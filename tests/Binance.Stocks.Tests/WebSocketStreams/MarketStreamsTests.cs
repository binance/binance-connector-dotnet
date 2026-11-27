//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Stocks.WebSocketStreams;

namespace Binance.Stocks.Tests.WebSocketStreams.MarketStreams;

[Trait("Category", "Native")]
public class MarketStreamsApiTests
{
    [Fact]
    public async Task CalendarStream()
    {
        const string example = """""{"e":"calendar","from":"PRE_MARKET","to":"MARKET_OPEN","ts":1710334200000}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.CalendarStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("calendar", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task CalendarStreamWithOptionalParameters()
    {
        const string example = """""{"e":"calendar","from":"PRE_MARKET","to":"MARKET_OPEN","ts":1710334200000}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new CalendarStreamRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.CalendarStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("calendar", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineStream()
    {
        const string example = """""{"e":"kline","E":1710320400000,"s":"AAPL","k":{"t":1710316800000,"ct":1710317099999,"s":"AAPL","i":"5m","o":"182.50","c":"183.20","h":"183.50","l":"182.30","v":"15000","n":120,"x":false,"vw":"182.95"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineStreamRequest
        {
            Symbol = "AAPL",
            Interval = "5m",
        };

        using var subscription = client.KlineStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@kline_5m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineStreamWithOptionalParameters()
    {
        const string example = """""{"e":"kline","E":1710320400000,"s":"AAPL","k":{"t":1710316800000,"ct":1710317099999,"s":"AAPL","i":"5m","o":"182.50","c":"183.20","h":"183.50","l":"182.30","v":"15000","n":120,"x":false,"vw":"182.95"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineStreamRequest
        {
            Symbol = "AAPL",
            Interval = "5m",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.KlineStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@kline_5m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PriceStream()
    {
        const string example = """""{"e":"price","rates":[{"s":"AAPL","ac":"EQ_AAPL","p":"182.5","t":1710320400000,"pc":"181.2000","tc":"182.0000","lrc":"182.0000","prc":"181.2000","mp":"O"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.PriceStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("price", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PriceStreamWithOptionalParameters()
    {
        const string example = """""{"e":"price","rates":[{"s":"AAPL","ac":"EQ_AAPL","p":"182.5","t":1710320400000,"pc":"181.2000","tc":"182.0000","lrc":"182.0000","prc":"181.2000","mp":"O"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PriceStreamRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.PriceStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("price", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task QuoteStream()
    {
        const string example = """""{"e":"quote","E":1710320400000,"s":"AAPL","bp":"182.50","ap":"182.55","bs":100,"as":200,"T":1710320399500}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new QuoteStreamRequest
        {
            Symbol = "AAPL",
        };

        using var subscription = client.QuoteStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@quote", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task QuoteStreamWithOptionalParameters()
    {
        const string example = """""{"e":"quote","E":1710320400000,"s":"AAPL","bp":"182.50","ap":"182.55","bs":100,"as":200,"T":1710320399500}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new QuoteStreamRequest
        {
            Symbol = "AAPL",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.QuoteStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@quote", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradabilityStream()
    {
        const string example = """""{"e":"tradability","symbol":"AAPL","assetCode":"EQ_AAPL","tradability":"BUY_SELL","t":1712345678000}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradabilityStreamRequest
        {
            Symbol = "AAPL",
        };

        using var subscription = client.TradabilityStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@tradability", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradabilityStreamWithOptionalParameters()
    {
        const string example = """""{"e":"tradability","symbol":"AAPL","assetCode":"EQ_AAPL","tradability":"BUY_SELL","t":1712345678000}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradabilityStreamRequest
        {
            Symbol = "AAPL",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.TradabilityStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@tradability", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradingStatusStream()
    {
        const string example = """""{"e":"tradingStatus","symbol":"AAPL","assetCode":"EQ_AAPL","status":"TRADING_HALTED","msg":"MATERIAL_NEWS","time":1614021300000,"z":"C","tradability":"NONE"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradingStatusStreamRequest
        {
            Symbol = "AAPL",
        };

        using var subscription = client.TradingStatusStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@tradingStatus", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradingStatusStreamWithOptionalParameters()
    {
        const string example = """""{"e":"tradingStatus","symbol":"AAPL","assetCode":"EQ_AAPL","status":"TRADING_HALTED","msg":"MATERIAL_NEWS","time":1614021300000,"z":"C","tradability":"NONE"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradingStatusStreamRequest
        {
            Symbol = "AAPL",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.TradingStatusStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("AAPL@tradingStatus", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
