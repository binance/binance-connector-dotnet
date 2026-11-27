//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.CopyTrading.RestApi;

namespace Binance.CopyTrading.Tests.RestApi.FutureCopyTrading;

[Trait("Category", "Native")]
public class FutureCopyTradingApiTests
{
    private static CopyTradingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetFuturesLeadTraderStatusAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"isLeadTrader":true,"time":1717382310843},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFuturesLeadTraderStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/copyTrading/futures/userStatus", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesLeadTraderStatusWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"isLeadTrader":true,"time":1717382310843},"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesLeadTraderStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesLeadTraderStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/copyTrading/futures/userStatus", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesLeadTraderStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesLeadTraderStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesLeadTradingSymbolWhitelistAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"symbol":"BTCUSDT","baseAsset":"BTC","quoteAsset":"USDT"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFuturesLeadTradingSymbolWhitelistAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/copyTrading/futures/leadSymbol", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesLeadTradingSymbolWhitelistWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"symbol":"BTCUSDT","baseAsset":"BTC","quoteAsset":"USDT"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesLeadTradingSymbolWhitelistRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesLeadTradingSymbolWhitelistAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/copyTrading/futures/leadSymbol", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesLeadTradingSymbolWhitelistBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesLeadTradingSymbolWhitelistAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
