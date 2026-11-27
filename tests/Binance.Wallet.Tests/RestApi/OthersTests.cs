//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Wallet.RestApi;

namespace Binance.Wallet.Tests.RestApi.Others;

[Trait("Category", "Native")]
public class OthersApiTests
{
    private static WalletRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetSymbolsDelistScheduleForSpotAsync()
    {
        const string example = """""[{"delistTime":1686161202000,"symbols":["ADAUSDT"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSymbolsDelistScheduleForSpotAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/spot/delist-schedule", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSymbolsDelistScheduleForSpotWithOptionalParametersAsync()
    {
        const string example = """""[{"delistTime":1686161202000,"symbols":["ADAUSDT"]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSymbolsDelistScheduleForSpotRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetSymbolsDelistScheduleForSpotAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/spot/delist-schedule", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSymbolsDelistScheduleForSpotBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSymbolsDelistScheduleForSpotAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SystemStatusAsync()
    {
        const string example = """""{"status":0,"msg":"normal"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.SystemStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/system/status", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SystemStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SystemStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
