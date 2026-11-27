//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.VipLoan.RestApi;

namespace Binance.VipLoan.Tests.RestApi.Trade;

[Trait("Category", "Native")]
public class TradeApiTests
{
    private static VipLoanRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task VipLoanBorrowAsync()
    {
        const string example = """""{"loanAccountId":"12345678","requestId":"12345678","loanCoin":"BTC","isFlexibleRate":"Yes","loanAmount":"100.55","collateralAccountId":"12345678,12345678,12345678","collateralCoin":"BUSD,USDT,USDT-Earn,ETH","loanTerm":"30"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanBorrowRequest
        {
            LoanAccountId = 1L,
            LoanCoin = "BTC",
            LoanAmount = 1.0m,
            CollateralAccountId = "12345678,12345678,12345678",
            CollateralCoin = "BUSD,USDT,USDT-Earn,ETH",
            IsFlexibleRate = true,
        };

        var response = await client.VipLoanBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/borrow", seen.Path);
        Assert.Equal("1", seen.Param("loanAccountId"));
        Assert.Equal("BTC", seen.Param("loanCoin"));
        Assert.Equal("1.0", seen.Param("loanAmount"));
        Assert.Equal("12345678,12345678,12345678", seen.Param("collateralAccountId"));
        Assert.Equal("BUSD,USDT,USDT-Earn,ETH", seen.Param("collateralCoin"));
        Assert.Equal("true", seen.Param("isFlexibleRate"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanBorrowWithOptionalParametersAsync()
    {
        const string example = """""{"loanAccountId":"12345678","requestId":"12345678","loanCoin":"BTC","isFlexibleRate":"Yes","loanAmount":"100.55","collateralAccountId":"12345678,12345678,12345678","collateralCoin":"BUSD,USDT,USDT-Earn,ETH","loanTerm":"30"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanBorrowRequest
        {
            LoanAccountId = 1L,
            LoanCoin = "BTC",
            LoanAmount = 1.0m,
            CollateralAccountId = "12345678,12345678,12345678",
            CollateralCoin = "BUSD,USDT,USDT-Earn,ETH",
            IsFlexibleRate = true,
            LoanTerm = 30L,
            RecvWindow = 5000L,
        };

        var response = await client.VipLoanBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/borrow", seen.Path);
        Assert.Equal("1", seen.Param("loanAccountId"));
        Assert.Equal("BTC", seen.Param("loanCoin"));
        Assert.Equal("1.0", seen.Param("loanAmount"));
        Assert.Equal("12345678,12345678,12345678", seen.Param("collateralAccountId"));
        Assert.Equal("BUSD,USDT,USDT-Earn,ETH", seen.Param("collateralCoin"));
        Assert.Equal("true", seen.Param("isFlexibleRate"));
        Assert.Equal("30", seen.Param("loanTerm"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanBorrowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new VipLoanBorrowRequest
        {
            LoanAccountId = 1L,
            LoanCoin = "BTC",
            LoanAmount = 1.0m,
            CollateralAccountId = "12345678,12345678,12345678",
            CollateralCoin = "BUSD,USDT,USDT-Earn,ETH",
            IsFlexibleRate = true,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VipLoanBorrowAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task VipLoanFixedRateBorrowAsync()
    {
        const string example = """""{"borrowCoin":"BUSD","borrowAmount":"100.5","actualReceivedAmount":"98.75","collateralCoin":"BNB,BNB-Earn,ETH,BTC","collateralAccountId":"12345,67890,13579","borrowInterestRate":"0.01501231","duration":"30Days","autoRepay":true,"orderId":123456789,"status":"Succeeds"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanFixedRateBorrowRequest
        {
            SupplyRequest = "1212:0.12:100;3434:0.13:50",
            BorrowCoin = "BUSD",
            LoanTerm = 30L,
            BorrowUid = 12345678L,
            CollateralCoin = "BNB,BNB-Earn,ETH,BTC",
            CollateralAccountId = "12345,67890,13579",
        };

        var response = await client.VipLoanFixedRateBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/fixed/borrow", seen.Path);
        Assert.Equal("1212:0.12:100;3434:0.13:50", seen.Param("supplyRequest"));
        Assert.Equal("BUSD", seen.Param("borrowCoin"));
        Assert.Equal("30", seen.Param("loanTerm"));
        Assert.Equal("12345678", seen.Param("borrowUid"));
        Assert.Equal("BNB,BNB-Earn,ETH,BTC", seen.Param("collateralCoin"));
        Assert.Equal("12345,67890,13579", seen.Param("collateralAccountId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanFixedRateBorrowWithOptionalParametersAsync()
    {
        const string example = """""{"borrowCoin":"BUSD","borrowAmount":"100.5","actualReceivedAmount":"98.75","collateralCoin":"BNB,BNB-Earn,ETH,BTC","collateralAccountId":"12345,67890,13579","borrowInterestRate":"0.01501231","duration":"30Days","autoRepay":true,"orderId":123456789,"status":"Succeeds"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanFixedRateBorrowRequest
        {
            SupplyRequest = "1212:0.12:100;3434:0.13:50",
            BorrowCoin = "BUSD",
            LoanTerm = 30L,
            BorrowUid = 12345678L,
            CollateralCoin = "BNB,BNB-Earn,ETH,BTC",
            CollateralAccountId = "12345,67890,13579",
            AutoRepay = true,
            RecvWindow = 5000L,
        };

        var response = await client.VipLoanFixedRateBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/fixed/borrow", seen.Path);
        Assert.Equal("1212:0.12:100;3434:0.13:50", seen.Param("supplyRequest"));
        Assert.Equal("BUSD", seen.Param("borrowCoin"));
        Assert.Equal("30", seen.Param("loanTerm"));
        Assert.Equal("12345678", seen.Param("borrowUid"));
        Assert.Equal("BNB,BNB-Earn,ETH,BTC", seen.Param("collateralCoin"));
        Assert.Equal("12345,67890,13579", seen.Param("collateralAccountId"));
        Assert.Equal("true", seen.Param("autoRepay"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanFixedRateBorrowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new VipLoanFixedRateBorrowRequest
        {
            SupplyRequest = "1212:0.12:100;3434:0.13:50",
            BorrowCoin = "BUSD",
            LoanTerm = 30L,
            BorrowUid = 12345678L,
            CollateralCoin = "BNB,BNB-Earn,ETH,BTC",
            CollateralAccountId = "12345,67890,13579",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VipLoanFixedRateBorrowAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task VipLoanRenewAsync()
    {
        const string example = """""{"loanAccountId":"12345678","loanCoin":"BTC","loanAmount":"100.55","collateralAccountId":"12345677,12345678,12345679","collateralCoin":"BUSD,USDT,ETH","loanTerm":"30"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanRenewRequest
        {
            OrderId = 1L,
            LoanTerm = 30L,
        };

        var response = await client.VipLoanRenewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/renew", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("30", seen.Param("loanTerm"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanRenewWithOptionalParametersAsync()
    {
        const string example = """""{"loanAccountId":"12345678","loanCoin":"BTC","loanAmount":"100.55","collateralAccountId":"12345677,12345678,12345679","collateralCoin":"BUSD,USDT,ETH","loanTerm":"30"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanRenewRequest
        {
            OrderId = 1L,
            LoanTerm = 30L,
            RecvWindow = 5000L,
        };

        var response = await client.VipLoanRenewAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/renew", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("30", seen.Param("loanTerm"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanRenewBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new VipLoanRenewRequest
        {
            OrderId = 1L,
            LoanTerm = 30L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VipLoanRenewAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task VipLoanRepayAsync()
    {
        const string example = """""{"loanCoin":"BUSD","repayAmount":"200.5","remainingPrincipal":"100.5","remainingInterest":"0","collateralCoin":"BNB,BTC,ETH","currentLTV":"0.25","repayStatus":"Repaid"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanRepayRequest
        {
            OrderId = 1L,
            Amount = 1.0m,
        };

        var response = await client.VipLoanRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/repay", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanRepayWithOptionalParametersAsync()
    {
        const string example = """""{"loanCoin":"BUSD","repayAmount":"200.5","remainingPrincipal":"100.5","remainingInterest":"0","collateralCoin":"BNB,BTC,ETH","currentLTV":"0.25","repayStatus":"Repaid"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new VipLoanRepayRequest
        {
            OrderId = 1L,
            Amount = 1.0m,
            RecvWindow = 5000L,
        };

        var response = await client.VipLoanRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/repay", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task VipLoanRepayBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new VipLoanRepayRequest
        {
            OrderId = 1L,
            Amount = 1.0m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.VipLoanRepayAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
