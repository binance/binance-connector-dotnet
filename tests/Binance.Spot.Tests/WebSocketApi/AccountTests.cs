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

namespace Binance.Spot.Tests.WebSocketApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    [Fact]
    public async Task AccountCommissionAsync()
    {
        const string envelope = """""{"id":"d3df8a61-98ea-4fe0-8f4e-0fcea5d418b0","status":200,"result":{"symbol":"BTCUSDT","standardCommission":{"maker":"0.00000010","taker":"0.00000020","buyer":"0.00000030","seller":"0.00000040"},"specialCommission":{"maker":"0.01000000","taker":"0.02000000","buyer":"0.03000000","seller":"0.04000000"},"taxCommission":{"maker":"0.00000112","taker":"0.00000114","buyer":"0.00000118","seller":"0.00000116"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.75000000"}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""{"symbol":"BTCUSDT","standardCommission":{"maker":"0.00000010","taker":"0.00000020","buyer":"0.00000030","seller":"0.00000040"},"specialCommission":{"maker":"0.01000000","taker":"0.02000000","buyer":"0.03000000","seller":"0.04000000"},"taxCommission":{"maker":"0.00000112","taker":"0.00000114","buyer":"0.00000118","seller":"0.00000116"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.75000000"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AccountCommissionRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.AccountCommissionAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.commission", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountCommissionWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"d3df8a61-98ea-4fe0-8f4e-0fcea5d418b0","status":200,"result":{"symbol":"BTCUSDT","standardCommission":{"maker":"0.00000010","taker":"0.00000020","buyer":"0.00000030","seller":"0.00000040"},"specialCommission":{"maker":"0.01000000","taker":"0.02000000","buyer":"0.03000000","seller":"0.04000000"},"taxCommission":{"maker":"0.00000112","taker":"0.00000114","buyer":"0.00000118","seller":"0.00000116"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.75000000"}},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""{"symbol":"BTCUSDT","standardCommission":{"maker":"0.00000010","taker":"0.00000020","buyer":"0.00000030","seller":"0.00000040"},"specialCommission":{"maker":"0.01000000","taker":"0.02000000","buyer":"0.03000000","seller":"0.04000000"},"taxCommission":{"maker":"0.00000112","taker":"0.00000114","buyer":"0.00000118","seller":"0.00000116"},"discount":{"enabledForAccount":true,"enabledForSymbol":true,"discountAsset":"BNB","discount":"0.75000000"}}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AccountCommissionRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
        };

        var response = await client.AccountCommissionAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.commission", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountCommissionBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new AccountCommissionRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AccountCommissionAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountRateLimitsOrdersAsync()
    {
        const string envelope = """""{"id":"d3783d8d-f8d1-4d2c-b8a0-b7596af5a664","status":200,"result":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":0},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":0}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":40}]}""""";
        const string result = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":0},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":0}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.AccountRateLimitsOrdersAsync();

        var frame = server.ApiRequest();
        Assert.Equal("account.rateLimits.orders", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountRateLimitsOrdersWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"d3783d8d-f8d1-4d2c-b8a0-b7596af5a664","status":200,"result":[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":0},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":0}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":40}]}""""";
        const string result = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":50,"count":0},{"rateLimitType":"ORDERS","interval":"DAY","intervalNum":1,"limit":160000,"count":0}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AccountRateLimitsOrdersRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000m,
        };

        var response = await client.AccountRateLimitsOrdersAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.rateLimits.orders", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountRateLimitsOrdersBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AccountRateLimitsOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountStatusAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"makerCommission":15,"takerCommission":15,"buyerCommission":0,"sellerCommission":0,"canTrade":true,"canWithdraw":true,"canDeposit":true,"commissionRates":{"maker":"0.00150000","taker":"0.00150000","buyer":"0.00000000","seller":"0.00000000"},"brokered":false,"requireSelfTradePrevention":false,"preventSor":false,"updateTime":1660801833000,"accountType":"SPOT","balances":[{"asset":"BNB","free":"0.00000000","locked":"0.00000000"},{"asset":"BTC","free":"1.3447112","locked":"0.08600000"},{"asset":"USDT","free":"1021.21000000","locked":"0.00000000"}],"permissions":["SPOT"],"uid":354937868},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""{"makerCommission":15,"takerCommission":15,"buyerCommission":0,"sellerCommission":0,"canTrade":true,"canWithdraw":true,"canDeposit":true,"commissionRates":{"maker":"0.00150000","taker":"0.00150000","buyer":"0.00000000","seller":"0.00000000"},"brokered":false,"requireSelfTradePrevention":false,"preventSor":false,"updateTime":1660801833000,"accountType":"SPOT","balances":[{"asset":"BNB","free":"0.00000000","locked":"0.00000000"},{"asset":"BTC","free":"1.3447112","locked":"0.08600000"},{"asset":"USDT","free":"1021.21000000","locked":"0.00000000"}],"permissions":["SPOT"],"uid":354937868}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.AccountStatusAsync();

        var frame = server.ApiRequest();
        Assert.Equal("account.status", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountStatusWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"makerCommission":15,"takerCommission":15,"buyerCommission":0,"sellerCommission":0,"canTrade":true,"canWithdraw":true,"canDeposit":true,"commissionRates":{"maker":"0.00150000","taker":"0.00150000","buyer":"0.00000000","seller":"0.00000000"},"brokered":false,"requireSelfTradePrevention":false,"preventSor":false,"updateTime":1660801833000,"accountType":"SPOT","balances":[{"asset":"BNB","free":"0.00000000","locked":"0.00000000"},{"asset":"BTC","free":"1.3447112","locked":"0.08600000"},{"asset":"USDT","free":"1021.21000000","locked":"0.00000000"}],"permissions":["SPOT"],"uid":354937868},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""{"makerCommission":15,"takerCommission":15,"buyerCommission":0,"sellerCommission":0,"canTrade":true,"canWithdraw":true,"canDeposit":true,"commissionRates":{"maker":"0.00150000","taker":"0.00150000","buyer":"0.00000000","seller":"0.00000000"},"brokered":false,"requireSelfTradePrevention":false,"preventSor":false,"updateTime":1660801833000,"accountType":"SPOT","balances":[{"asset":"BNB","free":"0.00000000","locked":"0.00000000"},{"asset":"BTC","free":"1.3447112","locked":"0.08600000"},{"asset":"USDT","free":"1021.21000000","locked":"0.00000000"}],"permissions":["SPOT"],"uid":354937868}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AccountStatusRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            OmitZeroBalances = false,
            RecvWindow = 5000m,
        };

        var response = await client.AccountStatusAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.status", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("false", frame.Param("omitZeroBalances"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountStatusBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AccountStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AllOrderListsAsync()
    {
        const string envelope = """""{"id":"8617b7b3-1b3d-4dec-94cd-eefd929b8ceb","status":200,"result":[{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.AllOrderListsAsync();

        var frame = server.ApiRequest();
        Assert.Equal("allOrderLists", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AllOrderListsWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"8617b7b3-1b3d-4dec-94cd-eefd929b8ceb","status":200,"result":[{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AllOrderListsRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            FromId = 1L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.AllOrderListsAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("allOrderLists", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("fromId"));
        Assert.Equal("1735693200000", frame.Param("startTime"));
        Assert.Equal("1735693200000", frame.Param("endTime"));
        Assert.Equal("1", frame.Param("limit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AllOrderListsBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AllOrderListsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AllOrdersAsync()
    {
        const string envelope = """""{"id":"734235c2-13d2-4574-be68-723e818c08f3","status":200,"result":[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"origQuoteOrderQty":"0.000000","selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","icebergQty":"0.00000000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"origQuoteOrderQty":"0.000000","selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","icebergQty":"0.00000000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AllOrdersRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.AllOrdersAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("allOrders", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AllOrdersWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"734235c2-13d2-4574-be68-723e818c08f3","status":200,"result":[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"origQuoteOrderQty":"0.000000","selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","icebergQty":"0.00000000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"origQuoteOrderQty":"0.000000","selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","icebergQty":"0.00000000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AllOrdersRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.AllOrdersAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("allOrders", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("1735693200000", frame.Param("startTime"));
        Assert.Equal("1735693200000", frame.Param("endTime"));
        Assert.Equal("1", frame.Param("limit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AllOrdersBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new AllOrdersRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AllOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyAllocationsAsync()
    {
        const string envelope = """""{"id":"g4ce6a53-a39d-4f71-823b-4ab5r391d6y8","status":200,"result":[{"symbol":"BTCUSDT","allocationId":0,"allocationType":"SOR","orderId":500,"orderListId":-1,"price":"1.00000000","qty":"0.10000000","quoteQty":"0.10000000","commission":"0.00000000","commissionAsset":"BTC","time":1687319487614,"isBuyer":false,"isMaker":false,"isAllocator":false}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","allocationId":0,"allocationType":"SOR","orderId":500,"orderListId":-1,"price":"1.00000000","qty":"0.10000000","quoteQty":"0.10000000","commission":"0.00000000","commissionAsset":"BTC","time":1687319487614,"isBuyer":false,"isMaker":false,"isAllocator":false}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyAllocationsRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.MyAllocationsAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myAllocations", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyAllocationsWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"g4ce6a53-a39d-4f71-823b-4ab5r391d6y8","status":200,"result":[{"symbol":"BTCUSDT","allocationId":0,"allocationType":"SOR","orderId":500,"orderListId":-1,"price":"1.00000000","qty":"0.10000000","quoteQty":"0.10000000","commission":"0.00000000","commissionAsset":"BTC","time":1687319487614,"isBuyer":false,"isMaker":false,"isAllocator":false}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","allocationId":0,"allocationType":"SOR","orderId":500,"orderListId":-1,"price":"1.00000000","qty":"0.10000000","quoteQty":"0.10000000","commission":"0.00000000","commissionAsset":"BTC","time":1687319487614,"isBuyer":false,"isMaker":false,"isAllocator":false}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyAllocationsRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            FromAllocationId = 1L,
            Limit = 1L,
            OrderId = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.MyAllocationsAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myAllocations", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1735693200000", frame.Param("startTime"));
        Assert.Equal("1735693200000", frame.Param("endTime"));
        Assert.Equal("1", frame.Param("fromAllocationId"));
        Assert.Equal("1", frame.Param("limit"));
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyAllocationsBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new MyAllocationsRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.MyAllocationsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyFiltersAsync()
    {
        const string envelope = """""{"id":"1758009606869","status":200,"result":{"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbolFilters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"assetFilters":[{"filterType":"MAX_ASSET","qtyExponent":8,"limit":"1000000.00000000","asset":"JPY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":40}]}}""""";
        const string result = """""{"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbolFilters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"assetFilters":[{"filterType":"MAX_ASSET","qtyExponent":8,"limit":"1000000.00000000","asset":"JPY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":40}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyFiltersRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.MyFiltersAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myFilters", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyFiltersWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"1758009606869","status":200,"result":{"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbolFilters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"assetFilters":[{"filterType":"MAX_ASSET","qtyExponent":8,"limit":"1000000.00000000","asset":"JPY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":40}]}}""""";
        const string result = """""{"exchangeFilters":[{"filterType":"EXCHANGE_MAX_NUM_ORDERS","maxNumOrders":1000}],"symbolFilters":[{"filterType":"PRICE_FILTER","priceExponent":8,"minPrice":"0.00000100","maxPrice":"100000.00000000","tickSize":"0.00000100"}],"assetFilters":[{"filterType":"MAX_ASSET","qtyExponent":8,"limit":"1000000.00000000","asset":"JPY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":40}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyFiltersRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000m,
        };

        var response = await client.MyFiltersAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myFilters", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyFiltersBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new MyFiltersRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.MyFiltersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyPreventedMatchesAsync()
    {
        const string envelope = """""{"id":"g4ce6a53-a39d-4f71-823b-4ab5r391d6y8","status":200,"result":[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyPreventedMatchesRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.MyPreventedMatchesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myPreventedMatches", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyPreventedMatchesWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"g4ce6a53-a39d-4f71-823b-4ab5r391d6y8","status":200,"result":[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyPreventedMatchesRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            PreventedMatchId = 1L,
            OrderId = 1L,
            FromPreventedMatchId = 1L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.MyPreventedMatchesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myPreventedMatches", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("preventedMatchId"));
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("1", frame.Param("fromPreventedMatchId"));
        Assert.Equal("1", frame.Param("limit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyPreventedMatchesBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new MyPreventedMatchesRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.MyPreventedMatchesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MyTradesAsync()
    {
        const string envelope = """""{"id":"f4ce6a53-a29d-4f70-823b-4ab59391d6e8","status":200,"result":[{"symbol":"BTCUSDT","id":1650422481,"orderId":12569099453,"orderListId":-1,"price":"23416.10000000","qty":"0.00635000","quoteQty":"148.69223500","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true},{"symbol":"BTCUSDT","id":1650422482,"orderId":12569099453,"orderListId":-1,"price":"23416.50000000","qty":"0.00212000","quoteQty":"49.64298000","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","id":1650422481,"orderId":12569099453,"orderListId":-1,"price":"23416.10000000","qty":"0.00635000","quoteQty":"148.69223500","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true},{"symbol":"BTCUSDT","id":1650422482,"orderId":12569099453,"orderListId":-1,"price":"23416.50000000","qty":"0.00212000","quoteQty":"49.64298000","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.MyTradesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myTrades", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyTradesWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"f4ce6a53-a29d-4f70-823b-4ab59391d6e8","status":200,"result":[{"symbol":"BTCUSDT","id":1650422481,"orderId":12569099453,"orderListId":-1,"price":"23416.10000000","qty":"0.00635000","quoteQty":"148.69223500","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true},{"symbol":"BTCUSDT","id":1650422482,"orderId":12569099453,"orderListId":-1,"price":"23416.50000000","qty":"0.00212000","quoteQty":"49.64298000","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":20}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","id":1650422481,"orderId":12569099453,"orderListId":-1,"price":"23416.10000000","qty":"0.00635000","quoteQty":"148.69223500","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true},{"symbol":"BTCUSDT","id":1650422482,"orderId":12569099453,"orderListId":-1,"price":"23416.50000000","qty":"0.00212000","quoteQty":"49.64298000","commission":"0.00000000","commissionAsset":"BNB","time":1660801715793,"isBuyer":false,"isMaker":true,"isBestMatch":true}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new MyTradesRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            StartTime = 1735693200000L,
            EndTime = 1735693200000L,
            FromId = 1L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.MyTradesAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("myTrades", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("1735693200000", frame.Param("startTime"));
        Assert.Equal("1735693200000", frame.Param("endTime"));
        Assert.Equal("1", frame.Param("fromId"));
        Assert.Equal("1", frame.Param("limit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task MyTradesBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new MyTradesRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.MyTradesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenOrderListsStatusAsync()
    {
        const string envelope = """""{"id":"3a4437e2-41a3-4c19-897c-9cadc5dce8b6","status":200,"result":[{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":4,"clientOrderId":"CUhLgTXnX5n2c0gWiLpV4d"},{"symbol":"BTCUSDT","orderId":5,"clientOrderId":"1ZqG7bBuYwaF4SU8CwnwHm"}]}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":6}]}""""";
        const string result = """""[{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":4,"clientOrderId":"CUhLgTXnX5n2c0gWiLpV4d"},{"symbol":"BTCUSDT","orderId":5,"clientOrderId":"1ZqG7bBuYwaF4SU8CwnwHm"}]}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.OpenOrderListsStatusAsync();

        var frame = server.ApiRequest();
        Assert.Equal("openOrderLists.status", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OpenOrderListsStatusWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"3a4437e2-41a3-4c19-897c-9cadc5dce8b6","status":200,"result":[{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":4,"clientOrderId":"CUhLgTXnX5n2c0gWiLpV4d"},{"symbol":"BTCUSDT","orderId":5,"clientOrderId":"1ZqG7bBuYwaF4SU8CwnwHm"}]}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":6}]}""""";
        const string result = """""[{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":4,"clientOrderId":"CUhLgTXnX5n2c0gWiLpV4d"},{"symbol":"BTCUSDT","orderId":5,"clientOrderId":"1ZqG7bBuYwaF4SU8CwnwHm"}]}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OpenOrderListsStatusRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000m,
        };

        var response = await client.OpenOrderListsStatusAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("openOrderLists.status", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OpenOrderListsStatusBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OpenOrderListsStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OpenOrdersStatusAsync()
    {
        const string envelope = """""{"id":"55f07876-4f6f-4c47-87dc-43e5fff3f2e7","status":200,"result":[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00720000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"172.43931000","status":"PARTIALLY_FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":6}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00720000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"172.43931000","status":"PARTIALLY_FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.OpenOrdersStatusAsync();

        var frame = server.ApiRequest();
        Assert.Equal("openOrders.status", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OpenOrdersStatusWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"55f07876-4f6f-4c47-87dc-43e5fff3f2e7","status":200,"result":[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00720000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"172.43931000","status":"PARTIALLY_FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":6}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00720000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"172.43931000","status":"PARTIALLY_FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"selfTradePreventionMode":"NONE","icebergQty":"0.00000000","preventedMatchId":0,"preventedQuantity":"1.200000","stopPrice":"0.00000000","strategyId":1,"strategyType":1000000,"trailingDelta":10,"trailingTime":-1,"usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OpenOrdersStatusRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BNBUSDT",
            RecvWindow = 5000m,
        };

        var response = await client.OpenOrdersStatusAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("openOrders.status", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OpenOrdersStatusBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OpenOrdersStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderAmendmentsAsync()
    {
        const string envelope = """""{"id":"6f5ebe91-01d9-43ac-be99-57cf062e0e30","status":200,"result":[{"symbol":"BTCUSDT","orderId":23,"executionId":60,"origClientOrderId":"my_pending_order","newClientOrderId":"xbxXh5SSwaHS7oUEOCI88B","origQty":"7.00000000","newQty":"5.00000000","time":1741924229819}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":23,"executionId":60,"origClientOrderId":"my_pending_order","newClientOrderId":"xbxXh5SSwaHS7oUEOCI88B","origQty":"7.00000000","newQty":"5.00000000","time":1741924229819}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderAmendmentsRequest
        {
            Symbol = "BNBUSDT",
            OrderId = 1L,
        };

        var response = await client.OrderAmendmentsAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.amendments", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderAmendmentsWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"6f5ebe91-01d9-43ac-be99-57cf062e0e30","status":200,"result":[{"symbol":"BTCUSDT","orderId":23,"executionId":60,"origClientOrderId":"my_pending_order","newClientOrderId":"xbxXh5SSwaHS7oUEOCI88B","origQty":"7.00000000","newQty":"5.00000000","time":1741924229819}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""[{"symbol":"BTCUSDT","orderId":23,"executionId":60,"origClientOrderId":"my_pending_order","newClientOrderId":"xbxXh5SSwaHS7oUEOCI88B","origQty":"7.00000000","newQty":"5.00000000","time":1741924229819}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderAmendmentsRequest
        {
            Symbol = "BNBUSDT",
            OrderId = 1L,
            Id = "0123456789abcdef0123456789abcdef",
            FromExecutionId = 1L,
            Limit = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.OrderAmendmentsAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.amendments", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("fromExecutionId"));
        Assert.Equal("1", frame.Param("limit"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderAmendmentsBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderAmendmentsRequest
        {
            Symbol = "BNBUSDT",
            OrderId = 1L,
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderAmendmentsAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderListStatusAsync()
    {
        const string envelope = """""{"id":"b53fd5ff-82c7-4a04-bd64-5f9dc42c2100","status":200,"result":{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.OrderListStatusAsync();

        var frame = server.ApiRequest();
        Assert.Equal("orderList.status", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListStatusWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"b53fd5ff-82c7-4a04-bd64-5f9dc42c2100","status":200,"result":{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"orderListId":1274512,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"08985fedd9ea2cf6b28996","transactionTime":1660801713793,"symbol":"BTCUSDT","orders":[{"symbol":"BTCUSDT","orderId":12569138901,"clientOrderId":"BqtFCj5odMoWtSqGk2X9tU"},{"symbol":"BTCUSDT","orderId":12569138902,"clientOrderId":"jLnZpj5enfMXTuhKB1d0us"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderListStatusRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            OrigClientOrderId = "08985fedd9ea2cf6b28996",
            OrderListId = 1L,
            RecvWindow = 5000m,
        };

        var response = await client.OrderListStatusAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("orderList.status", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("08985fedd9ea2cf6b28996", frame.Param("origClientOrderId"));
        Assert.Equal("1", frame.Param("orderListId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderListStatusBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderListStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderStatusAsync()
    {
        const string envelope = """""{"id":"aa62318a-5a97-4f3b-bdc7-640bbe33b291","status":200,"result":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":10,"trailingTime":-1,"icebergQty":"0.00000000","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":10,"trailingTime":-1,"icebergQty":"0.00000000","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderStatusRequest
        {
            Symbol = "BNBUSDT",
        };

        var response = await client.OrderStatusAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.status", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderStatusWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"aa62318a-5a97-4f3b-bdc7-640bbe33b291","status":200,"result":{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":10,"trailingTime":-1,"icebergQty":"0.00000000","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":6000,"count":4}]}""""";
        const string result = """""{"symbol":"BTCUSDT","orderId":12569099453,"orderListId":-1,"clientOrderId":"4d96324ff9d44481926157","price":"23416.10000000","origQty":"0.00847000","executedQty":"0.00847000","origQuoteOrderQty":"0.000000","cummulativeQuoteQty":"198.33521500","status":"FILLED","timeInForce":"GTC","type":"LIMIT","side":"SELL","stopPrice":"0.00000000","trailingDelta":10,"trailingTime":-1,"icebergQty":"0.00000000","time":1660801715639,"updateTime":1660801717945,"isWorking":true,"workingTime":1660801715639,"strategyId":37463720,"strategyType":1000000,"selfTradePreventionMode":"NONE","preventedMatchId":0,"preventedQuantity":"1.200000","usedSor":true,"workingFloor":"SOR","pegPriceType":"PRIMARY_PEG","pegOffsetType":"PRICE_LEVEL","pegOffsetValue":5,"peggedPrice":"87523.83710000","expiryReason":"INSUFFICIENT_LIQUIDITY"}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderStatusRequest
        {
            Symbol = "BNBUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            OrderId = 1L,
            OrigClientOrderId = "myOrder1",
            RecvWindow = 5000m,
        };

        var response = await client.OrderStatusAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("order.status", frame.Method);
        Assert.Equal("BNBUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("1", frame.Param("orderId"));
        Assert.Equal("myOrder1", frame.Param("origClientOrderId"));
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderStatusBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderStatusRequest
        {
            Symbol = "BNBUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderStatusAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
