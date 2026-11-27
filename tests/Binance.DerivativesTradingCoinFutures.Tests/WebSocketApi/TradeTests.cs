//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

namespace Binance.DerivativesTradingCoinFutures.Tests.WebSocketApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    [Fact]
    public async Task CancelAlgoOrderAsync()
    {
        const string envelope = """""{"id":"unique-cancel-request-id-5678","status":200,"result":{"algoId":2000000002162519,"clientAlgoId":"rDMG8WSde6LkyMNtk6s825","code":"200","msg":"success"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"algoId":2000000002162519,"clientAlgoId":"rDMG8WSde6LkyMNtk6s825","code":"200","msg":"success"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        const string envelope = """""{"id":"a8627ea5-8b9f-452f-90ae-4136f2b442e2","status":200,"result":{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"CANCELED","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728416138285},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"CANCELED","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728416138285}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var response = await client.CancelOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.cancel", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task CancelOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"a8627ea5-8b9f-452f-90ae-4136f2b442e2","status":200,"result":{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"CANCELED","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728416138285},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"CANCELED","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728416138285}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.cancel", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.CancelOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifyOrderAsync()
    {
        const string envelope = """""{"id":"88601d02-bd0d-430d-8733-2708a569ebda","status":200,"result":{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","modifyId":1,"price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728415765493},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","modifyId":1,"price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728415765493}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
        };

        var response = await client.ModifyOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.modify", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
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
        const string envelope = """""{"id":"88601d02-bd0d-430d-8733-2708a569ebda","status":200,"result":{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","modifyId":1,"price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728415765493},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","modifyId":1,"price":"51000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728415765493}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "1",
            PriceMatch = ModifyOrderPriceMatch.Opponent,
            ModifyId = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.ModifyOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.modify", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("1.0", frame.Param("quantity"));
        Assert.Equal("1.0", frame.Param("price"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("1", frame.Param("origClientOrderId"));
        Assert.Equal("OPPONENT", frame.Param("priceMatch"));
        Assert.Equal("1", frame.Param("modifyId"));
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSD_PERP",
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
        const string envelope = """""{"id":"06c9dbd8-ccbf-4ecf-a29c-fe31495ac73f","status":200,"result":{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSD_PERP","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":1}]}""""";
        const string result = """""{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSD_PERP","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BTCUSD_PERP",
            Side = NewAlgoOrderSide.Buy,
            Type = NewAlgoOrderType.StopMarket,
        };

        var response = await client.NewAlgoOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("algoOrder.place", frame.Method);
        Assert.Equal("CONDITIONAL", frame.Param("algoType"));
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
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
        const string envelope = """""{"id":"06c9dbd8-ccbf-4ecf-a29c-fe31495ac73f","status":200,"result":{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSD_PERP","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":1}]}""""";
        const string result = """""{"algoId":3000000000003505,"clientAlgoId":"0Xkl1p621E4EryvufmYre1","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BTCUSD_PERP","side":"SELL","positionSide":"SHORT","timeInForce":"GTC","quantity":"1.000","algoStatus":"NEW","triggerPrice":"120000.00","price":"160000.00","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1762507264142,"updateTime":1762507264143,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BTCUSD_PERP",
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
            RecvWindow = 5000L,
        };

        var response = await client.NewAlgoOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("algoOrder.place", frame.Method);
        Assert.Equal("CONDITIONAL", frame.Param("algoType"));
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BTCUSD_PERP",
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
        const string envelope = """""{"id":"60fa4366-f96e-42fe-a82b-f819952c6db4","status":200,"result":{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"50000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728413795125},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"50000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728413795125}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
        };

        var response = await client.NewOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.place", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
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
        const string envelope = """""{"id":"60fa4366-f96e-42fe-a82b-f819952c6db4","status":200,"result":{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"50000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728413795125},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":333245211,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"5SztZiGFAxgAqw4J9EN9fA","price":"50000","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","updateTime":1728413795125}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new NewOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
            Id = "0123456789abcdef0123456789abcdef",
            PositionSide = NewOrderPositionSide.Both,
            TimeInForce = NewOrderTimeInForce.Gtc,
            Quantity = 1.0m,
            ReduceOnly = NewOrderReduceOnly.True,
            Price = 1.0m,
            NewClientOrderId = "1",
            StopPrice = 1.0m,
            ClosePosition = NewOrderClosePosition.True,
            ActivationPrice = 1.0m,
            CallbackRate = 5000.0m,
            WorkingType = NewOrderWorkingType.MarkPrice,
            PriceProtect = NewOrderPriceProtect.True,
            NewOrderRespType = NewOrderNewOrderRespType.Ack,
            PriceMatch = NewOrderPriceMatch.Opponent,
            SelfTradePreventionMode = NewOrderSelfTradePreventionMode.None,
            RecvWindow = 5000L,
        };

        var response = await client.NewOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.place", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
        Assert.Equal("BUY", frame.Param("side"));
        Assert.Equal("LIMIT", frame.Param("type"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BOTH", frame.Param("positionSide"));
        Assert.Equal("GTC", frame.Param("timeInForce"));
        Assert.Equal("1.0", frame.Param("quantity"));
        Assert.Equal("true", frame.Param("reduceOnly"));
        Assert.Equal("1.0", frame.Param("price"));
        Assert.Equal("1", frame.Param("newClientOrderId"));
        Assert.Equal("1.0", frame.Param("stopPrice"));
        Assert.Equal("true", frame.Param("closePosition"));
        Assert.Equal("1.0", frame.Param("activationPrice"));
        Assert.Equal("5000.0", frame.Param("callbackRate"));
        Assert.Equal("MARK_PRICE", frame.Param("workingType"));
        Assert.Equal("true", frame.Param("priceProtect"));
        Assert.Equal("ACK", frame.Param("newOrderRespType"));
        Assert.Equal("OPPONENT", frame.Param("priceMatch"));
        Assert.Equal("NONE", frame.Param("selfTradePreventionMode"));
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new NewOrderRequest
        {
            Symbol = "BTCUSD_PERP",
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
        const string envelope = """""{"id":"233b8741-a96d-48e8-8ce1-160f43548aeb","status":200,"result":[{"symbol":"BTCUSD_PERP","positionAmt":"0","entryPrice":"0.00000000","markPrice":"62297.60417296","unRealizedProfit":"0.00000000","liquidationPrice":"0","leverage":"7","maxQty":"100","marginType":"cross","isolatedMargin":"0.00000000","isAutoAddMargin":"false","positionSide":"BOTH","notionalValue":"0","isolatedWallet":"0","updateTime":1726731195634,"breakEvenPrice":"0.00000000"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":10}]}""""";
        const string result = """""[{"symbol":"BTCUSD_PERP","positionAmt":"0","entryPrice":"0.00000000","markPrice":"62297.60417296","unRealizedProfit":"0.00000000","liquidationPrice":"0","leverage":"7","maxQty":"100","marginType":"cross","isolatedMargin":"0.00000000","isAutoAddMargin":"false","positionSide":"BOTH","notionalValue":"0","isolatedWallet":"0","updateTime":1726731195634,"breakEvenPrice":"0.00000000"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        const string envelope = """""{"id":"233b8741-a96d-48e8-8ce1-160f43548aeb","status":200,"result":[{"symbol":"BTCUSD_PERP","positionAmt":"0","entryPrice":"0.00000000","markPrice":"62297.60417296","unRealizedProfit":"0.00000000","liquidationPrice":"0","leverage":"7","maxQty":"100","marginType":"cross","isolatedMargin":"0.00000000","isAutoAddMargin":"false","positionSide":"BOTH","notionalValue":"0","isolatedWallet":"0","updateTime":1726731195634,"breakEvenPrice":"0.00000000"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":10}]}""""";
        const string result = """""[{"symbol":"BTCUSD_PERP","positionAmt":"0","entryPrice":"0.00000000","markPrice":"62297.60417296","unRealizedProfit":"0.00000000","liquidationPrice":"0","leverage":"7","maxQty":"100","marginType":"cross","isolatedMargin":"0.00000000","isAutoAddMargin":"false","positionSide":"BOTH","notionalValue":"0","isolatedWallet":"0","updateTime":1726731195634,"breakEvenPrice":"0.00000000"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new PositionInformationRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            MarginAsset = "USDT",
            Pair = "BTCUSD",
            RecvWindow = 5000L,
        };

        var response = await client.PositionInformationAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.position", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("USDT", frame.Param("marginAsset"));
        Assert.Equal("BTCUSD", frame.Param("pair"));
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
    public async Task QueryOrderAsync()
    {
        const string envelope = """""{"id":"0ce5d070-a5e5-4ff2-b57f-1556741a4204","status":200,"result":{"orderId":328999071,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"ArY8Ng1rln0s9x3fclmAHy","price":"58000","avgPrice":"0.00","origQty":"1","executedQty":"0","cumQty":"0","cumBase":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","selfTradePreventionMode":"EXPIRE_TAKER","time":1733740063619,"updateTime":1733740063619,"priceMatch":"NONE"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":328999071,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"ArY8Ng1rln0s9x3fclmAHy","price":"58000","avgPrice":"0.00","origQty":"1","executedQty":"0","cumQty":"0","cumBase":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","selfTradePreventionMode":"EXPIRE_TAKER","time":1733740063619,"updateTime":1733740063619,"priceMatch":"NONE"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var response = await client.QueryOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.status", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task QueryOrderWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"0ce5d070-a5e5-4ff2-b57f-1556741a4204","status":200,"result":{"orderId":328999071,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"ArY8Ng1rln0s9x3fclmAHy","price":"58000","avgPrice":"0.00","origQty":"1","executedQty":"0","cumQty":"0","cumBase":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","selfTradePreventionMode":"EXPIRE_TAKER","time":1733740063619,"updateTime":1733740063619,"priceMatch":"NONE"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":6}]}""""";
        const string result = """""{"orderId":328999071,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"ArY8Ng1rln0s9x3fclmAHy","price":"58000","avgPrice":"0.00","origQty":"1","executedQty":"0","cumQty":"0","cumBase":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","selfTradePreventionMode":"EXPIRE_TAKER","time":1733740063619,"updateTime":1733740063619,"priceMatch":"NONE"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryOrderAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.status", frame.Method);
        Assert.Equal("BTCUSD_PERP", frame.Param("symbol"));
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.QueryOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
