//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingPortfolioMarginPro.RestApi;

namespace Binance.DerivativesTradingPortfolioMarginPro.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static DerivativesTradingPortfolioMarginProRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetPortfolioMarginAssetLeverageAsync()
    {
        const string example = """""[{"asset":"USDC","leverage":10}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetPortfolioMarginAssetLeverageAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/margin-asset-leverage", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginAssetLeverageBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPortfolioMarginAssetLeverageAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetPortfolioMarginTieredCollateralRatesAsync()
    {
        const string example = """""[{"asset":"BNB","collateralInfo":[{"tierFloor":"0.0000","tierCap":"1000.0000","collateralRate":"1.0000","cum":"0.0000"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetPortfolioMarginTieredCollateralRatesAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/portfolio/retail/collateralRate", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPortfolioMarginTieredCollateralRatesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPortfolioMarginTieredCollateralRatesAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PortfolioMarginCollateralRateAsync()
    {
        const string example = """""[{"asset":"USDC","collateralRate":"1.0000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.PortfolioMarginCollateralRateAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/collateralRate", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PortfolioMarginCollateralRateBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PortfolioMarginCollateralRateAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PortfolioMarginProTieredCollateralRateAsync()
    {
        const string example = """""[{"asset":"BNB","collateralInfo":[{"tierFloor":"0.0000","tierCap":"1000.0000","collateralRate":"1.0000","cum":"0.0000"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.PortfolioMarginProTieredCollateralRateAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/portfolio/collateralRate", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PortfolioMarginProTieredCollateralRateWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"BNB","collateralInfo":[{"tierFloor":"0.0000","tierCap":"1000.0000","collateralRate":"1.0000","cum":"0.0000"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PortfolioMarginProTieredCollateralRateRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.PortfolioMarginProTieredCollateralRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/portfolio/collateralRate", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PortfolioMarginProTieredCollateralRateBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PortfolioMarginProTieredCollateralRateAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPortfolioMarginAssetIndexPriceAsync()
    {
        const string example = """""[{"asset":"BTC","assetIndexPrice":"28251.9136906","time":1683518338121}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryPortfolioMarginAssetIndexPriceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/asset-index-price", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginAssetIndexPriceWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"BTC","assetIndexPrice":"28251.9136906","time":1683518338121}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPortfolioMarginAssetIndexPriceRequest
        {
            Asset = "BTC",
        };

        var response = await client.QueryPortfolioMarginAssetIndexPriceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/portfolio/asset-index-price", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPortfolioMarginAssetIndexPriceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPortfolioMarginAssetIndexPriceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
