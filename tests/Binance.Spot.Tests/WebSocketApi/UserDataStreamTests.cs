//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Spot.WebSocketApi;

namespace Binance.Spot.Tests.WebSocketApi.UserDataStream;

[Trait("Category", "Native")]
public class UserDataStreamApiTests
{
    [Fact]
    public async Task SessionSubscriptionsAsync()
    {
        const string envelope = """""{"id":"d3df5a22-88ea-4fe0-9f4e-0fcea5d418b7","status":200,"result":[{"subscriptionId":0},{"subscriptionId":1}]}""""";
        const string result = """""[{"subscriptionId":0},{"subscriptionId":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.SessionSubscriptionsAsync();

        var frame = server.ApiRequest();
        Assert.Equal("session.subscriptions", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionSubscriptionsWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"d3df5a22-88ea-4fe0-9f4e-0fcea5d418b7","status":200,"result":[{"subscriptionId":0},{"subscriptionId":1}]}""""";
        const string result = """""[{"subscriptionId":0},{"subscriptionId":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SessionSubscriptionsRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.SessionSubscriptionsAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("session.subscriptions", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionSubscriptionsBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SessionSubscriptionsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserDataStreamSubscribeAsync()
    {
        const string envelope = """""{"id":"d3df8a21-98ea-4fe0-8f4e-0fcea5d418b7","status":200,"result":{"subscriptionId":0}}""""";
        const string result = """""{"subscriptionId":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        using var subscription = await client.UserDataStreamSubscribeAsync();
        var response = subscription.Response;

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.subscribe", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UserDataStreamSubscribeWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"d3df8a21-98ea-4fe0-8f4e-0fcea5d418b7","status":200,"result":{"subscriptionId":0}}""""";
        const string result = """""{"subscriptionId":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new UserDataStreamSubscribeRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Filter = new(),
        };

        using var subscription = await client.UserDataStreamSubscribeAsync(request);
        var response = subscription.Response;

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.subscribe", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UserDataStreamSubscribeBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.UserDataStreamSubscribeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserDataStreamSubscribeSignatureAsync()
    {
        const string envelope = """""{"id":"d3df8a22-98ea-4fe0-9f4e-0fcea5d418b7","status":200,"result":{"subscriptionId":0}}""""";
        const string result = """""{"subscriptionId":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        using var subscription = await client.UserDataStreamSubscribeSignatureAsync();
        var response = subscription.Response;

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.subscribe.signature", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UserDataStreamSubscribeSignatureWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"d3df8a22-98ea-4fe0-9f4e-0fcea5d418b7","status":200,"result":{"subscriptionId":0}}""""";
        const string result = """""{"subscriptionId":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new UserDataStreamSubscribeSignatureRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000m,
            Filter = new(),
        };

        using var subscription = await client.UserDataStreamSubscribeSignatureAsync(request);
        var response = subscription.Response;

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.subscribe.signature", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UserDataStreamSubscribeSignatureBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.UserDataStreamSubscribeSignatureAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserDataStreamUnsubscribeAsync()
    {
        const string envelope = """""{"id":"d3df8a21-98ea-4fe0-8f4e-0fcea5d418b7","status":200,"result":{}}""""";
        const string result = """""{}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.UserDataStreamUnsubscribeAsync();

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.unsubscribe", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UserDataStreamUnsubscribeWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"d3df8a21-98ea-4fe0-8f4e-0fcea5d418b7","status":200,"result":{}}""""";
        const string result = """""{}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new UserDataStreamUnsubscribeRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            SubscriptionId = 1L,
        };

        var response = await client.UserDataStreamUnsubscribeAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("userDataStream.unsubscribe", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("subscriptionId"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UserDataStreamUnsubscribeBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.UserDataStreamUnsubscribeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
