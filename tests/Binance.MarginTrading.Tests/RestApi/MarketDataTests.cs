//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.MarginTrading.RestApi;

namespace Binance.MarginTrading.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static MarginTradingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CrossMarginCollateralRatioAsync()
    {
        const string example = """""[{"collaterals":[{"minUsdValue":"0","maxUsdValue":"13000000","discountRate":"1"}],"assetNames":["BNX"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CrossMarginCollateralRatioAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/crossMarginCollateralRatio", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CrossMarginCollateralRatioBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CrossMarginCollateralRatioAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetAllCrossMarginPairsAsync()
    {
        const string example = """""[{"base":"BNB","id":351637150141315840,"isBuyAllowed":true,"isMarginTrade":true,"isSellAllowed":true,"quote":"BTC","symbol":"BNBBTC","delistTime":1704973040}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetAllCrossMarginPairsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allPairs", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAllCrossMarginPairsWithOptionalParametersAsync()
    {
        const string example = """""[{"base":"BNB","id":351637150141315840,"isBuyAllowed":true,"isMarginTrade":true,"isSellAllowed":true,"quote":"BTC","symbol":"BNBBTC","delistTime":1704973040}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetAllCrossMarginPairsRequest
        {
            Symbol = "BNBBTC",
        };

        var response = await client.GetAllCrossMarginPairsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allPairs", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAllCrossMarginPairsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetAllCrossMarginPairsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetAllIsolatedMarginSymbolAsync()
    {
        const string example = """""[{"base":"BNB","isBuyAllowed":true,"isMarginTrade":true,"isSellAllowed":true,"quote":"BTC","symbol":"BNBBTC"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetAllIsolatedMarginSymbolAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/allPairs", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAllIsolatedMarginSymbolWithOptionalParametersAsync()
    {
        const string example = """""[{"base":"BNB","isBuyAllowed":true,"isMarginTrade":true,"isSellAllowed":true,"quote":"BTC","symbol":"BNBBTC"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetAllIsolatedMarginSymbolRequest
        {
            Symbol = "BNBBTC",
            RecvWindow = 5000L,
        };

        var response = await client.GetAllIsolatedMarginSymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/allPairs", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAllIsolatedMarginSymbolBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetAllIsolatedMarginSymbolAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetAllMarginAssetsAsync()
    {
        const string example = """""[{"assetFullName":"USD coin","assetName":"USDC","isBorrowable":true,"isMortgageable":true,"userMinBorrow":"5.00000000","userMinRepay":"0.00000000","delistTime":1704973040000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetAllMarginAssetsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allAssets", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAllMarginAssetsWithOptionalParametersAsync()
    {
        const string example = """""[{"assetFullName":"USD coin","assetName":"USDC","isBorrowable":true,"isMortgageable":true,"userMinBorrow":"5.00000000","userMinRepay":"0.00000000","delistTime":1704973040000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetAllMarginAssetsRequest
        {
            Asset = "USDC",
        };

        var response = await client.GetAllMarginAssetsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allAssets", seen.Path);
        Assert.Equal("USDC", seen.Param("asset"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAllMarginAssetsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetAllMarginAssetsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDelistScheduleAsync()
    {
        const string example = """""[{"delistTime":1686161202000,"crossMarginAssets":["BTC"],"isolatedMarginSymbols":["ADAUSDT"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetDelistScheduleAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/delist-schedule", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDelistScheduleWithOptionalParametersAsync()
    {
        const string example = """""[{"delistTime":1686161202000,"crossMarginAssets":["BTC"],"isolatedMarginSymbols":["ADAUSDT"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDelistScheduleRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetDelistScheduleAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/delist-schedule", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDelistScheduleBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDelistScheduleAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLimitPricePairsAsync()
    {
        const string example = """""{"crossMarginSymbols":["BLURUSDC"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetLimitPricePairsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/limit-price-pairs", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLimitPricePairsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLimitPricePairsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetListScheduleAsync()
    {
        const string example = """""[{"listTime":1686161202000,"crossMarginAssets":["BTC"],"isolatedMarginSymbols":["ADAUSDT"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetListScheduleAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/list-schedule", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetListScheduleWithOptionalParametersAsync()
    {
        const string example = """""[{"listTime":1686161202000,"crossMarginAssets":["BTC"],"isolatedMarginSymbols":["ADAUSDT"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetListScheduleRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetListScheduleAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/list-schedule", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetListScheduleBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetListScheduleAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetMarginAssetRiskBasedLiquidationRatioAsync()
    {
        const string example = """""[{"asset":"USDC","riskBasedLiquidationRatio":"0.01"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetMarginAssetRiskBasedLiquidationRatioAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/risk-based-liquidation-ratio", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarginAssetRiskBasedLiquidationRatioBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetMarginAssetRiskBasedLiquidationRatioAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetMarginRestrictedAssetsAsync()
    {
        const string example = """""{"openLongRestrictedAsset":["ADA"],"maxCollateralExceededAsset":["ACH"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetMarginRestrictedAssetsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/restricted-asset", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMarginRestrictedAssetsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetMarginRestrictedAssetsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryIsolatedMarginTierDataAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","tier":1,"effectiveMultiple":"10","initialRiskRatio":"1.111","liquidationRiskRatio":"1.05","baseAssetMaxBorrowable":"9","quoteAssetMaxBorrowable":"70000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryIsolatedMarginTierDataRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryIsolatedMarginTierDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolatedMarginTier", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryIsolatedMarginTierDataWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","tier":1,"effectiveMultiple":"10","initialRiskRatio":"1.111","liquidationRiskRatio":"1.05","baseAssetMaxBorrowable":"9","quoteAssetMaxBorrowable":"70000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryIsolatedMarginTierDataRequest
        {
            Symbol = "BTCUSDT",
            Tier = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryIsolatedMarginTierDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolatedMarginTier", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("tier"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryIsolatedMarginTierDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryIsolatedMarginTierDataRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryIsolatedMarginTierDataAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryLiabilityCoinLeverageBracketInCrossMarginProModeAsync()
    {
        const string example = """""[{"assetNames":["SHIB"],"rank":1,"brackets":[{"leverage":10,"maxDebt":1000000,"maintenanceMarginRate":0.02,"initialMarginRate":0.1112,"fastNum":60000}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryLiabilityCoinLeverageBracketInCrossMarginProModeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/leverageBracket", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLiabilityCoinLeverageBracketInCrossMarginProModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryLiabilityCoinLeverageBracketInCrossMarginProModeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAvailableInventoryAsync()
    {
        const string example = """""{"assets":{"MATIC":"200","STPT":"30000","TVK":"10000","SHIB":"4000000"},"updateTime":1699272487}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAvailableInventoryRequest
        {
            Type = QueryMarginAvailableInventoryType.Margin,
        };

        var response = await client.QueryMarginAvailableInventoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/available-inventory", seen.Path);
        Assert.Equal("MARGIN", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAvailableInventoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginAvailableInventoryRequest
        {
            Type = QueryMarginAvailableInventoryType.Margin,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAvailableInventoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginPriceindexAsync()
    {
        const string example = """""{"calcTime":1562046418000,"price":"0.00333930","symbol":"BNBBTC"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginPriceindexRequest
        {
            Symbol = "BNBBTC",
        };

        var response = await client.QueryMarginPriceindexAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/priceIndex", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginPriceindexBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginPriceindexRequest
        {
            Symbol = "BNBBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginPriceindexAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
