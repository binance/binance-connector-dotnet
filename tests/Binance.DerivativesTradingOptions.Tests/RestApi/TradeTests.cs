//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingOptions.RestApi;

namespace Binance.DerivativesTradingOptions.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static DerivativesTradingOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountTradeListAsync()
    {
        const string example = """""[{"id":4611875134427365000,"tradeId":239,"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","fee":"-1.04378629","realizedProfit":"0.00000000","side":"BUY","type":"LIMIT","liquidity":"TAKER","time":1592465880683,"priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountTradeListRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.AccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/userTrades", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountTradeListWithOptionalParametersAsync()
    {
        const string example = """""[{"id":4611875134427365000,"tradeId":239,"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","fee":"-1.04378629","realizedProfit":"0.00000000","side":"BUY","type":"LIMIT","liquidity":"TAKER","time":1592465880683,"priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountTradeListRequest
        {
            Symbol = "BTC-200730-9000-C",
            FromId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.AccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/userTrades", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountTradeListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AccountTradeListRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountTradeListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAllOptionOrdersByUnderlyingAsync()
    {
        const string example = """""{"code":0,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllOptionOrdersByUnderlyingRequest
        {
            Underlying = "BTCUSDT",
        };

        var response = await client.CancelAllOptionOrdersByUnderlyingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/allOpenOrdersByUnderlying", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOptionOrdersByUnderlyingWithOptionalParametersAsync()
    {
        const string example = """""{"code":0,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllOptionOrdersByUnderlyingRequest
        {
            Underlying = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllOptionOrdersByUnderlyingAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/allOpenOrdersByUnderlying", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOptionOrdersByUnderlyingBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllOptionOrdersByUnderlyingRequest
        {
            Underlying = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllOptionOrdersByUnderlyingAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAllOptionOrdersOnSpecificSymbolAsync()
    {
        const string example = """""{"code":"0","msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllOptionOrdersOnSpecificSymbolRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.CancelAllOptionOrdersOnSpecificSymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/allOpenOrders", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOptionOrdersOnSpecificSymbolWithOptionalParametersAsync()
    {
        const string example = """""{"code":"0","msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllOptionOrdersOnSpecificSymbolRequest
        {
            Symbol = "BTC-200730-9000-C",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllOptionOrdersOnSpecificSymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/allOpenOrders", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOptionOrdersOnSpecificSymbolBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllOptionOrdersOnSpecificSymbolRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllOptionOrdersOnSpecificSymbolAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelMultipleOptionOrdersAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","fee":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"ACCEPTED","avgPrice":"0","clientOrderId":"","priceScale":3,"quantityScale":4,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"source":"API","selfTradePreventionMode":"EXPIRE_MAKER"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMultipleOptionOrdersRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.CancelMultipleOptionOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/batchOrders", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMultipleOptionOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","fee":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"ACCEPTED","avgPrice":"0","clientOrderId":"","priceScale":3,"quantityScale":4,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"source":"API","selfTradePreventionMode":"EXPIRE_MAKER"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMultipleOptionOrdersRequest
        {
            Symbol = "BTC-200730-9000-C",
            OrderIds = new() { },
            ClientOrderIds = new() { },
            RecvWindow = 5000L,
        };

        var response = await client.CancelMultipleOptionOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/batchOrders", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMultipleOptionOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelMultipleOptionOrdersRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelMultipleOptionOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelOptionOrderAsync()
    {
        const string example = """""{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createDate":1592465880683,"updateTime":1566818724722,"status":"ACCEPTED","avgPrice":"0","source":"API","clientOrderId":"","priceScale":4,"quantityScale":4,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelOptionOrderRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.CancelOptionOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/order", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelOptionOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createDate":1592465880683,"updateTime":1566818724722,"status":"ACCEPTED","avgPrice":"0","source":"API","clientOrderId":"","priceScale":4,"quantityScale":4,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelOptionOrderRequest
        {
            Symbol = "BTC-200730-9000-C",
            OrderId = 4611875134427365000L,
            ClientOrderId = "10000",
            RecvWindow = 5000L,
        };

        var response = await client.CancelOptionOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/order", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("4611875134427365000", seen.Param("orderId"));
        Assert.Equal("10000", seen.Param("clientOrderId"));
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
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelOptionOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewOrderAsync()
    {
        const string example = """""{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","fee":0,"side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"postOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"NEW","avgPrice":"0","source":"API","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BTC-200730-9000-C",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
            Quantity = 1.0m,
        };

        var response = await client.NewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/order", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","fee":0,"side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"postOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"NEW","avgPrice":"0","source":"API","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BTC-200730-9000-C",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
            Quantity = 1.0m,
            Price = 1.0m,
            TimeInForce = NewOrderTimeInForce.Gtc,
            ReduceOnly = false,
            PostOnly = false,
            NewOrderRespType = NewOrderNewOrderRespType.Ack,
            ClientOrderId = "1",
            IsMmp = true,
            SelfTradePreventionMode = NewOrderSelfTradePreventionMode.None,
            RecvWindow = 5000L,
        };

        var response = await client.NewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/order", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("false", seen.Param("reduceOnly"));
        Assert.Equal("false", seen.Param("postOnly"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("1", seen.Param("clientOrderId"));
        Assert.Equal("true", seen.Param("isMmp"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
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
            Symbol = "BTC-200730-9000-C",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
            Quantity = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OptionPositionInformationAsync()
    {
        const string example = """""[{"entryPrice":"1000","symbol":"BTC-200730-9000-C","side":"SHORT","quantity":"-0.1","markValue":"105.00138","unrealizedPNL":"-5.00138","markPrice":"1050.0138","strikePrice":"9000","expiryDate":1593511200000,"priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","time":1762872654561,"bidQuantity":"0.0000","askQuantity":"0.0000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OptionPositionInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/position", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionPositionInformationWithOptionalParametersAsync()
    {
        const string example = """""[{"entryPrice":"1000","symbol":"BTC-200730-9000-C","side":"SHORT","quantity":"-0.1","markValue":"105.00138","unrealizedPNL":"-5.00138","markPrice":"1050.0138","strikePrice":"9000","expiryDate":1593511200000,"priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","time":1762872654561,"bidQuantity":"0.0000","askQuantity":"0.0000"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OptionPositionInformationRequest
        {
            Symbol = "BTC-200730-9000-C",
            RecvWindow = 5000L,
        };

        var response = await client.OptionPositionInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/position", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OptionPositionInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OptionPositionInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PlaceMultipleOrdersAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","fee":0,"side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"postOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"NEW","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER","source":"API"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceMultipleOrdersRequest
        {
            Orders = new() { },
        };

        var response = await client.PlaceMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/batchOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceMultipleOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","fee":0,"side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"postOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"NEW","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER","source":"API"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceMultipleOrdersRequest
        {
            Orders = new() { },
            RecvWindow = 5000L,
        };

        var response = await client.PlaceMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/batchOrders", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceMultipleOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new PlaceMultipleOrdersRequest
        {
            Orders = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PlaceMultipleOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentOpenOptionOrdersAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createTime":1592465880683,"updateTime":1592465880683,"status":"NEW","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCurrentOpenOptionOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentOpenOptionOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createTime":1592465880683,"updateTime":1592465880683,"status":"NEW","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentOpenOptionOrdersRequest
        {
            Symbol = "BTC-200730-9000-C",
            OrderId = 4611875134427365000L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentOpenOptionOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/openOrders", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("4611875134427365000", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentOpenOptionOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentOpenOptionOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryOptionOrderHistoryAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createTime":1592465880683,"updateTime":1592465880683,"status":"ACCEPTED","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryOptionOrderHistoryRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.QueryOptionOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/historyOrders", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryOptionOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"createTime":1592465880683,"updateTime":1592465880683,"status":"ACCEPTED","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryOptionOrderHistoryRequest
        {
            Symbol = "BTC-200730-9000-C",
            OrderId = 4611875134427365000L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryOptionOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/historyOrders", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("4611875134427365000", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryOptionOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryOptionOrderHistoryRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryOptionOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySingleOrderAsync()
    {
        const string example = """""{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"postOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"NEW","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySingleOrderRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var response = await client.QuerySingleOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/order", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySingleOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":4611875134427365000,"symbol":"BTC-200730-9000-C","price":"100","quantity":"1","executedQty":"0","side":"BUY","type":"LIMIT","timeInForce":"GTC","reduceOnly":false,"postOnly":false,"createTime":1592465880683,"updateTime":1566818724722,"status":"NEW","avgPrice":"0","clientOrderId":"","priceScale":2,"quantityScale":2,"optionSide":"CALL","quoteAsset":"USDT","mmp":false,"selfTradePreventionMode":"EXPIRE_MAKER"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySingleOrderRequest
        {
            Symbol = "BTC-200730-9000-C",
            OrderId = 4611875134427365000L,
            ClientOrderId = "abc123",
            RecvWindow = 5000L,
        };

        var response = await client.QuerySingleOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/order", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("4611875134427365000", seen.Param("orderId"));
        Assert.Equal("abc123", seen.Param("clientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySingleOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QuerySingleOrderRequest
        {
            Symbol = "BTC-200730-9000-C",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySingleOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TradfiOptionsContractAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.TradfiOptionsContractAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/stock/contract", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TradfiOptionsContractWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TradfiOptionsContractRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.TradfiOptionsContractAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/stock/contract", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TradfiOptionsContractBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TradfiOptionsContractAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserCommissionAsync()
    {
        const string example = """""{"commissions":[{"underlying":"BTCUSDT","makerFee":"0.000240","takerFee":"0.000240"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UserCommissionAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/commission", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserCommissionWithOptionalParametersAsync()
    {
        const string example = """""{"commissions":[{"underlying":"BTCUSDT","makerFee":"0.000240","takerFee":"0.000240"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserCommissionRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.UserCommissionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/commission", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserCommissionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UserCommissionAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserExerciseRecordAsync()
    {
        const string example = """""[{"id":"1125899906842624042","currency":"USDT","symbol":"BTC-220721-25000-C","exercisePrice":"25000.00000000","quantity":"1.00000000","amount":"0.00000000","fee":"0.00000000","createDate":1658361600000,"priceScale":2,"quantityScale":2,"optionSide":"CALL","positionSide":"LONG","quoteAsset":"USDT"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UserExerciseRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/exerciseRecord", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserExerciseRecordWithOptionalParametersAsync()
    {
        const string example = """""[{"id":"1125899906842624042","currency":"USDT","symbol":"BTC-220721-25000-C","exercisePrice":"25000.00000000","quantity":"1.00000000","amount":"0.00000000","fee":"0.00000000","createDate":1658361600000,"priceScale":2,"quantityScale":2,"optionSide":"CALL","positionSide":"LONG","quoteAsset":"USDT"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserExerciseRecordRequest
        {
            Symbol = "BTC-200730-9000-C",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 20L,
            RecvWindow = 5000L,
        };

        var response = await client.UserExerciseRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/exerciseRecord", seen.Path);
        Assert.Equal("BTC-200730-9000-C", seen.Param("symbol"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("20", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserExerciseRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UserExerciseRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
