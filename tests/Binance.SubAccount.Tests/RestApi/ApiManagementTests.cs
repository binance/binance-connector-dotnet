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

namespace Binance.SubAccount.Tests.RestApi.ApiManagement;

[Trait("Category", "Native")]
public class ApiManagementApiTests
{
    private static SubAccountRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AddIpRestrictionForSubAccountApiKeyAsync()
    {
        const string example = """""{"status":"2","ipList":["69.210.67.14"],"updateTime":1636371437000,"apiKey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AddIpRestrictionForSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            Status = 1L,
        };

        var response = await client.AddIpRestrictionForSubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/subAccountApi/ipRestriction", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("1", seen.Param("status"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AddIpRestrictionForSubAccountApiKeyWithOptionalParametersAsync()
    {
        const string example = """""{"status":"2","ipList":["69.210.67.14"],"updateTime":1636371437000,"apiKey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AddIpRestrictionForSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            Status = 1L,
            IpAddress = "69.210.67.14",
            RecvWindow = 5000L,
        };

        var response = await client.AddIpRestrictionForSubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/subAccountApi/ipRestriction", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("1", seen.Param("status"));
        Assert.Equal("69.210.67.14", seen.Param("ipAddress"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AddIpRestrictionForSubAccountApiKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AddIpRestrictionForSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            Status = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AddIpRestrictionForSubAccountApiKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CreateSubAccountApiKeyAsync()
    {
        const string example = """""{"apiName":"myKey","apiKey":"vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A","secretKey":"NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":false,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"status":2,"ipList":["69.210.67.14"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            ApiName = "myKey",
            Status = 2L,
        };

        var response = await client.CreateSubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("myKey", seen.Param("apiName"));
        Assert.Equal("2", seen.Param("status"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateSubAccountApiKeyWithOptionalParametersAsync()
    {
        const string example = """""{"apiName":"myKey","apiKey":"vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A","secretKey":"NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":false,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"status":2,"ipList":["69.210.67.14"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            ApiName = "myKey",
            Status = 2L,
            CanTrade = true,
            CanMarginLoanRepay = false,
            CanFuturesTrade = false,
            CanUniversalTransfer = false,
            CanVanillaOptions = false,
            CanFixApiTrading = true,
            CanFixApiReading = false,
            IpAddress = "69.210.67.14",
            ThirdPartyName = "thirdParty",
            PublicKey = "string",
            RecvWindow = 5000L,
        };

        var response = await client.CreateSubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("myKey", seen.Param("apiName"));
        Assert.Equal("2", seen.Param("status"));
        Assert.Equal("true", seen.Param("canTrade"));
        Assert.Equal("false", seen.Param("canMarginLoanRepay"));
        Assert.Equal("false", seen.Param("canFuturesTrade"));
        Assert.Equal("false", seen.Param("canUniversalTransfer"));
        Assert.Equal("false", seen.Param("canVanillaOptions"));
        Assert.Equal("true", seen.Param("canFixApiTrading"));
        Assert.Equal("false", seen.Param("canFixApiReading"));
        Assert.Equal("69.210.67.14", seen.Param("ipAddress"));
        Assert.Equal("thirdParty", seen.Param("thirdPartyName"));
        Assert.Equal("string", seen.Param("publicKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateSubAccountApiKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            ApiName = "myKey",
            Status = 2L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateSubAccountApiKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CreateSubAccountApiKeyV2Async()
    {
        const string example = """""{"apiName":"myKey","apiKey":"vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A","secretKey":"NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":false,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"status":2,"ipList":["69.210.67.14"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateSubAccountApiKeyV2Request
        {
            Email = "123@test.com",
            ApiName = "my-fix-api",
            Status = 2L,
        };

        var response = await client.CreateSubAccountApiKeyV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("my-fix-api", seen.Param("apiName"));
        Assert.Equal("2", seen.Param("status"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateSubAccountApiKeyV2WithOptionalParametersAsync()
    {
        const string example = """""{"apiName":"myKey","apiKey":"vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A","secretKey":"NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":false,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"status":2,"ipList":["69.210.67.14"]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateSubAccountApiKeyV2Request
        {
            Email = "123@test.com",
            ApiName = "my-fix-api",
            Status = 2L,
            CanTrade = true,
            CanMarginLoanRepay = false,
            CanFuturesTrade = false,
            CanUniversalTransfer = false,
            CanVanillaOptions = false,
            CanFixApiTrading = true,
            CanFixApiReading = true,
            IpAddress = "1.2.3.4",
            ThirdPartyName = "thirdParty",
            PublicKey = "-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEAptEM59ao3nOD2baduIA830qZU4k4mqfvv7PwHVAfZhg=\n-----END PUBLIC KEY-----",
            RecvWindow = 5000L,
        };

        var response = await client.CreateSubAccountApiKeyV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("my-fix-api", seen.Param("apiName"));
        Assert.Equal("2", seen.Param("status"));
        Assert.Equal("true", seen.Param("canTrade"));
        Assert.Equal("false", seen.Param("canMarginLoanRepay"));
        Assert.Equal("false", seen.Param("canFuturesTrade"));
        Assert.Equal("false", seen.Param("canUniversalTransfer"));
        Assert.Equal("false", seen.Param("canVanillaOptions"));
        Assert.Equal("true", seen.Param("canFixApiTrading"));
        Assert.Equal("true", seen.Param("canFixApiReading"));
        Assert.Equal("1.2.3.4", seen.Param("ipAddress"));
        Assert.Equal("thirdParty", seen.Param("thirdPartyName"));
        Assert.Equal("-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEAptEM59ao3nOD2baduIA830qZU4k4mqfvv7PwHVAfZhg=\n-----END PUBLIC KEY-----", seen.Param("publicKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateSubAccountApiKeyV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateSubAccountApiKeyV2Request
        {
            Email = "123@test.com",
            ApiName = "my-fix-api",
            Status = 2L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateSubAccountApiKeyV2Async(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DeleteIpListForASubAccountApiKeyAsync()
    {
        const string example = """""{"ipRestrict":"true","ipList":["69.210.67.14"],"updateTime":1636371437000,"apiKey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteIpListForASubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            IpAddress = "69.210.67.14",
        };

        var response = await client.DeleteIpListForASubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("69.210.67.14", seen.Param("ipAddress"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteIpListForASubAccountApiKeyWithOptionalParametersAsync()
    {
        const string example = """""{"ipRestrict":"true","ipList":["69.210.67.14"],"updateTime":1636371437000,"apiKey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteIpListForASubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            IpAddress = "69.210.67.14",
            RecvWindow = 5000L,
        };

        var response = await client.DeleteIpListForASubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("69.210.67.14", seen.Param("ipAddress"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteIpListForASubAccountApiKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DeleteIpListForASubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            IpAddress = "69.210.67.14",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DeleteIpListForASubAccountApiKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DeleteSubAccountApiKeyAsync()
    {
        const string example = """""{}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
        };

        var response = await client.DeleteSubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteSubAccountApiKeyWithOptionalParametersAsync()
    {
        const string example = """""{}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            RecvWindow = 5000L,
        };

        var response = await client.DeleteSubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteSubAccountApiKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DeleteSubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DeleteSubAccountApiKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetIpRestrictionForASubAccountApiKeyAsync()
    {
        const string example = """""{"ipRestrict":"true","ipList":["69.210.67.14"],"updateTime":1636371437000,"apiKey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetIpRestrictionForASubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
        };

        var response = await client.GetIpRestrictionForASubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi/ipRestriction", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetIpRestrictionForASubAccountApiKeyWithOptionalParametersAsync()
    {
        const string example = """""{"ipRestrict":"true","ipList":["69.210.67.14"],"updateTime":1636371437000,"apiKey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetIpRestrictionForASubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            RecvWindow = 5000L,
        };

        var response = await client.GetIpRestrictionForASubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi/ipRestriction", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetIpRestrictionForASubAccountApiKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetIpRestrictionForASubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetIpRestrictionForASubAccountApiKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifySubAccountApiKeyPermissionAsync()
    {
        const string example = """""{"apiName":"myKey","apikey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":true,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"timestamp":1640000000000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifySubAccountApiKeyPermissionRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
        };

        var response = await client.ModifySubAccountApiKeyPermissionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApiPermission", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifySubAccountApiKeyPermissionWithOptionalParametersAsync()
    {
        const string example = """""{"apiName":"myKey","apikey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":true,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"timestamp":1640000000000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifySubAccountApiKeyPermissionRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            CanTrade = true,
            CanMarginLoanRepay = false,
            CanFuturesTrade = true,
            CanUniversalTransfer = false,
            CanVanillaOptions = false,
            CanFixApiTrading = true,
            CanFixApiReading = false,
            RecvWindow = 5000L,
        };

        var response = await client.ModifySubAccountApiKeyPermissionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApiPermission", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("true", seen.Param("canTrade"));
        Assert.Equal("false", seen.Param("canMarginLoanRepay"));
        Assert.Equal("true", seen.Param("canFuturesTrade"));
        Assert.Equal("false", seen.Param("canUniversalTransfer"));
        Assert.Equal("false", seen.Param("canVanillaOptions"));
        Assert.Equal("true", seen.Param("canFixApiTrading"));
        Assert.Equal("false", seen.Param("canFixApiReading"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifySubAccountApiKeyPermissionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ModifySubAccountApiKeyPermissionRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ModifySubAccountApiKeyPermissionAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySubAccountApiKeyAsync()
    {
        const string example = """""{"total":1,"rows":[{"email":"123@test.com","apiName":"myKey","apikey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":false,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"timestamp":1640000000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountApiKeyRequest
        {
            Email = "123@test.com",
        };

        var response = await client.QuerySubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountApiKeyWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"rows":[{"email":"123@test.com","apiName":"myKey","apikey":"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf","canTrade":true,"canMarginLoanRepay":false,"canFuturesTrade":false,"canUniversalTransfer":false,"canVanillaOptions":false,"canFixApiTrading":true,"canFixApiReading":false,"timestamp":1640000000000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySubAccountApiKeyRequest
        {
            Email = "123@test.com",
            SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            Page = 1L,
            Size = 30L,
            RecvWindow = 5000L,
        };

        var response = await client.QuerySubAccountApiKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/sub-account/subAccountApi", seen.Path);
        Assert.Equal("123@test.com", seen.Param("email"));
        Assert.Equal("k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf", seen.Param("subAccountApiKey"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("30", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySubAccountApiKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySubAccountApiKeyRequest
        {
            Email = "123@test.com",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySubAccountApiKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
