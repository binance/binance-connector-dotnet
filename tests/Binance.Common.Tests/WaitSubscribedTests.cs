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
public class WaitSubscribedTests
{
    private static WebSocketStreamsClient Client(MiniWsServer server) => new(new WebSocketStreamsConfig { Url = server.Url });

    [Fact]
    public async Task ItCompletesOnceTheServerAcknowledges()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = Client(server);
        await client.ConnectAsync();

        using var subscription = client.Subscribe("a@b", NativeJson.Default.DictionaryStringString);
        await subscription.WaitSubscribedAsync().WaitAsync(TimeSpan.FromSeconds(10));

        Assert.True(subscription.IsActive);
        Assert.Equal(1, server.Subscribes());
    }

    [Fact]
    public async Task BeforeConnectingItCompletesOnceTheConnectionOpens()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = Client(server);

        using var subscription = client.Subscribe("a@b", NativeJson.Default.DictionaryStringString);
        var waiting = subscription.WaitSubscribedAsync();
        await Task.Delay(200);
        Assert.False(waiting.IsCompleted);
        await client.ConnectAsync();

        await waiting.WaitAsync(TimeSpan.FromSeconds(10));
        Assert.True(subscription.IsActive);
    }

    [Fact]
    public async Task ARejectedSubscriptionFailsTheWait()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = Client(server);
        await client.ConnectAsync();

        using var subscription = client.Subscribe("bad@stream", NativeJson.Default.DictionaryStringString);
        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => subscription.WaitSubscribedAsync());

        Assert.Equal(BinanceWebSocketErrorKind.ResponseError, error.WebSocketKind);
        Assert.Contains("Invalid request", error.Message, StringComparison.Ordinal);
    }

    [Fact]
    public async Task CancellingAbandonsTheWaitAndTheSubscriptionStays()
    {
        using var server = new MiniWsServer((_, _, _) => null); // never answers
        await using var client = Client(server);
        await client.ConnectAsync();
        using var subscription = client.Subscribe("a@b", NativeJson.Default.DictionaryStringString);
        using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(200));

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => subscription.WaitSubscribedAsync(cts.Token));
        Assert.True(client.IsSubscribed("a@b"));
    }

    [Fact]
    public async Task AnUnsubscribedStreamEndsTheWait()
    {
        using var server = new MiniWsServer((_, _, _) => null); // never answers
        await using var client = Client(server);
        await client.ConnectAsync();
        var subscription = client.Subscribe("a@b");
        var waiting = subscription.WaitSubscribedAsync();

        subscription.Unsubscribe();

        await Assert.ThrowsAsync<BinanceCancelledException>(() => waiting.WaitAsync(TimeSpan.FromSeconds(10)));
        Assert.False(client.IsSubscribed("a@b"));
        Assert.True(subscription.Completion.IsCompleted);
    }
}

[Trait("Category", "Native")]
public class CallbackTests
{
    [Fact]
    public async Task EveryCallbackGetsEveryEventInOrder()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        await client.ConnectAsync();
        using var subscription = client.Subscribe("a@trade");
        await subscription.WaitSubscribedAsync().WaitAsync(TimeSpan.FromSeconds(10));
        var first = new List<string>();
        var second = new List<string>();
        using var one = subscription.OnMessage(e => { lock (first) first.Add(e.GetProperty("p").GetString()!); });
        using var two = subscription.OnMessage(e => { lock (second) second.Add(e.GetProperty("p").GetString()!); return ValueTask.CompletedTask; });
        using var throwing = subscription.OnMessage(_ => throw new InvalidOperationException("ignored"));

        server.Publish("a@trade", """{"p":"1"}""");
        server.Publish("a@trade", """{"p":"2"}""");

        Assert.True(await MiniWsServer.WaitFor(() => { lock (second) return second.Count == 2; }));
        lock (first) Assert.Equal(["1", "2"], first);
        lock (second) Assert.Equal(["1", "2"], second);
        Assert.Throws<InvalidOperationException>(() => subscription.Events);
    }

    [Fact]
    public async Task ARemovedCallbackGetsNothingMore()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        await client.ConnectAsync();
        using var subscription = client.Subscribe("a@trade");
        await subscription.WaitSubscribedAsync().WaitAsync(TimeSpan.FromSeconds(10));
        var kept = 0;
        var removed = 0;
        using var keep = subscription.OnMessage(_ => Interlocked.Increment(ref kept));
        var remove = subscription.OnMessage(_ => Interlocked.Increment(ref removed));

        server.Publish("a@trade", "{}");
        Assert.True(await MiniWsServer.WaitFor(() => Volatile.Read(ref removed) == 1));
        remove.Dispose();
        server.Publish("a@trade", "{}");

        Assert.True(await MiniWsServer.WaitFor(() => Volatile.Read(ref kept) == 2));
        Assert.Equal(1, Volatile.Read(ref removed));
    }

    [Fact]
    public void AReaderAndCallbacksDoNotMix()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        using var subscription = client.Subscribe("a@trade");
        _ = subscription.Events;
        _ = subscription.Events; // the same reader again
        Assert.Throws<InvalidOperationException>(() => subscription.OnMessage(_ => { }));
    }

    [Fact]
    public async Task ConnectionEventsAndMessagesReachCallbacks()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        var events = new List<ConnectionEventType>();
        var messages = 0;
        using var onEvent = client.OnEvent(e => { lock (events) events.Add(e.Type); });
        using var onMessage = client.OnMessage(_ => Interlocked.Increment(ref messages));

        await client.ConnectAsync(["a@trade"]);
        server.Send(1, """{"stream":"a@trade","data":{"p":"2"}}""");

        Assert.True(await MiniWsServer.WaitFor(() => { lock (events) return events.Contains(ConnectionEventType.Open); }));
        Assert.True(await MiniWsServer.WaitFor(() => Volatile.Read(ref messages) >= 1));
        Assert.Throws<InvalidOperationException>(() => client.Events);
        Assert.Throws<InvalidOperationException>(() => client.EnableMessages());
    }
}

[Trait("Category", "Native")]
public class StreamNameTests
{
    [Fact]
    public async Task StreamsAreSubscribedAndUnsubscribedByName()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        await client.ConnectAsync();
        var messages = client.EnableMessages();

        client.Subscribe(["a@trade", "b@trade"], id: 7);

        Assert.True(client.IsSubscribed("a@trade"));
        Assert.True(client.IsSubscribed("b@trade"));
        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        using (var subscribe = JsonDocument.Parse(server.FirstSubscribe()))
            Assert.Equal(7, subscribe.RootElement.GetProperty("id").GetInt32());
        server.Publish("a@trade", """{"p":"1"}""");
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        // Every message arrives, the SUBSCRIBE acknowledgement first.
        ConnectionMessage message;
        do message = await messages.ReadAsync(cts.Token);
        while (!message.Data.Contains("a@trade", StringComparison.Ordinal));

        client.Unsubscribe(["a@trade"]);

        Assert.False(client.IsSubscribed("a@trade"));
        Assert.True(client.IsSubscribed("b@trade"));
        Assert.True(await MiniWsServer.WaitFor(() => { lock (server.Received) return server.Received.Any(r => r.Contains("\"UNSUBSCRIBE\"", StringComparison.Ordinal)); }));
        Assert.Throws<ArgumentException>(() => client.Subscribe(Array.Empty<string>()));
    }
}
