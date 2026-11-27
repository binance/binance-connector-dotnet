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

namespace Binance.Spot.Tests.WebSocketApi.Auth;

[Trait("Category", "Native")]
public class AuthApiTests
{
    [Fact]
    public async Task SessionLogonAsync()
    {
        const string envelope = """""{"id":"c174a2b1-3f51-4580-b200-8528bd237cb7","status":200,"result":{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649729878630,"userDataStream":false}}""""";
        const string result = """""{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649729878630,"userDataStream":false}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            PrivateKeyPem = TestKeys.Ed25519Pem,
        }).ConnectAsync();

        var responses = await client.SessionLogonAsync();
        var response = Assert.Single(responses);

        var frame = server.ApiRequest();
        Assert.Equal("session.logon", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.NotNull(frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionLogonWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"c174a2b1-3f51-4580-b200-8528bd237cb7","status":200,"result":{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649729878630,"userDataStream":false}}""""";
        const string result = """""{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649729878630,"userDataStream":false}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            PrivateKeyPem = TestKeys.Ed25519Pem,
        }).ConnectAsync();

        var request = new SessionLogonRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000m,
        };

        var responses = await client.SessionLogonAsync(request);
        var response = Assert.Single(responses);

        var frame = server.ApiRequest();
        Assert.Equal("session.logon", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.NotNull(frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionLogonBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            PrivateKeyPem = TestKeys.Ed25519Pem,
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SessionLogonAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SessionLogoutAsync()
    {
        const string envelope = """""{"id":"c174a2b1-3f51-4580-b200-8528bd237cb7","status":200,"result":{"apiKey":"apiKey","authorizedSince":1,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":false}}""""";
        const string result = """""{"apiKey":"apiKey","authorizedSince":1,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":false}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var responses = await client.SessionLogoutAsync();
        var response = Assert.Single(responses);

        var frame = server.ApiRequest();
        Assert.Equal("session.logout", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionLogoutWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"c174a2b1-3f51-4580-b200-8528bd237cb7","status":200,"result":{"apiKey":"apiKey","authorizedSince":1,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":false}}""""";
        const string result = """""{"apiKey":"apiKey","authorizedSince":1,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":false}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SessionLogoutRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var responses = await client.SessionLogoutAsync(request);
        var response = Assert.Single(responses);

        var frame = server.ApiRequest();
        Assert.Equal("session.logout", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionLogoutBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SessionLogoutAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SessionStatusAsync()
    {
        const string envelope = """""{"id":"b50c16cd-62c9-4e29-89e4-37f10111f5bf","status":200,"result":{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":true}}""""";
        const string result = """""{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":true}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.SessionStatusAsync();

        var frame = server.ApiRequest();
        Assert.Equal("session.status", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionStatusWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"b50c16cd-62c9-4e29-89e4-37f10111f5bf","status":200,"result":{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":true}}""""";
        const string result = """""{"apiKey":"YOUR_API_KEY","authorizedSince":1649729878532,"connectedSince":1649729873021,"returnRateLimits":false,"serverTime":1649730611671,"userDataStream":true}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SessionStatusRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.SessionStatusAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("session.status", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SessionStatusBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SessionStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
