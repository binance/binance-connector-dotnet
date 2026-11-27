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

namespace Binance.DerivativesTradingUsdsFutures.Tests.RestApi.Convert;

[Trait("Category", "Native")]
public class ConvertApiTests
{
    private static DerivativesTradingUsdsFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AcceptTheOfferedQuoteAsync()
    {
        const string example = """""{"orderId":"933256278426274426","createTime":1623381330472,"orderStatus":"PROCESS"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AcceptTheOfferedQuoteRequest
        {
            QuoteId = "1",
        };

        var response = await client.AcceptTheOfferedQuoteAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/convert/acceptQuote", seen.Path);
        Assert.Equal("1", seen.Param("quoteId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcceptTheOfferedQuoteWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":"933256278426274426","createTime":1623381330472,"orderStatus":"PROCESS"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AcceptTheOfferedQuoteRequest
        {
            QuoteId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.AcceptTheOfferedQuoteAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/convert/acceptQuote", seen.Path);
        Assert.Equal("1", seen.Param("quoteId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcceptTheOfferedQuoteBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AcceptTheOfferedQuoteRequest
        {
            QuoteId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AcceptTheOfferedQuoteAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ListAllConvertPairsAsync()
    {
        const string example = """""[{"fromAsset":"BTC","toAsset":"USDT","fromAssetMinAmount":"0.0004","fromAssetMaxAmount":"50","toAssetMinAmount":"20","toAssetMaxAmount":"2500000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ListAllConvertPairsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/convert/exchangeInfo", seen.Path);
        Assert.Null(seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListAllConvertPairsWithOptionalParametersAsync()
    {
        const string example = """""[{"fromAsset":"BTC","toAsset":"USDT","fromAssetMinAmount":"0.0004","fromAssetMaxAmount":"50","toAssetMinAmount":"20","toAssetMaxAmount":"2500000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ListAllConvertPairsRequest
        {
            FromAsset = "BTC",
            ToAsset = "USDT",
        };

        var response = await client.ListAllConvertPairsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/convert/exchangeInfo", seen.Path);
        Assert.Equal("BTC", seen.Param("fromAsset"));
        Assert.Equal("USDT", seen.Param("toAsset"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ListAllConvertPairsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ListAllConvertPairsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderStatusAsync()
    {
        const string example = """""{"orderId":933256278426274400,"orderStatus":"SUCCESS","fromAsset":"BTC","fromAmount":"0.00054414","toAsset":"USDT","toAmount":"20","ratio":"36755","inverseRatio":"0.00002721","createTime":1623381330472}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OrderStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/convert/orderStatus", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderStatusWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":933256278426274400,"orderStatus":"SUCCESS","fromAsset":"BTC","fromAmount":"0.00054414","toAsset":"USDT","toAmount":"20","ratio":"36755","inverseRatio":"0.00002721","createTime":1623381330472}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderStatusRequest
        {
            OrderId = "933256278426274400",
            QuoteId = "1",
        };

        var response = await client.OrderStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/convert/orderStatus", seen.Path);
        Assert.Equal("933256278426274400", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("quoteId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SendQuoteRequestAsync()
    {
        const string example = """""{"quoteId":"12415572564","ratio":"38163.7","inverseRatio":"0.0000262","validTimestamp":1623319461670,"toAmount":"3816.37","fromAmount":"0.1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SendQuoteRequestRequest
        {
            FromAsset = "BTC",
            ToAsset = "USDT",
        };

        var response = await client.SendQuoteRequestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/convert/getQuote", seen.Path);
        Assert.Equal("BTC", seen.Param("fromAsset"));
        Assert.Equal("USDT", seen.Param("toAsset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SendQuoteRequestWithOptionalParametersAsync()
    {
        const string example = """""{"quoteId":"12415572564","ratio":"38163.7","inverseRatio":"0.0000262","validTimestamp":1623319461670,"toAmount":"3816.37","fromAmount":"0.1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SendQuoteRequestRequest
        {
            FromAsset = "BTC",
            ToAsset = "USDT",
            FromAmount = 1.0m,
            ToAmount = 1.0m,
            ValidTime = "10s",
            RecvWindow = 5000L,
        };

        var response = await client.SendQuoteRequestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/convert/getQuote", seen.Path);
        Assert.Equal("BTC", seen.Param("fromAsset"));
        Assert.Equal("USDT", seen.Param("toAsset"));
        Assert.Equal("1.0", seen.Param("fromAmount"));
        Assert.Equal("1.0", seen.Param("toAmount"));
        Assert.Equal("10s", seen.Param("validTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SendQuoteRequestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SendQuoteRequestRequest
        {
            FromAsset = "BTC",
            ToAsset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SendQuoteRequestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
