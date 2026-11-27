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

namespace Binance.DerivativesTradingCoinFutures.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static DerivativesTradingCoinFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task BasisAsync()
    {
        const string example = """""[{"indexPrice":"29269.93972727","contractType":"CURRENT_QUARTER","basisRate":"0.0024","futuresPrice":"29341.3","annualizedBasisRate":"0.0283","basis":"71.36027273","pair":"BTCUSD","timestamp":1653381600000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BasisRequest
        {
            Pair = "pair_example",
            ContractType = BasisContractType.Perpetual,
            Period = BasisPeriod.Period5m,
        };

        var response = await client.BasisAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/basis", seen.Path);
        Assert.Equal("pair_example", seen.Param("pair"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task BasisWithOptionalParametersAsync()
    {
        const string example = """""[{"indexPrice":"29269.93972727","contractType":"CURRENT_QUARTER","basisRate":"0.0024","futuresPrice":"29341.3","annualizedBasisRate":"0.0283","basis":"71.36027273","pair":"BTCUSD","timestamp":1653381600000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new BasisRequest
        {
            Pair = "pair_example",
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
        Assert.Equal("pair_example", seen.Param("pair"));
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
            Pair = "pair_example",
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
        Assert.Equal("/dapi/v1/time", seen.Path);
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
    public async Task CompressedAggregateTradesListAsync()
    {
        const string example = """""[{"a":416690,"p":"9642.4","q":"3","f":595259,"l":595259,"T":1591250548649,"m":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CompressedAggregateTradesListRequest
        {
            Symbol = "symbol_example",
        };

        var response = await client.CompressedAggregateTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/aggTrades", seen.Path);
        Assert.Equal("symbol_example", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CompressedAggregateTradesListWithOptionalParametersAsync()
    {
        const string example = """""[{"a":416690,"p":"9642.4","q":"3","f":595259,"l":595259,"T":1591250548649,"m":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CompressedAggregateTradesListRequest
        {
            Symbol = "symbol_example",
            FromId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
        };

        var response = await client.CompressedAggregateTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/aggTrades", seen.Path);
        Assert.Equal("symbol_example", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
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
            Symbol = "symbol_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CompressedAggregateTradesListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickDataAsync()
    {
        const string example = """""[[1591258320000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ContinuousContractKlineCandlestickDataRequest
        {
            Pair = "BTCUSD",
            ContractType = ContinuousContractKlineCandlestickDataContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.ContinuousContractKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/continuousKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1591258320000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ContinuousContractKlineCandlestickDataRequest
        {
            Pair = "BTCUSD",
            ContractType = ContinuousContractKlineCandlestickDataContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
        };

        var response = await client.ContinuousContractKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/continuousKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
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
            Pair = "BTCUSD",
            ContractType = ContinuousContractKlineCandlestickDataContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ContinuousContractKlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExchangeInformationAsync()
    {
        const string example = """""{"rateLimits":[{"interval":"MINUTE","intervalNum":1,"limit":2400,"rateLimitType":"REQUEST_WEIGHT"}],"serverTime":1565613908500,"symbols":[{"filters":[{"filterType":"PRICE_FILTER","maxPrice":"100000","minPrice":"0.1","tickSize":"0.1","maxQty":"100000","minQty":"1","stepSize":"1","limit":200,"multiplierUp":"1.0500","multiplierDown":"0.9500","multiplierDecimal":"4"}],"orderTypes":["LIMIT"],"timeInForce":["GTC"],"liquidationFee":"0.010000","marketTakeBound":"0.30","symbol":"BTCUSD_200925","pair":"BTCUSD","contractType":"CURRENT_QUARTER","deliveryDate":1601020800000,"onboardDate":1590739200000,"contractStatus":"TRADING","contractSize":100,"quoteAsset":"USD","baseAsset":"BTC","marginAsset":"BTC","pricePrecision":1,"quantityPrecision":0,"baseAssetPrecision":8,"quotePrecision":8,"equalQtyPrecision":4,"triggerProtect":"0.0500","maintMarginPercent":"2.5000","requiredMarginPercent":"5.0000","underlyingType":"COIN"}],"timezone":"UTC"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExchangeInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/exchangeInfo", seen.Path);
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
    public async Task GetFundingRateHistoryOfPerpetualFuturesAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","fundingTime":1596038400000,"fundingRate":"-0.00300000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFundingRateHistoryOfPerpetualFuturesRequest
        {
            Symbol = "symbol_example",
        };

        var response = await client.GetFundingRateHistoryOfPerpetualFuturesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/fundingRate", seen.Path);
        Assert.Equal("symbol_example", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFundingRateHistoryOfPerpetualFuturesWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","fundingTime":1596038400000,"fundingRate":"-0.00300000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFundingRateHistoryOfPerpetualFuturesRequest
        {
            Symbol = "symbol_example",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
        };

        var response = await client.GetFundingRateHistoryOfPerpetualFuturesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/fundingRate", seen.Path);
        Assert.Equal("symbol_example", seen.Param("symbol"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFundingRateHistoryOfPerpetualFuturesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFundingRateHistoryOfPerpetualFuturesRequest
        {
            Symbol = "symbol_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFundingRateHistoryOfPerpetualFuturesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFundingRateInfoAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","adjustedFundingRateCap":"0.02500000","adjustedFundingRateFloor":"-0.02500000","fundingIntervalHours":8,"disclaimer":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFundingRateInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/fundingInfo", seen.Path);
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
    public async Task IndexPriceAndMarkPriceAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","pair":"BTCUSD","markPrice":"11029.69574559","indexPrice":"10979.14437500","estimatedSettlePrice":"10981.74168236","lastFundingRate":"0.00071003","interestRate":"0.00010000","nextFundingTime":1596096000000,"time":1596094042000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.IndexPriceAndMarkPriceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/premiumIndex", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task IndexPriceAndMarkPriceWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","pair":"BTCUSD","markPrice":"11029.69574559","indexPrice":"10979.14437500","estimatedSettlePrice":"10981.74168236","lastFundingRate":"0.00071003","interestRate":"0.00010000","nextFundingTime":1596096000000,"time":1596094042000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new IndexPriceAndMarkPriceRequest
        {
            Symbol = "BTCUSD_PERP",
            Pair = "BTCUSD",
        };

        var response = await client.IndexPriceAndMarkPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/premiumIndex", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task IndexPriceAndMarkPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.IndexPriceAndMarkPriceAsync());

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
            Pair = "BTCUSD",
            Interval = IndexPriceKlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.IndexPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/indexPriceKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
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
            Pair = "BTCUSD",
            Interval = IndexPriceKlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
        };

        var response = await client.IndexPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/indexPriceKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
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
            Pair = "BTCUSD",
            Interval = IndexPriceKlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.IndexPriceKlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task KlineCandlestickDataAsync()
    {
        const string example = """""[[1591258320000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlineCandlestickDataRequest
        {
            Symbol = "BTCUSD",
            Interval = KlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.KlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/klines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task KlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1591258320000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new KlineCandlestickDataRequest
        {
            Symbol = "BTCUSD",
            Interval = KlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
        };

        var response = await client.KlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/klines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
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
            Symbol = "BTCUSD",
            Interval = KlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.KlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task LongShortRatioAsync()
    {
        const string example = """""[{"pair":"BTCUSD","longShortRatio":"0.1960","longAccount":"0.6622","shortAccount":"0.3378","timestamp":1583139600000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new LongShortRatioRequest
        {
            Pair = "pair_example",
            Period = LongShortRatioPeriod.Period5m,
        };

        var response = await client.LongShortRatioAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/globalLongShortAccountRatio", seen.Path);
        Assert.Equal("pair_example", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task LongShortRatioWithOptionalParametersAsync()
    {
        const string example = """""[{"pair":"BTCUSD","longShortRatio":"0.1960","longAccount":"0.6622","shortAccount":"0.3378","timestamp":1583139600000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new LongShortRatioRequest
        {
            Pair = "pair_example",
            Period = LongShortRatioPeriod.Period5m,
            ContractType = LongShortRatioContractType.Perpetual,
            Limit = 30L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.LongShortRatioAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/globalLongShortAccountRatio", seen.Path);
        Assert.Equal("pair_example", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("30", seen.Param("limit"));
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
            Pair = "pair_example",
            Period = LongShortRatioPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.LongShortRatioAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarkPriceKlineCandlestickDataAsync()
    {
        const string example = """""[[1591256400000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarkPriceKlineCandlestickDataRequest
        {
            Symbol = "BTCUSD",
            Interval = MarkPriceKlineCandlestickDataInterval.Interval1m,
        };

        var response = await client.MarkPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/markPriceKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarkPriceKlineCandlestickDataWithOptionalParametersAsync()
    {
        const string example = """""[[1591256400000]]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarkPriceKlineCandlestickDataRequest
        {
            Symbol = "BTCUSD",
            Interval = MarkPriceKlineCandlestickDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
        };

        var response = await client.MarkPriceKlineCandlestickDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/markPriceKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
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
            Symbol = "BTCUSD",
            Interval = MarkPriceKlineCandlestickDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarkPriceKlineCandlestickDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OldTradesLookupAsync()
    {
        const string example = """""[{"id":595103,"price":"9642.2","qty":"1","baseQty":"0.01037108","time":1499865549590,"isBuyerMaker":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OldTradesLookupRequest
        {
            Symbol = "symbol_example",
        };

        var response = await client.OldTradesLookupAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/historicalTrades", seen.Path);
        Assert.Equal("symbol_example", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OldTradesLookupWithOptionalParametersAsync()
    {
        const string example = """""[{"id":595103,"price":"9642.2","qty":"1","baseQty":"0.01037108","time":1499865549590,"isBuyerMaker":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OldTradesLookupRequest
        {
            Symbol = "symbol_example",
            Limit = 30L,
            FromId = 595103L,
        };

        var response = await client.OldTradesLookupAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/historicalTrades", seen.Path);
        Assert.Equal("symbol_example", seen.Param("symbol"));
        Assert.Equal("30", seen.Param("limit"));
        Assert.Equal("595103", seen.Param("fromId"));
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
            Symbol = "symbol_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OldTradesLookupAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenInterestAsync()
    {
        const string example = """""{"symbol":"BTCUSD_200626","pair":"BTCUSD","openInterest":"15004","contractType":"CURRENT_QUARTER","time":1591261042378}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenInterestRequest
        {
            Symbol = "BTCUSD_200626",
        };

        var response = await client.OpenInterestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/openInterest", seen.Path);
        Assert.Equal("BTCUSD_200626", seen.Param("symbol"));
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
            Symbol = "BTCUSD_200626",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OpenInterestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenInterestStatisticsAsync()
    {
        const string example = """""[{"pair":"BTCUSD","contractType":"CURRENT_QUARTER","sumOpenInterest":"20403","sumOpenInterestValue":"176196512.23400000","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenInterestStatisticsRequest
        {
            Pair = "BTCUSD",
            Period = OpenInterestStatisticsPeriod.Period5m,
        };

        var response = await client.OpenInterestStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/openInterestHist", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OpenInterestStatisticsWithOptionalParametersAsync()
    {
        const string example = """""[{"pair":"BTCUSD","contractType":"CURRENT_QUARTER","sumOpenInterest":"20403","sumOpenInterestValue":"176196512.23400000","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenInterestStatisticsRequest
        {
            Pair = "BTCUSD",
            Period = OpenInterestStatisticsPeriod.Period5m,
            ContractType = OpenInterestStatisticsContractType.Perpetual,
            Limit = 30L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.OpenInterestStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/openInterestHist", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("30", seen.Param("limit"));
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
            Pair = "BTCUSD",
            Period = OpenInterestStatisticsPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OpenInterestStatisticsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderBookAsync()
    {
        const string example = """""{"lastUpdateId":16769853,"symbol":"BTCUSD_PERP","pair":"BTCUSD","E":1591250106370,"T":1591250106368,"bids":[["9638.00000000","431.00000000"]],"asks":[["9638.20000000","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderBookRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var response = await client.OrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/depth", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderBookWithOptionalParametersAsync()
    {
        const string example = """""{"lastUpdateId":16769853,"symbol":"BTCUSD_PERP","pair":"BTCUSD","E":1591250106370,"T":1591250106368,"bids":[["9638.00000000","431.00000000"]],"asks":[["9638.20000000","12.00000000"]]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderBookRequest
        {
            Symbol = "BTCUSD_PERP",
            Limit = 500L,
        };

        var response = await client.OrderBookAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/depth", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("500", seen.Param("limit"));
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
            Symbol = "BTCUSD_PERP",
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
            Symbol = "BTCUSD",
            Interval = PremiumIndexKlineDataInterval.Interval1m,
        };

        var response = await client.PremiumIndexKlineDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/premiumIndexKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
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
            Symbol = "BTCUSD",
            Interval = PremiumIndexKlineDataInterval.Interval1m,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
        };

        var response = await client.PremiumIndexKlineDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/premiumIndexKlines", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Equal("1m", seen.Param("interval"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
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
            Symbol = "BTCUSD",
            Interval = PremiumIndexKlineDataInterval.Interval1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PremiumIndexKlineDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryIndexPriceConstituentsAsync()
    {
        const string example = """""{"symbol":"BTCUSD","time":1697422647853,"constituents":[{"exchange":"bitstamp","symbol":"btcusd","price":"94057.03000000","weight":"0.25000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryIndexPriceConstituentsRequest
        {
            Symbol = "BTCUSD",
        };

        var response = await client.QueryIndexPriceConstituentsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/constituents", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
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
            Symbol = "BTCUSD",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryIndexPriceConstituentsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RecentTradesListAsync()
    {
        const string example = """""[{"id":28457,"price":"9635.0","qty":"1","baseQty":"0.01037883","time":1591250192508,"isBuyerMaker":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RecentTradesListRequest
        {
            Symbol = "BTCUSD",
        };

        var response = await client.RecentTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/trades", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RecentTradesListWithOptionalParametersAsync()
    {
        const string example = """""[{"id":28457,"price":"9635.0","qty":"1","baseQty":"0.01037883","time":1591250192508,"isBuyerMaker":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RecentTradesListRequest
        {
            Symbol = "BTCUSD",
            Limit = 30L,
        };

        var response = await client.RecentTradesListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/trades", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Equal("30", seen.Param("limit"));
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
            Symbol = "BTCUSD",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RecentTradesListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SymbolOrderBookTickerAsync()
    {
        const string example = """""[{"lastUpdateId":1027024,"symbol":"BTCUSD_200626","pair":"BTCUSD","bidPrice":"9650.1","bidQty":"16","askPrice":"9650.3","askQty":"7","time":1591257300345}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SymbolOrderBookTickerAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/ticker/bookTicker", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolOrderBookTickerWithOptionalParametersAsync()
    {
        const string example = """""[{"lastUpdateId":1027024,"symbol":"BTCUSD_200626","pair":"BTCUSD","bidPrice":"9650.1","bidQty":"16","askPrice":"9650.3","askQty":"7","time":1591257300345}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SymbolOrderBookTickerRequest
        {
            Symbol = "BTCUSD_200626",
            Pair = "BTCUSD",
        };

        var response = await client.SymbolOrderBookTickerAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/ticker/bookTicker", seen.Path);
        Assert.Equal("BTCUSD_200626", seen.Param("symbol"));
        Assert.Equal("BTCUSD", seen.Param("pair"));
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

    [Fact]
    public async Task SymbolPriceTickerAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_200626","ps":"BTCUSD","price":"9647.8","time":1591257246176}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SymbolPriceTickerAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/ticker/price", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolPriceTickerWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_200626","ps":"BTCUSD","price":"9647.8","time":1591257246176}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SymbolPriceTickerRequest
        {
            Symbol = "BTCUSD_200626",
            Pair = "BTCUSD",
        };

        var response = await client.SymbolPriceTickerAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/ticker/price", seen.Path);
        Assert.Equal("BTCUSD_200626", seen.Param("symbol"));
        Assert.Equal("BTCUSD", seen.Param("pair"));
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

    [Fact]
    public async Task TakerBuySellVolumeAsync()
    {
        const string example = """""[{"pair":"BTCUSD","contractType":"CURRENT_QUARTER","takerBuyVol":"387","takerSellVol":"248","takerBuyVolValue":"2342.1220","takerSellVolValue":"4213.9800","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TakerBuySellVolumeRequest
        {
            Pair = "BTCUSD",
            ContractType = TakerBuySellVolumeContractType.All,
            Period = TakerBuySellVolumePeriod.Period5m,
        };

        var response = await client.TakerBuySellVolumeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/takerBuySellVol", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("ALL", seen.Param("contractType"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TakerBuySellVolumeWithOptionalParametersAsync()
    {
        const string example = """""[{"pair":"BTCUSD","contractType":"CURRENT_QUARTER","takerBuyVol":"387","takerSellVol":"248","takerBuyVolValue":"2342.1220","takerSellVolValue":"4213.9800","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TakerBuySellVolumeRequest
        {
            Pair = "BTCUSD",
            ContractType = TakerBuySellVolumeContractType.All,
            Period = TakerBuySellVolumePeriod.Period5m,
            Limit = 30L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.TakerBuySellVolumeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/takerBuySellVol", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("ALL", seen.Param("contractType"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("30", seen.Param("limit"));
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
            Pair = "BTCUSD",
            ContractType = TakerBuySellVolumeContractType.All,
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
        Assert.Equal("/dapi/v1/ping", seen.Path);
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
        const string example = """""[{"symbol":"BTCUSD_200925","pair":"BTCUSD","priceChange":"136.6","priceChangePercent":"1.436","weightedAvgPrice":"9547.3","lastPrice":"9651.6","lastQty":"1","openPrice":"9515.0","highPrice":"9687.0","lowPrice":"9499.5","volume":"494109","baseVolume":"5192.94797687","openTime":1591170300000,"closeTime":1591256718418,"firstId":600507,"lastId":697803,"count":97297}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.Ticker24hrPriceChangeStatisticsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/ticker/24hr", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task Ticker24hrPriceChangeStatisticsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_200925","pair":"BTCUSD","priceChange":"136.6","priceChangePercent":"1.436","weightedAvgPrice":"9547.3","lastPrice":"9651.6","lastQty":"1","openPrice":"9515.0","highPrice":"9687.0","lowPrice":"9499.5","volume":"494109","baseVolume":"5192.94797687","openTime":1591170300000,"closeTime":1591256718418,"firstId":600507,"lastId":697803,"count":97297}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new Ticker24hrPriceChangeStatisticsRequest
        {
            Symbol = "BTCUSD_200925",
            Pair = "BTCUSD",
        };

        var response = await client.Ticker24hrPriceChangeStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/ticker/24hr", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("BTCUSD", seen.Param("pair"));
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
        const string example = """""[{"pair":"BTCUSD","longShortRatio":"1.8105","longAccount":"0.6442","shortAccount":"0.3558","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioAccountsRequest
        {
            Pair = "BTCUSD",
            Period = TopTraderLongShortRatioAccountsPeriod.Period5m,
        };

        var response = await client.TopTraderLongShortRatioAccountsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortAccountRatio", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TopTraderLongShortRatioAccountsWithOptionalParametersAsync()
    {
        const string example = """""[{"pair":"BTCUSD","longShortRatio":"1.8105","longAccount":"0.6442","shortAccount":"0.3558","timestamp":1591261042378}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioAccountsRequest
        {
            Pair = "BTCUSD",
            Period = TopTraderLongShortRatioAccountsPeriod.Period5m,
            ContractType = TopTraderLongShortRatioAccountsContractType.Perpetual,
            Limit = 30L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.TopTraderLongShortRatioAccountsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortAccountRatio", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("30", seen.Param("limit"));
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
            Pair = "BTCUSD",
            Period = TopTraderLongShortRatioAccountsPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TopTraderLongShortRatioAccountsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TopTraderLongShortRatioPositionsAsync()
    {
        const string example = """""[{"pair":"BTCUSD","longShortRatio":"0.7869","longPosition":"0.6442","shortPosition":"0.4404","timestamp":1592870400000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioPositionsRequest
        {
            Pair = "BTCUSD",
            Period = TopTraderLongShortRatioPositionsPeriod.Period5m,
        };

        var response = await client.TopTraderLongShortRatioPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortPositionRatio", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TopTraderLongShortRatioPositionsWithOptionalParametersAsync()
    {
        const string example = """""[{"pair":"BTCUSD","longShortRatio":"0.7869","longPosition":"0.6442","shortPosition":"0.4404","timestamp":1592870400000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TopTraderLongShortRatioPositionsRequest
        {
            Pair = "BTCUSD",
            Period = TopTraderLongShortRatioPositionsPeriod.Period5m,
            ContractType = TopTraderLongShortRatioPositionsContractType.Perpetual,
            Limit = 30L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.TopTraderLongShortRatioPositionsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/futures/data/topLongShortPositionRatio", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5m", seen.Param("period"));
        Assert.Equal("PERPETUAL", seen.Param("contractType"));
        Assert.Equal("30", seen.Param("limit"));
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
            Pair = "BTCUSD",
            Period = TopTraderLongShortRatioPositionsPeriod.Period5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TopTraderLongShortRatioPositionsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
