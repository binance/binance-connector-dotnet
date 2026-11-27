//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;

namespace Binance.Common.Tests;

[Trait("Category", "Native")]
public class StreamSubscriptionTests
{
    private static string Config(MiniWsServer server, string extra = "") =>
        $$"""{"url":"{{server.Url}}","reconnect_delay_ms":50,"connect_timeout_ms":3000{{extra}}}""";

    [Fact]
    public async Task TheReaderCompletesOnANormalDisconnect()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var streams = new WebSocketStreams(Config(server));
        await streams.ConnectAsync();
        using var sub = streams.Subscribe("a@b"); // after connecting, the client sends a SUBSCRIBE
        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        Assert.True(sub.IsActive);

        await streams.DisconnectAsync();

        await sub.Completion.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.False(sub.IsActive);
        Assert.False(await sub.Reader.WaitToReadAsync());
        await sub.Reader.Completion;
    }

    [Fact]
    public async Task TheReaderFaultsWhenTheServerRejectsTheSubscribe()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var streams = new WebSocketStreams(Config(server));
        await streams.ConnectAsync();
        using var sub = streams.Subscribe("bad@stream");

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(async () =>
        {
            await foreach (var message in sub.Reader.ReadAllAsync().WithCancellation(new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token)) _ = message;
        });

        Assert.Equal(BinanceErrorKind.WebSocket, error.Kind);
        Assert.Equal(BinanceWebSocketErrorKind.ResponseError, error.WebSocketKind);
        Assert.Contains("Invalid request", error.Message, StringComparison.Ordinal);
        await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => sub.Completion);
        Assert.False(sub.IsActive);
    }

    [Fact]
    public async Task AReconnectDoesNotEndTheSubscription()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var streams = new WebSocketStreams(Config(server));
        await streams.ConnectAsync();
        using var sub = streams.Subscribe("a@b");
        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));

        server.Drop(1);

        Assert.True(await MiniWsServer.WaitFor(() => server.Connections >= 2));
        await Task.Delay(300); // the subscription is restored on the new connection
        Assert.False(sub.Completion.IsCompleted);
        Assert.True(sub.IsActive);
        server.Send(server.Connections, """{"stream":"a@b","data":{"x":1}}""");
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        Assert.Contains("\"x\":1", await sub.Reader.ReadAsync(timeout.Token), StringComparison.Ordinal);
    }

    [Fact]
    public async Task DisposingTheClientCompletesTheReaders()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        var streams = new WebSocketStreams(Config(server));
        await streams.ConnectAsync();
        var sub = streams.Subscribe("a@b");

        streams.Dispose();

        await sub.Completion.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.False(sub.IsActive);
    }

    [Fact]
    public async Task PingsReachTheServer()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var streams = new WebSocketStreams(Config(server));
        await streams.ConnectAsync();
        streams.PingServer();
        Assert.True(await MiniWsServer.WaitFor(() => server.Pings == 1));

        using var apiServer = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var api = new WebSocketApi($$"""{"url":"{{apiServer.Url}}"}""");
        await api.ConnectAsync();
        api.PingServer();
        Assert.True(await MiniWsServer.WaitFor(() => apiServer.Pings == 1));
    }

    [Fact]
    public async Task StrictlyNumericIdsAreSentAsNumbers()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url }, streamIdIsStrictlyNumber: true);
        await client.ConnectAsync();
        using var numeric = client.Subscribe("a@b", TestJson.Default.TimeDto, id: "42");
        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        using var doc = JsonDocument.Parse(server.FirstSubscribe());
        Assert.Equal(JsonValueKind.Number, doc.RootElement.GetProperty("id").ValueKind);
        Assert.Equal(42, doc.RootElement.GetProperty("id").GetInt32());

        using var text = client.Subscribe("c@d", TestJson.Default.TimeDto, id: "abc");
        Assert.True(await MiniWsServer.WaitFor(() => server.SubscribedStreams() == 2));
        string second;
        lock (server.Received) second = server.Received.Last(r => r.Contains("c@d", StringComparison.Ordinal));
        using var doc2 = JsonDocument.Parse(second);
        Assert.Equal(JsonValueKind.Number, doc2.RootElement.GetProperty("id").ValueKind);
    }

    [Fact]
    public async Task SignedStreamsAuthenticateTheUpgrade()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }, signedStreams: true);

        await client.ConnectAsync();

        var handshake = Assert.Single(server.Handshakes);
        Assert.Contains("X-MBX-APIKEY: test-key", handshake, StringComparison.OrdinalIgnoreCase);
        Assert.Matches("timestamp=\\d+", handshake);
        Assert.Matches("signature=[0-9a-f]+", handshake);
    }
}

