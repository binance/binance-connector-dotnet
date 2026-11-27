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

namespace Binance.Spot.Tests.WebSocketApi.Market;

[Trait("Category", "Native")]
public class MarketApiTests
{
    [Fact]
    public async Task AvgPriceAsync()
    {
        const string envelope = """""{"id":"ddbfb65f-9ebf-42ec-8240-8f0f91de0867","status":200,"result":{"mins":5,"price":"0.01378135","closeTime":1694061154503},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"mins":5,"price":"0.01378135","closeTime":1694061154503}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AvgPriceRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.AvgPriceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("avgPrice", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AvgPriceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"ddbfb65f-9ebf-42ec-8240-8f0f91de0867","status":200,"result":{"mins":5,"price":"0.01378135","closeTime":1694061154503},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"mins":5,"price":"0.01378135","closeTime":1694061154503}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AvgPriceRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.AvgPriceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("avgPrice", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AvgPriceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new AvgPriceRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AvgPriceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task BlockTradesHistoricalAsync()
    {
        const string envelope = """""{"id":"cffc9c7d-4efc-4ce0-b587-6b87448f052a","status":200,"result":[{"id":582,"price":"0.052","qty":"5838","quoteQty":"303.576","time":1772506983321,"isBuyerMaker":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":10}]}""""";
        const string result = """""[{"id":582,"price":"0.052","qty":"5838","quoteQty":"303.576","time":1772506983321,"isBuyerMaker":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new BlockTradesHistoricalRequest
        {
            Symbol = "BNBBTC",
            FromId = 582L,
        };

        var response = await client.BlockTradesHistoricalAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("blockTrades.historical", frame.Method);
        Assert.Equal("BNBBTC", frame.Param("symbol"));
        Assert.Equal("582", frame.Param("fromId"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task BlockTradesHistoricalWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"cffc9c7d-4efc-4ce0-b587-6b87448f052a","status":200,"result":[{"id":582,"price":"0.052","qty":"5838","quoteQty":"303.576","time":1772506983321,"isBuyerMaker":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":10}]}""""";
        const string result = """""[{"id":582,"price":"0.052","qty":"5838","quoteQty":"303.576","time":1772506983321,"isBuyerMaker":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new BlockTradesHistoricalRequest
        {
            Symbol = "BNBBTC",
            FromId = 582L,
            Id = "0123456789abcdef0123456789abcdef",
            Limit = 500L,
        };

        var response = await client.BlockTradesHistoricalAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("blockTrades.historical", frame.Method);
        Assert.Equal("BNBBTC", frame.Param("symbol"));
        Assert.Equal("582", frame.Param("fromId"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("500", frame.Param("limit"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task BlockTradesHistoricalBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new BlockTradesHistoricalRequest
        {
            Symbol = "BNBBTC",
            FromId = 582L,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.BlockTradesHistoricalAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DepthAsync()
    {
        const string envelope = """""{"id":"51e2affb-0aba-4821-ba75-f2625006eb43","status":200,"result":{"lastUpdateId":2731179239,"bids":[["0.01379900","3.43200000"],["0.01379800","3.24300000"],["0.01379700","10.45500000"],["0.01379600","3.82100000"],["0.01379500","10.26200000"]],"asks":[["0.01380000","5.91700000"],["0.01380100","6.01400000"],["0.01380200","0.26800000"],["0.01380300","0.33800000"],["0.01380400","0.26800000"]]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"lastUpdateId":2731179239,"bids":[["0.01379900","3.43200000"],["0.01379800","3.24300000"],["0.01379700","10.45500000"],["0.01379600","3.82100000"],["0.01379500","10.26200000"]],"asks":[["0.01380000","5.91700000"],["0.01380100","6.01400000"],["0.01380200","0.26800000"],["0.01380300","0.33800000"],["0.01380400","0.26800000"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new DepthRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.DepthAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("depth", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task DepthWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"51e2affb-0aba-4821-ba75-f2625006eb43","status":200,"result":{"lastUpdateId":2731179239,"bids":[["0.01379900","3.43200000"],["0.01379800","3.24300000"],["0.01379700","10.45500000"],["0.01379600","3.82100000"],["0.01379500","10.26200000"]],"asks":[["0.01380000","5.91700000"],["0.01380100","6.01400000"],["0.01380200","0.26800000"],["0.01380300","0.33800000"],["0.01380400","0.26800000"]]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"lastUpdateId":2731179239,"bids":[["0.01379900","3.43200000"],["0.01379800","3.24300000"],["0.01379700","10.45500000"],["0.01379600","3.82100000"],["0.01379500","10.26200000"]],"asks":[["0.01380000","5.91700000"],["0.01380100","6.01400000"],["0.01380200","0.26800000"],["0.01380300","0.33800000"],["0.01380400","0.26800000"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new DepthRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            Limit = 1L,
            SymbolStatus = DepthSymbolStatus.Trading,
        };

        var response = await client.DepthAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("depth", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("limit"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task DepthBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new DepthRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.DepthAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KlinesAsync()
    {
        const string envelope = """""{"id":"1dbbeb56-8eea-466a-8f6e-86bdcfa2fc0b","status":200,"result":[[1499040000000]],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""[[1499040000000]]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new KlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = KlinesInterval.Interval1s,
        };

        var response = await client.KlinesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("klines", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("1s", frame.Param("interval"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task KlinesWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"1dbbeb56-8eea-466a-8f6e-86bdcfa2fc0b","status":200,"result":[[1499040000000]],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""[[1499040000000]]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new KlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = KlinesInterval.Interval1s,
            Id = "0123456789abcdef0123456789abcdef",
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            TimeZone = "0",
            Limit = 1L,
        };

        var response = await client.KlinesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("klines", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("1s", frame.Param("interval"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1735693200000", frame.Param("startTime"));
        Assert.Equal("1735693200000", frame.Param("endTime"));
        Assert.Equal("0", frame.Param("timeZone"));
        Assert.Equal("1", frame.Param("limit"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task KlinesBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new KlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = KlinesInterval.Interval1s,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.KlinesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ReferencePriceAsync()
    {
        const string envelope = """""{"id":"ddbfb65f-9ebf-42ec-8240-8f0f91de0867","status":200,"result":{"symbol":"BAZUSD","referencePrice":"0.00501900","timestamp":1770946889251,"code":-2043,"msg":"This symbol doesn't have a reference price."},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BAZUSD","referencePrice":"0.00501900","timestamp":1770946889251,"code":-2043,"msg":"This symbol doesn't have a reference price."}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ReferencePriceRequest
        {
            Symbol = "BAZUSD",
        };

        var response = await client.ReferencePriceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("referencePrice", frame.Method);
        Assert.Equal("BAZUSD", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ReferencePriceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"ddbfb65f-9ebf-42ec-8240-8f0f91de0867","status":200,"result":{"symbol":"BAZUSD","referencePrice":"0.00501900","timestamp":1770946889251,"code":-2043,"msg":"This symbol doesn't have a reference price."},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BAZUSD","referencePrice":"0.00501900","timestamp":1770946889251,"code":-2043,"msg":"This symbol doesn't have a reference price."}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ReferencePriceRequest
        {
            Symbol = "BAZUSD",
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.ReferencePriceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("referencePrice", frame.Method);
        Assert.Equal("BAZUSD", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ReferencePriceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new ReferencePriceRequest
        {
            Symbol = "BAZUSD",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.ReferencePriceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ReferencePriceCalculationAsync()
    {
        const string envelope = """""{"id":"ddbfb65f-9ebf-42ec-8240-8f0f91de0867","status":200,"result":{"symbol":"BAZUSD","calculationType":"ARITHMETIC_MEAN","bucketCount":10,"bucketWidthMs":1000,"externalCalculationId":42},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BAZUSD","calculationType":"ARITHMETIC_MEAN","bucketCount":10,"bucketWidthMs":1000,"externalCalculationId":42}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ReferencePriceCalculationRequest
        {
            Symbol = "BAZUSD",
        };

        var response = await client.ReferencePriceCalculationAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("referencePrice.calculation", frame.Method);
        Assert.Equal("BAZUSD", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ReferencePriceCalculationWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"ddbfb65f-9ebf-42ec-8240-8f0f91de0867","status":200,"result":{"symbol":"BAZUSD","calculationType":"ARITHMETIC_MEAN","bucketCount":10,"bucketWidthMs":1000,"externalCalculationId":42},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BAZUSD","calculationType":"ARITHMETIC_MEAN","bucketCount":10,"bucketWidthMs":1000,"externalCalculationId":42}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ReferencePriceCalculationRequest
        {
            Symbol = "BAZUSD",
            Id = "0123456789abcdef0123456789abcdef",
            SymbolStatus = ReferencePriceCalculationSymbolStatus.Trading,
        };

        var response = await client.ReferencePriceCalculationAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("referencePrice.calculation", frame.Method);
        Assert.Equal("BAZUSD", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ReferencePriceCalculationBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new ReferencePriceCalculationRequest
        {
            Symbol = "BAZUSD",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.ReferencePriceCalculationAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerAsync()
    {
        const string envelope = """""{"id":"bdb7c503-542c-495c-b797-4d2ee2e91173","status":200,"result":{"symbol":"BNBBTC","priceChange":"0.00061500","priceChangePercent":"4.735","weightedAvgPrice":"0.01368242","openPrice":"0.01298900","highPrice":"0.01418800","lowPrice":"0.01296000","lastPrice":"0.01360400","volume":"587179.23900000","quoteVolume":"8034.03382165","openTime":1659580020000,"closeTime":1660184865291,"firstId":192977765,"lastId":195365758,"count":2387994},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"symbol":"BNBBTC","priceChange":"0.00061500","priceChangePercent":"4.735","weightedAvgPrice":"0.01368242","openPrice":"0.01298900","highPrice":"0.01418800","lowPrice":"0.01296000","lastPrice":"0.01360400","volume":"587179.23900000","quoteVolume":"8034.03382165","openTime":1659580020000,"closeTime":1660184865291,"firstId":192977765,"lastId":195365758,"count":2387994}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.TickerAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ticker", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"bdb7c503-542c-495c-b797-4d2ee2e91173","status":200,"result":{"symbol":"BNBBTC","priceChange":"0.00061500","priceChangePercent":"4.735","weightedAvgPrice":"0.01368242","openPrice":"0.01298900","highPrice":"0.01418800","lowPrice":"0.01296000","lastPrice":"0.01360400","volume":"587179.23900000","quoteVolume":"8034.03382165","openTime":1659580020000,"closeTime":1660184865291,"firstId":192977765,"lastId":195365758,"count":2387994},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"symbol":"BNBBTC","priceChange":"0.00061500","priceChangePercent":"4.735","weightedAvgPrice":"0.01368242","openPrice":"0.01298900","highPrice":"0.01418800","lowPrice":"0.01296000","lastPrice":"0.01360400","volume":"587179.23900000","quoteVolume":"8034.03382165","openTime":1659580020000,"closeTime":1660184865291,"firstId":192977765,"lastId":195365758,"count":2387994}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TickerRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BNBUSDT",
            Symbols = new() { },
            Type = TickerType.Full,
            WindowSize = TickerWindowSize.WindowSize1m,
            SymbolStatus = TickerSymbolStatus.Trading,
        };

        var response = await client.TickerAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ticker", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("FULL", frame.Param("type"));
        Assert.Equal("1m", frame.Param("windowSize"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TickerAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task Ticker24hrAsync()
    {
        const string envelope = """""{"id":"9fa2a91b-3fca-4ed7-a9ad-58e3b67483de","status":200,"result":{"symbol":"BNBBTC","priceChange":"0.00013900","priceChangePercent":"1.020","weightedAvgPrice":"0.01382453","prevClosePrice":"0.01362800","lastPrice":"0.01376700","lastQty":"1.78800000","bidPrice":"0.01376700","bidQty":"4.64600000","askPrice":"0.01376800","askQty":"14.31400000","openPrice":"0.01362800","highPrice":"0.01414900","lowPrice":"0.01346600","volume":"69412.40500000","quoteVolume":"959.59411487","openTime":1660014164909,"closeTime":1660100564909,"firstId":194696115,"lastId":194968287,"count":272173},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BNBBTC","priceChange":"0.00013900","priceChangePercent":"1.020","weightedAvgPrice":"0.01382453","prevClosePrice":"0.01362800","lastPrice":"0.01376700","lastQty":"1.78800000","bidPrice":"0.01376700","bidQty":"4.64600000","askPrice":"0.01376800","askQty":"14.31400000","openPrice":"0.01362800","highPrice":"0.01414900","lowPrice":"0.01346600","volume":"69412.40500000","quoteVolume":"959.59411487","openTime":1660014164909,"closeTime":1660100564909,"firstId":194696115,"lastId":194968287,"count":272173}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.Ticker24hrAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ticker.24hr", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task Ticker24hrWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"9fa2a91b-3fca-4ed7-a9ad-58e3b67483de","status":200,"result":{"symbol":"BNBBTC","priceChange":"0.00013900","priceChangePercent":"1.020","weightedAvgPrice":"0.01382453","prevClosePrice":"0.01362800","lastPrice":"0.01376700","lastQty":"1.78800000","bidPrice":"0.01376700","bidQty":"4.64600000","askPrice":"0.01376800","askQty":"14.31400000","openPrice":"0.01362800","highPrice":"0.01414900","lowPrice":"0.01346600","volume":"69412.40500000","quoteVolume":"959.59411487","openTime":1660014164909,"closeTime":1660100564909,"firstId":194696115,"lastId":194968287,"count":272173},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BNBBTC","priceChange":"0.00013900","priceChangePercent":"1.020","weightedAvgPrice":"0.01382453","prevClosePrice":"0.01362800","lastPrice":"0.01376700","lastQty":"1.78800000","bidPrice":"0.01376700","bidQty":"4.64600000","askPrice":"0.01376800","askQty":"14.31400000","openPrice":"0.01362800","highPrice":"0.01414900","lowPrice":"0.01346600","volume":"69412.40500000","quoteVolume":"959.59411487","openTime":1660014164909,"closeTime":1660100564909,"firstId":194696115,"lastId":194968287,"count":272173}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new Ticker24hrRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BNBUSDT",
            Symbols = new() { },
            Type = Ticker24hrType.Full,
            SymbolStatus = Ticker24hrSymbolStatus.Trading,
        };

        var response = await client.Ticker24hrAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ticker.24hr", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("FULL", frame.Param("type"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task Ticker24hrBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.Ticker24hrAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerBookAsync()
    {
        const string envelope = """""{"id":"9d32157c-a556-4d27-9866-66760a174b57","status":200,"result":{"symbol":"BNBBTC","bidPrice":"0.01358000","bidQty":"12.53400000","askPrice":"0.01358100","askQty":"17.83700000"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BNBBTC","bidPrice":"0.01358000","bidQty":"12.53400000","askPrice":"0.01358100","askQty":"17.83700000"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.TickerBookAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ticker.book", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerBookWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"9d32157c-a556-4d27-9866-66760a174b57","status":200,"result":{"symbol":"BNBBTC","bidPrice":"0.01358000","bidQty":"12.53400000","askPrice":"0.01358100","askQty":"17.83700000"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BNBBTC","bidPrice":"0.01358000","bidQty":"12.53400000","askPrice":"0.01358100","askQty":"17.83700000"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TickerBookRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BNBUSDT",
            Symbols = new() { },
            SymbolStatus = TickerBookSymbolStatus.Trading,
        };

        var response = await client.TickerBookAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ticker.book", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerBookBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TickerBookAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerPriceAsync()
    {
        const string envelope = """""{"id":"043a7cf2-bde3-4888-9604-c8ac41fcba4d","status":200,"result":{"symbol":"BNBBTC","price":"0.01361900"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BNBBTC","price":"0.01361900"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.TickerPriceAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ticker.price", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerPriceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"043a7cf2-bde3-4888-9604-c8ac41fcba4d","status":200,"result":{"symbol":"BNBBTC","price":"0.01361900"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""{"symbol":"BNBBTC","price":"0.01361900"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TickerPriceRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BNBUSDT",
            Symbols = new() { },
            SymbolStatus = TickerPriceSymbolStatus.Trading,
        };

        var response = await client.TickerPriceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ticker.price", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerPriceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TickerPriceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerTradingDayAsync()
    {
        const string envelope = """""{"id":"f4b3b507-c8f2-442a-81a6-b2f12daa030f","status":200,"result":{"symbol":"BTCUSDT","priceChange":"-83.13000000","priceChangePercent":"-0.317","weightedAvgPrice":"26234.58803036","openPrice":"26304.80000000","highPrice":"26397.46000000","lowPrice":"26088.34000000","lastPrice":"26221.67000000","volume":"18495.35066000","quoteVolume":"485217905.04210480","openTime":1695686400000,"closeTime":1695772799999,"firstId":3220151555,"lastId":3220849281,"count":697727},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"symbol":"BTCUSDT","priceChange":"-83.13000000","priceChangePercent":"-0.317","weightedAvgPrice":"26234.58803036","openPrice":"26304.80000000","highPrice":"26397.46000000","lowPrice":"26088.34000000","lastPrice":"26221.67000000","volume":"18495.35066000","quoteVolume":"485217905.04210480","openTime":1695686400000,"closeTime":1695772799999,"firstId":3220151555,"lastId":3220849281,"count":697727}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.TickerTradingDayAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ticker.tradingDay", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerTradingDayWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"f4b3b507-c8f2-442a-81a6-b2f12daa030f","status":200,"result":{"symbol":"BTCUSDT","priceChange":"-83.13000000","priceChangePercent":"-0.317","weightedAvgPrice":"26234.58803036","openPrice":"26304.80000000","highPrice":"26397.46000000","lowPrice":"26088.34000000","lastPrice":"26221.67000000","volume":"18495.35066000","quoteVolume":"485217905.04210480","openTime":1695686400000,"closeTime":1695772799999,"firstId":3220151555,"lastId":3220849281,"count":697727},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"symbol":"BTCUSDT","priceChange":"-83.13000000","priceChangePercent":"-0.317","weightedAvgPrice":"26234.58803036","openPrice":"26304.80000000","highPrice":"26397.46000000","lowPrice":"26088.34000000","lastPrice":"26221.67000000","volume":"18495.35066000","quoteVolume":"485217905.04210480","openTime":1695686400000,"closeTime":1695772799999,"firstId":3220151555,"lastId":3220849281,"count":697727}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TickerTradingDayRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BNBUSDT",
            Symbols = new() { },
            TimeZone = "0",
            Type = TickerTradingDayType.Full,
            SymbolStatus = TickerTradingDaySymbolStatus.Trading,
        };

        var response = await client.TickerTradingDayAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ticker.tradingDay", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0", frame.Param("timeZone"));
        Assert.Equal("FULL", frame.Param("type"));
        Assert.Equal("TRADING", frame.Param("symbolStatus"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TickerTradingDayBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TickerTradingDayAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TradesAggregateAsync()
    {
        const string envelope = """""{"id":"189da436-d4bd-48ca-9f95-9f613d621717","status":200,"result":[{"a":50000000,"p":"0.00274100","q":"57.19000000","f":59120167,"l":59120170,"T":1565877971222,"m":true,"M":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""[{"a":50000000,"p":"0.00274100","q":"57.19000000","f":59120167,"l":59120170,"T":1565877971222,"m":true,"M":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TradesAggregateRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.TradesAggregateAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("trades.aggregate", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TradesAggregateWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"189da436-d4bd-48ca-9f95-9f613d621717","status":200,"result":[{"a":50000000,"p":"0.00274100","q":"57.19000000","f":59120167,"l":59120170,"T":1565877971222,"m":true,"M":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""[{"a":50000000,"p":"0.00274100","q":"57.19000000","f":59120167,"l":59120170,"T":1565877971222,"m":true,"M":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TradesAggregateRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            FromId = 1L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            Limit = 1L,
        };

        var response = await client.TradesAggregateAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("trades.aggregate", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("fromId"));
        Assert.Equal("1735693200000", frame.Param("startTime"));
        Assert.Equal("1735693200000", frame.Param("endTime"));
        Assert.Equal("1", frame.Param("limit"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TradesAggregateBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new TradesAggregateRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TradesAggregateAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TradesHistoricalAsync()
    {
        const string envelope = """""{"id":"cffc9c7d-4efc-4ce0-b587-6b87448f052a","status":200,"result":[{"id":0,"price":"0.00005000","qty":"40.00000000","quoteQty":"0.00200000","time":1500004800376,"isBuyerMaker":true,"isBestMatch":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":25}]}""""";
        const string result = """""[{"id":0,"price":"0.00005000","qty":"40.00000000","quoteQty":"0.00200000","time":1500004800376,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TradesHistoricalRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.TradesHistoricalAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("trades.historical", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TradesHistoricalWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"cffc9c7d-4efc-4ce0-b587-6b87448f052a","status":200,"result":[{"id":0,"price":"0.00005000","qty":"40.00000000","quoteQty":"0.00200000","time":1500004800376,"isBuyerMaker":true,"isBestMatch":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":25}]}""""";
        const string result = """""[{"id":0,"price":"0.00005000","qty":"40.00000000","quoteQty":"0.00200000","time":1500004800376,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TradesHistoricalRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            FromId = 1L,
            Limit = 1L,
        };

        var response = await client.TradesHistoricalAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("trades.historical", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("fromId"));
        Assert.Equal("1", frame.Param("limit"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TradesHistoricalBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new TradesHistoricalRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TradesHistoricalAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TradesRecentAsync()
    {
        const string envelope = """""{"id":"409a20bd-253d-41db-a6dd-687862a5882f","status":200,"result":[{"id":194686783,"price":"0.01361000","qty":"0.01400000","quoteQty":"0.00019054","time":1660009530807,"isBuyerMaker":true,"isBestMatch":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":25}]}""""";
        const string result = """""[{"id":194686783,"price":"0.01361000","qty":"0.01400000","quoteQty":"0.00019054","time":1660009530807,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TradesRecentRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.TradesRecentAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("trades.recent", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TradesRecentWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"409a20bd-253d-41db-a6dd-687862a5882f","status":200,"result":[{"id":194686783,"price":"0.01361000","qty":"0.01400000","quoteQty":"0.00019054","time":1660009530807,"isBuyerMaker":true,"isBestMatch":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":25}]}""""";
        const string result = """""[{"id":194686783,"price":"0.01361000","qty":"0.01400000","quoteQty":"0.00019054","time":1660009530807,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new TradesRecentRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            Limit = 1L,
        };

        var response = await client.TradesRecentAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("trades.recent", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("limit"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task TradesRecentBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new TradesRecentRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.TradesRecentAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UiKlinesAsync()
    {
        const string envelope = """""{"id":"b137468a-fb20-4c06-bd6b-625148eec958","status":200,"result":[[1499040000000]],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""[[1499040000000]]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new UiKlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = UiKlinesInterval.Interval1s,
        };

        var response = await client.UiKlinesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("uiKlines", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("1s", frame.Param("interval"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UiKlinesWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"b137468a-fb20-4c06-bd6b-625148eec958","status":200,"result":[[1499040000000]],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":2}]}""""";
        const string result = """""[[1499040000000]]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new UiKlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = UiKlinesInterval.Interval1s,
            Id = "0123456789abcdef0123456789abcdef",
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            TimeZone = "0",
            Limit = 1L,
        };

        var response = await client.UiKlinesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("uiKlines", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("1s", frame.Param("interval"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1735693200000", frame.Param("startTime"));
        Assert.Equal("1735693200000", frame.Param("endTime"));
        Assert.Equal("0", frame.Param("timeZone"));
        Assert.Equal("1", frame.Param("limit"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task UiKlinesBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new UiKlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = UiKlinesInterval.Interval1s,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.UiKlinesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
