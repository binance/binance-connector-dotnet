//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingCoinFutures.RestApi;

namespace Binance.DerivativesTradingCoinFutures.Tests.RestApi.UserDataStreams;

[Trait("Category", "Native")]
public class UserDataStreamsApiTests
{
    private static DerivativesTradingCoinFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CloseUserDataStreamAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.CloseUserDataStreamAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/dapi/v1/listenKey", seen.Path);
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
    public async Task KeepaliveUserDataStreamAsync()
    {
        const string example = """""{"listenKey":"vmNt6gl1so8bXVsaAY153FG5tf63QaODxUarKUM8V8rY4ElSwEe431DNIYNKOkQp"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.KeepaliveUserDataStreamAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/dapi/v1/listenKey", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KeepaliveUserDataStreamBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KeepaliveUserDataStreamAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task StartUserDataStreamAsync()
    {
        const string example = """""{"listenKey":"pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s61cv6a81va65sdf19v8a65a1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.StartUserDataStreamAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/dapi/v1/listenKey", seen.Path);
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
}
