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
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Binance.Common.Tests;

/// <summary>A minimal WebSocket server (RFC 6455, unfragmented frames) that records what it receives, counts pings and can drop connections.</summary>
public sealed class MiniWsServer : IDisposable
{
    private readonly TcpListener _listener = new(IPAddress.Loopback, 0);
    private readonly Func<MiniWsServer, int, string, string?> _onText;
    private readonly List<TcpClient> _clients = [];
    private readonly X509Certificate2? _certificate;
    private int _pings;

    /// <param name="onText">Gets the connection number (1-based) and a text frame, and returns the reply frame, if any.</param>
    /// <param name="certificate">Serves <c>wss</c> with this certificate instead of <c>ws</c>.</param>
    public MiniWsServer(Func<MiniWsServer, int, string, string?> onText, X509Certificate2? certificate = null)
    {
        _onText = onText;
        _certificate = certificate;
        _listener.Start();
        Url = $"{(certificate is null ? "ws" : "wss")}://127.0.0.1:{((IPEndPoint)_listener.LocalEndpoint).Port}";
        _ = Task.Run(AcceptLoop);
    }

    public string Url { get; }

    public int Pings => Volatile.Read(ref _pings);

    public List<string> Received { get; } = [];
    /// <summary>For each text of <see cref="Received"/>, the number of the connection it came on.</summary>
    public List<int> ReceivedOn { get; } = [];

    /// <summary>Whether the streams are signed: events are then <c>DATA</c> frames and subscriptions are commands.</summary>
    public bool Signed { get; init; }


    /// <summary>The HTTP upgrade requests (request line and headers) of the connections.</summary>
    public List<string> Handshakes { get; } = [];

    public int Connections { get { lock (_clients) return _clients.Count; } }

    /// <summary>Answers every SUBSCRIBE with success, except those for streams starting with "bad".</summary>
    public static string? AcceptSubscribes(MiniWsServer server, int connection, string text)
    {
        using var doc = JsonDocument.Parse(text);
        var root = doc.RootElement;
        if (root.TryGetProperty("command", out var command))
            return $$$"""{"type":"COMMAND","subType":"{{{command.GetString()}}}","data":"SUCCESS","code":"00000000"}""";
        if (!root.TryGetProperty("method", out var method) || method.GetString() != "SUBSCRIBE") return null;
        var id = root.GetProperty("id").GetRawText();
        return root.GetProperty("params")[0].GetString()!.StartsWith("bad", StringComparison.Ordinal)
            ? $$$"""{"id":{{{id}}},"error":{"code":2,"msg":"Invalid request"}}"""
            : $$"""{"result":null,"id":{{id}}}""";
    }

    /// <summary>
    /// Answers the requests of a WebSocket API client with <paramref name="envelope"/> (the response as the API documents it) carrying the id of the request, and
    /// the SUBSCRIBE of a stream client with success.
    /// </summary>
    public static Func<MiniWsServer, int, string, string?> ApiReplies(string? envelope) => (server, connection, text) =>
    {
        var request = JsonNode.Parse(text)?.AsObject();
        if (request is null) return null;
        if (request["method"]?.GetValue<string>() == "SUBSCRIBE") return AcceptSubscribes(server, connection, text);
        if (request["id"] is not { } id) return null;
        var response = envelope is null ? new JsonObject { ["status"] = 200, ["result"] = null } : JsonNode.Parse(envelope) as JsonObject ?? new JsonObject { ["status"] = 200, ["result"] = JsonNode.Parse(envelope) };
        response["id"] = id.DeepClone();
        return response.ToJsonString();
    };

    /// <summary>Answers every WebSocket API request with the error envelope of Binance (<c>status</c> and <c>error.code</c>/<c>error.msg</c>).</summary>
    public static Func<MiniWsServer, int, string, string?> ApiErrors(int status, int code) => (server, connection, text) =>
    {
        var request = JsonNode.Parse(text)?.AsObject();
        if (request?["id"] is not { } id) return null;
        return new JsonObject
        {
            ["id"] = id.DeepClone(),
            ["status"] = status,
            ["error"] = new JsonObject
            {
                ["code"] = code,
                ["msg"] = "Mandatory parameter was not sent, was empty/null, or malformed.",
                ["data"] = new JsonObject { ["cancelResult"] = "FAILURE", ["newOrderResult"] = "NOT_ATTEMPTED" },
            },
            ["rateLimits"] = new JsonArray(new JsonObject { ["rateLimitType"] = "REQUEST_WEIGHT", ["interval"] = "MINUTE", ["intervalNum"] = 1, ["limit"] = 6000, ["count"] = 9 }),
        }.ToJsonString();
    };

