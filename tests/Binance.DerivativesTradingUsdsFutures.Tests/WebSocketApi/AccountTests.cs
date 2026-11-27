//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingUsdsFutures.WebSocketApi;

namespace Binance.DerivativesTradingUsdsFutures.Tests.WebSocketApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    [Fact]
    public async Task AccountInformationAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"multiAssetsMargin":true,"tradeGroupId":-1,"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","isolated":true,"entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0,"breakEvenPrice":"0.0"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"multiAssetsMargin":true,"tradeGroupId":-1,"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","isolated":true,"entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0,"breakEvenPrice":"0.0"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.AccountInformationAsync();

        var frame = server.ApiRequest();
        Assert.Equal("account.status", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountInformationWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"multiAssetsMargin":true,"tradeGroupId":-1,"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","isolated":true,"entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0,"breakEvenPrice":"0.0"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"multiAssetsMargin":true,"tradeGroupId":-1,"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"100","isolated":true,"entryPrice":"0.00000","maxNotional":"250000","bidNotional":"0","askNotional":"0","positionSide":"BOTH","positionAmt":"0","updateTime":0,"breakEvenPrice":"0.0"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AccountInformationRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000L,
        };

        var response = await client.AccountInformationAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.status", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountInformationBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AccountInformationAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task AccountInformationV2Async()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","positionSide":"BOTH","positionAmt":"1.000","unrealizedProfit":"0.00000000","isolatedMargin":"0.00000000","notional":"0","isolatedWallet":"0","initialMargin":"0","maintMargin":"0","updateTime":0}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""{"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","positionSide":"BOTH","positionAmt":"1.000","unrealizedProfit":"0.00000000","isolatedMargin":"0.00000000","notional":"0","isolatedWallet":"0","initialMargin":"0","maintMargin":"0","updateTime":0}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.AccountInformationV2Async();

        var frame = server.ApiRequest();
        Assert.Equal("v2/account.status", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountInformationV2WithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":{"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","positionSide":"BOTH","positionAmt":"1.000","unrealizedProfit":"0.00000000","isolatedMargin":"0.00000000","notional":"0","isolatedWallet":"0","initialMargin":"0","maintMargin":"0","updateTime":0}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""{"totalInitialMargin":"0.00000000","totalMaintMargin":"0.00000000","totalWalletBalance":"126.72469206","totalUnrealizedProfit":"0.00000000","totalMarginBalance":"126.72469206","totalPositionInitialMargin":"0.00000000","totalOpenOrderInitialMargin":"0.00000000","totalCrossWalletBalance":"126.72469206","totalCrossUnPnl":"0.00000000","availableBalance":"126.72469206","maxWithdrawAmount":"126.72469206","assets":[{"asset":"USDT","walletBalance":"23.72469206","unrealizedProfit":"0.00000000","marginBalance":"23.72469206","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1625474304765}],"positions":[{"symbol":"BTCUSDT","positionSide":"BOTH","positionAmt":"1.000","unrealizedProfit":"0.00000000","isolatedMargin":"0.00000000","notional":"0","isolatedWallet":"0","initialMargin":"0","maintMargin":"0","updateTime":0}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new AccountInformationV2Request
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000L,
        };

        var response = await client.AccountInformationV2Async(request);

        var frame = server.ApiRequest();
        Assert.Equal("v2/account.status", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task AccountInformationV2BadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.AccountInformationV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesAccountBalanceAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.FuturesAccountBalanceAsync();

        var frame = server.ApiRequest();
        Assert.Equal("account.balance", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new FuturesAccountBalanceRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000L,
        };

        var response = await client.FuturesAccountBalanceAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("account.balance", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.FuturesAccountBalanceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task FuturesAccountBalanceV2Async()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.FuturesAccountBalanceV2Async();

        var frame = server.ApiRequest();
        Assert.Equal("v2/account.balance", frame.Method);
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceV2WithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"605a6d20-6588-4cb9-afa0-b0ab087507ba","status":200,"result":[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":20}]}""""";
        const string result = """""[{"accountAlias":"SgsR","asset":"USDT","balance":"122607.35137903","crossWalletBalance":"23.72469206","crossUnPnl":"0.00000000","availableBalance":"23.72469206","maxWithdrawAmount":"23.72469206","marginAvailable":true,"updateTime":1617939110373}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new FuturesAccountBalanceV2Request
        {
            Id = "0123456789abcdef0123456789abcdef",
            RecvWindow = 5000L,
        };

        var response = await client.FuturesAccountBalanceV2Async(request);

        var frame = server.ApiRequest();
        Assert.Equal("v2/account.balance", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("5000", frame.Param("recvWindow"));
        Assert.Equal("test-key", frame.Param("apiKey"));
        Assert.NotNull(frame.Param("timestamp"));
        Assert.Matches("^[0-9a-f]{64}$", frame.Param("signature"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task FuturesAccountBalanceV2BadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.FuturesAccountBalanceV2Async());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
