//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingUsdsFutures.WebSocketApi;

namespace Binance.DerivativesTradingUsdsFutures.Tests.WebSocketApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    [Fact]
    public async Task CancelAlgoOrderAsync()
    {
        const string envelope = """""{"id":"unique-cancel-request-id-5678","status":200,"result":{"algoId":2000000002162519,"clientAlgoId":"rDMG8WSde6LkyMNtk6s825","code":"200","msg":"success"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"algoId":2000000002162519,"clientAlgoId":"rDMG8WSde6LkyMNtk6s825","code":"200","msg":"success"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.CancelAlgoOrderAsync();

        var frame = server.ApiRequest();
        Assert.Equal("algoOrder.cancel", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task CancelAlgoOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"unique-cancel-request-id-5678","status":200,"result":{"algoId":2000000002162519,"clientAlgoId":"rDMG8WSde6LkyMNtk6s825","code":"200","msg":"success"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"algoId":2000000002162519,"clientAlgoId":"rDMG8WSde6LkyMNtk6s825","code":"200","msg":"success"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new CancelAlgoOrderRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            AlgoId = 2000000002162519L,
            ClientAlgoId = "rDMG8WSde6LkyMNtk6s825",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAlgoOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("algoOrder.cancel", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("2000000002162519", frame.Param("algoId"));
        Assert.Equal("rDMG8WSde6LkyMNtk6s825", frame.Param("clientAlgoId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task CancelAlgoOrderBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.CancelAlgoOrderAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelOrderAsync()
    {
        const string envelope = """""{"id":"5633b6a2-90a9-4192-83e7-925c90b6a2fd","status":200,"result":{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":1}]}""""";
        const string result = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.cancel", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task CancelOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"5633b6a2-90a9-4192-83e7-925c90b6a2fd","status":200,"result":{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":1}]}""""";
        const string result = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.cancel", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("1", frame.Param("origClientOrderId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task CancelOrderBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.CancelOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifyOrderAsync()
    {
        const string envelope = """""{"id":"c8c271ba-de70-479e-870c-e64951c753d9","status":200,"result":{"orderId":328971409,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"xGHfltUMExx0TbQstQQfRX","modifyId":1,"price":"43769.10","origQty":"0.110","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"SELL","positionSide":"SHORT","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1703426756190},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":300,"count":1}]}""""";
        const string result = """""{"orderId":328971409,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"xGHfltUMExx0TbQstQQfRX","modifyId":1,"price":"43769.10","origQty":"0.110","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"SELL","positionSide":"SHORT","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1703426756190}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
        };

        var response = await client.ModifyOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.modify", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("1.0", frame.Param("quantity"));
        Assert.Equal("1.0", frame.Param("price"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ModifyOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"c8c271ba-de70-479e-870c-e64951c753d9","status":200,"result":{"orderId":328971409,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"xGHfltUMExx0TbQstQQfRX","modifyId":1,"price":"43769.10","origQty":"0.110","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"SELL","positionSide":"SHORT","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1703426756190},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":300,"count":1}]}""""";
        const string result = """""{"orderId":328971409,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"xGHfltUMExx0TbQstQQfRX","modifyId":1,"price":"43769.10","origQty":"0.110","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"SELL","positionSide":"SHORT","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1703426756190}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "1",
            PriceMatch = ModifyOrderPriceMatch.Opponent,
            ModifyId = 1L,
            ReduceOnly = ModifyOrderReduceOnly.True,
            RecvWindow = 5000L,
        };

        var response = await client.ModifyOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.modify", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("1.0", frame.Param("quantity"));
        Assert.Equal("1.0", frame.Param("price"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("1", frame.Param("origClientOrderId"));
        Assert.Equal("OPPONENT", frame.Param("priceMatch"));
        Assert.Equal("1", frame.Param("modifyId"));
        Assert.Equal("true", frame.Param("reduceOnly"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task ModifyOrderBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.ModifyOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewAlgoOrderAsync()
    {
        const string envelope = """""{"id":"06c9dbd8-ccbf-4ecf-a29c-fe31495ac73f","status":200,"result":{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSDT","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":1}]}""""";
        const string result = """""{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSDT","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BTCUSDT",
            Side = NewAlgoOrderSide.Buy,
            Type = NewAlgoOrderType.StopMarket,
        };

        var response = await client.NewAlgoOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("algoOrder.place", frame.Method);
        Assert.Equal("CONDITIONAL", frame.Param("algoType"));
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("STOP_MARKET", frame.Param("type"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task NewAlgoOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"06c9dbd8-ccbf-4ecf-a29c-fe31495ac73f","status":200,"result":{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSDT","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":1}]}""""";
        const string result = """""{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSDT","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BTCUSDT",
            Side = NewAlgoOrderSide.Buy,
            Type = NewAlgoOrderType.StopMarket,
            Id = "0123456789abcdef0123456789abcdef",
            PositionSide = NewAlgoOrderPositionSide.Both,
            TimeInForce = NewAlgoOrderTimeInForce.Ioc,
            Quantity = 1.0m,
            Price = 1.0m,
            TriggerPrice = 1.0m,
            WorkingType = NewAlgoOrderWorkingType.MarkPrice,
            PriceMatch = NewAlgoOrderPriceMatch.Opponent,
            ClosePosition = NewAlgoOrderClosePosition.True,
            PriceProtect = NewAlgoOrderPriceProtect.True,
            ReduceOnly = NewAlgoOrderReduceOnly.True,
            ActivatePrice = 1.0m,
            CallbackRate = 1m,
            ClientAlgoId = "1",
            NewOrderRespType = NewAlgoOrderNewOrderRespType.Ack,
            SelfTradePreventionMode = NewAlgoOrderSelfTradePreventionMode.None,
            GoodTillDate = 1770736694138L,
            RecvWindow = 5000L,
        };

        var response = await client.NewAlgoOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("algoOrder.place", frame.Method);
        Assert.Equal("CONDITIONAL", frame.Param("algoType"));
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("STOP_MARKET", frame.Param("type"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BOTH", frame.Param("positionSide"));
        Assert.Equal("IOC", frame.Param("timeInForce"));
        Assert.Equal("1.0", frame.Param("quantity"));
        Assert.Equal("1.0", frame.Param("price"));
        Assert.Equal("1.0", frame.Param("triggerPrice"));
        Assert.Equal("MARK_PRICE", frame.Param("workingType"));
        Assert.Equal("OPPONENT", frame.Param("priceMatch"));
        Assert.Equal("true", frame.Param("closePosition"));
        Assert.Equal("true", frame.Param("priceProtect"));
        Assert.Equal("true", frame.Param("reduceOnly"));
        Assert.Equal("1.0", frame.Param("activatePrice"));
        Assert.Equal("1", frame.Param("callbackRate"));
        Assert.Equal("1", frame.Param("clientAlgoId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("1770736694138", frame.Param("goodTillDate"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task NewAlgoOrderBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BTCUSDT",
            Side = NewAlgoOrderSide.Buy,
            Type = NewAlgoOrderType.StopMarket,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.NewAlgoOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewOrderAsync()
    {
        const string envelope = """""{"id":"3f7df6e3-2df4-44b9-9919-d2f38f90a99a","status":200,"result":{"orderId":325078477,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"iCXL1BywlBaf2sesNUrVl3","price":"43187.00","origQty":"0.100","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1702555534435},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":300,"count":1}]}""""";
        const string result = """""{"orderId":325078477,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"iCXL1BywlBaf2sesNUrVl3","price":"43187.00","origQty":"0.100","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1702555534435}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
        };

        var response = await client.NewOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.place", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("LIMIT", frame.Param("type"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task NewOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"3f7df6e3-2df4-44b9-9919-d2f38f90a99a","status":200,"result":{"orderId":325078477,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"iCXL1BywlBaf2sesNUrVl3","price":"43187.00","origQty":"0.100","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1702555534435},"rateLimits":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":300,"count":1}]}""""";
        const string result = """""{"orderId":325078477,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"iCXL1BywlBaf2sesNUrVl3","price":"43187.00","origQty":"0.100","executedQty":"0.000","cumQty":"0.000","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0.00","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1702555534435}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
            Id = "0123456789abcdef0123456789abcdef",
            PositionSide = NewOrderPositionSide.Both,
            TimeInForce = NewOrderTimeInForce.Gtc,
            ReduceOnly = NewOrderReduceOnly.True,
            Quantity = 1.0m,
            Price = 1.0m,
            NewClientOrderId = "1",
            NewOrderRespType = NewOrderNewOrderRespType.Ack,
            PriceMatch = NewOrderPriceMatch.Opponent,
            SelfTradePreventionMode = NewOrderSelfTradePreventionMode.None,
            GoodTillDate = 1770736694138L,
            RecvWindow = 5000L,
        };

        var response = await client.NewOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.place", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("LIMIT", frame.Param("type"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BOTH", frame.Param("positionSide"));
        Assert.Equal("GTC", frame.Param("timeInForce"));
        Assert.Equal("true", frame.Param("reduceOnly"));
        Assert.Equal("1.0", frame.Param("quantity"));
        Assert.Equal("1.0", frame.Param("price"));
        Assert.Equal("1", frame.Param("newClientOrderId"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("OPPONENT", frame.Param("priceMatch"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
        Assert.Equal("1770736694138", frame.Param("goodTillDate"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task NewOrderBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new NewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.NewOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PositionInformationAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"entryPrice":"0.00000","breakEvenPrice":"0.0","marginType":"isolated","isAutoAddMargin":"false","isolatedMargin":"0.00000000","leverage":"10","liquidationPrice":"0","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","isolatedWallet":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","positionSide":"BOTH","updateTime":1625474304765}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"entryPrice":"0.00000","breakEvenPrice":"0.0","marginType":"isolated","isAutoAddMargin":"false","isolatedMargin":"0.00000000","leverage":"10","liquidationPrice":"0","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","isolatedWallet":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","positionSide":"BOTH","updateTime":1625474304765}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.PositionInformationAsync();

        var frame = server.ApiRequest();
        Assert.Equal("account.position", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task PositionInformationWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"entryPrice":"0.00000","breakEvenPrice":"0.0","marginType":"isolated","isAutoAddMargin":"false","isolatedMargin":"0.00000000","leverage":"10","liquidationPrice":"0","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","isolatedWallet":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","positionSide":"BOTH","updateTime":1625474304765}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"entryPrice":"0.00000","breakEvenPrice":"0.0","marginType":"isolated","isAutoAddMargin":"false","isolatedMargin":"0.00000000","leverage":"10","liquidationPrice":"0","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","isolatedWallet":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","positionSide":"BOTH","updateTime":1625474304765}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new PositionInformationRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.PositionInformationAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.position", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task PositionInformationBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.PositionInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PositionInformationV2Async()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"symbol":"ADAUSDT","positionSide":"BOTH","positionAmt":"30","entryPrice":"0.385","breakEvenPrice":"0.385077","markPrice":"0.41047590","unRealizedProfit":"0.76427700","liquidationPrice":"0","isolatedMargin":"0","notional":"12.31427700","marginAsset":"USDT","isolatedWallet":"0","initialMargin":"0.61571385","maintMargin":"0.08004280","positionInitialMargin":"0.61571385","openOrderInitialMargin":"0","adl":2,"bidNotional":"0","askNotional":"0","updateTime":1720736417660}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"symbol":"ADAUSDT","positionSide":"BOTH","positionAmt":"30","entryPrice":"0.385","breakEvenPrice":"0.385077","markPrice":"0.41047590","unRealizedProfit":"0.76427700","liquidationPrice":"0","isolatedMargin":"0","notional":"12.31427700","marginAsset":"USDT","isolatedWallet":"0","initialMargin":"0.61571385","maintMargin":"0.08004280","positionInitialMargin":"0.61571385","openOrderInitialMargin":"0","adl":2,"bidNotional":"0","askNotional":"0","updateTime":1720736417660}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.PositionInformationV2Async();

        var frame = server.ApiRequest();
        Assert.Equal("v2/account.position", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task PositionInformationV2WithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"symbol":"ADAUSDT","positionSide":"BOTH","positionAmt":"30","entryPrice":"0.385","breakEvenPrice":"0.385077","markPrice":"0.41047590","unRealizedProfit":"0.76427700","liquidationPrice":"0","isolatedMargin":"0","notional":"12.31427700","marginAsset":"USDT","isolatedWallet":"0","initialMargin":"0.61571385","maintMargin":"0.08004280","positionInitialMargin":"0.61571385","openOrderInitialMargin":"0","adl":2,"bidNotional":"0","askNotional":"0","updateTime":1720736417660}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"symbol":"ADAUSDT","positionSide":"BOTH","positionAmt":"30","entryPrice":"0.385","breakEvenPrice":"0.385077","markPrice":"0.41047590","unRealizedProfit":"0.76427700","liquidationPrice":"0","isolatedMargin":"0","notional":"12.31427700","marginAsset":"USDT","isolatedWallet":"0","initialMargin":"0.61571385","maintMargin":"0.08004280","positionInitialMargin":"0.61571385","openOrderInitialMargin":"0","adl":2,"bidNotional":"0","askNotional":"0","updateTime":1720736417660}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new PositionInformationV2Request
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.PositionInformationV2Async(request);

        var frame = server.ApiRequest();
        Assert.Equal("v2/account.position", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task PositionInformationV2BadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.PositionInformationV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryOrderAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1573346959,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}}""""";
        const string result = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1573346959,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.status", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task QueryOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1573346959,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}}""""";
        const string result = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1573346959,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.status", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("1", frame.Param("origClientOrderId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task QueryOrderBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.QueryOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
