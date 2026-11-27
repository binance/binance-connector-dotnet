//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Binance.Common.Tests;

/// <summary>Errors per cause, cancellation, TLS options, SOCKS5 and the request id, against loopback servers.</summary>
[Trait("Category", "Native")]
public class NativeFeatureTests
{
    private static readonly RestRequest Time = new("GET", "/api/v3/time");

    private static WebSocketApi Api(string url, string extra = "") =>
        new($$"""{"url":"{{url}}","timeout_ms":300,"reconnect_delay_ms":50,"connect_timeout_ms":3000{{extra}}}""");

    private static string UnusedUrl()
    {
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        var port = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        return $"ws://127.0.0.1:{port}";
    }

    // ---- WebSocket errors, by cause ----

    [Fact]
    public async Task AnErrorAnsweredByTheServerIsAResponseException()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        using var api = Api(server.Url);
        await api.ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => api.SendAsync("""{"method":"x"}"""));

        Assert.Equal(BinanceWebSocketErrorKind.ResponseError, error.WebSocketKind);
        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
        Assert.Equal("FAILURE", error.ErrorData!.Value.GetProperty("cancelResult").GetString());
        var limit = Assert.Single(error.WebSocketRateLimits);
        Assert.Equal((RateLimitType.RequestWeight, RateLimitInterval.Minute, 6000L, 9L), (limit.RateLimitType, limit.Interval, limit.Limit, limit.Count));
    }

    [Fact]
    public async Task ARequestWithoutAnAnswerIsATimeout()
    {
        using var server = new MiniWsServer((_, _, _) => null);
        using var api = Api(server.Url);
        await api.ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceTimeoutException>(() => api.SendAsync("""{"method":"x"}"""));

        Assert.Equal(BinanceWebSocketErrorKind.Timeout, error.WebSocketKind);
        Assert.Null(error.ErrorData);
        Assert.IsAssignableFrom<BinanceNetworkException>(error);
    }

    [Fact]
    public async Task ARequestBeforeConnectingIsNotConnected()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies(null));
        using var api = Api(server.Url);

        var error = await Assert.ThrowsAsync<BinanceWebSocketNotConnectedException>(() => api.SendAsync("""{"method":"x"}"""));

        Assert.Equal(BinanceWebSocketErrorKind.NotConnected, error.WebSocketKind);
    }

    [Fact]
    public async Task AConnectionDroppedBeforeTheAnswerIsNoResponse()
    {
        using var server = new MiniWsServer((s, connection, text) => { s.Drop(connection); return null; });
        using var api = Api(server.Url);
        await api.ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketNoResponseException>(() => api.SendAsync("""{"method":"x"}"""));

        Assert.True(error.RequestSent);
    }

    [Fact]
    public async Task ARejectedUpgradeIsAHandshakeException()
    {
        using var server = new Loopback(_ => (403, "{}"));
        using var api = Api(server.Url.Replace("http://", "ws://", StringComparison.Ordinal));

        var error = await Assert.ThrowsAsync<BinanceWebSocketHandshakeException>(() => api.ConnectAsync());

        Assert.Equal(403, error.HttpStatus);
    }

    [Fact]
    public async Task ANoListenerIsANetworkException()
    {
        using var api = Api(UnusedUrl());

        var error = await Assert.ThrowsAsync<BinanceNetworkException>(() => api.ConnectAsync());

        Assert.Equal(BinanceWebSocketErrorKind.Network, error.WebSocketKind);
    }

    // ---- Cancellation of the operations that cannot be aborted ----

    [Fact]
    public async Task CancellingConnectEndsTheWaitAtOnce()
    {
        using var hole = new BlackHole();
        using var api = Api(hole.WsUrl);
        using var streams = new WebSocketStreams($$"""{"url":"{{hole.WsUrl}}","connect_timeout_ms":3000}""");
        var watch = Stopwatch.StartNew();

        using var first = new CancellationTokenSource(TimeSpan.FromMilliseconds(150));
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => api.ConnectAsync(first.Token));
        using var second = new CancellationTokenSource(TimeSpan.FromMilliseconds(150));
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => streams.ConnectAsync(cancellationToken: second.Token));

        Assert.True(watch.Elapsed < TimeSpan.FromSeconds(2.5), $"took {watch.Elapsed}");
    }

    [Fact]
    public async Task CancellingASubscribeEndsTheWait()
    {
        using var server = new MiniWsServer((_, _, _) => null);
        using var api = Api(server.Url, ",\"timeout_ms\":5000");
        await api.ConnectAsync();
        using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(150));
        var watch = Stopwatch.StartNew();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => api.SubscribeAsync("""{"method":"userDataStream.subscribe"}""", cancellationToken: cts.Token));

        Assert.True(watch.Elapsed < TimeSpan.FromSeconds(2.5), $"took {watch.Elapsed}");
    }

    [Fact]
    public async Task ADisconnectWithAnUncancelledTokenStillCompletes()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies(null));
        using var api = Api(server.Url);
        await api.ConnectAsync();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

        await api.DisconnectAsync(cts.Token);

        Assert.False(api.IsConnected);
    }

    // ---- The id of a WebSocket API request ----

    [Fact]
    public async Task ARequestIdOf32HexCharactersIsKeptAndAnyOtherIsReplaced() // the product tests cover the Id property of the requests
    {
        const string Id = "0123456789abcdef0123456789abcdef";
        using var server = new MiniWsServer(MiniWsServer.ApiReplies(null));
        using var api = Api(server.Url);
        await api.ConnectAsync();

        await api.SendAsync($$"""{"method":"ping","id":"{{Id}}"}""");
        Assert.Equal(Id, server.ApiRequest().Id);
        Assert.Null(server.ApiRequest().Param("id"));

        await api.SendAsync("""{"method":"ping","id":"not-a-hex-id"}""");
        Assert.NotEqual("not-a-hex-id", server.ApiRequest().Id);
    }

    // ---- Decoding ----

    [Fact]
    public async Task ABodyThatDoesNotDecodeIsAClientExceptionWithThePayload()
    {
        using var server = new Loopback(_ => (200, """{"serverTime":{"nested":1}}"""));
        using var client = Rest(server.Url, _ => { });

        // The body is decoded when it is read.
        var response = await client.SendAsync(Time, TestJson.Default.TimeDto);
        var error = Assert.Throws<BinanceClientException>(() => response.Data());

        Assert.Contains("Failed to decode", error.Message, StringComparison.Ordinal);
        Assert.Contains("nested", error.Message, StringComparison.Ordinal);
        Assert.IsAssignableFrom<System.Text.Json.JsonException>(error.InnerException);
    }

    // ---- TLS ----

    private static RestApiClient Rest(string url, Action<RestApiConfig> configure)
    {
        var config = new RestApiConfig { BasePath = url, Retries = 0, Timeout = TimeSpan.FromSeconds(3), ProxyFromEnv = false };
        configure(config);
        return new RestApiClient(config);
    }

    [Fact]
    public async Task AnUnknownCaIsRejectedUntilItIsAdded()
    {
        using var server = new TlsLoopback();

        using (var client = Rest(server.Url, _ => { }))
            await Assert.ThrowsAsync<BinanceNetworkException>(() => client.SendAsync(Time, TestJson.Default.TimeDto));

        using (var client = Rest(server.Url, c => c.CaPem = server.CaPem))
            Assert.Equal(1, (await client.SendAsync(Time, TestJson.Default.TimeDto)).Data()!.ServerTime);

        var file = Path.GetTempFileName();
        try
        {
            await File.WriteAllTextAsync(file, server.CaPem);
            using var client = Rest(server.Url, c => { c.CaFile = file; c.CaOnly = true; });
            Assert.Equal(1, (await client.SendAsync(Time, TestJson.Default.TimeDto)).Data()!.ServerTime);
        }
        finally { File.Delete(file); }
    }

    [Fact]
    public void CaOnlyNeedsACertificate()
    {
        var config = new RestApiConfig { BasePath = "https://127.0.0.1", CaOnly = true };

        Assert.Throws<BinanceConfigException>(() => new RestApiClient(config));
        Assert.Throws<BinanceConfigException>(() => new RestApiClient(new RestApiConfig { BasePath = "https://127.0.0.1", CaPem = "not a pem" }));
    }

    [Fact]
    public async Task TheValidatorSeesTheCertificateAndDecides()
    {
        using var server = new TlsLoopback();
        var seen = new List<(string Thumbprint, int Depth, bool Preverified)>();
        var accept = true;
        ServerCertificateValidator validator = (certificate, depth, preverified) =>
        {
            lock (seen) seen.Add((certificate.Thumbprint, depth, preverified));
            return accept && preverified;
        };

        using (var client = Rest(server.Url, c => { c.CaPem = server.CaPem; c.ServerCertificateValidator = validator; }))
            await client.SendAsync(Time, TestJson.Default.TimeDto);
        Assert.Contains(seen, s => s.Depth == 0 && s.Preverified && s.Thumbprint == server.Certificate.Thumbprint);

        accept = false;
        using (var client = Rest(server.Url, c => { c.CaPem = server.CaPem; c.ServerCertificateValidator = validator; }))
            await Assert.ThrowsAsync<BinanceNetworkException>(() => client.SendAsync(Time, TestJson.Default.TimeDto));
    }

    [Fact]
    public async Task AValidatorThatThrowsRejectsAndOneThatAcceptsOverrides()
    {
        using var server = new TlsLoopback();

        using (var client = Rest(server.Url, c => c.ServerCertificateValidator = (_, _, _) => throw new InvalidOperationException("boom")))
            await Assert.ThrowsAsync<BinanceNetworkException>(() => client.SendAsync(Time, TestJson.Default.TimeDto));

        // The CA is not trusted (preverified is false), and the validator accepts anyway: pinning by thumbprint.
        var pin = server.Certificate.Thumbprint;
        using (var client = Rest(server.Url, c => c.ServerCertificateValidator = (certificate, depth, preverified) => depth != 0 || certificate.Thumbprint == pin)) // chain certificates are not pinned
            Assert.Equal(1, (await client.SendAsync(Time, TestJson.Default.TimeDto)).Data()!.ServerTime);
    }

    // ---- SOCKS5 ----

    [Theory]
    [InlineData(ProxyProtocol.Socks5, "127.0.0.1", 1)]
    [InlineData(ProxyProtocol.Socks5h, "binance.test", 3)]
    public async Task ARestClientTunnelsThroughASocks5Proxy(ProxyProtocol protocol, string host, int addressType)
    {
        using var server = new Loopback(_ => (200, """{"serverTime":7}"""));
        var port = new Uri(server.Url).Port;
        using var proxy = new Socks5Proxy(port);
        using var client = Rest($"http://{host}:{port}", c => { c.Proxy = new ProxyConfig("127.0.0.1", proxy.Port, protocol); });

        var response = await client.SendAsync(Time, TestJson.Default.TimeDto);

        Assert.Equal(7, response.Data()!.ServerTime);
        var connect = Assert.Single(proxy.Connects);
        Assert.Equal((addressType, host, port), connect);
    }
}
