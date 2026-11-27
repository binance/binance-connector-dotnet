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

namespace Binance.VipLoan.Tests.RestApi.UserInformation;

[Trait("Category", "Native")]
public class UserInformationApiTests
{
    private static VipLoanRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CheckVIPLoanCollateralAccountAsync()
    {
        const string example = """""{"rows":[{"collateralAccountId":"12345678","collateralCoin":"BNB,BTC,ETH"}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.CheckVIPLoanCollateralAccountAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/collateral/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckVIPLoanCollateralAccountWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"collateralAccountId":"12345678","collateralCoin":"BNB,BTC,ETH"}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CheckVIPLoanCollateralAccountRequest
        {
            OrderId = 1L,
            CollateralAccountId = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.CheckVIPLoanCollateralAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/collateral/account", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("collateralAccountId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckVIPLoanCollateralAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CheckVIPLoanCollateralAccountAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetVIPLoanAccruedInterestAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"USDT","principalAmount":"10000","interestAmount":"1.2","annualInterestRate":"0.001273","accrualTime":1575018510000,"orderId":756783308056935400}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetVIPLoanAccruedInterestAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/accruedInterest", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetVIPLoanAccruedInterestWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"USDT","principalAmount":"10000","interestAmount":"1.2","annualInterestRate":"0.001273","accrualTime":1575018510000,"orderId":756783308056935400}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetVIPLoanAccruedInterestRequest
        {
            OrderId = 1L,
            LoanCoin = "BTC",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetVIPLoanAccruedInterestAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/accruedInterest", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("BTC", seen.Param("loanCoin"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetVIPLoanAccruedInterestBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetVIPLoanAccruedInterestAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetVIPLoanOngoingOrdersAsync()
    {
        const string example = """""{"rows":[{"orderId":100000001,"loanCoin":"BUSD","totalDebt":"10000","loanRate":"0.0123","residualInterest":"10.27687923","collateralAccountId":"12345678,23456789","collateralCoin":"BNB,BNB-Earn,BTC,ETH","totalCollateralValueAfterHaircut":"25000.27565492","lockedCollateralValue":"25000.27565492","currentLTV":"0.57","expirationTime":1575018510000,"loanDate":"1676851200000","loanTerm":"30days"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetVIPLoanOngoingOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/ongoing/orders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetVIPLoanOngoingOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"orderId":100000001,"loanCoin":"BUSD","totalDebt":"10000","loanRate":"0.0123","residualInterest":"10.27687923","collateralAccountId":"12345678,23456789","collateralCoin":"BNB,BNB-Earn,BTC,ETH","totalCollateralValueAfterHaircut":"25000.27565492","lockedCollateralValue":"25000.27565492","currentLTV":"0.57","expirationTime":1575018510000,"loanDate":"1676851200000","loanTerm":"30days"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetVIPLoanOngoingOrdersRequest
        {
            OrderId = 1L,
            CollateralAccountId = 1L,
            LoanCoin = "BUSD",
            CollateralCoin = "BNB,BTC,ETH",
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetVIPLoanOngoingOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/ongoing/orders", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("1", seen.Param("collateralAccountId"));
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB,BTC,ETH", seen.Param("collateralCoin"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetVIPLoanOngoingOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetVIPLoanOngoingOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetVIPLoanRepaymentHistoryAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","repayAmount":"10000","repayPrincipal":"9500","repayInterest":"500","collateralCoin":"BNB,BTC,ETH","repayStatus":"Repaid","loanDate":"1676851200000","repayTime":"1575018510000","orderId":"756783308056935434"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetVIPLoanRepaymentHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/repay/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetVIPLoanRepaymentHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","repayAmount":"10000","repayPrincipal":"9500","repayInterest":"500","collateralCoin":"BNB,BTC,ETH","repayStatus":"Repaid","loanDate":"1676851200000","repayTime":"1575018510000","orderId":"756783308056935434"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetVIPLoanRepaymentHistoryRequest
        {
            OrderId = 1L,
            LoanCoin = "BUSD",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetVIPLoanRepaymentHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/repay/history", seen.Path);
        Assert.Equal("1", seen.Param("orderId"));
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetVIPLoanRepaymentHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetVIPLoanRepaymentHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryApplicationStatusAsync()
    {
        const string example = """""{"rows":[{"loanAccountId":"12345678","orderId":"12345678","requestId":"12345678","loanCoin":"BTC","loanAmount":"100.55","collateralAccountId":"12345678,12345678,12345678","collateralCoin":"BUSD,USDT,USDT-Earn,ETH","loanTerm":"30","status":"Repaid","loanDate":"1676851200000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.QueryApplicationStatusAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/request/data", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryApplicationStatusWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanAccountId":"12345678","orderId":"12345678","requestId":"12345678","loanCoin":"BTC","loanAmount":"100.55","collateralAccountId":"12345678,12345678,12345678","collateralCoin":"BUSD,USDT,USDT-Earn,ETH","loanTerm":"30","status":"Repaid","loanDate":"1676851200000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryApplicationStatusRequest
        {
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryApplicationStatusAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/request/data", seen.Path);
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryApplicationStatusBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryApplicationStatusAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
