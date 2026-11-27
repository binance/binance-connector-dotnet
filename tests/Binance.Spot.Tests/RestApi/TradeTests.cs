//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Spot.RestApi;

namespace Binance.Spot.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static SpotRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task DeleteOpenOrdersAsync()
    {
        const string example = """""[{"orderListId":-1,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":10,"trailingTime":-1,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteOpenOrdersRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.DeleteOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/api/v3/openOrders", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":-1,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":10,"trailingTime":-1,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteOpenOrdersRequest
        {
            Symbol = "BNBUSDT",
            RecvWindow = 5000m,
        };

        var response = await client.DeleteOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/api/v3/openOrders", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DeleteOpenOrdersRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DeleteOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DeleteOrderAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":4,"orderListId":-1,"origClientOrderId":"myOrder1","clientOrderId":"cancelMyOrder1","transactTime":1684804350068,"price":"2.00000000","origQty":"1.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"BUY","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"23500.00000000","strategyId":37463720,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteOrderRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.DeleteOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/api/v3/order", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":4,"orderListId":-1,"origClientOrderId":"myOrder1","clientOrderId":"cancelMyOrder1","transactTime":1684804350068,"price":"2.00000000","origQty":"1.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"BUY","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"23500.00000000","strategyId":37463720,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteOrderRequest
        {
            Symbol = "BNBUSDT",
            OrderId = 1L,
            OrigClientOrderId = "myOrder1",
            NewClientOrderId = "cancelMyOrder1",
            CancelRestrictions = DeleteOrderCancelRestrictions.OnlyNew,
            RecvWindow = 5000m,
        };

        var response = await client.DeleteOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/api/v3/order", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("myOrder1", seen.Param("origClientOrderId"));
        Assert.Equal("cancelMyOrder1", seen.Param("newClientOrderId"));
        Assert.Equal("ONLY_NEW", seen.Param("cancelRestrictions"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DeleteOrderRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DeleteOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DeleteOrderListAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"C3wyj4WVEktd7u9aVBRXcN","transactionTime":1574040868128,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"pO9ufTiFGg3nw2fOdgeOXa"},{"symbol":"LTCBTC","orderId":3,"clientOrderId":"TXOvglzXuaubXAaENpaRCB"}],"orderReports":[{"symbol":"LTCBTC","origClientOrderId":"pO9ufTiFGg3nw2fOdgeOXa","orderId":2,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","transactTime":1688005070874,"price":"1.00000000","origQty":"10.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000","selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","origClientOrderId":"TXOvglzXuaubXAaENpaRCB","orderId":3,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","transactTime":1688005070874,"price":"3.00000000","origQty":"10.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteOrderListRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.DeleteOrderListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/api/v3/orderList", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteOrderListWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"C3wyj4WVEktd7u9aVBRXcN","transactionTime":1574040868128,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"pO9ufTiFGg3nw2fOdgeOXa"},{"symbol":"LTCBTC","orderId":3,"clientOrderId":"TXOvglzXuaubXAaENpaRCB"}],"orderReports":[{"symbol":"LTCBTC","origClientOrderId":"pO9ufTiFGg3nw2fOdgeOXa","orderId":2,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","transactTime":1688005070874,"price":"1.00000000","origQty":"10.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000","selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","origClientOrderId":"TXOvglzXuaubXAaENpaRCB","orderId":3,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","transactTime":1688005070874,"price":"3.00000000","origQty":"10.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DeleteOrderListRequest
        {
            Symbol = "BNBUSDT",
            OrderListId = 1L,
            ListClientOrderId = "C3wyj4WVEktd7u9aVBRXcN",
            NewClientOrderId = "cancelMyOrder1",
            RecvWindow = 5000m,
        };

        var response = await client.DeleteOrderListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/api/v3/orderList", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderListId"));
        Assert.Equal("C3wyj4WVEktd7u9aVBRXcN", seen.Param("listClientOrderId"));
        Assert.Equal("cancelMyOrder1", seen.Param("newClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DeleteOrderListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DeleteOrderListRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DeleteOrderListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewOrderAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":28,"orderListId":-1,"clientOrderId":"6gCrw2kRUAF9CvJDGP16IP","transactTime":1507725176595,"price":"0.00000000","origQty":"10.00000000","executedQty":"10.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"10.00000000","status":"FILLED","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":1507725176595,"selfTradePreventionMode":"NONE","stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","fills":[{"price":"4000.00000000","qty":"1.00000000","commission":"4.00000000","commissionAsset":"USDT","tradeId":56},{"price":"3999.00000000","qty":"5.00000000","commission":"19.99500000","commissionAsset":"USDT","tradeId":57},{"price":"3998.00000000","qty":"2.00000000","commission":"7.99600000","commissionAsset":"USDT","tradeId":58},{"price":"3997.00000000","qty":"1.00000000","commission":"3.99700000","commissionAsset":"USDT","tradeId":59},{"price":"3995.00000000","qty":"1.00000000","commission":"3.99500000","commissionAsset":"USDT","tradeId":60}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BNBUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Market,
        };

        var response = await client.NewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":28,"orderListId":-1,"clientOrderId":"6gCrw2kRUAF9CvJDGP16IP","transactTime":1507725176595,"price":"0.00000000","origQty":"10.00000000","executedQty":"10.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"10.00000000","status":"FILLED","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":1507725176595,"selfTradePreventionMode":"NONE","stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","fills":[{"price":"4000.00000000","qty":"1.00000000","commission":"4.00000000","commissionAsset":"USDT","tradeId":56},{"price":"3999.00000000","qty":"5.00000000","commission":"19.99500000","commissionAsset":"USDT","tradeId":57},{"price":"3998.00000000","qty":"2.00000000","commission":"7.99600000","commissionAsset":"USDT","tradeId":58},{"price":"3997.00000000","qty":"1.00000000","commission":"3.99700000","commissionAsset":"USDT","tradeId":59},{"price":"3995.00000000","qty":"1.00000000","commission":"3.99500000","commissionAsset":"USDT","tradeId":60}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BNBUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Market,
            TimeInForce = NewOrderTimeInForce.Gtc,
            Quantity = 1m,
            QuoteOrderQty = 1m,
            Price = 400m,
            NewClientOrderId = "myOrder1",
            StrategyId = 1L,
            StrategyType = 1L,
            StopPrice = 1m,
            TrailingDelta = 1L,
            IcebergQty = 1m,
            NewOrderRespType = NewOrderNewOrderRespType.Ack,
            SelfTradePreventionMode = NewOrderSelfTradePreventionMode.None,
            PegPriceType = NewOrderPegPriceType.PrimaryPeg,
            PegOffsetValue = 1L,
            PegOffsetType = NewOrderPegOffsetType.PriceLevel,
            QuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.NewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1", seen.Param("quoteOrderQty"));
        Assert.Equal("400", seen.Param("price"));
        Assert.Equal("myOrder1", seen.Param("newClientOrderId"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("strategyType"));
        Assert.Equal("1", seen.Param("stopPrice"));
        Assert.Equal("1", seen.Param("trailingDelta"));
        Assert.Equal("1", seen.Param("icebergQty"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pegPriceType"));
        Assert.Equal("1", seen.Param("pegOffsetValue"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pegOffsetType"));
        Assert.Equal("100", seen.Param("quoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BNBUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Market,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderAmendKeepPriorityAsync()
    {
        const string example = """""{"transactTime":1741926410255,"executionId":75,"amendedOrder":{"symbol":"BTCUSDT","orderId":33,"orderListId":-1,"origClientOrderId":"5xrgbMyg6z36NzBn2pbT8H","clientOrderId":"PFaq6hIHxqFENGfdtn4J6Q","price":"6.00000000","qty":"5.00000000","executedQty":"0.00000000","preventedQty":"0.00000000","quoteOrderQty":"0.00000000","cumulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1741926410242,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"listStatus":{"orderListId":1,"contingencyType":"OTO","listOrderStatus":"EXECUTING","listClientOrderId":"AT7FTxZXylVSwRoZs52mt3","symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":8,"clientOrderId":"GkwwHZUUbFtZOoH1YsZk9Q"},{"symbol":"BTCUSDT","orderId":9,"clientOrderId":"UQ1Np3bmQ71jJzsSDW9Vpi"}]}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderAmendKeepPriorityRequest
        {
            Symbol = "BNBUSDT",
            NewQty = 5m,
        };

        var response = await client.OrderAmendKeepPriorityAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/api/v3/order/amend/keepPriority", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("5", seen.Param("newQty"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderAmendKeepPriorityWithOptionalParametersAsync()
    {
        const string example = """""{"transactTime":1741926410255,"executionId":75,"amendedOrder":{"symbol":"BTCUSDT","orderId":33,"orderListId":-1,"origClientOrderId":"5xrgbMyg6z36NzBn2pbT8H","clientOrderId":"PFaq6hIHxqFENGfdtn4J6Q","price":"6.00000000","qty":"5.00000000","executedQty":"0.00000000","preventedQty":"0.00000000","quoteOrderQty":"0.00000000","cumulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1741926410242,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"listStatus":{"orderListId":1,"contingencyType":"OTO","listOrderStatus":"EXECUTING","listClientOrderId":"AT7FTxZXylVSwRoZs52mt3","symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":8,"clientOrderId":"GkwwHZUUbFtZOoH1YsZk9Q"},{"symbol":"BTCUSDT","orderId":9,"clientOrderId":"UQ1Np3bmQ71jJzsSDW9Vpi"}]}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderAmendKeepPriorityRequest
        {
            Symbol = "BNBUSDT",
            NewQty = 5m,
            OrderId = 1L,
            OrigClientOrderId = "myOrder1",
            NewClientOrderId = "myOrder2",
            RecvWindow = 5000m,
        };

        var response = await client.OrderAmendKeepPriorityAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/api/v3/order/amend/keepPriority", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("5", seen.Param("newQty"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("myOrder1", seen.Param("origClientOrderId"));
        Assert.Equal("myOrder2", seen.Param("newClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderAmendKeepPriorityBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderAmendKeepPriorityRequest
        {
            Symbol = "BNBUSDT",
            NewQty = 5m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderAmendKeepPriorityAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderCancelReplaceAsync()
    {
        const string example = """""{"cancelResult":"SUCCESS","newOrderResult":"SUCCESS","cancelResponse":{"symbol":"BTCUSDT","origClientOrderId":"DnLo3vTAQcjha43lAZhZ0y","orderId":9,"orderListId":-1,"clientOrderId":"osxN3JXAtJvKvCqGeMWMVR","transactTime":1684804350068,"price":"0.01000000","origQty":"0.000100","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"newOrderResponse":{"symbol":"BTCUSDT","orderId":10,"orderListId":-1,"clientOrderId":"wOceeeOzNORyLiQfw7jd8S","transactTime":1652928801803,"price":"0.02000000","origQty":"0.040000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1669277163808,"fills":[],"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderCancelReplaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderCancelReplaceSide.Buy,
            Type = OrderCancelReplaceType.Market,
            CancelReplaceMode = OrderCancelReplaceCancelReplaceMode.StopOnFailure,
        };

        var response = await client.OrderCancelReplaceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order/cancelReplace", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("STOP_ON_FAILURE", seen.Param("cancelReplaceMode"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderCancelReplaceWithOptionalParametersAsync()
    {
        const string example = """""{"cancelResult":"SUCCESS","newOrderResult":"SUCCESS","cancelResponse":{"symbol":"BTCUSDT","origClientOrderId":"DnLo3vTAQcjha43lAZhZ0y","orderId":9,"orderListId":-1,"clientOrderId":"osxN3JXAtJvKvCqGeMWMVR","transactTime":1684804350068,"price":"0.01000000","origQty":"0.000100","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"newOrderResponse":{"symbol":"BTCUSDT","orderId":10,"orderListId":-1,"clientOrderId":"wOceeeOzNORyLiQfw7jd8S","transactTime":1652928801803,"price":"0.02000000","origQty":"0.040000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1669277163808,"fills":[],"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderCancelReplaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderCancelReplaceSide.Buy,
            Type = OrderCancelReplaceType.Market,
            CancelReplaceMode = OrderCancelReplaceCancelReplaceMode.StopOnFailure,
            TimeInForce = OrderCancelReplaceTimeInForce.Gtc,
            Quantity = 1m,
            QuoteOrderQty = 1m,
            Price = 400m,
            CancelNewClientOrderId = "cancelMyOrder1",
            CancelOrigClientOrderId = "myOrder1",
            CancelOrderId = 1L,
            NewClientOrderId = "myOrder2",
            StrategyId = 1L,
            StrategyType = 1L,
            StopPrice = 1m,
            TrailingDelta = 1L,
            IcebergQty = 1m,
            NewOrderRespType = OrderCancelReplaceNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderCancelReplaceSelfTradePreventionMode.None,
            CancelRestrictions = OrderCancelReplaceCancelRestrictions.OnlyNew,
            OrderRateLimitExceededMode = OrderCancelReplaceOrderRateLimitExceededMode.DoNothing,
            PegPriceType = OrderCancelReplacePegPriceType.PrimaryPeg,
            PegOffsetValue = 1L,
            PegOffsetType = OrderCancelReplacePegOffsetType.PriceLevel,
            QuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderCancelReplaceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order/cancelReplace", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("STOP_ON_FAILURE", seen.Param("cancelReplaceMode"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1", seen.Param("quoteOrderQty"));
        Assert.Equal("400", seen.Param("price"));
        Assert.Equal("cancelMyOrder1", seen.Param("cancelNewClientOrderId"));
        Assert.Equal("myOrder1", seen.Param("cancelOrigClientOrderId"));
        Assert.Equal("1", seen.Param("cancelOrderId"));
        Assert.Equal("myOrder2", seen.Param("newClientOrderId"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("strategyType"));
        Assert.Equal("1", seen.Param("stopPrice"));
        Assert.Equal("1", seen.Param("trailingDelta"));
        Assert.Equal("1", seen.Param("icebergQty"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("ONLY_NEW", seen.Param("cancelRestrictions"));
        Assert.Equal("DO_NOTHING", seen.Param("orderRateLimitExceededMode"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pegPriceType"));
        Assert.Equal("1", seen.Param("pegOffsetValue"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pegOffsetType"));
        Assert.Equal("100", seen.Param("quoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderCancelReplaceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderCancelReplaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderCancelReplaceSide.Buy,
            Type = OrderCancelReplaceType.Market,
            CancelReplaceMode = OrderCancelReplaceCancelReplaceMode.StopOnFailure,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderCancelReplaceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListOcoAsync()
    {
        const string example = """""{"orderListId":1,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"lH1YDkuQKWiXVXHPSKYEIp","transactionTime":1710485608839,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":10,"clientOrderId":"44nZvqpemY7sVYgPYbvPih"},{"symbol":"LTCBTC","orderId":11,"clientOrderId":"NuMp0nVYnciDiFmVqfpBqK"}],"orderReports":[{"symbol":"LTCBTC","orderId":10,"orderListId":1,"clientOrderId":"44nZvqpemY7sVYgPYbvPih","transactTime":1710485608839,"price":"1.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000","workingTime":-1,"icebergQty":"1.00000000","selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":11,"orderListId":1,"clientOrderId":"NuMp0nVYnciDiFmVqfpBqK","transactTime":1710485608839,"price":"3.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":1710485608839,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListOcoSide.Buy,
            Quantity = 1m,
            AboveType = OrderListOcoAboveType.StopLossLimit,
            BelowType = OrderListOcoBelowType.StopLoss,
        };

        var response = await client.OrderListOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/oco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("STOP_LOSS_LIMIT", seen.Param("aboveType"));
        Assert.Equal("STOP_LOSS", seen.Param("belowType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOcoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":1,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"lH1YDkuQKWiXVXHPSKYEIp","transactionTime":1710485608839,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":10,"clientOrderId":"44nZvqpemY7sVYgPYbvPih"},{"symbol":"LTCBTC","orderId":11,"clientOrderId":"NuMp0nVYnciDiFmVqfpBqK"}],"orderReports":[{"symbol":"LTCBTC","orderId":10,"orderListId":1,"clientOrderId":"44nZvqpemY7sVYgPYbvPih","transactTime":1710485608839,"price":"1.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000","workingTime":-1,"icebergQty":"1.00000000","selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":11,"orderListId":1,"clientOrderId":"NuMp0nVYnciDiFmVqfpBqK","transactTime":1710485608839,"price":"3.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":1710485608839,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListOcoSide.Buy,
            Quantity = 1m,
            AboveType = OrderListOcoAboveType.StopLossLimit,
            BelowType = OrderListOcoBelowType.StopLoss,
            ListClientOrderId = "lH1YDkuQKWiXVXHPSKYEIp",
            AboveClientOrderId = "aboveOrder1",
            AboveIcebergQty = 1m,
            AbovePrice = 1.5m,
            AboveStopPrice = 1.50000001m,
            AboveTrailingDelta = 1L,
            AboveTimeInForce = OrderListOcoAboveTimeInForce.Gtc,
            AboveStrategyId = 1L,
            AboveStrategyType = 1L,
            AbovePegPriceType = OrderListOcoAbovePegPriceType.PrimaryPeg,
            AbovePegOffsetType = OrderListOcoAbovePegOffsetType.PriceLevel,
            AbovePegOffsetValue = 1L,
            BelowClientOrderId = "belowOrder1",
            BelowIcebergQty = 1m,
            BelowPrice = 1.49999999m,
            BelowStopPrice = 1.50000001m,
            BelowTrailingDelta = 1L,
            BelowTimeInForce = OrderListOcoBelowTimeInForce.Gtc,
            BelowStrategyId = 1L,
            BelowStrategyType = 1L,
            BelowPegPriceType = OrderListOcoBelowPegPriceType.PrimaryPeg,
            BelowPegOffsetType = OrderListOcoBelowPegOffsetType.PriceLevel,
            BelowPegOffsetValue = 1L,
            NewOrderRespType = OrderListOcoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListOcoSelfTradePreventionMode.None,
            AboveQuoteNotionalLimit = 100m,
            BelowQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/oco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("STOP_LOSS_LIMIT", seen.Param("aboveType"));
        Assert.Equal("STOP_LOSS", seen.Param("belowType"));
        Assert.Equal("lH1YDkuQKWiXVXHPSKYEIp", seen.Param("listClientOrderId"));
        Assert.Equal("aboveOrder1", seen.Param("aboveClientOrderId"));
        Assert.Equal("1", seen.Param("aboveIcebergQty"));
        Assert.Equal("1.5", seen.Param("abovePrice"));
        Assert.Equal("1.50000001", seen.Param("aboveStopPrice"));
        Assert.Equal("1", seen.Param("aboveTrailingDelta"));
        Assert.Equal("GTC", seen.Param("aboveTimeInForce"));
        Assert.Equal("1", seen.Param("aboveStrategyId"));
        Assert.Equal("1", seen.Param("aboveStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("abovePegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("abovePegOffsetType"));
        Assert.Equal("1", seen.Param("abovePegOffsetValue"));
        Assert.Equal("belowOrder1", seen.Param("belowClientOrderId"));
        Assert.Equal("1", seen.Param("belowIcebergQty"));
        Assert.Equal("1.49999999", seen.Param("belowPrice"));
        Assert.Equal("1.50000001", seen.Param("belowStopPrice"));
        Assert.Equal("1", seen.Param("belowTrailingDelta"));
        Assert.Equal("GTC", seen.Param("belowTimeInForce"));
        Assert.Equal("1", seen.Param("belowStrategyId"));
        Assert.Equal("1", seen.Param("belowStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("belowPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("belowPegOffsetType"));
        Assert.Equal("1", seen.Param("belowPegOffsetValue"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("100", seen.Param("aboveQuoteNotionalLimit"));
        Assert.Equal("100", seen.Param("belowQuoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOcoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderListOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListOcoSide.Buy,
            Quantity = 1m,
            AboveType = OrderListOcoAboveType.StopLossLimit,
            BelowType = OrderListOcoBelowType.StopLoss,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderListOcoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListOpoAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"H94qCqO27P74OEiO4X8HOG","transactionTime":1762998011671,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":2,"clientOrderId":"JX6xfdjo0wysiGumfHNmPu"},{"symbol":"BTCUSDT","orderId":3,"clientOrderId":"2ZJCY0IjOhuYIMLGN8kU8S"}],"orderReports":[{"symbol":"BTCUSDT","orderId":2,"orderListId":0,"clientOrderId":"JX6xfdjo0wysiGumfHNmPu","transactTime":1762998011671,"price":"102264.00000000","origQty":"0.00060000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1762998011671,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":3,"orderListId":0,"clientOrderId":"2ZJCY0IjOhuYIMLGN8kU8S","transactTime":1762998011671,"price":"0.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOpoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOpoWorkingType.Limit,
            WorkingSide = OrderListOpoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListOpoPendingType.Limit,
            PendingSide = OrderListOpoPendingSide.Buy,
        };

        var response = await client.OrderListOpoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/opo", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("LIMIT", seen.Param("pendingType"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOpoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"H94qCqO27P74OEiO4X8HOG","transactionTime":1762998011671,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":2,"clientOrderId":"JX6xfdjo0wysiGumfHNmPu"},{"symbol":"BTCUSDT","orderId":3,"clientOrderId":"2ZJCY0IjOhuYIMLGN8kU8S"}],"orderReports":[{"symbol":"BTCUSDT","orderId":2,"orderListId":0,"clientOrderId":"JX6xfdjo0wysiGumfHNmPu","transactTime":1762998011671,"price":"102264.00000000","origQty":"0.00060000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1762998011671,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":3,"orderListId":0,"clientOrderId":"2ZJCY0IjOhuYIMLGN8kU8S","transactTime":1762998011671,"price":"0.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOpoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOpoWorkingType.Limit,
            WorkingSide = OrderListOpoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListOpoPendingType.Limit,
            PendingSide = OrderListOpoPendingSide.Buy,
            ListClientOrderId = "H94qCqO27P74OEiO4X8HOG",
            NewOrderRespType = OrderListOpoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListOpoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListOpoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListOpoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListOpoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingClientOrderId = "pendingOrder1",
            PendingPrice = 1m,
            PendingStopPrice = 1m,
            PendingTrailingDelta = 1m,
            PendingIcebergQty = 1m,
            PendingTimeInForce = OrderListOpoPendingTimeInForce.Gtc,
            PendingStrategyId = 1L,
            PendingStrategyType = 1L,
            PendingPegPriceType = OrderListOpoPendingPegPriceType.PrimaryPeg,
            PendingPegOffsetType = OrderListOpoPendingPegOffsetType.PriceLevel,
            PendingPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListOpoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/opo", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("LIMIT", seen.Param("pendingType"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("H94qCqO27P74OEiO4X8HOG", seen.Param("listClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", seen.Param("workingClientOrderId"));
        Assert.Equal("1", seen.Param("workingIcebergQty"));
        Assert.Equal("GTC", seen.Param("workingTimeInForce"));
        Assert.Equal("1", seen.Param("workingStrategyId"));
        Assert.Equal("1", seen.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("workingPegOffsetType"));
        Assert.Equal("1", seen.Param("workingPegOffsetValue"));
        Assert.Equal("pendingOrder1", seen.Param("pendingClientOrderId"));
        Assert.Equal("1", seen.Param("pendingPrice"));
        Assert.Equal("1", seen.Param("pendingStopPrice"));
        Assert.Equal("1", seen.Param("pendingTrailingDelta"));
        Assert.Equal("1", seen.Param("pendingIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingTimeInForce"));
        Assert.Equal("1", seen.Param("pendingStrategyId"));
        Assert.Equal("1", seen.Param("pendingStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pendingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pendingPegOffsetType"));
        Assert.Equal("1", seen.Param("pendingPegOffsetValue"));
        Assert.Equal("100", seen.Param("workingQuoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOpoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderListOpoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOpoWorkingType.Limit,
            WorkingSide = OrderListOpoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListOpoPendingType.Limit,
            PendingSide = OrderListOpoPendingSide.Buy,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderListOpoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListOpocoAsync()
    {
        const string example = """""{"orderListId":2,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"bcedxMpQG6nFrZUPQyshoL","transactionTime":1763000506354,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":9,"clientOrderId":"OLSBhMWaIlLSzZ9Zm7fnKB"},{"symbol":"BTCUSDT","orderId":10,"clientOrderId":"mfif39yPTHsB3C0FIXznR2"},{"symbol":"BTCUSDT","orderId":11,"clientOrderId":"yINkaXSJeoi3bU5vWMY8Z8"}],"orderReports":[{"symbol":"BTCUSDT","orderId":9,"orderListId":2,"clientOrderId":"OLSBhMWaIlLSzZ9Zm7fnKB","transactTime":1763000506354,"price":"102496.00000000","origQty":"0.00170000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1763000506354,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":10,"orderListId":2,"clientOrderId":"mfif39yPTHsB3C0FIXznR2","transactTime":1763000506354,"price":"101613.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"10100.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":11,"orderListId":2,"clientOrderId":"yINkaXSJeoi3bU5vWMY8Z8","transactTime":1763000506354,"price":"104261.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOpocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOpocoWorkingType.Limit,
            WorkingSide = OrderListOpocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListOpocoPendingSide.Buy,
            PendingAboveType = OrderListOpocoPendingAboveType.StopLossLimit,
        };

        var response = await client.OrderListOpocoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/opoco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("STOP_LOSS_LIMIT", seen.Param("pendingAboveType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOpocoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":2,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"bcedxMpQG6nFrZUPQyshoL","transactionTime":1763000506354,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":9,"clientOrderId":"OLSBhMWaIlLSzZ9Zm7fnKB"},{"symbol":"BTCUSDT","orderId":10,"clientOrderId":"mfif39yPTHsB3C0FIXznR2"},{"symbol":"BTCUSDT","orderId":11,"clientOrderId":"yINkaXSJeoi3bU5vWMY8Z8"}],"orderReports":[{"symbol":"BTCUSDT","orderId":9,"orderListId":2,"clientOrderId":"OLSBhMWaIlLSzZ9Zm7fnKB","transactTime":1763000506354,"price":"102496.00000000","origQty":"0.00170000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1763000506354,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":10,"orderListId":2,"clientOrderId":"mfif39yPTHsB3C0FIXznR2","transactTime":1763000506354,"price":"101613.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"10100.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":11,"orderListId":2,"clientOrderId":"yINkaXSJeoi3bU5vWMY8Z8","transactTime":1763000506354,"price":"104261.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOpocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOpocoWorkingType.Limit,
            WorkingSide = OrderListOpocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListOpocoPendingSide.Buy,
            PendingAboveType = OrderListOpocoPendingAboveType.StopLossLimit,
            ListClientOrderId = "bcedxMpQG6nFrZUPQyshoL",
            NewOrderRespType = OrderListOpocoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListOpocoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListOpocoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListOpocoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListOpocoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingAboveClientOrderId = "pendingAboveOrder1",
            PendingAbovePrice = 1m,
            PendingAboveStopPrice = 1m,
            PendingAboveTrailingDelta = 1m,
            PendingAboveIcebergQty = 1m,
            PendingAboveTimeInForce = OrderListOpocoPendingAboveTimeInForce.Gtc,
            PendingAboveStrategyId = 1L,
            PendingAboveStrategyType = 1L,
            PendingAbovePegPriceType = OrderListOpocoPendingAbovePegPriceType.PrimaryPeg,
            PendingAbovePegOffsetType = OrderListOpocoPendingAbovePegOffsetType.PriceLevel,
            PendingAbovePegOffsetValue = 1L,
            PendingBelowType = OrderListOpocoPendingBelowType.StopLoss,
            PendingBelowClientOrderId = "pendingBelowOrder1",
            PendingBelowPrice = 1m,
            PendingBelowStopPrice = 1m,
            PendingBelowTrailingDelta = 1m,
            PendingBelowIcebergQty = 1m,
            PendingBelowTimeInForce = OrderListOpocoPendingBelowTimeInForce.Gtc,
            PendingBelowStrategyId = 1L,
            PendingBelowStrategyType = 1L,
            PendingBelowPegPriceType = OrderListOpocoPendingBelowPegPriceType.PrimaryPeg,
            PendingBelowPegOffsetType = OrderListOpocoPendingBelowPegOffsetType.PriceLevel,
            PendingBelowPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListOpocoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/opoco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("STOP_LOSS_LIMIT", seen.Param("pendingAboveType"));
        Assert.Equal("bcedxMpQG6nFrZUPQyshoL", seen.Param("listClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", seen.Param("workingClientOrderId"));
        Assert.Equal("1", seen.Param("workingIcebergQty"));
        Assert.Equal("GTC", seen.Param("workingTimeInForce"));
        Assert.Equal("1", seen.Param("workingStrategyId"));
        Assert.Equal("1", seen.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("workingPegOffsetType"));
        Assert.Equal("1", seen.Param("workingPegOffsetValue"));
        Assert.Equal("pendingAboveOrder1", seen.Param("pendingAboveClientOrderId"));
        Assert.Equal("1", seen.Param("pendingAbovePrice"));
        Assert.Equal("1", seen.Param("pendingAboveStopPrice"));
        Assert.Equal("1", seen.Param("pendingAboveTrailingDelta"));
        Assert.Equal("1", seen.Param("pendingAboveIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingAboveTimeInForce"));
        Assert.Equal("1", seen.Param("pendingAboveStrategyId"));
        Assert.Equal("1", seen.Param("pendingAboveStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pendingAbovePegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pendingAbovePegOffsetType"));
        Assert.Equal("1", seen.Param("pendingAbovePegOffsetValue"));
        Assert.Equal("STOP_LOSS", seen.Param("pendingBelowType"));
        Assert.Equal("pendingBelowOrder1", seen.Param("pendingBelowClientOrderId"));
        Assert.Equal("1", seen.Param("pendingBelowPrice"));
        Assert.Equal("1", seen.Param("pendingBelowStopPrice"));
        Assert.Equal("1", seen.Param("pendingBelowTrailingDelta"));
        Assert.Equal("1", seen.Param("pendingBelowIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingBelowTimeInForce"));
        Assert.Equal("1", seen.Param("pendingBelowStrategyId"));
        Assert.Equal("1", seen.Param("pendingBelowStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pendingBelowPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pendingBelowPegOffsetType"));
        Assert.Equal("1", seen.Param("pendingBelowPegOffsetValue"));
        Assert.Equal("100", seen.Param("workingQuoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOpocoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderListOpocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOpocoWorkingType.Limit,
            WorkingSide = OrderListOpocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListOpocoPendingSide.Buy,
            PendingAboveType = OrderListOpocoPendingAboveType.StopLossLimit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderListOpocoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListOtoAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"yl2ERtcar1o25zcWtqVBTC","transactionTime":1712289389158,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"Bq17mn9fP6vyCn75Jw1xya"},{"symbol":"LTCBTC","orderId":5,"clientOrderId":"arLFo0zGJVDE69cvGBaU0d"}],"orderReports":[{"symbol":"LTCBTC","orderId":4,"orderListId":0,"clientOrderId":"Bq17mn9fP6vyCn75Jw1xya","transactTime":1712289389158,"price":"1.00000000","origQty":"1.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712289389158,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":5,"orderListId":0,"clientOrderId":"arLFo0zGJVDE69cvGBaU0d","transactTime":1712289389158,"price":"0.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOtoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOtoWorkingType.Limit,
            WorkingSide = OrderListOtoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListOtoPendingType.Limit,
            PendingSide = OrderListOtoPendingSide.Buy,
            PendingQuantity = 1m,
        };

        var response = await client.OrderListOtoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/oto", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("LIMIT", seen.Param("pendingType"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1", seen.Param("pendingQuantity"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOtoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"yl2ERtcar1o25zcWtqVBTC","transactionTime":1712289389158,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"Bq17mn9fP6vyCn75Jw1xya"},{"symbol":"LTCBTC","orderId":5,"clientOrderId":"arLFo0zGJVDE69cvGBaU0d"}],"orderReports":[{"symbol":"LTCBTC","orderId":4,"orderListId":0,"clientOrderId":"Bq17mn9fP6vyCn75Jw1xya","transactTime":1712289389158,"price":"1.00000000","origQty":"1.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712289389158,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":5,"orderListId":0,"clientOrderId":"arLFo0zGJVDE69cvGBaU0d","transactTime":1712289389158,"price":"0.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOtoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOtoWorkingType.Limit,
            WorkingSide = OrderListOtoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListOtoPendingType.Limit,
            PendingSide = OrderListOtoPendingSide.Buy,
            PendingQuantity = 1m,
            ListClientOrderId = "yl2ERtcar1o25zcWtqVBTC",
            NewOrderRespType = OrderListOtoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListOtoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListOtoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListOtoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListOtoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingClientOrderId = "pendingOrder1",
            PendingPrice = 1m,
            PendingStopPrice = 1m,
            PendingTrailingDelta = 1m,
            PendingIcebergQty = 1m,
            PendingTimeInForce = OrderListOtoPendingTimeInForce.Gtc,
            PendingStrategyId = 1L,
            PendingStrategyType = 1L,
            PendingPegPriceType = OrderListOtoPendingPegPriceType.PrimaryPeg,
            PendingPegOffsetType = OrderListOtoPendingPegOffsetType.PriceLevel,
            PendingPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            PendingQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListOtoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/oto", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("LIMIT", seen.Param("pendingType"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1", seen.Param("pendingQuantity"));
        Assert.Equal("yl2ERtcar1o25zcWtqVBTC", seen.Param("listClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", seen.Param("workingClientOrderId"));
        Assert.Equal("1", seen.Param("workingIcebergQty"));
        Assert.Equal("GTC", seen.Param("workingTimeInForce"));
        Assert.Equal("1", seen.Param("workingStrategyId"));
        Assert.Equal("1", seen.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("workingPegOffsetType"));
        Assert.Equal("1", seen.Param("workingPegOffsetValue"));
        Assert.Equal("pendingOrder1", seen.Param("pendingClientOrderId"));
        Assert.Equal("1", seen.Param("pendingPrice"));
        Assert.Equal("1", seen.Param("pendingStopPrice"));
        Assert.Equal("1", seen.Param("pendingTrailingDelta"));
        Assert.Equal("1", seen.Param("pendingIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingTimeInForce"));
        Assert.Equal("1", seen.Param("pendingStrategyId"));
        Assert.Equal("1", seen.Param("pendingStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pendingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pendingPegOffsetType"));
        Assert.Equal("1", seen.Param("pendingPegOffsetValue"));
        Assert.Equal("100", seen.Param("workingQuoteNotionalLimit"));
        Assert.Equal("100", seen.Param("pendingQuoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOtoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderListOtoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOtoWorkingType.Limit,
            WorkingSide = OrderListOtoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListOtoPendingType.Limit,
            PendingSide = OrderListOtoPendingSide.Buy,
            PendingQuantity = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderListOtoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListOtocoAsync()
    {
        const string example = """""{"orderListId":1,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"RumwQpBaDctlUu5jyG5rs0","transactionTime":1712291372842,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":6,"clientOrderId":"fM9Y4m23IFJVCQmIrlUmMK"},{"symbol":"LTCBTC","orderId":7,"clientOrderId":"6pcQbFIzTXGZQ1e2MkGDq4"},{"symbol":"LTCBTC","orderId":8,"clientOrderId":"r4JMv9cwAYYUwwBZfbussx"}],"orderReports":[{"symbol":"LTCBTC","orderId":6,"orderListId":1,"clientOrderId":"fM9Y4m23IFJVCQmIrlUmMK","transactTime":1712291372842,"price":"1.00000000","origQty":"1.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712291372842,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":7,"orderListId":1,"clientOrderId":"6pcQbFIzTXGZQ1e2MkGDq4","transactTime":1712291372842,"price":"1.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"IOC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"6.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":8,"orderListId":1,"clientOrderId":"r4JMv9cwAYYUwwBZfbussx","transactTime":1712291372842,"price":"3.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOtocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOtocoWorkingType.Limit,
            WorkingSide = OrderListOtocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListOtocoPendingSide.Buy,
            PendingQuantity = 1m,
            PendingAboveType = OrderListOtocoPendingAboveType.StopLossLimit,
        };

        var response = await client.OrderListOtocoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/otoco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1", seen.Param("pendingQuantity"));
        Assert.Equal("STOP_LOSS_LIMIT", seen.Param("pendingAboveType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOtocoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":1,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"RumwQpBaDctlUu5jyG5rs0","transactionTime":1712291372842,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":6,"clientOrderId":"fM9Y4m23IFJVCQmIrlUmMK"},{"symbol":"LTCBTC","orderId":7,"clientOrderId":"6pcQbFIzTXGZQ1e2MkGDq4"},{"symbol":"LTCBTC","orderId":8,"clientOrderId":"r4JMv9cwAYYUwwBZfbussx"}],"orderReports":[{"symbol":"LTCBTC","orderId":6,"orderListId":1,"clientOrderId":"fM9Y4m23IFJVCQmIrlUmMK","transactTime":1712291372842,"price":"1.00000000","origQty":"1.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712291372842,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":7,"orderListId":1,"clientOrderId":"6pcQbFIzTXGZQ1e2MkGDq4","transactTime":1712291372842,"price":"1.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"IOC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"6.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":8,"orderListId":1,"clientOrderId":"r4JMv9cwAYYUwwBZfbussx","transactTime":1712291372842,"price":"3.00000000","origQty":"5.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderListOtocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOtocoWorkingType.Limit,
            WorkingSide = OrderListOtocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListOtocoPendingSide.Buy,
            PendingQuantity = 1m,
            PendingAboveType = OrderListOtocoPendingAboveType.StopLossLimit,
            ListClientOrderId = "RumwQpBaDctlUu5jyG5rs0",
            NewOrderRespType = OrderListOtocoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListOtocoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListOtocoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListOtocoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListOtocoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingAboveClientOrderId = "pendingAboveOrder1",
            PendingAbovePrice = 1m,
            PendingAboveStopPrice = 1m,
            PendingAboveTrailingDelta = 1m,
            PendingAboveIcebergQty = 1m,
            PendingAboveTimeInForce = OrderListOtocoPendingAboveTimeInForce.Gtc,
            PendingAboveStrategyId = 1L,
            PendingAboveStrategyType = 1L,
            PendingAbovePegPriceType = OrderListOtocoPendingAbovePegPriceType.PrimaryPeg,
            PendingAbovePegOffsetType = OrderListOtocoPendingAbovePegOffsetType.PriceLevel,
            PendingAbovePegOffsetValue = 1L,
            PendingBelowType = OrderListOtocoPendingBelowType.StopLoss,
            PendingBelowClientOrderId = "pendingBelowOrder1",
            PendingBelowPrice = 1m,
            PendingBelowStopPrice = 1m,
            PendingBelowTrailingDelta = 1m,
            PendingBelowIcebergQty = 1m,
            PendingBelowTimeInForce = OrderListOtocoPendingBelowTimeInForce.Gtc,
            PendingBelowStrategyId = 1L,
            PendingBelowStrategyType = 1L,
            PendingBelowPegPriceType = OrderListOtocoPendingBelowPegPriceType.PrimaryPeg,
            PendingBelowPegOffsetType = OrderListOtocoPendingBelowPegOffsetType.PriceLevel,
            PendingBelowPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            PendingAboveQuoteNotionalLimit = 100m,
            PendingBelowQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListOtocoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/orderList/otoco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1", seen.Param("workingPrice"));
        Assert.Equal("1", seen.Param("workingQuantity"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1", seen.Param("pendingQuantity"));
        Assert.Equal("STOP_LOSS_LIMIT", seen.Param("pendingAboveType"));
        Assert.Equal("RumwQpBaDctlUu5jyG5rs0", seen.Param("listClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", seen.Param("workingClientOrderId"));
        Assert.Equal("1", seen.Param("workingIcebergQty"));
        Assert.Equal("GTC", seen.Param("workingTimeInForce"));
        Assert.Equal("1", seen.Param("workingStrategyId"));
        Assert.Equal("1", seen.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("workingPegOffsetType"));
        Assert.Equal("1", seen.Param("workingPegOffsetValue"));
        Assert.Equal("pendingAboveOrder1", seen.Param("pendingAboveClientOrderId"));
        Assert.Equal("1", seen.Param("pendingAbovePrice"));
        Assert.Equal("1", seen.Param("pendingAboveStopPrice"));
        Assert.Equal("1", seen.Param("pendingAboveTrailingDelta"));
        Assert.Equal("1", seen.Param("pendingAboveIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingAboveTimeInForce"));
        Assert.Equal("1", seen.Param("pendingAboveStrategyId"));
        Assert.Equal("1", seen.Param("pendingAboveStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pendingAbovePegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pendingAbovePegOffsetType"));
        Assert.Equal("1", seen.Param("pendingAbovePegOffsetValue"));
        Assert.Equal("STOP_LOSS", seen.Param("pendingBelowType"));
        Assert.Equal("pendingBelowOrder1", seen.Param("pendingBelowClientOrderId"));
        Assert.Equal("1", seen.Param("pendingBelowPrice"));
        Assert.Equal("1", seen.Param("pendingBelowStopPrice"));
        Assert.Equal("1", seen.Param("pendingBelowTrailingDelta"));
        Assert.Equal("1", seen.Param("pendingBelowIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingBelowTimeInForce"));
        Assert.Equal("1", seen.Param("pendingBelowStrategyId"));
        Assert.Equal("1", seen.Param("pendingBelowStrategyType"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pendingBelowPegPriceType"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pendingBelowPegOffsetType"));
        Assert.Equal("1", seen.Param("pendingBelowPegOffsetValue"));
        Assert.Equal("100", seen.Param("workingQuoteNotionalLimit"));
        Assert.Equal("100", seen.Param("pendingAboveQuoteNotionalLimit"));
        Assert.Equal("100", seen.Param("pendingBelowQuoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderListOtocoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderListOtocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListOtocoWorkingType.Limit,
            WorkingSide = OrderListOtocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListOtocoPendingSide.Buy,
            PendingQuantity = 1m,
            PendingAboveType = OrderListOtocoPendingAboveType.StopLossLimit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderListOtocoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

#pragma warning disable CS0618 // This endpoint is deprecated.
    [Fact]
    public async Task OrderOcoAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JYVpp3F0f5CAG15DhtrqLp","transactionTime":1563417480525,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos"},{"symbol":"LTCBTC","orderId":3,"clientOrderId":"xTXKaGYd4bluPVp78IVRvl"}],"orderReports":[{"symbol":"LTCBTC","orderId":2,"orderListId":0,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos","transactTime":1563417480525,"price":"0.000000","origQty":"0.624363","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"BUY","stopPrice":"0.960664","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":3,"orderListId":0,"clientOrderId":"xTXKaGYd4bluPVp78IVRvl","transactTime":1563417480525,"price":"0.036435","origQty":"0.624363","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":1563417480525,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderOcoSide.Buy,
            Quantity = 1m,
            Price = 1m,
            StopPrice = 1m,
        };

        var response = await client.OrderOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order/oco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1", seen.Param("price"));
        Assert.Equal("1", seen.Param("stopPrice"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderOcoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JYVpp3F0f5CAG15DhtrqLp","transactionTime":1563417480525,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos"},{"symbol":"LTCBTC","orderId":3,"clientOrderId":"xTXKaGYd4bluPVp78IVRvl"}],"orderReports":[{"symbol":"LTCBTC","orderId":2,"orderListId":0,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos","transactTime":1563417480525,"price":"0.000000","origQty":"0.624363","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"BUY","stopPrice":"0.960664","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBTC","orderId":3,"orderListId":0,"clientOrderId":"xTXKaGYd4bluPVp78IVRvl","transactTime":1563417480525,"price":"0.036435","origQty":"0.624363","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":1563417480525,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderOcoSide.Buy,
            Quantity = 1m,
            Price = 1m,
            StopPrice = 1m,
            ListClientOrderId = "JYVpp3F0f5CAG15DhtrqLp",
            LimitClientOrderId = "limitOrder1",
            LimitStrategyId = 1L,
            LimitStrategyType = 1L,
            LimitIcebergQty = 1m,
            TrailingDelta = 1L,
            StopClientOrderId = "stopOrder1",
            StopStrategyId = 1L,
            StopStrategyType = 1L,
            StopLimitPrice = 1m,
            StopIcebergQty = 1m,
            StopLimitTimeInForce = OrderOcoStopLimitTimeInForce.Gtc,
            NewOrderRespType = OrderOcoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderOcoSelfTradePreventionMode.None,
            RecvWindow = 5000m,
        };

        var response = await client.OrderOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order/oco", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1", seen.Param("price"));
        Assert.Equal("1", seen.Param("stopPrice"));
        Assert.Equal("JYVpp3F0f5CAG15DhtrqLp", seen.Param("listClientOrderId"));
        Assert.Equal("limitOrder1", seen.Param("limitClientOrderId"));
        Assert.Equal("1", seen.Param("limitStrategyId"));
        Assert.Equal("1", seen.Param("limitStrategyType"));
        Assert.Equal("1", seen.Param("limitIcebergQty"));
        Assert.Equal("1", seen.Param("trailingDelta"));
        Assert.Equal("stopOrder1", seen.Param("stopClientOrderId"));
        Assert.Equal("1", seen.Param("stopStrategyId"));
        Assert.Equal("1", seen.Param("stopStrategyType"));
        Assert.Equal("1", seen.Param("stopLimitPrice"));
        Assert.Equal("1", seen.Param("stopIcebergQty"));
        Assert.Equal("GTC", seen.Param("stopLimitTimeInForce"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderOcoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderOcoSide.Buy,
            Quantity = 1m,
            Price = 1m,
            StopPrice = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderOcoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

#pragma warning restore CS0618

    [Fact]
    public async Task OrderTestAsync()
    {
        const string example = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"specialCommissionForOrder":{"maker":"0.05000000","taker":"0.06000000"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderTestSide.Buy,
            Type = OrderTestType.Market,
        };

        var response = await client.OrderTestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order/test", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderTestWithOptionalParametersAsync()
    {
        const string example = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"specialCommissionForOrder":{"maker":"0.05000000","taker":"0.06000000"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderTestSide.Buy,
            Type = OrderTestType.Market,
            ComputeCommissionRates = false,
            TimeInForce = OrderTestTimeInForce.Gtc,
            Quantity = 1m,
            QuoteOrderQty = 1m,
            Price = 400m,
            NewClientOrderId = "myOrder1",
            StrategyId = 1L,
            StrategyType = 1L,
            StopPrice = 1m,
            TrailingDelta = 1L,
            IcebergQty = 1m,
            NewOrderRespType = OrderTestNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderTestSelfTradePreventionMode.None,
            PegPriceType = OrderTestPegPriceType.PrimaryPeg,
            PegOffsetValue = 1L,
            PegOffsetType = OrderTestPegOffsetType.PriceLevel,
            QuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderTestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/order/test", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("false", seen.Param("computeCommissionRates"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("1", seen.Param("quoteOrderQty"));
        Assert.Equal("400", seen.Param("price"));
        Assert.Equal("myOrder1", seen.Param("newClientOrderId"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("strategyType"));
        Assert.Equal("1", seen.Param("stopPrice"));
        Assert.Equal("1", seen.Param("trailingDelta"));
        Assert.Equal("1", seen.Param("icebergQty"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("PRIMARY_PEG", seen.Param("pegPriceType"));
        Assert.Equal("1", seen.Param("pegOffsetValue"));
        Assert.Equal("PRICE_LEVEL", seen.Param("pegOffsetType"));
        Assert.Equal("100", seen.Param("quoteNotionalLimit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderTestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderTestSide.Buy,
            Type = OrderTestType.Market,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderTestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SorOrderAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":2,"orderListId":-1,"clientOrderId":"sBI1KM6nNtOfj5tccZSKly","transactTime":1689149087774,"price":"31000.00000000","origQty":"0.50000000","executedQty":"0.50000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"14000.00000000","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1689149087774,"fills":[{"matchType":"ONE_PARTY_TRADE_REPORT","price":"28000.00000000","qty":"0.50000000","commission":"0.00000000","commissionAsset":"BTC","tradeId":-1,"allocId":0}],"workingFloor":"SOR","selfTradePreventionMode":"NONE","usedSor":true,"stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SorOrderRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderSide.Buy,
            Type = SorOrderType.Market,
            Quantity = 1m,
        };

        var response = await client.SorOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/sor/order", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SorOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":2,"orderListId":-1,"clientOrderId":"sBI1KM6nNtOfj5tccZSKly","transactTime":1689149087774,"price":"31000.00000000","origQty":"0.50000000","executedQty":"0.50000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"14000.00000000","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1689149087774,"fills":[{"matchType":"ONE_PARTY_TRADE_REPORT","price":"28000.00000000","qty":"0.50000000","commission":"0.00000000","commissionAsset":"BTC","tradeId":-1,"allocId":0}],"workingFloor":"SOR","selfTradePreventionMode":"NONE","usedSor":true,"stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SorOrderRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderSide.Buy,
            Type = SorOrderType.Market,
            Quantity = 1m,
            TimeInForce = SorOrderTimeInForce.Gtc,
            Price = 400m,
            NewClientOrderId = "myOrder1",
            StrategyId = 1L,
            StrategyType = 1L,
            IcebergQty = 1m,
            NewOrderRespType = SorOrderNewOrderRespType.Ack,
            SelfTradePreventionMode = SorOrderSelfTradePreventionMode.None,
            RecvWindow = 5000m,
        };

        var response = await client.SorOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/sor/order", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("400", seen.Param("price"));
        Assert.Equal("myOrder1", seen.Param("newClientOrderId"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("strategyType"));
        Assert.Equal("1", seen.Param("icebergQty"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SorOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SorOrderRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderSide.Buy,
            Type = SorOrderType.Market,
            Quantity = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SorOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SorOrderTestAsync()
    {
        const string example = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SorOrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderTestSide.Buy,
            Type = SorOrderTestType.Market,
            Quantity = 1m,
        };

        var response = await client.SorOrderTestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/sor/order/test", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SorOrderTestWithOptionalParametersAsync()
    {
        const string example = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SorOrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderTestSide.Buy,
            Type = SorOrderTestType.Market,
            Quantity = 1m,
            ComputeCommissionRates = false,
            TimeInForce = SorOrderTestTimeInForce.Gtc,
            Price = 400m,
            NewClientOrderId = "myOrder1",
            StrategyId = 1L,
            StrategyType = 1L,
            IcebergQty = 1m,
            NewOrderRespType = SorOrderTestNewOrderRespType.Ack,
            SelfTradePreventionMode = SorOrderTestSelfTradePreventionMode.None,
            RecvWindow = 5000m,
        };

        var response = await client.SorOrderTestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/api/v3/sor/order/test", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("MARKET", seen.Param("type"));
        Assert.Equal("1", seen.Param("quantity"));
        Assert.Equal("false", seen.Param("computeCommissionRates"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("400", seen.Param("price"));
        Assert.Equal("myOrder1", seen.Param("newClientOrderId"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("strategyType"));
        Assert.Equal("1", seen.Param("icebergQty"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SorOrderTestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SorOrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderTestSide.Buy,
            Type = SorOrderTestType.Market,
            Quantity = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SorOrderTestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
