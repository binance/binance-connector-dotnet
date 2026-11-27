//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Binance.Common.Tests;

/// <summary>A CA made for the test, and a certificate for 127.0.0.1 signed by it.</summary>
public sealed class TestCertificate : IDisposable
{
    /// <summary>Creates the CA and the certificate.</summary>
    public TestCertificate()
    {
        using var caKey = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var caRequest = new CertificateRequest("CN=Test CA", caKey, HashAlgorithmName.SHA256);
        caRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
        caRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
        var now = DateTimeOffset.UtcNow;
        using var ca = caRequest.CreateSelfSigned(now.AddDays(-1), now.AddDays(1));
        CaPem = ca.ExportCertificatePem();

        using var key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var request = new CertificateRequest("CN=127.0.0.1", key, HashAlgorithmName.SHA256);
        var names = new SubjectAlternativeNameBuilder();
        names.AddIpAddress(IPAddress.Loopback);
        request.CertificateExtensions.Add(names.Build());
        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, true));
        request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension([new Oid("1.3.6.1.5.5.7.3.1")], false));
        var serial = RandomNumberGenerator.GetBytes(8);
        serial[0] &= 0x7f;
        using var signed = request.Create(ca, now.AddHours(-1), now.AddDays(1), serial);
        using var withKey = signed.CopyWithPrivateKey(key);
        Certificate = X509CertificateLoader.LoadPkcs12(withKey.Export(X509ContentType.Pfx), null);
    }

    /// <summary>The certificate of the CA, in PEM.</summary>
    public string CaPem { get; }

    /// <summary>The server certificate, with its private key.</summary>
    public X509Certificate2 Certificate { get; }

    /// <inheritdoc/>
    public void Dispose() => Certificate.Dispose();
}

/// <summary>An HTTPS server on a loopback port with a certificate signed by a CA made for the test (<see cref="CaPem"/>).</summary>
public sealed class TlsLoopback : IDisposable
{
    private readonly TcpListener _listener = new(IPAddress.Loopback, 0);
    private readonly TestCertificate _test = new();
    private readonly X509Certificate2 _certificate;
    private int _handshakes;

    /// <summary>Starts the server; every request is answered with <c>{"serverTime":1}</c>.</summary>
    public TlsLoopback()
    {
        _certificate = _test.Certificate;
        CaPem = _test.CaPem;
        _listener.Start();
        Url = $"https://127.0.0.1:{((IPEndPoint)_listener.LocalEndpoint).Port}";
        _ = Task.Run(AcceptAsync);
    }

    /// <summary>The base URL.</summary>
    public string Url { get; }

    /// <summary>The certificate of the CA that signed the server certificate, in PEM.</summary>
    public string CaPem { get; }

    /// <summary>The server certificate (public part).</summary>
    public X509Certificate2 Certificate => _certificate;

    /// <summary>TLS handshakes that completed.</summary>
    public int Handshakes => Volatile.Read(ref _handshakes);

    private async Task AcceptAsync()
    {
        while (true)
        {
            TcpClient client;
            try { client = await _listener.AcceptTcpClientAsync(); }
            catch (Exception e) when (e is ObjectDisposedException or SocketException) { return; }
            _ = Task.Run(() => HandleAsync(client));
        }
    }

    private async Task HandleAsync(TcpClient client)
    {
        using (client)
        {
            try
            {
                await using var ssl = new SslStream(client.GetStream());
                await ssl.AuthenticateAsServerAsync(_certificate);
                Interlocked.Increment(ref _handshakes);
                var buffer = new byte[4096];
                var seen = "";
                while (!seen.Contains("\r\n\r\n", StringComparison.Ordinal))
                {
                    var n = await ssl.ReadAsync(buffer);
                    if (n == 0) return;
                    seen += Encoding.ASCII.GetString(buffer, 0, n);
                }
                const string Body = """{"serverTime":1}""";
                await ssl.WriteAsync(Encoding.ASCII.GetBytes($"HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: {Body.Length}\r\nConnection: close\r\n\r\n{Body}"));
                await ssl.FlushAsync();
            }
            catch (Exception e) when (e is IOException or System.Security.Authentication.AuthenticationException or ObjectDisposedException) { }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _listener.Stop();
        _test.Dispose();
    }
}

/// <summary>A SOCKS5 proxy (no authentication, CONNECT only) that relays every tunnel to <c>target</c> whatever the client asked for.</summary>
public sealed class Socks5Proxy : IDisposable
{
    private readonly TcpListener _listener = new(IPAddress.Loopback, 0);
    private readonly int _targetPort;

