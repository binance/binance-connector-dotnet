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

namespace Binance.MarginTrading.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static MarginTradingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AdjustCrossMarginMaxLeverageAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AdjustCrossMarginMaxLeverageRequest
        {
            MaxLeverage = 3L,
        };

        var response = await client.AdjustCrossMarginMaxLeverageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/max-leverage", seen.Path);
        Assert.Equal("3", seen.Param("maxLeverage"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AdjustCrossMarginMaxLeverageBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AdjustCrossMarginMaxLeverageRequest
        {
            MaxLeverage = 3L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AdjustCrossMarginMaxLeverageAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DisableIsolatedMarginAccountAsync()
    {
        const string example = """""{"success":true,"symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DisableIsolatedMarginAccountRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.DisableIsolatedMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/account", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DisableIsolatedMarginAccountWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DisableIsolatedMarginAccountRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.DisableIsolatedMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/account", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DisableIsolatedMarginAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DisableIsolatedMarginAccountRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DisableIsolatedMarginAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EnableIsolatedMarginAccountAsync()
    {
        const string example = """""{"success":true,"symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EnableIsolatedMarginAccountRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.EnableIsolatedMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/account", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EnableIsolatedMarginAccountWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EnableIsolatedMarginAccountRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.EnableIsolatedMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/account", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EnableIsolatedMarginAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new EnableIsolatedMarginAccountRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EnableIsolatedMarginAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBnbBurnStatusAsync()
    {
        const string example = """""{"spotBNBBurn":true,"interestBNBBurn":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBnbBurnStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bnbBurn", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBnbBurnStatusWithOptionalParametersAsync()
    {
        const string example = """""{"spotBNBBurn":true,"interestBNBBurn":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBnbBurnStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetBnbBurnStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bnbBurn", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBnbBurnStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBnbBurnStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSummaryOfMarginAccountAsync()
    {
        const string example = """""{"normalBar":"1.5","marginCallBar":"1.3","forceLiquidationBar":"1.1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSummaryOfMarginAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/tradeCoeff", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfMarginAccountWithOptionalParametersAsync()
    {
        const string example = """""{"normalBar":"1.5","marginCallBar":"1.3","forceLiquidationBar":"1.1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSummaryOfMarginAccountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetSummaryOfMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/tradeCoeff", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfMarginAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSummaryOfMarginAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCrossIsolatedMarginCapitalFlowAsync()
    {
        const string example = """""[{"id":123456,"tranId":123123,"timestamp":1691116657000,"asset":"USDT","symbol":"BTCUSDT","type":"BORROW","amount":"101","note":"INSTITUTIONAL_LOAN_TRANSFER"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCrossIsolatedMarginCapitalFlowAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/capital-flow", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCrossIsolatedMarginCapitalFlowWithOptionalParametersAsync()
    {
        const string example = """""[{"id":123456,"tranId":123123,"timestamp":1691116657000,"asset":"USDT","symbol":"BTCUSDT","type":"BORROW","amount":"101","note":"INSTITUTIONAL_LOAN_TRANSFER"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCrossIsolatedMarginCapitalFlowRequest
        {
            Asset = "USDT",
            Symbol = "BTCUSDT",
            Type = QueryCrossIsolatedMarginCapitalFlowType.Transfer,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            FromId = 1L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryCrossIsolatedMarginCapitalFlowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/capital-flow", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("TRANSFER", seen.Param("type"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCrossIsolatedMarginCapitalFlowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCrossIsolatedMarginCapitalFlowAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCrossMarginAccountDetailsAsync()
    {
        const string example = """""{"created":true,"borrowEnabled":true,"marginLevel":"11.64405625","collateralMarginLevel":"3.2","totalAssetOfBtc":"6.82728457","totalLiabilityOfBtc":"0.58633215","totalNetAssetOfBtc":"6.24095242","TotalCollateralValueInUSDT":"5.82728457","tradeEnabled":true,"transferInEnabled":true,"transferOutEnabled":true,"accountType":"MARGIN_1","userAssets":[{"asset":"BTC","borrowed":"0.00000000","free":"0.00499500","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00499500"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCrossMarginAccountDetailsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCrossMarginAccountDetailsWithOptionalParametersAsync()
    {
        const string example = """""{"created":true,"borrowEnabled":true,"marginLevel":"11.64405625","collateralMarginLevel":"3.2","totalAssetOfBtc":"6.82728457","totalLiabilityOfBtc":"0.58633215","totalNetAssetOfBtc":"6.24095242","TotalCollateralValueInUSDT":"5.82728457","tradeEnabled":true,"transferInEnabled":true,"transferOutEnabled":true,"accountType":"MARGIN_1","userAssets":[{"asset":"BTC","borrowed":"0.00000000","free":"0.00499500","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00499500"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCrossMarginAccountDetailsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryCrossMarginAccountDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCrossMarginAccountDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCrossMarginAccountDetailsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCrossMarginFeeDataAsync()
    {
        const string example = """""[{"vipLevel":0,"coin":"BTC","transferIn":true,"borrowable":true,"dailyInterest":"0.00026125","yearlyInterest":"0.0953","borrowLimit":"180","marginablePairs":["BNBBTC"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCrossMarginFeeDataAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/crossMarginData", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCrossMarginFeeDataWithOptionalParametersAsync()
    {
        const string example = """""[{"vipLevel":0,"coin":"BTC","transferIn":true,"borrowable":true,"dailyInterest":"0.00026125","yearlyInterest":"0.0953","borrowLimit":"180","marginablePairs":["BNBBTC"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCrossMarginFeeDataRequest
        {
            VipLevel = 1L,
            Coin = "BTC",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCrossMarginFeeDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/crossMarginData", seen.Path);
        Assert.Equal("1", seen.Param("vipLevel"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCrossMarginFeeDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCrossMarginFeeDataAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryEnabledIsolatedMarginAccountLimitAsync()
    {
        const string example = """""{"enabledAccount":5,"maxAccount":20}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryEnabledIsolatedMarginAccountLimitAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/accountLimit", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryEnabledIsolatedMarginAccountLimitWithOptionalParametersAsync()
    {
        const string example = """""{"enabledAccount":5,"maxAccount":20}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryEnabledIsolatedMarginAccountLimitRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryEnabledIsolatedMarginAccountLimitAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/accountLimit", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryEnabledIsolatedMarginAccountLimitBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryEnabledIsolatedMarginAccountLimitAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryIsolatedMarginAccountInfoAsync()
    {
        const string example = """""{"assets":[{"baseAsset":{"asset":"BTC","borrowEnabled":true,"borrowed":"0.00000000","free":"0.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00000000","netAssetOfBtc":"0.00000000","repayEnabled":true,"totalAsset":"0.00000000"},"quoteAsset":{"asset":"USDT","borrowEnabled":true,"borrowed":"0.00000000","free":"0.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00000000","netAssetOfBtc":"0.00000000","repayEnabled":true,"totalAsset":"0.00000000"},"symbol":"BTCUSDT","isolatedCreated":true,"enabled":true,"marginLevel":"0.00000000","marginLevelStatus":"EXCESSIVE","marginRatio":"0.00000000","indexPrice":"10000.00000000","liquidatePrice":"1000.00000000","liquidateRate":"1.00000000","tradeEnabled":true}],"totalAssetOfBtc":"0.00000000","totalLiabilityOfBtc":"0.00000000","totalNetAssetOfBtc":"0.00000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryIsolatedMarginAccountInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryIsolatedMarginAccountInfoWithOptionalParametersAsync()
    {
        const string example = """""{"assets":[{"baseAsset":{"asset":"BTC","borrowEnabled":true,"borrowed":"0.00000000","free":"0.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00000000","netAssetOfBtc":"0.00000000","repayEnabled":true,"totalAsset":"0.00000000"},"quoteAsset":{"asset":"USDT","borrowEnabled":true,"borrowed":"0.00000000","free":"0.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00000000","netAssetOfBtc":"0.00000000","repayEnabled":true,"totalAsset":"0.00000000"},"symbol":"BTCUSDT","isolatedCreated":true,"enabled":true,"marginLevel":"0.00000000","marginLevelStatus":"EXCESSIVE","marginRatio":"0.00000000","indexPrice":"10000.00000000","liquidatePrice":"1000.00000000","liquidateRate":"1.00000000","tradeEnabled":true}],"totalAssetOfBtc":"0.00000000","totalLiabilityOfBtc":"0.00000000","totalNetAssetOfBtc":"0.00000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryIsolatedMarginAccountInfoRequest
        {
            Symbols = "BTCUSDT,BNBUSDT,ADAUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryIsolatedMarginAccountInfoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolated/account", seen.Path);
        Assert.Equal("BTCUSDT,BNBUSDT,ADAUSDT", seen.Param("symbols"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryIsolatedMarginAccountInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryIsolatedMarginAccountInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryIsolatedMarginFeeDataAsync()
    {
        const string example = """""[{"vipLevel":0,"symbol":"BTCUSDT","leverage":"10","data":[{"coin":"BTC","dailyInterest":"0.00026125","borrowLimit":"270"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryIsolatedMarginFeeDataAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolatedMarginData", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryIsolatedMarginFeeDataWithOptionalParametersAsync()
    {
        const string example = """""[{"vipLevel":0,"symbol":"BTCUSDT","leverage":"10","data":[{"coin":"BTC","dailyInterest":"0.00026125","borrowLimit":"270"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryIsolatedMarginFeeDataRequest
        {
            VipLevel = 1L,
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryIsolatedMarginFeeDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/isolatedMarginData", seen.Path);
        Assert.Equal("1", seen.Param("vipLevel"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryIsolatedMarginFeeDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryIsolatedMarginFeeDataAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
