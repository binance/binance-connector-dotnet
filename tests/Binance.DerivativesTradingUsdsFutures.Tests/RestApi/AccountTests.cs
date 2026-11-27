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

namespace Binance.DerivativesTradingUsdsFutures.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static DerivativesTradingUsdsFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountInformationV2Async()
    {
        const string example = """""{"feeTier":0,"feeBurn":true,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"multiAssetsMargin":true,"tradeGroupId":-1,"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","isolated":true,"entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountInformationV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationV2WithOptionalParametersAsync()
    {
        const string example = """""{"feeTier":0,"feeBurn":true,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"multiAssetsMargin":true,"tradeGroupId":-1,"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","isolated":true,"entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountInformationV2Request
        {
            RecvWindow = 5000L,
        };

        var response = await client.AccountInformationV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountInformationV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountInformationV3Async()
    {
        const string example = """""{"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","positionSide":"BOTH","positionAmt":"1.000","unrealizedProfit":"0.00000000","isolatedMargin":"0.00000000","notional":"0","isolatedWallet":"0","initialMargin":"0","maintMargin":"0","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountInformationV3Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v3/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationV3WithOptionalParametersAsync()
    {
        const string example = """""{"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","positionSide":"BOTH","positionAmt":"1.000","unrealizedProfit":"0.00000000","isolatedMargin":"0.00000000","notional":"0","isolatedWallet":"0","initialMargin":"0","maintMargin":"0","updateTime":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountInformationV3Request
        {
            RecvWindow = 5000L,
        };

        var response = await client.AccountInformationV3Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v3/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationV3BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountInformationV3Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesAccountBalanceV2Async()
    {
        const string example = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FuturesAccountBalanceV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/balance", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceV2WithOptionalParametersAsync()
    {
        const string example = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesAccountBalanceV2Request
        {
            RecvWindow = 5000L,
        };

        var response = await client.FuturesAccountBalanceV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/balance", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FuturesAccountBalanceV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesAccountBalanceV3Async()
    {
        const string example = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FuturesAccountBalanceV3Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v3/balance", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceV3WithOptionalParametersAsync()
    {
        const string example = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesAccountBalanceV3Request
        {
            RecvWindow = 5000L,
        };

        var response = await client.FuturesAccountBalanceV3Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v3/balance", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceV3BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FuturesAccountBalanceV3Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesAccountConfigurationAsync()
    {
        const string example = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"dualSidePosition":true,"updateTime":0,"multiAssetsMargin":false,"tradeGroupId":-1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FuturesAccountConfigurationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/accountConfig", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountConfigurationWithOptionalParametersAsync()
    {
        const string example = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"dualSidePosition":true,"updateTime":0,"multiAssetsMargin":false,"tradeGroupId":-1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesAccountConfigurationRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.FuturesAccountConfigurationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/accountConfig", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountConfigurationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FuturesAccountConfigurationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesTradingQuantitativeRulesIndicatorsAsync()
    {
        const string example = """""{"indicators":{"BTCUSDT":[{"isLocked":true,"plannedRecoverTime":1545741270000,"indicator":"UFR","value":0.05,"triggerValue":0.995}],"ETHUSDT":[{"isLocked":true,"plannedRecoverTime":1545741270000,"indicator":"UFR","value":0.05,"triggerValue":0.995}],"ACCOUNT":[{"indicator":"TMV","value":10,"triggerValue":1,"plannedRecoverTime":1644919865000,"isLocked":true}]},"updateTime":1644913304748}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FuturesTradingQuantitativeRulesIndicatorsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/apiTradingStatus", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesTradingQuantitativeRulesIndicatorsWithOptionalParametersAsync()
    {
        const string example = """""{"indicators":{"BTCUSDT":[{"isLocked":true,"plannedRecoverTime":1545741270000,"indicator":"UFR","value":0.05,"triggerValue":0.995}],"ETHUSDT":[{"isLocked":true,"plannedRecoverTime":1545741270000,"indicator":"UFR","value":0.05,"triggerValue":0.995}],"ACCOUNT":[{"indicator":"TMV","value":10,"triggerValue":1,"plannedRecoverTime":1644919865000,"isLocked":true}]},"updateTime":1644913304748}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesTradingQuantitativeRulesIndicatorsRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.FuturesTradingQuantitativeRulesIndicatorsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/apiTradingStatus", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesTradingQuantitativeRulesIndicatorsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FuturesTradingQuantitativeRulesIndicatorsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBnbBurnStatusAsync()
    {
        const string example = """""{"feeBurn":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBnbBurnStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/feeBurn", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBnbBurnStatusWithOptionalParametersAsync()
    {
        const string example = """""{"feeBurn":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBnbBurnStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetBnbBurnStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/feeBurn", seen.Path);
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
    public async Task GetCurrentMultiAssetsModeAsync()
    {
        const string example = """""{"multiAssetsMargin":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCurrentMultiAssetsModeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/multiAssetsMargin", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCurrentMultiAssetsModeWithOptionalParametersAsync()
    {
        const string example = """""{"multiAssetsMargin":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCurrentMultiAssetsModeRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetCurrentMultiAssetsModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/multiAssetsMargin", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCurrentMultiAssetsModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCurrentMultiAssetsModeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCurrentPositionModeAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCurrentPositionModeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/positionSide/dual", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCurrentPositionModeWithOptionalParametersAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCurrentPositionModeRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetCurrentPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/positionSide/dual", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCurrentPositionModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCurrentPositionModeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForFuturesOrderHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/order/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/order/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForFuturesOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTradeHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/trade/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/trade/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForFuturesTradeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTransactionHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/income/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTransactionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/income/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTransactionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForFuturesTransactionHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesOrderHistoryDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesOrderHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetFuturesOrderHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesOrderHistoryDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesOrderHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesOrderHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesOrderHistoryDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesOrderHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesOrderHistoryDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesTradeDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"www.binance.com","notified":false,"expirationTimestamp":1645009771000,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTradeDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"www.binance.com","notified":false,"expirationTimestamp":1645009771000,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTradeDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesTradeDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesTransactionHistoryDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"www.binance.com","notified":false,"expirationTimestamp":1645009771000,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTransactionHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetFuturesTransactionHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/income/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTransactionHistoryDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"www.binance.com","notified":false,"expirationTimestamp":1645009771000,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTransactionHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesTransactionHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/income/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTransactionHistoryDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesTransactionHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesTransactionHistoryDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetIncomeHistoryAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"USDT","info":"TRANSFER","time":1570608000000,"tranId":9689322392,"tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetIncomeHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/income", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetIncomeHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"USDT","info":"TRANSFER","time":1570608000000,"tranId":9689322392,"tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetIncomeHistoryRequest
        {
            Symbol = "BTCUSDT",
            IncomeType = GetIncomeHistoryIncomeType.Transfer,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
            RecvWindow = 5000L,
        };

        var response = await client.GetIncomeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/income", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("TRANSFER", seen.Param("incomeType"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetIncomeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetIncomeHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NotionalAndLeverageBracketsAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","notionalCoef":1.5,"brackets":[]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.NotionalAndLeverageBracketsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/leverageBracket", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NotionalAndLeverageBracketsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","notionalCoef":1.5,"brackets":[]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NotionalAndLeverageBracketsRequest
        {
            Symbol = "ETHUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.NotionalAndLeverageBracketsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/leverageBracket", seen.Path);
        Assert.Equal("ETHUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NotionalAndLeverageBracketsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NotionalAndLeverageBracketsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUserRateLimitAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":10000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUserRateLimitAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/rateLimit/order", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserRateLimitWithOptionalParametersAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":10000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUserRateLimitRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryUserRateLimitAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/rateLimit/order", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUserRateLimitBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUserRateLimitAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SymbolConfigurationAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","marginType":"CROSSED","isAutoAddMargin":false,"leverage":21,"maxNotionalValue":"1000000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SymbolConfigurationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/symbolConfig", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolConfigurationWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","marginType":"CROSSED","isAutoAddMargin":false,"leverage":21,"maxNotionalValue":"1000000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SymbolConfigurationRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.SymbolConfigurationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/symbolConfig", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SymbolConfigurationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SymbolConfigurationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ToggleBnbBurnOnFuturesTradeAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ToggleBnbBurnOnFuturesTradeRequest
        {
            FeeBurn = "true",
        };

        var response = await client.ToggleBnbBurnOnFuturesTradeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/feeBurn", seen.Path);
        Assert.Equal("true", seen.Param("feeBurn"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ToggleBnbBurnOnFuturesTradeWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ToggleBnbBurnOnFuturesTradeRequest
        {
            FeeBurn = "true",
            RecvWindow = 5000L,
        };

        var response = await client.ToggleBnbBurnOnFuturesTradeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/feeBurn", seen.Path);
        Assert.Equal("true", seen.Param("feeBurn"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ToggleBnbBurnOnFuturesTradeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ToggleBnbBurnOnFuturesTradeRequest
        {
            FeeBurn = "true",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ToggleBnbBurnOnFuturesTradeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserCommissionRateAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","makerCommissionRate":"0.0002","takerCommissionRate":"0.0004","rpiCommissionRate":"0.00005"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserCommissionRateRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.UserCommissionRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/commissionRate", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserCommissionRateWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","makerCommissionRate":"0.0002","takerCommissionRate":"0.0004","rpiCommissionRate":"0.00005"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserCommissionRateRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.UserCommissionRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/commissionRate", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserCommissionRateBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new UserCommissionRateRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UserCommissionRateAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
