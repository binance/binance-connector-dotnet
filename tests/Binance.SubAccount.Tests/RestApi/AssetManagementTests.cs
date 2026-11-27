//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.SubAccount.RestApi;

namespace Binance.SubAccount.Tests.RestApi.AssetManagement;

[Trait("Category", "Native")]
public class AssetManagementApiTests
{
    private static SubAccountRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task FuturesTransferForSubAccountAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesTransferForSubAccountRequest
        {
            Email = "123@test.com",
            Asset = "USDT",
            Amount = 1.0m,
            Type = 1L,
        };

        var response = await client.FuturesTransferForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/transfer", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesTransferForSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesTransferForSubAccountRequest
        {
            Email = "123@test.com",
            Asset = "USDT",
            Amount = 1.0m,
            Type = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.FuturesTransferForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/transfer", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesTransferForSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FuturesTransferForSubAccountRequest
        {
            Email = "123@test.com",
            Asset = "USDT",
            Amount = 1.0m,
            Type = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FuturesTransferForSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDetailOnSubAccountsFuturesAccountAsync()
    {
        const string example = """""{"email":"abc@test.com","asset":"USDT","assets":[{"asset":"USDT","initialMargin":"0.00000000","maintenanceMargin":"0.00000000","marginBalance":"0.88308000","maxWithdrawAmount":"0.88308000","openOrderInitialMargin":"0.00000000","positionInitialMargin":"0.00000000","unrealizedProfit":"0.00000000","walletBalance":"0.88308000"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"maxWithdrawAmount":"0.88308000","totalInitialMargin":"0.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"0.88308000","totalOpenOrderInitialMargin":"0.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"0.88308000","updateTime":1576756674610}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsFuturesAccountRequest
        {
            Email = "123@test.com",
        };

        var response = await client.GetDetailOnSubAccountsFuturesAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/account", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDetailOnSubAccountsFuturesAccountWithOptionalParametersAsync()
    {
        const string example = """""{"email":"abc@test.com","asset":"USDT","assets":[{"asset":"USDT","initialMargin":"0.00000000","maintenanceMargin":"0.00000000","marginBalance":"0.88308000","maxWithdrawAmount":"0.88308000","openOrderInitialMargin":"0.00000000","positionInitialMargin":"0.00000000","unrealizedProfit":"0.00000000","walletBalance":"0.88308000"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"maxWithdrawAmount":"0.88308000","totalInitialMargin":"0.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"0.88308000","totalOpenOrderInitialMargin":"0.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"0.88308000","updateTime":1576756674610}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsFuturesAccountRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.GetDetailOnSubAccountsFuturesAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/account", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDetailOnSubAccountsFuturesAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsFuturesAccountRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDetailOnSubAccountsFuturesAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDetailOnSubAccountsFuturesAccountV2Async()
    {
        const string example = """""{"futureAccountResp":{"email":"abc@test.com","assets":[{"asset":"USDT","initialMargin":"0.00000000","maintenanceMargin":"0.00000000","marginBalance":"0.88308000","maxWithdrawAmount":"0.88308000","openOrderInitialMargin":"0.00000000","positionInitialMargin":"0.00000000","unrealizedProfit":"0.00000000","walletBalance":"0.88308000"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"maxWithdrawAmount":"0.88308000","totalInitialMargin":"0.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"0.88308000","totalOpenOrderInitialMargin":"0.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"0.88308000","updateTime":1576756674610},"deliveryAccountResp":{"email":"abc@test.com","assets":[{"asset":"BTC","initialMargin":"0.00000000","maintenanceMargin":"0.00000000","marginBalance":"0.88308000","maxWithdrawAmount":"0.88308000","openOrderInitialMargin":"0.00000000","positionInitialMargin":"0.00000000","unrealizedProfit":"0.00000000","walletBalance":"0.88308000"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"updateTime":1598959682001}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsFuturesAccountV2Request
        {
            Email = "123@test.com",
            FuturesType = 1L,
        };

        var response = await client.GetDetailOnSubAccountsFuturesAccountV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/futures/account", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDetailOnSubAccountsFuturesAccountV2WithOptionalParametersAsync()
    {
        const string example = """""{"futureAccountResp":{"email":"abc@test.com","assets":[{"asset":"USDT","initialMargin":"0.00000000","maintenanceMargin":"0.00000000","marginBalance":"0.88308000","maxWithdrawAmount":"0.88308000","openOrderInitialMargin":"0.00000000","positionInitialMargin":"0.00000000","unrealizedProfit":"0.00000000","walletBalance":"0.88308000"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"maxWithdrawAmount":"0.88308000","totalInitialMargin":"0.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"0.88308000","totalOpenOrderInitialMargin":"0.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"0.88308000","updateTime":1576756674610},"deliveryAccountResp":{"email":"abc@test.com","assets":[{"asset":"BTC","initialMargin":"0.00000000","maintenanceMargin":"0.00000000","marginBalance":"0.88308000","maxWithdrawAmount":"0.88308000","openOrderInitialMargin":"0.00000000","positionInitialMargin":"0.00000000","unrealizedProfit":"0.00000000","walletBalance":"0.88308000"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"updateTime":1598959682001}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsFuturesAccountV2Request
        {
            Email = "123@test.com",
            FuturesType = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDetailOnSubAccountsFuturesAccountV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/futures/account", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDetailOnSubAccountsFuturesAccountV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsFuturesAccountV2Request
        {
            Email = "123@test.com",
            FuturesType = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDetailOnSubAccountsFuturesAccountV2Async(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDetailOnSubAccountsMarginAccountAsync()
    {
        const string example = """""{"email":"123@test.com","marginLevel":"11.64405625","totalAssetOfBtc":"6.82728457","totalLiabilityOfBtc":"0.58633215","totalNetAssetOfBtc":"6.24095242","marginTradeCoeffVo":{"forceLiquidationBar":"1.10000000","marginCallBar":"1.50000000","normalBar":"2.00000000"},"marginUserAssetVoList":[{"asset":"BTC","borrowed":"0.00000000","free":"0.00499500","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00499500"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsMarginAccountRequest
        {
            Email = "123@test.com",
        };

        var response = await client.GetDetailOnSubAccountsMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/margin/account", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDetailOnSubAccountsMarginAccountWithOptionalParametersAsync()
    {
        const string example = """""{"email":"123@test.com","marginLevel":"11.64405625","totalAssetOfBtc":"6.82728457","totalLiabilityOfBtc":"0.58633215","totalNetAssetOfBtc":"6.24095242","marginTradeCoeffVo":{"forceLiquidationBar":"1.10000000","marginCallBar":"1.50000000","normalBar":"2.00000000"},"marginUserAssetVoList":[{"asset":"BTC","borrowed":"0.00000000","free":"0.00499500","interest":"0.00000000","locked":"0.00000000","netAsset":"0.00499500"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsMarginAccountRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.GetDetailOnSubAccountsMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/margin/account", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDetailOnSubAccountsMarginAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDetailOnSubAccountsMarginAccountRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDetailOnSubAccountsMarginAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetMovePositionHistoryForSubAccountAsync()
    {
        const string example = """""{"total":3,"futureMovePositionOrderVoList":[{"fromUserEmail":"testFrom@google.com","toUserEmail":"testTo@google.com","productType":"UM","symbol":"BTCUSDT","price":"105025.50981609","quantity":"0.00100000","positionSide":"BOTH","side":"SELL","timeStamp":1737544712000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetMovePositionHistoryForSubAccountRequest
        {
            Symbol = "BTCUSDT",
            Page = 1L,
            Rows = 1L,
        };

        var response = await client.GetMovePositionHistoryForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/move-position", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("1", seen.Param("rows"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetMovePositionHistoryForSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"total":3,"futureMovePositionOrderVoList":[{"fromUserEmail":"testFrom@google.com","toUserEmail":"testTo@google.com","productType":"UM","symbol":"BTCUSDT","price":"105025.50981609","quantity":"0.00100000","positionSide":"BOTH","side":"SELL","timeStamp":1737544712000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetMovePositionHistoryForSubAccountRequest
        {
            Symbol = "BTCUSDT",
            Page = 1L,
            Rows = 1L,
            ProductType = GetMovePositionHistoryForSubAccountProductType.Um,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetMovePositionHistoryForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/move-position", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("1", seen.Param("rows"));
        Assert.Equal("UM", seen.Param("productType"));
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
    public async Task GetMovePositionHistoryForSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetMovePositionHistoryForSubAccountRequest
        {
            Symbol = "BTCUSDT",
            Page = 1L,
            Rows = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetMovePositionHistoryForSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSubAccountDepositAddressAsync()
    {
        const string example = """""{"address":"TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV","coin":"USDT","tag":"","url":"https://tronscan.org/#/address/TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSubAccountDepositAddressRequest
        {
            Email = "123@test.com",
            Coin = "BTC",
        };

        var response = await client.GetSubAccountDepositAddressAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/subAddress", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSubAccountDepositAddressWithOptionalParametersAsync()
    {
        const string example = """""{"address":"TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV","coin":"USDT","tag":"","url":"https://tronscan.org/#/address/TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSubAccountDepositAddressRequest
        {
            Email = "123@test.com",
            Coin = "BTC",
            Network = "network_example",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.GetSubAccountDepositAddressAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/subAddress", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("network_example", seen.Param("network"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSubAccountDepositAddressBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetSubAccountDepositAddressRequest
        {
            Email = "123@test.com",
            Coin = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSubAccountDepositAddressAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSubAccountDepositHistoryAsync()
    {
        const string example = """""[{"id":"769800519366885376","amount":"0.001","coin":"BNB","network":"BNB","status":0,"address":"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23","addressTag":"101764890","txId":"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC","insertTime":1661493146000,"transferType":0,"confirmTimes":"1/1","unlockConfirm":0,"walletType":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSubAccountDepositHistoryRequest
        {
            Email = "123@test.com",
        };

        var response = await client.GetSubAccountDepositHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/subHisrec", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSubAccountDepositHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"id":"769800519366885376","amount":"0.001","coin":"BNB","network":"BNB","status":0,"address":"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23","addressTag":"101764890","txId":"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC","insertTime":1661493146000,"transferType":0,"confirmTimes":"1/1","unlockConfirm":0,"walletType":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSubAccountDepositHistoryRequest
        {
            Email = "123@test.com",
            IncludeSource = false,
            Coin = "BTC",
            Status = 0L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 1L,
            Offset = 0L,
            RecvWindow = 5000L,
            TxId = "1",
        };

        var response = await client.GetSubAccountDepositHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/capital/deposit/subHisrec", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("false", seen.Param("includeSource"));
        Assert.Equal("BTC", seen.Param("coin"));
        Assert.Equal("0", seen.Param("status"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("0", seen.Param("offset"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSubAccountDepositHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetSubAccountDepositHistoryRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSubAccountDepositHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsFuturesAccountAsync()
    {
        const string example = """""{"totalInitialMargin":"9.83137400","totalMaintenanceMargin":"0.41568700","totalMarginBalance":"23.03235621","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.83137400","totalUnrealizedProfit":"0.03219710","totalWalletBalance":"22.15879444","asset":"USD","subAccountList":[{"email":"123@test.com","totalInitialMargin":"9.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"22.12659734","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"22.12659734","asset":"USD"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSummaryOfSubAccountsFuturesAccountRequest
        {
            Page = 1L,
            Limit = 1L,
        };

        var response = await client.GetSummaryOfSubAccountsFuturesAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/accountSummary", seen.Path);
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsFuturesAccountWithOptionalParametersAsync()
    {
        const string example = """""{"totalInitialMargin":"9.83137400","totalMaintenanceMargin":"0.41568700","totalMarginBalance":"23.03235621","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.83137400","totalUnrealizedProfit":"0.03219710","totalWalletBalance":"22.15879444","asset":"USD","subAccountList":[{"email":"123@test.com","totalInitialMargin":"9.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"22.12659734","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"22.12659734","asset":"USD"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSummaryOfSubAccountsFuturesAccountRequest
        {
            Page = 1L,
            Limit = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSummaryOfSubAccountsFuturesAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/accountSummary", seen.Path);
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsFuturesAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetSummaryOfSubAccountsFuturesAccountRequest
        {
            Page = 1L,
            Limit = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSummaryOfSubAccountsFuturesAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsFuturesAccountV2Async()
    {
        const string example = """""{"futureAccountSummaryResp":{"totalInitialMargin":"9.83137400","totalMaintenanceMargin":"0.41568700","totalMarginBalance":"23.03235621","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.83137400","totalUnrealizedProfit":"0.03219710","totalWalletBalance":"22.15879444","asset":"USD","subAccountList":[{"email":"123@test.com","totalInitialMargin":"9.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"22.12659734","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"22.12659734","asset":"USD"}]},"deliveryAccountSummaryResp":{"totalMarginBalanceOfBTC":"25.03221121","totalUnrealizedProfitOfBTC":"0.12233410","totalWalletBalanceOfBTC":"22.15879444","asset":"BTC","subAccountList":[{"email":"123@test.com","totalMarginBalance":"22.12659734","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"22.12659734","asset":"BTC"}]}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSummaryOfSubAccountsFuturesAccountV2Request
        {
            FuturesType = 1L,
        };

        var response = await client.GetSummaryOfSubAccountsFuturesAccountV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/futures/accountSummary", seen.Path);
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsFuturesAccountV2WithOptionalParametersAsync()
    {
        const string example = """""{"futureAccountSummaryResp":{"totalInitialMargin":"9.83137400","totalMaintenanceMargin":"0.41568700","totalMarginBalance":"23.03235621","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.83137400","totalUnrealizedProfit":"0.03219710","totalWalletBalance":"22.15879444","asset":"USD","subAccountList":[{"email":"123@test.com","totalInitialMargin":"9.00000000","totalMaintenanceMargin":"0.00000000","totalMarginBalance":"22.12659734","totalOpenOrderInitialMargin":"9.00000000","totalPositionInitialMargin":"0.00000000","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"22.12659734","asset":"USD"}]},"deliveryAccountSummaryResp":{"totalMarginBalanceOfBTC":"25.03221121","totalUnrealizedProfitOfBTC":"0.12233410","totalWalletBalanceOfBTC":"22.15879444","asset":"BTC","subAccountList":[{"email":"123@test.com","totalMarginBalance":"22.12659734","totalUnrealizedProfit":"0.00000000","totalWalletBalance":"22.12659734","asset":"BTC"}]}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSummaryOfSubAccountsFuturesAccountV2Request
        {
            FuturesType = 1L,
            Page = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSummaryOfSubAccountsFuturesAccountV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/futures/accountSummary", seen.Path);
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsFuturesAccountV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetSummaryOfSubAccountsFuturesAccountV2Request
        {
            FuturesType = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSummaryOfSubAccountsFuturesAccountV2Async(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsMarginAccountAsync()
    {
        const string example = """""{"totalAssetOfBtc":"4.33333333","totalLiabilityOfBtc":"2.11111112","totalNetAssetOfBtc":"2.22222221","subAccountList":[{"email":"123@test.com","totalAssetOfBtc":"2.11111111","totalLiabilityOfBtc":"1.11111111","totalNetAssetOfBtc":"1.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSummaryOfSubAccountsMarginAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/margin/accountSummary", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsMarginAccountWithOptionalParametersAsync()
    {
        const string example = """""{"totalAssetOfBtc":"4.33333333","totalLiabilityOfBtc":"2.11111112","totalNetAssetOfBtc":"2.22222221","subAccountList":[{"email":"123@test.com","totalAssetOfBtc":"2.11111111","totalLiabilityOfBtc":"1.11111111","totalNetAssetOfBtc":"1.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSummaryOfSubAccountsMarginAccountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetSummaryOfSubAccountsMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/margin/accountSummary", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSummaryOfSubAccountsMarginAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSummaryOfSubAccountsMarginAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginTransferForSubAccountAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginTransferForSubAccountRequest
        {
            Email = "123@test.com",
            Asset = "BTC",
            Amount = 1.0m,
            Type = 1L,
        };

        var response = await client.MarginTransferForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/margin/transfer", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginTransferForSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginTransferForSubAccountRequest
        {
            Email = "123@test.com",
            Asset = "BTC",
            Amount = 1.0m,
            Type = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.MarginTransferForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/margin/transfer", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginTransferForSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginTransferForSubAccountRequest
        {
            Email = "123@test.com",
            Asset = "BTC",
            Amount = 1.0m,
            Type = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginTransferForSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MovePositionForSubAccountAsync()
    {
        const string example = """""{"movePositionOrders":[{"fromUserEmail":"testFrom@google.com","toUserEmail":"testTo@google.com","productType":"UM","symbol":"BTCUSDT","priceType":"MARK_PRICE","price":"97139.00000000","quantity":"0.001","positionSide":"BOTH","side":"BUY","success":true}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MovePositionForSubAccountRequest
        {
            FromUserEmail = "testFrom@google.com",
            ToUserEmail = "testTo@google.com",
            ProductType = MovePositionForSubAccountProductType.Um,
            OrderArgs = new() { },
        };

        var response = await client.MovePositionForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/move-position", seen.Path);
        Assert.Equal("testFrom@google.com", seen.Param("fromUserEmail"));
        Assert.Equal("testTo@google.com", seen.Param("toUserEmail"));
        Assert.Equal("UM", seen.Param("productType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MovePositionForSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"movePositionOrders":[{"fromUserEmail":"testFrom@google.com","toUserEmail":"testTo@google.com","productType":"UM","symbol":"BTCUSDT","priceType":"MARK_PRICE","price":"97139.00000000","quantity":"0.001","positionSide":"BOTH","side":"BUY","success":true}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MovePositionForSubAccountRequest
        {
            FromUserEmail = "testFrom@google.com",
            ToUserEmail = "testTo@google.com",
            ProductType = MovePositionForSubAccountProductType.Um,
            OrderArgs = new() { },
            RecvWindow = 5000L,
        };

        var response = await client.MovePositionForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/move-position", seen.Path);
        Assert.Equal("testFrom@google.com", seen.Param("fromUserEmail"));
        Assert.Equal("testTo@google.com", seen.Param("toUserEmail"));
        Assert.Equal("UM", seen.Param("productType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MovePositionForSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MovePositionForSubAccountRequest
        {
            FromUserEmail = "testFrom@google.com",
            ToUserEmail = "testTo@google.com",
            ProductType = MovePositionForSubAccountProductType.Um,
            OrderArgs = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MovePositionForSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountAssetsAsync()
    {
        const string example = """""{"balances":[{"freeze":0,"withdrawing":0,"asset":"ADA","free":11467.6399,"locked":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountAssetsRequest
        {
            Email = "123@test.com",
        };

        var response = await client.QuerySubAccountAssetsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v3/sub-account/assets", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountAssetsWithOptionalParametersAsync()
    {
        const string example = """""{"balances":[{"freeze":0,"withdrawing":0,"asset":"ADA","free":11467.6399,"locked":0}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountAssetsRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountAssetsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v3/sub-account/assets", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountAssetsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySubAccountAssetsRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountAssetsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountAssetsAssetManagementAsync()
    {
        const string example = """""{"balances":[{"freeze":"0","withdrawing":"0","asset":"ADA","free":"10000","locked":"0"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountAssetsAssetManagementRequest
        {
            Email = "123@test.com",
        };

        var response = await client.QuerySubAccountAssetsAssetManagementAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v4/sub-account/assets", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountAssetsAssetManagementWithOptionalParametersAsync()
    {
        const string example = """""{"balances":[{"freeze":"0","withdrawing":"0","asset":"ADA","free":"10000","locked":"0"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountAssetsAssetManagementRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountAssetsAssetManagementAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v4/sub-account/assets", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountAssetsAssetManagementBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySubAccountAssetsAssetManagementRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountAssetsAssetManagementAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountFuturesAssetTransferHistoryAsync()
    {
        const string example = """""{"success":true,"futuresType":2,"transfers":[{"from":"aaa@test.com","to":"bbb@test.com","asset":"BTC","qty":"1","tranId":11897001102,"time":1544433328000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountFuturesAssetTransferHistoryRequest
        {
            Email = "123@test.com",
            FuturesType = 1L,
        };

        var response = await client.QuerySubAccountFuturesAssetTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/internalTransfer", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountFuturesAssetTransferHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"futuresType":2,"transfers":[{"from":"aaa@test.com","to":"bbb@test.com","asset":"BTC","qty":"1","tranId":11897001102,"time":1544433328000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountFuturesAssetTransferHistoryRequest
        {
            Email = "123@test.com",
            FuturesType = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountFuturesAssetTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/internalTransfer", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountFuturesAssetTransferHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySubAccountFuturesAssetTransferHistoryRequest
        {
            Email = "123@test.com",
            FuturesType = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountFuturesAssetTransferHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountSpotAssetTransferHistoryAsync()
    {
        const string example = """""[{"from":"aaa@test.com","to":"bbb@test.com","asset":"BTC","qty":"10","status":"SUCCESS","tranId":6489943656,"time":1544433328000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QuerySubAccountSpotAssetTransferHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/sub/transfer/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountSpotAssetTransferHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"from":"aaa@test.com","to":"bbb@test.com","asset":"BTC","qty":"10","status":"SUCCESS","tranId":6489943656,"time":1544433328000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountSpotAssetTransferHistoryRequest
        {
            FromEmail = "aaa@test.com",
            ToEmail = "bbb@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountSpotAssetTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/sub/transfer/history", seen.Path);
        Assert.Equal("aaa@test.com", seen.Param("fromEmail"));
        Assert.Equal("bbb@test.com", seen.Param("toEmail"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountSpotAssetTransferHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountSpotAssetTransferHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountSpotAssetsSummaryAsync()
    {
        const string example = """""{"totalCount":2,"masterAccountTotalAsset":"0.23231201","spotSubUserAssetBtcVoList":[{"email":"sub123@test.com","totalAsset":"9999.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QuerySubAccountSpotAssetsSummaryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/spotSummary", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountSpotAssetsSummaryWithOptionalParametersAsync()
    {
        const string example = """""{"totalCount":2,"masterAccountTotalAsset":"0.23231201","spotSubUserAssetBtcVoList":[{"email":"sub123@test.com","totalAsset":"9999.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountSpotAssetsSummaryRequest
        {
            Email = "123@test.com",
            Page = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountSpotAssetsSummaryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/spotSummary", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountSpotAssetsSummaryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountSpotAssetsSummaryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUniversalTransferHistoryAsync()
    {
        const string example = """""{"result":[{"tranId":92275823339,"fromEmail":"abctest@gmail.com","toEmail":"deftest@gmail.com","asset":"BNB","amount":"0.01","createTimeStamp":1640317374000,"fromAccountType":"USDT_FUTURE","toAccountType":"SPOT","status":"SUCCESS","clientTranId":"test"}],"totalCount":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUniversalTransferHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/universalTransfer", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUniversalTransferHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"result":[{"tranId":92275823339,"fromEmail":"abctest@gmail.com","toEmail":"deftest@gmail.com","asset":"BNB","amount":"0.01","createTimeStamp":1640317374000,"fromAccountType":"USDT_FUTURE","toAccountType":"SPOT","status":"SUCCESS","clientTranId":"test"}],"totalCount":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUniversalTransferHistoryRequest
        {
            FromEmail = "abctest@gmail.com",
            ToEmail = "deftest@gmail.com",
            ClientTranId = "1",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUniversalTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/universalTransfer", seen.Path);
        Assert.Equal("abctest@gmail.com", seen.Param("fromEmail"));
        Assert.Equal("deftest@gmail.com", seen.Param("toEmail"));
        Assert.Equal("1", seen.Param("clientTranId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUniversalTransferHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUniversalTransferHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubAccountFuturesAssetTransferAsync()
    {
        const string example = """""{"success":true,"txnId":"2934662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubAccountFuturesAssetTransferRequest
        {
            FromEmail = "abc@test.com",
            ToEmail = "def@test.com",
            FuturesType = 1L,
            Asset = "BTC",
            Amount = 1.0m,
        };

        var response = await client.SubAccountFuturesAssetTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/internalTransfer", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("fromEmail"));
        Assert.Equal("def@test.com", seen.Param("toEmail"));
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubAccountFuturesAssetTransferWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"txnId":"2934662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubAccountFuturesAssetTransferRequest
        {
            FromEmail = "abc@test.com",
            ToEmail = "def@test.com",
            FuturesType = 1L,
            Asset = "BTC",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.SubAccountFuturesAssetTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/internalTransfer", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("fromEmail"));
        Assert.Equal("def@test.com", seen.Param("toEmail"));
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubAccountFuturesAssetTransferBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubAccountFuturesAssetTransferRequest
        {
            FromEmail = "abc@test.com",
            ToEmail = "def@test.com",
            FuturesType = 1L,
            Asset = "BTC",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubAccountFuturesAssetTransferAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubAccountTransferHistoryAsync()
    {
        const string example = """""[{"counterParty":"master","email":"master@test.com","type":1,"asset":"BTC","qty":"1","fromAccountType":"SPOT","toAccountType":"SPOT","status":"SUCCESS","tranId":11798835829,"time":1544433325000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SubAccountTransferHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transfer/subUserHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubAccountTransferHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"counterParty":"master","email":"master@test.com","type":1,"asset":"BTC","qty":"1","fromAccountType":"SPOT","toAccountType":"SPOT","status":"SUCCESS","tranId":11798835829,"time":1544433325000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubAccountTransferHistoryRequest
        {
            Asset = "BTC",
            Type = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 10L,
            ReturnFailHistory = false,
            RecvWindow = 5000L,
        };

        var response = await client.SubAccountTransferHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transfer/subUserHistory", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("false", seen.Param("returnFailHistory"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubAccountTransferHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubAccountTransferHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TransferToMasterAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TransferToMasterRequest
        {
            Asset = "BTC",
            Amount = 1.0m,
        };

        var response = await client.TransferToMasterAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transfer/subToMaster", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TransferToMasterWithOptionalParametersAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TransferToMasterRequest
        {
            Asset = "BTC",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.TransferToMasterAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transfer/subToMaster", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TransferToMasterBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TransferToMasterRequest
        {
            Asset = "BTC",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TransferToMasterAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TransferToSubAccountOfSameMasterAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TransferToSubAccountOfSameMasterRequest
        {
            ToEmail = "abc@test.com",
            Asset = "BTC",
            Amount = 1.0m,
        };

        var response = await client.TransferToSubAccountOfSameMasterAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transfer/subToSub", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("toEmail"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TransferToSubAccountOfSameMasterWithOptionalParametersAsync()
    {
        const string example = """""{"txnId":"2966662589"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TransferToSubAccountOfSameMasterRequest
        {
            ToEmail = "abc@test.com",
            Asset = "BTC",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.TransferToSubAccountOfSameMasterAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transfer/subToSub", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("toEmail"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TransferToSubAccountOfSameMasterBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TransferToSubAccountOfSameMasterRequest
        {
            ToEmail = "abc@test.com",
            Asset = "BTC",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TransferToSubAccountOfSameMasterAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UniversalTransferAsync()
    {
        const string example = """""{"tranId":11945860693,"clientTranId":"test"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UniversalTransferRequest
        {
            FromAccountType = UniversalTransferFromAccountType.Spot,
            ToAccountType = UniversalTransferToAccountType.Spot,
            Asset = "BTC",
            Amount = 1.0m,
        };

        var response = await client.UniversalTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/universalTransfer", seen.Path);
        Assert.Equal("SPOT", seen.Param("fromAccountType"));
        Assert.Equal("SPOT", seen.Param("toAccountType"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UniversalTransferWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":11945860693,"clientTranId":"test"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UniversalTransferRequest
        {
            FromAccountType = UniversalTransferFromAccountType.Spot,
            ToAccountType = UniversalTransferToAccountType.Spot,
            Asset = "BTC",
            Amount = 1.0m,
            FromEmail = "abc@test.com",
            ToEmail = "def@test.com",
            ClientTranId = "1",
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.UniversalTransferAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/universalTransfer", seen.Path);
        Assert.Equal("SPOT", seen.Param("fromAccountType"));
        Assert.Equal("SPOT", seen.Param("toAccountType"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("abc@test.com", seen.Param("fromEmail"));
        Assert.Equal("def@test.com", seen.Param("toEmail"));
        Assert.Equal("1", seen.Param("clientTranId"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UniversalTransferBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new UniversalTransferRequest
        {
            FromAccountType = UniversalTransferFromAccountType.Spot,
            ToAccountType = UniversalTransferToAccountType.Spot,
            Asset = "BTC",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UniversalTransferAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
