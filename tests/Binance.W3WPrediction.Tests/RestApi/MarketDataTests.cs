//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.W3WPrediction.RestApi;

namespace Binance.W3WPrediction.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static W3WPredictionRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetMarketDetailAsync()
    {
        const string example = """""{"marketTopicId":4229564,"vendor":"PREDICT_FUN","chainId":"56","slug":"btc-price-1h-up-or-down","title":"BTC Price 1h Up or Down?","question":"Will BTC price go UP in the next 1 hour?","description":"Resolves YES if BTC spot price is higher than the starting price at resolution time.","imageUrl":"https://cdn.example.com/prediction/btc-1h.png","topicType":"FLAT","chartType":"CRYPTO_UP_DOWN","symbol":"BTCUSDT","variantData":{"type":"CRYPTO_UP_DOWN","startPrice":"67890.12","endPrice":"endPrice","priceFeedId":"0xpricefeedid123","priceFeedProvider":"BINANCE","priceFeedSymbol":"BTCUSDT"},"participantCount":3420,"collateral":"USDT","feeRateBps":200,"slippageBps":1200,"isYieldBearing":false,"tradeVolume":"158234.56","liquidity":"45000.00","publishedAt":1748100000000,"startDate":1748131200000,"endDate":1748134800000,"status":"REGISTERED","timeline":[{"marketTopicId":4229560,"startDate":1748127600000,"endDate":1748131200000}],"markets":[{"marketId":5567895,"externalId":"ext_001","title":"UP","question":"Will BTC go UP?","description":"Resolves YES if BTC price increases.","conditionId":"0xabc123","status":"REGISTERED","tradingStatus":"OPEN","tradeVolume":"90000.00","liquidity":"25000.00","decimalPrecision":2,"outcomes":[{"name":"YES","price":"0.52","chance":"0.52","index":0,"tokenId":"112233","winner":true}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetMarketDetailRequest
        {
            MarketTopicId = 4229564L,
        };

        var response = await client.GetMarketDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/market/detail", seen.Path);
        Assert.Equal("4229564", seen.Param("marketTopicId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarketDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetMarketDetailRequest
        {
            MarketTopicId = 4229564L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetMarketDetailAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ListPredictionCategoriesAsync()
    {
        const string example = """""{"categories":[{"id":"crypto","name":"Crypto","icon":"crypto_icon","order":1,"subcategories":[{"id":"up-down","name":"Up/Down","icon":"updown_icon","order":1}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ListPredictionCategoriesAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/category/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListPredictionCategoriesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ListPredictionCategoriesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ListPredictionMarketsAsync()
    {
        const string example = """""{"marketTopics":[{"marketTopicId":4229564,"vendor":"PREDICT_FUN","chainId":"56","slug":"btc-price-1h-up-or-down","title":"BTC Price 1h Up or Down?","question":"Will BTC price go UP in the next 1 hour?","description":"Resolves YES if BTC spot price is higher than the starting price at resolution time.","imageUrl":"https://cdn.example.com/prediction/btc-1h.png","topicType":"FLAT","chartType":"CRYPTO_UP_DOWN","symbol":"BTCUSDT","participantCount":3420,"collateral":"USDT","feeRateBps":200,"slippageBps":1200,"isYieldBearing":false,"tradeVolume":"158234.56","liquidity":"45000.00","publishedAt":1748100000000,"startDate":1748131200000,"endDate":1748134800000,"status":"REGISTERED","markets":[{}]}],"total":128,"offset":0,"limit":20,"hasMore":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ListPredictionMarketsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/market/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListPredictionMarketsWithOptionalParametersAsync()
    {
        const string example = """""{"marketTopics":[{"marketTopicId":4229564,"vendor":"PREDICT_FUN","chainId":"56","slug":"btc-price-1h-up-or-down","title":"BTC Price 1h Up or Down?","question":"Will BTC price go UP in the next 1 hour?","description":"Resolves YES if BTC spot price is higher than the starting price at resolution time.","imageUrl":"https://cdn.example.com/prediction/btc-1h.png","topicType":"FLAT","chartType":"CRYPTO_UP_DOWN","symbol":"BTCUSDT","participantCount":3420,"collateral":"USDT","feeRateBps":200,"slippageBps":1200,"isYieldBearing":false,"tradeVolume":"158234.56","liquidity":"45000.00","publishedAt":1748100000000,"startDate":1748131200000,"endDate":1748134800000,"status":"REGISTERED","markets":[{}]}],"total":128,"offset":0,"limit":20,"hasMore":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ListPredictionMarketsRequest
        {
            L1Category = "crypto",
            L2Category = "up-down",
            SortBy = ListPredictionMarketsSortBy.Recommended,
            OrderBy = ListPredictionMarketsOrderBy.Asc,
            Offset = 0L,
            Limit = 20L,
        };

        var response = await client.ListPredictionMarketsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/market/list", seen.Path);
        Assert.Equal("crypto", seen.Param("l1Category"));
        Assert.Equal("up-down", seen.Param("l2Category"));
        Assert.Equal("RECOMMENDED", seen.Param("sortBy"));
        Assert.Equal("ASC", seen.Param("orderBy"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListPredictionMarketsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ListPredictionMarketsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarketSearchAsync()
    {
        const string example = """""[{"marketTopicId":4229564,"vendor":"PREDICT_FUN","chainId":"56","slug":"btc-price-1h-up-or-down","title":"BTC Price 1h Up or Down?","question":"Will BTC price go UP in the next 1 hour?","description":"Resolves YES if BTC spot price is higher than the starting price.","topicType":"FLAT","chartType":"CRYPTO_UP_DOWN","symbol":"BTCUSDT","participantCount":3420,"collateral":"USDT","tradeVolume":"158234.56","liquidity":"45000.00","startDate":1748131200000,"endDate":1748134800000,"status":"REGISTERED","markets":[{}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarketSearchRequest
        {
            Query = "BTC price",
        };

        var response = await client.MarketSearchAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/market/search", seen.Path);
        Assert.Equal("BTC price", seen.Param("query"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarketSearchWithOptionalParametersAsync()
    {
        const string example = """""[{"marketTopicId":4229564,"vendor":"PREDICT_FUN","chainId":"56","slug":"btc-price-1h-up-or-down","title":"BTC Price 1h Up or Down?","question":"Will BTC price go UP in the next 1 hour?","description":"Resolves YES if BTC spot price is higher than the starting price.","topicType":"FLAT","chartType":"CRYPTO_UP_DOWN","symbol":"BTCUSDT","participantCount":3420,"collateral":"USDT","tradeVolume":"158234.56","liquidity":"45000.00","startDate":1748131200000,"endDate":1748134800000,"status":"REGISTERED","markets":[{}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarketSearchRequest
        {
            Query = "BTC price",
            TopK = 20L,
        };

        var response = await client.MarketSearchAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/market/search", seen.Path);
        Assert.Equal("BTC price", seen.Param("query"));
        Assert.Equal("20", seen.Param("topK"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarketSearchBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarketSearchRequest
        {
            Query = "BTC price",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarketSearchAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryLastTradePriceAsync()
    {
        const string example = """""{"marketId":5567895,"lastTradePrice":"0.52"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryLastTradePriceRequest
        {
            MarketId = 5567895L,
        };

        var response = await client.QueryLastTradePriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/order-book/last-trade-price", seen.Path);
        Assert.Equal("5567895", seen.Param("marketId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLastTradePriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryLastTradePriceRequest
        {
            MarketId = 5567895L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryLastTradePriceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryOrderBookAsync()
    {
        const string example = """""{"outcome":"YES","tokenId":"112233","timestamp":1748131800000,"bids":[{"price":"0.51","size":"5000.00"}],"asks":[{"price":"0.52","size":"3000.00"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryOrderBookRequest
        {
            Vendor = "predict_fun",
            MarketId = 5567895L,
            TokenId = "112233",
        };

        var response = await client.QueryOrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/w3w/wallet/prediction/order-book", seen.Path);
        Assert.Equal("predict_fun", seen.Param("vendor"));
        Assert.Equal("5567895", seen.Param("marketId"));
        Assert.Equal("112233", seen.Param("tokenId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryOrderBookBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryOrderBookRequest
        {
            Vendor = "predict_fun",
            MarketId = 5567895L,
            TokenId = "112233",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryOrderBookAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
