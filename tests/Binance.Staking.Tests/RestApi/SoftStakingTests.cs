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

namespace Binance.Staking.Tests.RestApi.SoftStaking;

[Trait("Category", "Native")]
public class SoftStakingApiTests
{
    private static StakingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetSoftStakingProductListAsync()
    {
        const string example = """""{"status":true,"totalRewardsUsdt":"3.09827182","rows":[{"asset":"BNB","minAmount":"0.5","maxCap":"1000","apr":"0.0015","stakedAmount":"2.14","totalProfit":"0.00171234"}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSoftStakingProductListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/soft-staking/list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSoftStakingProductListWithOptionalParametersAsync()
    {
        const string example = """""{"status":true,"totalRewardsUsdt":"3.09827182","rows":[{"asset":"BNB","minAmount":"0.5","maxCap":"1000","apr":"0.0015","stakedAmount":"2.14","totalProfit":"0.00171234"}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSoftStakingProductListRequest
        {
            Asset = "BTC",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSoftStakingProductListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/soft-staking/list", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
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
    public async Task GetSoftStakingProductListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSoftStakingProductListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSoftStakingRewardsHistoryAsync()
    {
        const string example = """""{"rows":[{"asset":"BNB","rewards":"0.00000557","rewardAsset":"BNB","avgAmount":"2.14","time":1754007978000}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSoftStakingRewardsHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/soft-staking/history/rewardsRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSoftStakingRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"asset":"BNB","rewards":"0.00000557","rewardAsset":"BNB","avgAmount":"2.14","time":1754007978000}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSoftStakingRewardsHistoryRequest
        {
            Asset = "BTC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSoftStakingRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/soft-staking/history/rewardsRecord", seen.Path);
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
    public async Task GetSoftStakingRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSoftStakingRewardsHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SetSoftStakingAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetSoftStakingRequest
        {
            SoftStaking = true,
        };

        var response = await client.SetSoftStakingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/soft-staking/set", seen.Path);
        Assert.Equal("true", seen.Param("softStaking"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetSoftStakingWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SetSoftStakingRequest
        {
            SoftStaking = true,
            RecvWindow = 5000L,
        };

        var response = await client.SetSoftStakingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/soft-staking/set", seen.Path);
        Assert.Equal("true", seen.Param("softStaking"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SetSoftStakingBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SetSoftStakingRequest
        {
            SoftStaking = true,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SetSoftStakingAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
