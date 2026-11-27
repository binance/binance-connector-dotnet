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

namespace Binance.StockOptions.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static StockOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CancelAllOptionOrdersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CancelAllOptionOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/cancel-all", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOptionOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllOptionOrdersRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllOptionOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/cancel-all", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOptionOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllOptionOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelOptionOrderAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","status":"S"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelOptionOrderRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
        };

        var response = await client.CancelOptionOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/cancel", seen.Path);
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelOptionOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","status":"S"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelOptionOrderRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
            RecvWindow = 5000L,
        };

        var response = await client.CancelOptionOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/cancel", seen.Path);
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelOptionOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelOptionOrderRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelOptionOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PlaceOptionOrderAsync()
    {
        const string example = """""{"status":"S","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceOptionOrderRequest
        {
            Symbol = "NVDA260930C00100000",
            Side = PlaceOptionOrderSide.Buy,
            Quantity = "1",
            Price = "1.5",
        };

        var response = await client.PlaceOptionOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/place", seen.Path);
        Assert.Equal("NVDA260930C00100000", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1.5", seen.Param("price"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceOptionOrderWithOptionalParametersAsync()
    {
        const string example = """""{"status":"S","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceOptionOrderRequest
        {
            Symbol = "NVDA260930C00100000",
            Side = PlaceOptionOrderSide.Buy,
            Quantity = "1",
            Price = "1.5",
            QuoteAsset = "USDC",
            PositionIntent = PlaceOptionOrderPositionIntent.BuyToOpen,
            TimeInForce = PlaceOptionOrderTimeInForce.Day,
            WalletType = PlaceOptionOrderWalletType.Card,
            ClientOrderId = "web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a",
            RecvWindow = 5000L,
        };

        var response = await client.PlaceOptionOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/order/place", seen.Path);
        Assert.Equal("NVDA260930C00100000", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1.5", seen.Param("price"));
        Assert.Equal("USDC", seen.Param("quoteAsset"));
        Assert.Equal("BUY_TO_OPEN", seen.Param("positionIntent"));
        Assert.Equal("DAY", seen.Param("timeInForce"));
        Assert.Equal("CARD", seen.Param("walletType"));
        Assert.Equal("web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a", seen.Param("clientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceOptionOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new PlaceOptionOrderRequest
        {
            Symbol = "NVDA260930C00100000",
            Side = PlaceOptionOrderSide.Buy,
            Quantity = "1",
            Price = "1.5",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PlaceOptionOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SubmitOptionExerciseAsync()
    {
        const string example = """""{"tranId":1234567890,"clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubmitOptionExerciseRequest
        {
            Symbol = "NVDA260930C00100000",
            Quantity = "1",
        };

        var response = await client.SubmitOptionExerciseAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/submit", seen.Path);
        Assert.Equal("NVDA260930C00100000", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubmitOptionExerciseWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":1234567890,"clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","status":"PROCESSING"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SubmitOptionExerciseRequest
        {
            Symbol = "NVDA260930C00100000",
            Quantity = "1",
            QuoteAsset = "USDC",
            ClientOrderId = "web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a",
            RecvWindow = 5000L,
        };

        var response = await client.SubmitOptionExerciseAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/option/exercise/submit", seen.Path);
        Assert.Equal("NVDA260930C00100000", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("USDC", seen.Param("quoteAsset"));
        Assert.Equal("web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a", seen.Param("clientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SubmitOptionExerciseBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SubmitOptionExerciseRequest
        {
            Symbol = "NVDA260930C00100000",
            Quantity = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SubmitOptionExerciseAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
