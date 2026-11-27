//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingUsdsFutures.RestApi;

namespace Binance.DerivativesTradingUsdsFutures.Tests.RestApi.PortfolioMarginEndpoints;

[Trait("Category", "Native")]
public class PortfolioMarginEndpointsApiTests
{
    private static DerivativesTradingUsdsFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task ClassicPortfolioMarginAccountInformationAsync()
    {
        const string example = """""{"maxWithdrawAmountUSD":"1627523.32459208","asset":"BTC","maxWithdrawAmount":"27.43689636"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ClassicPortfolioMarginAccountInformationRequest
        {
            Asset = "BTC",
        };

        var response = await client.ClassicPortfolioMarginAccountInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/pmAccountInfo", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ClassicPortfolioMarginAccountInformationWithOptionalParametersAsync()
    {
        const string example = """""{"maxWithdrawAmountUSD":"1627523.32459208","asset":"BTC","maxWithdrawAmount":"27.43689636"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ClassicPortfolioMarginAccountInformationRequest
        {
            Asset = "BTC",
            RecvWindow = 5000L,
        };

        var response = await client.ClassicPortfolioMarginAccountInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/pmAccountInfo", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ClassicPortfolioMarginAccountInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ClassicPortfolioMarginAccountInformationRequest
        {
            Asset = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ClassicPortfolioMarginAccountInformationAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
