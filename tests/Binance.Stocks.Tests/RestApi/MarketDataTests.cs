//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Stocks.RestApi;

namespace Binance.Stocks.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static StocksRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task ExchangeInfoAsync()
    {
        const string example = """""{"timezone":"UTC","symbols":[{"symbol":"AAPL","tradability":"BUY_SELL","tradabilityUpdateTime":1735900000000,"overnightSupported":true,"fractionable":true,"fractionableEh":false,"extendedSession":true,"maxNumOrders":200,"stepSize":"0.000000001","multiplierUp":"1.10","multiplierDown":"0.90","minQty":"0.000000001","maxQty":"100000.00000000","minNotional":"1.00","maxNotional":"1000000.00","listingTime":1700000000000,"delistingTime":1}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExchangeInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/market/exchangeInfo", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExchangeInfoWithOptionalParametersAsync()
    {
        const string example = """""{"timezone":"UTC","symbols":[{"symbol":"AAPL","tradability":"BUY_SELL","tradabilityUpdateTime":1735900000000,"overnightSupported":true,"fractionable":true,"fractionableEh":false,"extendedSession":true,"maxNumOrders":200,"stepSize":"0.000000001","multiplierUp":"1.10","multiplierDown":"0.90","minQty":"0.000000001","maxQty":"100000.00000000","minNotional":"1.00","maxNotional":"1000000.00","listingTime":1700000000000,"delistingTime":1}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExchangeInfoRequest
        {
            Symbol = "AAPL",
        };

        var response = await client.ExchangeInfoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/market/exchangeInfo", seen.Path);
        Assert.Equal("AAPL", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExchangeInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ExchangeInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task LatestQuoteAsync()
    {
        const string example = """""{"symbol":"AAPL","bidPrice":"180.50","askPrice":"180.52","bidSize":100,"askSize":200}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new LatestQuoteRequest
        {
            Symbol = "AAPL",
        };

        var response = await client.LatestQuoteAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/market/quote", seen.Path);
        Assert.Equal("AAPL", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task LatestQuoteBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new LatestQuoteRequest
        {
            Symbol = "AAPL",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.LatestQuoteAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TokenizedAssetsAsync()
    {
        const string example = """""[{"assetCode":"AAPLB","assetName":"Apple Inc. Tokenized Stock","underlyingEquitySymbol":"AAPL","multiplier":"1","multiplierValid":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TokenizedAssetsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/market/tokenized-assets", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TokenizedAssetsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TokenizedAssetsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