sealed class CapturingLoggerFactory : Microsoft.Extensions.Logging.ILoggerFactory
{
    public List<(Microsoft.Extensions.Logging.LogLevel Level, string Message)> Entries { get; } = [];

    public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName) => new Logger(this);

    public void AddProvider(Microsoft.Extensions.Logging.ILoggerProvider provider) { }

    public void Dispose() { }

    private sealed class Logger(CapturingLoggerFactory owner) : Microsoft.Extensions.Logging.ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel) => true;

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (owner.Entries) owner.Entries.Add((logLevel, formatter(state, exception)));
        }
    }
}

// The log is process-wide: the tests that configure it run one at a time.
[Collection("Logging")]
[Trait("Category", "Native")]
public class DecodeFailureTests
{
    [Fact]
    public async Task AnArrayOfEventsIsDeliveredEventByEventAndAnObjectIsWrappedForAListType()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        await client.ConnectAsync();
        using var single = client.Subscribe("a@b", TestJson.Default.TimeDto);
        using var list = client.Subscribe("c@d", TestJson.Default.ListTimeDto);
        Assert.True(await MiniWsServer.WaitFor(() => server.SubscribedStreams() == 2));

        server.Publish("a@b", """[{"serverTime":1},{"serverTime":2}]""");
        server.Publish("a@b", """[{"serverTime":"x"},{"serverTime":4}]""");
        server.Publish("a@b", """{"serverTime":3}""");
        server.Publish("c@d", """{"serverTime":9}""");

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        Assert.Equal(1, (await single.Events.ReadAsync(timeout.Token)).ServerTime);
        Assert.Equal(2, (await single.Events.ReadAsync(timeout.Token)).ServerTime);
        Assert.Equal(3, (await single.Events.ReadAsync(timeout.Token)).ServerTime);
        Assert.Equal(1, single.DecodeFailureCount);
        var wrapped = await list.Events.ReadAsync(timeout.Token);
        Assert.Equal(9, Assert.Single(wrapped).ServerTime);
    }

    [Fact]
    public async Task AMessageThatDoesNotDecodeIsSkippedLoggedAndCounted()
    {
        var log = new CapturingLoggerFactory();
        BinanceLogging.Configure(log);
        try
        {
            using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
            using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
            await client.ConnectAsync();
            using var subscription = client.Subscribe("a@b", TestJson.Default.TimeDto);
            Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));

            server.Publish("a@b", """{"serverTime":"not a number"}""");
            server.Publish("a@b", "{\"serverTime\":\"x\",\"padding\":\"" + new string('p', 2000) + "\"}");
            server.Publish("a@b", """{"serverTime":7}""");

            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var received = await subscription.Events.ReadAsync(timeout.Token);
            Assert.Equal(7, received.ServerTime);
            Assert.Equal(2, subscription.DecodeFailureCount);
            Assert.True(subscription.IsActive);
            (Microsoft.Extensions.Logging.LogLevel Level, string Message)[] entries;
            lock (log.Entries) entries = [.. log.Entries.Where(e => e.Message.StartsWith("Stream a@b", StringComparison.Ordinal))];
            Assert.Equal(2, entries.Length);
            Assert.All(entries, e => Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Warning, e.Level));
            Assert.Contains("not a number", entries[0].Message, StringComparison.Ordinal);
            Assert.True(entries[1].Message.Length < 900 && entries[1].Message.EndsWith("...", StringComparison.Ordinal));
        }
        finally
        {
            BinanceLogging.Configure(null);
        }
    }
}
