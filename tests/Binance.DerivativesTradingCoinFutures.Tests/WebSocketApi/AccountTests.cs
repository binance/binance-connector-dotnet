//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

namespace Binance.DerivativesTradingCoinFutures.Tests.WebSocketApi.Account;

[Trait("Category", "Native")]
public class AccountApiTests
{
    [Fact]
    public async Task AccountInformationAsync()
    {
        const string envelope = """""{"id":"baaec739-c5cf-4920-b448-c0b9c5431410","status":200,"result":{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"assets":[{"asset":"WLD","walletBalance":"0.00000000","unrealizedProfit":"0.00000000","marginBalance":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","maxWithdrawAmount":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}],"positions":[{"symbol":"ETHUSD_220930","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"7","isolated":false,"positionSide":"BOTH","entryPrice":"0.00000000","maxQty":"1000","notionalValue":"0","isolatedWallet":"0","updateTime":0,"positionAmt":"0","breakEvenPrice":"0.00000000"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":10}]}""""";
        const string result = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"assets":[{"asset":"WLD","walletBalance":"0.00000000","unrealizedProfit":"0.00000000","marginBalance":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","maxWithdrawAmount":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}],"positions":[{"symbol":"ETHUSD_220930","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"7","isolated":false,"positionSide":"BOTH","entryPrice":"0.00000000","maxQty":"1000","notionalValue":"0","isolatedWallet":"0","updateTime":0,"positionAmt":"0","breakEvenPrice":"0.00000000"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        const string envelope = """""{"id":"baaec739-c5cf-4920-b448-c0b9c5431410","status":200,"result":{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"assets":[{"asset":"WLD","walletBalance":"0.00000000","unrealizedProfit":"0.00000000","marginBalance":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","maxWithdrawAmount":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}],"positions":[{"symbol":"ETHUSD_220930","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"7","isolated":false,"positionSide":"BOTH","entryPrice":"0.00000000","maxQty":"1000","notionalValue":"0","isolatedWallet":"0","updateTime":0,"positionAmt":"0","breakEvenPrice":"0.00000000"}]},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":10}]}""""";
        const string result = """""{"feeTier":0,"canTrade":true,"canDeposit":true,"canWithdraw":true,"updateTime":0,"assets":[{"asset":"WLD","walletBalance":"0.00000000","unrealizedProfit":"0.00000000","marginBalance":"0.00000000","maintMargin":"0.00000000","initialMargin":"0.00000000","positionInitialMargin":"0.00000000","openOrderInitialMargin":"0.00000000","maxWithdrawAmount":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}],"positions":[{"symbol":"ETHUSD_220930","initialMargin":"0","maintMargin":"0","unrealizedProfit":"0.00000000","positionInitialMargin":"0","openOrderInitialMargin":"0","leverage":"7","isolated":false,"positionSide":"BOTH","entryPrice":"0.00000000","maxQty":"1000","notionalValue":"0","isolatedWallet":"0","updateTime":0,"positionAmt":"0","breakEvenPrice":"0.00000000"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
    public async Task FuturesAccountBalanceAsync()
    {
        const string envelope = """""{"id":"9328e612-1560-4108-979e-283bf85b5acb","status":200,"result":[{"accountAlias":"fWAuTiuXoCuXmY","asset":"WLD","balance":"0.00000000","withdrawAvailable":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":10}]}""""";
        const string result = """""[{"accountAlias":"fWAuTiuXoCuXmY","asset":"WLD","balance":"0.00000000","withdrawAvailable":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        const string envelope = """""{"id":"9328e612-1560-4108-979e-283bf85b5acb","status":200,"result":[{"accountAlias":"fWAuTiuXoCuXmY","asset":"WLD","balance":"0.00000000","withdrawAvailable":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":10}]}""""";
        const string result = """""[{"accountAlias":"fWAuTiuXoCuXmY","asset":"WLD","balance":"0.00000000","withdrawAvailable":"0.00000000","crossWalletBalance":"0.00000000","crossUnPnl":"0.00000000","availableBalance":"0.00000000","updateTime":0}]""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
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
        await using var client = await new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.FuturesAccountBalanceAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
