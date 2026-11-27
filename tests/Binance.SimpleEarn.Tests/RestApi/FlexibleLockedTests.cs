//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.SimpleEarn.RestApi;

namespace Binance.SimpleEarn.Tests.RestApi.FlexibleLocked;

[Trait("Category", "Native")]
public class FlexibleLockedApiTests
{
    private static SimpleEarnRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetCollateralRecordAsync()
    {
        const string example = """""{"rows":[{"amount":"100.00000000","productId":"BUSD001","asset":"USDT","createTime":1575018510000,"type":"REPAY","productName":"USDT","orderId":26055}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCollateralRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/collateralRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCollateralRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"amount":"100.00000000","productId":"BUSD001","asset":"USDT","createTime":1575018510000,"type":"REPAY","productName":"USDT","orderId":26055}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCollateralRecordRequest
        {
            ProductId = "1",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetCollateralRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/collateralRecord", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
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
    public async Task GetCollateralRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCollateralRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexiblePersonalLeftQuotaAsync()
    {
        const string example = """""{"leftPersonalQuota":"1000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexiblePersonalLeftQuotaRequest
        {
            ProductId = "1",
        };

        var response = await client.GetFlexiblePersonalLeftQuotaAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/personalLeftQuota", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexiblePersonalLeftQuotaWithOptionalParametersAsync()
    {
        const string example = """""{"leftPersonalQuota":"1000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexiblePersonalLeftQuotaRequest
        {
            ProductId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexiblePersonalLeftQuotaAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/personalLeftQuota", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexiblePersonalLeftQuotaBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFlexiblePersonalLeftQuotaRequest
        {
            ProductId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexiblePersonalLeftQuotaAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleProductPositionAsync()
    {
        const string example = """""{"rows":[{"totalAmount":"75.46000000","tierAnnualPercentageRate":{"0-5BTC":0.05,"5-10BTC":0.03},"latestAnnualPercentageRate":"0.02599895","yesterdayAirdropPercentageRate":"0.02599895","asset":"USDT","airDropAsset":"BETH","canRedeem":true,"collateralAmount":"232.23123213","productId":"USDT001","yesterdayRealTimeRewards":"0.10293829","cumulativeBonusRewards":"0.22759183","cumulativeRealTimeRewards":"0.22759183","cumulativeTotalRewards":"0.45459183","autoSubscribe":true}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleProductPositionAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/position", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleProductPositionWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"totalAmount":"75.46000000","tierAnnualPercentageRate":{"0-5BTC":0.05,"5-10BTC":0.03},"latestAnnualPercentageRate":"0.02599895","yesterdayAirdropPercentageRate":"0.02599895","asset":"USDT","airDropAsset":"BETH","canRedeem":true,"collateralAmount":"232.23123213","productId":"USDT001","yesterdayRealTimeRewards":"0.10293829","cumulativeBonusRewards":"0.22759183","cumulativeRealTimeRewards":"0.22759183","cumulativeTotalRewards":"0.45459183","autoSubscribe":true}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleProductPositionRequest
        {
            Asset = "USDC",
            ProductId = "1",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleProductPositionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/position", seen.Path);
        Assert.Equal("USDC", seen.Param("asset"));
        Assert.Equal("1", seen.Param("productId"));
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
    public async Task GetFlexibleProductPositionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleProductPositionAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleRedemptionRecordAsync()
    {
        const string example = """""{"rows":[{"amount":"10.54000000","asset":"USDT","time":1577257222000,"projectId":"USDT001","redeemId":40607,"destAccount":"SPOT","status":"PAID"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleRedemptionRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/redemptionRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleRedemptionRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"amount":"10.54000000","asset":"USDT","time":1577257222000,"projectId":"USDT001","redeemId":40607,"destAccount":"SPOT","status":"PAID"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleRedemptionRecordRequest
        {
            ProductId = "1",
            RedeemId = "1",
            Asset = "USDC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleRedemptionRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/redemptionRecord", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("1", seen.Param("redeemId"));
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetFlexibleRedemptionRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleRedemptionRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleRewardsHistoryAsync()
    {
        const string example = """""{"rows":[{"asset":"BUSD","rewards":"0.00006408","projectId":"USDT001","type":"BONUS","time":1577233578000}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleRewardsHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/rewardsRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"asset":"BUSD","rewards":"0.00006408","projectId":"USDT001","type":"BONUS","time":1577233578000}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleRewardsHistoryRequest
        {
            ProductId = "1",
            Asset = "USDC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Type = GetFlexibleRewardsHistoryType.Bonus,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/rewardsRecord", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("USDC", seen.Param("asset"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("BONUS", seen.Param("type"));
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
    public async Task GetFlexibleRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleRewardsHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleSubscriptionPreviewAsync()
    {
        const string example = """""{"totalAmount":"1232.32230982","rewardAsset":"BUSD","airDropAsset":"BETH","estDailyBonusRewards":"0.22759183","estDailyRealTimeRewards":"0.22759183","estDailyAirdropRewards":"0.22759183"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleSubscriptionPreviewRequest
        {
            ProductId = "1",
            Amount = 1.0m,
        };

        var response = await client.GetFlexibleSubscriptionPreviewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/subscriptionPreview", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleSubscriptionPreviewWithOptionalParametersAsync()
    {
        const string example = """""{"totalAmount":"1232.32230982","rewardAsset":"BUSD","airDropAsset":"BETH","estDailyBonusRewards":"0.22759183","estDailyRealTimeRewards":"0.22759183","estDailyAirdropRewards":"0.22759183"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleSubscriptionPreviewRequest
        {
            ProductId = "1",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleSubscriptionPreviewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/subscriptionPreview", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleSubscriptionPreviewBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFlexibleSubscriptionPreviewRequest
        {
            ProductId = "1",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleSubscriptionPreviewAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleSubscriptionRecordAsync()
    {
        const string example = """""{"rows":[{"amount":"100.00000000","asset":"USDT","time":1575018510000,"purchaseId":26055,"productId":"USDT001","type":"AUTO","sourceAccount":"SPOT","amtFromSpot":"30","amtFromFunding":"70","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleSubscriptionRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/subscriptionRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleSubscriptionRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"amount":"100.00000000","asset":"USDT","time":1575018510000,"purchaseId":26055,"productId":"USDT001","type":"AUTO","sourceAccount":"SPOT","amtFromSpot":"30","amtFromFunding":"70","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleSubscriptionRecordRequest
        {
            ProductId = "1",
            PurchaseId = "1",
            Asset = "USDC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleSubscriptionRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/subscriptionRecord", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("1", seen.Param("purchaseId"));
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetFlexibleSubscriptionRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleSubscriptionRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLockedPersonalLeftQuotaAsync()
    {
        const string example = """""{"leftPersonalQuota":"1000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedPersonalLeftQuotaRequest
        {
            ProjectId = "1",
        };

        var response = await client.GetLockedPersonalLeftQuotaAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/personalLeftQuota", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLockedPersonalLeftQuotaWithOptionalParametersAsync()
    {
        const string example = """""{"leftPersonalQuota":"1000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedPersonalLeftQuotaRequest
        {
            ProjectId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.GetLockedPersonalLeftQuotaAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/personalLeftQuota", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLockedPersonalLeftQuotaBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetLockedPersonalLeftQuotaRequest
        {
            ProjectId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLockedPersonalLeftQuotaAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLockedProductPositionAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"parentPositionId":123122,"projectId":"Axs*90","asset":"AXS","amount":"122.09202928","purchaseTime":1646182276000,"duration":"60","accrualDays":"4","rewardAsset":"AXS","APY":"0.2032","rewardAmt":"5.17181528","extraRewardAsset":"BNB","extraRewardAPR":"0.0203","estExtraRewardAmt":"5.17181528","boostRewardAsset":"AXS","boostApr":"0.0121","totalBoostRewardAmt":"3.98201829","nextPay":"1.29295383","nextPayDate":1646697600000,"payPeriod":"1","redeemAmountEarly":"2802.24068892","rewardsEndDate":1651449600000,"deliverDate":1651536000000,"redeemPeriod":"1","redeemingAmt":"232.2323","redeemTo":"FLEXIBLE","partialAmtDeliverDate":1651536000000,"canRedeemEarly":true,"canFastRedemption":true,"autoSubscribe":true,"type":"AUTO","status":"HOLDING","canReStake":true}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetLockedProductPositionAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/position", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLockedProductPositionWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"parentPositionId":123122,"projectId":"Axs*90","asset":"AXS","amount":"122.09202928","purchaseTime":1646182276000,"duration":"60","accrualDays":"4","rewardAsset":"AXS","APY":"0.2032","rewardAmt":"5.17181528","extraRewardAsset":"BNB","extraRewardAPR":"0.0203","estExtraRewardAmt":"5.17181528","boostRewardAsset":"AXS","boostApr":"0.0121","totalBoostRewardAmt":"3.98201829","nextPay":"1.29295383","nextPayDate":1646697600000,"payPeriod":"1","redeemAmountEarly":"2802.24068892","rewardsEndDate":1651449600000,"deliverDate":1651536000000,"redeemPeriod":"1","redeemingAmt":"232.2323","redeemTo":"FLEXIBLE","partialAmtDeliverDate":1651536000000,"canRedeemEarly":true,"canFastRedemption":true,"autoSubscribe":true,"type":"AUTO","status":"HOLDING","canReStake":true}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedProductPositionRequest
        {
            Asset = "USDC",
            PositionId = "1",
            ProjectId = "1",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetLockedProductPositionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/position", seen.Path);
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetLockedProductPositionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLockedProductPositionAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLockedRedemptionRecordAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"redeemId":40607,"time":1575018510000,"asset":"BNB","lockPeriod":"30","amount":"21312.23223","originalAmount":"21312.23223","type":"MATURE","deliverDate":1575018510000,"lossAmount":"0.00001232","isComplete":true,"rewardAsset":"AXS","rewardAmt":"5.17181528","extraRewardAsset":"BNB","estExtraRewardAmt":"5.17181528","status":"PAID"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetLockedRedemptionRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/history/redemptionRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLockedRedemptionRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"redeemId":40607,"time":1575018510000,"asset":"BNB","lockPeriod":"30","amount":"21312.23223","originalAmount":"21312.23223","type":"MATURE","deliverDate":1575018510000,"lossAmount":"0.00001232","isComplete":true,"rewardAsset":"AXS","rewardAmt":"5.17181528","extraRewardAsset":"BNB","estExtraRewardAmt":"5.17181528","status":"PAID"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedRedemptionRecordRequest
        {
            PositionId = "1",
            RedeemId = "1",
            Asset = "USDC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetLockedRedemptionRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/history/redemptionRecord", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("1", seen.Param("redeemId"));
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetLockedRedemptionRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLockedRedemptionRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLockedRewardsHistoryAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"time":1575018510000,"asset":"BNB","lockPeriod":"30","amount":"21312.23223","type":"Locked Rewards"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetLockedRewardsHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/history/rewardsRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLockedRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"time":1575018510000,"asset":"BNB","lockPeriod":"30","amount":"21312.23223","type":"Locked Rewards"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedRewardsHistoryRequest
        {
            PositionId = "1",
            Asset = "USDC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetLockedRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/history/rewardsRecord", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetLockedRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLockedRewardsHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLockedSubscriptionPreviewAsync()
    {
        const string example = """""[{"rewardAsset":"AXS","totalRewardAmt":"5.17181528","extraRewardAsset":"BNB","estTotalExtraRewardAmt":"5.17181528","boostRewardAsset":"AXS","estDailyRewardAmt":"1.20928901","nextPay":"1.29295383","nextPayDate":1646697600000,"valueDate":1646697600000,"rewardsEndDate":1651449600000,"deliverDate":1651536000000,"nextSubscriptionDate":1651536000000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedSubscriptionPreviewRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var response = await client.GetLockedSubscriptionPreviewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/subscriptionPreview", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLockedSubscriptionPreviewWithOptionalParametersAsync()
    {
        const string example = """""[{"rewardAsset":"AXS","totalRewardAmt":"5.17181528","extraRewardAsset":"BNB","estTotalExtraRewardAmt":"5.17181528","boostRewardAsset":"AXS","estDailyRewardAmt":"1.20928901","nextPay":"1.29295383","nextPayDate":1646697600000,"valueDate":1646697600000,"rewardsEndDate":1651449600000,"deliverDate":1651536000000,"nextSubscriptionDate":1651536000000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedSubscriptionPreviewRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
            AutoSubscribe = true,
            RecvWindow = 5000L,
        };

        var response = await client.GetLockedSubscriptionPreviewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/subscriptionPreview", seen.Path);
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
    public async Task GetLockedSubscriptionPreviewBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetLockedSubscriptionPreviewRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLockedSubscriptionPreviewAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLockedSubscriptionRecordAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"purchaseId":"26055","projectId":"Axs*90","time":1575018510000,"asset":"BNB","amount":"21312.23223","lockPeriod":"30","type":"AUTO","sourceAccount":"SPOT","amtFromSpot":"30","amtFromFunding":"70","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetLockedSubscriptionRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/history/subscriptionRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLockedSubscriptionRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"positionId":123123,"purchaseId":"26055","projectId":"Axs*90","time":1575018510000,"asset":"BNB","amount":"21312.23223","lockPeriod":"30","type":"AUTO","sourceAccount":"SPOT","amtFromSpot":"30","amtFromFunding":"70","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLockedSubscriptionRecordRequest
        {
            PurchaseId = "1",
            Asset = "USDC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetLockedSubscriptionRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/history/subscriptionRecord", seen.Path);
        Assert.Equal("1", seen.Param("purchaseId"));
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetLockedSubscriptionRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLockedSubscriptionRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRateHistoryAsync()
    {
        const string example = """""{"rows":[{"productId":"BUSD001","asset":"BUSD","annualPercentageRate":"0.00006408","time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRateHistoryRequest
        {
            ProductId = "1",
        };

        var response = await client.GetRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/rateHistory", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"productId":"BUSD001","asset":"BUSD","annualPercentageRate":"0.00006408","time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRateHistoryRequest
        {
            ProductId = "1",
            AprPeriod = GetRateHistoryAprPeriod.Day,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/history/rateHistory", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("DAY", seen.Param("aprPeriod"));
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
    public async Task GetRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetRateHistoryRequest
        {
            ProductId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRateHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSimpleEarnFlexibleProductListAsync()
    {
        const string example = """""{"rows":[{"asset":"BTC","latestAnnualPercentageRate":"0.05000000","tierAnnualPercentageRate":{"0-5BTC":0.05,"5-10BTC":0.03},"airDropPercentageRate":"0.05000000","canPurchase":true,"canRedeem":true,"isSoldOut":true,"hot":true,"minPurchaseAmount":"0.01000000","productId":"BTC001","subscriptionStartTime":1646182276000,"status":"PURCHASING"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSimpleEarnFlexibleProductListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSimpleEarnFlexibleProductListWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"asset":"BTC","latestAnnualPercentageRate":"0.05000000","tierAnnualPercentageRate":{"0-5BTC":0.05,"5-10BTC":0.03},"airDropPercentageRate":"0.05000000","canPurchase":true,"canRedeem":true,"isSoldOut":true,"hot":true,"minPurchaseAmount":"0.01000000","productId":"BTC001","subscriptionStartTime":1646182276000,"status":"PURCHASING"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSimpleEarnFlexibleProductListRequest
        {
            Asset = "USDC",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSimpleEarnFlexibleProductListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/list", seen.Path);
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetSimpleEarnFlexibleProductListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSimpleEarnFlexibleProductListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSimpleEarnLockedProductListAsync()
    {
        const string example = """""{"rows":[{"projectId":"Axs*90","detail":{"asset":"AXS","rewardAsset":"AXS","duration":90,"renewable":true,"isSoldOut":true,"apr":"1.2069","status":"CREATED","subscriptionStartTime":1646182276000,"extraRewardAsset":"BNB","extraRewardAPR":"0.23","boostRewardAsset":"AXS","boostApr":"0.0121","boostEndTime":1646182276000},"quota":{"totalPersonalQuota":"2","minimum":"0.001"}}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSimpleEarnLockedProductListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSimpleEarnLockedProductListWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"projectId":"Axs*90","detail":{"asset":"AXS","rewardAsset":"AXS","duration":90,"renewable":true,"isSoldOut":true,"apr":"1.2069","status":"CREATED","subscriptionStartTime":1646182276000,"extraRewardAsset":"BNB","extraRewardAPR":"0.23","boostRewardAsset":"AXS","boostApr":"0.0121","boostEndTime":1646182276000},"quota":{"totalPersonalQuota":"2","minimum":"0.001"}}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSimpleEarnLockedProductListRequest
        {
            Asset = "USDC",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSimpleEarnLockedProductListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/list", seen.Path);
        Assert.Equal("USDC", seen.Param("asset"));
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
    public async Task GetSimpleEarnLockedProductListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSimpleEarnLockedProductListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RedeemFlexibleProductAsync()
    {
        const string example = """""{"redeemId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemFlexibleProductRequest
        {
            ProductId = "1",
        };

        var response = await client.RedeemFlexibleProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/redeem", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemFlexibleProductWithOptionalParametersAsync()
    {
        const string example = """""{"redeemId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemFlexibleProductRequest
        {
            ProductId = "1",
            RedeemAll = false,
            Amount = 1.0m,
            DestAccount = RedeemFlexibleProductDestAccount.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.RedeemFlexibleProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/redeem", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("false", seen.Param("redeemAll"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("SPOT", seen.Param("destAccount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemFlexibleProductBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RedeemFlexibleProductRequest
        {
            ProductId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RedeemFlexibleProductAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RedeemLockedProductAsync()
    {
        const string example = """""{"redeemId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemLockedProductRequest
        {
            PositionId = "1",
        };

        var response = await client.RedeemLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/redeem", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemLockedProductWithOptionalParametersAsync()
    {
        const string example = """""{"redeemId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemLockedProductRequest
        {
            PositionId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.RedeemLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/redeem", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemLockedProductBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RedeemLockedProductRequest
        {
            PositionId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RedeemLockedProductAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetFlexibleAutoSubscribeAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetFlexibleAutoSubscribeRequest
        {
            ProductId = "1",
            AutoSubscribe = true,
        };

        var response = await client.SetFlexibleAutoSubscribeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/setAutoSubscribe", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("true", seen.Param("autoSubscribe"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetFlexibleAutoSubscribeWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetFlexibleAutoSubscribeRequest
        {
            ProductId = "1",
            AutoSubscribe = true,
            RecvWindow = 5000L,
        };

        var response = await client.SetFlexibleAutoSubscribeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/setAutoSubscribe", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("true", seen.Param("autoSubscribe"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetFlexibleAutoSubscribeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetFlexibleAutoSubscribeRequest
        {
            ProductId = "1",
            AutoSubscribe = true,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetFlexibleAutoSubscribeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetLockedAutoSubscribeAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetLockedAutoSubscribeRequest
        {
            PositionId = "1",
            AutoSubscribe = true,
        };

        var response = await client.SetLockedAutoSubscribeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/setAutoSubscribe", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("true", seen.Param("autoSubscribe"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetLockedAutoSubscribeWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetLockedAutoSubscribeRequest
        {
            PositionId = "1",
            AutoSubscribe = true,
            RecvWindow = 5000L,
        };

        var response = await client.SetLockedAutoSubscribeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/setAutoSubscribe", seen.Path);
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
    public async Task SetLockedAutoSubscribeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetLockedAutoSubscribeRequest
        {
            PositionId = "1",
            AutoSubscribe = true,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetLockedAutoSubscribeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetLockedProductRedeemOptionAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetLockedProductRedeemOptionRequest
        {
            PositionId = "1",
            RedeemTo = SetLockedProductRedeemOptionRedeemTo.Spot,
        };

        var response = await client.SetLockedProductRedeemOptionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/setRedeemOption", seen.Path);
        Assert.Equal("1", seen.Param("positionId"));
        Assert.Equal("SPOT", seen.Param("redeemTo"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetLockedProductRedeemOptionWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetLockedProductRedeemOptionRequest
        {
            PositionId = "1",
            RedeemTo = SetLockedProductRedeemOptionRedeemTo.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.SetLockedProductRedeemOptionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/setRedeemOption", seen.Path);
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
    public async Task SetLockedProductRedeemOptionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetLockedProductRedeemOptionRequest
        {
            PositionId = "1",
            RedeemTo = SetLockedProductRedeemOptionRedeemTo.Spot,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetLockedProductRedeemOptionAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SimpleAccountAsync()
    {
        const string example = """""{"totalAmountInBTC":"0.01067982","totalAmountInUSDT":"77.13289230","totalFlexibleAmountInBTC":"0.00000000","totalFlexibleAmountInUSDT":"0.00000000","totalLockedInBTC":"0.01067982","totalLockedInUSDT":"77.13289230"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SimpleAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SimpleAccountWithOptionalParametersAsync()
    {
        const string example = """""{"totalAmountInBTC":"0.01067982","totalAmountInUSDT":"77.13289230","totalFlexibleAmountInBTC":"0.00000000","totalFlexibleAmountInUSDT":"0.00000000","totalLockedInBTC":"0.01067982","totalLockedInUSDT":"77.13289230"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SimpleAccountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.SimpleAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SimpleAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SimpleAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubscribeFlexibleProductAsync()
    {
        const string example = """""{"purchaseId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeFlexibleProductRequest
        {
            ProductId = "1",
            Amount = 1.0m,
        };

        var response = await client.SubscribeFlexibleProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/subscribe", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeFlexibleProductWithOptionalParametersAsync()
    {
        const string example = """""{"purchaseId":40607,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeFlexibleProductRequest
        {
            ProductId = "1",
            Amount = 1.0m,
            AutoSubscribe = true,
            SourceAccount = SubscribeFlexibleProductSourceAccount.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.SubscribeFlexibleProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/flexible/subscribe", seen.Path);
        Assert.Equal("1", seen.Param("productId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("true", seen.Param("autoSubscribe"));
        Assert.Equal("SPOT", seen.Param("sourceAccount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeFlexibleProductBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubscribeFlexibleProductRequest
        {
            ProductId = "1",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubscribeFlexibleProductAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubscribeLockedProductAsync()
    {
        const string example = """""{"purchaseId":40607,"positionId":"12345","success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeLockedProductRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var response = await client.SubscribeLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/subscribe", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeLockedProductWithOptionalParametersAsync()
    {
        const string example = """""{"purchaseId":40607,"positionId":"12345","success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeLockedProductRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
            AutoSubscribe = false,
            SourceAccount = SubscribeLockedProductSourceAccount.Spot,
            RedeemTo = SubscribeLockedProductRedeemTo.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.SubscribeLockedProductAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/simple-earn/locked/subscribe", seen.Path);
        Assert.Equal("1", seen.Param("projectId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("false", seen.Param("autoSubscribe"));
        Assert.Equal("SPOT", seen.Param("sourceAccount"));
        Assert.Equal("SPOT", seen.Param("redeemTo"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeLockedProductBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubscribeLockedProductRequest
        {
            ProjectId = "1",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubscribeLockedProductAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
