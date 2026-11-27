//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Stocks.RestApi;

namespace Binance.Stocks.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static StocksRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CancelAllEquityOrdersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CancelAllEquityOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/cancel-all", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllEquityOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllEquityOrdersRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllEquityOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/cancel-all", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllEquityOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllEquityOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelEquityOrderAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","status":"S"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelEquityOrderRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
        };

        var response = await client.CancelEquityOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/cancel", seen.Path);
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelEquityOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","status":"S"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelEquityOrderRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
            RecvWindow = 5000L,
        };

        var response = await client.CancelEquityOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/cancel", seen.Path);
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelEquityOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelEquityOrderRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelEquityOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CurrentOpenOrdersAsync()
    {
        const string example = """""[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"180.50","avgFilledPrice":"avgFilledPrice","qty":"1","notional":"notional","filledQty":"0","filledTotal":"filledTotal","fee":"0","session":"RTH","status":"NEW","createdAt":1735900000000,"updatedAt":1735900000000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CurrentOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/open-orders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"180.50","avgFilledPrice":"avgFilledPrice","qty":"1","notional":"notional","filledQty":"0","filledTotal":"filledTotal","fee":"0","session":"RTH","status":"NEW","createdAt":1735900000000,"updatedAt":1735900000000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CurrentOpenOrdersRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.CurrentOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/open-orders", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CurrentOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EquityOrderDetailAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"180.50","avgFilledPrice":"180.48","qty":"1","notional":"notional","filledQty":"1","filledTotal":"filledTotal","fee":"0.10","session":"RTH","status":"FILLED","createdAt":1735900000000,"updatedAt":1735900120000,"trades":[{"executionId":"exec-20260504-0001","executionAt":1735900115000,"price":"180.48","qty":"1"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.EquityOrderDetailAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/detail", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EquityOrderDetailWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"180.50","avgFilledPrice":"180.48","qty":"1","notional":"notional","filledQty":"1","filledTotal":"filledTotal","fee":"0.10","session":"RTH","status":"FILLED","createdAt":1735900000000,"updatedAt":1735900120000,"trades":[{"executionId":"exec-20260504-0001","executionAt":1735900115000,"price":"180.48","qty":"1"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EquityOrderDetailRequest
        {
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
            ClientOrderId = "web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a",
            RecvWindow = 5000L,
        };

        var response = await client.EquityOrderDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/detail", seen.Path);
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a", seen.Param("clientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EquityOrderDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EquityOrderDetailAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EquityOrderHistoryAsync()
    {
        const string example = """""{"total":2,"page":1,"size":20,"rows":[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"180.50","avgFilledPrice":"180.48","qty":"1","notional":"notional","filledQty":"1","filledTotal":"filledTotal","fee":"0.10","session":"RTH","status":"FILLED","createdAt":1735900000000,"updatedAt":1735900120000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EquityOrderHistoryRequest
        {
            StartTime = 1735800000000L,
            EndTime = 1735900000000L,
        };

        var response = await client.EquityOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/history", seen.Path);
        Assert.Equal("1735800000000", seen.Param("startTime"));
        Assert.Equal("1735900000000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EquityOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":2,"page":1,"size":20,"rows":[{"orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","limitPrice":"180.50","avgFilledPrice":"180.48","qty":"1","notional":"notional","filledQty":"1","filledTotal":"filledTotal","fee":"0.10","session":"RTH","status":"FILLED","createdAt":1735900000000,"updatedAt":1735900120000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EquityOrderHistoryRequest
        {
            StartTime = 1735800000000L,
            EndTime = 1735900000000L,
            Symbol = "NVDA",
            OrderType = EquityOrderHistoryOrderType.Market,
            Side = EquityOrderHistorySide.Buy,
            OrderStatus = "FILLED,CANCELED",
            Current = 1L,
            Size = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.EquityOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/history", seen.Path);
        Assert.Equal("1735800000000", seen.Param("startTime"));
        Assert.Equal("1735900000000", seen.Param("endTime"));
        Assert.Equal("NVDA", seen.Param("symbol"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("FILLED,CANCELED", seen.Param("orderStatus"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("20", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EquityOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new EquityOrderHistoryRequest
        {
            StartTime = 1735800000000L,
            EndTime = 1735900000000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EquityOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EquityTradeHistoryAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"executionId":"exec-20260504-0001","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","price":"180.50","qty":"1","total":"180.50","executionAt":1735900115000,"updatedAt":1735900115200}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EquityTradeHistoryRequest
        {
            StartTime = 1735800000000L,
            EndTime = 1735900000000L,
        };

        var response = await client.EquityTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/trade/history", seen.Path);
        Assert.Equal("1735800000000", seen.Param("startTime"));
        Assert.Equal("1735900000000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EquityTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"page":1,"size":20,"rows":[{"executionId":"exec-20260504-0001","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","symbol":"AAPL","quote":"USDC","side":"BUY","orderType":"LIMIT","price":"180.50","qty":"1","total":"180.50","executionAt":1735900115000,"updatedAt":1735900115200}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new EquityTradeHistoryRequest
        {
            StartTime = 1735800000000L,
            EndTime = 1735900000000L,
            Symbol = "NVDA",
            Side = EquityTradeHistorySide.Buy,
            OrderId = "c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71",
            Current = 1L,
            Size = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.EquityTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/equity/trade/history", seen.Path);
        Assert.Equal("1735800000000", seen.Param("startTime"));
        Assert.Equal("1735900000000", seen.Param("endTime"));
        Assert.Equal("NVDA", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("20", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task EquityTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new EquityTradeHistoryRequest
        {
            StartTime = 1735800000000L,
            EndTime = 1735900000000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EquityTradeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PlaceEquityOrderAsync()
    {
        const string example = """""{"status":"S","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceEquityOrderRequest
        {
            Symbol = "AAPL",
            Side = PlaceEquityOrderSide.Buy,
            OrderType = PlaceEquityOrderOrderType.Market,
        };

        var response = await client.PlaceEquityOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/place", seen.Path);
        Assert.Equal("AAPL", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceEquityOrderWithOptionalParametersAsync()
    {
        const string example = """""{"status":"S","orderId":"c3c58f49-7b0d-4b9e-a2db-1a2f9a3b8c71","clientOrderId":"web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceEquityOrderRequest
        {
            Symbol = "AAPL",
            Side = PlaceEquityOrderSide.Buy,
            OrderType = PlaceEquityOrderOrderType.Market,
            QuoteAsset = "USDC",
            Price = "180.50",
            Quantity = "1",
            Notional = "1000.00",
            TimeInForce = PlaceEquityOrderTimeInForce.Day,
            TradingSession = PlaceEquityOrderTradingSession.Rth,
            WalletType = PlaceEquityOrderWalletType.Card,
            ClientOrderId = "web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a",
            Tokenize = true,
            TokenizedAssetSettleWalletType = PlaceEquityOrderTokenizedAssetSettleWalletType.Main,
            RecvWindow = 5000L,
        };

        var response = await client.PlaceEquityOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/equity/order/place", seen.Path);
        Assert.Equal("AAPL", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("orderType"));
        Assert.Equal("USDC", seen.Param("quoteAsset"));
        Assert.Equal("180.50", seen.Param("price"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1000.00", seen.Param("notional"));
        Assert.Equal("DAY", seen.Param("timeInForce"));
        Assert.Equal("RTH", seen.Param("tradingSession"));
        Assert.Equal("CARD", seen.Param("walletType"));
        Assert.Equal("web_2c9c92b74f1e4a7c8f3b9e1a2d3c4b5a", seen.Param("clientOrderId"));
        Assert.Equal("true", seen.Param("tokenize"));
        Assert.Equal("MAIN", seen.Param("tokenizedAssetSettleWalletType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceEquityOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new PlaceEquityOrderRequest
        {
            Symbol = "AAPL",
            Side = PlaceEquityOrderSide.Buy,
            OrderType = PlaceEquityOrderOrderType.Market,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PlaceEquityOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
