//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingOptions.RestApi;

namespace Binance.DerivativesTradingOptions.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static DerivativesTradingOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CheckServerTimeAsync()
    {
        const string example = """""{"serverTime":1592387156596}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CheckServerTimeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/time", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckServerTimeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CheckServerTimeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExchangeInformationAsync()
    {
        const string example = """""{"timezone":"UTC","serverTime":1592387337630,"optionContracts":[{"baseAsset":"BTC","quoteAsset":"USDT","underlying":"BTCUSDT","settleAsset":"USDT"}],"optionAssets":[{"name":"USDT"}],"optionSymbols":[{"expiryDate":1660521600000,"filters":[{"filterType":"PRICE_FILTER","minPrice":"0.02","maxPrice":"80000.01","tickSize":"0.01","minQty":"0.01","maxQty":"100","stepSize":"0.01"}],"symbol":"BTC-220815-50000-C","side":"CALL","strikePrice":"50000","underlying":"BTCUSDT","unit":1,"liquidationFeeRate":"0.0019000","minQty":"0.01","maxQty":"100","initialMargin":"0.15","maintenanceMargin":"0.075","minInitialMargin":"0.1","minMaintenanceMargin":"0.05","priceScale":2,"quantityScale":2,"quoteAsset":"USDT","contractType":"CRYPTO_OPTIONS","underlyingType":"CRYPTO","nakedSell":false,"status":"TRADING"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExchangeInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/exchangeInfo", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExchangeInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ExchangeInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task HistoricalExerciseRecordsAsync()
    {
        const string example = """""[{"symbol":"BTC-220121-60000-P","strikePrice":"60000","realStrikePrice":"38844.69652571","expiryDate":1642752000000,"strikeResult":"REALISTIC_VALUE_STRICKEN"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.HistoricalExerciseRecordsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/exerciseHistory", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HistoricalExerciseRecordsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTC-220121-60000-P","strikePrice":"60000","realStrikePrice":"38844.69652571","expiryDate":1642752000000,"strikeResult":"REALISTIC_VALUE_STRICKEN"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HistoricalExerciseRecordsRequest
        {
            Underlying = "BTCUSDT",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 20L,
        };

        var response = await client.HistoricalExerciseRecordsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/exerciseHistory", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HistoricalExerciseRecordsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.HistoricalExerciseRecordsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task IndexPriceAsync()
    {
        const string example = """""{"time":1656647305000,"indexPrice":"105917.75"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new IndexPriceRequest
        {
            Underlying = "BTCUSDT",
        };

        var response = await client.IndexPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/index", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task IndexPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new IndexPriceRequest
        {
            Underlying = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.IndexPriceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KlineCandlestickDataAsync()
    {
        const string example = """""[[1762779600000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlineCandlestickDataRequest
        {
            Symbol = "BTC-200730-9000-C",
            Interval = KlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.KlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/klines", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1762779600000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlineCandlestickDataRequest
        {
            Symbol = "BTC-200730-9000-C",
            Interval = KlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 20L,
        };

        var response = await client.KlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/klines", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlineCandlestickDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new KlineCandlestickDataRequest
        {
            Symbol = "BTC-200730-9000-C",
            Interval = KlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenInterestAsync()
    {
        const string example = """""[{"symbol":"ETH-221119-1175-P","sumOpenInterest":"4.01","sumOpenInterestUsd":"4880.2985615624","timestamp":"1668754020000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenInterestRequest
        {
            UnderlyingAsset = "ETH/BTC",
            Expiration = "221225",
        };

        var response = await client.OpenInterestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/openInterest", seen.Path);
        Assert.Equal("ETH/BTC", seen.Param("underlyingAsset"));
        Assert.Equal("221225", seen.Param("expiration"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OpenInterestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OpenInterestRequest
        {
            UnderlyingAsset = "ETH/BTC",
            Expiration = "221225",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OpenInterestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionMarkPriceAsync()
    {
        const string example = """""[{"symbol":"BTC-200730-9000-C","markPrice":"1343.2883","bidIV":"1.40000077","askIV":"1.50000153","markIV":"1.45000000","delta":"0.55937056","theta":"3739.82509871","gamma":"0.00010969","vega":"978.58874732","highPriceLimit":"1618.241","lowPriceLimit":"1068.3356","riskFreeInterest":"0.1"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionMarkPriceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/mark", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionMarkPriceWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTC-200730-9000-C","markPrice":"1343.2883","bidIV":"1.40000077","askIV":"1.50000153","markIV":"1.45000000","delta":"0.55937056","theta":"3739.82509871","gamma":"0.00010969","vega":"978.58874732","highPriceLimit":"1618.241","lowPriceLimit":"1068.3356","riskFreeInterest":"0.1"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionMarkPriceRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.OptionMarkPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/mark", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionMarkPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionMarkPriceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderBookAsync()
    {
        const string example = """""{"bids":[["1000.000","0.1000"]],"asks":[["1900.000","0.1000"]],"T":1762780909676,"lastUpdateId":361}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderBookRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.OrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/depth", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderBookWithOptionalParametersAsync()
    {
        const string example = """""{"bids":[["1000.000","0.1000"]],"asks":[["1900.000","0.1000"]],"T":1762780909676,"lastUpdateId":361}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderBookRequest
        {
            Symbol = "BTC-200730-9000-C",
            Limit = 20L,
        };

        var response = await client.OrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/depth", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderBookBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderBookRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderBookAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RecentBlockTradesListAsync()
    {
        const string example = """""[{"id":1125899906901081100,"tradeId":389,"symbol":"ETH-250725-1200-P","price":"342.40","qty":"-2167.20","quoteQty":"-4.90","side":-1,"time":1733950676483}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.RecentBlockTradesListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/blockTrades", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RecentBlockTradesListWithOptionalParametersAsync()
    {
        const string example = """""[{"id":1125899906901081100,"tradeId":389,"symbol":"ETH-250725-1200-P","price":"342.40","qty":"-2167.20","quoteQty":"-4.90","side":-1,"time":1733950676483}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RecentBlockTradesListRequest
        {
            Symbol = "BTC-200730-9000-C",
            Limit = 20L,
        };

        var response = await client.RecentBlockTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/blockTrades", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RecentBlockTradesListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RecentBlockTradesListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RecentTradesListAsync()
    {
        const string example = """""[{"id":2323857420768529000,"tradeId":1,"symbol":"BTC-251123-126000-C","price":"1300","qty":"0.1","quoteQty":"130","side":-1,"time":1762780453623}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RecentTradesListRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.RecentTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/trades", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RecentTradesListWithOptionalParametersAsync()
    {
        const string example = """""[{"id":2323857420768529000,"tradeId":1,"symbol":"BTC-251123-126000-C","price":"1300","qty":"0.1","quoteQty":"130","side":-1,"time":1762780453623}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RecentTradesListRequest
        {
            Symbol = "BTC-200730-9000-C",
            Limit = 20L,
        };

        var response = await client.RecentTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/trades", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RecentTradesListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RecentTradesListRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RecentTradesListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TestConnectivityAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.TestConnectivityAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/ping", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task TestConnectivityBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TestConnectivityAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task Ticker24hrPriceChangeStatisticsAsync()
    {
        const string example = """""[{"symbol":"BTC-200730-9000-C","priceChange":"-16.2038","priceChangePercent":"-0.0162","lastPrice":"1000","lastQty":"1000","open":"1016.2038","high":"1016.2038","low":"0","volume":"5","amount":"1","bidPrice":"999.34","askPrice":"1000.23","openTime":1592317127349,"closeTime":1592380593516,"firstTradeId":1,"tradeCount":5,"strikePrice":"9000","exercisePrice":"3000.3356"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.Ticker24hrPriceChangeStatisticsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/ticker", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task Ticker24hrPriceChangeStatisticsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTC-200730-9000-C","priceChange":"-16.2038","priceChangePercent":"-0.0162","lastPrice":"1000","lastQty":"1000","open":"1016.2038","high":"1016.2038","low":"0","volume":"5","amount":"1","bidPrice":"999.34","askPrice":"1000.23","openTime":1592317127349,"closeTime":1592380593516,"firstTradeId":1,"tradeCount":5,"strikePrice":"9000","exercisePrice":"3000.3356"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new Ticker24hrPriceChangeStatisticsRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.Ticker24hrPriceChangeStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/ticker", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task Ticker24hrPriceChangeStatisticsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.Ticker24hrPriceChangeStatisticsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
