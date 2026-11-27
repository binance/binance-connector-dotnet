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

namespace Binance.SimpleEarn.Tests.RestApi.YieldArena;

[Trait("Category", "Native")]
public class YieldArenaApiTests
{
    private static SimpleEarnRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetYieldArenaActivitiesAsync()
    {
        const string example = """""{"activities":[{"activityId":10001,"activityType":"AIRDROP","title":"Hold FDUSD & Earn BNB Airdrop","description":"Subscribe to FDUSD Flexible and earn bonus BNB airdrop.","rewardPoolInUsd":"50000","rewardToken":["BNB"],"redirectUrl":"https://www.binance.com/en/earn/arena/airdrop-123","startTime":1713052800000,"endTime":1713657600000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetYieldArenaActivitiesAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/earn/arena/activities", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetYieldArenaActivitiesWithOptionalParametersAsync()
    {
        const string example = """""{"activities":[{"activityId":10001,"activityType":"AIRDROP","title":"Hold FDUSD & Earn BNB Airdrop","description":"Subscribe to FDUSD Flexible and earn bonus BNB airdrop.","rewardPoolInUsd":"50000","rewardToken":["BNB"],"redirectUrl":"https://www.binance.com/en/earn/arena/airdrop-123","startTime":1713052800000,"endTime":1713657600000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetYieldArenaActivitiesRequest
        {
            Lang = "en",
            RecvWindow = 5000L,
        };

        var response = await client.GetYieldArenaActivitiesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/earn/arena/activities", seen.Path);
        Assert.Equal("en", seen.Header("lang"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetYieldArenaActivitiesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetYieldArenaActivitiesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
