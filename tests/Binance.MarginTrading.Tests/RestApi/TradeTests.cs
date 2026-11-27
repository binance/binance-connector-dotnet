//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.MarginTrading.RestApi;

namespace Binance.MarginTrading.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static MarginTradingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CreateSpecialKeyAsync()
    {
        const string example = """""{"apiKey":"npOzOAeLVgr2TuxWfNo43AaPWpBbJEoKezh1o8mSQb6ryE2odE11A4AoVlJbQoGx","secretKey":"87ssWB7azoy6ACRfyp6OVOL5U3rtZptX31QWw2kWjl1jHEYRbyM1pd6qykRBQw8p","type":"HMAC_SHA256"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateSpecialKeyRequest
        {
            ApiName = "apiName",
        };

        var response = await client.CreateSpecialKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey", seen.Path);
        Assert.Equal("apiName", seen.Param("apiName"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateSpecialKeyWithOptionalParametersAsync()
    {
        const string example = """""{"apiKey":"npOzOAeLVgr2TuxWfNo43AaPWpBbJEoKezh1o8mSQb6ryE2odE11A4AoVlJbQoGx","secretKey":"87ssWB7azoy6ACRfyp6OVOL5U3rtZptX31QWw2kWjl1jHEYRbyM1pd6qykRBQw8p","type":"HMAC_SHA256"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CreateSpecialKeyRequest
        {
            ApiName = "apiName",
            Symbol = "BTCUSDT",
            Ip = "69.210.67.14,69.210.67.15",
            PublicKey = "publicKey",
            PermissionMode = CreateSpecialKeyPermissionMode.Trade,
            RecvWindow = 5000L,
        };

        var response = await client.CreateSpecialKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey", seen.Path);
        Assert.Equal("apiName", seen.Param("apiName"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("69.210.67.14,69.210.67.15", seen.Param("ip"));
        Assert.Equal("publicKey", seen.Param("publicKey"));
        Assert.Equal("TRADE", seen.Param("permissionMode"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CreateSpecialKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CreateSpecialKeyRequest
        {
            ApiName = "apiName",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CreateSpecialKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task DeleteSpecialKeyAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var response = await client.DeleteSpecialKeyAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task DeleteSpecialKeyWithOptionalParametersAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new DeleteSpecialKeyRequest
        {
            ApiName = "apiName",
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.DeleteSpecialKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey", seen.Path);
        Assert.Equal("apiName", seen.Param("apiName"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task DeleteSpecialKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DeleteSpecialKeyAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task EditIpForSpecialKeyAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new EditIpForSpecialKeyRequest
        {
            Ip = "24.156.99.202",
        };

        var response = await client.EditIpForSpecialKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey/ip", seen.Path);
        Assert.Equal("24.156.99.202", seen.Param("ip"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task EditIpForSpecialKeyWithOptionalParametersAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new EditIpForSpecialKeyRequest
        {
            Ip = "24.156.99.202",
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.EditIpForSpecialKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("PUT", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey/ip", seen.Path);
        Assert.Equal("24.156.99.202", seen.Param("ip"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task EditIpForSpecialKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new EditIpForSpecialKeyRequest
        {
            Ip = "24.156.99.202",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.EditIpForSpecialKeyAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task ExitSpecialKeyModeAsync()
    {
        const string example = """""{}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.ExitSpecialKeyModeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/exit-special-key-mode", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExitSpecialKeyModeWithOptionalParametersAsync()
    {
        const string example = """""{}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new ExitSpecialKeyModeRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.ExitSpecialKeyModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/exit-special-key-mode", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task ExitSpecialKeyModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.ExitSpecialKeyModeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetForceLiquidationRecordAsync()
    {
        const string example = """""{"rows":[{"avgPrice":"0.00388359","executedQty":"31.39000000","orderId":180015097,"price":"0.00388110","qty":"31.39000000","side":"SELL","symbol":"BNBBTC","timeInForce":"GTC","isIsolated":true,"updatedTime":1558941374745}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetForceLiquidationRecordAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/forceLiquidationRec", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetForceLiquidationRecordWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"avgPrice":"0.00388359","executedQty":"31.39000000","orderId":180015097,"price":"0.00388110","qty":"31.39000000","side":"SELL","symbol":"BNBBTC","timeInForce":"GTC","isIsolated":true,"updatedTime":1558941374745}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetForceLiquidationRecordRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            IsolatedSymbol = "BTCUSDT",
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetForceLiquidationRecordAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/forceLiquidationRec", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("BTCUSDT", seen.Param("isolatedSymbol"));
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
    public async Task GetForceLiquidationRecordBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetForceLiquidationRecordAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSmallLiabilityExchangeCoinListAsync()
    {
        const string example = """""[{"asset":"ETH","interest":"0.00083334","principal":"0.001","liabilityAsset":"USDT","liabilityQty":0.3552}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetSmallLiabilityExchangeCoinListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/exchange-small-liability", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSmallLiabilityExchangeCoinListWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"ETH","interest":"0.00083334","principal":"0.001","liabilityAsset":"USDT","liabilityQty":0.3552}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSmallLiabilityExchangeCoinListRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetSmallLiabilityExchangeCoinListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/exchange-small-liability", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSmallLiabilityExchangeCoinListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSmallLiabilityExchangeCoinListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetSmallLiabilityExchangeHistoryAsync()
    {
        const string example = """""{"total":1,"rows":[{"asset":"ETH","amount":"0.00083434","targetAsset":"BUSD","targetAmount":"1.37576819","bizType":"EXCHANGE_SMALL_LIABILITY","timestamp":1672801339253}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSmallLiabilityExchangeHistoryRequest
        {
            Current = 1L,
            Size = 10L,
        };

        var response = await client.GetSmallLiabilityExchangeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/exchange-small-liability-history", seen.Path);
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetSmallLiabilityExchangeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":1,"rows":[{"asset":"ETH","amount":"0.00083434","targetAsset":"BUSD","targetAmount":"1.37576819","bizType":"EXCHANGE_SMALL_LIABILITY","timestamp":1672801339253}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetSmallLiabilityExchangeHistoryRequest
        {
            Current = 1L,
            Size = 10L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetSmallLiabilityExchangeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/exchange-small-liability-history", seen.Path);
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("size"));
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
    public async Task GetSmallLiabilityExchangeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetSmallLiabilityExchangeHistoryRequest
        {
            Current = 1L,
            Size = 10L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetSmallLiabilityExchangeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task LiquidationLoanRepayAsync()
    {
        const string example = """""{"repayId":12345678,"asset":"USDT","amount":"300.00000000","status":"SUCCESS","createTime":1714492800000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new LiquidationLoanRepayRequest
        {
            Asset = "USDT",
            Amount = 300.00m,
        };

        var response = await client.LiquidationLoanRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/liquidation-loan/repay", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("300.00", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task LiquidationLoanRepayWithOptionalParametersAsync()
    {
        const string example = """""{"repayId":12345678,"asset":"USDT","amount":"300.00000000","status":"SUCCESS","createTime":1714492800000}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new LiquidationLoanRepayRequest
        {
            Asset = "USDT",
            Amount = 300.00m,
            RecvWindow = 5000L,
        };

        var response = await client.LiquidationLoanRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/liquidation-loan/repay", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("300.00", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task LiquidationLoanRepayBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new LiquidationLoanRepayRequest
        {
            Asset = "USDT",
            Amount = 300.00m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.LiquidationLoanRepayAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountCancelAllOpenOrdersOnASymbolAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","isIsolated":true,"origClientOrderId":"E6APeyTJvkMvLMYMqu1KQ4","orderId":11,"orderListId":-1,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.089853","origQty":"0.178622","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"BUY","selfTradePreventionMode":"NONE","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"2inzWQdDvZLHbbAmAozX2N","transactionTime":1585230948299,"orders":[{"symbol":"BTCUSDT","orderId":20,"clientOrderId":"CwOOIPHSmYywx6jZX77TdL"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"CwOOIPHSmYywx6jZX77TdL","orderId":20,"orderListId":1929,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.668611","origQty":"0.690354","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"0.378131","icebergQty":"0.017083"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountCancelAllOpenOrdersOnASymbolRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.MarginAccountCancelAllOpenOrdersOnASymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/openOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountCancelAllOpenOrdersOnASymbolWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","isIsolated":true,"origClientOrderId":"E6APeyTJvkMvLMYMqu1KQ4","orderId":11,"orderListId":-1,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.089853","origQty":"0.178622","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"BUY","selfTradePreventionMode":"NONE","contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"2inzWQdDvZLHbbAmAozX2N","transactionTime":1585230948299,"orders":[{"symbol":"BTCUSDT","orderId":20,"clientOrderId":"CwOOIPHSmYywx6jZX77TdL"}],"orderReports":[{"symbol":"BTCUSDT","origClientOrderId":"CwOOIPHSmYywx6jZX77TdL","orderId":20,"orderListId":1929,"clientOrderId":"pXLV6Hz6mprAcVYpVMTGgx","price":"0.668611","origQty":"0.690354","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"BUY","stopPrice":"0.378131","icebergQty":"0.017083"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountCancelAllOpenOrdersOnASymbolRequest
        {
            Symbol = "BTCUSDT",
            IsIsolated = MarginAccountCancelAllOpenOrdersOnASymbolIsIsolated.True,
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountCancelAllOpenOrdersOnASymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/openOrders", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountCancelAllOpenOrdersOnASymbolBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountCancelAllOpenOrdersOnASymbolRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountCancelAllOpenOrdersOnASymbolAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountCancelOcoAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"C3wyj4WVEktd7u9aVBRXcN","transactionTime":1574040868128,"symbol":"LTCBTC","isIsolated":false,"orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"pO9ufTiFGg3nw2fOdgeOXa"}],"orderReports":[{"symbol":"LTCBTC","origClientOrderId":"pO9ufTiFGg3nw2fOdgeOXa","orderId":2,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","price":"1.00000000","origQty":"10.00000000","executedQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountCancelOcoRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.MarginAccountCancelOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/orderList", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountCancelOcoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"ALL_DONE","listOrderStatus":"ALL_DONE","listClientOrderId":"C3wyj4WVEktd7u9aVBRXcN","transactionTime":1574040868128,"symbol":"LTCBTC","isIsolated":false,"orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"pO9ufTiFGg3nw2fOdgeOXa"}],"orderReports":[{"symbol":"LTCBTC","origClientOrderId":"pO9ufTiFGg3nw2fOdgeOXa","orderId":2,"orderListId":0,"clientOrderId":"unfWT8ig8i0uj6lPuYLez6","price":"1.00000000","origQty":"10.00000000","executedQty":"0.00000000","cummulativeQuoteQty":"0.00000000","status":"CANCELED","timeInForce":"GTC","type":"STOP_LOSS_LIMIT","side":"SELL","stopPrice":"1.00000000","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountCancelOcoRequest
        {
            Symbol = "BTCUSDT",
            IsIsolated = MarginAccountCancelOcoIsIsolated.True,
            OrderListId = 1L,
            ListClientOrderId = "1",
            NewClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountCancelOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/orderList", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
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
    public async Task MarginAccountCancelOcoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountCancelOcoRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountCancelOcoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountCancelOrderAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":"28","origClientOrderId":"myOrder1","clientOrderId":"cancelMyOrder1","price":"1.00000000","origQty":"10.00000000","executedQty":"8.00000000","cummulativeQuoteQty":"8.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","isIsolated":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountCancelOrderRequest
        {
            Symbol = "LTCBTC",
        };

        var response = await client.MarginAccountCancelOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/order", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountCancelOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"LTCBTC","orderId":"28","origClientOrderId":"myOrder1","clientOrderId":"cancelMyOrder1","price":"1.00000000","origQty":"10.00000000","executedQty":"8.00000000","cummulativeQuoteQty":"8.00000000","status":"CANCELED","timeInForce":"GTC","type":"LIMIT","side":"SELL","isIsolated":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountCancelOrderRequest
        {
            Symbol = "LTCBTC",
            IsIsolated = MarginAccountCancelOrderIsIsolated.True,
            OrderId = 1L,
            OrigClientOrderId = "1",
            NewClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountCancelOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("DELETE", seen.Method);
        Assert.Equal("/sapi/v1/margin/order", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
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
    public async Task MarginAccountCancelOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountCancelOrderRequest
        {
            Symbol = "LTCBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountCancelOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountNewOcoAsync()
    {
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JYVpp3F0f5CAG15DhtrqLp","transactionTime":1563417480525,"symbol":"LTCBTC","marginBuyBorrowAmount":"5","marginBuyBorrowAsset":"BTC","isIsolated":false,"orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos"}],"orderReports":[{"symbol":"LTCBTC","orderId":2,"orderListId":0,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos","transactTime":1563417480525,"price":"0.000000","origQty":"0.624363","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"BUY","stopPrice":"0.960664","selfTradePreventionMode":"NONE"}]}""""";

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
        Assert.Equal("/sapi/v1/margin/order/oco", seen.Path);
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
        const string example = """""{"orderListId":0,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JYVpp3F0f5CAG15DhtrqLp","transactionTime":1563417480525,"symbol":"LTCBTC","marginBuyBorrowAmount":"5","marginBuyBorrowAsset":"BTC","isIsolated":false,"orders":[{"symbol":"LTCBTC","orderId":2,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos"}],"orderReports":[{"symbol":"LTCBTC","orderId":2,"orderListId":0,"clientOrderId":"Kk7sqHb9J6mJWTMDVW7Vos","transactTime":1563417480525,"price":"0.000000","origQty":"0.624363","executedQty":"0.000000","cummulativeQuoteQty":"0.000000","status":"NEW","timeInForce":"GTC","type":"STOP_LOSS","side":"BUY","stopPrice":"0.960664","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOcoRequest
        {
            Symbol = "LTCBTC",
            Side = MarginAccountNewOcoSide.Buy,
            Quantity = 1.0m,
            Price = 1.0m,
            StopPrice = 1.0m,
            IsIsolated = MarginAccountNewOcoIsIsolated.True,
            ListClientOrderId = "1",
            LimitClientOrderId = "1",
            LimitIcebergQty = 1.0m,
            StopClientOrderId = "1",
            StopLimitPrice = 1.0m,
            StopIcebergQty = 1.0m,
            StopLimitTimeInForce = MarginAccountNewOcoStopLimitTimeInForce.Gtc,
            NewOrderRespType = MarginAccountNewOcoNewOrderRespType.Ack,
            SideEffectType = MarginAccountNewOcoSideEffectType.NoSideEffect,
            SelfTradePreventionMode = MarginAccountNewOcoSelfTradePreventionMode.ExpireTaker,
            AutoRepayAtCancel = false,
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountNewOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/order/oco", seen.Path);
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1.0", seen.Param("stopPrice"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("1", seen.Param("listClientOrderId"));
        Assert.Equal("1", seen.Param("limitClientOrderId"));
        Assert.Equal("1.0", seen.Param("limitIcebergQty"));
        Assert.Equal("1", seen.Param("stopClientOrderId"));
        Assert.Equal("1.0", seen.Param("stopLimitPrice"));
        Assert.Equal("1.0", seen.Param("stopIcebergQty"));
        Assert.Equal("GTC", seen.Param("stopLimitTimeInForce"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NO_SIDE_EFFECT", seen.Param("sideEffectType"));
        Assert.Equal("EXPIRE_TAKER", seen.Param("selfTradePreventionMode"));
        Assert.Equal("false", seen.Param("autoRepayAtCancel"));
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
    public async Task MarginAccountNewOrderAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":26769564559,"clientOrderId":"E156O3KP4gOif65bjuUK5V","isIsolated":false,"transactTime":1713873075893,"price":"0","origQty":"0.001","executedQty":"0.001","cummulativeQuoteQty":"65.98253","status":"FILLED","timeInForce":"GTC","type":"MARKET","side":"SELL","selfTradePreventionMode":"EXPIRE_MAKER","marginBuyBorrowAmount":5,"marginBuyBorrowAsset":"BTC","fills":[{"price":"65982.53","qty":"0.001","commission":"0.06598253","commissionAsset":"USDT","tradeId":3570680726}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = MarginAccountNewOrderSide.Buy,
            Type = MarginAccountNewOrderType.Limit,
        };

        var response = await client.MarginAccountNewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/order", seen.Path);
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
    public async Task MarginAccountNewOrderWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSDT","orderId":26769564559,"clientOrderId":"E156O3KP4gOif65bjuUK5V","isIsolated":false,"transactTime":1713873075893,"price":"0","origQty":"0.001","executedQty":"0.001","cummulativeQuoteQty":"65.98253","status":"FILLED","timeInForce":"GTC","type":"MARKET","side":"SELL","selfTradePreventionMode":"EXPIRE_MAKER","marginBuyBorrowAmount":5,"marginBuyBorrowAsset":"BTC","fills":[{"price":"65982.53","qty":"0.001","commission":"0.06598253","commissionAsset":"USDT","tradeId":3570680726}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = MarginAccountNewOrderSide.Buy,
            Type = MarginAccountNewOrderType.Limit,
            IsIsolated = MarginAccountNewOrderIsIsolated.True,
            Quantity = 1.0m,
            QuoteOrderQty = 1.0m,
            Price = 1.0m,
            StopPrice = 1.0m,
            NewClientOrderId = "1",
            IcebergQty = 1.0m,
            NewOrderRespType = MarginAccountNewOrderNewOrderRespType.Ack,
            SideEffectType = MarginAccountNewOrderSideEffectType.NoSideEffect,
            TimeInForce = MarginAccountNewOrderTimeInForce.Gtc,
            SelfTradePreventionMode = MarginAccountNewOrderSelfTradePreventionMode.ExpireTaker,
            TrailingDelta = 100L,
            AutoRepayAtCancel = true,
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountNewOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/order", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("LIMIT", seen.Param("type"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("1.0", seen.Param("quantity"));
        Assert.Equal("1.0", seen.Param("quoteOrderQty"));
        Assert.Equal("1.0", seen.Param("price"));
        Assert.Equal("1.0", seen.Param("stopPrice"));
        Assert.Equal("1", seen.Param("newClientOrderId"));
        Assert.Equal("1.0", seen.Param("icebergQty"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NO_SIDE_EFFECT", seen.Param("sideEffectType"));
        Assert.Equal("GTC", seen.Param("timeInForce"));
        Assert.Equal("EXPIRE_TAKER", seen.Param("selfTradePreventionMode"));
        Assert.Equal("100", seen.Param("trailingDelta"));
        Assert.Equal("true", seen.Param("autoRepayAtCancel"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountNewOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountNewOrderRequest
        {
            Symbol = "BTCUSDT",
            Side = MarginAccountNewOrderSide.Buy,
            Type = MarginAccountNewOrderType.Limit,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountNewOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountNewOtoAsync()
    {
        const string example = """""{"orderListId":13551,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JDuOrsu0Ge8GTyvx8J7VTD","transactionTime":1725521998054,"symbol":"BTCUSDT","isIsolated":false,"orders":[{"symbol":"BTCUSDT","orderId":29896699,"clientOrderId":"y8RB6tQEMuHUXybqbtzTxk"}],"orderReports":[{"symbol":"BTCUSDT","orderId":29896699,"orderListId":13551,"clientOrderId":"y8RB6tQEMuHUXybqbtzTxk","transactTime":1725521998054,"price":"80000.00000000","origQty":"0.02000000","executedQty":"0","cummulativeQuoteQty":"0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOtoRequest
        {
            Symbol = "BTCUSDT",
            WorkingType = MarginAccountNewOtoWorkingType.Limit,
            WorkingSide = MarginAccountNewOtoWorkingSide.Buy,
            WorkingPrice = 1.0m,
            WorkingQuantity = 1.0m,
            WorkingIcebergQty = 1.0m,
            PendingType = MarginAccountNewOtoPendingType.Limit,
            PendingSide = MarginAccountNewOtoPendingSide.Buy,
            PendingQuantity = 1.0m,
        };

        var response = await client.MarginAccountNewOtoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/order/oto", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1.0", seen.Param("workingPrice"));
        Assert.Equal("1.0", seen.Param("workingQuantity"));
        Assert.Equal("1.0", seen.Param("workingIcebergQty"));
        Assert.Equal("LIMIT", seen.Param("pendingType"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1.0", seen.Param("pendingQuantity"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountNewOtoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":13551,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"JDuOrsu0Ge8GTyvx8J7VTD","transactionTime":1725521998054,"symbol":"BTCUSDT","isIsolated":false,"orders":[{"symbol":"BTCUSDT","orderId":29896699,"clientOrderId":"y8RB6tQEMuHUXybqbtzTxk"}],"orderReports":[{"symbol":"BTCUSDT","orderId":29896699,"orderListId":13551,"clientOrderId":"y8RB6tQEMuHUXybqbtzTxk","transactTime":1725521998054,"price":"80000.00000000","origQty":"0.02000000","executedQty":"0","cummulativeQuoteQty":"0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"SELL","selfTradePreventionMode":"NONE"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOtoRequest
        {
            Symbol = "BTCUSDT",
            WorkingType = MarginAccountNewOtoWorkingType.Limit,
            WorkingSide = MarginAccountNewOtoWorkingSide.Buy,
            WorkingPrice = 1.0m,
            WorkingQuantity = 1.0m,
            WorkingIcebergQty = 1.0m,
            PendingType = MarginAccountNewOtoPendingType.Limit,
            PendingSide = MarginAccountNewOtoPendingSide.Buy,
            PendingQuantity = 1.0m,
            IsIsolated = MarginAccountNewOtoIsIsolated.True,
            ListClientOrderId = "1",
            NewOrderRespType = MarginAccountNewOtoNewOrderRespType.Ack,
            SideEffectType = MarginAccountNewOtoSideEffectType.NoSideEffect,
            SelfTradePreventionMode = MarginAccountNewOtoSelfTradePreventionMode.ExpireTaker,
            AutoRepayAtCancel = true,
            WorkingClientOrderId = "1",
            WorkingTimeInForce = MarginAccountNewOtoWorkingTimeInForce.Gtc,
            PendingClientOrderId = "1",
            PendingPrice = 1.0m,
            PendingStopPrice = 1.0m,
            PendingTrailingDelta = 1.0m,
            PendingIcebergQty = 1.0m,
            PendingTimeInForce = MarginAccountNewOtoPendingTimeInForce.Gtc,
        };

        var response = await client.MarginAccountNewOtoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/order/oto", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1.0", seen.Param("workingPrice"));
        Assert.Equal("1.0", seen.Param("workingQuantity"));
        Assert.Equal("1.0", seen.Param("workingIcebergQty"));
        Assert.Equal("LIMIT", seen.Param("pendingType"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1.0", seen.Param("pendingQuantity"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("1", seen.Param("listClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("NO_SIDE_EFFECT", seen.Param("sideEffectType"));
        Assert.Equal("EXPIRE_TAKER", seen.Param("selfTradePreventionMode"));
        Assert.Equal("true", seen.Param("autoRepayAtCancel"));
        Assert.Equal("1", seen.Param("workingClientOrderId"));
        Assert.Equal("GTC", seen.Param("workingTimeInForce"));
        Assert.Equal("1", seen.Param("pendingClientOrderId"));
        Assert.Equal("1.0", seen.Param("pendingPrice"));
        Assert.Equal("1.0", seen.Param("pendingStopPrice"));
        Assert.Equal("1.0", seen.Param("pendingTrailingDelta"));
        Assert.Equal("1.0", seen.Param("pendingIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingTimeInForce"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountNewOtoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountNewOtoRequest
        {
            Symbol = "BTCUSDT",
            WorkingType = MarginAccountNewOtoWorkingType.Limit,
            WorkingSide = MarginAccountNewOtoWorkingSide.Buy,
            WorkingPrice = 1.0m,
            WorkingQuantity = 1.0m,
            WorkingIcebergQty = 1.0m,
            PendingType = MarginAccountNewOtoPendingType.Limit,
            PendingSide = MarginAccountNewOtoPendingSide.Buy,
            PendingQuantity = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountNewOtoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountNewOtocoAsync()
    {
        const string example = """""{"orderListId":13509,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"u2AUo48LLef5qVenRtwJZy","transactionTime":1725521881300,"symbol":"BNBUSDT","isIsolated":false,"orders":[{"symbol":"BNBUSDT","orderId":28282534,"clientOrderId":"IfYDxvrZI4kiyqYpRH13iI"}],"orderReports":[{"symbol":"BNBUSDT","orderId":28282534,"orderListId":13509,"clientOrderId":"IfYDxvrZI4kiyqYpRH13iI","transactTime":1725521881300,"price":"300.00000000","origQty":"1.00000000","executedQty":"0","cummulativeQuoteQty":"0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","selfTradePreventionMode":"NONE","stopPrice":"299.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOtocoRequest
        {
            Symbol = "BTCUSDT",
            WorkingType = MarginAccountNewOtocoWorkingType.Limit,
            WorkingSide = MarginAccountNewOtocoWorkingSide.Buy,
            WorkingPrice = 1.0m,
            WorkingQuantity = 1.0m,
            PendingSide = MarginAccountNewOtocoPendingSide.Buy,
            PendingQuantity = 1.0m,
            PendingAboveType = MarginAccountNewOtocoPendingAboveType.LimitMaker,
        };

        var response = await client.MarginAccountNewOtocoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/order/otoco", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1.0", seen.Param("workingPrice"));
        Assert.Equal("1.0", seen.Param("workingQuantity"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1.0", seen.Param("pendingQuantity"));
        Assert.Equal("LIMIT_MAKER", seen.Param("pendingAboveType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountNewOtocoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":13509,"contingencyType":"OTO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"u2AUo48LLef5qVenRtwJZy","transactionTime":1725521881300,"symbol":"BNBUSDT","isIsolated":false,"orders":[{"symbol":"BNBUSDT","orderId":28282534,"clientOrderId":"IfYDxvrZI4kiyqYpRH13iI"}],"orderReports":[{"symbol":"BNBUSDT","orderId":28282534,"orderListId":13509,"clientOrderId":"IfYDxvrZI4kiyqYpRH13iI","transactTime":1725521881300,"price":"300.00000000","origQty":"1.00000000","executedQty":"0","cummulativeQuoteQty":"0","status":"NEW","timeInForce":"GTC","type":"LIMIT","side":"BUY","selfTradePreventionMode":"NONE","stopPrice":"299.00000000"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountNewOtocoRequest
        {
            Symbol = "BTCUSDT",
            WorkingType = MarginAccountNewOtocoWorkingType.Limit,
            WorkingSide = MarginAccountNewOtocoWorkingSide.Buy,
            WorkingPrice = 1.0m,
            WorkingQuantity = 1.0m,
            PendingSide = MarginAccountNewOtocoPendingSide.Buy,
            PendingQuantity = 1.0m,
            PendingAboveType = MarginAccountNewOtocoPendingAboveType.LimitMaker,
            IsIsolated = MarginAccountNewOtocoIsIsolated.True,
            SideEffectType = MarginAccountNewOtocoSideEffectType.NoSideEffect,
            AutoRepayAtCancel = true,
            ListClientOrderId = "1",
            NewOrderRespType = MarginAccountNewOtocoNewOrderRespType.Ack,
            SelfTradePreventionMode = MarginAccountNewOtocoSelfTradePreventionMode.ExpireTaker,
            WorkingClientOrderId = "1",
            WorkingIcebergQty = 1.0m,
            WorkingTimeInForce = MarginAccountNewOtocoWorkingTimeInForce.Gtc,
            PendingAboveClientOrderId = "1",
            PendingAbovePrice = 1.0m,
            PendingAboveStopPrice = 1.0m,
            PendingAboveTrailingDelta = 1.0m,
            PendingAboveIcebergQty = 1.0m,
            PendingAboveTimeInForce = MarginAccountNewOtocoPendingAboveTimeInForce.Gtc,
            PendingBelowType = MarginAccountNewOtocoPendingBelowType.LimitMaker,
            PendingBelowClientOrderId = "1",
            PendingBelowPrice = 1.0m,
            PendingBelowStopPrice = 1.0m,
            PendingBelowTrailingDelta = 1.0m,
            PendingBelowIcebergQty = 1.0m,
            PendingBelowTimeInForce = MarginAccountNewOtocoPendingBelowTimeInForce.Gtc,
        };

        var response = await client.MarginAccountNewOtocoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/order/otoco", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("LIMIT", seen.Param("workingType"));
        Assert.Equal("BUY", seen.Param("workingSide"));
        Assert.Equal("1.0", seen.Param("workingPrice"));
        Assert.Equal("1.0", seen.Param("workingQuantity"));
        Assert.Equal("BUY", seen.Param("pendingSide"));
        Assert.Equal("1.0", seen.Param("pendingQuantity"));
        Assert.Equal("LIMIT_MAKER", seen.Param("pendingAboveType"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("NO_SIDE_EFFECT", seen.Param("sideEffectType"));
        Assert.Equal("true", seen.Param("autoRepayAtCancel"));
        Assert.Equal("1", seen.Param("listClientOrderId"));
        Assert.Equal("ACK", seen.Param("newOrderRespType"));
        Assert.Equal("EXPIRE_TAKER", seen.Param("selfTradePreventionMode"));
        Assert.Equal("1", seen.Param("workingClientOrderId"));
        Assert.Equal("1.0", seen.Param("workingIcebergQty"));
        Assert.Equal("GTC", seen.Param("workingTimeInForce"));
        Assert.Equal("1", seen.Param("pendingAboveClientOrderId"));
        Assert.Equal("1.0", seen.Param("pendingAbovePrice"));
        Assert.Equal("1.0", seen.Param("pendingAboveStopPrice"));
        Assert.Equal("1.0", seen.Param("pendingAboveTrailingDelta"));
        Assert.Equal("1.0", seen.Param("pendingAboveIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingAboveTimeInForce"));
        Assert.Equal("LIMIT_MAKER", seen.Param("pendingBelowType"));
        Assert.Equal("1", seen.Param("pendingBelowClientOrderId"));
        Assert.Equal("1.0", seen.Param("pendingBelowPrice"));
        Assert.Equal("1.0", seen.Param("pendingBelowStopPrice"));
        Assert.Equal("1.0", seen.Param("pendingBelowTrailingDelta"));
        Assert.Equal("1.0", seen.Param("pendingBelowIcebergQty"));
        Assert.Equal("GTC", seen.Param("pendingBelowTimeInForce"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountNewOtocoBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountNewOtocoRequest
        {
            Symbol = "BTCUSDT",
            WorkingType = MarginAccountNewOtocoWorkingType.Limit,
            WorkingSide = MarginAccountNewOtocoWorkingSide.Buy,
            WorkingPrice = 1.0m,
            WorkingQuantity = 1.0m,
            PendingSide = MarginAccountNewOtocoPendingSide.Buy,
            PendingQuantity = 1.0m,
            PendingAboveType = MarginAccountNewOtocoPendingAboveType.LimitMaker,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountNewOtocoAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginManualLiquidationAsync()
    {
        const string example = """""{"asset":"ETH","interest":"0.00083334","principal":"0.001","liabilityAsset":"USDT","liabilityQty":0.3552}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginManualLiquidationRequest
        {
            Type = MarginManualLiquidationType.Margin,
        };

        var response = await client.MarginManualLiquidationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/manual-liquidation", seen.Path);
        Assert.Equal("MARGIN", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginManualLiquidationWithOptionalParametersAsync()
    {
        const string example = """""{"asset":"ETH","interest":"0.00083334","principal":"0.001","liabilityAsset":"USDT","liabilityQty":0.3552}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginManualLiquidationRequest
        {
            Type = MarginManualLiquidationType.Margin,
            Symbol = "ETHUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.MarginManualLiquidationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/manual-liquidation", seen.Path);
        Assert.Equal("MARGIN", seen.Param("type"));
        Assert.Equal("ETHUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginManualLiquidationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginManualLiquidationRequest
        {
            Type = MarginManualLiquidationType.Margin,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginManualLiquidationAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryCurrentMarginOrderCountUsageAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":10000,"count":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryCurrentMarginOrderCountUsageAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/rateLimit/order", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentMarginOrderCountUsageWithOptionalParametersAsync()
    {
        const string example = """""[{"rateLimitType":"ORDERS","interval":"SECOND","intervalNum":10,"limit":10000,"count":0}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryCurrentMarginOrderCountUsageRequest
        {
            IsIsolated = QueryCurrentMarginOrderCountUsageIsIsolated.True,
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryCurrentMarginOrderCountUsageAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/rateLimit/order", seen.Path);
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryCurrentMarginOrderCountUsageBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryCurrentMarginOrderCountUsageAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryLiquidationLoanAsync()
    {
        const string example = """""{"asset":"USDC","amount":"1000.00000000","repaidAmount":"300.00000000","remainingAmount":"700.00000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryLiquidationLoanAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/liquidation-loan", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLiquidationLoanWithOptionalParametersAsync()
    {
        const string example = """""{"asset":"USDC","amount":"1000.00000000","repaidAmount":"300.00000000","remainingAmount":"700.00000000"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryLiquidationLoanRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryLiquidationLoanAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/liquidation-loan", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLiquidationLoanBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryLiquidationLoanAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryLiquidationLoanRepayHistoryAsync()
    {
        const string example = """""{"total":2,"rows":[{"repayId":12345678,"asset":"USDC","amount":"300.00000000","status":"SUCCESS","createTime":1714492800000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryLiquidationLoanRepayHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/liquidation-loan/repay-history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLiquidationLoanRepayHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"total":2,"rows":[{"repayId":12345678,"asset":"USDC","amount":"300.00000000","status":"SUCCESS","createTime":1714492800000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryLiquidationLoanRepayHistoryRequest
        {
            StartTime = 1714492800000L,
            EndTime = 1714579200000L,
            Current = 1L,
            Size = 50L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryLiquidationLoanRepayHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/liquidation-loan/repay-history", seen.Path);
        Assert.Equal("1714492800000", seen.Param("startTime"));
        Assert.Equal("1714579200000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("50", seen.Param("size"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLiquidationLoanRepayHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryLiquidationLoanRepayHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsAllOcoAsync()
    {
        const string example = """""[{"orderListId":29,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"amEEAXryFzFwYF1FeRpUoZ","transactionTime":1565245913483,"symbol":"LTCBTC","isIsolated":true,"orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"oD7aesZqjEGlZrbtRpy5zB"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsAllOcoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allOrderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsAllOcoWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":29,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"amEEAXryFzFwYF1FeRpUoZ","transactionTime":1565245913483,"symbol":"LTCBTC","isIsolated":true,"orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"oD7aesZqjEGlZrbtRpy5zB"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsAllOcoRequest
        {
            IsIsolated = QueryMarginAccountsAllOcoIsIsolated.True,
            Symbol = "LTCBTC",
            FromId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsAllOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allOrderList", seen.Path);
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("LTCBTC", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("fromId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("100", seen.Param("limit"));
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
    public async Task QueryMarginAccountsAllOrdersAsync()
    {
        const string example = """""[{"clientOrderId":"D2KDy4DIeS56PvkM13f8cP","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":false,"orderId":41295,"origQty":"5.31000000","price":"0.22500000","side":"SELL","status":"CANCELED","stopPrice":"0.18000000","symbol":"BNBBTC","isIsolated":false,"time":1565769338806,"timeInForce":"GTC","type":"TAKE_PROFIT_LIMIT","selfTradePreventionMode":"NONE","updateTime":1565769342148}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsAllOrdersRequest
        {
            Symbol = "BNBBTC",
        };

        var response = await client.QueryMarginAccountsAllOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allOrders", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsAllOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"clientOrderId":"D2KDy4DIeS56PvkM13f8cP","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":false,"orderId":41295,"origQty":"5.31000000","price":"0.22500000","side":"SELL","status":"CANCELED","stopPrice":"0.18000000","symbol":"BNBBTC","isIsolated":false,"time":1565769338806,"timeInForce":"GTC","type":"TAKE_PROFIT_LIMIT","selfTradePreventionMode":"NONE","updateTime":1565769342148}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsAllOrdersRequest
        {
            Symbol = "BNBBTC",
            IsIsolated = QueryMarginAccountsAllOrdersIsIsolated.True,
            OrderId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsAllOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/allOrders", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("100", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsAllOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginAccountsAllOrdersRequest
        {
            Symbol = "BNBBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsAllOrdersAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsOcoAsync()
    {
        const string example = """""{"orderListId":27,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"h2USkA5YQpaXHPIrkd96xE","transactionTime":1565245656253,"symbol":"LTCBTC","isIsolated":true,"orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"qD1gy3kc3Gx0rihm9Y3xwS"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsOcoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/orderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOcoWithOptionalParametersAsync()
    {
        const string example = """""{"orderListId":27,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"h2USkA5YQpaXHPIrkd96xE","transactionTime":1565245656253,"symbol":"LTCBTC","isIsolated":true,"orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"qD1gy3kc3Gx0rihm9Y3xwS"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOcoRequest
        {
            IsIsolated = QueryMarginAccountsOcoIsIsolated.True,
            Symbol = "LTCBTC",
            OrderListId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/orderList", seen.Path);
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("LTCBTC", seen.Param("symbol"));
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
        const string example = """""[{"orderListId":31,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"wuB13fmulKj3YjdqWEcsnp","transactionTime":1565246080644,"symbol":"LTCBTC","isIsolated":true,"orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"r3EH2N76dHfLoSZWIUw1bT"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsOpenOcoAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/openOrderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOcoWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":31,"contingencyType":"OCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"wuB13fmulKj3YjdqWEcsnp","transactionTime":1565246080644,"symbol":"LTCBTC","isIsolated":true,"orders":[{"symbol":"LTCBTC","orderId":4,"clientOrderId":"r3EH2N76dHfLoSZWIUw1bT"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOpenOcoRequest
        {
            IsIsolated = QueryMarginAccountsOpenOcoIsIsolated.True,
            Symbol = "LTCBTC",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsOpenOcoAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/openOrderList", seen.Path);
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("LTCBTC", seen.Param("symbol"));
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
    public async Task QueryMarginAccountsOpenOrdersAsync()
    {
        const string example = """""[{"clientOrderId":"qhcZw71gAkCCTv0t0k8LUK","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":211842552,"origQty":"0.30000000","price":"0.00475010","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","isIsolated":true,"time":1562040170089,"timeInForce":"GTC","type":"LIMIT","selfTradePreventionMode":"NONE","updateTime":1562040170089}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/openOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""[{"clientOrderId":"qhcZw71gAkCCTv0t0k8LUK","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":211842552,"origQty":"0.30000000","price":"0.00475010","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","isIsolated":true,"time":1562040170089,"timeInForce":"GTC","type":"LIMIT","selfTradePreventionMode":"NONE","updateTime":1562040170089}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOpenOrdersRequest
        {
            Symbol = "BNBBTC",
            IsIsolated = QueryMarginAccountsOpenOrdersIsIsolated.True,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/openOrders", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOtootocoOrderListsAsync()
    {
        const string example = """""[{"orderListId":24867326110,"contingencyType":"OTOCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"web_6324e98951224f96b8a24f312abe5067","transactionTime":1790063061632,"symbol":"ASTERUSDT","orders":[{"symbol":"ASTERUSDT","orderId":499470863,"status":"NEW","clientOrderId":"web_f8890794e27b42a1a2ef6b5aef79a949"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryMarginAccountsOpenOtootocoOrderListsAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/oto/openOrderList", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOtootocoOrderListsWithOptionalParametersAsync()
    {
        const string example = """""[{"orderListId":24867326110,"contingencyType":"OTOCO","listStatusType":"EXEC_STARTED","listOrderStatus":"EXECUTING","listClientOrderId":"web_6324e98951224f96b8a24f312abe5067","transactionTime":1790063061632,"symbol":"ASTERUSDT","orders":[{"symbol":"ASTERUSDT","orderId":499470863,"status":"NEW","clientOrderId":"web_f8890794e27b42a1a2ef6b5aef79a949"}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOpenOtootocoOrderListsRequest
        {
            Symbol = "ASTERUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsOpenOtootocoOrderListsAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/oto/openOrderList", seen.Path);
        Assert.Equal("ASTERUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOpenOtootocoOrderListsBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsOpenOtootocoOrderListsAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsOrderAsync()
    {
        const string example = """""{"clientOrderId":"ZwfQzuDIGpceVhKW5DvCmO","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":213205622,"origQty":"0.30000000","price":"0.00493630","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","isIsolated":true,"time":1562133008725,"timeInForce":"GTC","type":"LIMIT","selfTradePreventionMode":"NONE","updateTime":1562133008725}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOrderRequest
        {
            Symbol = "BNBBTC",
        };

        var response = await client.QueryMarginAccountsOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/order", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsOrderWithOptionalParametersAsync()
    {
        const string example = """""{"clientOrderId":"ZwfQzuDIGpceVhKW5DvCmO","cummulativeQuoteQty":"0.00000000","executedQty":"0.00000000","icebergQty":"0.00000000","isWorking":true,"orderId":213205622,"origQty":"0.30000000","price":"0.00493630","side":"SELL","status":"NEW","stopPrice":"0.00000000","symbol":"BNBBTC","isIsolated":true,"time":1562133008725,"timeInForce":"GTC","type":"LIMIT","selfTradePreventionMode":"NONE","updateTime":1562133008725}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsOrderRequest
        {
            Symbol = "BNBBTC",
            IsIsolated = QueryMarginAccountsOrderIsIsolated.True,
            OrderId = 1L,
            OrigClientOrderId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/order", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
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
    public async Task QueryMarginAccountsOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginAccountsOrderRequest
        {
            Symbol = "BNBBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginAccountsTradeListAsync()
    {
        const string example = """""[{"commission":"0.00006000","commissionAsset":"BTC","id":34,"isBestMatch":true,"isBuyer":false,"isMaker":false,"orderId":39324,"price":"0.02000000","qty":"3.00000000","symbol":"BNBBTC","isIsolated":false,"time":1561973357171}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsTradeListRequest
        {
            Symbol = "BNBBTC",
        };

        var response = await client.QueryMarginAccountsTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/myTrades", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginAccountsTradeListWithOptionalParametersAsync()
    {
        const string example = """""[{"commission":"0.00006000","commissionAsset":"BTC","id":34,"isBestMatch":true,"isBuyer":false,"isMaker":false,"orderId":39324,"price":"0.02000000","qty":"3.00000000","symbol":"BNBBTC","isIsolated":false,"time":1561973357171}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginAccountsTradeListRequest
        {
            Symbol = "BNBBTC",
            IsIsolated = QueryMarginAccountsTradeListIsIsolated.True,
            OrderId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            FromId = 1L,
            Limit = 500L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginAccountsTradeListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/myTrades", seen.Path);
        Assert.Equal("BNBBTC", seen.Param("symbol"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
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
    public async Task QueryMarginAccountsTradeListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginAccountsTradeListRequest
        {
            Symbol = "BNBBTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginAccountsTradeListAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryPreventedMatchesAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPreventedMatchesRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.QueryPreventedMatchesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/myPreventedMatches", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPreventedMatchesWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSDT","preventedMatchId":1,"takerOrderId":5,"makerSymbol":"BTCUSDT","makerOrderId":3,"tradeGroupId":1,"selfTradePreventionMode":"EXPIRE_MAKER","price":"1.100000","makerPreventedQuantity":"1.300000","transactTime":1669101687094}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryPreventedMatchesRequest
        {
            Symbol = "BTCUSDT",
            PreventedMatchId = 1L,
            OrderId = 1L,
            FromPreventedMatchId = 1L,
            IsIsolated = QueryPreventedMatchesIsIsolated.True,
            RecvWindow = 5000L,
        };

        var response = await client.QueryPreventedMatchesAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/myPreventedMatches", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("1", seen.Param("preventedMatchId"));
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("fromPreventedMatchId"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryPreventedMatchesBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryPreventedMatchesRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryPreventedMatchesAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySpecialKeyAsync()
    {
        const string example = """""{"apiKey":"npOzOAeLVgr2TuxWfNo43AaPWpBbJEoKezh1o8mSQb6ryE2odE11A4AoVlJbQoGx","ip":"0.0.0.0,192.168.0.1,192.168.0.2","apiName":"testName","type":"RSA","permissionMode":"TRADE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QuerySpecialKeyAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySpecialKeyWithOptionalParametersAsync()
    {
        const string example = """""{"apiKey":"npOzOAeLVgr2TuxWfNo43AaPWpBbJEoKezh1o8mSQb6ryE2odE11A4AoVlJbQoGx","ip":"0.0.0.0,192.168.0.1,192.168.0.2","apiName":"testName","type":"RSA","permissionMode":"TRADE"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySpecialKeyRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QuerySpecialKeyAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/apiKey", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySpecialKeyBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySpecialKeyAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QuerySpecialKeyListAsync()
    {
        const string example = """""[{"apiName":"testName1","apiKey":"znpOzOAeLVgr2TuxWfNo43AaPWpBbJEoKezh1o8mSQb6ryE2odE11A4AoVlJbQoG","ip":"192.168.0.1,192.168.0.2","type":"RSA","permissionMode":"TRADE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QuerySpecialKeyListAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/api-key-list", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySpecialKeyListWithOptionalParametersAsync()
    {
        const string example = """""[{"apiName":"testName1","apiKey":"znpOzOAeLVgr2TuxWfNo43AaPWpBbJEoKezh1o8mSQb6ryE2odE11A4AoVlJbQoG","ip":"192.168.0.1,192.168.0.2","type":"RSA","permissionMode":"TRADE"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QuerySpecialKeyListRequest
        {
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QuerySpecialKeyListAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/api-key-list", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QuerySpecialKeyListBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QuerySpecialKeyListAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SmallLiabilityExchangeAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new SmallLiabilityExchangeRequest
        {
            AssetNames = "BTC,ETH",
        };

        var response = await client.SmallLiabilityExchangeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/exchange-small-liability", seen.Path);
        Assert.Equal("BTC,ETH", seen.Param("assetNames"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task SmallLiabilityExchangeWithOptionalParametersAsync()
    {
        using var server = new Loopback(_ => (200, "null"));
        using var client = Client(server);
        var request = new SmallLiabilityExchangeRequest
        {
            AssetNames = "BTC,ETH",
            RecvWindow = 5000L,
        };

        var response = await client.SmallLiabilityExchangeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/exchange-small-liability", seen.Path);
        Assert.Equal("BTC,ETH", seen.Param("assetNames"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        // No example response is documented for this endpoint: only the request is checked.
    }

    [Fact]
    public async Task SmallLiabilityExchangeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SmallLiabilityExchangeRequest
        {
            AssetNames = "BTC,ETH",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SmallLiabilityExchangeAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
