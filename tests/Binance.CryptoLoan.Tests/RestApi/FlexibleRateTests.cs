//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.CryptoLoan.RestApi;

namespace Binance.CryptoLoan.Tests.RestApi.FlexibleRate;

[Trait("Category", "Native")]
public class FlexibleRateApiTests
{
    private static CryptoLoanRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task CheckCollateralRepayRateAsync()
    {
        const string example = """""{"loanCoin":"BUSD","collateralCoin":"BNB","rate":"300.36781234"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CheckCollateralRepayRateRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
        };

        var response = await client.CheckCollateralRepayRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/repay/rate", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckCollateralRepayRateWithOptionalParametersAsync()
    {
        const string example = """""{"loanCoin":"BUSD","collateralCoin":"BNB","rate":"300.36781234"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new CheckCollateralRepayRateRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            RecvWindow = 5000L,
        };

        var response = await client.CheckCollateralRepayRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/repay/rate", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task CheckCollateralRepayRateBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new CheckCollateralRepayRateRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.CheckCollateralRepayRateAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FlexibleLoanAdjustLtvAsync()
    {
        const string example = """""{"loanCoin":"BUSD","collateralCoin":"BNB","direction":"ADDITIONAL","adjustmentAmount":"5.235","currentLTV":"0.52","status":"Succeeds"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FlexibleLoanAdjustLtvRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            AdjustmentAmount = 1m,
            Direction = FlexibleLoanAdjustLtvDirection.Additional,
        };

        var response = await client.FlexibleLoanAdjustLtvAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/adjust/ltv", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("1", seen.Param("adjustmentAmount"));
        Assert.Equal("ADDITIONAL", seen.Param("direction"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FlexibleLoanAdjustLtvWithOptionalParametersAsync()
    {
        const string example = """""{"loanCoin":"BUSD","collateralCoin":"BNB","direction":"ADDITIONAL","adjustmentAmount":"5.235","currentLTV":"0.52","status":"Succeeds"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FlexibleLoanAdjustLtvRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            AdjustmentAmount = 1m,
            Direction = FlexibleLoanAdjustLtvDirection.Additional,
            RecvWindow = 5000L,
        };

        var response = await client.FlexibleLoanAdjustLtvAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/adjust/ltv", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("1", seen.Param("adjustmentAmount"));
        Assert.Equal("ADDITIONAL", seen.Param("direction"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FlexibleLoanAdjustLtvBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FlexibleLoanAdjustLtvRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            AdjustmentAmount = 1m,
            Direction = FlexibleLoanAdjustLtvDirection.Additional,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FlexibleLoanAdjustLtvAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FlexibleLoanBorrowAsync()
    {
        const string example = """""{"loanCoin":"BUSD","loanAmount":"100.5","collateralCoin":"BNB","collateralAmount":"50.5","status":"Succeeds"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FlexibleLoanBorrowRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
        };

        var response = await client.FlexibleLoanBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/borrow", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FlexibleLoanBorrowWithOptionalParametersAsync()
    {
        const string example = """""{"loanCoin":"BUSD","loanAmount":"100.5","collateralCoin":"BNB","collateralAmount":"50.5","status":"Succeeds"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FlexibleLoanBorrowRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            LoanAmount = 1m,
            CollateralAmount = 1m,
            RecvWindow = 5000L,
        };

        var response = await client.FlexibleLoanBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/borrow", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("1", seen.Param("loanAmount"));
        Assert.Equal("1", seen.Param("collateralAmount"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FlexibleLoanBorrowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FlexibleLoanBorrowRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FlexibleLoanBorrowAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FlexibleLoanRepayAsync()
    {
        const string example = """""{"loanCoin":"BUSD","collateralCoin":"BNB","remainingDebt":"100.5","remainingCollateral":"5.253","fullRepayment":false,"currentLTV":"0.25","repayStatus":"REPAID"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FlexibleLoanRepayRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            RepayAmount = 1m,
        };

        var response = await client.FlexibleLoanRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/repay", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("1", seen.Param("repayAmount"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FlexibleLoanRepayWithOptionalParametersAsync()
    {
        const string example = """""{"loanCoin":"BUSD","collateralCoin":"BNB","remainingDebt":"100.5","remainingCollateral":"5.253","fullRepayment":false,"currentLTV":"0.25","repayStatus":"REPAID"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FlexibleLoanRepayRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            RepayAmount = 1m,
            CollateralReturn = true,
            FullRepayment = false,
            RepaymentType = FlexibleLoanRepayRepaymentType.RepaymentType1,
            RecvWindow = 5000L,
        };

        var response = await client.FlexibleLoanRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/repay", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("1", seen.Param("repayAmount"));
        Assert.Equal("true", seen.Param("collateralReturn"));
        Assert.Equal("false", seen.Param("fullRepayment"));
        Assert.Equal("1", seen.Param("repaymentType"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FlexibleLoanRepayBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new FlexibleLoanRepayRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            RepayAmount = 1m,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FlexibleLoanRepayAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanAssetsDataAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","flexibleInterestRate":"0.00000491","flexibleMinLimit":"100","flexibleMaxLimit":"1000000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleLoanAssetsDataAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/loanable/data", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanAssetsDataWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","flexibleInterestRate":"0.00000491","flexibleMinLimit":"100","flexibleMaxLimit":"1000000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanAssetsDataRequest
        {
            LoanCoin = "BUSD",
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanAssetsDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/loanable/data", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanAssetsDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanAssetsDataAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanBorrowHistoryAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","initialLoanAmount":"10000","collateralCoin":"BNB","initialCollateralAmount":"49.27565492","borrowTime":1575018510000,"status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleLoanBorrowHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/borrow/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanBorrowHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","initialLoanAmount":"10000","collateralCoin":"BNB","initialCollateralAmount":"49.27565492","borrowTime":1575018510000,"status":"SUCCESS"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanBorrowHistoryRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanBorrowHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/borrow/history", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
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
    public async Task GetFlexibleLoanBorrowHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanBorrowHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanCollateralAssetsDataAsync()
    {
        const string example = """""{"rows":[{"collateralCoin":"BNB","initialLTV":"0.65","marginCallLTV":"0.75","liquidationLTV":"0.83","maxLimit":"1000000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleLoanCollateralAssetsDataAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/collateral/data", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanCollateralAssetsDataWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"collateralCoin":"BNB","initialLTV":"0.65","marginCallLTV":"0.75","liquidationLTV":"0.83","maxLimit":"1000000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanCollateralAssetsDataRequest
        {
            CollateralCoin = "BNB",
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanCollateralAssetsDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/collateral/data", seen.Path);
        Assert.Equal("BNB", seen.Param("collateralCoin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanCollateralAssetsDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanCollateralAssetsDataAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanInterestRateHistoryAsync()
    {
        const string example = """""{"rows":[{"coin":"USDT","annualizedInterestRate":"0.0647","time":1575018510000}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanInterestRateHistoryRequest
        {
            Coin = "USDT",
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanInterestRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/interestRateHistory", seen.Path);
        Assert.Equal("USDT", seen.Param("coin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanInterestRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"coin":"USDT","annualizedInterestRate":"0.0647","time":1575018510000}],"total":2}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanInterestRateHistoryRequest
        {
            Coin = "USDT",
            RecvWindow = 5000L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
        };

        var response = await client.GetFlexibleLoanInterestRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/interestRateHistory", seen.Path);
        Assert.Equal("USDT", seen.Param("coin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("1", seen.Param("current"));
        Assert.Equal("10", seen.Param("limit"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanInterestRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFlexibleLoanInterestRateHistoryRequest
        {
            Coin = "USDT",
            RecvWindow = 5000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanInterestRateHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanLiquidationHistoryAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","liquidationDebt":"10000","collateralCoin":"BNB","liquidationCollateralAmount":"123","returnCollateralAmount":"0.2","liquidationFee":"1.2","liquidationStartingPrice":"49.27565492","liquidationStartingTime":1575018510000,"status":"Liquidated"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleLoanLiquidationHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/liquidation/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanLiquidationHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","liquidationDebt":"10000","collateralCoin":"BNB","liquidationCollateralAmount":"123","returnCollateralAmount":"0.2","liquidationFee":"1.2","liquidationStartingPrice":"49.27565492","liquidationStartingTime":1575018510000,"status":"Liquidated"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanLiquidationHistoryRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanLiquidationHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/liquidation/history", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
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
    public async Task GetFlexibleLoanLiquidationHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanLiquidationHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanLtvAdjustmentHistoryAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","collateralCoin":"BNB","direction":"ADDITIONAL","collateralAmount":"5.235","preLTV":"0.78","afterLTV":"0.56","adjustTime":1575018510000}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleLoanLtvAdjustmentHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/ltv/adjustment/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanLtvAdjustmentHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","collateralCoin":"BNB","direction":"ADDITIONAL","collateralAmount":"5.235","preLTV":"0.78","afterLTV":"0.56","adjustTime":1575018510000}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanLtvAdjustmentHistoryRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanLtvAdjustmentHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/ltv/adjustment/history", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
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
    public async Task GetFlexibleLoanLtvAdjustmentHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanLtvAdjustmentHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanOngoingOrdersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","totalDebt":"10000","collateralCoin":"BNB","collateralAmount":"49.27565492","currentLTV":"0.57"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleLoanOngoingOrdersAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/ongoing/orders", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanOngoingOrdersWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","totalDebt":"10000","collateralCoin":"BNB","collateralAmount":"49.27565492","currentLTV":"0.57"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanOngoingOrdersRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanOngoingOrdersAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/ongoing/orders", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
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
    public async Task GetFlexibleLoanOngoingOrdersBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanOngoingOrdersAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFlexibleLoanRepaymentHistoryAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","repayAmount":"10000","collateralCoin":"BNB","collateralReturn":"49.27565492","repayStatus":"REPAID","repayTime":1575018510000}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetFlexibleLoanRepaymentHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/repay/history", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFlexibleLoanRepaymentHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","repayAmount":"10000","collateralCoin":"BNB","collateralReturn":"49.27565492","repayStatus":"REPAID","repayTime":1575018510000}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFlexibleLoanRepaymentHistoryRequest
        {
            LoanCoin = "BUSD",
            CollateralCoin = "BNB",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetFlexibleLoanRepaymentHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v2/loan/flexible/repay/history", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("BNB", seen.Param("collateralCoin"));
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
    public async Task GetFlexibleLoanRepaymentHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFlexibleLoanRepaymentHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