    /// <summary>Starts the proxy.</summary>
    /// <param name="targetPort">The loopback port the tunnels lead to.</param>
    public Socks5Proxy(int targetPort)
    {
        _targetPort = targetPort;
        _listener.Start();
        Port = ((IPEndPoint)_listener.LocalEndpoint).Port;
        _ = Task.Run(AcceptAsync);
    }

    /// <summary>The port of the proxy.</summary>
    public int Port { get; }

    /// <summary>The address type (1 IPv4, 3 domain name), host and port of each CONNECT.</summary>
    public List<(int AddressType, string Host, int Port)> Connects { get; } = [];

    private async Task AcceptAsync()
    {
        while (true)
        {
            TcpClient client;
            try { client = await _listener.AcceptTcpClientAsync(); }
            catch (Exception e) when (e is ObjectDisposedException or SocketException) { return; }
            _ = Task.Run(() => RelayAsync(client));
        }
    }

    private static async Task ReadExactlyAsync(NetworkStream stream, byte[] buffer, int count)
    {
        var read = 0;
        while (read < count)
        {
            var n = await stream.ReadAsync(buffer.AsMemory(read, count - read));
            if (n == 0) throw new IOException("closed");
            read += n;
        }
    }

    private async Task RelayAsync(TcpClient client)
    {
        using (client)
        {
            try
            {
                var stream = client.GetStream();
                var b = new byte[4096];
                await ReadExactlyAsync(stream, b, 2); // 05, number of methods
                await ReadExactlyAsync(stream, b, b[1]);
                await stream.WriteAsync(new byte[] { 5, 0 }); // no authentication
                await ReadExactlyAsync(stream, b, 4); // 05 01 00 atyp
                var type = b[3];
                string host;
                if (type == 1)
                {
                    await ReadExactlyAsync(stream, b, 4);
                    host = new IPAddress(b.AsSpan(0, 4)).ToString();
                }
                else
                {
                    await ReadExactlyAsync(stream, b, 1);
                    var length = b[0];
                    await ReadExactlyAsync(stream, b, length);
                    host = Encoding.ASCII.GetString(b, 0, length);
                }
                await ReadExactlyAsync(stream, b, 2);
                var port = (b[0] << 8) | b[1];
                lock (Connects) Connects.Add((type, host, port));
                using var upstream = new TcpClient();
                await upstream.ConnectAsync(IPAddress.Loopback, _targetPort);
                await stream.WriteAsync(new byte[] { 5, 0, 0, 1, 0, 0, 0, 0, 0, 0 });
                var up = upstream.GetStream();
                // The loopback server answers only for its own host name: the first chunk (the request head) names it.
                var n = await stream.ReadAsync(b);
                var head = Encoding.ASCII.GetString(b, 0, n).Replace($"Host: {host}:{port}", $"Host: 127.0.0.1:{_targetPort}", StringComparison.Ordinal);
                await up.WriteAsync(Encoding.ASCII.GetBytes(head));
                await Task.WhenAny(stream.CopyToAsync(up), up.CopyToAsync(stream));
            }
            catch (Exception e) when (e is IOException or SocketException or ObjectDisposedException) { }
        }
    }

    /// <inheritdoc/>
    public void Dispose() => _listener.Stop();
}

/// <summary>A TCP server that accepts connections and never answers.</summary>
public sealed class BlackHole : IDisposable
{
    private readonly TcpListener _listener = new(IPAddress.Loopback, 0);
    private readonly List<TcpClient> _clients = [];

    /// <summary>Starts the server.</summary>
    public BlackHole()
    {
        _listener.Start();
        Port = ((IPEndPoint)_listener.LocalEndpoint).Port;
        _ = Task.Run(async () =>
        {
            try { while (true) { var c = await _listener.AcceptTcpClientAsync(); lock (_clients) _clients.Add(c); } }
            catch (Exception e) when (e is ObjectDisposedException or SocketException) { }
        });
    }

    /// <summary>The port.</summary>
    public int Port { get; }

    /// <summary>The WebSocket URL.</summary>
    public string WsUrl => $"ws://127.0.0.1:{Port}";

    /// <inheritdoc/>
    public void Dispose()
    {
        _listener.Stop();
        lock (_clients) foreach (var c in _clients) c.Dispose();
    }
}
