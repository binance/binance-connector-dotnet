//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;

namespace Binance.Common.Tests;

/// <summary>The calls for what has no generated method: any endpoint, WebSocket API method or stream, and the raw messages.</summary>
[Trait("Category", "Native")]
public sealed class GenericRequestTests
{
    [Fact]
    public async Task AnyEndpointCanBeCalledSignedOrNot()
    {
        using var server = new Loopback(_ => (200, """{"serverTime":5}"""));
        using var client = new RestApiClient(new RestApiConfig { BasePath = server.Url, ApiKey = "k", ApiSecret = "s", Retries = 0 });

        var response = await client.SendRequestAsync("/api/v3/time", HttpMethod.Get, new Dictionary<string, object?> { ["symbol"] = "BNBUSDT", ["limit"] = 5, ["skipped"] = null });
        Assert.Equal(5, response.Data().GetProperty("serverTime").GetInt64());
        var seen = server.Requests.Single();
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/time", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("5", seen.Param("limit"));
        Assert.Null(seen.Param("skipped"));
        Assert.Null(seen.Param("signature"));

        await client.SendRequestAsync("/api/v3/order", HttpMethod.Delete, new Dictionary<string, object?> { ["price"] = 1.50m }, signed: true);
        var signed = server.Requests[1];
        Assert.Equal("DELETE", signed.Method);
        Assert.Equal("1.50", signed.Param("price"));
        Assert.NotNull(signed.Param("timestamp"));
        Assert.NotNull(signed.Param("signature"));
        Assert.Equal("k", signed.Key);

        await Assert.ThrowsAsync<ArgumentException>(() => client.SendRequestAsync("", HttpMethod.Get));
    }

    [Fact]
    public async Task AnyWebSocketApiMethodCanBeSent()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies("""{"status":200,"result":{"serverTime":7}}"""));
        await using var client = new WebSocketApiClient(new WebSocketApiConfig { Url = server.Url, ApiKey = "k", ApiSecret = "s" });
        await client.ConnectAsync();

        var response = await client.SendMessageAsync("time");
        Assert.Equal(7, response.Data().GetProperty("serverTime").GetInt64());
        Assert.Equal("time", server.ApiRequest().Method);
        Assert.Null(server.ApiRequest().Param("apiKey"));

        await client.SendMessageAsync("ticker.price", new Dictionary<string, object?> { ["symbol"] = "BNBUSDT" }, WebSocketAuth.ApiKey);
        Assert.Equal("BNBUSDT", server.ApiRequest().Param("symbol"));
        Assert.Equal("k", server.ApiRequest().Param("apiKey"));
        Assert.Null(server.ApiRequest().Param("signature"));

        await client.SendMessageAsync("account.status", auth: WebSocketAuth.Signed);
        Assert.Equal("account.status", server.ApiRequest().Method);
        Assert.NotNull(server.ApiRequest().Param("timestamp"));
        Assert.NotNull(server.ApiRequest().Param("signature"));
    }

    [Fact]
    public async Task WebSocketApiMessagesAreReadOnceAsked()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiReplies("""{"status":200,"result":{"serverTime":7}}"""));
        await using var client = new WebSocketApiClient(new WebSocketApiConfig { Url = server.Url });
        await client.ConnectAsync();
        var messages = client.EnableMessages();
        Assert.Same(messages, client.EnableMessages());

        await client.SendMessageAsync("time");

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await messages.ReadAsync(cts.Token);
        Assert.Contains("\"serverTime\":7", message.Data, StringComparison.Ordinal);
        Assert.NotEmpty(message.ConnectionId);
        // The lifecycle events still go to Events.
        Assert.True(await MiniWsServer.WaitFor(() => client.Events.TryPeek(out var e) && e.Type == ConnectionEventType.Open));
    }

    [Fact]
    public async Task MessagesCannotBeEnabledOnADisposedClient()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        var streams = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        await streams.DisposeAsync();
        Assert.Throws<ObjectDisposedException>(() => streams.EnableMessages());
        Assert.Throws<ObjectDisposedException>(() => streams.EnableMessages());
        await Assert.ThrowsAsync<ArgumentNullException>(() => streams.ConnectAsync((IEnumerable<string>)null!));
    }

    [Fact]
    public async Task AnyStreamCanBeSubscribedAndChecked()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var streams = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        await streams.ConnectAsync();

        var subscription = streams.Subscribe("a@trade");
        await subscription.WaitSubscribedAsync();
        Assert.True(streams.IsSubscribed("a@trade"));
        Assert.False(streams.IsSubscribed("other@trade"));
        server.Publish("a@trade", """{"e":"trade","p":"1.5"}""");

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var e = await subscription.Events.ReadAsync(cts.Token);
        Assert.Equal("1.5", e.GetProperty("p").GetString());

        subscription.Dispose();
        Assert.False(streams.IsSubscribed("a@trade"));
        using var bad = streams.Subscribe("bad@trade");
        await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => bad.WaitSubscribedAsync());
        Assert.False(streams.IsSubscribed("bad@trade"));
    }

    [Fact]
    public async Task StreamsOfConnectGoInTheUrlAndTheirMessagesReachMessages()
    {
        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var streams = new WebSocketStreamsClient(new WebSocketStreamsConfig { Url = server.Url });
        var messages = streams.EnableMessages();

        await streams.ConnectAsync(["a@trade", "b@trade"]);

        Assert.True(streams.IsSubscribed("a@trade"));
        string handshake;
        lock (server.Handshakes) handshake = server.Handshakes.Single();
        Assert.Contains("streams=a@trade/b@trade", Uri.UnescapeDataString(handshake), StringComparison.Ordinal);
        server.Send(1, """{"stream":"b@trade","data":{"p":"2"}}""");

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await messages.ReadAsync(cts.Token);
        using var doc = JsonDocument.Parse(message.Data);
        Assert.Equal("b@trade", doc.RootElement.GetProperty("stream").GetString());
    }
}
