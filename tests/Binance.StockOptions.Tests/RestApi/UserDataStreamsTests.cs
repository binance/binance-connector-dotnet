//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.StockOptions.RestApi;

namespace Binance.StockOptions.Tests.RestApi.UserDataStreams;

[Trait("Category", "Native")]
public class UserDataStreamsApiTests
{
    private static StockOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CreateRenewListenKeyAsync()
    {
        const string example = """""{"listenKey":"3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CreateRenewListenKeyAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/listenKey", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateRenewListenKeyWithOptionalParametersAsync()
    {
        const string example = """""{"listenKey":"3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateRenewListenKeyRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.CreateRenewListenKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/listenKey", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateRenewListenKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateRenewListenKeyAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
