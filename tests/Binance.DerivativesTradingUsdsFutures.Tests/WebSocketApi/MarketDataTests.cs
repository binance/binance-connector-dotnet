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

namespace Binance.DerivativesTradingUsdsFutures.Tests.WebSocketApi.MarketData;

[Trait("Category", "Native")]
public class MarketDataApiTests
{
    [Fact]
    public async Task OrderBookAsync()
    {
        const string envelope = """""{"id":"51e2affb-0aba-4821-ba75-f2625006eb43","status":200,"result":{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959},"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":5}]}""""";
        const string result = """""{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderBookRequest
        {
            Symbol = "BTCUSDT",
        };

        var response = await client.OrderBookAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("depth", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderBookWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"51e2affb-0aba-4821-ba75-f2625006eb43","status":200,"result":{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959},"bids":[["4.00000000","431.00000000"]],"asks":[["4.00000200","12.00000000"]],"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":5}]}""""";
        const string result = """""{"lastUpdateId":1027024,"E":1589436922972,"T":1589436922959}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new OrderBookRequest
        {
            Symbol = "BTCUSDT",
            Id = "0123456789abcdef0123456789abcdef",
            Limit = 10L,
        };

        var response = await client.OrderBookAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("depth", frame.Method);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("10", frame.Param("limit"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task OrderBookBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();
        var request = new OrderBookRequest
        {
            Symbol = "BTCUSDT",
        };

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.OrderBookAsync(request));

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SymbolOrderBookTickerAsync()
    {
        const string envelope = """""{"id":"9d32157c-a556-4d27-9866-66760a174b57","status":200,"result":{"lastUpdateId":1027024,"symbol":"BTCUSDT","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000","time":1589437530011},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"lastUpdateId":1027024,"symbol":"BTCUSDT","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000","time":1589437530011}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.SymbolOrderBookTickerAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ticker.book", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SymbolOrderBookTickerWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"9d32157c-a556-4d27-9866-66760a174b57","status":200,"result":{"lastUpdateId":1027024,"symbol":"BTCUSDT","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000","time":1589437530011},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"lastUpdateId":1027024,"symbol":"BTCUSDT","bidPrice":"4.00000000","bidQty":"431.00000000","askPrice":"4.00000200","askQty":"9.00000000","time":1589437530011}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SymbolOrderBookTickerRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BTCUSDT",
        };

        var response = await client.SymbolOrderBookTickerAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ticker.book", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SymbolOrderBookTickerBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SymbolOrderBookTickerAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }

    [Fact]
    public async Task SymbolPriceTickerAsync()
    {
        const string envelope = """""{"id":"9d32157c-a556-4d27-9866-66760a174b57","status":200,"result":{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var response = await client.SymbolPriceTickerAsync();

        var frame = server.ApiRequest();
        Assert.Equal("ticker.price", frame.Method);

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SymbolPriceTickerWithOptionalParametersAsync()
    {
        const string envelope = """""{"id":"9d32157c-a556-4d27-9866-66760a174b57","status":200,"result":{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011},"rateLimits":[{"rateLimitType":"REQUEST_WEIGHT","interval":"MINUTE","intervalNum":1,"limit":2400,"count":2}]}""""";
        const string result = """""{"symbol":"BTCUSDT","price":"6000.01","time":1589437530011}""""";

        using var server = new MiniWsServer(MiniWsServer.ApiReplies(envelope));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var request = new SymbolPriceTickerRequest
        {
            Id = "0123456789abcdef0123456789abcdef",
            Symbol = "BTCUSDT",
        };

        var response = await client.SymbolPriceTickerAsync(request);

        var frame = server.ApiRequest();
        Assert.Equal("ticker.price", frame.Method);
        Assert.Equal("0123456789abcdef0123456789abcdef", frame.Id);
        Assert.Equal("BTCUSDT", frame.Param("symbol"));

        ExampleAssert.Matches(result, response.Data());
    }

    [Fact]
    public async Task SymbolPriceTickerBadRequestAsync()
    {
        using var server = new MiniWsServer(MiniWsServer.ApiErrors(400, -1102));
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = server.Url,
            ApiKey = "test-key",
            ApiSecret = "test-secret",
        }).ConnectAsync();

        var error = await Assert.ThrowsAsync<BinanceWebSocketResponseException>(() => client.SymbolPriceTickerAsync());

        Assert.Equal(400, error.HttpStatus);
        Assert.Equal(-1102, error.Code);
    }
}