    /// <summary>The last WebSocket API request received (not a SUBSCRIBE).</summary>
    public ApiFrame ApiRequest()
    {
        lock (Received)
        {
            var text = Received.Last(r => r.Contains("\"method\"", StringComparison.Ordinal) && !r.Contains("\"SUBSCRIBE\"", StringComparison.Ordinal));
            return new ApiFrame(JsonDocument.Parse(text).RootElement.Clone());
        }
    }

    public static async Task<bool> WaitFor(Func<bool> condition, int seconds = 10)
    {
        var deadline = DateTime.UtcNow.AddSeconds(seconds);
        while (DateTime.UtcNow < deadline)
        {
            if (condition()) return true;
            await Task.Delay(10);
        }
        return condition();
    }

    /// <summary>The streams subscribed so far (the client may put several streams into one SUBSCRIBE).</summary>
    public int SubscribedStreams()
    {
        lock (Received)
            return Received.Where(r => r.Contains("\"SUBSCRIBE\"", StringComparison.Ordinal))
                .Sum(r => JsonDocument.Parse(r).RootElement.GetProperty("params").GetArrayLength());
    }

    public int Subscribes() { lock (Received) return Received.Count(r => r.Contains("\"SUBSCRIBE\"", StringComparison.Ordinal)); }

    /// <summary>The stream of the SUBSCRIBE number <paramref name="index"/>.</summary>
    public string SubscribedStream(int index = 0)
    {
        lock (Received)
        {
            var text = Received.Where(r => r.Contains("\"SUBSCRIBE\"", StringComparison.Ordinal)).ElementAt(index);
            return StreamOf(text);
        }
    }

    private static string StreamOf(string subscribe)
    {
        var root = JsonDocument.Parse(subscribe).RootElement;
        return root.TryGetProperty("value", out var value) ? value.GetString()! : root.GetProperty("params")[0].GetString()!;
    }

    /// <summary>Sends an event of <paramref name="stream"/> on the connection that subscribed to it.</summary>
    /// <param name="stream">The stream name.</param>
    /// <param name="json">The event.</param>
    public void Publish(string stream, string json)
    {
        int connection;
        lock (Received)
        {
            var index = Received.FindIndex(r => r.Contains("\"SUBSCRIBE\"", StringComparison.Ordinal) && r.Contains(stream, StringComparison.Ordinal));
            connection = ReceivedOn[index];
        }
        Send(connection, Signed
            ? new JsonObject { ["type"] = "DATA", ["topic"] = stream, ["data"] = json }.ToJsonString()
            : new JsonObject { ["stream"] = stream, ["data"] = JsonNode.Parse(json) }.ToJsonString());
    }

    public string FirstSubscribe() { lock (Received) return Received.First(r => r.Contains("\"SUBSCRIBE\"", StringComparison.Ordinal)); }

    /// <summary>Closes the TCP connection number <paramref name="connection"/> without a close frame.</summary>
    public void Drop(int connection)
    {
        lock (_clients) _clients[connection - 1].Close();
    }

    public void Send(int connection, string text)
    {
        TcpClient client;
        lock (_clients) client = _clients[connection - 1];
        Write(client.GetStream(), 0x1, Encoding.UTF8.GetBytes(text));
    }

    public void Dispose()
    {
        _listener.Stop();
        lock (_clients) foreach (var c in _clients) c.Close();
    }

    private async Task AcceptLoop()
    {
        try
        {
            while (true)
            {
                var client = await _listener.AcceptTcpClientAsync();
                int number;
                lock (_clients) { _clients.Add(client); number = _clients.Count; }
                _ = Task.Run(() => Serve(client, number));
            }
        }
        catch (Exception e) when (e is SocketException or ObjectDisposedException) { }
    }

