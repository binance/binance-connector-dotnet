//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Convert.RestApi;

namespace Binance.Convert.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static ConvertRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AcceptQuoteAsync()
    {
        const string example = """""{"orderId":"933256278426274426","createTime":1623381330472,"orderStatus":"PROCESS"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AcceptQuoteRequest
        {
            QuoteId = "1",
        };

        var response = await client.AcceptQuoteAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/acceptQuote", seen.Path);
        Assert.Equal("1", seen.Param("quoteId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcceptQuoteWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":"933256278426274426","createTime":1623381330472,"orderStatus":"PROCESS"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AcceptQuoteRequest
        {
            QuoteId = "1",
            RecvWindow = 5000L,
        };

        var response = await client.AcceptQuoteAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/acceptQuote", seen.Path);
        Assert.Equal("1", seen.Param("quoteId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AcceptQuoteBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new AcceptQuoteRequest
        {
            QuoteId = "1",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AcceptQuoteAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task CancelLimitOrderAsync()
    {
        const string example = """""{"orderId":1603680255057330400,"status":"CANCELED"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelLimitOrderRequest
        {
            OrderId = 1603680255057330400L,
        };

        var response = await client.CancelLimitOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/limit/cancelOrder", seen.Path);
        Assert.Equal("1603680255057330400", seen.Param("orderId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelLimitOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":1603680255057330400,"status":"CANCELED"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CancelLimitOrderRequest
        {
            OrderId = 1603680255057330400L,
            RecvWindow = 5000L,
        };

        var response = await client.CancelLimitOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/limit/cancelOrder", seen.Path);
        Assert.Equal("1603680255057330400", seen.Param("orderId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CancelLimitOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CancelLimitOrderRequest
        {
            OrderId = 1603680255057330400L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CancelLimitOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetConvertTradeHistoryAsync()
    {
        const string example = """""{"list":[{"quoteId":"f3b91c525b2644c7bc1e1cd31b6e1aa6","orderId":940708407462087200,"orderStatus":"SUCCESS","fromAsset":"USDT","fromAmount":"20","toAsset":"BNB","toAmount":"0.06154036","ratio":"0.00307702","inverseRatio":"324.99","createTime":1624248872184}],"startTime":1623824139000,"endTime":1626416139000,"limit":100,"moreData":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetConvertTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetConvertTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/convert/tradeFlow", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetConvertTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"list":[{"quoteId":"f3b91c525b2644c7bc1e1cd31b6e1aa6","orderId":940708407462087200,"orderStatus":"SUCCESS","fromAsset":"USDT","fromAmount":"20","toAsset":"BNB","toAmount":"0.06154036","ratio":"0.00307702","inverseRatio":"324.99","createTime":1624248872184}],"startTime":1623824139000,"endTime":1626416139000,"limit":100,"moreData":false}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetConvertTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.GetConvertTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/convert/tradeFlow", seen.Path);
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
    public async Task GetConvertTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetConvertTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetConvertTradeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task OrderStatusAsync()
    {
        const string example = """""{"orderId":933256278426274400,"orderStatus":"SUCCESS","fromAsset":"BTC","fromAmount":"0.00054414","toAsset":"USDT","toAmount":"20","ratio":"36755","inverseRatio":"0.00002721","createTime":1623381330472}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.OrderStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/convert/orderStatus", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderStatusWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":933256278426274400,"orderStatus":"SUCCESS","fromAsset":"BTC","fromAmount":"0.00054414","toAsset":"USDT","toAmount":"20","ratio":"36755","inverseRatio":"0.00002721","createTime":1623381330472}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new OrderStatusRequest
        {
            OrderId = "1",
            QuoteId = "1",
        };

        var response = await client.OrderStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/convert/orderStatus", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("quoteId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task OrderStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.OrderStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task PlaceLimitOrderAsync()
    {
        const string example = """""{"orderId":1603680255057330400,"status":"PROCESS"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceLimitOrderRequest
        {
            BaseAsset = "BTC",
            QuoteAsset = "USDT",
            LimitPrice = 1m,
            Side = PlaceLimitOrderSide.Buy,
            ExpiredType = PlaceLimitOrderExpiredType.ExpiredType1D,
        };

        var response = await client.PlaceLimitOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/limit/placeOrder", seen.Path);
        Assert.Equal("BTC", seen.Param("baseAsset"));
        Assert.Equal("USDT", seen.Param("quoteAsset"));
        Assert.Equal("1", seen.Param("limitPrice"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1_D", seen.Param("expiredType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceLimitOrderWithOptionalParametersAsync()
    {
        const string example = """""{"orderId":1603680255057330400,"status":"PROCESS"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new PlaceLimitOrderRequest
        {
            BaseAsset = "BTC",
            QuoteAsset = "USDT",
            LimitPrice = 1m,
            Side = PlaceLimitOrderSide.Buy,
            ExpiredType = PlaceLimitOrderExpiredType.ExpiredType1D,
            BaseAmount = 1m,
            QuoteAmount = 1m,
            WalletType = PlaceLimitOrderWalletType.Spot,
            RecvWindow = 5000L,
        };

        var response = await client.PlaceLimitOrderAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/limit/placeOrder", seen.Path);
        Assert.Equal("BTC", seen.Param("baseAsset"));
        Assert.Equal("USDT", seen.Param("quoteAsset"));
        Assert.Equal("1", seen.Param("limitPrice"));
        Assert.Equal("BUY", seen.Param("side"));
        Assert.Equal("1_D", seen.Param("expiredType"));
        Assert.Equal("1", seen.Param("baseAmount"));
        Assert.Equal("1", seen.Param("quoteAmount"));
        Assert.Equal("SPOT", seen.Param("walletType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task PlaceLimitOrderBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new PlaceLimitOrderRequest
        {
            BaseAsset = "BTC",
            QuoteAsset = "USDT",
            LimitPrice = 1m,
            Side = PlaceLimitOrderSide.Buy,
            ExpiredType = PlaceLimitOrderExpiredType.ExpiredType1D,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.PlaceLimitOrderAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryLimitOpenOrdersAsync()
    {
        const string example = """""{"list":[{"quoteId":"18sdf87kh9df","orderId":1150901289839,"orderStatus":"SUCCESS","fromAsset":"BNB","fromAmount":"10","toAsset":"USDT","toAmount":"2317.89","ratio":"231.789","inverseRatio":"0.00431427","createTime":1614089498000,"expiredTimestamp":1614099498000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryLimitOpenOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/convert/limit/queryOpenOrders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLimitOpenOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"list":[{"quoteId":"18sdf87kh9df","orderId":1150901289839,"orderStatus":"SUCCESS","fromAsset":"BNB","fromAmount":"10","toAsset":"USDT","toAmount":"2317.89","ratio":"231.789","inverseRatio":"0.00431427","createTime":1614089498000,"expiredTimestamp":1614099498000}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryLimitOpenOrdersRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.QueryLimitOpenOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/convert/limit/queryOpenOrders", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryLimitOpenOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryLimitOpenOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SendQuoteRequestAsync()
    {
        const string example = """""{"quoteId":"12415572564","ratio":"38163.7","inverseRatio":"0.0000262","validTimestamp":1623319461670,"toAmount":"3816.37","fromAmount":"0.1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SendQuoteRequestRequest
        {
            FromAsset = "BTC",
            ToAsset = "USDT",
        };

        var response = await client.SendQuoteRequestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/getQuote", seen.Path);
        Assert.Equal("BTC", seen.Param("fromAsset"));
        Assert.Equal("USDT", seen.Param("toAsset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SendQuoteRequestWithOptionalParametersAsync()
    {
        const string example = """""{"quoteId":"12415572564","ratio":"38163.7","inverseRatio":"0.0000262","validTimestamp":1623319461670,"toAmount":"3816.37","fromAmount":"0.1"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new SendQuoteRequestRequest
        {
            FromAsset = "BTC",
            ToAsset = "USDT",
            FromAmount = 1m,
            ToAmount = 1m,
            WalletType = SendQuoteRequestWalletType.Spot,
            ValidTime = SendQuoteRequestValidTime.ValidTime10s,
            RecvWindow = 5000L,
        };

        var response = await client.SendQuoteRequestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/convert/getQuote", seen.Path);
        Assert.Equal("BTC", seen.Param("fromAsset"));
        Assert.Equal("USDT", seen.Param("toAsset"));
        Assert.Equal("1", seen.Param("fromAmount"));
        Assert.Equal("1", seen.Param("toAmount"));
        Assert.Equal("SPOT", seen.Param("walletType"));
        Assert.Equal("10s", seen.Param("validTime"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task SendQuoteRequestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new SendQuoteRequestRequest
        {
            FromAsset = "BTC",
            ToAsset = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.SendQuoteRequestAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
