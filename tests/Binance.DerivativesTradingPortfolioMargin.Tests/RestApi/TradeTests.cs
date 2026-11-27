//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

namespace Binance.DerivativesTradingPortfolioMargin.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static DerivativesTradingPortfolioMarginRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CancelAllCmOpenConditionalOrdersAsync()
    {
        const string example = """""{"code":"200","msg":"The operation of cancel all conditional open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllCmOpenConditionalOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelAllCmOpenConditionalOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllCmOpenConditionalOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"code":"200","msg":"The operation of cancel all conditional open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllCmOpenConditionalOrdersRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllCmOpenConditionalOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllCmOpenConditionalOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllCmOpenConditionalOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllCmOpenConditionalOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAllCmOpenOrdersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllCmOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelAllCmOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllCmOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllCmOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllCmOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllCmOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllCmOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllCmOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAllUmAlgoOpenOrdersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllUmAlgoOpenOrdersRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.CancelAllUmAlgoOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/algo/allOpenOrders", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllUmAlgoOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllUmAlgoOpenOrdersRequest
        {
            Symbol = "BNBUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllUmAlgoOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/algo/allOpenOrders", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllUmAlgoOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllUmAlgoOpenOrdersRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllUmAlgoOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAllUmOpenOrdersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllUmOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelAllUmOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllUmOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllUmOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllUmOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllUmOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllUmOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllUmOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelCmConditionalOrderAsync()
    {
        const string example = """""{"newClientStrategyId":"myOrder1","strategyId":123445,"strategyStatus":"CANCELED","strategyType":"TRAILING_STOP_MARKET","origQty":"11","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3","bookTime":1566818724710,"updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelCmConditionalOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelCmConditionalOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelCmConditionalOrderWithOptionalParametersAsync()
    {
        const string example = """""{"newClientStrategyId":"myOrder1","strategyId":123445,"strategyStatus":"CANCELED","strategyType":"TRAILING_STOP_MARKET","origQty":"11","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3","bookTime":1566818724710,"updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelCmConditionalOrderRequest
        {
            Symbol = "BTCUSDT",
            StrategyId = 1L,
            NewClientStrategyId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelCmConditionalOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("newClientStrategyId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelCmConditionalOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelCmConditionalOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelCmConditionalOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelCmOrderAsync()
    {
        const string example = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"2","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","symbol":"BTCUSD_200925","pair":"BTCUSD","timeInForce":"GTC","type":"LIMIT","updateTime":1571110484038}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelCmOrderRequest
        {
            Symbol = "BTCUSD_200925",
        };

        var response = await client.CancelCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelCmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"2","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","symbol":"BTCUSD_200925","pair":"BTCUSD","timeInForce":"GTC","type":"LIMIT","updateTime":1571110484038}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelCmOrderRequest
        {
            Symbol = "BTCUSD_200925",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelCmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelCmOrderRequest
        {
            Symbol = "BTCUSD_200925",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelCmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelMarginAccountAllOpenOrdersOnASymbolAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","origClientOrderId":"E6APeyTJvkMvLMYMqu1KQ4","orderId":11,"orderListId":-1,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.089853","origQty":"0.178622","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"BUY","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"2inzWQdDvZLHbbAmAozX2N","transactionTime":1585230948299,"orders":[{"symbol":"BTCUSDT","orderId":20,"clientOrderId":"CwOOIPHSmYywx6jZX77TdL"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"CwOOIPHSmYywx6jZX77TdL","orderId":20,"orderListId":1929,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.668611","origQty":"0.690354","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"0.378131","icebergQty":"0.017083"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMarginAccountAllOpenOrdersOnASymbolRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelMarginAccountAllOpenOrdersOnASymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/margin/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMarginAccountAllOpenOrdersOnASymbolWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","origClientOrderId":"E6APeyTJvkMvLMYMqu1KQ4","orderId":11,"orderListId":-1,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.089853","origQty":"0.178622","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"BUY","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"2inzWQdDvZLHbbAmAozX2N","transactionTime":1585230948299,"orders":[{"symbol":"BTCUSDT","orderId":20,"clientOrderId":"CwOOIPHSmYywx6jZX77TdL"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"CwOOIPHSmYywx6jZX77TdL","orderId":20,"orderListId":1929,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.668611","origQty":"0.690354","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"0.378131","icebergQty":"0.017083"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMarginAccountAllOpenOrdersOnASymbolRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelMarginAccountAllOpenOrdersOnASymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/margin/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMarginAccountAllOpenOrdersOnASymbolBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelMarginAccountAllOpenOrdersOnASymbolRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelMarginAccountAllOpenOrdersOnASymbolAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelMarginAccountOcoOrdersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"C3wyj4WVEktd7u9aVBRXcN","transactionTime":1574040868128,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"pO9ufTiFGg3nw2fOdgeOXa"}],"orderReports":[{"symbol":"LTCBTC","origClientOrderId":"pO9ufTiFGg3nw2fOdgeOXa","orderId":2,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","price":"1.00000000","origQty":"10.00000000","executedQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMarginAccountOcoOrdersRequest
        {
            Symbol = "LTCBTC",
        };

        var response = await client.CancelMarginAccountOcoOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/margin/orderList", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMarginAccountOcoOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"C3wyj4WVEktd7u9aVBRXcN","transactionTime":1574040868128,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"pO9ufTiFGg3nw2fOdgeOXa"}],"orderReports":[{"symbol":"LTCBTC","origClientOrderId":"pO9ufTiFGg3nw2fOdgeOXa","orderId":2,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","price":"1.00000000","origQty":"10.00000000","executedQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMarginAccountOcoOrdersRequest
        {
            Symbol = "LTCBTC",
            OrderListId = 1L,
            ListClientOrderId = "1",
            NewClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelMarginAccountOcoOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/margin/orderList", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderListId"));
        Assert.Equal("1", seen.Param("listClientOrderId"));
        Assert.Equal("1", seen.Param("newClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMarginAccountOcoOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelMarginAccountOcoOrdersRequest
        {
            Symbol = "LTCBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelMarginAccountOcoOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelMarginAccountOrderAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":28,"origClientOrderId":"myOrder1","clientOrderId":"cancelMyOrder1","price":"1.00000000","origQty":"10.00000000","executedQty":"8.00000000","cummulativeQuoteQty":"8.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMarginAccountOrderRequest
        {
            Symbol = "LTCBTC",
        };

        var response = await client.CancelMarginAccountOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/margin/order", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMarginAccountOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":28,"origClientOrderId":"myOrder1","clientOrderId":"cancelMyOrder1","price":"1.00000000","origQty":"10.00000000","executedQty":"8.00000000","cummulativeQuoteQty":"8.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMarginAccountOrderRequest
        {
            Symbol = "LTCBTC",
            OrderId = 1L,
            OrigClientOrderId = "1",
            NewClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelMarginAccountOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/margin/order", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("1", seen.Param("newClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMarginAccountOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelMarginAccountOrderRequest
        {
            Symbol = "LTCBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelMarginAccountOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelUmAlgoOrderAsync()
    {
        const string example = """""{"complete":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CancelUmAlgoOrderAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/algo/order", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelUmAlgoOrderWithOptionalParametersAsync()
    {
        const string example = """""{"complete":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelUmAlgoOrderRequest
        {
            AlgoId = 2146760L,
            ClientAlgoId = "6B2I9XVcJpCjqPAJ4YoFX7",
            RecvWindow = 5000L,
        };

        var response = await client.CancelUmAlgoOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/algo/order", seen.Path);
        Assert.Equal("2146760", seen.Param("algoId"));
        Assert.Equal("6B2I9XVcJpCjqPAJ4YoFX7", seen.Param("clientAlgoId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelUmAlgoOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelUmAlgoOrderAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelUmOrderAsync()
    {
        const string example = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":4611875134427365000,"origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","symbol":"BTCUSDT","timeInForce":"GTC","type":"LIMIT","updateTime":1571110484038,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelUmOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelUmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":4611875134427365000,"origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","symbol":"BTCUSDT","timeInForce":"GTC","type":"LIMIT","updateTime":1571110484038,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelUmOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelUmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelUmOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelUmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CmAccountTradeListAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_200626","id":6,"orderId":28,"pair":"BTCUSD","side":"SELL","price":"8800","qty":"1","realizedPnl":"0","marginAsset":"BTC","baseQty":"0.01136364","commission":"0.00000454","commissionAsset":"BTC","time":1590743483586,"positionSide":"BOTH","buyer":false,"maker":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CmAccountTradeListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/userTrades", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CmAccountTradeListWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_200626","id":6,"orderId":28,"pair":"BTCUSD","side":"SELL","price":"8800","qty":"1","realizedPnl":"0","marginAsset":"BTC","baseQty":"0.01136364","commission":"0.00000454","commissionAsset":"BTC","time":1590743483586,"positionSide":"BOTH","buyer":false,"maker":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CmAccountTradeListRequest
        {
            Symbol = "BTCUSD_200626",
            Pair = "BTCUSD",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            FromId = 1L,
            Limit = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.CmAccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/userTrades", seen.Path);
        Assert.Equal("BTCUSD_200626", seen.Param("symbol"));
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CmAccountTradeListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CmAccountTradeListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CmPositionAdlQuantileEstimationAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_201225","adlQuantile":{"LONG":3,"SHORT":3,"HEDGE":0,"BOTH":0}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CmPositionAdlQuantileEstimationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/adlQuantile", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CmPositionAdlQuantileEstimationWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_201225","adlQuantile":{"LONG":3,"SHORT":3,"HEDGE":0,"BOTH":0}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CmPositionAdlQuantileEstimationRequest
        {
            Symbol = "BTCUSD_201225",
            RecvWindow = 5000L,
        };

        var response = await client.CmPositionAdlQuantileEstimationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/adlQuantile", seen.Path);
        Assert.Equal("BTCUSD_201225", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CmPositionAdlQuantileEstimationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CmPositionAdlQuantileEstimationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesTradfiPerpsContractAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FuturesTradfiPerpsContractAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/stock/contract", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesTradfiPerpsContractWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesTradfiPerpsContractRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.FuturesTradfiPerpsContractAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/stock/contract", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesTradfiPerpsContractBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FuturesTradfiPerpsContractAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetUmFuturesBnbBurnStatusAsync()
    {
        const string example = """""{"feeBurn":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetUmFuturesBnbBurnStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/feeBurn", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesBnbBurnStatusWithOptionalParametersAsync()
    {
        const string example = """""{"feeBurn":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetUmFuturesBnbBurnStatusRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetUmFuturesBnbBurnStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/feeBurn", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetUmFuturesBnbBurnStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetUmFuturesBnbBurnStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountBorrowAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountBorrowRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
        };

        var response = await client.MarginAccountBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/marginLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountBorrowWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountBorrowRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/marginLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountBorrowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountBorrowRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountBorrowAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountNewOcoAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JYVpp3F0f5CAG15DhtrqLp","transactionTime":1563417480525,"symbol":"LTCBTC","marginBuyBorrowAmount":"5","marginBuyBorrowAsset":"BTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos"}],"orderReports":[{"symbol":"LTCBTC","orderId":2,"orderListId":0,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos","transactTime":1563417480525,"price":"0.000000","origQty":"0.624363","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"BUY","stopPrice":"0.960664"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOcoRequest
        {
            Symbol = "LTCBTC",
            Side = MarginAccountNewOcoSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            StopPrice = 1.0m,
        };

        var response = await client.MarginAccountNewOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/margin/order/oco", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1.0", seen.Param("stopPrice"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountNewOcoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JYVpp3F0f5CAG15DhtrqLp","transactionTime":1563417480525,"symbol":"LTCBTC","marginBuyBorrowAmount":"5","marginBuyBorrowAsset":"BTC","orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos"}],"orderReports":[{"symbol":"LTCBTC","orderId":2,"orderListId":0,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos","transactTime":1563417480525,"price":"0.000000","origQty":"0.624363","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"BUY","stopPrice":"0.960664"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOcoRequest
        {
            Symbol = "LTCBTC",
            Side = MarginAccountNewOcoSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            StopPrice = 1.0m,
            ListClientOrderId = "1",
            LimitClientOrderId = "1",
            LimitIcebergQty = 1.0m,
            StopClientOrderId = "1",
            StopLimitPrice = 1.0m,
            StopIcebergQty = 1.0m,
            StopLimitTimeInForce = MarginAccountNewOcoStopLimitTimeInForce.Gtc,
            NewOrderRespType = MarginAccountNewOcoNewOrderRespType.Ack,
            SideEffectType = MarginAccountNewOcoSideEffectType.NoSideEffect,
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountNewOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/margin/order/oco", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1.0", seen.Param("stopPrice"));
        Assert.Equal("1", seen.Param("listClientOrderId"));
        Assert.Equal("1", seen.Param("limitClientOrderId"));
        Assert.Equal("1.0", seen.Param("limitIcebergQty"));
        Assert.Equal("1", seen.Param("stopClientOrderId"));
        Assert.Equal("1.0", seen.Param("stopLimitPrice"));
        Assert.Equal("1.0", seen.Param("stopIcebergQty"));
        Assert.Equal("GTC", seen.Param("stopLimitTimeInForce"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NO_SIDE_EFFECT", seen.Param("sideEffectType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountNewOcoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountNewOcoRequest
        {
            Symbol = "LTCBTC",
            Side = MarginAccountNewOcoSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            StopPrice = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountNewOcoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountRepayAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountRepayRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
        };

        var response = await client.MarginAccountRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/repayLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountRepayWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountRepayRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/repayLoan", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountRepayBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountRepayRequest
        {
            Asset = "USDT",
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountRepayAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountRepayDebtAsync()
    {
        const string example = """""{"amount":"0.10000000","asset":"BNB","specifyRepayAssets":["USDT"],"updateTime":1636371437000,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountRepayDebtRequest
        {
            Asset = "USDT",
        };

        var response = await client.MarginAccountRepayDebtAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/margin/repay-debt", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountRepayDebtWithOptionalParametersAsync()
    {
        const string example = """""{"amount":"0.10000000","asset":"BNB","specifyRepayAssets":["USDT"],"updateTime":1636371437000,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountRepayDebtRequest
        {
            Asset = "USDT",
            Amount = "1.0",
            SpecifyRepayAssets = "BNB",
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountRepayDebtAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/margin/repay-debt", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("BNB", seen.Param("specifyRepayAssets"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountRepayDebtBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountRepayDebtRequest
        {
            Asset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountRepayDebtAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountTradeListAsync()
    {
        const string example = """""[{"commission":"0.00006000","commissionAsset":"BTC","id":34,"isBestMatch":true,"isBuyer":false,"isMaker":false,"orderId":39324,"price":"0.02000000","qty":"3.00000000","symbol":"BNBBTC","time":1561973357171}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountTradeListRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.MarginAccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/myTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountTradeListWithOptionalParametersAsync()
    {
        const string example = """""[{"commission":"0.00006000","commissionAsset":"BTC","id":34,"isBestMatch":true,"isBuyer":false,"isMaker":false,"orderId":39324,"price":"0.02000000","qty":"3.00000000","symbol":"BNBBTC","time":1561973357171}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountTradeListRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            FromId = 1L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/myTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountTradeListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountTradeListRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountTradeListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifyCmOrderAsync()
    {
        const string example = """""{"orderId":20072994037,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"side":"BUY","positionSide":"LONG","origType":"LIMIT","updateTime":1629182711600}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyCmOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Side = ModifyCmOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
        };

        var response = await client.ModifyCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyCmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":20072994037,"symbol":"BTCUSD_PERP","pair":"BTCUSD","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"side":"BUY","positionSide":"LONG","origType":"LIMIT","updateTime":1629182711600}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyCmOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Side = ModifyCmOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            OrderId = 1L,
            OrigClientOrderId = "1",
            PriceMatch = ModifyCmOrderPriceMatch.Opponent,
            ModifyId = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.ModifyCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("1", seen.Param("modifyId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyCmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ModifyCmOrderRequest
        {
            Symbol = "BTCUSD_PERP",
            Side = ModifyCmOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ModifyCmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifyUmOrderAsync()
    {
        const string example = """""{"orderId":20072994037,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"side":"BUY","positionSide":"LONG","origType":"LIMIT","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1629182711600,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyUmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyUmOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
        };

        var response = await client.ModifyUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyUmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":20072994037,"symbol":"BTCUSDT","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"side":"BUY","positionSide":"LONG","origType":"LIMIT","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1629182711600,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyUmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyUmOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            OrderId = 1L,
            OrigClientOrderId = "1",
            PriceMatch = ModifyUmOrderPriceMatch.Opponent,
            ModifyId = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.ModifyUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("1", seen.Param("modifyId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyUmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ModifyUmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyUmOrderSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ModifyUmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewCmConditionalOrderAsync()
    {
        const string example = """""{"newClientStrategyId":"testOrder","strategyId":123445,"strategyStatus":"NEW","strategyType":"TRAILING_STOP_MARKET","origQty":"10","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD_200925","pair":"BTCUSD","timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3","bookTime":1566818724710,"updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewCmConditionalOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewCmConditionalOrderSide.Buy,
            StrategyType = NewCmConditionalOrderStrategyType.Stop,
        };

        var response = await client.NewCmConditionalOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("STOP", seen.Param("strategyType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewCmConditionalOrderWithOptionalParametersAsync()
    {
        const string example = """""{"newClientStrategyId":"testOrder","strategyId":123445,"strategyStatus":"NEW","strategyType":"TRAILING_STOP_MARKET","origQty":"10","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD_200925","pair":"BTCUSD","timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3","bookTime":1566818724710,"updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewCmConditionalOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewCmConditionalOrderSide.Buy,
            StrategyType = NewCmConditionalOrderStrategyType.Stop,
            PositionSide = NewCmConditionalOrderPositionSide.Both,
            TimeInForce = NewCmConditionalOrderTimeInForce.Gtc,
            Quantity = 1.0m,
            ReduceOnly = "true",
            Price = 1.0m,
            WorkingType = NewCmConditionalOrderWorkingType.MarkPrice,
            PriceProtect = NewCmConditionalOrderPriceProtect.True,
            NewClientStrategyId = "1",
            StopPrice = 1.0m,
            ActivationPrice = 1.0m,
            CallbackRate = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.NewCmConditionalOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("STOP", seen.Param("strategyType"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("MARK_PRICE", seen.Param("workingType"));
        Assert.Equal("true", seen.Param("priceProtect"));
        Assert.Equal("1", seen.Param("newClientStrategyId"));
        Assert.Equal("1.0", seen.Param("stopPrice"));
        Assert.Equal("1.0", seen.Param("activationPrice"));
        Assert.Equal("1.0", seen.Param("callbackRate"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewCmConditionalOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewCmConditionalOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewCmConditionalOrderSide.Buy,
            StrategyType = NewCmConditionalOrderStrategyType.Stop,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewCmConditionalOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewCmOrderAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","timeInForce":"GTC","type":"MARKET","updateTime":1566818724722}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewCmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewCmOrderSide.Buy,
            Type = NewCmOrderType.Limit,
        };

        var response = await client.NewCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewCmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","timeInForce":"GTC","type":"MARKET","updateTime":1566818724722}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewCmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewCmOrderSide.Buy,
            Type = NewCmOrderType.Limit,
            PositionSide = NewCmOrderPositionSide.Both,
            TimeInForce = NewCmOrderTimeInForce.Gtc,
            Quantity = 1.0m,
            ReduceOnly = NewCmOrderReduceOnly.True,
            Price = 1.0m,
            PriceMatch = NewCmOrderPriceMatch.Opponent,
            NewClientOrderId = "1",
            NewOrderRespType = NewCmOrderNewOrderRespType.Ack,
            RecvWindow = 5000L,
        };

        var response = await client.NewCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("1", seen.Param("newClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewCmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewCmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewCmOrderSide.Buy,
            Type = NewCmOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewCmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewMarginOrderAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":28,"clientOrderId":"6gCrw2kRUAF9CvJDGP16IP","transactTime":1507725176595,"price":"1.00000000","origQty":"10.00000000","executedQty":"10.00000000","cummulativeQuoteQty":"10.00000000","status":"FILLED","timeInForce":"GTC","type":"MARKET","side":"SELL","marginBuyBorrowAmount":"5","marginBuyBorrowAsset":"BTC","fills":[{"price":"4000.00000000","qty":"1.00000000","commission":"4.00000000","commissionAsset":"USDT"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewMarginOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewMarginOrderSide.Buy,
            Type = NewMarginOrderType.Limit,
        };

        var response = await client.NewMarginOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/margin/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewMarginOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":28,"clientOrderId":"6gCrw2kRUAF9CvJDGP16IP","transactTime":1507725176595,"price":"1.00000000","origQty":"10.00000000","executedQty":"10.00000000","cummulativeQuoteQty":"10.00000000","status":"FILLED","timeInForce":"GTC","type":"MARKET","side":"SELL","marginBuyBorrowAmount":"5","marginBuyBorrowAsset":"BTC","fills":[{"price":"4000.00000000","qty":"1.00000000","commission":"4.00000000","commissionAsset":"USDT"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewMarginOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewMarginOrderSide.Buy,
            Type = NewMarginOrderType.Limit,
            Quantity = 1.0m,
            QuoteOrderQty = 1.0m,
            Price = 1.0m,
            StopPrice = 1.0m,
            NewClientOrderId = "1",
            NewOrderRespType = NewMarginOrderNewOrderRespType.Ack,
            IcebergQty = 1.0m,
            SideEffectType = NewMarginOrderSideEffectType.NoSideEffect,
            TimeInForce = NewMarginOrderTimeInForce.Gtc,
            SelfTradePreventionMode = NewMarginOrderSelfTradePreventionMode.None,
            AutoRepayAtCancel = true,
            RecvWindow = 5000L,
        };

        var response = await client.NewMarginOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/margin/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("quoteOrderQty"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1.0", seen.Param("stopPrice"));
        Assert.Equal("1", seen.Param("newClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("1.0", seen.Param("icebergQty"));
        Assert.Equal("NO_SIDE_EFFECT", seen.Param("sideEffectType"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("true", seen.Param("autoRepayAtCancel"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewMarginOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewMarginOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewMarginOrderSide.Buy,
            Type = NewMarginOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewMarginOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewUmAlgoOrderAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"activatePrice":"","callbackRate":"","createTime":1750485492076,"updateTime":1750485492076,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewUmAlgoOrderRequest
        {
            AlgoType = NewUmAlgoOrderAlgoType.Conditional,
            Symbol = "BNBUSDT",
            Side = NewUmAlgoOrderSide.Buy,
            Type = NewUmAlgoOrderType.Stop,
        };

        var response = await client.NewUmAlgoOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/algo/order", seen.Path);
        Assert.Equal("CONDITIONAL", seen.Param("algoType"));
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("STOP", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewUmAlgoOrderWithOptionalParametersAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"activatePrice":"","callbackRate":"","createTime":1750485492076,"updateTime":1750485492076,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewUmAlgoOrderRequest
        {
            AlgoType = NewUmAlgoOrderAlgoType.Conditional,
            Symbol = "BNBUSDT",
            Side = NewUmAlgoOrderSide.Buy,
            Type = NewUmAlgoOrderType.Stop,
            PositionSide = NewUmAlgoOrderPositionSide.Both,
            TimeInForce = NewUmAlgoOrderTimeInForce.Ioc,
            Quantity = 0.01m,
            Price = 750.000m,
            TriggerPrice = 750.000m,
            WorkingType = NewUmAlgoOrderWorkingType.MarkPrice,
            PriceMatch = NewUmAlgoOrderPriceMatch.Opponent,
            ClosePosition = NewUmAlgoOrderClosePosition.True,
            PriceProtect = NewUmAlgoOrderPriceProtect.True,
            ReduceOnly = NewUmAlgoOrderReduceOnly.True,
            ActivatePrice = 700m,
            CallbackRate = 1m,
            ClientAlgoId = "6B2I9XVcJpCjqPAJ4YoFX7",
            NewOrderRespType = NewUmAlgoOrderNewOrderRespType.Ack,
            SelfTradePreventionMode = NewUmAlgoOrderSelfTradePreventionMode.None,
            GoodTillDate = 0L,
            RecvWindow = 5000L,
        };

        var response = await client.NewUmAlgoOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/algo/order", seen.Path);
        Assert.Equal("CONDITIONAL", seen.Param("algoType"));
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("STOP", seen.Param("type"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("IOC", seen.Param("timeInForce"));
        Assert.Equal("0.01", seen.Param("quantity"));
        Assert.Equal("750.000", seen.Param("price"));
        Assert.Equal("750.000", seen.Param("triggerPrice"));
        Assert.Equal("MARK_PRICE", seen.Param("workingType"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("true", seen.Param("closePosition"));
        Assert.Equal("true", seen.Param("priceProtect"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("700", seen.Param("activatePrice"));
        Assert.Equal("1", seen.Param("callbackRate"));
        Assert.Equal("6B2I9XVcJpCjqPAJ4YoFX7", seen.Param("clientAlgoId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("0", seen.Param("goodTillDate"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewUmAlgoOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewUmAlgoOrderRequest
        {
            AlgoType = NewUmAlgoOrderAlgoType.Conditional,
            Symbol = "BNBUSDT",
            Side = NewUmAlgoOrderSide.Buy,
            Type = NewUmAlgoOrderType.Stop,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewUmAlgoOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewUmOrderAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","timeInForce":"GTD","type":"MARKET","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000,"updateTime":1566818724722,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewUmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewUmOrderSide.Buy,
            Type = NewUmOrderType.Limit,
        };

        var response = await client.NewUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewUmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","timeInForce":"GTD","type":"MARKET","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000,"updateTime":1566818724722,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewUmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewUmOrderSide.Buy,
            Type = NewUmOrderType.Limit,
            PositionSide = NewUmOrderPositionSide.Both,
            TimeInForce = NewUmOrderTimeInForce.Gtc,
            Quantity = 1.0m,
            ReduceOnly = NewUmOrderReduceOnly.True,
            Price = 1.0m,
            NewClientOrderId = "1",
            NewOrderRespType = NewUmOrderNewOrderRespType.Ack,
            PriceMatch = NewUmOrderPriceMatch.Opponent,
            SelfTradePreventionMode = NewUmOrderSelfTradePreventionMode.ExpireTaker,
            GoodTillDate = 1770736694138L,
            RecvWindow = 5000L,
        };

        var response = await client.NewUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1", seen.Param("newClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("EXPIRE_TAKER", seen.Param("selfTradePreventionMode"));
        Assert.Equal("1770736694138", seen.Param("goodTillDate"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewUmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewUmOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewUmOrderSide.Buy,
            Type = NewUmOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewUmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllCmConditionalOrdersAsync()
    {
        const string example = """""[{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"TRIGGERED","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","orderId":12123343534,"status":"NEW","bookTime":1566818724710,"updateTime":1566818724722,"triggerTime":1566818724750,"timeInForce":"GTC","type":"MARKET","activatePrice":"9020","priceRate":"0.3"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryAllCmConditionalOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/allOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCmConditionalOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"TRIGGERED","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","orderId":12123343534,"status":"NEW","bookTime":1566818724710,"updateTime":1566818724722,"triggerTime":1566818724750,"timeInForce":"GTC","type":"MARKET","activatePrice":"9020","priceRate":"0.3"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllCmConditionalOrdersRequest
        {
            Symbol = "BTCUSDT",
            StrategyId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllCmConditionalOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/allOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCmConditionalOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllCmConditionalOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllCmOrdersAsync()
    {
        const string example = """""[{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryAllCmOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/allOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCmOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllCmOrdersRequest
        {
            Symbol = "BTCUSD_200925",
            Pair = "BTCUSD",
            OrderId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllCmOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/allOrders", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCmOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllCmOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllCurrentCmOpenConditionalOrdersAsync()
    {
        const string example = """""[{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"NEW","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","bookTime":1566818724710,"updateTime":1566818724722,"timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryAllCurrentCmOpenConditionalOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentCmOpenConditionalOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"NEW","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","bookTime":1566818724710,"updateTime":1566818724722,"timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllCurrentCmOpenConditionalOrdersRequest
        {
            Symbol = "BTCUSD",
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllCurrentCmOpenConditionalOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/openOrders", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentCmOpenConditionalOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllCurrentCmOpenConditionalOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllCurrentCmOpenOrdersAsync()
    {
        const string example = """""[{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryAllCurrentCmOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentCmOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllCurrentCmOpenOrdersRequest
        {
            Symbol = "BTCUSD_200925",
            Pair = "BTCUSD",
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllCurrentCmOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/openOrders", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentCmOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllCurrentCmOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllCurrentUmOpenAlgoOrdersAsync()
    {
        const string example = """""[{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750485492076,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryAllCurrentUmOpenAlgoOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/algo/openAlgoOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentUmOpenAlgoOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750485492076,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllCurrentUmOpenAlgoOrdersRequest
        {
            AlgoType = "CONDITIONAL",
            Symbol = "BNBUSDT",
            AlgoId = 2146760L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllCurrentUmOpenAlgoOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/algo/openAlgoOrders", seen.Path);
        Assert.Equal("CONDITIONAL", seen.Param("algoType"));
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("2146760", seen.Param("algoId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentUmOpenAlgoOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllCurrentUmOpenAlgoOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllCurrentUmOpenOrdersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryAllCurrentUmOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentUmOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllCurrentUmOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllCurrentUmOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/openOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllCurrentUmOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllCurrentUmOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllMarginAccountOrdersAsync()
    {
        const string example = """""[{"clientOrderId":"D2KDy4DIeS56PvkM13f8cP","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":false,"orderId":41295,"origQty":"5.31000000","price":"0.22500000","side":"SELL","status":"CANCELED","stopPrice":"0.18000000","symbol":"BNBBTC","time":1565769338806,"timeInForce":"GTC","type":"TAKE_PROFIT_LIMIT","updateTime":1565769342148,"accountId":152950866,"selfTradePreventionMode":"EXPIRE_TAKER","preventedMatchId":"null","preventedQuantity":"null"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllMarginAccountOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryAllMarginAccountOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/allOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllMarginAccountOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"clientOrderId":"D2KDy4DIeS56PvkM13f8cP","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":false,"orderId":41295,"origQty":"5.31000000","price":"0.22500000","side":"SELL","status":"CANCELED","stopPrice":"0.18000000","symbol":"BNBBTC","time":1565769338806,"timeInForce":"GTC","type":"TAKE_PROFIT_LIMIT","updateTime":1565769342148,"accountId":152950866,"selfTradePreventionMode":"EXPIRE_TAKER","preventedMatchId":"null","preventedQuantity":"null"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllMarginAccountOrdersRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllMarginAccountOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/allOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllMarginAccountOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryAllMarginAccountOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllMarginAccountOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllUmOrdersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllUmOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryAllUmOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/allOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllUmOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllUmOrdersRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllUmOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/allOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllUmOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryAllUmOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllUmOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCmConditionalOrderHistoryAsync()
    {
        const string example = """""{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"TRIGGERED","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","orderId":12123343534,"status":"NEW","bookTime":1566818724710,"updateTime":1566818724722,"triggerTime":1566818724750,"timeInForce":"GTC","type":"MARKET","activatePrice":"9020","priceRate":"0.3","workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCmConditionalOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryCmConditionalOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/orderHistory", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmConditionalOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"TRIGGERED","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","orderId":12123343534,"status":"NEW","bookTime":1566818724710,"updateTime":1566818724722,"triggerTime":1566818724750,"timeInForce":"GTC","type":"MARKET","activatePrice":"9020","priceRate":"0.3","workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCmConditionalOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
            StrategyId = 1L,
            NewClientStrategyId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCmConditionalOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/orderHistory", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("newClientStrategyId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmConditionalOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCmConditionalOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCmConditionalOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCmModifyOrderHistoryAsync()
    {
        const string example = """""[{"amendmentId":5363,"symbol":"BTCUSD_PERP","pair":"BTCUSD","orderId":20072994037,"clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","time":1629184560899,"amendment":{"price":{"before":"30004","after":"30003.2"},"origQty":{"before":"1","after":"1"},"count":3,"modifyId":123}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCmModifyOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryCmModifyOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/orderAmendment", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmModifyOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"amendmentId":5363,"symbol":"BTCUSD_PERP","pair":"BTCUSD","orderId":20072994037,"clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","time":1629184560899,"amendment":{"price":{"before":"30004","after":"30003.2"},"origQty":{"before":"1","after":"1"},"count":3,"modifyId":123}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCmModifyOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            OrigClientOrderId = "1",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryCmModifyOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/orderAmendment", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmModifyOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCmModifyOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCmModifyOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCmOrderAsync()
    {
        const string example = """""{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","positionSide":"SHORT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCmOrderRequest
        {
            Symbol = "BTCUSD_200925",
        };

        var response = await client.QueryCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","positionSide":"SHORT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCmOrderRequest
        {
            Symbol = "BTCUSD_200925",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/order", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCmOrderRequest
        {
            Symbol = "BTCUSD_200925",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentCmOpenConditionalOrderAsync()
    {
        const string example = """""{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"NEW","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","bookTime":1566818724710,"updateTime":1566818724722,"timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentCmOpenConditionalOrderRequest
        {
            Symbol = "BTCUSD_200925",
        };

        var response = await client.QueryCurrentCmOpenConditionalOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/openOrder", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentCmOpenConditionalOrderWithOptionalParametersAsync()
    {
        const string example = """""{"newClientStrategyId":"abc","strategyId":123445,"strategyStatus":"NEW","strategyType":"TRAILING_STOP_MARKET","origQty":"0.40","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","stopPrice":"9300","symbol":"BTCUSD","bookTime":1566818724710,"updateTime":1566818724722,"timeInForce":"GTC","activatePrice":"9020","priceRate":"0.3"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentCmOpenConditionalOrderRequest
        {
            Symbol = "BTCUSD_200925",
            StrategyId = 1L,
            NewClientStrategyId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentCmOpenConditionalOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/conditional/openOrder", seen.Path);
        Assert.Equal("BTCUSD_200925", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("strategyId"));
        Assert.Equal("1", seen.Param("newClientStrategyId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentCmOpenConditionalOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCurrentCmOpenConditionalOrderRequest
        {
            Symbol = "BTCUSD_200925",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentCmOpenConditionalOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentCmOpenOrderAsync()
    {
        const string example = """""[{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentCmOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryCurrentCmOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/openOrder", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentCmOpenOrderWithOptionalParametersAsync()
    {
        const string example = """""[{"avgPrice":"0.0","clientOrderId":"abc","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSD_200925","pair":"BTCUSD","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentCmOpenOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1917641L,
            OrigClientOrderId = "abc",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentCmOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/openOrder", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1917641", seen.Param("orderId"));
        Assert.Equal("abc", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentCmOpenOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCurrentCmOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentCmOpenOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentMarginOpenOrderAsync()
    {
        const string example = """""[{"clientOrderId":"qhcZw71gAkCCTv0t0k8LUK","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":211842552,"origQty":"0.30000000","price":"0.00475010","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","time":1562040170089,"timeInForce":"GTC","type":"LIMIT","updateTime":1562040170089,"accountId":152950866,"selfTradePreventionMode":"EXPIRE_TAKER","preventedMatchId":"null","preventedQuantity":"null"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentMarginOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryCurrentMarginOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/openOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentMarginOpenOrderWithOptionalParametersAsync()
    {
        const string example = """""[{"clientOrderId":"qhcZw71gAkCCTv0t0k8LUK","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":211842552,"origQty":"0.30000000","price":"0.00475010","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","time":1562040170089,"timeInForce":"GTC","type":"LIMIT","updateTime":1562040170089,"accountId":152950866,"selfTradePreventionMode":"EXPIRE_TAKER","preventedMatchId":"null","preventedQuantity":"null"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentMarginOpenOrderRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentMarginOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/openOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentMarginOpenOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCurrentMarginOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentMarginOpenOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentUmOpenAlgoOrderAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCurrentUmOpenAlgoOrderAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/algo/algoOrder", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentUmOpenAlgoOrderWithOptionalParametersAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentUmOpenAlgoOrderRequest
        {
            AlgoId = 2146760L,
            ClientAlgoId = "6B2I9XVcJpCjqPAJ4YoFX7",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentUmOpenAlgoOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/algo/algoOrder", seen.Path);
        Assert.Equal("2146760", seen.Param("algoId"));
        Assert.Equal("6B2I9XVcJpCjqPAJ4YoFX7", seen.Param("clientAlgoId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentUmOpenAlgoOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentUmOpenAlgoOrderAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentUmOpenOrderAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentUmOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryCurrentUmOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/openOrder", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentUmOpenOrderWithOptionalParametersAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentUmOpenOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentUmOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/openOrder", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentUmOpenOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCurrentUmOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentUmOpenOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountOrderAsync()
    {
        const string example = """""{"clientOrderId":"ZwfQzuDIGpceVhKW5DvCmO","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":213205622,"origQty":"0.30000000","price":"0.00493630","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","time":1562133008725,"timeInForce":"GTC","type":"LIMIT","updateTime":1562133008725,"accountId":152950866,"selfTradePreventionMode":"EXPIRE_TAKER","preventedMatchId":"null","preventedQuantity":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryMarginAccountOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"ZwfQzuDIGpceVhKW5DvCmO","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":213205622,"origQty":"0.30000000","price":"0.00493630","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","time":1562133008725,"timeInForce":"GTC","type":"LIMIT","updateTime":1562133008725,"accountId":152950866,"selfTradePreventionMode":"EXPIRE_TAKER","preventedMatchId":"null","preventedQuantity":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginAccountOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsAllOcoAsync()
    {
        const string example = """""[{"orderListId":29,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"amEEAXryFzFwYF1FeRpUoZ","transactionTime":1565245913483,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"oD7aesZqjEGlZrbtRpy5zB"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsAllOcoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/allOrderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsAllOcoWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":29,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"amEEAXryFzFwYF1FeRpUoZ","transactionTime":1565245913483,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"oD7aesZqjEGlZrbtRpy5zB"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsAllOcoRequest
        {
            FromId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsAllOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/allOrderList", seen.Path);
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsAllOcoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsAllOcoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsOcoAsync()
    {
        const string example = """""{"orderListId":27,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"h2USkA5YQpaXHPIrkd96xE","transactionTime":1565245656253,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"qD1gy3kc3Gx0rihm9Y3xwS"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsOcoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/orderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOcoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":27,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"h2USkA5YQpaXHPIrkd96xE","transactionTime":1565245656253,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"qD1gy3kc3Gx0rihm9Y3xwS"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOcoRequest
        {
            OrderListId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/orderList", seen.Path);
        Assert.Equal("1", seen.Param("orderListId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOcoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsOcoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOcoAsync()
    {
        const string example = """""[{"orderListId":31,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"wuB13fmulKj3YjdqWEcsnp","transactionTime":1565246080644,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"r3EH2N76dHfLoSZWIUw1bT"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsOpenOcoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/openOrderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOcoWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":31,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"wuB13fmulKj3YjdqWEcsnp","transactionTime":1565246080644,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"r3EH2N76dHfLoSZWIUw1bT"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOpenOcoRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsOpenOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/openOrderList", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOcoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsOpenOcoAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUmAlgoOrderHistoryAsync()
    {
        const string example = """""[{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUmAlgoOrderHistoryRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.QueryUmAlgoOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/algo/allAlgoOrders", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmAlgoOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUmAlgoOrderHistoryRequest
        {
            Symbol = "BNBUSDT",
            AlgoId = 2146760L,
            StartTime = 1770130294138L,
            EndTime = 1770736694138L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUmAlgoOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/algo/allAlgoOrders", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("2146760", seen.Param("algoId"));
        Assert.Equal("1770130294138", seen.Param("startTime"));
        Assert.Equal("1770736694138", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmAlgoOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryUmAlgoOrderHistoryRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUmAlgoOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUmModifyOrderHistoryAsync()
    {
        const string example = """""[{"amendmentId":5363,"symbol":"BTCUSDT","pair":"BTCUSDT","orderId":20072994037,"clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","time":1629184560899,"amendment":{"price":{"before":"30004","after":"30003.2"},"origQty":{"before":"1","after":"1"},"count":3,"modifyId":123},"priceMatch":"NONE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUmModifyOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryUmModifyOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/orderAmendment", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmModifyOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"amendmentId":5363,"symbol":"BTCUSDT","pair":"BTCUSDT","orderId":20072994037,"clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","time":1629184560899,"amendment":{"price":{"before":"30004","after":"30003.2"},"origQty":{"before":"1","after":"1"},"count":3,"modifyId":123},"priceMatch":"NONE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUmModifyOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            OrigClientOrderId = "1",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUmModifyOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/orderAmendment", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmModifyOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryUmModifyOrderHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUmModifyOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUmOrderAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUmOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmOrderWithOptionalParametersAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"LIMIT","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"LIMIT","updateTime":1579276756075,"selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"priceMatch":"NONE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUmOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryUmOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUmOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryUmOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUmOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUsersCmForceOrdersAsync()
    {
        const string example = """""[{"orderId":165123080,"symbol":"BTCUSD_200925","pair":"BTCUSD","status":"FILLED","clientOrderId":"autoclose-1596542005017000006","price":"11326.9","avgPrice":"11326.9","origQty":"1","executedQty":"1","cumBase":"0.00882854","timeInForce":"IOC","type":"LIMIT","reduceOnly":false,"side":"SELL","positionSide":"BOTH","origType":"LIMIT","time":1596542005019,"updateTime":1596542005050}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUsersCmForceOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/forceOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUsersCmForceOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":165123080,"symbol":"BTCUSD_200925","pair":"BTCUSD","status":"FILLED","clientOrderId":"autoclose-1596542005017000006","price":"11326.9","avgPrice":"11326.9","origQty":"1","executedQty":"1","cumBase":"0.00882854","timeInForce":"IOC","type":"LIMIT","reduceOnly":false,"side":"SELL","positionSide":"BOTH","origType":"LIMIT","time":1596542005019,"updateTime":1596542005050}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUsersCmForceOrdersRequest
        {
            Symbol = "BTCUSDT",
            AutoCloseType = QueryUsersCmForceOrdersAutoCloseType.Liquidation,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUsersCmForceOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/cm/forceOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("LIQUIDATION", seen.Param("autoCloseType"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUsersCmForceOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUsersCmForceOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUsersMarginForceOrdersAsync()
    {
        const string example = """""{"rows":[{"avgPrice":"0.00388359","executedQty":"31.39000000","orderId":180015097,"price":"0.00388110","qty":"31.39000000","side":"SELL","symbol":"BNBBTC","timeInForce":"GTC","updatedTime":1558941374745}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUsersMarginForceOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/forceOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUsersMarginForceOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"avgPrice":"0.00388359","executedQty":"31.39000000","orderId":180015097,"price":"0.00388110","qty":"31.39000000","side":"SELL","symbol":"BNBBTC","timeInForce":"GTC","updatedTime":1558941374745}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUsersMarginForceOrdersRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUsersMarginForceOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/margin/forceOrders", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUsersMarginForceOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUsersMarginForceOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryUsersUmForceOrdersAsync()
    {
        const string example = """""[{"orderId":6071832819,"symbol":"BTCUSDT","status":"FILLED","clientOrderId":"autoclose-1596107620040000020","price":"10871.09","avgPrice":"10913.21000","origQty":"0.001","executedQty":"0.001","cumQuote":"10.91321","timeInForce":"IOC","type":"LIMIT","reduceOnly":false,"side":"SELL","positionSide":"BOTH","origType":"LIMIT","time":1596107620044,"updateTime":1596107620087}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryUsersUmForceOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/forceOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUsersUmForceOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":6071832819,"symbol":"BTCUSDT","status":"FILLED","clientOrderId":"autoclose-1596107620040000020","price":"10871.09","avgPrice":"10913.21000","origQty":"0.001","executedQty":"0.001","cumQuote":"10.91321","timeInForce":"IOC","type":"LIMIT","reduceOnly":false,"side":"SELL","positionSide":"BOTH","origType":"LIMIT","time":1596107620044,"updateTime":1596107620087}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryUsersUmForceOrdersRequest
        {
            Symbol = "BTCUSDT",
            AutoCloseType = QueryUsersUmForceOrdersAutoCloseType.Liquidation,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryUsersUmForceOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/forceOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("LIQUIDATION", seen.Param("autoCloseType"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryUsersUmForceOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryUsersUmForceOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ToggleBnbBurnOnUmFuturesTradeAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ToggleBnbBurnOnUmFuturesTradeRequest
        {
            FeeBurn = ToggleBnbBurnOnUmFuturesTradeFeeBurn.True,
        };

        var response = await client.ToggleBnbBurnOnUmFuturesTradeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/feeBurn", seen.Path);
        Assert.Equal("true", seen.Param("feeBurn"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ToggleBnbBurnOnUmFuturesTradeWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ToggleBnbBurnOnUmFuturesTradeRequest
        {
            FeeBurn = ToggleBnbBurnOnUmFuturesTradeFeeBurn.True,
            RecvWindow = 5000L,
        };

        var response = await client.ToggleBnbBurnOnUmFuturesTradeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/papi/v1/um/feeBurn", seen.Path);
        Assert.Equal("true", seen.Param("feeBurn"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ToggleBnbBurnOnUmFuturesTradeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ToggleBnbBurnOnUmFuturesTradeRequest
        {
            FeeBurn = ToggleBnbBurnOnUmFuturesTradeFeeBurn.True,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ToggleBnbBurnOnUmFuturesTradeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UmAccountTradeListAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","id":67880589,"orderId":270093109,"side":"SELL","price":"28511.00","qty":"0.010","realizedPnl":"2.58500000","quoteQty":"285.11000","commission":"0.11404400","commissionAsset":"USDT","time":1680688557875,"buyer":false,"maker":false,"positionSide":"BOTH"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UmAccountTradeListRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.UmAccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/userTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmAccountTradeListWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","id":67880589,"orderId":270093109,"side":"SELL","price":"28511.00","qty":"0.010","realizedPnl":"2.58500000","quoteQty":"285.11000","commission":"0.11404400","commissionAsset":"USDT","time":1680688557875,"buyer":false,"maker":false,"positionSide":"BOTH"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UmAccountTradeListRequest
        {
            Symbol = "BTCUSDT",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            FromId = 1L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.UmAccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/userTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("500", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmAccountTradeListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new UmAccountTradeListRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UmAccountTradeListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UmPositionAdlQuantileEstimationAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","adlQuantile":{"LONG":3,"SHORT":3,"BOTH":0}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UmPositionAdlQuantileEstimationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/adlQuantile", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmPositionAdlQuantileEstimationWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","adlQuantile":{"LONG":3,"SHORT":3,"BOTH":0}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UmPositionAdlQuantileEstimationRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.UmPositionAdlQuantileEstimationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/papi/v1/um/adlQuantile", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UmPositionAdlQuantileEstimationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UmPositionAdlQuantileEstimationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
