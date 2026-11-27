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

namespace Binance.DerivativesTradingOptions.Tests.RestApi.MarketMakerBlockTrade;

[Trait("Category", "Native")]
public class MarketMakerBlockTradeApiTests
{
    private static DerivativesTradingOptionsRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AcceptBlockTradeOrderAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"7d046e6e-a429-4335-ab9d-6a681febcde5","expireTime":1730172115801,"liquidity":"MAKER","status":"ACCEPTED","createTime":1730170315803,"legs":[{"symbol":"BNB-241101-700-C","side":"SELL","quantity":"1.2","price":"2.8"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AcceptBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "7d046e6e-a429-4335-ab9d-6a681febcde5",
        };

        var response = await client.AcceptBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/block/order/execute", seen.Path);
        Assert.Equal("7d046e6e-a429-4335-ab9d-6a681febcde5", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcceptBlockTradeOrderWithOptionalParametersAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"7d046e6e-a429-4335-ab9d-6a681febcde5","expireTime":1730172115801,"liquidity":"MAKER","status":"ACCEPTED","createTime":1730170315803,"legs":[{"symbol":"BNB-241101-700-C","side":"SELL","quantity":"1.2","price":"2.8"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AcceptBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "7d046e6e-a429-4335-ab9d-6a681febcde5",
            RecvWindow = 5000L,
        };

        var response = await client.AcceptBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/block/order/execute", seen.Path);
        Assert.Equal("7d046e6e-a429-4335-ab9d-6a681febcde5", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcceptBlockTradeOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AcceptBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "7d046e6e-a429-4335-ab9d-6a681febcde5",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AcceptBlockTradeOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountBlockTradeListAsync()
    {
        const string example = """""[{"parentOrderId":"4675011431944499201","crossType":"USER_BLOCK","legs":[{"createTime":1730170445600,"updateTime":1730170445600,"symbol":"BNB-241101-700-C","orderId":"4675011431944499203","orderPrice":2.8,"orderQuantity":1.2,"orderStatus":"FILLED","executedQty":1.2,"executedAmount":3.36,"fee":0.336,"orderType":"PREV_QUOTED","orderSide":"BUY","id":"1125899906900937837","tradeId":1,"tradePrice":2.8,"tradeQty":1.2,"tradeTime":1730170445600,"liquidity":"TAKER","commission":0.336}],"blockTradeSettlementKey":"7d085e6e-a229-2335-ab9d-6a581febcd25"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountBlockTradeListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/block/user-trades", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountBlockTradeListWithOptionalParametersAsync()
    {
        const string example = """""[{"parentOrderId":"4675011431944499201","crossType":"USER_BLOCK","legs":[{"createTime":1730170445600,"updateTime":1730170445600,"symbol":"BNB-241101-700-C","orderId":"4675011431944499203","orderPrice":2.8,"orderQuantity":1.2,"orderStatus":"FILLED","executedQty":1.2,"executedAmount":3.36,"fee":0.336,"orderType":"PREV_QUOTED","orderSide":"BUY","id":"1125899906900937837","tradeId":1,"tradePrice":2.8,"tradeQty":1.2,"tradeTime":1730170445600,"liquidity":"TAKER","commission":0.336}],"blockTradeSettlementKey":"7d085e6e-a229-2335-ab9d-6a581febcd25"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountBlockTradeListRequest
        {
            EndTime = 1641782889000L,
            StartTime = 1623319461670L,
            Underlying = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.AccountBlockTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/block/user-trades", seen.Path);
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountBlockTradeListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountBlockTradeListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelBlockTradeOrderAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new CancelBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "7d046e6e-a429-4335-ab9d-6a681febcde5",
        };

        var response = await client.CancelBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/block/order/create", seen.Path);
        Assert.Equal("7d046e6e-a429-4335-ab9d-6a681febcde5", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task CancelBlockTradeOrderWithOptionalParametersAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new CancelBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "7d046e6e-a429-4335-ab9d-6a681febcde5",
            RecvWindow = 5000L,
        };

        var response = await client.CancelBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/eapi/v1/block/order/create", seen.Path);
        Assert.Equal("7d046e6e-a429-4335-ab9d-6a681febcde5", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task CancelBlockTradeOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "7d046e6e-a429-4335-ab9d-6a681febcde5",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelBlockTradeOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExtendBlockTradeOrderAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"3668822b8-1baa-6a2f-adb8-d3de6289b361","expireTime":1730172007000,"liquidity":"TAKER","status":"RECEIVED","createTime":1730170088111,"legs":[{"symbol":"BNB-241101-700-C","side":"BUY","quantity":"1.2","price":"2.8"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExtendBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "3668822b8-1baa-6a2f-adb8-d3de6289b361",
        };

        var response = await client.ExtendBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/eapi/v1/block/order/create", seen.Path);
        Assert.Equal("3668822b8-1baa-6a2f-adb8-d3de6289b361", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExtendBlockTradeOrderWithOptionalParametersAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"3668822b8-1baa-6a2f-adb8-d3de6289b361","expireTime":1730172007000,"liquidity":"TAKER","status":"RECEIVED","createTime":1730170088111,"legs":[{"symbol":"BNB-241101-700-C","side":"BUY","quantity":"1.2","price":"2.8"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExtendBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "3668822b8-1baa-6a2f-adb8-d3de6289b361",
            RecvWindow = 5000L,
        };

        var response = await client.ExtendBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/eapi/v1/block/order/create", seen.Path);
        Assert.Equal("3668822b8-1baa-6a2f-adb8-d3de6289b361", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExtendBlockTradeOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new ExtendBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "3668822b8-1baa-6a2f-adb8-d3de6289b361",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ExtendBlockTradeOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NewBlockTradeOrderAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"3668822b8-1baa-6a2f-adb8-d3de6289b361","expireTime":1730171888109,"liquidity":"TAKER","status":"RECEIVED","legs":[{"symbol":"BNB-241101-700-C","side":"BUY","quantity":"1.2","price":"2.8"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewBlockTradeOrderRequest
        {
            Liquidity = NewBlockTradeOrderLiquidity.Maker,
            Legs = new() { },
        };

        var response = await client.NewBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/block/order/create", seen.Path);
        Assert.Equal("MAKER", seen.Param("liquidity"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewBlockTradeOrderWithOptionalParametersAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"3668822b8-1baa-6a2f-adb8-d3de6289b361","expireTime":1730171888109,"liquidity":"TAKER","status":"RECEIVED","legs":[{"symbol":"BNB-241101-700-C","side":"BUY","quantity":"1.2","price":"2.8"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NewBlockTradeOrderRequest
        {
            Liquidity = NewBlockTradeOrderLiquidity.Maker,
            Legs = new() { },
            RecvWindow = 5000L,
        };

        var response = await client.NewBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/eapi/v1/block/order/create", seen.Path);
        Assert.Equal("MAKER", seen.Param("liquidity"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NewBlockTradeOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new NewBlockTradeOrderRequest
        {
            Liquidity = NewBlockTradeOrderLiquidity.Maker,
            Legs = new() { },
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NewBlockTradeOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryBlockTradeDetailsAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"12b96c28-ba05-8906-c89t-703215cfb2e6","expireTime":1730171860460,"liquidity":"MAKER","status":"RECEIVED","createTime":1730170060462,"legs":[{"symbol":"BNB-241101-700-C","side":"SELL","quantity":"1.66","price":"20"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryBlockTradeDetailsRequest
        {
            BlockOrderMatchingKey = "12b96c28-ba05-8906-c89t-703215cfb2e6",
        };

        var response = await client.QueryBlockTradeDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/block/order/execute", seen.Path);
        Assert.Equal("12b96c28-ba05-8906-c89t-703215cfb2e6", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryBlockTradeDetailsWithOptionalParametersAsync()
    {
        const string example = """""{"blockTradeSettlementKey":"12b96c28-ba05-8906-c89t-703215cfb2e6","expireTime":1730171860460,"liquidity":"MAKER","status":"RECEIVED","createTime":1730170060462,"legs":[{"symbol":"BNB-241101-700-C","side":"SELL","quantity":"1.66","price":"20"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryBlockTradeDetailsRequest
        {
            BlockOrderMatchingKey = "12b96c28-ba05-8906-c89t-703215cfb2e6",
            RecvWindow = 5000L,
        };

        var response = await client.QueryBlockTradeDetailsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/block/order/execute", seen.Path);
        Assert.Equal("12b96c28-ba05-8906-c89t-703215cfb2e6", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryBlockTradeDetailsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryBlockTradeDetailsRequest
        {
            BlockOrderMatchingKey = "12b96c28-ba05-8906-c89t-703215cfb2e6",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryBlockTradeDetailsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryBlockTradeOrderAsync()
    {
        const string example = """""[{"blockTradeSettlementKey":"7d046e6e-a429-4335-ab9d-6a681febcde5","expireTime":1730172115801,"liquidity":"TAKER","status":"RECEIVED","createTime":1730170315803,"legs":[{"symbol":"BNB-241101-700-C","side":"BUY","quantity":"1.2","price":"2.8"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryBlockTradeOrderAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/block/order/orders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryBlockTradeOrderWithOptionalParametersAsync()
    {
        const string example = """""[{"blockTradeSettlementKey":"7d046e6e-a429-4335-ab9d-6a681febcde5","expireTime":1730172115801,"liquidity":"TAKER","status":"RECEIVED","createTime":1730170315803,"legs":[{"symbol":"BNB-241101-700-C","side":"BUY","quantity":"1.2","price":"2.8"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryBlockTradeOrderRequest
        {
            BlockOrderMatchingKey = "7d046e6e-a429-4335-ab9d-6a681febcde5",
            EndTime = 1641782889000L,
            StartTime = 1623319461670L,
            Underlying = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryBlockTradeOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/eapi/v1/block/order/orders", seen.Path);
        Assert.Equal("7d046e6e-a429-4335-ab9d-6a681febcde5", seen.Param("blockOrderMatchingKey"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("BTCUSDT", seen.Param("underlying"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryBlockTradeOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryBlockTradeOrderAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
