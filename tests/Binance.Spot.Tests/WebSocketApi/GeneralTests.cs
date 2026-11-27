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

namespace Binance.Spot.Tests.WebSocketApi.General;

[Trait("Category", "Native")]
public class GeneralApiTests
{
    [Fact]
    public async Task ExchangeInfoAsync()
    {
        const string envelope = """""{"id":"5494febb-d167-46a2-996d-70533eb4d976","status":200,"result":{"timezone":"UTC","serverTime":1655969291181,"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000},{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000},{"rateLimitType":"CONNECTIONS","interval":"MINUTE","intervalNum":5,"limit":300}],"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbols":[{"symbol":"BNBBTC","status":"TRADING","baseAsset":"BNB","baseAssetPrecision":8,"quoteAsset":"BTC","quotePrecision":8,"quoteAssetPrecision":8,"baseCommissionPrecision":8,"quoteCommissionPrecision":8,"orderTypes":["LIMIT","LIMIT_MAKER","MARKET","STOP_LOSS_LIMIT","TAKE_PROFIT_LIMIT"],"icebergAllowed":true,"ocoAllowed":true,"otoAllowed":true,"opoAllowed":true,"quoteOrderQtyMarketAllowed":true,"allowTrailingStop":true,"cancelReplaceAllowed":true,"amendAllowed":false,"pegInstructionsAllowed":true,"marketQuoteNotionalLimitAllowed":true,"limitQuoteNotionalLimitAllowed":true,"isSpotTradingAllowed":true,"isMarginTradingAllowed":true,"filters":[{"filterType":"PRICE_FILTER","minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"},{"filterType":"LOT_SIZE","minQty":"0.00100000","maxQty":"100000.00000000","stepSize":"0.00100000"}],"permissions":["SPOT"],"permissionSets":[["SPOT","MARGIN","TRD_GRP_004"]],"defaultSelfTradePreventionMode":"NONE","allowedSelfTradePreventionModes":["NONE"]}],"sors":[{"baseAsset":"BTC","symbols":["BTCUSDT","BTCUSDC"]}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""{"timezone":"UTC","serverTime":1655969291181,"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000},{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000},{"rateLimitType":"CONNECTIONS","interval":"MINUTE","intervalNum":5,"limit":300}],"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbols":[{"symbol":"BNBBTC","status":"TRADING","baseAsset":"BNB","baseAssetPrecision":8,"quoteAsset":"BTC","quotePrecision":8,"quoteAssetPrecision":8,"baseCommissionPrecision":8,"quoteCommissionPrecision":8,"orderTypes":["LIMIT","LIMIT_MAKER","MARKET","STOP_LOSS_LIMIT","TAKE_PROFIT_LIMIT"],"icebergAllowed":true,"ocoAllowed":true,"otoAllowed":true,"opoAllowed":true,"quoteOrderQtyMarketAllowed":true,"allowTrailingStop":true,"cancelReplaceAllowed":true,"amendAllowed":false,"pegInstructionsAllowed":true,"marketQuoteNotionalLimitAllowed":true,"limitQuoteNotionalLimitAllowed":true,"isSpotTradingAllowed":true,"isMarginTradingAllowed":true,"filters":[{"filterType":"PRICE_FILTER","minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"},{"filterType":"LOT_SIZE","minQty":"0.00100000","maxQty":"100000.00000000","stepSize":"0.00100000"}],"permissions":["SPOT"],"permissionSets":[["SPOT","MARGIN","TRD_GRP_004"]],"defaultSelfTradePreventionMode":"NONE","allowedSelfTradePreventionModes":["NONE"]}],"sors":[{"baseAsset":"BTC","symbols":["BTCUSDT","BTCUSDC"]}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.ExchangeInfoAsync();

        var frame = server.ApiRequest();
        Assert.Equal("exchangeInfo", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ExchangeInfoWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"5494febb-d167-46a2-996d-70533eb4d976","status":200,"result":{"timezone":"UTC","serverTime":1655969291181,"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000},{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000},{"rateLimitType":"CONNECTIONS","interval":"MINUTE","intervalNum":5,"limit":300}],"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbols":[{"symbol":"BNBBTC","status":"TRADING","baseAsset":"BNB","baseAssetPrecision":8,"quoteAsset":"BTC","quotePrecision":8,"quoteAssetPrecision":8,"baseCommissionPrecision":8,"quoteCommissionPrecision":8,"orderTypes":["LIMIT","LIMIT_MAKER","MARKET","STOP_LOSS_LIMIT","TAKE_PROFIT_LIMIT"],"icebergAllowed":true,"ocoAllowed":true,"otoAllowed":true,"opoAllowed":true,"quoteOrderQtyMarketAllowed":true,"allowTrailingStop":true,"cancelReplaceAllowed":true,"amendAllowed":false,"pegInstructionsAllowed":true,"marketQuoteNotionalLimitAllowed":true,"limitQuoteNotionalLimitAllowed":true,"isSpotTradingAllowed":true,"isMarginTradingAllowed":true,"filters":[{"filterType":"PRICE_FILTER","minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"},{"filterType":"LOT_SIZE","minQty":"0.00100000","maxQty":"100000.00000000","stepSize":"0.00100000"}],"permissions":["SPOT"],"permissionSets":[["SPOT","MARGIN","TRD_GRP_004"]],"defaultSelfTradePreventionMode":"NONE","allowedSelfTradePreventionModes":["NONE"]}],"sors":[{"baseAsset":"BTC","symbols":["BTCUSDT","BTCUSDC"]}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""{"timezone":"UTC","serverTime":1655969291181,"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000},{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000},{"rateLimitType":"CONNECTIONS","interval":"MINUTE","intervalNum":5,"limit":300}],"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbols":[{"symbol":"BNBBTC","status":"TRADING","baseAsset":"BNB","baseAssetPrecision":8,"quoteAsset":"BTC","quotePrecision":8,"quoteAssetPrecision":8,"baseCommissionPrecision":8,"quoteCommissionPrecision":8,"orderTypes":["LIMIT","LIMIT_MAKER","MARKET","STOP_LOSS_LIMIT","TAKE_PROFIT_LIMIT"],"icebergAllowed":true,"ocoAllowed":true,"otoAllowed":true,"opoAllowed":true,"quoteOrderQtyMarketAllowed":true,"allowTrailingStop":true,"cancelReplaceAllowed":true,"amendAllowed":false,"pegInstructionsAllowed":true,"marketQuoteNotionalLimitAllowed":true,"limitQuoteNotionalLimitAllowed":true,"isSpotTradingAllowed":true,"isMarginTradingAllowed":true,"filters":[{"filterType":"PRICE_FILTER","minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"},{"filterType":"LOT_SIZE","minQty":"0.00100000","maxQty":"100000.00000000","stepSize":"0.00100000"}],"permissions":["SPOT"],"permissionSets":[["SPOT","MARGIN","TRD_GRP_004"]],"defaultSelfTradePreventionMode":"NONE","allowedSelfTradePreventionModes":["NONE"]}],"sors":[{"baseAsset":"BTC","symbols":["BTCUSDT","BTCUSDC"]}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ExchangeInfoRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BNBUSDT",
            Symbols = new() { },
            Permissions = new() { },
            ShowPermissionSets = true,
            SymbolStatus = ExchangeInfoSymbolStatus.Trading,
        };

        var response = await client.ExchangeInfoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("exchangeInfo", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("true", frame.Param("showPermissionSets"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ExchangeInfoBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.ExchangeInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExecutionRulesAsync()
    {
        const string envelope = """""{"id":"5162affb-0aba-4821-b475-f2625006eb43","status":200,"result":{"symbolRules":[{"symbol":"BAZUSD","rules":[{"ruleType":"PRICE_RANGE","bidLimitMultUp":"1.0001","bidLimitMultDown":"0.9999","askLimitMultUp":"1.0001","askLimitMultDown":"0.9999"}]}]}}""""";
        const string result = """""{"symbolRules":[{"symbol":"BAZUSD","rules":[{"ruleType":"PRICE_RANGE","bidLimitMultUp":"1.0001","bidLimitMultDown":"0.9999","askLimitMultUp":"1.0001","askLimitMultDown":"0.9999"}]}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.ExecutionRulesAsync();

        var frame = server.ApiRequest();
        Assert.Equal("executionRules", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ExecutionRulesWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"5162affb-0aba-4821-b475-f2625006eb43","status":200,"result":{"symbolRules":[{"symbol":"BAZUSD","rules":[{"ruleType":"PRICE_RANGE","bidLimitMultUp":"1.0001","bidLimitMultDown":"0.9999","askLimitMultUp":"1.0001","askLimitMultDown":"0.9999"}]}]}}""""";
        const string result = """""{"symbolRules":[{"symbol":"BAZUSD","rules":[{"ruleType":"PRICE_RANGE","bidLimitMultUp":"1.0001","bidLimitMultDown":"0.9999","askLimitMultUp":"1.0001","askLimitMultDown":"0.9999"}]}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ExecutionRulesRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BAZUSD",
            Symbols = new() { },
            SymbolStatus = ExecutionRulesSymbolStatus.Trading,
        };

        var response = await client.ExecutionRulesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("executionRules", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BAZUSD", frame.Param("symbol"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ExecutionRulesBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.ExecutionRulesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PingAsync()
    {
        const string envelope = """""{"id":"922bcc6e-9de8-440d-9e84-7c80933a8d0d","status":200,"result":{},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.PingAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ping", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task PingWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"922bcc6e-9de8-440d-9e84-7c80933a8d0d","status":200,"result":{},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new PingRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.PingAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ping", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task PingBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.PingAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TimeAsync()
    {
        const string envelope = """""{"id":"187d3cb2-942d-484c-8271-4e2141bbadb1","status":200,"result":{"serverTime":1656400526260},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"serverTime":1656400526260}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.TimeAsync();

        var frame = server.ApiRequest();
        Assert.Equal("time", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TimeWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"187d3cb2-942d-484c-8271-4e2141bbadb1","status":200,"result":{"serverTime":1656400526260},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"serverTime":1656400526260}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TimeRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.TimeAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("time", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TimeBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TimeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
