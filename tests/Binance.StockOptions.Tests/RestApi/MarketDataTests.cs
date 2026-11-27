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

namespace Binance.StockOptions.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static StockOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task OptionContractsAsync()
    {
        const string example = """""[{"symbol":"NVDA260930C00100000","contractType":"CALL","strikePrice":"100","multiplier":"100","contractSize":100,"expirationDate":"2026-09-30","status":"OPEN_CLOSE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionContractsRequest
        {
            UnderlyingSymbol = "NVDA",
            ExpirationDate = "2026-09-30",
        };

        var response = await client.OptionContractsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/market/contracts", seen.Path);
        Assert.Equal("NVDA", seen.Param("underlyingSymbol"));
        Assert.Equal("2026-09-30", seen.Param("expirationDate"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionContractsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"NVDA260930C00100000","contractType":"CALL","strikePrice":"100","multiplier":"100","contractSize":100,"expirationDate":"2026-09-30","status":"OPEN_CLOSE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionContractsRequest
        {
            UnderlyingSymbol = "NVDA",
            ExpirationDate = "2026-09-30",
            RootSymbol = "NVDA",
        };

        var response = await client.OptionContractsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/market/contracts", seen.Path);
        Assert.Equal("NVDA", seen.Param("underlyingSymbol"));
        Assert.Equal("2026-09-30", seen.Param("expirationDate"));
        Assert.Equal("NVDA", seen.Param("rootSymbol"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionContractsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OptionContractsRequest
        {
            UnderlyingSymbol = "NVDA",
            ExpirationDate = "2026-09-30",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionContractsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionExchangeInfoAsync()
    {
        const string example = """""{"timezone":"UTC","symbols":[{"symbol":"NVDA260930C00100000","underlyingSymbol":"NVDA","rootSymbol":"NVDA","contractType":"CALL","status":"OPEN_CLOSE","strikePrice":"100","expirationDate":1790784000000,"multiplier":"100","contractSize":100,"tickSize":"0.01","stepSize":"1","minQty":"1","maxQty":"100000","minNotional":"1","maxNotional":"500000","optionsLateClose":false,"pennyProgram":true,"deliverables":[{"type":"EQUITY","symbol":"NVDA","amount":"100"}]}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionExchangeInfoRequest
        {
            Symbol = "NVDA260930C00100000",
        };

        var response = await client.OptionExchangeInfoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/market/exchangeInfo", seen.Path);
        Assert.Equal("NVDA260930C00100000", seen.Param("symbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionExchangeInfoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OptionExchangeInfoRequest
        {
            Symbol = "NVDA260930C00100000",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionExchangeInfoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionExpirationsAsync()
    {
        const string example = """""[{"expirationDate":"2026-09-30","rootSymbol":"NVDA"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionExpirationsRequest
        {
            UnderlyingSymbol = "NVDA",
        };

        var response = await client.OptionExpirationsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/market/expirations", seen.Path);
        Assert.Equal("NVDA", seen.Param("underlyingSymbol"));
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionExpirationsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OptionExpirationsRequest
        {
            UnderlyingSymbol = "NVDA",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionExpirationsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
