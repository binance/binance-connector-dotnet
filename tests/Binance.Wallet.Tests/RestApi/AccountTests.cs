//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Wallet.RestApi;

namespace Binance.Wallet.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static WalletRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountApiTradingStatusAsync()
    {
        const string example = """""{"data":{"isLocked":false,"plannedRecoverTime":0,"triggerCondition":{"GCR":150,"IFER":150,"UFR":300},"updateTime":1547630471725}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountApiTradingStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/apiTradingStatus", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountApiTradingStatusWithOptionalParametersAsync()
    {
        const string example = """""{"data":{"isLocked":false,"plannedRecoverTime":0,"triggerCondition":{"GCR":150,"IFER":150,"UFR":300},"updateTime":1547630471725}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountApiTradingStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.AccountApiTradingStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/apiTradingStatus", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountApiTradingStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountApiTradingStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountInfoAsync()
    {
        const string example = """""{"vipLevel":0,"isMarginEnabled":true,"isFutureEnabled":true,"isOptionsEnabled":true,"isPortfolioMarginRetailEnabled":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountInfoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/info", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInfoWithOptionalParametersAsync()
    {
        const string example = """""{"vipLevel":0,"isMarginEnabled":true,"isFutureEnabled":true,"isOptionsEnabled":true,"isPortfolioMarginRetailEnabled":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountInfoRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.AccountInfoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/info", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountInfoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountStatusAsync()
    {
        const string example = """""{"data":"Normal"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/status", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountStatusWithOptionalParametersAsync()
    {
        const string example = """""{"data":"Normal"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.AccountStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/status", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DailyAccountSnapshotAsync()
    {
        const string example = """""{"code":200,"msg":"","snapshotVos":[{"data":{"balances":[{"asset":"BTC","free":"0.09905021","locked":"0.00000000"}],"totalAssetOfBtc":"0.09942700","marginLevel":"2748.02909813","totalLiabilityOfBtc":"0.00000100","totalNetAssetOfBtc":"0.00274750","userAssets":[{"asset":"XRP","borrowed":"0.00000000","free":"1.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"1.00000000"}],"assets":[{"asset":"USDT","marginBalance":"118.99782335","walletBalance":"120.23811389"}],"position":[{"entryPrice":"7130.41000000","markPrice":"7257.66239673","positionAmt":"0.01000000","symbol":"BTCUSDT","unRealizedProfit":"1.24029054"}]},"type":"spot","updateTime":1576281599000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DailyAccountSnapshotRequest
        {
            Type = DailyAccountSnapshotType.Spot,
        };

        var response = await client.DailyAccountSnapshotAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/accountSnapshot", seen.Path);
        Assert.Equal("SPOT", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DailyAccountSnapshotWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"","snapshotVos":[{"data":{"balances":[{"asset":"BTC","free":"0.09905021","locked":"0.00000000"}],"totalAssetOfBtc":"0.09942700","marginLevel":"2748.02909813","totalLiabilityOfBtc":"0.00000100","totalNetAssetOfBtc":"0.00274750","userAssets":[{"asset":"XRP","borrowed":"0.00000000","free":"1.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"1.00000000"}],"assets":[{"asset":"USDT","marginBalance":"118.99782335","walletBalance":"120.23811389"}],"position":[{"entryPrice":"7130.41000000","markPrice":"7257.66239673","positionAmt":"0.01000000","symbol":"BTCUSDT","unRealizedProfit":"1.24029054"}]},"type":"spot","updateTime":1576281599000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DailyAccountSnapshotRequest
        {
            Type = DailyAccountSnapshotType.Spot,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 7L,
            RecvWindow = 5000L,
        };

        var response = await client.DailyAccountSnapshotAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/accountSnapshot", seen.Path);
        Assert.Equal("SPOT", seen.Param("type"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("7", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DailyAccountSnapshotBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DailyAccountSnapshotRequest
        {
            Type = DailyAccountSnapshotType.Spot,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DailyAccountSnapshotAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DisableFastWithdrawSwitchAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.DisableFastWithdrawSwitchAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/account/disableFastWithdrawSwitch", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task DisableFastWithdrawSwitchWithOptionalParametersAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new DisableFastWithdrawSwitchRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.DisableFastWithdrawSwitchAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/account/disableFastWithdrawSwitch", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task DisableFastWithdrawSwitchBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DisableFastWithdrawSwitchAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EnableFastWithdrawSwitchAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.EnableFastWithdrawSwitchAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/account/enableFastWithdrawSwitch", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task EnableFastWithdrawSwitchWithOptionalParametersAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new EnableFastWithdrawSwitchRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.EnableFastWithdrawSwitchAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/account/enableFastWithdrawSwitch", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task EnableFastWithdrawSwitchBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EnableFastWithdrawSwitchAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetApiKeyPermissionAsync()
    {
        const string example = """""{"ipRestrict":false,"createTime":1623840271000,"enableReading":true,"enableWithdrawals":false,"enableInternalTransfer":true,"enableMargin":false,"enableFutures":false,"permitsUniversalTransfer":true,"enableVanillaOptions":false,"enableFixApiTrade":false,"enableFixReadOnly":true,"enableSpotAndMarginTrading":false,"enablePortfolioMarginTrading":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetApiKeyPermissionAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/apiRestrictions", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetApiKeyPermissionWithOptionalParametersAsync()
    {
        const string example = """""{"ipRestrict":false,"createTime":1623840271000,"enableReading":true,"enableWithdrawals":false,"enableInternalTransfer":true,"enableMargin":false,"enableFutures":false,"permitsUniversalTransfer":true,"enableVanillaOptions":false,"enableFixApiTrade":false,"enableFixReadOnly":true,"enableSpotAndMarginTrading":false,"enablePortfolioMarginTrading":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetApiKeyPermissionRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetApiKeyPermissionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/account/apiRestrictions", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetApiKeyPermissionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetApiKeyPermissionAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
