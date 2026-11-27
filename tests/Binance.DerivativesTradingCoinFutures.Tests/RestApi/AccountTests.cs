//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingCoinFutures.RestApi;

namespace Binance.DerivativesTradingCoinFutures.Tests.RestApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    private static DerivativesTradingCoinFuturesRestApi Client(Loopback server) =>
        new(new RestApiConfig { BasePath = server.Url, ApiKey = "test-key", ApiSecret = "test-secret", Retries = 0 });

    [Fact]
    public async Task AccountInformationAsync()
    {
        const string example = """""{"assets":[{"asset":"BTC","walletBalance":"0.00241969","unrealizedProfit":"0.00000000","marginBalance":"0.00241969","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","maxWithdrawAmount":"0.00241969","crossWalletBalance":"0.00241969","crossUnPnl":"0.00000000","availableBalance":"0.00241969","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSD_201225","positionAmt":"0","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"125","isolated":false,"positionSide":"BOTH","entryPrice":"0.0","breakEvenPrice":"0.0","maxQty":"50","updateTime":0,"notionalValue":"0"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"updateTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.AccountInformationAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/account", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationWithOptionalParametersAsync()
    {
        const string example = """""{"assets":[{"asset":"BTC","walletBalance":"0.00241969","unrealizedProfit":"0.00000000","marginBalance":"0.00241969","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","maxWithdrawAmount":"0.00241969","crossWalletBalance":"0.00241969","crossUnPnl":"0.00000000","availableBalance":"0.00241969","updateTime":1625474304765}],"positions":[{"symbol":"BTCUSD_201225","positionAmt":"0","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"125","isolated":false,"positionSide":"BOTH","entryPrice":"0.0","breakEvenPrice":"0.0","maxQty":"50","updateTime":0,"notionalValue":"0"}],"canDeposit":true,"canTrade":true,"canWithdraw":true,"feeTier":2,"updateTime":0}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new AccountInformationRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.AccountInformationAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/account", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task AccountInformationBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.AccountInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesAccountBalanceAsync()
    {
        const string example = """""[{"accountAlias":"SgsR","asset":"BTC","balance":"0.00250000","withdrawAvailable":"0.00250000","crossWalletBalance":"0.00241969","crossUnPnl":"0.00000000","availableBalance":"0.00241969","updateTime":1592468353979}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.FuturesAccountBalanceAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/balance", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceWithOptionalParametersAsync()
    {
        const string example = """""[{"accountAlias":"SgsR","asset":"BTC","balance":"0.00250000","withdrawAvailable":"0.00250000","crossWalletBalance":"0.00241969","crossUnPnl":"0.00000000","availableBalance":"0.00241969","updateTime":1592468353979}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new FuturesAccountBalanceRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.FuturesAccountBalanceAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/balance", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.FuturesAccountBalanceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetCurrentPositionModeAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetCurrentPositionModeAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/positionSide/dual", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCurrentPositionModeWithOptionalParametersAsync()
    {
        const string example = """""{"dualSidePosition":true}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetCurrentPositionModeRequest
        {
            RecvWindow = 5000L,
        };

        var response = await client.GetCurrentPositionModeAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/positionSide/dual", seen.Path);
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetCurrentPositionModeBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetCurrentPositionModeAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForFuturesOrderHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/order/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesOrderHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForFuturesOrderHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/order/asyn", seen.Path);
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
    public async Task GetDownloadIdForFuturesOrderHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesOrderHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForFuturesOrderHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTradeHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/trade/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTradeHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForFuturesTradeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/trade/asyn", seen.Path);
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
    public async Task GetDownloadIdForFuturesTradeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTradeHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForFuturesTradeHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTransactionHistoryAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var response = await client.GetDownloadIdForFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/income/asyn", seen.Path);
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetDownloadIdForFuturesTransactionHistoryWithOptionalParametersAsync()
    {
        const string example = """""{"avgCostTimestampOfLast30d":7241837,"downloadId":"546975389218332672"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            RecvWindow = 5000L,
        };

        var response = await client.GetDownloadIdForFuturesTransactionHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/income/asyn", seen.Path);
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
    public async Task GetDownloadIdForFuturesTransactionHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetDownloadIdForFuturesTransactionHistoryRequest
        {
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetDownloadIdForFuturesTransactionHistoryAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesOrderHistoryDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesOrderHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetFuturesOrderHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesOrderHistoryDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesOrderHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesOrderHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/order/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesOrderHistoryDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesOrderHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesOrderHistoryDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesTradeDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTradeDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesTradeDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/trade/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTradeDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesTradeDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesTradeDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetFuturesTransactionHistoryDownloadLinkByIdAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTransactionHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var response = await client.GetFuturesTransactionHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/income/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTransactionHistoryDownloadLinkByIdWithOptionalParametersAsync()
    {
        const string example = """""{"downloadId":"545923594199212032","status":"processing","url":"","notified":false,"expirationTimestamp":-1,"isExpired":"null"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetFuturesTransactionHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
            RecvWindow = 5000L,
        };

        var response = await client.GetFuturesTransactionHistoryDownloadLinkByIdAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/income/asyn/id", seen.Path);
        Assert.Equal("545923594199212032", seen.Param("downloadId"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetFuturesTransactionHistoryDownloadLinkByIdBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new GetFuturesTransactionHistoryDownloadLinkByIdRequest
        {
            DownloadId = "545923594199212032",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetFuturesTransactionHistoryDownloadLinkByIdAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task GetIncomeHistoryAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"BTC","info":"WITHDRAW","time":1570608000000,"tranId":"9689322392","tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.GetIncomeHistoryAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/income", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetIncomeHistoryWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"","incomeType":"TRANSFER","income":"-0.37500000","asset":"BTC","info":"WITHDRAW","time":1570608000000,"tranId":"9689322392","tradeId":""}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new GetIncomeHistoryRequest
        {
            Symbol = "BTCUSDT",
            IncomeType = GetIncomeHistoryIncomeType.Transfer,
            StartTime = 1623319461670L,
            EndTime = 1641782889000L,
            Limit = 30L,
            RecvWindow = 5000L,
        };

        var response = await client.GetIncomeHistoryAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/income", seen.Path);
        Assert.Equal("BTCUSDT", seen.Param("symbol"));
        Assert.Equal("TRANSFER", seen.Param("incomeType"));
        Assert.Equal("1623319461670", seen.Param("startTime"));
        Assert.Equal("1641782889000", seen.Param("endTime"));
        Assert.Equal("30", seen.Param("limit"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task GetIncomeHistoryBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.GetIncomeHistoryAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NotionalBracketForPairAsync()
    {
        const string example = """""[{"pair":"BTCUSD","brackets":[{"bracket":1,"initialLeverage":125,"qtyCap":50,"qtylFloor":0,"maintMarginRatio":0.004,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.NotionalBracketForPairAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/leverageBracket", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NotionalBracketForPairWithOptionalParametersAsync()
    {
        const string example = """""[{"pair":"BTCUSD","brackets":[{"bracket":1,"initialLeverage":125,"qtyCap":50,"qtylFloor":0,"maintMarginRatio":0.004,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NotionalBracketForPairRequest
        {
            Pair = "BTCUSD",
            RecvWindow = 5000L,
        };

        var response = await client.NotionalBracketForPairAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/leverageBracket", seen.Path);
        Assert.Equal("BTCUSD", seen.Param("pair"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NotionalBracketForPairBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NotionalBracketForPairAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task NotionalBracketForSymbolAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","notionalCoef":1.5,"brackets":[{"bracket":1,"initialLeverage":125,"qtyCap":50,"qtylFloor":0,"maintMarginRatio":0.004,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var response = await client.NotionalBracketForSymbolAsync();

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v2/leverageBracket", seen.Path);
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NotionalBracketForSymbolWithOptionalParametersAsync()
    {
        const string example = """""[{"symbol":"BTCUSD_PERP","notionalCoef":1.5,"brackets":[{"bracket":1,"initialLeverage":125,"qtyCap":50,"qtylFloor":0,"maintMarginRatio":0.004,"cum":0}]}]""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new NotionalBracketForSymbolRequest
        {
            Symbol = "BTCUSD_PERP",
            RecvWindow = 5000L,
        };

        var response = await client.NotionalBracketForSymbolAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v2/leverageBracket", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task NotionalBracketForSymbolBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.NotionalBracketForSymbolAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task UserCommissionRateAsync()
    {
        const string example = """""{"symbol":"BTCUSD_PERP","makerCommissionRate":"0.00015","takerCommissionRate":"0.00040"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserCommissionRateRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var response = await client.UserCommissionRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/commissionRate", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserCommissionRateWithOptionalParametersAsync()
    {
        const string example = """""{"symbol":"BTCUSD_PERP","makerCommissionRate":"0.00015","takerCommissionRate":"0.00040"}""""";

        using var server = new Loopback(_ => (200, example));
        using var client = Client(server);
        var request = new UserCommissionRateRequest
        {
            Symbol = "BTCUSD_PERP",
            RecvWindow = 5000L,
        };

        var response = await client.UserCommissionRateAsync(request);

        var seen = Assert.Single(server.Requests);
        Assert.Equal("GET", seen.Method);
        Assert.Equal("/dapi/v1/commissionRate", seen.Path);
        Assert.Equal("BTCUSD_PERP", seen.Param("symbol"));
        Assert.Equal("5000", seen.Param("recvWindow"));
        Assert.Equal("test-key", seen.Key);
        Assert.NotNull(seen.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", seen.Param("signature"));
        Assert.Equal(200, response.Status);

        ExampleAssert.Matches(example, response.Data());
    }

    [Fact]
    public async Task UserCommissionRateBadRequestAsync()
    {
        using var server = new Loopback(_ => Loopback.BadRequest);
        using var client = Client(server);
        var request = new UserCommissionRateRequest
        {
            Symbol = "BTCUSD_PERP",
        };

        var error = await Assert.ThrowsAsync<BinanceBadRequestException>(() => client.UserCommissionRateAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
