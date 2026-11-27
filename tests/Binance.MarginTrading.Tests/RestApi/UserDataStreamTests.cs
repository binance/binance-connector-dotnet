//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.MarginTrading.RestApi;

namespace Binance.MarginTrading.Tests.RestApi.UserDataStream;

[Trait("Category", "Native")]
public class UserDataStreamApiTests
{
    private static MarginTradingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CloseUserDataStreamAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.CloseUserDataStreamAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/listen-key", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task CloseUserDataStreamBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CloseUserDataStreamAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CloseUserDataStreamV2Async()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.CloseUserDataStreamV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v2/margin/listen-key", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task CloseUserDataStreamV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CloseUserDataStreamV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KeepaliveUserDataStreamAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new KeepaliveUserDataStreamRequest
        {
            ListenKey = "listenKey_example",
        };

        var response = await client.KeepaliveUserDataStreamAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v1/margin/listen-key", seen.Path);
        Assert.Equal("listenKey_example", seen.Param("listenKey"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task KeepaliveUserDataStreamBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new KeepaliveUserDataStreamRequest
        {
            ListenKey = "listenKey_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KeepaliveUserDataStreamAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KeepaliveUserDataStreamV2Async()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new KeepaliveUserDataStreamV2Request
        {
            ListenKey = "listenKey_example",
        };

        var response = await client.KeepaliveUserDataStreamV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v2/margin/listen-key", seen.Path);
        Assert.Equal("listenKey_example", seen.Param("listenKey"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task KeepaliveUserDataStreamV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new KeepaliveUserDataStreamV2Request
        {
            ListenKey = "listenKey_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KeepaliveUserDataStreamV2Async(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task StartUserDataStreamAsync()
    {
        const string example = """""{"listenKey":"T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhd"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.StartUserDataStreamAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/listen-key", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task StartUserDataStreamBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.StartUserDataStreamAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task StartUserDataStreamV2Async()
    {
        const string example = """""{"listenKey":"T3ee22BIYuWqmvne0HNq2A2WsFlEtLhvWCtItw6ffhhd"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.StartUserDataStreamV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/margin/listen-key", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task StartUserDataStreamV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.StartUserDataStreamV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
