//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingUsdsFutures.RestApi;

namespace Binance.DerivativesTradingUsdsFutures.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static DerivativesTradingUsdsFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AdlRiskAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","adlRisk":"low","updateTime":1597370495002}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AdlRiskAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/symbolAdlRisk", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AdlRiskWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","adlRisk":"low","updateTime":1597370495002}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AdlRiskRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.AdlRiskAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/symbolAdlRisk", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AdlRiskBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AdlRiskAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AssetIndexAsync()
    {
        const string example = """""{"symbol":"ADAUSD","time":1635740268004,"index":"1.92957370","bidBuffer":"0.10000000","askBuffer":"0.10000000","bidRate":"1.73661633","askRate":"2.12253107","autoExchangeBidBuffer":"0.05000000","autoExchangeAskBuffer":"0.05000000","autoExchangeBidRate":"1.83309501","autoExchangeAskRate":"2.02605238"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AssetIndexAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/assetIndex", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AssetIndexWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"ADAUSD","time":1635740268004,"index":"1.92957370","bidBuffer":"0.10000000","askBuffer":"0.10000000","bidRate":"1.73661633","askRate":"2.12253107","autoExchangeBidBuffer":"0.05000000","autoExchangeAskBuffer":"0.05000000","autoExchangeBidRate":"1.83309501","autoExchangeAskRate":"2.02605238"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AssetIndexRequest
        {
            Symbol = "ADAUSD",
        };

        var response = await client.AssetIndexAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/assetIndex", seen.Path);
        Assert.Equal("ADAUSD", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AssetIndexBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AssetIndexAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task BasisAsync()
    {
        const string example = """""[{"indexPrice":"34400.15945055","contractType":"PERPETUAL","basisRate":"0.0004","futuresPrice":"34414.10","annualizedBasisRate":"","basis":"13.94054945","pair":"BTCUSDT","timestamp":1698742800000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BasisRequest
        {
            Pair = "BTCUSDT",
            ContractType = BasisContractType.Perpetual,
            Period = BasisPeriod.Period5m,
        };

        var response = await client.BasisAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/basis", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("pair"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BasisWithOptionalParametersAsync()
    {
        const string example = """""[{"indexPrice":"34400.15945055","contractType":"PERPETUAL","basisRate":"0.0004","futuresPrice":"34414.10","annualizedBasisRate":"","basis":"13.94054945","pair":"BTCUSDT","timestamp":1698742800000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BasisRequest
        {
            Pair = "BTCUSDT",
            ContractType = BasisContractType.Perpetual,
            Period = BasisPeriod.Period5m,
            Limit = 30L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.BasisAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/basis", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("pair"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("30", seen.Param("limit"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BasisBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new BasisRequest
        {
            Pair = "BTCUSDT",
            ContractType = BasisContractType.Perpetual,
            Period = BasisPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.BasisAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CheckServerTimeAsync()
    {
        const string example = """""{"serverTime":1499827319559}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CheckServerTimeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/time", seen.Path);
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
    public async Task CompositeIndexSymbolInformationAsync()
    {
        const string example = """""[{"symbol":"DEFIUSDT","time":1589437530011,"component":"baseAsset","baseAssetList":[]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CompositeIndexSymbolInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/indexInfo", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CompositeIndexSymbolInformationWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"DEFIUSDT","time":1589437530011,"component":"baseAsset","baseAssetList":[]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CompositeIndexSymbolInformationRequest
        {
            Symbol = "DEFIUSDT",
        };

        var response = await client.CompositeIndexSymbolInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/indexInfo", seen.Path);
        Assert.Equal("DEFIUSDT", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CompositeIndexSymbolInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CompositeIndexSymbolInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CompressedAggregateTradesListAsync()
    {
        const string example = """""[{"a":26129,"p":"0.01633102","q":"4.70443515","nq":"100","f":27781,"l":27781,"T":1498793709153,"m":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CompressedAggregateTradesListRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CompressedAggregateTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/aggTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CompressedAggregateTradesListWithOptionalParametersAsync()
    {
        const string example = """""[{"a":26129,"p":"0.01633102","q":"4.70443515","nq":"100","f":27781,"l":27781,"T":1498793709153,"m":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CompressedAggregateTradesListRequest
        {
            Symbol = "BTCUSDT",
            FromId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
        };

        var response = await client.CompressedAggregateTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/aggTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CompressedAggregateTradesListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CompressedAggregateTradesListRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CompressedAggregateTradesListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickDataAsync()
    {
        const string example = """""[[1607444700000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ContinuousContractKlineCandlestickDataRequest
        {
            Pair = "BTCUSDT",
            ContractType = ContinuousContractKlineCandlestickDataContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickDataInterval.Interval1s,
        };

        var response = await client.ContinuousContractKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/continuousKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("pair"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1607444700000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ContinuousContractKlineCandlestickDataRequest
        {
            Pair = "BTCUSDT",
            ContractType = ContinuousContractKlineCandlestickDataContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickDataInterval.Interval1s,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
        };

        var response = await client.ContinuousContractKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/continuousKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("pair"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("1s", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ContinuousContractKlineCandlestickDataRequest
        {
            Pair = "BTCUSDT",
            ContractType = ContinuousContractKlineCandlestickDataContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickDataInterval.Interval1s,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ContinuousContractKlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExchangeInformationAsync()
    {
        const string example = """""{"exchangeFilters":[""],"rateLimits":[{"interval":"MINUTE","intervalNum":1,"limit":2400,"rateLimitType":"REQUEST_WEIGHT"}],"serverTime":1565613908500,"assets":[{"asset":"BTC","marginAvailable":true,"autoAssetExchange":"-0.10"}],"symbols":[{"symbol":"BLZUSDT","pair":"BLZUSDT","contractType":"PERPETUAL","deliveryDate":4133404800000,"onboardDate":1598252400000,"status":"TRADING","maintMarginPercent":"2.5000","requiredMarginPercent":"5.0000","baseAsset":"BLZ","quoteAsset":"USDT","marginAsset":"USDT","pricePrecision":5,"quantityPrecision":0,"baseAssetPrecision":8,"quotePrecision":8,"underlyingType":"COIN","underlyingSubType":["STORAGE"],"settlePlan":0,"triggerProtect":"0.15","filters":[{"filterType":"PRICE_FILTER","maxPrice":"300","minPrice":"0.0001","tickSize":"0.0001","maxQty":"10000000","minQty":"1","stepSize":"1","limit":200,"notional":"5.0","multiplierUp":"1.1500","multiplierDown":"0.8500","multiplierDecimal":"4"}],"orderTypes":["LIMIT"],"timeInForce":["GTC"],"liquidationFee":"0.010000","marketTakeBound":"0.30"}],"timezone":"UTC"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExchangeInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/exchangeInfo", seen.Path);
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
    public async Task GetFundingRateHistoryAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","fundingRate":"-0.03750000","fundingTime":1570608000000,"markPrice":"34287.54619963","rateType":"Regular"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFundingRateHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/fundingRate", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFundingRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","fundingRate":"-0.03750000","fundingTime":1570608000000,"markPrice":"34287.54619963","rateType":"Regular"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFundingRateHistoryRequest
        {
            Symbol = "BTCUSDT",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
        };

        var response = await client.GetFundingRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/fundingRate", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFundingRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFundingRateHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFundingRateInfoAsync()
    {
        const string example = """""[{"symbol":"BLZUSDT","adjustedFundingRateCap":"0.02500000","adjustedFundingRateFloor":"-0.02500000","fundingIntervalHours":8,"disclaimer":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFundingRateInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/fundingInfo", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFundingRateInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFundingRateInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task IndexPriceKlineCandlestickDataAsync()
    {
        const string example = """""[[1591256400000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new IndexPriceKlineCandlestickDataRequest
        {
            Pair = "BTCUSDT",
            Interval = IndexPriceKlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.IndexPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/indexPriceKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("pair"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task IndexPriceKlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1591256400000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new IndexPriceKlineCandlestickDataRequest
        {
            Pair = "BTCUSDT",
            Interval = IndexPriceKlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
        };

        var response = await client.IndexPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/indexPriceKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("pair"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task IndexPriceKlineCandlestickDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new IndexPriceKlineCandlestickDataRequest
        {
            Pair = "BTCUSDT",
            Interval = IndexPriceKlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.IndexPriceKlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KlineCandlestickDataAsync()
    {
        const string example = """""[[1499040000000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlineCandlestickDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = KlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.KlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/klines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1499040000000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlineCandlestickDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = KlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
        };

        var response = await client.KlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/klines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
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
            Symbol = "BTCUSDT",
            Interval = KlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task LongShortRatioAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","longShortRatio":"0.1960","longAccount":"0.6622","shortAccount":"0.3378","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new LongShortRatioRequest
        {
            Symbol = "BTCUSDT",
            Period = LongShortRatioPeriod.Period5m,
        };

        var response = await client.LongShortRatioAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/globalLongShortAccountRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task LongShortRatioWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","longShortRatio":"0.1960","longAccount":"0.6622","shortAccount":"0.3378","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new LongShortRatioRequest
        {
            Symbol = "BTCUSDT",
            Period = LongShortRatioPeriod.Period5m,
            Limit = 50L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.LongShortRatioAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/globalLongShortAccountRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task LongShortRatioBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new LongShortRatioRequest
        {
            Symbol = "BTCUSDT",
            Period = LongShortRatioPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.LongShortRatioAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarkPriceAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","markPrice":"11793.63104562","indexPrice":"11781.80495970","estimatedSettlePrice":"11781.16138815","lastFundingRate":"0.00038246","interestRate":"0.00010000","nextFundingTime":1597392000000,"time":1597370495002}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.MarkPriceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/premiumIndex", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarkPriceWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","markPrice":"11793.63104562","indexPrice":"11781.80495970","estimatedSettlePrice":"11781.16138815","lastFundingRate":"0.00038246","interestRate":"0.00010000","nextFundingTime":1597392000000,"time":1597370495002}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarkPriceRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.MarkPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/premiumIndex", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarkPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarkPriceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarkPriceKlineCandlestickDataAsync()
    {
        const string example = """""[[1591256460000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarkPriceKlineCandlestickDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = MarkPriceKlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.MarkPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/markPriceKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarkPriceKlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1591256460000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarkPriceKlineCandlestickDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = MarkPriceKlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
        };

        var response = await client.MarkPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/markPriceKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarkPriceKlineCandlestickDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarkPriceKlineCandlestickDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = MarkPriceKlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarkPriceKlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OldTradesLookupAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"8000.00","time":1499865549590,"isBuyerMaker":true,"isRPITrade":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OldTradesLookupRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.OldTradesLookupAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/historicalTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OldTradesLookupWithOptionalParametersAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"8000.00","time":1499865549590,"isBuyerMaker":true,"isRPITrade":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OldTradesLookupRequest
        {
            Symbol = "BTCUSDT",
            Limit = 50L,
            FromId = 1L,
        };

        var response = await client.OldTradesLookupAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/historicalTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OldTradesLookupBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OldTradesLookupRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OldTradesLookupAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenInterestAsync()
    {
        const string example = """""{"openInterest":"10659.509","symbol":"BTCUSDT","time":1589437530011}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenInterestRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.OpenInterestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/openInterest", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
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
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OpenInterestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenInterestStatisticsAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","sumOpenInterest":"20403.12345678","sumOpenInterestValue":"176196512.12345678","CMCCirculatingSupply":"165880.538","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenInterestStatisticsRequest
        {
            Symbol = "BTCUSDT",
            Period = OpenInterestStatisticsPeriod.Period5m,
        };

        var response = await client.OpenInterestStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/openInterestHist", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OpenInterestStatisticsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","sumOpenInterest":"20403.12345678","sumOpenInterestValue":"176196512.12345678","CMCCirculatingSupply":"165880.538","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenInterestStatisticsRequest
        {
            Symbol = "BTCUSDT",
            Period = OpenInterestStatisticsPeriod.Period5m,
            Limit = 50L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.OpenInterestStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/openInterestHist", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OpenInterestStatisticsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OpenInterestStatisticsRequest
        {
            Symbol = "BTCUSDT",
            Period = OpenInterestStatisticsPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OpenInterestStatisticsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderBookAsync()
    {
        const string example = """""{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959,"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderBookRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.OrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/depth", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderBookWithOptionalParametersAsync()
    {
        const string example = """""{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959,"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderBookRequest
        {
            Symbol = "BTCUSDT",
            Limit = 50L,
        };

        var response = await client.OrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/depth", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("50", seen.Param("limit"));
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
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderBookAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PremiumIndexKlineDataAsync()
    {
        const string example = """""[[1691603820000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PremiumIndexKlineDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = PremiumIndexKlineDataInterval.Interval1m,
        };

        var response = await client.PremiumIndexKlineDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/premiumIndexKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PremiumIndexKlineDataWithOptionalParametersAsync()
    {
        const string example = """""[[1691603820000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PremiumIndexKlineDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = PremiumIndexKlineDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
        };

        var response = await client.PremiumIndexKlineDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/premiumIndexKlines", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PremiumIndexKlineDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new PremiumIndexKlineDataRequest
        {
            Symbol = "BTCUSDT",
            Interval = PremiumIndexKlineDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PremiumIndexKlineDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuarterlyContractSettlementPriceAsync()
    {
        const string example = """""[{"deliveryTime":1695945600000,"deliveryPrice":27103}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuarterlyContractSettlementPriceRequest
        {
            Pair = "BTCUSDT",
        };

        var response = await client.QuarterlyContractSettlementPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/delivery-price", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("pair"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuarterlyContractSettlementPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuarterlyContractSettlementPriceRequest
        {
            Pair = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuarterlyContractSettlementPriceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryIndexPriceConstituentsAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","time":1745401553408,"constituents":[]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryIndexPriceConstituentsRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryIndexPriceConstituentsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/constituents", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryIndexPriceConstituentsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryIndexPriceConstituentsRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryIndexPriceConstituentsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryInsuranceFundBalanceSnapshotAsync()
    {
        const string example = """""{"symbols":[],"assets":[]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryInsuranceFundBalanceSnapshotAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/insuranceBalance", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryInsuranceFundBalanceSnapshotWithOptionalParametersAsync()
    {
        const string example = """""{"symbols":[],"assets":[]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryInsuranceFundBalanceSnapshotRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.QueryInsuranceFundBalanceSnapshotAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/insuranceBalance", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryInsuranceFundBalanceSnapshotBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryInsuranceFundBalanceSnapshotAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RecentTradesListAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.00","time":1499865549590,"isBuyerMaker":true,"isRPITrade":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RecentTradesListRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.RecentTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/trades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RecentTradesListWithOptionalParametersAsync()
    {
        const string example = """""[{"id":28457,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.00","time":1499865549590,"isBuyerMaker":true,"isRPITrade":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RecentTradesListRequest
        {
            Symbol = "BTCUSDT",
            Limit = 50L,
        };

        var response = await client.RecentTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/trades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("50", seen.Param("limit"));
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
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RecentTradesListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RpiOrderBookAsync()
    {
        const string example = """""{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959,"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RpiOrderBookRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.RpiOrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/rpiDepth", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RpiOrderBookWithOptionalParametersAsync()
    {
        const string example = """""{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959,"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RpiOrderBookRequest
        {
            Symbol = "BTCUSDT",
            Limit = 1000L,
        };

        var response = await client.RpiOrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/rpiDepth", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1000", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RpiOrderBookBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RpiOrderBookRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RpiOrderBookAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SymbolOrderBookTickerAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000","time":1589437530011}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SymbolOrderBookTickerAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/ticker/bookTicker", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolOrderBookTickerWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000","time":1589437530011}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SymbolOrderBookTickerRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.SymbolOrderBookTickerAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/ticker/bookTicker", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolOrderBookTickerBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SymbolOrderBookTickerAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

#pragma warning disable CS0618 // This endpoint is deprecated.
    [Fact]
    public async Task SymbolPriceTickerAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SymbolPriceTickerAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/ticker/price", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolPriceTickerWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SymbolPriceTickerRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.SymbolPriceTickerAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/ticker/price", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolPriceTickerBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SymbolPriceTickerAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

#pragma warning restore CS0618

    [Fact]
    public async Task SymbolPriceTickerV2Async()
    {
        const string example = """""{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SymbolPriceTickerV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/ticker/price", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolPriceTickerV2WithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SymbolPriceTickerV2Request
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.SymbolPriceTickerV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/ticker/price", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolPriceTickerV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SymbolPriceTickerV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TakerBuySellVolumeAsync()
    {
        const string example = """""[{"buySellRatio":"1.5586","buyVol":"387.3300","sellVol":"248.5030","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TakerBuySellVolumeRequest
        {
            Symbol = "BTCUSDT",
            Period = TakerBuySellVolumePeriod.Period5m,
        };

        var response = await client.TakerBuySellVolumeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/takerlongshortRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TakerBuySellVolumeWithOptionalParametersAsync()
    {
        const string example = """""[{"buySellRatio":"1.5586","buyVol":"387.3300","sellVol":"248.5030","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TakerBuySellVolumeRequest
        {
            Symbol = "BTCUSDT",
            Period = TakerBuySellVolumePeriod.Period5m,
            Limit = 50L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.TakerBuySellVolumeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/takerlongshortRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TakerBuySellVolumeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TakerBuySellVolumeRequest
        {
            Symbol = "BTCUSDT",
            Period = TakerBuySellVolumePeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TakerBuySellVolumeAsync(request));

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
        Assert.Equal("/fapi/v1/ping", seen.Path);
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
        const string example = """""{"symbol":"BTCUSDT","priceChange":"-94.99999800","priceChangePercent":"-95.960","weightedAvgPrice":"0.29628482","lastPrice":"4.00000200","lastQty":"200.00000000","openPrice":"99.00000000","highPrice":"100.00000000","lowPrice":"0.10000000","volume":"8913.30000000","quoteVolume":"15.30000000","openTime":1499783499040,"closeTime":1499869899040,"firstId":28385,"lastId":28460,"count":76}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.Ticker24hrPriceChangeStatisticsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/ticker/24hr", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task Ticker24hrPriceChangeStatisticsWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","priceChange":"-94.99999800","priceChangePercent":"-95.960","weightedAvgPrice":"0.29628482","lastPrice":"4.00000200","lastQty":"200.00000000","openPrice":"99.00000000","highPrice":"100.00000000","lowPrice":"0.10000000","volume":"8913.30000000","quoteVolume":"15.30000000","openTime":1499783499040,"closeTime":1499869899040,"firstId":28385,"lastId":28460,"count":76}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new Ticker24hrPriceChangeStatisticsRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.Ticker24hrPriceChangeStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/ticker/24hr", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
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

    [Fact]
    public async Task TopTraderLongShortRatioAccountsAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","longShortRatio":"1.8105","longAccount":"0.6442","shortAccount":"0.3558","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioAccountsRequest
        {
            Symbol = "BTCUSDT",
            Period = TopTraderLongShortRatioAccountsPeriod.Period5m,
        };

        var response = await client.TopTraderLongShortRatioAccountsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortAccountRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TopTraderLongShortRatioAccountsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","longShortRatio":"1.8105","longAccount":"0.6442","shortAccount":"0.3558","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioAccountsRequest
        {
            Symbol = "BTCUSDT",
            Period = TopTraderLongShortRatioAccountsPeriod.Period5m,
            Limit = 50L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.TopTraderLongShortRatioAccountsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortAccountRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TopTraderLongShortRatioAccountsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TopTraderLongShortRatioAccountsRequest
        {
            Symbol = "BTCUSDT",
            Period = TopTraderLongShortRatioAccountsPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TopTraderLongShortRatioAccountsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TopTraderLongShortRatioPositionsAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","longShortRatio":"1.4342","longAccount":"0.5344","shortAccount":"0.4238","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioPositionsRequest
        {
            Symbol = "BTCUSDT",
            Period = TopTraderLongShortRatioPositionsPeriod.Period5m,
        };

        var response = await client.TopTraderLongShortRatioPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortPositionRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TopTraderLongShortRatioPositionsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","longShortRatio":"1.4342","longAccount":"0.5344","shortAccount":"0.4238","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioPositionsRequest
        {
            Symbol = "BTCUSDT",
            Period = TopTraderLongShortRatioPositionsPeriod.Period5m,
            Limit = 50L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.TopTraderLongShortRatioPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortPositionRatio", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TopTraderLongShortRatioPositionsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TopTraderLongShortRatioPositionsRequest
        {
            Symbol = "BTCUSDT",
            Period = TopTraderLongShortRatioPositionsPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TopTraderLongShortRatioPositionsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TradingScheduleAsync()
    {
        const string example = """""{"updateTime":1761286643918,"marketSchedules":{}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TradingScheduleAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/tradingSchedule", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TradingScheduleBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TradingScheduleAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
