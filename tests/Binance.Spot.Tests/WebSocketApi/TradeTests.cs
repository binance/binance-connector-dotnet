//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Spot.WebSocketApi;

namespace Binance.Spot.Tests.WebSocketApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    [Fact]
    public async Task OpenOrdersCancelAllAsync()
    {
        const string envelope = """""{"id":"778f938f-9041-4b88-9914-efbf64eeacc8","status":200,"result":[{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"trailingTime":-1,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE"},{"orderListId":19431,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"trailingTime":-1,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE"},{"orderListId":19431,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OpenOrdersCancelAllRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.OpenOrdersCancelAllAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("openOrders.cancelAll", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OpenOrdersCancelAllWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"778f938f-9041-4b88-9914-efbf64eeacc8","status":200,"result":[{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"trailingTime":-1,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE"},{"orderListId":19431,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"trailingTime":-1,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE"},{"orderListId":19431,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OpenOrdersCancelAllRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000m,
        };

        var response = await client.OpenOrdersCancelAllAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("openOrders.cancelAll", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OpenOrdersCancelAllBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OpenOrdersCancelAllRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OpenOrdersCancelAllAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderAmendKeepPriorityAsync()
    {
        const string envelope = """""{"id":"56374a46-3061-486b-a311-89ee972eb648","status":200,"result":{"transactTime":1741923284382,"executionId":16,"amendedOrder":{"symbol":"BTCUSDT","orderId":12,"orderListId":-1,"origClientOrderId":"my_test_order1","clientOrderId":"4zR9HFcEq8gM1tWUqPEUHc","price":"5.00000000","qty":"5.00000000","executedQty":"0.00000000","preventedQty":"0.00000000","quoteOrderQty":"0.00000000","cumulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1741923284364,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"listStatus":{"orderListId":4,"contingencyType":"OTO","listOrderStatus":"EXECUTING","listClientOrderId":"8nOGLLawudj1QoOiwbroRH","symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":22,"clientOrderId":"g04EWsjaackzedjC9wRkWD"},{"symbol":"BTCUSDT","orderId":23,"clientOrderId":"xbxXh5SSwaHS7oUEOCI88B"}]}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"transactTime":1741923284382,"executionId":16,"amendedOrder":{"symbol":"BTCUSDT","orderId":12,"orderListId":-1,"origClientOrderId":"my_test_order1","clientOrderId":"4zR9HFcEq8gM1tWUqPEUHc","price":"5.00000000","qty":"5.00000000","executedQty":"0.00000000","preventedQty":"0.00000000","quoteOrderQty":"0.00000000","cumulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1741923284364,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"listStatus":{"orderListId":4,"contingencyType":"OTO","listOrderStatus":"EXECUTING","listClientOrderId":"8nOGLLawudj1QoOiwbroRH","symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":22,"clientOrderId":"g04EWsjaackzedjC9wRkWD"},{"symbol":"BTCUSDT","orderId":23,"clientOrderId":"xbxXh5SSwaHS7oUEOCI88B"}]}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderAmendKeepPriorityRequest
        {
            Symbol = "BNBUSDT",
            NewQty = 5m,
        };

        var response = await client.OrderAmendKeepPriorityAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.amend.keepPriority", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("5", frame.Param("newQty"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderAmendKeepPriorityWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"56374a46-3061-486b-a311-89ee972eb648","status":200,"result":{"transactTime":1741923284382,"executionId":16,"amendedOrder":{"symbol":"BTCUSDT","orderId":12,"orderListId":-1,"origClientOrderId":"my_test_order1","clientOrderId":"4zR9HFcEq8gM1tWUqPEUHc","price":"5.00000000","qty":"5.00000000","executedQty":"0.00000000","preventedQty":"0.00000000","quoteOrderQty":"0.00000000","cumulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1741923284364,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"listStatus":{"orderListId":4,"contingencyType":"OTO","listOrderStatus":"EXECUTING","listClientOrderId":"8nOGLLawudj1QoOiwbroRH","symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":22,"clientOrderId":"g04EWsjaackzedjC9wRkWD"},{"symbol":"BTCUSDT","orderId":23,"clientOrderId":"xbxXh5SSwaHS7oUEOCI88B"}]}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"transactTime":1741923284382,"executionId":16,"amendedOrder":{"symbol":"BTCUSDT","orderId":12,"orderListId":-1,"origClientOrderId":"my_test_order1","clientOrderId":"4zR9HFcEq8gM1tWUqPEUHc","price":"5.00000000","qty":"5.00000000","executedQty":"0.00000000","preventedQty":"0.00000000","quoteOrderQty":"0.00000000","cumulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1741923284364,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"listStatus":{"orderListId":4,"contingencyType":"OTO","listOrderStatus":"EXECUTING","listClientOrderId":"8nOGLLawudj1QoOiwbroRH","symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":22,"clientOrderId":"g04EWsjaackzedjC9wRkWD"},{"symbol":"BTCUSDT","orderId":23,"clientOrderId":"xbxXh5SSwaHS7oUEOCI88B"}]}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderAmendKeepPriorityRequest
        {
            Symbol = "BNBUSDT",
            NewQty = 5m,
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "myOrder1",
            NewClientOrderId = "myOrder2",
            RecvWindow = 5000m,
        };

        var response = await client.OrderAmendKeepPriorityAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.amend.keepPriority", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("5", frame.Param("newQty"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("myOrder1", frame.Param("origClientOrderId"));
        Assert.Equal("myOrder2", frame.Param("newClientOrderId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderAmendKeepPriorityBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderAmendKeepPriorityRequest
        {
            Symbol = "BNBUSDT",
            NewQty = 5m,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderAmendKeepPriorityAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderCancelAsync()
    {
        const string envelope = """""{"id":"5633b6a2-90a9-4192-83e7-925c90b6a2fd","status":200,"result":{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderCancelRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.OrderCancelAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.cancel", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderCancelWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"5633b6a2-90a9-4192-83e7-925c90b6a2fd","status":200,"result":{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":12569099453,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23416100","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":0,"icebergQty":"0.00000000","strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"iuVNVJYYrByz6C4yGOPPK0","transactionTime":1660803702431,"orders":[{"symbol":"BTCUSDT","orderId":12569099453,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY"},{"symbol":"BTCUSDT","orderId":12569099454,"clientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"bX5wROblo6YeDwa9iTLeyY","orderId":12569099453,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23450.50000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"23430.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","origClientOrderId":"Tnu2IP0J5Y4mxw3IATBfmW","orderId":12569099454,"orderListId":19431,"clientOrderId":"OFFXQtxVFZ6Nbcg4PgE2DA","transactTime":1684804350068,"price":"23400.00000000","origQty":"0.00850000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderCancelRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "myOrder1",
            NewClientOrderId = "cancelMyOrder1",
            CancelRestrictions = OrderCancelCancelRestrictions.OnlyNew,
            RecvWindow = 5000m,
        };

        var response = await client.OrderCancelAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.cancel", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("myOrder1", frame.Param("origClientOrderId"));
        Assert.Equal("cancelMyOrder1", frame.Param("newClientOrderId"));
        Assert.Equal("ONLY_NEW", frame.Param("cancelRestrictions"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderCancelBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderCancelRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderCancelAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderCancelReplaceAsync()
    {
        const string envelope = """""{"id":"99de1036-b5e2-4e0f-9b5c-13d751c93a1a","status":200,"result":{"cancelResult":"SUCCESS","newOrderResult":"SUCCESS","cancelResponse":{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":125690984230,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23450.00000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23450000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"newOrderResponse":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY","transactTime":1660813156959,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":1},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":1},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"cancelResult":"SUCCESS","newOrderResult":"SUCCESS","cancelResponse":{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":125690984230,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23450.00000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23450000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"newOrderResponse":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY","transactTime":1660813156959,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderCancelReplaceRequest
        {
            Symbol = "BNBUSDT",
            CancelReplaceMode = OrderCancelReplaceCancelReplaceMode.StopOnFailure,
            Side = OrderCancelReplaceSide.Buy,
            Type = OrderCancelReplaceType.Market,
        };

        var response = await client.OrderCancelReplaceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.cancelReplace", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("STOP_ON_FAILURE", frame.Param("cancelReplaceMode"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderCancelReplaceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"99de1036-b5e2-4e0f-9b5c-13d751c93a1a","status":200,"result":{"cancelResult":"SUCCESS","newOrderResult":"SUCCESS","cancelResponse":{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":125690984230,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23450.00000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23450000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"newOrderResponse":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY","transactTime":1660813156959,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":1},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":1},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"cancelResult":"SUCCESS","newOrderResult":"SUCCESS","cancelResponse":{"symbol":"BTCUSDT","origClientOrderId":"4d96324ff9d44481926157","orderId":125690984230,"orderListId":-1,"clientOrderId":"91fe37ce9e69c90d6358c0","transactTime":1684804350068,"price":"23450.00000000","origQty":"0.00847000","executedQty":"0.00001000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.23450000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"newOrderResponse":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"bX5wROblo6YeDwa9iTLeyY","transactTime":1660813156959,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderCancelReplaceRequest
        {
            Symbol = "BNBUSDT",
            CancelReplaceMode = OrderCancelReplaceCancelReplaceMode.StopOnFailure,
            Side = OrderCancelReplaceSide.Buy,
            Type = OrderCancelReplaceType.Market,
            Id = "0123456789abcdef0123456789abcdef",
            CancelOrderId = 1L,
            CancelOrigClientOrderId = "myOrder1",
            CancelNewClientOrderId = "cancelMyOrder1",
            TimeInForce = OrderCancelReplaceTimeInForce.Gtc,
            Price = 1m,
            Quantity = 1m,
            QuoteOrderQty = 1m,
            NewClientOrderId = "myOrder2",
            NewOrderRespType = OrderCancelReplaceNewOrderRespType.Ack,
            StopPrice = 1m,
            TrailingDelta = 1m,
            IcebergQty = 1m,
            StrategyId = 1L,
            StrategyType = 1L,
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

        var frame = server.ApiRequest();
        Assert.Equal("order.cancelReplace", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("STOP_ON_FAILURE", frame.Param("cancelReplaceMode"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("cancelOrderId"));
        Assert.Equal("myOrder1", frame.Param("cancelOrigClientOrderId"));
        Assert.Equal("cancelMyOrder1", frame.Param("cancelNewClientOrderId"));
        Assert.Equal("GTC", frame.Param("timeInForce"));
        Assert.Equal("1", frame.Param("price"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("1", frame.Param("quoteOrderQty"));
        Assert.Equal("myOrder2", frame.Param("newClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("1", frame.Param("stopPrice"));
        Assert.Equal("1", frame.Param("trailingDelta"));
        Assert.Equal("1", frame.Param("icebergQty"));
        Assert.Equal("1", frame.Param("strategyId"));
        Assert.Equal("1", frame.Param("strategyType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("ONLY_NEW", frame.Param("cancelRestrictions"));
        Assert.Equal("DO_NOTHING", frame.Param("orderRateLimitExceededMode"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pegPriceType"));
        Assert.Equal("1", frame.Param("pegOffsetValue"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pegOffsetType"));
        Assert.Equal("100", frame.Param("quoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderCancelReplaceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderCancelReplaceRequest
        {
            Symbol = "BNBUSDT",
            CancelReplaceMode = OrderCancelReplaceCancelReplaceMode.StopOnFailure,
            Side = OrderCancelReplaceSide.Buy,
            Type = OrderCancelReplaceType.Market,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderCancelReplaceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListCancelAsync()
    {
        const string envelope = """""{"id":"c5899911-d3f4-47ae-8835-97da553d27d0","status":200,"result":{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"6023531d7edaad348f5aff","transactionTime":1660801720215,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801720215,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801720215,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"6023531d7edaad348f5aff","transactionTime":1660801720215,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801720215,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801720215,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListCancelRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.OrderListCancelAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.cancel", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListCancelWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"c5899911-d3f4-47ae-8835-97da553d27d0","status":200,"result":{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"6023531d7edaad348f5aff","transactionTime":1660801720215,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801720215,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801720215,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"6023531d7edaad348f5aff","transactionTime":1660801720215,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801720215,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801720215,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListCancelRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            OrderListId = 1L,
            ListClientOrderId = "C3wyj4WVEktd7u9aVBRXcN",
            NewClientOrderId = "cancelMyOrder1",
            RecvWindow = 5000m,
        };

        var response = await client.OrderListCancelAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.cancel", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderListId"));
        Assert.Equal("C3wyj4WVEktd7u9aVBRXcN", frame.Param("listClientOrderId"));
        Assert.Equal("cancelMyOrder1", frame.Param("newClientOrderId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListCancelBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderListCancelRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListCancelAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

#pragma warning disable CS0618 // This endpoint is deprecated.
    [Fact]
    public async Task OrderListPlaceAsync()
    {
        const string envelope = """""{"id":"57833dc0-e3f2-43fb-ba20-46480973b0aa","status":200,"result":{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801713793,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801713793,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":1660801713793,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":2},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":2},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801713793,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801713793,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":1660801713793,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListPlaceSide.Buy,
            Price = 1m,
            Quantity = 1m,
        };

        var response = await client.OrderListPlaceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("1", frame.Param("price"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"57833dc0-e3f2-43fb-ba20-46480973b0aa","status":200,"result":{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801713793,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801713793,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":1660801713793,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":2},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":2},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}],"orderReports":[{"symbol":"BTCUSDT","orderId":12569138901,"orderListId":1274512,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU","transactTime":1660801713793,"price":"23410.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"23405.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":12569138902,"orderListId":1274512,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us","transactTime":1660801713793,"price":"23420.00000000","origQty":"0.00650000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":1660801713793,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListPlaceSide.Buy,
            Price = 1m,
            Quantity = 1m,
            Id = "0123456789abcdef0123456789abcdef",
            ListClientOrderId = "08985fedd9ea2cf6b28996",
            LimitClientOrderId = "limitOrder1",
            LimitIcebergQty = 1m,
            LimitStrategyId = 1L,
            LimitStrategyType = 1L,
            StopPrice = 1m,
            TrailingDelta = 1L,
            StopClientOrderId = "stopOrder1",
            StopLimitPrice = 1m,
            StopLimitTimeInForce = OrderListPlaceStopLimitTimeInForce.Gtc,
            StopIcebergQty = 1m,
            StopStrategyId = 1L,
            StopStrategyType = 1L,
            NewOrderRespType = OrderListPlaceNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListPlaceSelfTradePreventionMode.None,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListPlaceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("1", frame.Param("price"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("08985fedd9ea2cf6b28996", frame.Param("listClientOrderId"));
        Assert.Equal("limitOrder1", frame.Param("limitClientOrderId"));
        Assert.Equal("1", frame.Param("limitIcebergQty"));
        Assert.Equal("1", frame.Param("limitStrategyId"));
        Assert.Equal("1", frame.Param("limitStrategyType"));
        Assert.Equal("1", frame.Param("stopPrice"));
        Assert.Equal("1", frame.Param("trailingDelta"));
        Assert.Equal("stopOrder1", frame.Param("stopClientOrderId"));
        Assert.Equal("1", frame.Param("stopLimitPrice"));
        Assert.Equal("GTC", frame.Param("stopLimitTimeInForce"));
        Assert.Equal("1", frame.Param("stopIcebergQty"));
        Assert.Equal("1", frame.Param("stopStrategyId"));
        Assert.Equal("1", frame.Param("stopStrategyType"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderListPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListPlaceSide.Buy,
            Price = 1m,
            Quantity = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListPlaceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
#pragma warning restore CS0618

    [Fact]
    public async Task OrderListPlaceOcoAsync()
    {
        const string envelope = """""{"id":"56374a46-3261-486b-a211-99ed972eb648","status":200,"result":{"orderListId":2,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"cKPMnDCbcLQILtDYM4f4fX","transactionTime":1711062760648,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU"},{"symbol":"LTCBNB","orderId":3,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW"}],"orderReports":[{"symbol":"LTCBNB","orderId":2,"orderListId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU","transactTime":1711062760648,"price":"1.50000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"1.50000001","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":3,"orderListId":2,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW","transactTime":1711062760648,"price":"1.49999999","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":1711062760648,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":2},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":2},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"orderListId":2,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"cKPMnDCbcLQILtDYM4f4fX","transactionTime":1711062760648,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU"},{"symbol":"LTCBNB","orderId":3,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW"}],"orderReports":[{"symbol":"LTCBNB","orderId":2,"orderListId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU","transactTime":1711062760648,"price":"1.50000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"1.50000001","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":3,"orderListId":2,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW","transactTime":1711062760648,"price":"1.49999999","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":1711062760648,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListPlaceOcoSide.Buy,
            Quantity = 1m,
            AboveType = OrderListPlaceOcoAboveType.StopLossLimit,
            BelowType = OrderListPlaceOcoBelowType.StopLoss,
        };

        var response = await client.OrderListPlaceOcoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.oco", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("STOP_LOSS_LIMIT", frame.Param("aboveType"));
        Assert.Equal("STOP_LOSS", frame.Param("belowType"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOcoWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"56374a46-3261-486b-a211-99ed972eb648","status":200,"result":{"orderListId":2,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"cKPMnDCbcLQILtDYM4f4fX","transactionTime":1711062760648,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU"},{"symbol":"LTCBNB","orderId":3,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW"}],"orderReports":[{"symbol":"LTCBNB","orderId":2,"orderListId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU","transactTime":1711062760648,"price":"1.50000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"1.50000001","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":3,"orderListId":2,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW","transactTime":1711062760648,"price":"1.49999999","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":1711062760648,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":2},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":2},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"orderListId":2,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"cKPMnDCbcLQILtDYM4f4fX","transactionTime":1711062760648,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU"},{"symbol":"LTCBNB","orderId":3,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW"}],"orderReports":[{"symbol":"LTCBNB","orderId":2,"orderListId":2,"clientOrderId":"0m6I4wfxvTUrOBSMUl0OPU","transactTime":1711062760648,"price":"1.50000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"1.50000001","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":3,"orderListId":2,"clientOrderId":"Z2IMlR79XNY5LU0tOxrWyW","transactTime":1711062760648,"price":"1.49999999","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"BUY","workingTime":1711062760648,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListPlaceOcoSide.Buy,
            Quantity = 1m,
            AboveType = OrderListPlaceOcoAboveType.StopLossLimit,
            BelowType = OrderListPlaceOcoBelowType.StopLoss,
            Id = "0123456789abcdef0123456789abcdef",
            ListClientOrderId = "cKPMnDCbcLQILtDYM4f4fX",
            AboveClientOrderId = "aboveOrder1",
            AboveIcebergQty = 1m,
            AbovePrice = 1.5m,
            AboveStopPrice = 1.50000001m,
            AboveTrailingDelta = 1L,
            AboveTimeInForce = OrderListPlaceOcoAboveTimeInForce.Gtc,
            AboveStrategyId = 1L,
            AboveStrategyType = 1L,
            AbovePegPriceType = OrderListPlaceOcoAbovePegPriceType.PrimaryPeg,
            AbovePegOffsetType = OrderListPlaceOcoAbovePegOffsetType.PriceLevel,
            AbovePegOffsetValue = 1L,
            BelowClientOrderId = "belowOrder1",
            BelowIcebergQty = 1m,
            BelowPrice = 1.49999999m,
            BelowStopPrice = 1.50000001m,
            BelowTrailingDelta = 1L,
            BelowTimeInForce = OrderListPlaceOcoBelowTimeInForce.Gtc,
            BelowStrategyId = 1L,
            BelowStrategyType = 1L,
            BelowPegPriceType = OrderListPlaceOcoBelowPegPriceType.PrimaryPeg,
            BelowPegOffsetType = OrderListPlaceOcoBelowPegOffsetType.PriceLevel,
            BelowPegOffsetValue = 1L,
            NewOrderRespType = OrderListPlaceOcoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListPlaceOcoSelfTradePreventionMode.None,
            AboveQuoteNotionalLimit = 100m,
            BelowQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListPlaceOcoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.oco", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("STOP_LOSS_LIMIT", frame.Param("aboveType"));
        Assert.Equal("STOP_LOSS", frame.Param("belowType"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("cKPMnDCbcLQILtDYM4f4fX", frame.Param("listClientOrderId"));
        Assert.Equal("aboveOrder1", frame.Param("aboveClientOrderId"));
        Assert.Equal("1", frame.Param("aboveIcebergQty"));
        Assert.Equal("1.5", frame.Param("abovePrice"));
        Assert.Equal("1.50000001", frame.Param("aboveStopPrice"));
        Assert.Equal("1", frame.Param("aboveTrailingDelta"));
        Assert.Equal("GTC", frame.Param("aboveTimeInForce"));
        Assert.Equal("1", frame.Param("aboveStrategyId"));
        Assert.Equal("1", frame.Param("aboveStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("abovePegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("abovePegOffsetType"));
        Assert.Equal("1", frame.Param("abovePegOffsetValue"));
        Assert.Equal("belowOrder1", frame.Param("belowClientOrderId"));
        Assert.Equal("1", frame.Param("belowIcebergQty"));
        Assert.Equal("1.49999999", frame.Param("belowPrice"));
        Assert.Equal("1.50000001", frame.Param("belowStopPrice"));
        Assert.Equal("1", frame.Param("belowTrailingDelta"));
        Assert.Equal("GTC", frame.Param("belowTimeInForce"));
        Assert.Equal("1", frame.Param("belowStrategyId"));
        Assert.Equal("1", frame.Param("belowStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("belowPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("belowPegOffsetType"));
        Assert.Equal("1", frame.Param("belowPegOffsetValue"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("100", frame.Param("aboveQuoteNotionalLimit"));
        Assert.Equal("100", frame.Param("belowQuoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOcoBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderListPlaceOcoRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderListPlaceOcoSide.Buy,
            Quantity = 1m,
            AboveType = OrderListPlaceOcoAboveType.StopLossLimit,
            BelowType = OrderListPlaceOcoBelowType.StopLoss,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListPlaceOcoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListPlaceOpoAsync()
    {
        const string envelope = """""{"id":"eabb220d-1c53-4f8a-8bca-a1cd3594b3ce","status":200,"result":{"orderListId":2,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"OiOgqvRagBefpzdM5gjYX3","transactionTime":1762941318142,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH"},{"symbol":"BTCUSDT","orderId":3,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd"}],"orderReports":[{"symbol":"BTCUSDT","orderId":2,"orderListId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH","transactTime":1762941318142,"price":"101496.00000000","origQty":"0.00070000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1762941318142,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":3,"orderListId":2,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd","transactTime":1762941318142,"price":"0.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}}""""";
        const string result = """""{"orderListId":2,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"OiOgqvRagBefpzdM5gjYX3","transactionTime":1762941318142,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH"},{"symbol":"BTCUSDT","orderId":3,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd"}],"orderReports":[{"symbol":"BTCUSDT","orderId":2,"orderListId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH","transactTime":1762941318142,"price":"101496.00000000","origQty":"0.00070000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1762941318142,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":3,"orderListId":2,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd","transactTime":1762941318142,"price":"0.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOpoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOpoWorkingType.Limit,
            WorkingSide = OrderListPlaceOpoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListPlaceOpoPendingType.Limit,
            PendingSide = OrderListPlaceOpoPendingSide.Buy,
        };

        var response = await client.OrderListPlaceOpoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.opo", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("LIMIT", frame.Param("pendingType"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOpoWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"eabb220d-1c53-4f8a-8bca-a1cd3594b3ce","status":200,"result":{"orderListId":2,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"OiOgqvRagBefpzdM5gjYX3","transactionTime":1762941318142,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH"},{"symbol":"BTCUSDT","orderId":3,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd"}],"orderReports":[{"symbol":"BTCUSDT","orderId":2,"orderListId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH","transactTime":1762941318142,"price":"101496.00000000","origQty":"0.00070000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1762941318142,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":3,"orderListId":2,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd","transactTime":1762941318142,"price":"0.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}}""""";
        const string result = """""{"orderListId":2,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"OiOgqvRagBefpzdM5gjYX3","transactionTime":1762941318142,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH"},{"symbol":"BTCUSDT","orderId":3,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd"}],"orderReports":[{"symbol":"BTCUSDT","orderId":2,"orderListId":2,"clientOrderId":"pUzhKBbc0ZVdMScIRAqitH","transactTime":1762941318142,"price":"101496.00000000","origQty":"0.00070000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1762941318142,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":3,"orderListId":2,"clientOrderId":"x7ISSjywZxFXOdzwsThNnd","transactTime":1762941318142,"price":"0.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOpoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOpoWorkingType.Limit,
            WorkingSide = OrderListPlaceOpoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListPlaceOpoPendingType.Limit,
            PendingSide = OrderListPlaceOpoPendingSide.Buy,
            Id = "0123456789abcdef0123456789abcdef",
            ListClientOrderId = "OiOgqvRagBefpzdM5gjYX3",
            NewOrderRespType = OrderListPlaceOpoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListPlaceOpoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListPlaceOpoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListPlaceOpoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListPlaceOpoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingClientOrderId = "pendingOrder1",
            PendingPrice = 1m,
            PendingStopPrice = 1m,
            PendingTrailingDelta = 1m,
            PendingIcebergQty = 1m,
            PendingTimeInForce = OrderListPlaceOpoPendingTimeInForce.Gtc,
            PendingStrategyId = 1L,
            PendingStrategyType = 1L,
            PendingPegPriceType = OrderListPlaceOpoPendingPegPriceType.PrimaryPeg,
            PendingPegOffsetType = OrderListPlaceOpoPendingPegOffsetType.PriceLevel,
            PendingPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListPlaceOpoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.opo", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("LIMIT", frame.Param("pendingType"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("OiOgqvRagBefpzdM5gjYX3", frame.Param("listClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", frame.Param("workingClientOrderId"));
        Assert.Equal("1", frame.Param("workingIcebergQty"));
        Assert.Equal("GTC", frame.Param("workingTimeInForce"));
        Assert.Equal("1", frame.Param("workingStrategyId"));
        Assert.Equal("1", frame.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("workingPegOffsetType"));
        Assert.Equal("1", frame.Param("workingPegOffsetValue"));
        Assert.Equal("pendingOrder1", frame.Param("pendingClientOrderId"));
        Assert.Equal("1", frame.Param("pendingPrice"));
        Assert.Equal("1", frame.Param("pendingStopPrice"));
        Assert.Equal("1", frame.Param("pendingTrailingDelta"));
        Assert.Equal("1", frame.Param("pendingIcebergQty"));
        Assert.Equal("GTC", frame.Param("pendingTimeInForce"));
        Assert.Equal("1", frame.Param("pendingStrategyId"));
        Assert.Equal("1", frame.Param("pendingStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pendingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pendingPegOffsetType"));
        Assert.Equal("1", frame.Param("pendingPegOffsetValue"));
        Assert.Equal("100", frame.Param("workingQuoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOpoBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderListPlaceOpoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOpoWorkingType.Limit,
            WorkingSide = OrderListPlaceOpoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListPlaceOpoPendingType.Limit,
            PendingSide = OrderListPlaceOpoPendingSide.Buy,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListPlaceOpoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListPlaceOpocoAsync()
    {
        const string envelope = """""{"id":"606063bf-43ea-40a6-a463-5c66fbd53b56","status":200,"result":{"orderListId":1,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"TVbG6ymkYMXTj7tczbOsBf","transactionTime":1763000139104,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":6,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3"},{"symbol":"BTCUSDT","orderId":7,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo"},{"symbol":"BTCUSDT","orderId":8,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ"}],"orderReports":[{"symbol":"BTCUSDT","orderId":6,"orderListId":1,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3","transactTime":1763000139104,"price":"102496.00000000","origQty":"0.00170000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1763000139104,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":7,"orderListId":1,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo","transactTime":1763000139104,"price":"101613.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"IOC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"10100.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":8,"orderListId":1,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ","transactTime":1763000139104,"price":"104261.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}}""""";
        const string result = """""{"orderListId":1,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"TVbG6ymkYMXTj7tczbOsBf","transactionTime":1763000139104,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":6,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3"},{"symbol":"BTCUSDT","orderId":7,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo"},{"symbol":"BTCUSDT","orderId":8,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ"}],"orderReports":[{"symbol":"BTCUSDT","orderId":6,"orderListId":1,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3","transactTime":1763000139104,"price":"102496.00000000","origQty":"0.00170000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1763000139104,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":7,"orderListId":1,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo","transactTime":1763000139104,"price":"101613.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"IOC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"10100.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":8,"orderListId":1,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ","transactTime":1763000139104,"price":"104261.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOpocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOpocoWorkingType.Limit,
            WorkingSide = OrderListPlaceOpocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListPlaceOpocoPendingSide.Buy,
            PendingAboveType = OrderListPlaceOpocoPendingAboveType.StopLossLimit,
        };

        var response = await client.OrderListPlaceOpocoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.opoco", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("STOP_LOSS_LIMIT", frame.Param("pendingAboveType"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOpocoWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"606063bf-43ea-40a6-a463-5c66fbd53b56","status":200,"result":{"orderListId":1,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"TVbG6ymkYMXTj7tczbOsBf","transactionTime":1763000139104,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":6,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3"},{"symbol":"BTCUSDT","orderId":7,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo"},{"symbol":"BTCUSDT","orderId":8,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ"}],"orderReports":[{"symbol":"BTCUSDT","orderId":6,"orderListId":1,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3","transactTime":1763000139104,"price":"102496.00000000","origQty":"0.00170000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1763000139104,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":7,"orderListId":1,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo","transactTime":1763000139104,"price":"101613.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"IOC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"10100.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":8,"orderListId":1,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ","transactTime":1763000139104,"price":"104261.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}}""""";
        const string result = """""{"orderListId":1,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"TVbG6ymkYMXTj7tczbOsBf","transactionTime":1763000139104,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":6,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3"},{"symbol":"BTCUSDT","orderId":7,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo"},{"symbol":"BTCUSDT","orderId":8,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ"}],"orderReports":[{"symbol":"BTCUSDT","orderId":6,"orderListId":1,"clientOrderId":"3czuJSeyjPwV9Xo28j1Dv3","transactTime":1763000139104,"price":"102496.00000000","origQty":"0.00170000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1763000139104,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":7,"orderListId":1,"clientOrderId":"kyIKnMLKQclE5FmyYgaMSo","transactTime":1763000139104,"price":"101613.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"IOC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"10100.00000000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"BTCUSDT","orderId":8,"orderListId":1,"clientOrderId":"i76cGJWN9J1FpADS56TtQZ","transactTime":1763000139104,"price":"104261.00000000","executedQty":"0.00000000","origQuoteOrderQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOpocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOpocoWorkingType.Limit,
            WorkingSide = OrderListPlaceOpocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListPlaceOpocoPendingSide.Buy,
            PendingAboveType = OrderListPlaceOpocoPendingAboveType.StopLossLimit,
            Id = "0123456789abcdef0123456789abcdef",
            ListClientOrderId = "TVbG6ymkYMXTj7tczbOsBf",
            NewOrderRespType = OrderListPlaceOpocoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListPlaceOpocoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListPlaceOpocoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListPlaceOpocoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListPlaceOpocoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingAboveClientOrderId = "pendingAboveOrder1",
            PendingAbovePrice = 1m,
            PendingAboveStopPrice = 1m,
            PendingAboveTrailingDelta = 1m,
            PendingAboveIcebergQty = 1m,
            PendingAboveTimeInForce = OrderListPlaceOpocoPendingAboveTimeInForce.Gtc,
            PendingAboveStrategyId = 1L,
            PendingAboveStrategyType = 1L,
            PendingAbovePegPriceType = OrderListPlaceOpocoPendingAbovePegPriceType.PrimaryPeg,
            PendingAbovePegOffsetType = OrderListPlaceOpocoPendingAbovePegOffsetType.PriceLevel,
            PendingAbovePegOffsetValue = 1L,
            PendingBelowType = OrderListPlaceOpocoPendingBelowType.StopLoss,
            PendingBelowClientOrderId = "pendingBelowOrder1",
            PendingBelowPrice = 1m,
            PendingBelowStopPrice = 1m,
            PendingBelowTrailingDelta = 1m,
            PendingBelowIcebergQty = 1m,
            PendingBelowTimeInForce = OrderListPlaceOpocoPendingBelowTimeInForce.Gtc,
            PendingBelowStrategyId = 1L,
            PendingBelowStrategyType = 1L,
            PendingBelowPegPriceType = OrderListPlaceOpocoPendingBelowPegPriceType.PrimaryPeg,
            PendingBelowPegOffsetType = OrderListPlaceOpocoPendingBelowPegOffsetType.PriceLevel,
            PendingBelowPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListPlaceOpocoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.opoco", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("STOP_LOSS_LIMIT", frame.Param("pendingAboveType"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("TVbG6ymkYMXTj7tczbOsBf", frame.Param("listClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", frame.Param("workingClientOrderId"));
        Assert.Equal("1", frame.Param("workingIcebergQty"));
        Assert.Equal("GTC", frame.Param("workingTimeInForce"));
        Assert.Equal("1", frame.Param("workingStrategyId"));
        Assert.Equal("1", frame.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("workingPegOffsetType"));
        Assert.Equal("1", frame.Param("workingPegOffsetValue"));
        Assert.Equal("pendingAboveOrder1", frame.Param("pendingAboveClientOrderId"));
        Assert.Equal("1", frame.Param("pendingAbovePrice"));
        Assert.Equal("1", frame.Param("pendingAboveStopPrice"));
        Assert.Equal("1", frame.Param("pendingAboveTrailingDelta"));
        Assert.Equal("1", frame.Param("pendingAboveIcebergQty"));
        Assert.Equal("GTC", frame.Param("pendingAboveTimeInForce"));
        Assert.Equal("1", frame.Param("pendingAboveStrategyId"));
        Assert.Equal("1", frame.Param("pendingAboveStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pendingAbovePegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pendingAbovePegOffsetType"));
        Assert.Equal("1", frame.Param("pendingAbovePegOffsetValue"));
        Assert.Equal("STOP_LOSS", frame.Param("pendingBelowType"));
        Assert.Equal("pendingBelowOrder1", frame.Param("pendingBelowClientOrderId"));
        Assert.Equal("1", frame.Param("pendingBelowPrice"));
        Assert.Equal("1", frame.Param("pendingBelowStopPrice"));
        Assert.Equal("1", frame.Param("pendingBelowTrailingDelta"));
        Assert.Equal("1", frame.Param("pendingBelowIcebergQty"));
        Assert.Equal("GTC", frame.Param("pendingBelowTimeInForce"));
        Assert.Equal("1", frame.Param("pendingBelowStrategyId"));
        Assert.Equal("1", frame.Param("pendingBelowStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pendingBelowPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pendingBelowPegOffsetType"));
        Assert.Equal("1", frame.Param("pendingBelowPegOffsetValue"));
        Assert.Equal("100", frame.Param("workingQuoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOpocoBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderListPlaceOpocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOpocoWorkingType.Limit,
            WorkingSide = OrderListPlaceOpocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListPlaceOpocoPendingSide.Buy,
            PendingAboveType = OrderListPlaceOpocoPendingAboveType.StopLossLimit,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListPlaceOpocoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListPlaceOtoAsync()
    {
        const string envelope = """""{"id":"1712544395950","status":200,"result":{"orderListId":626,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"KA4EBjGnzvSwSCQsDdTrlf","transactionTime":1712544395981,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":13,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny"},{"symbol":"LTCBNB","orderId":14,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R"}],"orderReports":[{"symbol":"LTCBNB","orderId":13,"orderListId":626,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny","transactTime":1712544395981,"price":"1.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712544395981,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":14,"orderListId":626,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R","transactTime":1712544395981,"price":"0.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"MINUTE","intervalNum":1,"limit":10000000,"count":10},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":1000,"count":38}]}""""";
        const string result = """""{"orderListId":626,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"KA4EBjGnzvSwSCQsDdTrlf","transactionTime":1712544395981,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":13,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny"},{"symbol":"LTCBNB","orderId":14,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R"}],"orderReports":[{"symbol":"LTCBNB","orderId":13,"orderListId":626,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny","transactTime":1712544395981,"price":"1.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712544395981,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":14,"orderListId":626,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R","transactTime":1712544395981,"price":"0.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOtoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOtoWorkingType.Limit,
            WorkingSide = OrderListPlaceOtoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListPlaceOtoPendingType.Limit,
            PendingSide = OrderListPlaceOtoPendingSide.Buy,
            PendingQuantity = 1m,
        };

        var response = await client.OrderListPlaceOtoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.oto", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("LIMIT", frame.Param("pendingType"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("1", frame.Param("pendingQuantity"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOtoWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"1712544395950","status":200,"result":{"orderListId":626,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"KA4EBjGnzvSwSCQsDdTrlf","transactionTime":1712544395981,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":13,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny"},{"symbol":"LTCBNB","orderId":14,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R"}],"orderReports":[{"symbol":"LTCBNB","orderId":13,"orderListId":626,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny","transactTime":1712544395981,"price":"1.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712544395981,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":14,"orderListId":626,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R","transactTime":1712544395981,"price":"0.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"MINUTE","intervalNum":1,"limit":10000000,"count":10},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":1000,"count":38}]}""""";
        const string result = """""{"orderListId":626,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"KA4EBjGnzvSwSCQsDdTrlf","transactionTime":1712544395981,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":13,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny"},{"symbol":"LTCBNB","orderId":14,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R"}],"orderReports":[{"symbol":"LTCBNB","orderId":13,"orderListId":626,"clientOrderId":"YiAUtM9yJjl1a2jXHSp9Ny","transactTime":1712544395981,"price":"1.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1712544395981,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":14,"orderListId":626,"clientOrderId":"9MxJSE1TYkmyx5lbGLve7R","transactTime":1712544395981,"price":"0.000000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"MARKET","side":"BUY","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOtoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOtoWorkingType.Limit,
            WorkingSide = OrderListPlaceOtoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListPlaceOtoPendingType.Limit,
            PendingSide = OrderListPlaceOtoPendingSide.Buy,
            PendingQuantity = 1m,
            Id = "0123456789abcdef0123456789abcdef",
            ListClientOrderId = "KA4EBjGnzvSwSCQsDdTrlf",
            NewOrderRespType = OrderListPlaceOtoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListPlaceOtoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListPlaceOtoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListPlaceOtoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListPlaceOtoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingClientOrderId = "pendingOrder1",
            PendingPrice = 1m,
            PendingStopPrice = 1m,
            PendingTrailingDelta = 1m,
            PendingIcebergQty = 1m,
            PendingTimeInForce = OrderListPlaceOtoPendingTimeInForce.Gtc,
            PendingStrategyId = 1L,
            PendingStrategyType = 1L,
            PendingPegOffsetType = OrderListPlaceOtoPendingPegOffsetType.PriceLevel,
            PendingPegPriceType = OrderListPlaceOtoPendingPegPriceType.PrimaryPeg,
            PendingPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            PendingQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListPlaceOtoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.oto", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("LIMIT", frame.Param("pendingType"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("1", frame.Param("pendingQuantity"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("KA4EBjGnzvSwSCQsDdTrlf", frame.Param("listClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", frame.Param("workingClientOrderId"));
        Assert.Equal("1", frame.Param("workingIcebergQty"));
        Assert.Equal("GTC", frame.Param("workingTimeInForce"));
        Assert.Equal("1", frame.Param("workingStrategyId"));
        Assert.Equal("1", frame.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("workingPegOffsetType"));
        Assert.Equal("1", frame.Param("workingPegOffsetValue"));
        Assert.Equal("pendingOrder1", frame.Param("pendingClientOrderId"));
        Assert.Equal("1", frame.Param("pendingPrice"));
        Assert.Equal("1", frame.Param("pendingStopPrice"));
        Assert.Equal("1", frame.Param("pendingTrailingDelta"));
        Assert.Equal("1", frame.Param("pendingIcebergQty"));
        Assert.Equal("GTC", frame.Param("pendingTimeInForce"));
        Assert.Equal("1", frame.Param("pendingStrategyId"));
        Assert.Equal("1", frame.Param("pendingStrategyType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pendingPegOffsetType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pendingPegPriceType"));
        Assert.Equal("1", frame.Param("pendingPegOffsetValue"));
        Assert.Equal("100", frame.Param("workingQuoteNotionalLimit"));
        Assert.Equal("100", frame.Param("pendingQuoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOtoBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderListPlaceOtoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOtoWorkingType.Limit,
            WorkingSide = OrderListPlaceOtoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingType = OrderListPlaceOtoPendingType.Limit,
            PendingSide = OrderListPlaceOtoPendingSide.Buy,
            PendingQuantity = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListPlaceOtoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListPlaceOtocoAsync()
    {
        const string envelope = """""{"id":"1712544408508","status":200,"result":{"orderListId":629,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"GaeJHjZPasPItFj4x7Mqm6","transactionTime":1712544408537,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":23,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H"},{"symbol":"LTCBNB","orderId":24,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X"},{"symbol":"LTCBNB","orderId":25,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt"}],"orderReports":[{"symbol":"LTCBNB","orderId":23,"orderListId":629,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H","transactTime":1712544408537,"price":"1.500000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1712544408537,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":24,"orderListId":629,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X","transactTime":1712544408537,"price":"0.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"SELL","stopPrice":"0.500000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":25,"orderListId":629,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt","transactTime":1712544408537,"price":"5.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"MINUTE","intervalNum":1,"limit":10000000,"count":18},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":1000,"count":65}]}""""";
        const string result = """""{"orderListId":629,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"GaeJHjZPasPItFj4x7Mqm6","transactionTime":1712544408537,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":23,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H"},{"symbol":"LTCBNB","orderId":24,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X"},{"symbol":"LTCBNB","orderId":25,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt"}],"orderReports":[{"symbol":"LTCBNB","orderId":23,"orderListId":629,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H","transactTime":1712544408537,"price":"1.500000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1712544408537,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":24,"orderListId":629,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X","transactTime":1712544408537,"price":"0.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"SELL","stopPrice":"0.500000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":25,"orderListId":629,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt","transactTime":1712544408537,"price":"5.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOtocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOtocoWorkingType.Limit,
            WorkingSide = OrderListPlaceOtocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListPlaceOtocoPendingSide.Buy,
            PendingQuantity = 1m,
            PendingAboveType = OrderListPlaceOtocoPendingAboveType.StopLossLimit,
        };

        var response = await client.OrderListPlaceOtocoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.otoco", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("1", frame.Param("pendingQuantity"));
        Assert.Equal("STOP_LOSS_LIMIT", frame.Param("pendingAboveType"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOtocoWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"1712544408508","status":200,"result":{"orderListId":629,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"GaeJHjZPasPItFj4x7Mqm6","transactionTime":1712544408537,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":23,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H"},{"symbol":"LTCBNB","orderId":24,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X"},{"symbol":"LTCBNB","orderId":25,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt"}],"orderReports":[{"symbol":"LTCBNB","orderId":23,"orderListId":629,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H","transactTime":1712544408537,"price":"1.500000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1712544408537,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":24,"orderListId":629,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X","transactTime":1712544408537,"price":"0.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"SELL","stopPrice":"0.500000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":25,"orderListId":629,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt","transactTime":1712544408537,"price":"5.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"MINUTE","intervalNum":1,"limit":10000000,"count":18},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":1000,"count":65}]}""""";
        const string result = """""{"orderListId":629,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"GaeJHjZPasPItFj4x7Mqm6","transactionTime":1712544408537,"symbol":"LTCBNB","orders":[{"symbol":"LTCBNB","orderId":23,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H"},{"symbol":"LTCBNB","orderId":24,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X"},{"symbol":"LTCBNB","orderId":25,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt"}],"orderReports":[{"symbol":"LTCBNB","orderId":23,"orderListId":629,"clientOrderId":"OVQOpKwfmPCfaBTD0n7e7H","transactTime":1712544408537,"price":"1.500000","origQty":"1.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1712544408537,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":24,"orderListId":629,"clientOrderId":"YcCPKCDMQIjNvLtNswt82X","transactTime":1712544408537,"price":"0.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"SELL","stopPrice":"0.500000","workingTime":-1,"selfTradePreventionMode":"NONE"},{"symbol":"LTCBNB","orderId":25,"orderListId":629,"clientOrderId":"ilpIoShcFZ1ZGgSASKxMPt","transactTime":1712544408537,"price":"5.000000","origQty":"5.000000","executedQty":"0.000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"PENDING_NEW","timeInForce":"GTC","type":"LIMIT_MAKER","side":"SELL","workingTime":-1,"selfTradePreventionMode":"NONE"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListPlaceOtocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOtocoWorkingType.Limit,
            WorkingSide = OrderListPlaceOtocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListPlaceOtocoPendingSide.Buy,
            PendingQuantity = 1m,
            PendingAboveType = OrderListPlaceOtocoPendingAboveType.StopLossLimit,
            Id = "0123456789abcdef0123456789abcdef",
            ListClientOrderId = "GaeJHjZPasPItFj4x7Mqm6",
            NewOrderRespType = OrderListPlaceOtocoNewOrderRespType.Ack,
            SelfTradePreventionMode = OrderListPlaceOtocoSelfTradePreventionMode.None,
            WorkingClientOrderId = "workingOrder1",
            WorkingIcebergQty = 1m,
            WorkingTimeInForce = OrderListPlaceOtocoWorkingTimeInForce.Gtc,
            WorkingStrategyId = 1L,
            WorkingStrategyType = 1L,
            WorkingPegPriceType = OrderListPlaceOtocoWorkingPegPriceType.PrimaryPeg,
            WorkingPegOffsetType = OrderListPlaceOtocoWorkingPegOffsetType.PriceLevel,
            WorkingPegOffsetValue = 1L,
            PendingAboveClientOrderId = "pendingAboveOrder1",
            PendingAbovePrice = 1m,
            PendingAboveStopPrice = 1m,
            PendingAboveTrailingDelta = 1m,
            PendingAboveIcebergQty = 1m,
            PendingAboveTimeInForce = OrderListPlaceOtocoPendingAboveTimeInForce.Gtc,
            PendingAboveStrategyId = 1L,
            PendingAboveStrategyType = 1L,
            PendingAbovePegPriceType = OrderListPlaceOtocoPendingAbovePegPriceType.PrimaryPeg,
            PendingAbovePegOffsetType = OrderListPlaceOtocoPendingAbovePegOffsetType.PriceLevel,
            PendingAbovePegOffsetValue = 1L,
            PendingBelowType = OrderListPlaceOtocoPendingBelowType.StopLoss,
            PendingBelowClientOrderId = "pendingBelowOrder1",
            PendingBelowPrice = 1m,
            PendingBelowStopPrice = 1m,
            PendingBelowTrailingDelta = 1m,
            PendingBelowIcebergQty = 1m,
            PendingBelowTimeInForce = OrderListPlaceOtocoPendingBelowTimeInForce.Gtc,
            PendingBelowStrategyId = 1L,
            PendingBelowStrategyType = 1L,
            PendingBelowPegPriceType = OrderListPlaceOtocoPendingBelowPegPriceType.PrimaryPeg,
            PendingBelowPegOffsetType = OrderListPlaceOtocoPendingBelowPegOffsetType.PriceLevel,
            PendingBelowPegOffsetValue = 1L,
            WorkingQuoteNotionalLimit = 100m,
            PendingAboveQuoteNotionalLimit = 100m,
            PendingBelowQuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListPlaceOtocoAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.place.otoco", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("LIMIT", frame.Param("workingType"));
        Assert.Equal("BUY", frame.Param("workingSide"));
        Assert.Equal("1", frame.Param("workingPrice"));
        Assert.Equal("1", frame.Param("workingQuantity"));
        Assert.Equal("BUY", frame.Param("pendingSide"));
        Assert.Equal("1", frame.Param("pendingQuantity"));
        Assert.Equal("STOP_LOSS_LIMIT", frame.Param("pendingAboveType"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("GaeJHjZPasPItFj4x7Mqm6", frame.Param("listClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("workingOrder1", frame.Param("workingClientOrderId"));
        Assert.Equal("1", frame.Param("workingIcebergQty"));
        Assert.Equal("GTC", frame.Param("workingTimeInForce"));
        Assert.Equal("1", frame.Param("workingStrategyId"));
        Assert.Equal("1", frame.Param("workingStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("workingPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("workingPegOffsetType"));
        Assert.Equal("1", frame.Param("workingPegOffsetValue"));
        Assert.Equal("pendingAboveOrder1", frame.Param("pendingAboveClientOrderId"));
        Assert.Equal("1", frame.Param("pendingAbovePrice"));
        Assert.Equal("1", frame.Param("pendingAboveStopPrice"));
        Assert.Equal("1", frame.Param("pendingAboveTrailingDelta"));
        Assert.Equal("1", frame.Param("pendingAboveIcebergQty"));
        Assert.Equal("GTC", frame.Param("pendingAboveTimeInForce"));
        Assert.Equal("1", frame.Param("pendingAboveStrategyId"));
        Assert.Equal("1", frame.Param("pendingAboveStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pendingAbovePegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pendingAbovePegOffsetType"));
        Assert.Equal("1", frame.Param("pendingAbovePegOffsetValue"));
        Assert.Equal("STOP_LOSS", frame.Param("pendingBelowType"));
        Assert.Equal("pendingBelowOrder1", frame.Param("pendingBelowClientOrderId"));
        Assert.Equal("1", frame.Param("pendingBelowPrice"));
        Assert.Equal("1", frame.Param("pendingBelowStopPrice"));
        Assert.Equal("1", frame.Param("pendingBelowTrailingDelta"));
        Assert.Equal("1", frame.Param("pendingBelowIcebergQty"));
        Assert.Equal("GTC", frame.Param("pendingBelowTimeInForce"));
        Assert.Equal("1", frame.Param("pendingBelowStrategyId"));
        Assert.Equal("1", frame.Param("pendingBelowStrategyType"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pendingBelowPegPriceType"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pendingBelowPegOffsetType"));
        Assert.Equal("1", frame.Param("pendingBelowPegOffsetValue"));
        Assert.Equal("100", frame.Param("workingQuoteNotionalLimit"));
        Assert.Equal("100", frame.Param("pendingAboveQuoteNotionalLimit"));
        Assert.Equal("100", frame.Param("pendingBelowQuoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListPlaceOtocoBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderListPlaceOtocoRequest
        {
            Symbol = "BNBUSDT",
            WorkingType = OrderListPlaceOtocoWorkingType.Limit,
            WorkingSide = OrderListPlaceOtocoWorkingSide.Buy,
            WorkingPrice = 1m,
            WorkingQuantity = 1m,
            PendingSide = OrderListPlaceOtocoPendingSide.Buy,
            PendingQuantity = 1m,
            PendingAboveType = OrderListPlaceOtocoPendingAboveType.StopLossLimit,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListPlaceOtocoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderPlaceAsync()
    {
        const string envelope = """""{"id":"56374a46-3061-486b-a311-99ee972eb648","status":200,"result":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157ec08158a40","transactTime":1660801715639,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1660801715639,"selfTradePreventionMode":"NONE","stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","fills":[{"price":"23416.10000000","qty":"0.00635000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422481},{"price":"23416.50000000","qty":"0.00212000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422482}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":1},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":1},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157ec08158a40","transactTime":1660801715639,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1660801715639,"selfTradePreventionMode":"NONE","stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","fills":[{"price":"23416.10000000","qty":"0.00635000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422481},{"price":"23416.50000000","qty":"0.00212000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422482}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderPlaceSide.Buy,
            Type = OrderPlaceType.Market,
        };

        var response = await client.OrderPlaceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.place", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderPlaceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"56374a46-3061-486b-a311-99ee972eb648","status":200,"result":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157ec08158a40","transactTime":1660801715639,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1660801715639,"selfTradePreventionMode":"NONE","stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","fills":[{"price":"23416.10000000","qty":"0.00635000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422481},{"price":"23416.50000000","qty":"0.00212000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422482}]},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":1},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":1},{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157ec08158a40","transactTime":1660801715639,"price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.00000000","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","workingTime":1660801715639,"selfTradePreventionMode":"NONE","stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY","fills":[{"price":"23416.10000000","qty":"0.00635000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422481},{"price":"23416.50000000","qty":"0.00212000","commission":"0.000000","commissionAsset":"BNB","tradeId":1650422482}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderPlaceSide.Buy,
            Type = OrderPlaceType.Market,
            Id = "0123456789abcdef0123456789abcdef",
            TimeInForce = OrderPlaceTimeInForce.Gtc,
            Price = 1m,
            Quantity = 1m,
            QuoteOrderQty = 1m,
            NewClientOrderId = "myOrder1",
            NewOrderRespType = OrderPlaceNewOrderRespType.Ack,
            StopPrice = 1m,
            TrailingDelta = 1L,
            IcebergQty = 1m,
            StrategyId = 1L,
            StrategyType = 1L,
            SelfTradePreventionMode = OrderPlaceSelfTradePreventionMode.None,
            PegPriceType = OrderPlacePegPriceType.PrimaryPeg,
            PegOffsetValue = 1L,
            PegOffsetType = OrderPlacePegOffsetType.PriceLevel,
            QuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderPlaceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.place", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("GTC", frame.Param("timeInForce"));
        Assert.Equal("1", frame.Param("price"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("1", frame.Param("quoteOrderQty"));
        Assert.Equal("myOrder1", frame.Param("newClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("1", frame.Param("stopPrice"));
        Assert.Equal("1", frame.Param("trailingDelta"));
        Assert.Equal("1", frame.Param("icebergQty"));
        Assert.Equal("1", frame.Param("strategyId"));
        Assert.Equal("1", frame.Param("strategyType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pegPriceType"));
        Assert.Equal("1", frame.Param("pegOffsetValue"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pegOffsetType"));
        Assert.Equal("100", frame.Param("quoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderPlaceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderPlaceSide.Buy,
            Type = OrderPlaceType.Market,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderPlaceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderTestAsync()
    {
        const string envelope = """""{"id":"6ffebe91-01d9-43ac-be99-57cf062e0e30","status":200,"result":{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"specialCommissionForOrder":{"maker":"0.05000000","taker":"0.06000000"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"specialCommissionForOrder":{"maker":"0.05000000","taker":"0.06000000"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderTestSide.Buy,
            Type = OrderTestType.Market,
        };

        var response = await client.OrderTestAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.test", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderTestWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"6ffebe91-01d9-43ac-be99-57cf062e0e30","status":200,"result":{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"specialCommissionForOrder":{"maker":"0.05000000","taker":"0.06000000"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"specialCommissionForOrder":{"maker":"0.05000000","taker":"0.06000000"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderTestSide.Buy,
            Type = OrderTestType.Market,
            Id = "0123456789abcdef0123456789abcdef",
            ComputeCommissionRates = false,
            TimeInForce = OrderTestTimeInForce.Gtc,
            Price = 1m,
            Quantity = 1m,
            QuoteOrderQty = 1m,
            NewClientOrderId = "myOrder1",
            NewOrderRespType = OrderTestNewOrderRespType.Ack,
            StopPrice = 1m,
            TrailingDelta = 1L,
            IcebergQty = 1m,
            StrategyId = 1L,
            StrategyType = 1L,
            SelfTradePreventionMode = OrderTestSelfTradePreventionMode.None,
            PegPriceType = OrderTestPegPriceType.PrimaryPeg,
            PegOffsetValue = 1L,
            PegOffsetType = OrderTestPegOffsetType.PriceLevel,
            QuoteNotionalLimit = 100m,
            RecvWindow = 5000m,
        };

        var response = await client.OrderTestAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.test", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("false", frame.Param("computeCommissionRates"));
        Assert.Equal("GTC", frame.Param("timeInForce"));
        Assert.Equal("1", frame.Param("price"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("1", frame.Param("quoteOrderQty"));
        Assert.Equal("myOrder1", frame.Param("newClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("1", frame.Param("stopPrice"));
        Assert.Equal("1", frame.Param("trailingDelta"));
        Assert.Equal("1", frame.Param("icebergQty"));
        Assert.Equal("1", frame.Param("strategyId"));
        Assert.Equal("1", frame.Param("strategyType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("PRIMARY_PEG", frame.Param("pegPriceType"));
        Assert.Equal("1", frame.Param("pegOffsetValue"));
        Assert.Equal("PRICE_LEVEL", frame.Param("pegOffsetType"));
        Assert.Equal("100", frame.Param("quoteNotionalLimit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderTestBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = OrderTestSide.Buy,
            Type = OrderTestType.Market,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderTestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SorOrderPlaceAsync()
    {
        const string envelope = """""{"id":"3a4437e2-41a3-4c19-897c-9cadc5dce8b6","status":200,"result":[{"symbol":"BTCUSDT","orderId":2,"orderListId":-1,"clientOrderId":"sBI1KM6nNtOfj5tccZSKly","transactTime":1689149087774,"price":"31000.00000000","origQty":"0.50000000","executedQty":"0.50000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"14000.00000000","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1689149087774,"fills":[{"matchType":"ONE_PARTY_TRADE_REPORT","price":"28000.00000000","qty":"0.50000000","commission":"0.00000000","commissionAsset":"BTC","tradeId":-1,"allocId":0}],"workingFloor":"SOR","selfTradePreventionMode":"NONE","usedSor":true,"stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":2,"orderListId":-1,"clientOrderId":"sBI1KM6nNtOfj5tccZSKly","transactTime":1689149087774,"price":"31000.00000000","origQty":"0.50000000","executedQty":"0.50000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"14000.00000000","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1689149087774,"fills":[{"matchType":"ONE_PARTY_TRADE_REPORT","price":"28000.00000000","qty":"0.50000000","commission":"0.00000000","commissionAsset":"BTC","tradeId":-1,"allocId":0}],"workingFloor":"SOR","selfTradePreventionMode":"NONE","usedSor":true,"stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SorOrderPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderPlaceSide.Buy,
            Type = SorOrderPlaceType.Market,
            Quantity = 1m,
        };

        var response = await client.SorOrderPlaceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("sor.order.place", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SorOrderPlaceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"3a4437e2-41a3-4c19-897c-9cadc5dce8b6","status":200,"result":[{"symbol":"BTCUSDT","orderId":2,"orderListId":-1,"clientOrderId":"sBI1KM6nNtOfj5tccZSKly","transactTime":1689149087774,"price":"31000.00000000","origQty":"0.50000000","executedQty":"0.50000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"14000.00000000","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1689149087774,"fills":[{"matchType":"ONE_PARTY_TRADE_REPORT","price":"28000.00000000","qty":"0.50000000","commission":"0.00000000","commissionAsset":"BTC","tradeId":-1,"allocId":0}],"workingFloor":"SOR","selfTradePreventionMode":"NONE","usedSor":true,"stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":2,"orderListId":-1,"clientOrderId":"sBI1KM6nNtOfj5tccZSKly","transactTime":1689149087774,"price":"31000.00000000","origQty":"0.50000000","executedQty":"0.50000000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"14000.00000000","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"BUY","workingTime":1689149087774,"fills":[{"matchType":"ONE_PARTY_TRADE_REPORT","price":"28000.00000000","qty":"0.50000000","commission":"0.00000000","commissionAsset":"BTC","tradeId":-1,"allocId":0}],"workingFloor":"SOR","selfTradePreventionMode":"NONE","usedSor":true,"stopPrice":"0.00000000","trailingDelta":10,"icebergQty":"0.00000000","strategyId":1,"strategyType":1000000,"preventedMatchId":0,"preventedQuantity":"1.200000","trailingTime":-1,"pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SorOrderPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderPlaceSide.Buy,
            Type = SorOrderPlaceType.Market,
            Quantity = 1m,
            Id = "0123456789abcdef0123456789abcdef",
            TimeInForce = SorOrderPlaceTimeInForce.Gtc,
            Price = 1m,
            NewClientOrderId = "myOrder1",
            NewOrderRespType = SorOrderPlaceNewOrderRespType.Ack,
            IcebergQty = 1m,
            StrategyId = 1L,
            StrategyType = 1L,
            SelfTradePreventionMode = SorOrderPlaceSelfTradePreventionMode.None,
            RecvWindow = 5000m,
        };

        var response = await client.SorOrderPlaceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("sor.order.place", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("GTC", frame.Param("timeInForce"));
        Assert.Equal("1", frame.Param("price"));
        Assert.Equal("myOrder1", frame.Param("newClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("1", frame.Param("icebergQty"));
        Assert.Equal("1", frame.Param("strategyId"));
        Assert.Equal("1", frame.Param("strategyType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SorOrderPlaceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new SorOrderPlaceRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderPlaceSide.Buy,
            Type = SorOrderPlaceType.Market,
            Quantity = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SorOrderPlaceAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SorOrderTestAsync()
    {
        const string envelope = """""{"id":"3a4437e2-41a3-4c19-897c-9cadc5dce8b6","status":200,"result":{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SorOrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderTestSide.Buy,
            Type = SorOrderTestType.Market,
            Quantity = 1m,
        };

        var response = await client.SorOrderTestAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("sor.order.test", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SorOrderTestWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"3a4437e2-41a3-4c19-897c-9cadc5dce8b6","status":200,"result":{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":1}]}""""";
        const string result = """""{"standardCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"taxCommissionForOrder":{"maker":"0.00000112","taker":"0.00000114"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.25000000"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SorOrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderTestSide.Buy,
            Type = SorOrderTestType.Market,
            Quantity = 1m,
            Id = "0123456789abcdef0123456789abcdef",
            ComputeCommissionRates = false,
            TimeInForce = SorOrderTestTimeInForce.Gtc,
            Price = 1m,
            NewClientOrderId = "myOrder1",
            NewOrderRespType = SorOrderTestNewOrderRespType.Ack,
            IcebergQty = 1m,
            StrategyId = 1L,
            StrategyType = 1L,
            SelfTradePreventionMode = SorOrderTestSelfTradePreventionMode.None,
            RecvWindow = 5000m,
        };

        var response = await client.SorOrderTestAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("sor.order.test", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("MARKET", frame.Param("type"));
        Assert.Equal("1", frame.Param("quantity"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("false", frame.Param("computeCommissionRates"));
        Assert.Equal("GTC", frame.Param("timeInForce"));
        Assert.Equal("1", frame.Param("price"));
        Assert.Equal("myOrder1", frame.Param("newClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("1", frame.Param("icebergQty"));
        Assert.Equal("1", frame.Param("strategyId"));
        Assert.Equal("1", frame.Param("strategyType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SorOrderTestBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new SorOrderTestRequest
        {
            Symbol = "BNBUSDT",
            Side = SorOrderTestSide.Buy,
            Type = SorOrderTestType.Market,
            Quantity = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SorOrderTestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
