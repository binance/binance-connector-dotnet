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

namespace Binance.SimpleEarn.Tests.RestApi.Rwusd;

[Trait("Category", "Native")]
public class RwusdApiTests
{
    private static SimpleEarnRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetRwusdAccountAsync()
    {
        const string example = """""{"rwusdAmount":"100","totalProfit":"12.81"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetRwusdAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdAccountWithOptionalParametersAsync()
    {
        const string example = """""{"rwusdAmount":"100","totalProfit":"12.81"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRwusdAccountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetRwusdAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRwusdAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRwusdQuotaDetailsAsync()
    {
        const string example = """""{"subscriptionQuota":{"assets":["USDT"],"leftQuota":"1000","minimum":"0.10000000"},"fastRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.0005","freeQuota":"100"},"standardRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.001","redeemPeriod":3},"subscribeEnable":true,"redeemEnable":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetRwusdQuotaDetailsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/quota", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdQuotaDetailsWithOptionalParametersAsync()
    {
        const string example = """""{"subscriptionQuota":{"assets":["USDT"],"leftQuota":"1000","minimum":"0.10000000"},"fastRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.0005","freeQuota":"100"},"standardRedemptionQuota":{"leftQuota":"2","minimum":"0.1","fee":"0.001","redeemPeriod":3},"subscribeEnable":true,"redeemEnable":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRwusdQuotaDetailsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetRwusdQuotaDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/quota", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdQuotaDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRwusdQuotaDetailsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRwusdRateHistoryAsync()
    {
        const string example = """""{"rows":[{"annualPercentageRate":"0.0418","time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetRwusdRateHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/rateHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"annualPercentageRate":"0.0418","time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRwusdRateHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetRwusdRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/rateHistory", seen.Path);
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
    public async Task GetRwusdRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRwusdRateHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRwusdRedemptionHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"RWUSD","amount":"51","receiveAsset":"USDC","receiveAmount":"50","fee":"1","arrivalTime":1575018510000,"status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetRwusdRedemptionHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/redemptionHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdRedemptionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"RWUSD","amount":"51","receiveAsset":"USDC","receiveAmount":"50","fee":"1","arrivalTime":1575018510000,"status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRwusdRedemptionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetRwusdRedemptionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/redemptionHistory", seen.Path);
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
    public async Task GetRwusdRedemptionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRwusdRedemptionHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRwusdRewardsHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"rewardsAmount":"1","rwusdPosition":"100","annualPercentageRate":"0.0418"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetRwusdRewardsHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/rewardsHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"rewardsAmount":"1","rwusdPosition":"100","annualPercentageRate":"0.0418"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRwusdRewardsHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetRwusdRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/rewardsHistory", seen.Path);
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
    public async Task GetRwusdRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRwusdRewardsHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetRwusdSubscriptionHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"USDC","amount":"100","receiveAsset":"RWUSD","receiveAmount":"100","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetRwusdSubscriptionHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/subscriptionHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetRwusdSubscriptionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"USDC","amount":"100","receiveAsset":"RWUSD","receiveAmount":"100","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetRwusdSubscriptionHistoryRequest
        {
            Asset = GetRwusdSubscriptionHistoryAsset.Usdc,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetRwusdSubscriptionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/history/subscriptionHistory", seen.Path);
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
    public async Task GetRwusdSubscriptionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetRwusdSubscriptionHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RedeemRwusdAsync()
    {
        const string example = """""{"success":true,"receiveAmount":"0.23092091","fee":"0.00000012","arrivalTime":1575018510000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemRwusdRequest
        {
            Amount = 1.0m,
            Type = RedeemRwusdType.Fast,
        };

        var response = await client.RedeemRwusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/redeem", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("FAST", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemRwusdWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"receiveAmount":"0.23092091","fee":"0.00000012","arrivalTime":1575018510000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemRwusdRequest
        {
            Amount = 1.0m,
            Type = RedeemRwusdType.Fast,
            RecvWindow = 5000L,
        };

        var response = await client.RedeemRwusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/redeem", seen.Path);
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
    public async Task RedeemRwusdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RedeemRwusdRequest
        {
            Amount = 1.0m,
            Type = RedeemRwusdType.Fast,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RedeemRwusdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubscribeRwusdAsync()
    {
        const string example = """""{"success":true,"rwusdAmount":"0.22091092"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeRwusdRequest
        {
            Asset = SubscribeRwusdAsset.Usdt,
            Amount = 1.0m,
        };

        var response = await client.SubscribeRwusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/subscribe", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeRwusdWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"rwusdAmount":"0.22091092"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeRwusdRequest
        {
            Asset = SubscribeRwusdAsset.Usdt,
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.SubscribeRwusdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/rwusd/subscribe", seen.Path);
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
    public async Task SubscribeRwusdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubscribeRwusdRequest
        {
            Asset = SubscribeRwusdAsset.Usdt,
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubscribeRwusdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
