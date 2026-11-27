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

namespace Binance.SimpleEarn.Tests.RestApi.Bfusd;

[Trait("Category", "Native")]
public class BfusdApiTests
{
    private static SimpleEarnRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetBfusdAccountAsync()
    {
        const string example = """""{"bfusdAmount":"100","usdtProfit":"11.00","bfusdProfit":"1.81"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBfusdAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdAccountWithOptionalParametersAsync()
    {
        const string example = """""{"bfusdAmount":"100","usdtProfit":"11.00","bfusdProfit":"1.81"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBfusdAccountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetBfusdAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBfusdAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBfusdQuotaDetailsAsync()
    {
        const string example = """""{"subscriptionQuota":{"leftQuota":"1000"},"fastRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.001","freeQuota":"100"},"standardRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.0005","redeemPeriod":3}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBfusdQuotaDetailsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/quota", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdQuotaDetailsWithOptionalParametersAsync()
    {
        const string example = """""{"subscriptionQuota":{"leftQuota":"1000"},"fastRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.001","freeQuota":"100"},"standardRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.0005","redeemPeriod":3}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBfusdQuotaDetailsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetBfusdQuotaDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/quota", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdQuotaDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBfusdQuotaDetailsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBfusdRateHistoryAsync()
    {
        const string example = """""{"rows":[{"annualPercentageRate":"0.0418","time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBfusdRateHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/rateHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"annualPercentageRate":"0.0418","time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBfusdRateHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetBfusdRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/rateHistory", seen.Path);
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
    public async Task GetBfusdRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBfusdRateHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBfusdRedemptionHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"BFUSD","amount":"51","receiveAsset":"USDT","receiveAmount":"50","fee":"1","arrivalTime":1575018510000,"status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBfusdRedemptionHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/redemptionHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdRedemptionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"BFUSD","amount":"51","receiveAsset":"USDT","receiveAmount":"50","fee":"1","arrivalTime":1575018510000,"status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBfusdRedemptionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetBfusdRedemptionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/redemptionHistory", seen.Path);
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
    public async Task GetBfusdRedemptionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBfusdRedemptionHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBfusdRewardsHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"rewardAsset":"BFUSD","rewardsAmount":"1","BFUSDPosition":"100","annualPercentageRate":"0.0418"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBfusdRewardsHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/rewardsHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"rewardAsset":"BFUSD","rewardsAmount":"1","BFUSDPosition":"100","annualPercentageRate":"0.0418"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBfusdRewardsHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetBfusdRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/rewardsHistory", seen.Path);
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
    public async Task GetBfusdRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBfusdRewardsHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBfusdSubscriptionHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"USDT","amount":"100","receiveAsset":"BFUSD","receiveAmount":"100","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBfusdSubscriptionHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/subscriptionHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBfusdSubscriptionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"USDT","amount":"100","receiveAsset":"BFUSD","receiveAmount":"100","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBfusdSubscriptionHistoryRequest
        {
            Asset = GetBfusdSubscriptionHistoryAsset.Usdc,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetBfusdSubscriptionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/history/subscriptionHistory", seen.Path);
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
    public async Task GetBfusdSubscriptionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBfusdSubscriptionHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RedeemBfusdAsync()
    {
        const string example = """""{"success":true,"receiveAmount":"0.23092091","fee":"0.00000012","arrivalTime":1575018510000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemBfusdRequest
        {
            Amount = 1.0m,
            Type = RedeemBfusdType.Fast,
        };

        var response = await client.RedeemBfusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/redeem", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("FAST", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemBfusdWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"receiveAmount":"0.23092091","fee":"0.00000012","arrivalTime":1575018510000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemBfusdRequest
        {
            Amount = 1.0m,
            Type = RedeemBfusdType.Fast,
            RecvWindow = 5000L,
        };

        var response = await client.RedeemBfusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/redeem", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("FAST", seen.Param("type"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemBfusdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RedeemBfusdRequest
        {
            Amount = 1.0m,
            Type = RedeemBfusdType.Fast,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RedeemBfusdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubscribeBfusdAsync()
    {
        const string example = """""{"success":true,"bfusdAmount":"0.22091092"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeBfusdRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
        };

        var response = await client.SubscribeBfusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/subscribe", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeBfusdWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"bfusdAmount":"0.22091092"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeBfusdRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.SubscribeBfusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/bfusd/subscribe", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeBfusdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubscribeBfusdRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubscribeBfusdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
