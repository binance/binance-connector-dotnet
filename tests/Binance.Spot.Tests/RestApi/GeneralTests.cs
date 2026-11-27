//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Spot.RestApi;

namespace Binance.Spot.Tests.RestApi.General;

[Trait("Category", "Native")]
public class GeneralApiTests
{
    private static SpotRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task ExchangeInfoAsync()
    {
        const string example = """""{"timezone":"UTC","serverTime":1565246363776,"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":321}],"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbols":[{"symbol":"ETHBTC","status":"TRADING","baseAsset":"ETH","baseAssetPrecision":8,"quoteAsset":"BTC","quotePrecision":8,"quoteAssetPrecision":8,"baseCommissionPrecision":8,"quoteCommissionPrecision":8,"orderTypes":["LIMIT","LIMIT_MAKER","MARKET","STOP_LOSS","STOP_LOSS_LIMIT","TAKE_PROFIT","TAKE_PROFIT_LIMIT"],"icebergAllowed":true,"ocoAllowed":true,"otoAllowed":true,"opoAllowed":true,"quoteOrderQtyMarketAllowed":true,"allowTrailingStop":false,"cancelReplaceAllowed":false,"amendAllowed":false,"pegInstructionsAllowed":true,"marketQuoteNotionalLimitAllowed":true,"limitQuoteNotionalLimitAllowed":true,"isSpotTradingAllowed":true,"isMarginTradingAllowed":true,"filters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"permissions":["undefined"],"permissionSets":[["SPOT"]],"defaultSelfTradePreventionMode":"NONE","allowedSelfTradePreventionModes":["NONE"]}],"sors":[{"baseAsset":"BTC","symbols":["BTCUSDT"]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExchangeInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/exchangeInfo", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExchangeInfoWithOptionalParametersAsync()
    {
        const string example = """""{"timezone":"UTC","serverTime":1565246363776,"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":321}],"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbols":[{"symbol":"ETHBTC","status":"TRADING","baseAsset":"ETH","baseAssetPrecision":8,"quoteAsset":"BTC","quotePrecision":8,"quoteAssetPrecision":8,"baseCommissionPrecision":8,"quoteCommissionPrecision":8,"orderTypes":["LIMIT","LIMIT_MAKER","MARKET","STOP_LOSS","STOP_LOSS_LIMIT","TAKE_PROFIT","TAKE_PROFIT_LIMIT"],"icebergAllowed":true,"ocoAllowed":true,"otoAllowed":true,"opoAllowed":true,"quoteOrderQtyMarketAllowed":true,"allowTrailingStop":false,"cancelReplaceAllowed":false,"amendAllowed":false,"pegInstructionsAllowed":true,"marketQuoteNotionalLimitAllowed":true,"limitQuoteNotionalLimitAllowed":true,"isSpotTradingAllowed":true,"isMarginTradingAllowed":true,"filters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"permissions":["undefined"],"permissionSets":[["SPOT"]],"defaultSelfTradePreventionMode":"NONE","allowedSelfTradePreventionModes":["NONE"]}],"sors":[{"baseAsset":"BTC","symbols":["BTCUSDT"]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExchangeInfoRequest
        {
            Symbol = "ETHBTC",
            Symbols = new() { },
            Permissions = new() { ExchangeInfoPermissions.Spot },
            ShowPermissionSets = false,
            SymbolStatus = ExchangeInfoSymbolStatus.Trading,
        };

        var response = await client.ExchangeInfoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/exchangeInfo", seen.Path);
        Assert.Equal("ETHBTC", seen.Param("symbol"));
        Assert.Equal("[\"SPOT\"]", seen.Param("permissions"));
        Assert.Equal("false", seen.Param("showPermissionSets"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
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
    public async Task ExecutionRulesAsync()
    {
        const string example = """""{"symbolRules":[{"symbol":"BAZUSD","rules":[{"ruleType":"PRICE_RANGE","bidLimitMultUp":"1.0001","bidLimitMultDown":"0.9999","askLimitMultUp":"1.0001","askLimitMultDown":"0.9999"}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExecutionRulesAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/executionRules", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExecutionRulesWithOptionalParametersAsync()
    {
        const string example = """""{"symbolRules":[{"symbol":"BAZUSD","rules":[{"ruleType":"PRICE_RANGE","bidLimitMultUp":"1.0001","bidLimitMultDown":"0.9999","askLimitMultUp":"1.0001","askLimitMultDown":"0.9999"}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExecutionRulesRequest
        {
            Symbol = "BAZUSD",
            Symbols = new() { },
            SymbolStatus = ExecutionRulesSymbolStatus.Trading,
        };

        var response = await client.ExecutionRulesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/executionRules", seen.Path);
        Assert.Equal("BAZUSD", seen.Param("symbol"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExecutionRulesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ExecutionRulesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PingAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.PingAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ping", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task PingBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PingAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TimeAsync()
    {
        const string example = """""{"serverTime":1499827319559}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TimeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/time", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TimeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TimeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
