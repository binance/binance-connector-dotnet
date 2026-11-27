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

namespace Binance.Spot.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static SpotRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountCommissionAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","standardCommission":{"maker":"0.00000010","taker":"0.00000020","buyer":"0.00000030","seller":"0.00000040"},"specialCommission":{"maker":"0.01000000","taker":"0.02000000","buyer":"0.03000000","seller":"0.04000000"},"taxCommission":{"maker":"0.00000112","taker":"0.00000114","buyer":"0.00000118","seller":"0.00000116"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.75000000"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountCommissionRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.AccountCommissionAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/account/commission", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountCommissionBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AccountCommissionRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountCommissionAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AllOrderListAsync()
    {
        const string example = """""[{"orderListId":29,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"amEEAXryFzFwYF1FeRpUoZ","transactionTime":1565245913483,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"oD7aesZqjEGlZrbtRpy5zB"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AllOrderListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/allOrderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AllOrderListWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":29,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"amEEAXryFzFwYF1FeRpUoZ","transactionTime":1565245913483,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"oD7aesZqjEGlZrbtRpy5zB"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AllOrderListRequest
        {
            FromId = 1L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.AllOrderListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/allOrderList", seen.Path);
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1735693200000", seen.Param("startTime"));
        Assert.Equal("1735693200000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AllOrderListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AllOrderListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AllOrdersAsync()
    {
        const string example = """""[{"symbol":"LTCBTC","orderId":1,"orderListId":-1,"clientOrderId":"myOrder1","price":"0.1","origQty":"1.0","executedQty":"0.0","cummulativeQuoteQty":"0.0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","stopPrice":"0.00000000","icebergQty":"0.00000000","time":1499827319559,"updateTime":1499827319559,"isWorking":true,"origQuoteOrderQty":"0.000000","workingTime":1499827319559,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AllOrdersRequest
        {
            Symbol = "LTCBTC",
        };

        var response = await client.AllOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/allOrders", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AllOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"LTCBTC","orderId":1,"orderListId":-1,"clientOrderId":"myOrder1","price":"0.1","origQty":"1.0","executedQty":"0.0","cummulativeQuoteQty":"0.0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","stopPrice":"0.00000000","icebergQty":"0.00000000","time":1499827319559,"updateTime":1499827319559,"isWorking":true,"origQuoteOrderQty":"0.000000","workingTime":1499827319559,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AllOrdersRequest
        {
            Symbol = "LTCBTC",
            OrderId = 1L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.AllOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/allOrders", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1735693200000", seen.Param("startTime"));
        Assert.Equal("1735693200000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("limit"));
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
        var request = new AllOrdersRequest
        {
            Symbol = "LTCBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AllOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetAccountAsync()
    {
        const string example = """""{"makerCommission":15,"takerCommission":15,"buyerCommission":0,"sellerCommission":0,"commissionRates":{"maker":"0.00150000","taker":"0.00150000","buyer":"0.00000000","seller":"0.00000000"},"canTrade":true,"canWithdraw":true,"canDeposit":true,"brokered":false,"requireSelfTradePrevention":false,"preventSor":false,"updateTime":123456789,"accountType":"SPOT","balances":[{"asset":"BTC","free":"4723846.89208129","locked":"0.00000000"},{"asset":"LTC","free":"4763368.68006011","locked":"0.00000000"}],"permissions":["SPOT"],"uid":354937868}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAccountWithOptionalParametersAsync()
    {
        const string example = """""{"makerCommission":15,"takerCommission":15,"buyerCommission":0,"sellerCommission":0,"commissionRates":{"maker":"0.00150000","taker":"0.00150000","buyer":"0.00000000","seller":"0.00000000"},"canTrade":true,"canWithdraw":true,"canDeposit":true,"brokered":false,"requireSelfTradePrevention":false,"preventSor":false,"updateTime":123456789,"accountType":"SPOT","balances":[{"asset":"BTC","free":"4723846.89208129","locked":"0.00000000"},{"asset":"LTC","free":"4763368.68006011","locked":"0.00000000"}],"permissions":["SPOT"],"uid":354937868}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetAccountRequest
        {
            OmitZeroBalances = false,
            RecvWindow = 5000m,
        };

        var response = await client.GetAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/account", seen.Path);
        Assert.Equal("false", seen.Param("omitZeroBalances"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOpenOrdersAsync()
    {
        const string example = """""[{"symbol":"LTCBTC","orderId":1,"orderListId":-1,"clientOrderId":"myOrder1","price":"0.1","origQty":"1.0","executedQty":"0.0","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","stopPrice":"0.00000000","icebergQty":"0.00000000","time":1499827319559,"updateTime":1499827319559,"isWorking":true,"workingTime":1499827319559,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"LTCBTC","orderId":1,"orderListId":-1,"clientOrderId":"myOrder1","price":"0.1","origQty":"1.0","executedQty":"0.0","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","stopPrice":"0.00000000","icebergQty":"0.00000000","time":1499827319559,"updateTime":1499827319559,"isWorking":true,"workingTime":1499827319559,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOpenOrdersRequest
        {
            Symbol = "LTCBTC",
            RecvWindow = 5000m,
        };

        var response = await client.GetOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/openOrders", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOrderAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":1,"orderListId":-1,"clientOrderId":"myOrder1","price":"0.1","origQty":"1.0","executedQty":"0.0","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","stopPrice":"0.00000000","icebergQty":"0.00000000","time":1499827319559,"updateTime":1499827319559,"isWorking":true,"workingTime":1499827319559,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOrderRequest
        {
            Symbol = "LTCBTC",
        };

        var response = await client.GetOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/order", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":1,"orderListId":-1,"clientOrderId":"myOrder1","price":"0.1","origQty":"1.0","executedQty":"0.0","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"0.0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","stopPrice":"0.00000000","icebergQty":"0.00000000","time":1499827319559,"updateTime":1499827319559,"isWorking":true,"workingTime":1499827319559,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOrderRequest
        {
            Symbol = "LTCBTC",
            OrderId = 1L,
            OrigClientOrderId = "myOrder1",
            RecvWindow = 5000m,
        };

        var response = await client.GetOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/order", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("myOrder1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetOrderRequest
        {
            Symbol = "LTCBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOrderListAsync()
    {
        const string example = """""{"orderListId":27,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"h2USkA5YQpaXHPIrkd96xE","transactionTime":1565245656253,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"qD1gy3kc3Gx0rihm9Y3xwS"},{"symbol":"LTCBTC","orderId":5,"clientOrderId":"ARzZ9I00CPM8i3NhmU9Ega"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetOrderListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/orderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderListWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":27,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"h2USkA5YQpaXHPIrkd96xE","transactionTime":1565245656253,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"qD1gy3kc3Gx0rihm9Y3xwS"},{"symbol":"LTCBTC","orderId":5,"clientOrderId":"ARzZ9I00CPM8i3NhmU9Ega"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOrderListRequest
        {
            OrderListId = 27L,
            OrigClientOrderId = "1",
            RecvWindow = 5000m,
        };

        var response = await client.GetOrderListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/orderList", seen.Path);
        Assert.Equal("27", seen.Param("orderListId"));
        Assert.Equal("1", seen.Param("origClientOrderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOrderListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyAllocationsAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","allocationId":0,"allocationType":"SOR","orderId":1,"orderListId":-1,"price":"1.00000000","qty":"5.00000000","quoteQty":"5.00000000","commission":"0.00000000","commissionAsset":"BTC","time":1687506878118,"isBuyer":true,"isMaker":false,"isAllocator":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyAllocationsRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.MyAllocationsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myAllocations", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyAllocationsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","allocationId":0,"allocationType":"SOR","orderId":1,"orderListId":-1,"price":"1.00000000","qty":"5.00000000","quoteQty":"5.00000000","commission":"0.00000000","commissionAsset":"BTC","time":1687506878118,"isBuyer":true,"isMaker":false,"isAllocator":false}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyAllocationsRequest
        {
            Symbol = "BTCUSDT",
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            FromAllocationId = 0L,
            Limit = 1L,
            OrderId = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.MyAllocationsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myAllocations", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1735693200000", seen.Param("startTime"));
        Assert.Equal("1735693200000", seen.Param("endTime"));
        Assert.Equal("0", seen.Param("fromAllocationId"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyAllocationsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MyAllocationsRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MyAllocationsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyFiltersAsync()
    {
        const string example = """""{"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbolFilters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"assetFilters":[{"filterType":"MAX_ASSET","qtyExponent":8,"limit":"100.00000000","asset":"BNB"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":321}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyFiltersRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.MyFiltersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myFilters", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyFiltersWithOptionalParametersAsync()
    {
        const string example = """""{"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbolFilters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"assetFilters":[{"filterType":"MAX_ASSET","qtyExponent":8,"limit":"100.00000000","asset":"BNB"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":321}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyFiltersRequest
        {
            Symbol = "BNBUSDT",
            RecvWindow = 5000m,
        };

        var response = await client.MyFiltersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myFilters", seen.Path);
        Assert.Equal("BNBUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyFiltersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MyFiltersRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MyFiltersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyPreventedMatchesAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyPreventedMatchesRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.MyPreventedMatchesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myPreventedMatches", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyPreventedMatchesWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyPreventedMatchesRequest
        {
            Symbol = "BTCUSDT",
            PreventedMatchId = 1L,
            OrderId = 1L,
            FromPreventedMatchId = 1L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.MyPreventedMatchesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myPreventedMatches", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("preventedMatchId"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("fromPreventedMatchId"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyPreventedMatchesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MyPreventedMatchesRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MyPreventedMatchesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyTradesAsync()
    {
        const string example = """""[{"symbol":"BNBBTC","id":28457,"orderId":100234,"orderListId":-1,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.000012","commission":"10.10000000","commissionAsset":"BNB","time":1499865549590,"isBuyer":true,"isMaker":false,"isBestMatch":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyTradesRequest
        {
            Symbol = "BNBBTC",
        };

        var response = await client.MyTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myTrades", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyTradesWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BNBBTC","id":28457,"orderId":100234,"orderListId":-1,"price":"4.00000100","qty":"12.00000000","quoteQty":"48.000012","commission":"10.10000000","commissionAsset":"BNB","time":1499865549590,"isBuyer":true,"isMaker":false,"isBestMatch":true}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MyTradesRequest
        {
            Symbol = "BNBBTC",
            OrderId = 100234L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            FromId = 1L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.MyTradesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/myTrades", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("100234", seen.Param("orderId"));
        Assert.Equal("1735693200000", seen.Param("startTime"));
        Assert.Equal("1735693200000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MyTradesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MyTradesRequest
        {
            Symbol = "BNBBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MyTradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenOrderListAsync()
    {
        const string example = """""[{"orderListId":31,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"wuB13fmulKj3YjdqWEcsnp","transactionTime":1565246080644,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"r3EH2N76dHfLoSZWIUw1bT"},{"symbol":"LTCBTC","orderId":5,"clientOrderId":"Cv1SnyPD3qhqpbjpYEHbd2"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OpenOrderListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/openOrderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OpenOrderListWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":31,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"wuB13fmulKj3YjdqWEcsnp","transactionTime":1565246080644,"symbol":"LTCBTC","orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"r3EH2N76dHfLoSZWIUw1bT"},{"symbol":"LTCBTC","orderId":5,"clientOrderId":"Cv1SnyPD3qhqpbjpYEHbd2"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OpenOrderListRequest
        {
            RecvWindow = 5000m,
        };

        var response = await client.OpenOrderListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/openOrderList", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OpenOrderListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OpenOrderListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderAmendmentsAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","orderId":9,"executionId":22,"origClientOrderId":"W0fJ9fiLKHOJutovPK3oJp","newClientOrderId":"UQ1Np3bmQ71jJzsSDW9Vpi","origQty":"5.00000000","newQty":"4.00000000","time":1741669661670}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderAmendmentsRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 9L,
        };

        var response = await client.OrderAmendmentsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/order/amendments", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("9", seen.Param("orderId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderAmendmentsWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","orderId":9,"executionId":22,"origClientOrderId":"W0fJ9fiLKHOJutovPK3oJp","newClientOrderId":"UQ1Np3bmQ71jJzsSDW9Vpi","origQty":"5.00000000","newQty":"4.00000000","time":1741669661670}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderAmendmentsRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 9L,
            FromExecutionId = 22L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.OrderAmendmentsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/order/amendments", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("9", seen.Param("orderId"));
        Assert.Equal("22", seen.Param("fromExecutionId"));
        Assert.Equal("1", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderAmendmentsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new OrderAmendmentsRequest
        {
            Symbol = "BTCUSDT",
            OrderId = 9L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderAmendmentsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task RateLimitOrderAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.RateLimitOrderAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/rateLimit/order", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RateLimitOrderWithOptionalParametersAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new RateLimitOrderRequest
        {
            RecvWindow = 5000m,
        };

        var response = await client.RateLimitOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/api/v3/rateLimit/order", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task RateLimitOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.RateLimitOrderAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