    private async Task Serve(TcpClient client, int number)
    {
        try
        {
            Stream stream = client.GetStream();
            if (_certificate is not null)
            {
                var ssl = new SslStream(stream);
                await ssl.AuthenticateAsServerAsync(_certificate);
                stream = ssl;
            }
            var request = new StringBuilder();
            var one = new byte[1];
            while (!request.ToString().EndsWith("\r\n\r\n", StringComparison.Ordinal))
            {
                if (await stream.ReadAsync(one) == 0) return;
                request.Append((char)one[0]);
            }
            lock (Handshakes) Handshakes.Add(request.ToString());
            var key = System.Text.RegularExpressions.Regex.Match(request.ToString(), "Sec-WebSocket-Key: (.*)\r\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Groups[1].Value.Trim();
            var accept = System.Convert.ToBase64String(SHA1.HashData(Encoding.ASCII.GetBytes(key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11")));
            await stream.WriteAsync(Encoding.ASCII.GetBytes($"HTTP/1.1 101 Switching Protocols\r\nUpgrade: websocket\r\nConnection: Upgrade\r\nSec-WebSocket-Accept: {accept}\r\n\r\n"));
            while (true)
            {
                var header = new byte[2];
                await ReadExactly(stream, header);
                var opcode = header[0] & 0x0F;
                long length = header[1] & 0x7F;
                if (length == 126) { var b = new byte[2]; await ReadExactly(stream, b); length = (b[0] << 8) | b[1]; }
                else if (length == 127) { var b = new byte[8]; await ReadExactly(stream, b); length = (long)System.Buffers.Binary.BinaryPrimitives.ReadUInt64BigEndian(b); }
                var mask = new byte[4];
                if ((header[1] & 0x80) != 0) await ReadExactly(stream, mask);
                var payload = new byte[length];
                await ReadExactly(stream, payload);
                for (var i = 0; i < payload.Length; i++) payload[i] ^= mask[i % 4];
                switch (opcode)
                {
                    case 0x1:
                        var text = Encoding.UTF8.GetString(payload);
                        lock (Received) { Received.Add(text); ReceivedOn.Add(number); }
                        if (_onText(this, number, text) is { } reply) Write(stream, 0x1, Encoding.UTF8.GetBytes(reply));
                        break;
                    case 0x9:
                        Interlocked.Increment(ref _pings);
                        Write(stream, 0xA, payload);
                        break;
                    case 0x8:
                        Write(stream, 0x8, payload);
                        client.Close();
                        return;
                }
            }
        }
        catch (Exception e) when (e is IOException or ObjectDisposedException or SocketException or EndOfStreamException or System.Security.Authentication.AuthenticationException) { }
    }

    private static async Task ReadExactly(Stream stream, byte[] buffer)
    {
        var read = 0;
        while (read < buffer.Length)
        {
            var n = await stream.ReadAsync(buffer.AsMemory(read));
            if (n == 0) throw new EndOfStreamException();
            read += n;
        }
    }

    private static void Write(Stream stream, int opcode, byte[] payload)
    {
        var frame = new List<byte> { (byte)(0x80 | opcode) };
        if (payload.Length < 126) frame.Add((byte)payload.Length);
        else if (payload.Length < 65536) { frame.Add(126); frame.Add((byte)(payload.Length >> 8)); frame.Add((byte)payload.Length); }
        else { frame.Add(127); for (var shift = 56; shift >= 0; shift -= 8) frame.Add((byte)((long)payload.Length >> shift)); }
        frame.AddRange(payload);
        lock (stream) stream.Write(frame.ToArray());
    }
}

/// <summary>A request frame of the WebSocket API.</summary>
/// <param name="Root">The frame.</param>
public sealed record ApiFrame(JsonElement Root)
{
    /// <summary>The method.</summary>
    public string Method => Root.GetProperty("method").GetString()!;

    /// <summary>The request id.</summary>
    public string Id => Root.GetProperty("id").ToString();

    /// <summary>A parameter as text (numbers as written), or null.</summary>
    public string? Param(string name) =>
        Root.TryGetProperty("params", out var p) && p.TryGetProperty(name, out var v) && v.ValueKind != JsonValueKind.Null ? Text(v) : null;

    private static string Text(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.True => "true",
        JsonValueKind.False => "false",
        _ => value.ToString(),
    };
}
