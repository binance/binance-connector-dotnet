//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;

namespace Binance.Common.Tests;

// The library thread writes into these channels; the tests write the same way, through the Registry.
public class EventBufferTests
{
    [Fact]
    public void ABoundedStreamBufferCountsWhatItDrops()
    {
        using var sub = new StreamSubscription("btcusdt@depth", capacity: 2);
        var writer = Registry.Get<Channel<string>>(sub.Id)!.Writer;

        for (var i = 0; i < 5; i++) Assert.True(writer.TryWrite(i.ToString(System.Globalization.CultureInfo.InvariantCulture)));

        Assert.Equal(3, sub.DroppedCount);
        Assert.True(sub.Reader.TryRead(out var a));
        Assert.True(sub.Reader.TryRead(out var b));
        Assert.Equal(("3", "4"), (a, b)); // the newest are kept
    }

    [Fact]
    public void AnUnboundedStreamBufferDropsNothing()
    {
        using var sub = new StreamSubscription("btcusdt@depth", capacity: null);
        var writer = Registry.Get<Channel<string>>(sub.Id)!.Writer;

        for (var i = 0; i < 5_000; i++) Assert.True(writer.TryWrite("{}"));

        Assert.Equal(0, sub.DroppedCount);
    }

    [Fact]
    public void LifecycleEventsAreBoundedAndCounted()
    {
        using var sink = new EventSink();
        var writer = sink.Writer;

        for (var i = 0; i < EventSink.Capacity + 10; i++)
            Assert.True(writer.TryWrite(new(ConnectionEventType.Ping, "", 0, i.ToString(System.Globalization.CultureInfo.InvariantCulture))));

        Assert.Equal(10, sink.DroppedCount);
        Assert.Equal(EventSink.Capacity, sink.Reader.Count);
        Assert.True(sink.Reader.TryRead(out var oldest));
        Assert.Equal("10", oldest.ConnectionId);
    }
}

[Trait("Category", "Native")]
public class UserDataSubscriptionTests
{
    [Fact]
    public async Task AResponseThatDoesNotDecodeFailsOnReadAndTheSubscriptionEndsOnDispose()
    {
        // The result is a string where the type expects an object.
        using var server = new MiniWsServer((_, _, text) =>
        {
            var request = JsonNode.Parse(text)!.AsObject();
            return new JsonObject { ["id"] = request["id"]!.DeepClone(), ["status"] = 200, ["result"] = "not an object" }.ToJsonString();
        });
        await using var api = new WebSocketApiClient(new WebSocketApiConfig { Url = server.Url, ReconnectDelay = TimeSpan.FromMilliseconds(50) });
        await api.ConnectAsync();
        int Subscribes() { lock (server.Received) return server.Received.Count(r => r.Contains("userDataStream.subscribe", StringComparison.Ordinal)); }

        // The response is decoded when it is read (as in the other connectors), so the subscription is opened.
        var subscription = await api.SubscribeAsync(
            new WebSocketApiRequest("userDataStream.subscribe"), NativeJson.Default.DictionaryStringString, NativeJson.Default.DictionaryStringString);
        Assert.Throws<BinanceClientException>(() => subscription.Response.Data());
        Assert.Equal(1, Subscribes());

        // Disposed, it is not sent again on the new connection.
        subscription.Dispose();
        server.Drop(1);
        Assert.True(await MiniWsServer.WaitFor(() => { lock (server.Handshakes) return server.Handshakes.Count == 2; }));
        await Task.Delay(500);
        Assert.Equal(1, Subscribes());
    }
}
