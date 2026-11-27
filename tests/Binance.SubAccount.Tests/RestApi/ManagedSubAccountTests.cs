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

namespace Binance.SubAccount.Tests.RestApi.ManagedSubAccount;

[Trait("Category", "Native")]
public class ManagedSubAccountApiTests
{
    private static SubAccountRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task DepositAssetsIntoTheManagedSubAccountAsync()
    {
        const string example = """""{"tranId":66157362489}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositAssetsIntoTheManagedSubAccountRequest
        {
            ToEmail = "abc@test.com",
            Asset = "BTC",
            Amount = 1.0m,
        };

        var response = await client.DepositAssetsIntoTheManagedSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/deposit", seen.Path);
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
    public async Task DepositAssetsIntoTheManagedSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":66157362489}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositAssetsIntoTheManagedSubAccountRequest
        {
            ToEmail = "abc@test.com",
            Asset = "BTC",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.DepositAssetsIntoTheManagedSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/deposit", seen.Path);
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
    public async Task DepositAssetsIntoTheManagedSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DepositAssetsIntoTheManagedSubAccountRequest
        {
            ToEmail = "abc@test.com",
            Asset = "BTC",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DepositAssetsIntoTheManagedSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetManagedSubAccountDepositAddressAsync()
    {
        const string example = """""{"coin":"USDT","address":"0x206c22d833bb0bb2102da6b7c7d4c3eb14bcf73d","tag":"","url":"https://etherscan.io/address/0x206c22d833bb0bb2102da6b7c7d4c3eb14bcf73d"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetManagedSubAccountDepositAddressRequest
        {
            Email = "abc@test.com",
            Coin = "USDT",
        };

        var response = await client.GetManagedSubAccountDepositAddressAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/deposit/address", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("USDT", seen.Param("coin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetManagedSubAccountDepositAddressWithOptionalParametersAsync()
    {
        const string example = """""{"coin":"USDT","address":"0x206c22d833bb0bb2102da6b7c7d4c3eb14bcf73d","tag":"","url":"https://etherscan.io/address/0x206c22d833bb0bb2102da6b7c7d4c3eb14bcf73d"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetManagedSubAccountDepositAddressRequest
        {
            Email = "abc@test.com",
            Coin = "USDT",
            Network = "LIGHTNING",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.GetManagedSubAccountDepositAddressAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/deposit/address", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("USDT", seen.Param("coin"));
        Assert.Equal("LIGHTNING", seen.Param("network"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetManagedSubAccountDepositAddressBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetManagedSubAccountDepositAddressRequest
        {
            Email = "abc@test.com",
            Coin = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetManagedSubAccountDepositAddressAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountAssetDetailsAsync()
    {
        const string example = """""[{"coin":"INJ","name":"Injective Protocol","totalBalance":"0","availableBalance":"0","inOrder":"0","btcValue":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountAssetDetailsRequest
        {
            Email = "abc@test.com",
        };

        var response = await client.QueryManagedSubAccountAssetDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/asset", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountAssetDetailsWithOptionalParametersAsync()
    {
        const string example = """""[{"coin":"INJ","name":"Injective Protocol","totalBalance":"0","availableBalance":"0","inOrder":"0","btcValue":"0"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountAssetDetailsRequest
        {
            Email = "abc@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.QueryManagedSubAccountAssetDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/asset", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountAssetDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryManagedSubAccountAssetDetailsRequest
        {
            Email = "abc@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountAssetDetailsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountFuturesAssetDetailsAsync()
    {
        const string example = """""{"code":"200","message":"OK","snapshotVos":[{"type":"FUTURES","updateTime":1672893855394,"data":{"assets":[{"asset":"USDT","marginBalance":100,"walletBalance":120}],"position":[{"symbol":"BTCUSDT","entryPrice":17000,"markPrice":17000,"positionAmt":0.0001}]}}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountFuturesAssetDetailsRequest
        {
            Email = "abc@test.com",
        };

        var response = await client.QueryManagedSubAccountFuturesAssetDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/fetch-future-asset", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountFuturesAssetDetailsWithOptionalParametersAsync()
    {
        const string example = """""{"code":"200","message":"OK","snapshotVos":[{"type":"FUTURES","updateTime":1672893855394,"data":{"assets":[{"asset":"USDT","marginBalance":100,"walletBalance":120}],"position":[{"symbol":"BTCUSDT","entryPrice":17000,"markPrice":17000,"positionAmt":0.0001}]}}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountFuturesAssetDetailsRequest
        {
            Email = "abc@test.com",
            AccountType = "MARGIN",
        };

        var response = await client.QueryManagedSubAccountFuturesAssetDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/fetch-future-asset", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("MARGIN", seen.Param("accountType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountFuturesAssetDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryManagedSubAccountFuturesAssetDetailsRequest
        {
            Email = "abc@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountFuturesAssetDetailsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountListAsync()
    {
        const string example = """""{"total":3,"managerSubUserInfoVoList":[{"rootUserId":1000138475670,"managersubUserId":1000137842513,"bindParentUserId":1000138475669,"email":"test_0_virtual@kq3kno9imanagedsub.com","insertTimeStamp":1678435149000,"bindParentEmail":"wdyw8xsh8pey@test.com","isSubUserEnabled":true,"isUserActive":true,"isMarginEnabled":false,"isFutureEnabled":false,"isSignedLVTRiskAgreement":false}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryManagedSubAccountListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/info", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountListWithOptionalParametersAsync()
    {
        const string example = """""{"total":3,"managerSubUserInfoVoList":[{"rootUserId":1000138475670,"managersubUserId":1000137842513,"bindParentUserId":1000138475669,"email":"test_0_virtual@kq3kno9imanagedsub.com","insertTimeStamp":1678435149000,"bindParentEmail":"wdyw8xsh8pey@test.com","isSubUserEnabled":true,"isUserActive":true,"isMarginEnabled":false,"isFutureEnabled":false,"isSignedLVTRiskAgreement":false}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountListRequest
        {
            Email = "abc@test.com",
            Page = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryManagedSubAccountListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/info", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
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
    public async Task QueryManagedSubAccountListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountMarginAssetDetailsAsync()
    {
        const string example = """""{"marginLevel":"999","totalAssetOfBtc":"0","totalLiabilityOfBtc":"0","totalNetAssetOfBtc":"0","userAssets":[{"asset":"MATIC","borrowed":"0","free":"0","interest":"0","locked":"0","netAsset":"0"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountMarginAssetDetailsRequest
        {
            Email = "abc@test.com",
        };

        var response = await client.QueryManagedSubAccountMarginAssetDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/marginAsset", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountMarginAssetDetailsWithOptionalParametersAsync()
    {
        const string example = """""{"marginLevel":"999","totalAssetOfBtc":"0","totalLiabilityOfBtc":"0","totalNetAssetOfBtc":"0","userAssets":[{"asset":"MATIC","borrowed":"0","free":"0","interest":"0","locked":"0","netAsset":"0"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountMarginAssetDetailsRequest
        {
            Email = "abc@test.com",
            AccountType = "MARGIN",
        };

        var response = await client.QueryManagedSubAccountMarginAssetDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/marginAsset", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("MARGIN", seen.Param("accountType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountMarginAssetDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryManagedSubAccountMarginAssetDetailsRequest
        {
            Email = "abc@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountMarginAssetDetailsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountSnapshotAsync()
    {
        const string example = """""{"code":200,"msg":"","snapshotVos":[{"data":{"balances":[{"asset":"BTC","free":"0.09905021","locked":"0.00000000"}],"totalAssetOfBtc":"0.09942700","marginLevel":"2748.02909813","totalLiabilityOfBtc":"0.00000100","totalNetAssetOfBtc":"0.00274750","userAssets":[{"asset":"XRP","borrowed":"0.00000000","free":"1.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"1.00000000"}],"assets":[{"asset":"USDT","marginBalance":"118.99782335","walletBalance":"120.23811389"}],"position":[{"entryPrice":"7130.41000000","markPrice":"7257.66239673","positionAmt":"0.01000000","symbol":"BTCUSDT","unRealizedProfit":"1.24029054"}]},"type":"spot","updateTime":1576281599000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountSnapshotRequest
        {
            Email = "abc@test.com",
            Type = QueryManagedSubAccountSnapshotType.Spot,
        };

        var response = await client.QueryManagedSubAccountSnapshotAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/accountSnapshot", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("SPOT", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountSnapshotWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"","snapshotVos":[{"data":{"balances":[{"asset":"BTC","free":"0.09905021","locked":"0.00000000"}],"totalAssetOfBtc":"0.09942700","marginLevel":"2748.02909813","totalLiabilityOfBtc":"0.00000100","totalNetAssetOfBtc":"0.00274750","userAssets":[{"asset":"XRP","borrowed":"0.00000000","free":"1.00000000","interest":"0.00000000","locked":"0.00000000","netAsset":"1.00000000"}],"assets":[{"asset":"USDT","marginBalance":"118.99782335","walletBalance":"120.23811389"}],"position":[{"entryPrice":"7130.41000000","markPrice":"7257.66239673","positionAmt":"0.01000000","symbol":"BTCUSDT","unRealizedProfit":"1.24029054"}]},"type":"spot","updateTime":1576281599000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountSnapshotRequest
        {
            Email = "abc@test.com",
            Type = QueryManagedSubAccountSnapshotType.Spot,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryManagedSubAccountSnapshotAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/accountSnapshot", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("SPOT", seen.Param("type"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountSnapshotBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryManagedSubAccountSnapshotRequest
        {
            Email = "abc@test.com",
            Type = QueryManagedSubAccountSnapshotType.Spot,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountSnapshotAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogMasterAccountInvestorAsync()
    {
        const string example = """""{"managerSubTransferHistoryVos":[{"fromEmail":"test_0_virtual@kq3kno9imanagedsub.com","fromAccountType":"SPOT","toEmail":"wdywl0lddakh@test.com","toAccountType":"SPOT","asset":"BNB","amount":"0.01","scheduledData":1679416673000,"createTime":1679416673000,"status":"SUCCESS","tranId":91077779}],"count":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogMasterAccountInvestorRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 1L,
        };

        var response = await client.QueryManagedSubAccountTransferLogMasterAccountInvestorAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/queryTransLogForInvestor", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogMasterAccountInvestorWithOptionalParametersAsync()
    {
        const string example = """""{"managerSubTransferHistoryVos":[{"fromEmail":"test_0_virtual@kq3kno9imanagedsub.com","fromAccountType":"SPOT","toEmail":"wdywl0lddakh@test.com","toAccountType":"SPOT","asset":"BNB","amount":"0.01","scheduledData":1679416673000,"createTime":1679416673000,"status":"SUCCESS","tranId":91077779}],"count":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogMasterAccountInvestorRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 1L,
            Transfers = "transfers_example",
            TransferFunctionAccountType = QueryManagedSubAccountTransferLogMasterAccountInvestorTransferFunctionAccountType.Spot,
        };

        var response = await client.QueryManagedSubAccountTransferLogMasterAccountInvestorAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/queryTransLogForInvestor", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("transfers_example", seen.Param("transfers"));
        Assert.Equal("SPOT", seen.Param("transferFunctionAccountType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogMasterAccountInvestorBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogMasterAccountInvestorRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountTransferLogMasterAccountInvestorAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogMasterAccountTradingAsync()
    {
        const string example = """""{"managerSubTransferHistoryVos":[{"fromEmail":"test_0_virtual@kq3kno9imanagedsub.com","fromAccountType":"SPOT","toEmail":"wdywl0lddakh@test.com","toAccountType":"SPOT","asset":"BNB","amount":"0.01","scheduledData":1679416673000,"createTime":1679416673000,"status":"SUCCESS","tranId":91077779}],"count":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogMasterAccountTradingRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
        };

        var response = await client.QueryManagedSubAccountTransferLogMasterAccountTradingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/queryTransLogForTradeParent", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogMasterAccountTradingWithOptionalParametersAsync()
    {
        const string example = """""{"managerSubTransferHistoryVos":[{"fromEmail":"test_0_virtual@kq3kno9imanagedsub.com","fromAccountType":"SPOT","toEmail":"wdywl0lddakh@test.com","toAccountType":"SPOT","asset":"BNB","amount":"0.01","scheduledData":1679416673000,"createTime":1679416673000,"status":"SUCCESS","tranId":91077779}],"count":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogMasterAccountTradingRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
            Transfers = "transfers_example",
            TransferFunctionAccountType = QueryManagedSubAccountTransferLogMasterAccountTradingTransferFunctionAccountType.Spot,
        };

        var response = await client.QueryManagedSubAccountTransferLogMasterAccountTradingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/queryTransLogForTradeParent", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("transfers_example", seen.Param("transfers"));
        Assert.Equal("SPOT", seen.Param("transferFunctionAccountType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogMasterAccountTradingBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogMasterAccountTradingRequest
        {
            Email = "abc@test.com",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountTransferLogMasterAccountTradingAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogSubAccountTradingAsync()
    {
        const string example = """""{"managerSubTransferHistoryVos":[{"fromEmail":"test_0_virtual@kq3kno9imanagedsub.com","fromAccountType":"SPOT","toEmail":"wdywl0lddakh@test.com","toAccountType":"SPOT","asset":"BNB","amount":"0.01","scheduledData":1679416673000,"createTime":1679416673000,"status":"SUCCESS","tranId":91077779}],"count":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogSubAccountTradingRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
        };

        var response = await client.QueryManagedSubAccountTransferLogSubAccountTradingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/query-trans-log", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogSubAccountTradingWithOptionalParametersAsync()
    {
        const string example = """""{"managerSubTransferHistoryVos":[{"fromEmail":"test_0_virtual@kq3kno9imanagedsub.com","fromAccountType":"SPOT","toEmail":"wdywl0lddakh@test.com","toAccountType":"SPOT","asset":"BNB","amount":"0.01","scheduledData":1679416673000,"createTime":1679416673000,"status":"SUCCESS","tranId":91077779}],"count":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogSubAccountTradingRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
            Transfers = "transfers_example",
            TransferFunctionAccountType = QueryManagedSubAccountTransferLogSubAccountTradingTransferFunctionAccountType.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.QueryManagedSubAccountTransferLogSubAccountTradingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/query-trans-log", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("transfers_example", seen.Param("transfers"));
        Assert.Equal("SPOT", seen.Param("transferFunctionAccountType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryManagedSubAccountTransferLogSubAccountTradingBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryManagedSubAccountTransferLogSubAccountTradingRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Page = 1L,
            Limit = 10L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryManagedSubAccountTransferLogSubAccountTradingAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task WithdrawlAssetsFromTheManagedSubAccountAsync()
    {
        const string example = """""{"tranId":66157362489}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawlAssetsFromTheManagedSubAccountRequest
        {
            FromEmail = "from@test.com",
            Asset = "BTC",
            Amount = 1.0m,
        };

        var response = await client.WithdrawlAssetsFromTheManagedSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/withdraw", seen.Path);
        Assert.Equal("from@test.com", seen.Param("fromEmail"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawlAssetsFromTheManagedSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":66157362489}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new WithdrawlAssetsFromTheManagedSubAccountRequest
        {
            FromEmail = "from@test.com",
            Asset = "BTC",
            Amount = 1.0m,
            TransferDate = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.WithdrawlAssetsFromTheManagedSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/managed-subaccount/withdraw", seen.Path);
        Assert.Equal("from@test.com", seen.Param("fromEmail"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("transferDate"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task WithdrawlAssetsFromTheManagedSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new WithdrawlAssetsFromTheManagedSubAccountRequest
        {
            FromEmail = "from@test.com",
            Asset = "BTC",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.WithdrawlAssetsFromTheManagedSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
