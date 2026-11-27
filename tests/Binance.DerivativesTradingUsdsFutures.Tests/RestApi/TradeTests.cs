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

namespace Binance.DerivativesTradingUsdsFutures.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static DerivativesTradingUsdsFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountTradeListAsync()
    {
        const string example = """""[{"buyer":false,"commission":"0.07819010","commissionAsset":"USDT","id":698759,"maker":false,"orderId":25851813,"price":"7819.01","qty":"0.002","quoteQty":"15.63802","baseQty":"0","marginAsset":"USDT","realizedPnl":"-0.91539999","side":"SELL","positionSide":"SHORT","symbol":"BTCUSDT","pair":"BTCUSDT","time":1569514978020}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountTradeListRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.AccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/userTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountTradeListWithOptionalParametersAsync()
    {
        const string example = """""[{"buyer":false,"commission":"0.07819010","commissionAsset":"USDT","id":698759,"maker":false,"orderId":25851813,"price":"7819.01","qty":"0.002","quoteQty":"15.63802","baseQty":"0","marginAsset":"USDT","realizedPnl":"-0.91539999","side":"SELL","positionSide":"SHORT","symbol":"BTCUSDT","pair":"BTCUSDT","time":1569514978020}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountTradeListRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 25851813L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            FromId = 1L,
            Limit = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.AccountTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/userTrades", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("25851813", seen.Param("orderId"));
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
    public async Task AccountTradeListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AccountTradeListRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountTradeListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AllOrdersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","pair":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AllOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/allOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AllOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","cumBase":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","pair":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AllOrdersRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1917641L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.AllOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/allOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1917641", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AllOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AllOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AutoCancelAllOpenOrdersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","countdownTime":"100000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AutoCancelAllOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            CountdownTime = 1000L,
        };

        var response = await client.AutoCancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/countdownCancelAll", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1000", seen.Param("countdownTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AutoCancelAllOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","countdownTime":"100000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AutoCancelAllOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            CountdownTime = 1000L,
            RecvWindow = 5000L,
        };

        var response = await client.AutoCancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/countdownCancelAll", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1000", seen.Param("countdownTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AutoCancelAllOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AutoCancelAllOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            CountdownTime = 1000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AutoCancelAllOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAlgoOrderAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","code":"200","msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CancelAlgoOrderAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/algoOrder", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAlgoOrderWithOptionalParametersAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","code":"200","msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAlgoOrderRequest
        {
            AlgoId = 2146760L,
            ClientAlgoId = "6B2I9XVcJpCjqPAJ4YoFX7",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAlgoOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/algoOrder", seen.Path);
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
    public async Task CancelAlgoOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAlgoOrderAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAllAlgoOpenOrdersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllAlgoOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelAllAlgoOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/algoOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllAlgoOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllAlgoOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllAlgoOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/algoOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllAlgoOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllAlgoOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllAlgoOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelAllOpenOrdersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"The operation of cancel all open order is done."}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelAllOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CancelAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/allOpenOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelAllOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelAllOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelAllOpenOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelMultipleOrdersAsync()
    {
        const string example = """""[{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","origType":"TRAILING_STOP_MARKET","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"code":-2011,"msg":"Unknown order sent."}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMultipleOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/batchOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMultipleOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","origType":"TRAILING_STOP_MARKET","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"code":-2011,"msg":"Unknown order sent."}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelMultipleOrdersRequest
        {
            Symbol = "BTCUSDT",
            OrderIdList = new() { },
            OrigClientOrderIdList = new() { },
            RecvWindow = 5000L,
        };

        var response = await client.CancelMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/batchOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelMultipleOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelMultipleOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelMultipleOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelOrderAsync()
    {
        const string example = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","origType":"TRAILING_STOP_MARKET","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.CancelOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"myOrder1","cumQty":"0","executedQty":"0","orderId":283194212,"origQty":"11","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"CANCELED","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","origType":"TRAILING_STOP_MARKET","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1571110484038,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 283194212L,
            OrigClientOrderId = "myOrder1",
            RecvWindow = 5000L,
        };

        var response = await client.CancelOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("283194212", seen.Param("orderId"));
        Assert.Equal("myOrder1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangeInitialLeverageAsync()
    {
        const string example = """""{"leverage":21,"maxNotionalValue":"1000000","symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeInitialLeverageRequest
        {
            Symbol = "BTCUSDT",
            Leverage = 1L,
        };

        var response = await client.ChangeInitialLeverageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/leverage", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("leverage"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeInitialLeverageWithOptionalParametersAsync()
    {
        const string example = """""{"leverage":21,"maxNotionalValue":"1000000","symbol":"BTCUSDT"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeInitialLeverageRequest
        {
            Symbol = "BTCUSDT",
            Leverage = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.ChangeInitialLeverageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/leverage", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("leverage"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeInitialLeverageBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeInitialLeverageRequest
        {
            Symbol = "BTCUSDT",
            Leverage = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeInitialLeverageAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangeMarginTypeAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeMarginTypeRequest
        {
            Symbol = "BTCUSDT",
            MarginType = ChangeMarginTypeMarginType.Isolated,
        };

        var response = await client.ChangeMarginTypeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/marginType", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("ISOLATED", seen.Param("marginType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeMarginTypeWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeMarginTypeRequest
        {
            Symbol = "BTCUSDT",
            MarginType = ChangeMarginTypeMarginType.Isolated,
            RecvWindow = 5000L,
        };

        var response = await client.ChangeMarginTypeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/marginType", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("ISOLATED", seen.Param("marginType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeMarginTypeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeMarginTypeRequest
        {
            Symbol = "BTCUSDT",
            MarginType = ChangeMarginTypeMarginType.Isolated,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeMarginTypeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangeMultiAssetsModeAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeMultiAssetsModeRequest
        {
            MultiAssetsMargin = "true",
        };

        var response = await client.ChangeMultiAssetsModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/multiAssetsMargin", seen.Path);
        Assert.Equal("true", seen.Param("multiAssetsMargin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeMultiAssetsModeWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangeMultiAssetsModeRequest
        {
            MultiAssetsMargin = "true",
            RecvWindow = 5000L,
        };

        var response = await client.ChangeMultiAssetsModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/multiAssetsMargin", seen.Path);
        Assert.Equal("true", seen.Param("multiAssetsMargin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangeMultiAssetsModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangeMultiAssetsModeRequest
        {
            MultiAssetsMargin = "true",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangeMultiAssetsModeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ChangePositionModeAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangePositionModeRequest
        {
            DualSidePosition = "true",
        };

        var response = await client.ChangePositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/positionSide/dual", seen.Path);
        Assert.Equal("true", seen.Param("dualSidePosition"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangePositionModeWithOptionalParametersAsync()
    {
        const string example = """""{"code":200,"msg":"success"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ChangePositionModeRequest
        {
            DualSidePosition = "true",
            RecvWindow = 5000L,
        };

        var response = await client.ChangePositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/positionSide/dual", seen.Path);
        Assert.Equal("true", seen.Param("dualSidePosition"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ChangePositionModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ChangePositionModeRequest
        {
            DualSidePosition = "true",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ChangePositionModeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CurrentAllAlgoOpenOrdersAsync()
    {
        const string example = """""[{"algoId":2148627,"clientAlgoId":"MRumok0dkhrP4kCm12AHaB","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","tpTriggerPrice":"0.000","tpPrice":"0.000","slTriggerPrice":"0.000","slPrice":"0.000","tpOrderType":"","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750514941540,"updateTime":1750514941540,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CurrentAllAlgoOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/openAlgoOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentAllAlgoOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"algoId":2148627,"clientAlgoId":"MRumok0dkhrP4kCm12AHaB","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","tpTriggerPrice":"0.000","tpPrice":"0.000","slTriggerPrice":"0.000","slPrice":"0.000","tpOrderType":"","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750514941540,"updateTime":1750514941540,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CurrentAllAlgoOpenOrdersRequest
        {
            AlgoType = "CONDITIONAL",
            Symbol = "BTCUSDT",
            AlgoId = 2148627L,
            RecvWindow = 5000L,
        };

        var response = await client.CurrentAllAlgoOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/openAlgoOrders", seen.Path);
        Assert.Equal("CONDITIONAL", seen.Param("algoType"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("2148627", seen.Param("algoId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentAllAlgoOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CurrentAllAlgoOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CurrentAllOpenOrdersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CurrentAllOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentAllOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CurrentAllOpenOrdersRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.CurrentAllOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/openOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CurrentAllOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CurrentAllOpenOrdersAsync());

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
        Assert.Equal("/fapi/v1/stock/contract", seen.Path);
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
        Assert.Equal("/fapi/v1/stock/contract", seen.Path);
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
    public async Task GetOrderModifyHistoryAsync()
    {
        const string example = """""[{"amendmentId":5363,"symbol":"BTCUSDT","pair":"BTCUSDT","orderId":20072994037,"clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","time":1629184560899,"amendment":{"price":{"before":"30004","after":"30003.2"},"origQty":{"before":"1","after":"1"},"count":3,"modifyId":123}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOrderModifyHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.GetOrderModifyHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/orderAmendment", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderModifyHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"amendmentId":5363,"symbol":"BTCUSDT","pair":"BTCUSDT","orderId":20072994037,"clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","time":1629184560899,"amendment":{"price":{"before":"30004","after":"30003.2"},"origQty":{"before":"1","after":"1"},"count":3,"modifyId":123}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOrderModifyHistoryRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 20072994037L,
            OrigClientOrderId = "LJ9R4QZDihCaS8UAOOLpgW",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.GetOrderModifyHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/orderAmendment", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("20072994037", seen.Param("orderId"));
        Assert.Equal("LJ9R4QZDihCaS8UAOOLpgW", seen.Param("origClientOrderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderModifyHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetOrderModifyHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOrderModifyHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetPositionMarginChangeHistoryAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","type":1,"deltaType":"USER_ADJUST","amount":"23.36332311","asset":"USDT","time":1578047897183,"positionSide":"BOTH"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPositionMarginChangeHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.GetPositionMarginChangeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/positionMargin/history", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPositionMarginChangeHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","type":1,"deltaType":"USER_ADJUST","amount":"23.36332311","asset":"USDT","time":1578047897183,"positionSide":"BOTH"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetPositionMarginChangeHistoryRequest
        {
            Symbol = "BTCUSDT",
            Type = "1",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.GetPositionMarginChangeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/positionMargin/history", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetPositionMarginChangeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetPositionMarginChangeHistoryRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetPositionMarginChangeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifyIsolatedPositionMarginAsync()
    {
        const string example = """""{"amount":100,"code":200,"msg":"Successfully modify position margin.","type":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyIsolatedPositionMarginRequest
        {
            Symbol = "BTCUSDT",
            Amount = 1.0m,
            Type = 1L,
        };

        var response = await client.ModifyIsolatedPositionMarginAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/positionMargin", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyIsolatedPositionMarginWithOptionalParametersAsync()
    {
        const string example = """""{"amount":100,"code":200,"msg":"Successfully modify position margin.","type":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyIsolatedPositionMarginRequest
        {
            Symbol = "BTCUSDT",
            Amount = 1.0m,
            Type = 1L,
            PositionSide = "BOTH",
            RecvWindow = 5000L,
        };

        var response = await client.ModifyIsolatedPositionMarginAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/positionMargin", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("1", seen.Param("type"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyIsolatedPositionMarginBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ModifyIsolatedPositionMarginRequest
        {
            Symbol = "BTCUSDT",
            Amount = 1.0m,
            Type = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ModifyIsolatedPositionMarginAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifyMultipleOrdersAsync()
    {
        const string example = """""[{"orderId":20072994037,"symbol":"BTCUSDT","pair":"BTCUSDT","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1629182711600,"code":-2022,"msg":"ReduceOnly Order is rejected."}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyMultipleOrdersRequest
        {
            BatchOrders = new() { },
        };

        var response = await client.ModifyMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/fapi/v1/batchOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyMultipleOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":20072994037,"symbol":"BTCUSDT","pair":"BTCUSDT","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1629182711600,"code":-2022,"msg":"ReduceOnly Order is rejected."}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyMultipleOrdersRequest
        {
            BatchOrders = new() { },
            RecvWindow = 5000L,
        };

        var response = await client.ModifyMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/fapi/v1/batchOrders", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyMultipleOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ModifyMultipleOrdersRequest
        {
            BatchOrders = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ModifyMultipleOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ModifyOrderAsync()
    {
        const string example = """""{"orderId":20072994037,"symbol":"BTCUSDT","pair":"BTCUSDT","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1629182711600}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 30005m,
        };

        var response = await client.ModifyOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("30005", seen.Param("price"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":20072994037,"symbol":"BTCUSDT","pair":"BTCUSDT","status":"NEW","clientOrderId":"LJ9R4QZDihCaS8UAOOLpgW","modifyId":1,"price":"30005","origQty":"1","executedQty":"0","cumQty":"0","timeInForce":"GTC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"BUY","positionSide":"LONG","stopPrice":"0","workingType":"CONTRACT_PRICE","priceProtect":false,"origType":"LIMIT","priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0,"updateTime":1629182711600}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 30005m,
            OrderId = 20072994037L,
            OrigClientOrderId = "LJ9R4QZDihCaS8UAOOLpgW",
            PriceMatch = ModifyOrderPriceMatch.Opponent,
            ModifyId = 1L,
            ReduceOnly = ModifyOrderReduceOnly.True,
            RecvWindow = 5000L,
        };

        var response = await client.ModifyOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("30005", seen.Param("price"));
        Assert.Equal("20072994037", seen.Param("orderId"));
        Assert.Equal("LJ9R4QZDihCaS8UAOOLpgW", seen.Param("origClientOrderId"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("1", seen.Param("modifyId"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ModifyOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ModifyOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = ModifyOrderSide.Buy,
            Quantity = 1.0m,
            Price = 30005m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ModifyOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewAlgoOrderAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"activatePrice":"","callbackRate":"","createTime":1750485492076,"updateTime":1750485492076,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BNBUSDT",
            Side = NewAlgoOrderSide.Buy,
            Type = NewAlgoOrderType.Limit,
        };

        var response = await client.NewAlgoOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/algoOrder", seen.Path);
        Assert.Equal("CONDITIONAL", seen.Param("algoType"));
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewAlgoOrderWithOptionalParametersAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"NEW","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"activatePrice":"","callbackRate":"","createTime":1750485492076,"updateTime":1750485492076,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BNBUSDT",
            Side = NewAlgoOrderSide.Buy,
            Type = NewAlgoOrderType.Limit,
            PositionSide = "BOTH",
            TimeInForce = NewAlgoOrderTimeInForce.Gtc,
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

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/algoOrder", seen.Path);
        Assert.Equal("CONDITIONAL", seen.Param("algoType"));
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1.0", seen.Param("triggerPrice"));
        Assert.Equal("MARK_PRICE", seen.Param("workingType"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("true", seen.Param("closePosition"));
        Assert.Equal("true", seen.Param("priceProtect"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("1.0", seen.Param("activatePrice"));
        Assert.Equal("1", seen.Param("callbackRate"));
        Assert.Equal("1", seen.Param("clientAlgoId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("1770736694138", seen.Param("goodTillDate"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewAlgoOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewAlgoOrderRequest
        {
            AlgoType = NewAlgoOrderAlgoType.Conditional,
            Symbol = "BNBUSDT",
            Side = NewAlgoOrderSide.Buy,
            Type = NewAlgoOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewAlgoOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewOrderAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"SELL","positionSide":"SHORT","status":"NEW","stopPrice":"0","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTD","type":"LIMIT","origType":"LIMIT","updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
        };

        var response = await client.NewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
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
    public async Task NewOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"SELL","positionSide":"SHORT","status":"NEW","stopPrice":"0","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTD","type":"LIMIT","origType":"LIMIT","updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
            PositionSide = "BOTH",
            TimeInForce = NewOrderTimeInForce.Gtc,
            ReduceOnly = NewOrderReduceOnly.True,
            Quantity = 1.0m,
            Price = 1.0m,
            NewClientOrderId = "1",
            NewOrderRespType = NewOrderNewOrderRespType.Ack,
            PriceMatch = NewOrderPriceMatch.Opponent,
            SelfTradePreventionMode = NewOrderSelfTradePreventionMode.ExpireTaker,
            GoodTillDate = 1770736694138L,
            RecvWindow = 5000L,
        };

        var response = await client.NewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("1.0", seen.Param("quantity"));
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
    public async Task NewOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = NewOrderSide.Buy,
            Type = NewOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PlaceMultipleOrdersAsync()
    {
        const string example = """""[{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"SELL","positionSide":"SHORT","status":"NEW","stopPrice":"0","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","type":"TRAILING_STOP_MARKET","origType":"TRAILING_STOP_MARKET","updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000,"code":-2022,"msg":"ReduceOnly Order is rejected."}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceMultipleOrdersRequest
        {
            BatchOrders = new() { },
        };

        var response = await client.PlaceMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/batchOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceMultipleOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"clientOrderId":"testOrder","cumQty":"0","executedQty":"0","orderId":22542179,"origQty":"10","price":"0","reduceOnly":false,"side":"SELL","positionSide":"SHORT","status":"NEW","stopPrice":"0","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTC","type":"TRAILING_STOP_MARKET","origType":"TRAILING_STOP_MARKET","updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000,"code":-2022,"msg":"ReduceOnly Order is rejected."}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceMultipleOrdersRequest
        {
            BatchOrders = new() { },
            RecvWindow = 5000L,
        };

        var response = await client.PlaceMultipleOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/batchOrders", seen.Path);
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
            BatchOrders = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PlaceMultipleOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PositionAdlQuantileEstimationAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","adlQuantile":{}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.PositionAdlQuantileEstimationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/adlQuantile", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PositionAdlQuantileEstimationWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"ETHUSDT","adlQuantile":{}}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PositionAdlQuantileEstimationRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.PositionAdlQuantileEstimationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/adlQuantile", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PositionAdlQuantileEstimationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PositionAdlQuantileEstimationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PositionInformationV2Async()
    {
        const string example = """""[{"entryPrice":"0.00000","breakEvenPrice":"0.0","marginType":"isolated","isAutoAddMargin":"false","isolatedMargin":"0.00000000","leverage":"10","liquidationPrice":"0","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","isolatedWallet":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","positionSide":"BOTH","updateTime":1625474304765}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.PositionInformationV2Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/positionRisk", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PositionInformationV2WithOptionalParametersAsync()
    {
        const string example = """""[{"entryPrice":"0.00000","breakEvenPrice":"0.0","marginType":"isolated","isAutoAddMargin":"false","isolatedMargin":"0.00000000","leverage":"10","liquidationPrice":"0","markPrice":"6679.50671178","maxNotionalValue":"20000000","positionAmt":"0.000","notional":"0","isolatedWallet":"0","symbol":"BTCUSDT","unRealizedProfit":"0.00000000","positionSide":"BOTH","updateTime":1625474304765}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PositionInformationV2Request
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.PositionInformationV2Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v2/positionRisk", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PositionInformationV2BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PositionInformationV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PositionInformationV3Async()
    {
        const string example = """""[{"symbol":"ADAUSDT","positionSide":"BOTH","positionAmt":"30","entryPrice":"0.385","breakEvenPrice":"0.385077","markPrice":"0.41047590","unRealizedProfit":"0.76427700","liquidationPrice":"0","isolatedMargin":"0","notional":"12.31427700","marginAsset":"USDT","isolatedWallet":"0","initialMargin":"0.61571385","maintMargin":"0.08004280","positionInitialMargin":"0.61571385","openOrderInitialMargin":"0","adl":2,"bidNotional":"0","askNotional":"0","updateTime":1720736417660}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.PositionInformationV3Async();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v3/positionRisk", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PositionInformationV3WithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"ADAUSDT","positionSide":"BOTH","positionAmt":"30","entryPrice":"0.385","breakEvenPrice":"0.385077","markPrice":"0.41047590","unRealizedProfit":"0.76427700","liquidationPrice":"0","isolatedMargin":"0","notional":"12.31427700","marginAsset":"USDT","isolatedWallet":"0","initialMargin":"0.61571385","maintMargin":"0.08004280","positionInitialMargin":"0.61571385","openOrderInitialMargin":"0","adl":2,"bidNotional":"0","askNotional":"0","updateTime":1720736417660}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PositionInformationV3Request
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.PositionInformationV3Async(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v3/positionRisk", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PositionInformationV3BadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PositionInformationV3Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAlgoOrderAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","actualType":"LIMIT","actualQty":"0.01","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","tpOrderType":"","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryAlgoOrderAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/algoOrder", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAlgoOrderWithOptionalParametersAsync()
    {
        const string example = """""{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","actualType":"LIMIT","actualQty":"0.01","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","tpOrderType":"","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAlgoOrderRequest
        {
            AlgoId = 1L,
            ClientAlgoId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryAlgoOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/algoOrder", seen.Path);
        Assert.Equal("1", seen.Param("algoId"));
        Assert.Equal("1", seen.Param("clientAlgoId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAlgoOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAlgoOrderAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryAllAlgoOrdersAsync()
    {
        const string example = """""[{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","tpTriggerPrice":"0.000","tpPrice":"0.000","slTriggerPrice":"0.000","slPrice":"0.000","tpOrderType":"","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllAlgoOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryAllAlgoOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/allAlgoOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllAlgoOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"algoId":2146760,"clientAlgoId":"6B2I9XVcJpCjqPAJ4YoFX7","algoType":"CONDITIONAL","orderType":"TAKE_PROFIT","symbol":"BNBUSDT","side":"SELL","positionSide":"BOTH","timeInForce":"GTC","quantity":"0.01","algoStatus":"CANCELED","actualOrderId":"","actualPrice":"0.00000","triggerPrice":"750.000","price":"750.000","icebergQuantity":"null","tpTriggerPrice":"0.000","tpPrice":"0.000","slTriggerPrice":"0.000","slPrice":"0.000","tpOrderType":"","selfTradePreventionMode":"EXPIRE_MAKER","workingType":"CONTRACT_PRICE","priceMatch":"NONE","closePosition":false,"priceProtect":false,"reduceOnly":false,"createTime":1750485492076,"updateTime":1750514545091,"triggerTime":0,"goodTillDate":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryAllAlgoOrdersRequest
        {
            Symbol = "BTCUSDT",
            AlgoId = 2146760L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryAllAlgoOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/allAlgoOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("2146760", seen.Param("algoId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryAllAlgoOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryAllAlgoOrdersRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryAllAlgoOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentOpenOrderAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","status":"NEW","positionSide":"SHORT","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryCurrentOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/openOrder", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentOpenOrderWithOptionalParametersAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1917641,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","status":"NEW","positionSide":"SHORT","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentOpenOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1917641L,
            OrigClientOrderId = "abc",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentOpenOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/openOrder", seen.Path);
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
    public async Task QueryCurrentOpenOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryCurrentOpenOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentOpenOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryOrderAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1573346959,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryOrderWithOptionalParametersAsync()
    {
        const string example = """""{"avgPrice":"0.00000","clientOrderId":"abc","cumQuote":"0","executedQty":"0","orderId":1573346959,"origQty":"0.40","origType":"TRAILING_STOP_MARKET","price":"0","reduceOnly":false,"side":"BUY","positionSide":"SHORT","status":"NEW","stopPrice":"9300","closePosition":false,"symbol":"BTCUSDT","time":1579276756075,"timeInForce":"GTC","type":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1579276756075,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 1917641L,
            OrigClientOrderId = "abc",
            RecvWindow = 5000L,
        };

        var response = await client.QueryOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/order", seen.Path);
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
    public async Task QueryOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryOrderRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task TestOrderAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","cumQuote":"0","executedQty":"0","orderId":22542179,"avgPrice":"0.00000","origQty":"10","price":"0","reduceOnly":false,"side":"SELL","positionSide":"SHORT","status":"NEW","stopPrice":"0","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTD","type":"TRAILING_STOP_MARKET","origType":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TestOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = TestOrderSide.Buy,
            Type = TestOrderType.Limit,
        };

        var response = await client.TestOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/order/test", seen.Path);
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
    public async Task TestOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"testOrder","cumQty":"0","cumQuote":"0","executedQty":"0","orderId":22542179,"avgPrice":"0.00000","origQty":"10","price":"0","reduceOnly":false,"side":"SELL","positionSide":"SHORT","status":"NEW","stopPrice":"0","closePosition":false,"symbol":"BTCUSDT","timeInForce":"GTD","type":"TRAILING_STOP_MARKET","origType":"TRAILING_STOP_MARKET","activatePrice":"9020","priceRate":"0.3","updateTime":1566818724722,"workingType":"CONTRACT_PRICE","priceProtect":false,"priceMatch":"NONE","selfTradePreventionMode":"EXPIRE_MAKER","goodTillDate":1693207680000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new TestOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = TestOrderSide.Buy,
            Type = TestOrderType.Limit,
            PositionSide = TestOrderPositionSide.Both,
            ReduceOnly = TestOrderReduceOnly.True,
            Quantity = 1.0m,
            Price = 1.0m,
            NewClientOrderId = "1",
            StopPrice = 1.0m,
            ClosePosition = TestOrderClosePosition.True,
            ActivationPrice = 1.0m,
            CallbackRate = 1m,
            TimeInForce = TestOrderTimeInForce.Gtc,
            WorkingType = TestOrderWorkingType.MarkPrice,
            PriceProtect = TestOrderPriceProtect.True,
            NewOrderRespType = TestOrderNewOrderRespType.Ack,
            PriceMatch = TestOrderPriceMatch.Opponent,
            SelfTradePreventionMode = TestOrderSelfTradePreventionMode.None,
            GoodTillDate = 1770736694138L,
            RecvWindow = 5000L,
        };

        var response = await client.TestOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/fapi/v1/order/test", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("BOTH", seen.Param("positionSide"));
        Assert.Equal("true", seen.Param("reduceOnly"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1", seen.Param("newClientOrderId"));
        Assert.Equal("1.0", seen.Param("stopPrice"));
        Assert.Equal("true", seen.Param("closePosition"));
        Assert.Equal("1.0", seen.Param("activationPrice"));
        Assert.Equal("1", seen.Param("callbackRate"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("MARK_PRICE", seen.Param("workingType"));
        Assert.Equal("true", seen.Param("priceProtect"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("OPPONENT", seen.Param("priceMatch"));
        Assert.Equal("NONE", seen.Param("selfTradePreventionMode"));
        Assert.Equal("1770736694138", seen.Param("goodTillDate"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task TestOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new TestOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = TestOrderSide.Buy,
            Type = TestOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.TestOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UsersForceOrdersAsync()
    {
        const string example = """""[{"orderId":6071832819,"symbol":"BTCUSDT","pair":"BTCUSDT","status":"FILLED","clientOrderId":"autoclose-1596107620040000020","price":"10871.09","avgPrice":"10913.21000","origQty":"0.001","executedQty":"0.001","cumQuote":"10.91321","cumBase":"0.001","timeInForce":"IOC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"SELL","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","origType":"LIMIT","time":1596107620044,"updateTime":1596107620087}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.UsersForceOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/forceOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UsersForceOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"orderId":6071832819,"symbol":"BTCUSDT","pair":"BTCUSDT","status":"FILLED","clientOrderId":"autoclose-1596107620040000020","price":"10871.09","avgPrice":"10913.21000","origQty":"0.001","executedQty":"0.001","cumQuote":"10.91321","cumBase":"0.001","timeInForce":"IOC","type":"LIMIT","reduceOnly":false,"closePosition":false,"side":"SELL","positionSide":"BOTH","stopPrice":"0","workingType":"CONTRACT_PRICE","origType":"LIMIT","time":1596107620044,"updateTime":1596107620087}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UsersForceOrdersRequest
        {
            Symbol = "BTCUSDT",
            AutoCloseType = UsersForceOrdersAutoCloseType.Liquidation,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.UsersForceOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/fapi/v1/forceOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("LIQUIDATION", seen.Param("autoCloseType"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("50", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UsersForceOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UsersForceOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
