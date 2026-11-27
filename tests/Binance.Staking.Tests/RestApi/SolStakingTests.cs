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

namespace Binance.Staking.Tests.RestApi.SolStaking;

[Trait("Category", "Native")]
public class SolStakingApiTests
{
    private static StakingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task ClaimBoostRewardsAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ClaimBoostRewardsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/claim", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ClaimBoostRewardsWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ClaimBoostRewardsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.ClaimBoostRewardsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/claim", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ClaimBoostRewardsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ClaimBoostRewardsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBnsolRateHistoryAsync()
    {
        const string example = """""{"rows":[{"annualPercentageRate":"0.00006408","exchangeRate":"1.001212343432","boostRewards":[{"boostAPR":"0.12000000","rewardsAsset":"SOL"}],"time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBnsolRateHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/rateHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBnsolRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"annualPercentageRate":"0.00006408","exchangeRate":"1.001212343432","boostRewards":[{"boostAPR":"0.12000000","rewardsAsset":"SOL"}],"time":1577233578000}],"total":"1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBnsolRateHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetBnsolRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/rateHistory", seen.Path);
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
    public async Task GetBnsolRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBnsolRateHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBnsolRewardsHistoryAsync()
    {
        const string example = """""{"estRewardsInSOL":"1.23230920","rows":[{"time":1575018510000,"amountInSOL":"0.23223","holding":"2.3223","holdingInSOL":"2.4231","annualPercentageRate":"0.5"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetBnsolRewardsHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/bnsolRewardsHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBnsolRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"estRewardsInSOL":"1.23230920","rows":[{"time":1575018510000,"amountInSOL":"0.23223","holding":"2.3223","holdingInSOL":"2.4231","annualPercentageRate":"0.5"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBnsolRewardsHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetBnsolRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/bnsolRewardsHistory", seen.Path);
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
    public async Task GetBnsolRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBnsolRewardsHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetBoostRewardsHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1729520680,"token":"SOL","amount":"1.20291028","bnsolHolding":"2.0928798","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBoostRewardsHistoryRequest
        {
            Type = GetBoostRewardsHistoryType.Claim,
        };

        var response = await client.GetBoostRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/boostRewardsHistory", seen.Path);
        Assert.Equal("CLAIM", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBoostRewardsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1729520680,"token":"SOL","amount":"1.20291028","bnsolHolding":"2.0928798","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBoostRewardsHistoryRequest
        {
            Type = GetBoostRewardsHistoryType.Claim,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetBoostRewardsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/boostRewardsHistory", seen.Path);
        Assert.Equal("CLAIM", seen.Param("type"));
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
    public async Task GetBoostRewardsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetBoostRewardsHistoryRequest
        {
            Type = GetBoostRewardsHistoryType.Claim,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBoostRewardsHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSolRedemptionHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"arrivalTime":1575018510000,"asset":"BNSOL","amount":"21312.23223","distributeAsset":"SOL","distributeAmount":"21338.0699","exchangeRate":"1.00121234","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSolRedemptionHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/redemptionHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSolRedemptionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"arrivalTime":1575018510000,"asset":"BNSOL","amount":"21312.23223","distributeAsset":"SOL","distributeAmount":"21338.0699","exchangeRate":"1.00121234","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSolRedemptionHistoryRequest
        {
            RedeemId = 1234567L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSolRedemptionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/redemptionHistory", seen.Path);
        Assert.Equal("1234567", seen.Param("redeemId"));
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
    public async Task GetSolRedemptionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSolRedemptionHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSolStakingHistoryAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"SOL","amount":"21312.23223","distributeAsset":"BNSOL","distributeAmount":"21286.42584","exchangeRate":"1.00121234","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSolStakingHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/stakingHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSolStakingHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"time":1575018510000,"asset":"SOL","amount":"21312.23223","distributeAsset":"BNSOL","distributeAmount":"21286.42584","exchangeRate":"1.00121234","status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSolStakingHistoryRequest
        {
            PurchaseId = 1234567L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSolStakingHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/stakingHistory", seen.Path);
        Assert.Equal("1234567", seen.Param("purchaseId"));
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
    public async Task GetSolStakingHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSolStakingHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSolStakingQuotaDetailsAsync()
    {
        const string example = """""{"leftStakingPersonalQuota":"1000","leftRedemptionPersonalQuota":"1000","minStakeAmount":"0.01000000","minRedeemAmount":"0.00000001","redeemPeriod":4,"stakeable":true,"redeemable":true,"soldOut":false,"commissionFee":"0.25000000","nextEpochTime":725993969475,"calculating":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSolStakingQuotaDetailsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/quota", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSolStakingQuotaDetailsWithOptionalParametersAsync()
    {
        const string example = """""{"leftStakingPersonalQuota":"1000","leftRedemptionPersonalQuota":"1000","minStakeAmount":"0.01000000","minRedeemAmount":"0.00000001","redeemPeriod":4,"stakeable":true,"redeemable":true,"soldOut":false,"commissionFee":"0.25000000","nextEpochTime":725993969475,"calculating":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSolStakingQuotaDetailsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetSolStakingQuotaDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/quota", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSolStakingQuotaDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSolStakingQuotaDetailsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUnclaimedRewardsAsync()
    {
        const string example = """""[{"amount":"1.00000011","rewardsAsset":"SOL"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetUnclaimedRewardsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/unclaimedRewards", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUnclaimedRewardsWithOptionalParametersAsync()
    {
        const string example = """""[{"amount":"1.00000011","rewardsAsset":"SOL"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUnclaimedRewardsRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetUnclaimedRewardsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/history/unclaimedRewards", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUnclaimedRewardsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUnclaimedRewardsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RedeemSolAsync()
    {
        const string example = """""{"success":true,"solAmount":"0.23092091","redeemId":1234567,"exchangeRate":"1.00121234","arrivalTime":1575018510000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemSolRequest
        {
            Amount = 1.0m,
        };

        var response = await client.RedeemSolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/redeem", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemSolWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"solAmount":"0.23092091","redeemId":1234567,"exchangeRate":"1.00121234","arrivalTime":1575018510000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RedeemSolRequest
        {
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.RedeemSolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/redeem", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RedeemSolBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new RedeemSolRequest
        {
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RedeemSolAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SolStakingAccountAsync()
    {
        const string example = """""{"bnsolAmount":"1.10928781","holdingInSOL":"1.22330928","thirtyDaysProfitInSOL":"0.22330928"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SolStakingAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SolStakingAccountWithOptionalParametersAsync()
    {
        const string example = """""{"bnsolAmount":"1.10928781","holdingInSOL":"1.22330928","thirtyDaysProfitInSOL":"0.22330928"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SolStakingAccountRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.SolStakingAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SolStakingAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SolStakingAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubscribeSolStakingAsync()
    {
        const string example = """""{"success":true,"bnsolAmount":"0.23092091","purchaseId":1234567,"exchangeRate":"1.001212342342"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeSolStakingRequest
        {
            Amount = 1.0m,
        };

        var response = await client.SubscribeSolStakingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/stake", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeSolStakingWithOptionalParametersAsync()
    {
        const string example = """""{"success":true,"bnsolAmount":"0.23092091","purchaseId":1234567,"exchangeRate":"1.001212342342"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubscribeSolStakingRequest
        {
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.SubscribeSolStakingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sol-staking/sol/stake", seen.Path);
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubscribeSolStakingBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubscribeSolStakingRequest
        {
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubscribeSolStakingAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
