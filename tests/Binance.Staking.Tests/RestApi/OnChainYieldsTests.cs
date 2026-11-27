//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Staking.RestApi;

namespace Binance.Staking.Tests.RestApi.OnChainYields;

[Trait("Category", "Native")]
public class OnChainYieldsApiTests
{
    private static StakingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetOnChainYieldsLockedPersonalLeftQuotaAsync()
    {
        const string example = """""{"leftPersonalQuota":"1000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedPersonalLeftQuotaRequest
        {
            ProjectId = "1",
        };

        var response = await client.GetOnChainYieldsLockedPersonalLeftQuotaAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/personalLeftQuota", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedPersonalLeftQuotaWithOptionalParametersAsync()
    {
        const string example = """""{"leftPersonalQuota":"1000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedPersonalLeftQuotaRequest
        {
            ProjectId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.GetOnChainYieldsLockedPersonalLeftQuotaAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/personalLeftQuota", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedPersonalLeftQuotaBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedPersonalLeftQuotaRequest
        {
            ProjectId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOnChainYieldsLockedPersonalLeftQuotaAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOnChainYieldsLockedProductListAsync()
    {
        const string example = """""{"rows":[{"projectId":"Solv-60d","detail":{"asset":"BTC","rewardAsset":"SOLV","duration":60,"renewable":true,"isSoldOut":true,"apr":"0.039","status":"PREHEATING","subscriptionStartTime":1646182276000,"canRedeemToFlex":true},"quota":{"totalPersonalQuota":"2","minimum":"0.001"}}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOnChainYieldsLockedProductListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedProductListWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"projectId":"Solv-60d","detail":{"asset":"BTC","rewardAsset":"SOLV","duration":60,"renewable":true,"isSoldOut":true,"apr":"0.039","status":"PREHEATING","subscriptionStartTime":1646182276000,"canRedeemToFlex":true},"quota":{"totalPersonalQuota":"2","minimum":"0.001"}}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedProductListRequest
        {
            Asset = "SOL",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetOnChainYieldsLockedProductListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/list", seen.Path);
        Assert.Equal("SOL", seen.Param("asset"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedProductListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOnChainYieldsLockedProductListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOnChainYieldsLockedProductPositionAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","projectId":"Solv-60d","asset":"BTC","amount":"122.09202928","purchaseTime":"1646182276000","duration":"60","accrualDays":"4","rewardAsset":"SOLV","APY":"0.039","rewardAmt":"5.17181528","nextPay":"1.29295383","nextPayDate":"1646697600000","payPeriod":"1","rewardsPayDate":"1646697600000","rewardsEndDate":"1651449600000","deliverDate":"1651536000000","nextSubscriptionDate":"1651536000000","redeemingAmt":"232.2323","redeemTo":"FLEXIBLE","canRedeemEarly":true,"autoSubscribe":true,"type":"AUTO","status":"HOLDING"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOnChainYieldsLockedProductPositionAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/position", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedProductPositionWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","projectId":"Solv-60d","asset":"BTC","amount":"122.09202928","purchaseTime":"1646182276000","duration":"60","accrualDays":"4","rewardAsset":"SOLV","APY":"0.039","rewardAmt":"5.17181528","nextPay":"1.29295383","nextPayDate":"1646697600000","payPeriod":"1","rewardsPayDate":"1646697600000","rewardsEndDate":"1651449600000","deliverDate":"1651536000000","nextSubscriptionDate":"1651536000000","redeemingAmt":"232.2323","redeemTo":"FLEXIBLE","canRedeemEarly":true,"autoSubscribe":true,"type":"AUTO","status":"HOLDING"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedProductPositionRequest
        {
            Asset = "BTC",
            PositionId = "1",
            ProjectId = "1",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetOnChainYieldsLockedProductPositionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/position", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedProductPositionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOnChainYieldsLockedProductPositionAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOnChainYieldsLockedRedemptionRecordAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","redeemId":40607,"time":1575018510000,"asset":"BTC","lockPeriod":"30","amount":"21312.23223","originalAmount":"21312.23223","type":"NORMAL","deliverDate":"1575018510000","lossAmount":"0.00001232","isComplete":true,"rewardAsset":"SOLV","rewardAmt":"5.17181528","status":"PAID"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOnChainYieldsLockedRedemptionRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/history/redemptionRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedRedemptionRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","redeemId":40607,"time":1575018510000,"asset":"BTC","lockPeriod":"30","amount":"21312.23223","originalAmount":"21312.23223","type":"NORMAL","deliverDate":"1575018510000","lossAmount":"0.00001232","isComplete":true,"rewardAsset":"SOLV","rewardAmt":"5.17181528","status":"PAID"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedRedemptionRecordRequest
        {
            PositionId = "1",
            RedeemId = "1",
            Asset = "BTC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetOnChainYieldsLockedRedemptionRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/history/redemptionRecord", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("1", seen.Param("redeemId"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedRedemptionRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOnChainYieldsLockedRedemptionRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOnChainYieldsLockedRewardsHistoryAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","time":1575018510000,"asset":"BNB","lockPeriod":"30","amount":"21312.23223"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOnChainYieldsLockedRewardsHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/history/rewardsRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","time":1575018510000,"asset":"BNB","lockPeriod":"30","amount":"21312.23223"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedRewardsHistoryRequest
        {
            PositionId = "1",
            Asset = "BTC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetOnChainYieldsLockedRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/history/rewardsRecord", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOnChainYieldsLockedRewardsHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOnChainYieldsLockedSubscriptionPreviewAsync()
    {
        const string example = """""{"rewardAsset":"SOLV","totalRewardAmt":"5.17181528","nextPay":"1.29295383","nextPayDate":"1646697600000","rewardsPayDate":"1646697600000","valueDate":"1646697600000","rewardsEndDate":"1651449600000","deliverDate":"1651536000000","nextSubscriptionDate":"1651536000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedSubscriptionPreviewRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var response = await client.GetOnChainYieldsLockedSubscriptionPreviewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/subscriptionPreview", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedSubscriptionPreviewWithOptionalParametersAsync()
    {
        const string example = """""{"rewardAsset":"SOLV","totalRewardAmt":"5.17181528","nextPay":"1.29295383","nextPayDate":"1646697600000","rewardsPayDate":"1646697600000","valueDate":"1646697600000","rewardsEndDate":"1651449600000","deliverDate":"1651536000000","nextSubscriptionDate":"1651536000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedSubscriptionPreviewRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
            AutoSubscribe = true,
            RecvWindow = 5000L,
        };

        var response = await client.GetOnChainYieldsLockedSubscriptionPreviewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/subscriptionPreview", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("true", seen.Param("autoSubscribe"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedSubscriptionPreviewBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedSubscriptionPreviewRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOnChainYieldsLockedSubscriptionPreviewAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOnChainYieldsLockedSubscriptionRecordAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","purchaseId":"26055","projectId":"Solv-60d","clientId":"ABC","time":1575018510000,"asset":"BTC","amount":"21312.23223","lockPeriod":"30","type":"AUTO","sourceAccount":"SPOT","amtFromSpot":"30","amtFromFunding":"70","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOnChainYieldsLockedSubscriptionRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/history/subscriptionRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedSubscriptionRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":"123123","purchaseId":"26055","projectId":"Solv-60d","clientId":"ABC","time":1575018510000,"asset":"BTC","amount":"21312.23223","lockPeriod":"30","type":"AUTO","sourceAccount":"SPOT","amtFromSpot":"30","amtFromFunding":"70","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOnChainYieldsLockedSubscriptionRecordRequest
        {
            PurchaseId = "1",
            ClientId = "1",
            Asset = "BTC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetOnChainYieldsLockedSubscriptionRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/history/subscriptionRecord", seen.Path);
        Assert.Equal("1", seen.Param("purchaseId"));
        Assert.Equal("1", seen.Param("clientId"));
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOnChainYieldsLockedSubscriptionRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOnChainYieldsLockedSubscriptionRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OnChainYieldsAccountAsync()
    {
        const string example = """""{"totalAmountInBTC":"0.01067982","totalAmountInUSDT":"77.13289230","totalFlexibleAmountInBTC":"0.00000000","totalFlexibleAmountInUSDT":"0.00000000","totalLockedInBTC":"0.01067982","totalLockedInUSDT":"77.13289230"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OnChainYieldsAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OnChainYieldsAccountWithOptionalParametersAsync()
    {
        const string example = """""{"totalAmountInBTC":"0.01067982","totalAmountInUSDT":"77.13289230","totalFlexibleAmountInBTC":"0.00000000","totalFlexibleAmountInUSDT":"0.00000000","totalLockedInBTC":"0.01067982","totalLockedInUSDT":"77.13289230"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OnChainYieldsAccountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.OnChainYieldsAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OnChainYieldsAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OnChainYieldsAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RedeemOnChainYieldsLockedProductAsync()
    {
        const string example = """""{"redeemId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemOnChainYieldsLockedProductRequest
        {
            PositionId = "1",
        };

        var response = await client.RedeemOnChainYieldsLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/redeem", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemOnChainYieldsLockedProductWithOptionalParametersAsync()
    {
        const string example = """""{"redeemId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemOnChainYieldsLockedProductRequest
        {
            PositionId = "1",
            ChannelId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.RedeemOnChainYieldsLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/redeem", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("1", seen.Param("channelId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemOnChainYieldsLockedProductBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RedeemOnChainYieldsLockedProductRequest
        {
            PositionId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RedeemOnChainYieldsLockedProductAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetOnChainYieldsLockedAutoSubscribeAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetOnChainYieldsLockedAutoSubscribeRequest
        {
            PositionId = "1",
            AutoSubscribe = true,
        };

        var response = await client.SetOnChainYieldsLockedAutoSubscribeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/setAutoSubscribe", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("true", seen.Param("autoSubscribe"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetOnChainYieldsLockedAutoSubscribeWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetOnChainYieldsLockedAutoSubscribeRequest
        {
            PositionId = "1",
            AutoSubscribe = true,
            RecvWindow = 5000L,
        };

        var response = await client.SetOnChainYieldsLockedAutoSubscribeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/setAutoSubscribe", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("true", seen.Param("autoSubscribe"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetOnChainYieldsLockedAutoSubscribeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetOnChainYieldsLockedAutoSubscribeRequest
        {
            PositionId = "1",
            AutoSubscribe = true,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetOnChainYieldsLockedAutoSubscribeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetOnChainYieldsLockedProductRedeemOptionAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetOnChainYieldsLockedProductRedeemOptionRequest
        {
            PositionId = "1",
            RedeemTo = SetOnChainYieldsLockedProductRedeemOptionRedeemTo.Spot,
        };

        var response = await client.SetOnChainYieldsLockedProductRedeemOptionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/setRedeemOption", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("SPOT", seen.Param("redeemTo"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetOnChainYieldsLockedProductRedeemOptionWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetOnChainYieldsLockedProductRedeemOptionRequest
        {
            PositionId = "1",
            RedeemTo = SetOnChainYieldsLockedProductRedeemOptionRedeemTo.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.SetOnChainYieldsLockedProductRedeemOptionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/setRedeemOption", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("SPOT", seen.Param("redeemTo"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetOnChainYieldsLockedProductRedeemOptionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetOnChainYieldsLockedProductRedeemOptionRequest
        {
            PositionId = "1",
            RedeemTo = SetOnChainYieldsLockedProductRedeemOptionRedeemTo.Spot,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetOnChainYieldsLockedProductRedeemOptionAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubscribeOnChainYieldsLockedProductAsync()
    {
        const string example = """""{"purchaseId":40607,"positionId":"12345","amount":"75.46000000","success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeOnChainYieldsLockedProductRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var response = await client.SubscribeOnChainYieldsLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/subscribe", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeOnChainYieldsLockedProductWithOptionalParametersAsync()
    {
        const string example = """""{"purchaseId":40607,"positionId":"12345","amount":"75.46000000","success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeOnChainYieldsLockedProductRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
            AutoSubscribe = false,
            SourceAccount = SubscribeOnChainYieldsLockedProductSourceAccount.Spot,
            RedeemTo = SubscribeOnChainYieldsLockedProductRedeemTo.Spot,
            ChannelId = "1",
            ClientId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.SubscribeOnChainYieldsLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/onchain-yields/locked/subscribe", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("false", seen.Param("autoSubscribe"));
        Assert.Equal("SPOT", seen.Param("sourceAccount"));
        Assert.Equal("SPOT", seen.Param("redeemTo"));
        Assert.Equal("1", seen.Param("channelId"));
        Assert.Equal("1", seen.Param("clientId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeOnChainYieldsLockedProductBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubscribeOnChainYieldsLockedProductRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubscribeOnChainYieldsLockedProductAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
