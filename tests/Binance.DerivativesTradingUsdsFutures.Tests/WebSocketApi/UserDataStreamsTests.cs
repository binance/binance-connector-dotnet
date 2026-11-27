//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingUsdsFutures.WebSocketApi;

namespace Binance.DerivativesTradingUsdsFutures.Tests.WebSocketApi.UserDataStreams;

[Trait("Category", "Native")]
public class UserDataStreamsApiTests
{
    [Fact]
    public async Task CloseUserDataStreamAsync()
    {
        const string envelope = """""{"id":"819e1b1b-8c06-485b-a13e-131326c69599","status":200,"result":{},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.CloseUserDataStreamAsync();

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.stop", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task CloseUserDataStreamWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"819e1b1b-8c06-485b-a13e-131326c69599","status":200,"result":{},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new CloseUserDataStreamRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.CloseUserDataStreamAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.stop", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("test-key", frame.Param("apiKey"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task CloseUserDataStreamBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.CloseUserDataStreamAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KeepaliveUserDataStreamAsync()
    {
        const string envelope = """""{"id":"815d5fce-0880-4287-a567-80badf004c74","status":200,"result":{"listenKey":"3HBntNTepshgEdjIwSUIBgB9keLyOCg5qv3n6bYAtktG8ejcaW5HXz9Vx1JgIieg"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"listenKey":"3HBntNTepshgEdjIwSUIBgB9keLyOCg5qv3n6bYAtktG8ejcaW5HXz9Vx1JgIieg"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.KeepaliveUserDataStreamAsync();

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.ping", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task KeepaliveUserDataStreamWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"815d5fce-0880-4287-a567-80badf004c74","status":200,"result":{"listenKey":"3HBntNTepshgEdjIwSUIBgB9keLyOCg5qv3n6bYAtktG8ejcaW5HXz9Vx1JgIieg"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"listenKey":"3HBntNTepshgEdjIwSUIBgB9keLyOCg5qv3n6bYAtktG8ejcaW5HXz9Vx1JgIieg"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new KeepaliveUserDataStreamRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.KeepaliveUserDataStreamAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.ping", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("test-key", frame.Param("apiKey"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task KeepaliveUserDataStreamBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.KeepaliveUserDataStreamAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task StartUserDataStreamAsync()
    {
        const string envelope = """""{"id":"d3df8a61-98ea-4fe0-8f4e-0fcea5d418b0","status":200,"result":{"listenKey":"xs0mRXdAKlIPDRFrlPcw0qI41Eh3ixNntmymGyhrhgqo7L6FuLaWArTD7RLP"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"listenKey":"xs0mRXdAKlIPDRFrlPcw0qI41Eh3ixNntmymGyhrhgqo7L6FuLaWArTD7RLP"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.StartUserDataStreamAsync();

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.start", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task StartUserDataStreamWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"d3df8a61-98ea-4fe0-8f4e-0fcea5d418b0","status":200,"result":{"listenKey":"xs0mRXdAKlIPDRFrlPcw0qI41Eh3ixNntmymGyhrhgqo7L6FuLaWArTD7RLP"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"listenKey":"xs0mRXdAKlIPDRFrlPcw0qI41Eh3ixNntmymGyhrhgqo7L6FuLaWArTD7RLP"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new StartUserDataStreamRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.StartUserDataStreamAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.start", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("test-key", frame.Param("apiKey"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task StartUserDataStreamBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.StartUserDataStreamAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
