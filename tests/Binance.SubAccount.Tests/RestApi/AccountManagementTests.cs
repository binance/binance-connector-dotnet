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

namespace Binance.SubAccount.Tests.RestApi.AccountManagement;

[Trait("Category", "Native")]
public class AccountManagementApiTests
{
    private static SubAccountRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CreateAVirtualSubAccountAsync()
    {
        const string example = """""{"email":"addsdd_virtual@aasaixwqnoemail.com"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateAVirtualSubAccountRequest
        {
            SubAccountString = "testSubAccount",
        };

        var response = await client.CreateAVirtualSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/virtualSubAccount", seen.Path);
        Assert.Equal("testSubAccount", seen.Param("subAccountString"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateAVirtualSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"email":"addsdd_virtual@aasaixwqnoemail.com"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateAVirtualSubAccountRequest
        {
            SubAccountString = "testSubAccount",
            RecvWindow = 5000L,
        };

        var response = await client.CreateAVirtualSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/virtualSubAccount", seen.Path);
        Assert.Equal("testSubAccount", seen.Param("subAccountString"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateAVirtualSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateAVirtualSubAccountRequest
        {
            SubAccountString = "testSubAccount",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateAVirtualSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EnableFuturesForSubAccountAsync()
    {
        const string example = """""{"email":"123@test.com","isFuturesEnabled":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EnableFuturesForSubAccountRequest
        {
            Email = "123@test.com",
        };

        var response = await client.EnableFuturesForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/enable", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EnableFuturesForSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"email":"123@test.com","isFuturesEnabled":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EnableFuturesForSubAccountRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.EnableFuturesForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/enable", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EnableFuturesForSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new EnableFuturesForSubAccountRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EnableFuturesForSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EnableOptionsForSubAccountAsync()
    {
        const string example = """""{"email":"123@test.com","isEOptionsEnabled":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EnableOptionsForSubAccountRequest
        {
            Email = "123@test.com",
        };

        var response = await client.EnableOptionsForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/eoptions/enable", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EnableOptionsForSubAccountWithOptionalParametersAsync()
    {
        const string example = """""{"email":"123@test.com","isEOptionsEnabled":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EnableOptionsForSubAccountRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.EnableOptionsForSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/eoptions/enable", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EnableOptionsForSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new EnableOptionsForSubAccountRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EnableOptionsForSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesPositionRiskOfSubAccountAsync()
    {
        const string example = """""[{"entryPrice":"9975.12000","leverage":"50","maxNotional":"1000000","liquidationPrice":"7963.54","markPrice":"9973.50770517","positionAmount":"0.010","symbol":"BTCUSDT","unrealizedProfit":"-0.01612295"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesPositionRiskOfSubAccountRequest
        {
            Email = "123@test.com",
        };

        var response = await client.GetFuturesPositionRiskOfSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/positionRisk", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesPositionRiskOfSubAccountWithOptionalParametersAsync()
    {
        const string example = """""[{"entryPrice":"9975.12000","leverage":"50","maxNotional":"1000000","liquidationPrice":"7963.54","markPrice":"9973.50770517","positionAmount":"0.010","symbol":"BTCUSDT","unrealizedProfit":"-0.01612295"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesPositionRiskOfSubAccountRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesPositionRiskOfSubAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/futures/positionRisk", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesPositionRiskOfSubAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesPositionRiskOfSubAccountRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesPositionRiskOfSubAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesPositionRiskOfSubAccountV2Async()
    {
        const string example = """""{"futurePositionRiskVos":[{"entryPrice":"9975.12000","leverage":"50","maxNotional":"1000000","liquidationPrice":"7963.54","markPrice":"9973.50770517","positionAmount":"0.010","symbol":"BTCUSDT","unrealizedProfit":"-0.01612295"}],"deliveryPositionRiskVos":[{"entryPrice":"9975.12000","markPrice":"9973.50770517","leverage":"20","isolated":"false","isolatedWallet":"9973.50770517","isolatedMargin":"0.00000000","isAutoAddMargin":"false","positionSide":"BOTH","positionAmount":"1.230","symbol":"BTCUSD_201225","unrealizedProfit":"-0.01612295"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesPositionRiskOfSubAccountV2Request
        {
            Email = "123@test.com",
            FuturesType = 1L,
        };

        var response = await client.GetFuturesPositionRiskOfSubAccountV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/futures/positionRisk", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("1", seen.Param("futuresType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesPositionRiskOfSubAccountV2WithOptionalParametersAsync()
    {
        const string example = """""{"futurePositionRiskVos":[{"entryPrice":"9975.12000","leverage":"50","maxNotional":"1000000","liquidationPrice":"7963.54","markPrice":"9973.50770517","positionAmount":"0.010","symbol":"BTCUSDT","unrealizedProfit":"-0.01612295"}],"deliveryPositionRiskVos":[{"entryPrice":"9975.12000","markPrice":"9973.50770517","leverage":"20","isolated":"false","isolatedWallet":"9973.50770517","isolatedMargin":"0.00000000","isAutoAddMargin":"false","positionSide":"BOTH","positionAmount":"1.230","symbol":"BTCUSD_201225","unrealizedProfit":"-0.01612295"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesPositionRiskOfSubAccountV2Request
        {
            Email = "123@test.com",
            FuturesType = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesPositionRiskOfSubAccountV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/futures/positionRisk", seen.Path);
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
    public async Task GetFuturesPositionRiskOfSubAccountV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesPositionRiskOfSubAccountV2Request
        {
            Email = "123@test.com",
            FuturesType = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesPositionRiskOfSubAccountV2Async(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSubAccountsStatusOnMarginOrFuturesAsync()
    {
        const string example = """""[{"email":"123@test.com","isSubUserEnabled":true,"isUserActive":true,"insertTime":1570791523523,"isMarginEnabled":true,"isFutureEnabled":true,"mobile":1570791523523}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSubAccountsStatusOnMarginOrFuturesAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/status", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSubAccountsStatusOnMarginOrFuturesWithOptionalParametersAsync()
    {
        const string example = """""[{"email":"123@test.com","isSubUserEnabled":true,"isUserActive":true,"insertTime":1570791523523,"isMarginEnabled":true,"isFutureEnabled":true,"mobile":1570791523523}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSubAccountsStatusOnMarginOrFuturesRequest
        {
            Email = "123@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.GetSubAccountsStatusOnMarginOrFuturesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/status", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSubAccountsStatusOnMarginOrFuturesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSubAccountsStatusOnMarginOrFuturesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountListAsync()
    {
        const string example = """""{"subAccounts":[{"subUserId":123456,"email":"testsub@gmail.com","remark":"remark","isFreeze":false,"createTime":1544433328000,"isManagedSubAccount":false,"isAssetManagementSubAccount":false}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QuerySubAccountListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountListWithOptionalParametersAsync()
    {
        const string example = """""{"subAccounts":[{"subUserId":123456,"email":"testsub@gmail.com","remark":"remark","isFreeze":false,"createTime":1544433328000,"isManagedSubAccount":false,"isAssetManagementSubAccount":false}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountListRequest
        {
            Email = "123@test.com",
            IsFreeze = "true",
            Page = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/list", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("true", seen.Param("isFreeze"));
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
    public async Task QuerySubAccountListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountTransactionStatisticsAsync()
    {
        const string example = """""{"recent30BtcTotal":"0","recent30BtcFuturesTotal":"0","recent30BtcMarginTotal":"0","recent30BusdTotal":"0","recent30BusdFuturesTotal":"0","recent30BusdMarginTotal":"0","tradeInfoVos":[{"userId":1000138138384,"btc":0,"btcFutures":0,"btcMargin":0,"busd":0,"busdFutures":0,"busdMargin":0,"date":1676851200000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QuerySubAccountTransactionStatisticsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transaction-statistics", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountTransactionStatisticsWithOptionalParametersAsync()
    {
        const string example = """""{"recent30BtcTotal":"0","recent30BtcFuturesTotal":"0","recent30BtcMarginTotal":"0","recent30BusdTotal":"0","recent30BusdFuturesTotal":"0","recent30BusdMarginTotal":"0","tradeInfoVos":[{"userId":1000138138384,"btc":0,"btcFutures":0,"btcMargin":0,"busd":0,"busdFutures":0,"busdMargin":0,"date":1676851200000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountTransactionStatisticsRequest
        {
            Email = "abc@test.com",
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountTransactionStatisticsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/transaction-statistics", seen.Path);
        Assert.Equal("abc@test.com", seen.Param("email"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountTransactionStatisticsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountTransactionStatisticsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
