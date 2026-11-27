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

namespace Binance.Spot.Tests.RestApi.Market;

[Trait("Category", "Native")]
public class MarketApiTests
{
    private static SpotRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AggTradesAsync()
    {
        const string example = """""[{"a":26129,"p":"0.01633102","q":"4.70443515","f":27781,"l":27781,"T":1498793709153,"m":true,"M":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AggTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.AggTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/aggTrades", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AggTradesWithOptionalParametersAsync()
    {
        const string example = """""[{"a":26129,"p":"0.01633102","q":"4.70443515","f":27781,"l":27781,"T":1498793709153,"m":true,"M":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AggTradesRequest
        {
            Symbol = "BNBUSDT",
            FromId = 1L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            Limit = 1L,
        };

        var response = await client.AggTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/aggTrades", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1735693200000", seen.Param("startTime"));
        Assert.Equal("1735693200000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AggTradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AggTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AggTradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AvgPriceAsync()
    {
        const string example = """""{"mins":5,"price":"9.35751834","closeTime":1694061154503}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AvgPriceRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.AvgPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/avgPrice", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AvgPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AvgPriceRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AvgPriceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DepthAsync()
    {
        const string example = """""{"lastUpdateId":1027024,"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepthRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.DepthAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/depth", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepthWithOptionalParametersAsync()
    {
        const string example = """""{"lastUpdateId":1027024,"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepthRequest
        {
            Symbol = "BNBUSDT",
            Limit = 1L,
            SymbolStatus = DepthSymbolStatus.Trading,
        };

        var response = await client.DepthAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/depth", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepthBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DepthRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DepthAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetTradesAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.000012","time":1499865549590,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.GetTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/trades", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetTradesWithOptionalParametersAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.000012","time":1499865549590,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetTradesRequest
        {
            Symbol = "BNBUSDT",
            Limit = 1L,
        };

        var response = await client.GetTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/trades", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetTradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetTradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task HistoricalBlockTradesAsync()
    {
        const string example = """""[{"id":582,"price":"0.052","qty":"5838","quoteQty":"303.576","time":1772506983321,"isBuyerMaker":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HistoricalBlockTradesRequest
        {
            Symbol = "BNBBTC",
            FromId = 582L,
        };

        var response = await client.HistoricalBlockTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/historicalBlockTrades", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("582", seen.Param("fromId"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HistoricalBlockTradesWithOptionalParametersAsync()
    {
        const string example = """""[{"id":582,"price":"0.052","qty":"5838","quoteQty":"303.576","time":1772506983321,"isBuyerMaker":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HistoricalBlockTradesRequest
        {
            Symbol = "BNBBTC",
            FromId = 582L,
            Limit = 500L,
        };

        var response = await client.HistoricalBlockTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/historicalBlockTrades", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("582", seen.Param("fromId"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HistoricalBlockTradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new HistoricalBlockTradesRequest
        {
            Symbol = "BNBBTC",
            FromId = 582L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.HistoricalBlockTradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task HistoricalTradesAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.000012","time":1499865549590,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HistoricalTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.HistoricalTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/historicalTrades", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HistoricalTradesWithOptionalParametersAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.000012","time":1499865549590,"isBuyerMaker":true,"isBestMatch":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new HistoricalTradesRequest
        {
            Symbol = "BNBUSDT",
            Limit = 1L,
            FromId = 1L,
        };

        var response = await client.HistoricalTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/historicalTrades", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task HistoricalTradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new HistoricalTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.HistoricalTradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KlinesAsync()
    {
        const string example = """""[[1499040000000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = KlinesInterval.Interval1s,
        };

        var response = await client.KlinesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/klines", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlinesWithOptionalParametersAsync()
    {
        const string example = """""[[1499040000000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = KlinesInterval.Interval1s,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            TimeZone = "0",
            Limit = 1L,
        };

        var response = await client.KlinesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/klines", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Equal("1735693200000", seen.Param("startTime"));
        Assert.Equal("1735693200000", seen.Param("endTime"));
        Assert.Equal("0", seen.Param("timeZone"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlinesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new KlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = KlinesInterval.Interval1s,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KlinesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ReferencePriceAsync()
    {
        const string example = """""{"symbol":"BAZUSD","referencePrice":"10.00","timestamp":1770736694138}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ReferencePriceRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.ReferencePriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/referencePrice", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ReferencePriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ReferencePriceRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ReferencePriceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ReferencePriceCalculationAsync()
    {
        const string example = """""{"symbol":"BAZUSD","calculationType":"ARITHMETIC_MEAN","bucketCount":10,"bucketWidthMs":1000,"externalCalculationId":42}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ReferencePriceCalculationRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.ReferencePriceCalculationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/referencePrice/calculation", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ReferencePriceCalculationWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BAZUSD","calculationType":"ARITHMETIC_MEAN","bucketCount":10,"bucketWidthMs":1000,"externalCalculationId":42}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ReferencePriceCalculationRequest
        {
            Symbol = "BNBUSDT",
            SymbolStatus = ReferencePriceCalculationSymbolStatus.Trading,
        };

        var response = await client.ReferencePriceCalculationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/referencePrice/calculation", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ReferencePriceCalculationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ReferencePriceCalculationRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ReferencePriceCalculationAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerAsync()
    {
        const string example = """""{"symbol":"LTCBTC","priceChange":"-8.00000000","priceChangePercent":"-88.889","weightedAvgPrice":"2.60427807","openPrice":"0.10000000","highPrice":"2.00000000","lowPrice":"0.10000000","lastPrice":"2.00000000","volume":"39.00000000","quoteVolume":"13.40000000","openTime":1656986580000,"closeTime":1657001016795,"firstId":0,"lastId":34,"count":35}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TickerAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"LTCBTC","priceChange":"-8.00000000","priceChangePercent":"-88.889","weightedAvgPrice":"2.60427807","openPrice":"0.10000000","highPrice":"2.00000000","lowPrice":"0.10000000","lastPrice":"2.00000000","volume":"39.00000000","quoteVolume":"13.40000000","openTime":1656986580000,"closeTime":1657001016795,"firstId":0,"lastId":34,"count":35}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TickerRequest
        {
            Symbol = "BNBUSDT",
            Symbols = new() { },
            WindowSize = TickerWindowSize.WindowSize1m,
            Type = TickerType.Full,
            SymbolStatus = TickerSymbolStatus.Trading,
        };

        var response = await client.TickerAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("windowSize"));
        Assert.Equal("FULL", seen.Param("type"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TickerAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task Ticker24hrAsync()
    {
        const string example = """""{"symbol":"BNBBTC","priceChange":"-94.99999800","priceChangePercent":"-95.960","weightedAvgPrice":"0.29628482","prevClosePrice":"0.10002000","lastPrice":"4.00000200","lastQty":"200.00000000","bidPrice":"4.00000000","bidQty":"100.00000000","askPrice":"4.00000200","askQty":"100.00000000","openPrice":"99.00000000","highPrice":"100.00000000","lowPrice":"0.10000000","volume":"8913.30000000","quoteVolume":"15.30000000","openTime":1499783499040,"closeTime":1499869899040,"firstId":28385,"lastId":28460,"count":76}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.Ticker24hrAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/24hr", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task Ticker24hrWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BNBBTC","priceChange":"-94.99999800","priceChangePercent":"-95.960","weightedAvgPrice":"0.29628482","prevClosePrice":"0.10002000","lastPrice":"4.00000200","lastQty":"200.00000000","bidPrice":"4.00000000","bidQty":"100.00000000","askPrice":"4.00000200","askQty":"100.00000000","openPrice":"99.00000000","highPrice":"100.00000000","lowPrice":"0.10000000","volume":"8913.30000000","quoteVolume":"15.30000000","openTime":1499783499040,"closeTime":1499869899040,"firstId":28385,"lastId":28460,"count":76}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new Ticker24hrRequest
        {
            Symbol = "BNBUSDT",
            Symbols = new() { },
            Type = Ticker24hrType.Full,
            SymbolStatus = Ticker24hrSymbolStatus.Trading,
        };

        var response = await client.Ticker24hrAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/24hr", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("FULL", seen.Param("type"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task Ticker24hrBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.Ticker24hrAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerBookTickerAsync()
    {
        const string example = """""{"symbol":"LTCBTC","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TickerBookTickerAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/bookTicker", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerBookTickerWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"LTCBTC","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TickerBookTickerRequest
        {
            Symbol = "BNBUSDT",
            Symbols = new() { },
            SymbolStatus = TickerBookTickerSymbolStatus.Trading,
        };

        var response = await client.TickerBookTickerAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/bookTicker", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerBookTickerBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TickerBookTickerAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerPriceAsync()
    {
        const string example = """""{"symbol":"LTCBTC","price":"4.00000200"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TickerPriceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/price", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerPriceWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"LTCBTC","price":"4.00000200"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TickerPriceRequest
        {
            Symbol = "BNBUSDT",
            Symbols = new() { },
            SymbolStatus = TickerPriceSymbolStatus.Trading,
        };

        var response = await client.TickerPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/price", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TickerPriceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TickerTradingDayAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","priceChange":"-83.13000000","priceChangePercent":"-0.317","weightedAvgPrice":"26234.58803036","openPrice":"26304.80000000","highPrice":"26397.46000000","lowPrice":"26088.34000000","lastPrice":"26221.67000000","volume":"18495.35066000","quoteVolume":"485217905.04210480","openTime":1695686400000,"closeTime":1695772799999,"firstId":3220151555,"lastId":3220849281,"count":697727}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TickerTradingDayAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/tradingDay", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerTradingDayWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","priceChange":"-83.13000000","priceChangePercent":"-0.317","weightedAvgPrice":"26234.58803036","openPrice":"26304.80000000","highPrice":"26397.46000000","lowPrice":"26088.34000000","lastPrice":"26221.67000000","volume":"18495.35066000","quoteVolume":"485217905.04210480","openTime":1695686400000,"closeTime":1695772799999,"firstId":3220151555,"lastId":3220849281,"count":697727}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TickerTradingDayRequest
        {
            Symbol = "BNBUSDT",
            Symbols = new() { },
            TimeZone = "0",
            Type = TickerTradingDayType.Full,
            SymbolStatus = TickerTradingDaySymbolStatus.Trading,
        };

        var response = await client.TickerTradingDayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/ticker/tradingDay", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("0", seen.Param("timeZone"));
        Assert.Equal("FULL", seen.Param("type"));
        Assert.Equal("TRADING", seen.Param("symbolStatus"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TickerTradingDayBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TickerTradingDayAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UiKlinesAsync()
    {
        const string example = """""[[1499040000000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UiKlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = UiKlinesInterval.Interval1s,
        };

        var response = await client.UiKlinesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/uiKlines", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UiKlinesWithOptionalParametersAsync()
    {
        const string example = """""[[1499040000000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UiKlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = UiKlinesInterval.Interval1s,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            TimeZone = "0",
            Limit = 1L,
        };

        var response = await client.UiKlinesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/uiKlines", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Equal("1735693200000", seen.Param("startTime"));
        Assert.Equal("1735693200000", seen.Param("endTime"));
        Assert.Equal("0", seen.Param("timeZone"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UiKlinesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new UiKlinesRequest
        {
            Symbol = "BNBUSDT",
            Interval = UiKlinesInterval.Interval1s,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UiKlinesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
