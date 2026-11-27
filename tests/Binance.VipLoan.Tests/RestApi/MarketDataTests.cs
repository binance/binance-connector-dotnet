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

namespace Binance.VipLoan.Tests.RestApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    private static VipLoanRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetBorrowInterestRateAsync()
    {
        const string example = """""[{"asset":"BUSD","flexibleDailyInterestRate":"0.001503","flexibleYearlyInterestRate":"0.548595","time":1577233578000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBorrowInterestRateRequest
        {
            LoanCoin = "BTC",
        };

        var response = await client.GetBorrowInterestRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/request/interestRate", seen.Path);
        Assert.Equal("BTC", seen.Param("loanCoin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBorrowInterestRateWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"BUSD","flexibleDailyInterestRate":"0.001503","flexibleYearlyInterestRate":"0.548595","time":1577233578000}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetBorrowInterestRateRequest
        {
            LoanCoin = "BTC",
            RecvWindow = 5000L,
        };

        var response = await client.GetBorrowInterestRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/request/interestRate", seen.Path);
        Assert.Equal("BTC", seen.Param("loanCoin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetBorrowInterestRateBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetBorrowInterestRateRequest
        {
            LoanCoin = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetBorrowInterestRateAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCollateralAssetDataAsync()
    {
        const string example = """""{"rows":[{"collateralCoin":"BUSD","_1stCollateralRatio":"100%","_1stCollateralRange":"1-10000000","_2ndCollateralRatio":"80%","_2ndCollateralRange":"10000000-100000000","_3rdCollateralRatio":"60%","_3rdCollateralRange":"100000000-1000000000","_4thCollateralRatio":"0%","_4thCollateralRange":">10000000000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCollateralAssetDataAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/collateral/data", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCollateralAssetDataWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"collateralCoin":"BUSD","_1stCollateralRatio":"100%","_1stCollateralRange":"1-10000000","_2ndCollateralRatio":"80%","_2ndCollateralRange":"10000000-100000000","_3rdCollateralRatio":"60%","_3rdCollateralRange":"100000000-1000000000","_4thCollateralRatio":"0%","_4thCollateralRange":">10000000000"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCollateralAssetDataRequest
        {
            CollateralCoin = "BUSD",
            RecvWindow = 5000L,
        };

        var response = await client.GetCollateralAssetDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/collateral/data", seen.Path);
        Assert.Equal("BUSD", seen.Param("collateralCoin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCollateralAssetDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCollateralAssetDataAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetLoanableAssetsDataAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","_flexibleDailyInterestRate":"0.001503","_flexibleYearlyInterestRate":"0.548595","_30dDailyInterestRate":"0.000136","_30dYearlyInterestRate":"0.03450","_60dDailyInterestRate":"0.000145","_60dYearlyInterestRate":"0.04103","minLimit":"100","maxLimit":"1000000","vipLevel":1}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetLoanableAssetsDataAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/loanable/data", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLoanableAssetsDataWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"loanCoin":"BUSD","_flexibleDailyInterestRate":"0.001503","_flexibleYearlyInterestRate":"0.548595","_30dDailyInterestRate":"0.000136","_30dYearlyInterestRate":"0.03450","_60dDailyInterestRate":"0.000145","_60dYearlyInterestRate":"0.04103","minLimit":"100","maxLimit":"1000000","vipLevel":1}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetLoanableAssetsDataRequest
        {
            LoanCoin = "BUSD",
            VipLevel = 1L,
            RecvWindow = 5000L,
        };

        var response = await client.GetLoanableAssetsDataAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/loanable/data", seen.Path);
        Assert.Equal("BUSD", seen.Param("loanCoin"));
        Assert.Equal("1", seen.Param("vipLevel"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetLoanableAssetsDataBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetLoanableAssetsDataAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetVIPLoanInterestRateHistoryAsync()
    {
        const string example = """""{"rows":[{"coin":"USDT","annualizedInterestRate":"0.0647","time":1575018510000}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetVIPLoanInterestRateHistoryRequest
        {
            Coin = "USDT",
            RecvWindow = 5000L,
        };

        var response = await client.GetVIPLoanInterestRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/interestRateHistory", seen.Path);
        Assert.Equal("USDT", seen.Param("coin"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetVIPLoanInterestRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"coin":"USDT","annualizedInterestRate":"0.0647","time":1575018510000}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetVIPLoanInterestRateHistoryRequest
        {
            Coin = "USDT",
            RecvWindow = 5000L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Limit = 10L,
        };

        var response = await client.GetVIPLoanInterestRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/interestRateHistory", seen.Path);
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
    public async Task GetVIPLoanInterestRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetVIPLoanInterestRateHistoryRequest
        {
            Coin = "USDT",
            RecvWindow = 5000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetVIPLoanInterestRateHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryVIPLoanFixedRateMarketAsync()
    {
        const string example = """""{"total":25,"rows":[{"requestId":1234567890,"requestNo":100001,"coin":"USDT","interestRate":"0.05","duration":30,"minimumAmount":"100","availableAmount":"1000000","estimatedInterest":"4109.59"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryVIPLoanFixedRateMarketRequest
        {
            LoanCoin = "USDT",
        };

        var response = await client.QueryVIPLoanFixedRateMarketAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/fixed/market", seen.Path);
        Assert.Equal("USDT", seen.Param("loanCoin"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryVIPLoanFixedRateMarketWithOptionalParametersAsync()
    {
        const string example = """""{"total":25,"rows":[{"requestId":1234567890,"requestNo":100001,"coin":"USDT","interestRate":"0.05","duration":30,"minimumAmount":"100","availableAmount":"1000000","estimatedInterest":"4109.59"}]}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryVIPLoanFixedRateMarketRequest
        {
            LoanCoin = "USDT",
            Duration = 30L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryVIPLoanFixedRateMarketAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/loan/vip/fixed/market", seen.Path);
        Assert.Equal("USDT", seen.Param("loanCoin"));
        Assert.Equal("30", seen.Param("duration"));
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
    public async Task QueryVIPLoanFixedRateMarketBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryVIPLoanFixedRateMarketRequest
        {
            LoanCoin = "USDT",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryVIPLoanFixedRateMarketAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
