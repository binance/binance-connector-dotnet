//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Fiat.RestApi;

namespace Binance.Fiat.Tests.RestApi;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    private static FiatRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task DepositAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"orderId":"04595xxxxxxxxx37"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositRequest
        {
            Currency = "currency_example",
            ApiPaymentMethod = DepositApiPaymentMethod.Pix,
            Amount = "amount_example",
        };

        var response = await client.DepositAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/fiat/deposit", seen.Path);
        Assert.Equal("currency_example", seen.Param("currency"));
        Assert.Equal("pix", seen.Param("apiPaymentMethod"));
        Assert.Equal("amount_example", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"orderId":"04595xxxxxxxxx37"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new DepositRequest
        {
            Currency = "currency_example",
            ApiPaymentMethod = DepositApiPaymentMethod.Pix,
            Amount = "amount_example",
            RecvWindow = 5000L,
            Ext = new(),
        };

        var response = await client.DepositAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/fiat/deposit", seen.Path);
        Assert.Equal("currency_example", seen.Param("currency"));
        Assert.Equal("pix", seen.Param("apiPaymentMethod"));
        Assert.Equal("amount_example", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task DepositBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new DepositRequest
        {
            Currency = "currency_example",
            ApiPaymentMethod = DepositApiPaymentMethod.Pix,
            Amount = "amount_example",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.DepositAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FiatWithdrawAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"orderId":"04595xxxxxxxxx37"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FiatWithdrawRequest
        {
            Currency = "currency_example",
            ApiPaymentMethod = FiatWithdrawApiPaymentMethod.BankTransfer,
            Amount = 1L,
            AccountInfo = new(),
        };

        var response = await client.FiatWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/fiat/withdraw", seen.Path);
        Assert.Equal("currency_example", seen.Param("currency"));
        Assert.Equal("bank_transfer", seen.Param("apiPaymentMethod"));
        Assert.Equal("1", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FiatWithdrawWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"orderId":"04595xxxxxxxxx37"}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FiatWithdrawRequest
        {
            Currency = "currency_example",
            ApiPaymentMethod = FiatWithdrawApiPaymentMethod.BankTransfer,
            Amount = 1L,
            AccountInfo = new(),
            RecvWindow = 5000L,
            Ext = new(),
        };

        var response = await client.FiatWithdrawAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/fiat/withdraw", seen.Path);
        Assert.Equal("currency_example", seen.Param("currency"));
        Assert.Equal("bank_transfer", seen.Param("apiPaymentMethod"));
        Assert.Equal("1", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FiatWithdrawBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FiatWithdrawRequest
        {
            Currency = "currency_example",
            ApiPaymentMethod = FiatWithdrawApiPaymentMethod.BankTransfer,
            Amount = 1L,
            AccountInfo = new(),
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FiatWithdrawAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFiatDepositWithdrawHistoryAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderNo":"7d76d611-0568-4f43-afb6-24cac7767365","fiatCurrency":"BRL","indicatedAmount":"10.00","amount":"10.00","totalFee":"0.00","method":"BankAccount","status":"Expired","createTime":1626144956000,"updateTime":1626400907000}],"total":1,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFiatDepositWithdrawHistoryRequest
        {
            TransactionType = "0",
        };

        var response = await client.GetFiatDepositWithdrawHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/fiat/orders", seen.Path);
        Assert.Equal("0", seen.Param("transactionType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFiatDepositWithdrawHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderNo":"7d76d611-0568-4f43-afb6-24cac7767365","fiatCurrency":"BRL","indicatedAmount":"10.00","amount":"10.00","totalFee":"0.00","method":"BankAccount","status":"Expired","createTime":1626144956000,"updateTime":1626400907000}],"total":1,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFiatDepositWithdrawHistoryRequest
        {
            TransactionType = "0",
            BeginTime = 1641782889000L,
            EndTime = 1641782889000L,
            Page = 1L,
            Rows = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFiatDepositWithdrawHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/fiat/orders", seen.Path);
        Assert.Equal("0", seen.Param("transactionType"));
        Assert.Equal("1641782889000", seen.Param("beginTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("100", seen.Param("rows"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFiatDepositWithdrawHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFiatDepositWithdrawHistoryRequest
        {
            TransactionType = "0",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFiatDepositWithdrawHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFiatPaymentsHistoryAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderNo":"353fca443f06466db0c4dc89f94f027a","sourceAmount":"20.0","fiatCurrency":"EUR","obtainAmount":"4.462","cryptoCurrency":"LUNA","totalFee":"0.2","price":"4.437472","status":"Failed","paymentMethod":"Credit Card","createTime":1624529919000,"updateTime":1624529919000}],"total":1,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFiatPaymentsHistoryRequest
        {
            TransactionType = "0",
        };

        var response = await client.GetFiatPaymentsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/fiat/payments", seen.Path);
        Assert.Equal("0", seen.Param("transactionType"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFiatPaymentsHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":[{"orderNo":"353fca443f06466db0c4dc89f94f027a","sourceAmount":"20.0","fiatCurrency":"EUR","obtainAmount":"4.462","cryptoCurrency":"LUNA","totalFee":"0.2","price":"4.437472","status":"Failed","paymentMethod":"Credit Card","createTime":1624529919000,"updateTime":1624529919000}],"total":1,"success":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFiatPaymentsHistoryRequest
        {
            TransactionType = "0",
            BeginTime = 1641782889000L,
            EndTime = 1641782889000L,
            Page = 1L,
            Rows = 100L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFiatPaymentsHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/fiat/payments", seen.Path);
        Assert.Equal("0", seen.Param("transactionType"));
        Assert.Equal("1641782889000", seen.Param("beginTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("page"));
        Assert.Equal("100", seen.Param("rows"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFiatPaymentsHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFiatPaymentsHistoryRequest
        {
            TransactionType = "0",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFiatPaymentsHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetOrderDetailAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"orderId":"036752*678","orderStatus":"ORDER_INITIAL","amount":"4.33","fee":"0.43","fiatCurrency":"***","errorCode":"","errorMessage":"","ext":{}}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOrderDetailRequest
        {
            OrderNo = "036752*678",
        };

        var response = await client.GetOrderDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/fiat/get-order-detail", seen.Path);
        Assert.Equal("036752*678", seen.Param("orderNo"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderDetailWithOptionalParametersAsync()
    {
        const string example = """""{"code":"000000","message":"success","data":{"orderId":"036752*678","orderStatus":"ORDER_INITIAL","amount":"4.33","fee":"0.43","fiatCurrency":"***","errorCode":"","errorMessage":"","ext":{}}}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetOrderDetailRequest
        {
            OrderNo = "036752*678",
            RecvWindow = 5000L,
        };

        var response = await client.GetOrderDetailAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/fiat/get-order-detail", seen.Path);
        Assert.Equal("036752*678", seen.Param("orderNo"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetOrderDetailBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetOrderDetailRequest
        {
            OrderNo = "036752*678",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetOrderDetailAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
