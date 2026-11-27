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

namespace Binance.MarginTrading.Tests.RestApi.BorrowRepay;

[Trait("Category", "Native")]
public class BorrowRepayApiTests
{
    private static MarginTradingRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task GetFutureHourlyInterestRateAsync()
    {
        const string example = """""[{"asset":"BTC","nextHourlyInterestRate":"0.00000571"}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFutureHourlyInterestRateRequest
        {
            Assets = "BTC,ETH",
            IsIsolated = GetFutureHourlyInterestRateIsIsolated.True,
        };

        var response = await client.GetFutureHourlyInterestRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/next-hourly-interest-rate", seen.Path);
        Assert.Equal("BTC,ETH", seen.Param("assets"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFutureHourlyInterestRateBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFutureHourlyInterestRateRequest
        {
            Assets = "BTC,ETH",
            IsIsolated = GetFutureHourlyInterestRateIsIsolated.True,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFutureHourlyInterestRateAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetInterestHistoryAsync()
    {
        const string example = """""{"rows":[{"txId":1352286576452864800,"interestAccuredTime":1672160400000,"asset":"USDT","rawAsset":"USDT","principal":"45.3313","interest":"0.00024995","interestRate":"0.00013233","type":"ON_BORROW","isolatedSymbol":"BNBUSDT"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetInterestHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/interestHistory", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetInterestHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"txId":1352286576452864800,"interestAccuredTime":1672160400000,"asset":"USDT","rawAsset":"USDT","principal":"45.3313","interest":"0.00024995","interestRate":"0.00013233","type":"ON_BORROW","isolatedSymbol":"BNBUSDT"}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetInterestHistoryRequest
        {
            Asset = "USDT",
            IsolatedSymbol = "BNBUSDT",
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.GetInterestHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/interestHistory", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("BNBUSDT", seen.Param("isolatedSymbol"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
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
    public async Task GetInterestHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetInterestHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task MarginAccountBorrowRepayAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountBorrowRepayRequest
        {
            Asset = "USDT",
            IsIsolated = MarginAccountBorrowRepayIsIsolated.True,
            Amount = "1.0",
            Type = MarginAccountBorrowRepayType.Borrow,
        };

        var response = await client.MarginAccountBorrowRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/borrow-repay", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("BORROW", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountBorrowRepayWithOptionalParametersAsync()
    {
        const string example = """""{"tranId":100000001}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new MarginAccountBorrowRepayRequest
        {
            Asset = "USDT",
            IsIsolated = MarginAccountBorrowRepayIsIsolated.True,
            Amount = "1.0",
            Type = MarginAccountBorrowRepayType.Borrow,
            Symbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.MarginAccountBorrowRepayAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("POST", seen.Method);
        Assert.Equal("/sapi/v1/margin/borrow-repay", seen.Path);
        Assert.Equal("USDT", seen.Param("asset"));
        Assert.Equal("TRUE", seen.Param("isIsolated"));
        Assert.Equal("1.0", seen.Param("amount"));
        Assert.Equal("BORROW", seen.Param("type"));
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task MarginAccountBorrowRepayBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new MarginAccountBorrowRepayRequest
        {
            Asset = "USDT",
            IsIsolated = MarginAccountBorrowRepayIsIsolated.True,
            Amount = "1.0",
            Type = MarginAccountBorrowRepayType.Borrow,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.MarginAccountBorrowRepayAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryBorrowRepayRecordsInMarginAccountAsync()
    {
        const string example = """""{"rows":[{"type":"AUTO","isolatedSymbol":"BNBUSDT","amount":"14.00000000","asset":"BNB","interest":"0.01866667","principal":"13.98133333","status":"CONFIRMED","timestamp":1563438204000,"txId":2970933056}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryBorrowRepayRecordsInMarginAccountRequest
        {
            Type = QueryBorrowRepayRecordsInMarginAccountType.Borrow,
        };

        var response = await client.QueryBorrowRepayRecordsInMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/borrow-repay", seen.Path);
        Assert.Equal("BORROW", seen.Param("type"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryBorrowRepayRecordsInMarginAccountWithOptionalParametersAsync()
    {
        const string example = """""{"rows":[{"type":"AUTO","isolatedSymbol":"BNBUSDT","amount":"14.00000000","asset":"BNB","interest":"0.01866667","principal":"13.98133333","status":"CONFIRMED","timestamp":1563438204000,"txId":2970933056}],"total":1}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryBorrowRepayRecordsInMarginAccountRequest
        {
            Type = QueryBorrowRepayRecordsInMarginAccountType.Borrow,
            Asset = "BNB",
            IsolatedSymbol = "BNBUSDT",
            TxId = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Current = 1L,
            Size = 10L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryBorrowRepayRecordsInMarginAccountAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/borrow-repay", seen.Path);
        Assert.Equal("BORROW", seen.Param("type"));
        Assert.Equal("BNB", seen.Param("asset"));
        Assert.Equal("BNBUSDT", seen.Param("isolatedSymbol"));
        Assert.Equal("1", seen.Param("txId"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
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
    public async Task QueryBorrowRepayRecordsInMarginAccountBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryBorrowRepayRecordsInMarginAccountRequest
        {
            Type = QueryBorrowRepayRecordsInMarginAccountType.Borrow,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryBorrowRepayRecordsInMarginAccountAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMarginInterestRateHistoryAsync()
    {
        const string example = """""[{"asset":"BTC","dailyInterestRate":"0.00025000","timestamp":1611544731000,"vipLevel":1}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginInterestRateHistoryRequest
        {
            Asset = "BTC",
        };

        var response = await client.QueryMarginInterestRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/interestRateHistory", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMarginInterestRateHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"asset":"BTC","dailyInterestRate":"0.00025000","timestamp":1611544731000,"vipLevel":1}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMarginInterestRateHistoryRequest
        {
            Asset = "BTC",
            VipLevel = 1L,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.QueryMarginInterestRateHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/interestRateHistory", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("1", seen.Param("vipLevel"));
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
    public async Task QueryMarginInterestRateHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMarginInterestRateHistoryRequest
        {
            Asset = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMarginInterestRateHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task QueryMaxBorrowAsync()
    {
        const string example = """""{"amount":"1.69248805","borrowLimit":"60"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMaxBorrowRequest
        {
            Asset = "BTC",
        };

        var response = await client.QueryMaxBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/maxBorrowable", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMaxBorrowWithOptionalParametersAsync()
    {
        const string example = """""{"amount":"1.69248805","borrowLimit":"60"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new QueryMaxBorrowRequest
        {
            Asset = "BTC",
            IsolatedSymbol = "BTCUSDT",
            RecvWindow = 5000L,
        };

        var response = await client.QueryMaxBorrowAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/sapi/v1/margin/maxBorrowable", seen.Path);
        Assert.Equal("BTC", seen.Param("asset"));
        Assert.Equal("BTCUSDT", seen.Param("isolatedSymbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task QueryMaxBorrowBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new QueryMaxBorrowRequest
        {
            Asset = "BTC",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.QueryMaxBorrowAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
