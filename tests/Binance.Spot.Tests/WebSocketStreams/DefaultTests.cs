//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Spot.WebSocketStreams;

namespace Binance.Spot.Tests.WebSocketStreams;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    [Fact]
    public async Task AggTrade()
    {
        const string example = """""{"e":"aggTrade","E":1672515782136,"s":"BNBBTC","a":12345,"p":"0.001","q":"100","f":100,"l":105,"T":1672515782136,"m":true,"M":true}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AggTradeRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.AggTrade(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@aggTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AggTradeWithOptionalParameters()
    {
        const string example = """""{"e":"aggTrade","E":1672515782136,"s":"BNBBTC","a":12345,"p":"0.001","q":"100","f":100,"l":105,"T":1672515782136,"m":true,"M":true}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AggTradeRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AggTrade(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@aggTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMarketRollingWindowTicker()
    {
        const string example = """""[{"e":"1hTicker","E":1672515782136,"s":"BNBBTC","p":"0.0015","P":"250.00","o":"0.0010","h":"0.0025","l":"0.0010","c":"0.0025","w":"0.0018","v":"10000","q":"18","O":0,"C":1675216573749,"F":0,"L":18150,"n":18151}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllMarketRollingWindowTickerRequest
        {
            WindowSize = AllMarketRollingWindowTickerWindowSize.WindowSize1h,
        };

        using var subscription = client.AllMarketRollingWindowTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!ticker_1h@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMarketRollingWindowTickerWithOptionalParameters()
    {
        const string example = """""[{"e":"1hTicker","E":1672515782136,"s":"BNBBTC","p":"0.0015","P":"250.00","o":"0.0010","h":"0.0025","l":"0.0010","c":"0.0025","w":"0.0018","v":"10000","q":"18","O":0,"C":1675216573749,"F":0,"L":18150,"n":18151}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllMarketRollingWindowTickerRequest
        {
            WindowSize = AllMarketRollingWindowTickerWindowSize.WindowSize1h,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AllMarketRollingWindowTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!ticker_1h@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMiniTicker()
    {
        const string example = """""[{"e":"24hrMiniTicker","E":1672515782136,"s":"BNBBTC","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllMiniTicker();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!miniTicker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMiniTickerWithOptionalParameters()
    {
        const string example = """""[{"e":"24hrMiniTicker","E":1672515782136,"s":"BNBBTC","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllMiniTickerRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AllMiniTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!miniTicker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AvgPrice()
    {
        const string example = """""{"e":"avgPrice","E":1693907033000,"s":"BTCUSDT","i":"5m","w":"25776.86000000","T":1693907032213}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AvgPriceRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.AvgPrice(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@avgPrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AvgPriceWithOptionalParameters()
    {
        const string example = """""{"e":"avgPrice","E":1693907033000,"s":"BTCUSDT","i":"5m","w":"25776.86000000","T":1693907032213}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AvgPriceRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AvgPrice(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@avgPrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task BlockTrade()
    {
        const string example = """""{"e":"blockTrade","E":1772506983582,"s":"BNBBTC","t":582,"p":"0.052","q":"5838","T":1772506983321,"m":true}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new BlockTradeRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.BlockTrade(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@blockTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task BlockTradeWithOptionalParameters()
    {
        const string example = """""{"e":"blockTrade","E":1772506983582,"s":"BNBBTC","t":582,"p":"0.052","q":"5838","T":1772506983321,"m":true}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new BlockTradeRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.BlockTrade(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@blockTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task BookTicker()
    {
        const string example = """""{"u":400900217,"s":"BNBUSDT","b":"25.35190000","B":"31.21000000","a":"25.36520000","A":"40.66000000"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new BookTickerRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.BookTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task BookTickerWithOptionalParameters()
    {
        const string example = """""{"u":400900217,"s":"BNBUSDT","b":"25.35190000","B":"31.21000000","a":"25.36520000","A":"40.66000000"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new BookTickerRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.BookTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task DiffBookDepth()
    {
        const string example = """""{"e":"depthUpdate","E":1672515782136,"s":"BNBBTC","U":157,"u":160,"b":[["0.0024","10"]],"a":[["0.0026","100"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new DiffBookDepthRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.DiffBookDepth(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@depth", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task DiffBookDepthWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":1672515782136,"s":"BNBBTC","U":157,"u":160,"b":[["0.0024","10"]],"a":[["0.0026","100"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new DiffBookDepthRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
            UpdateSpeed = DiffBookDepthUpdateSpeed.UpdateSpeed100ms,
        };

        using var subscription = client.DiffBookDepth(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@depth@100ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task Kline()
    {
        const string example = """""{"e":"kline","E":1672515782136,"s":"BNBBTC","k":{"t":1672515780000,"T":1672515839999,"s":"BNBBTC","i":"1m","f":100,"L":200,"o":"0.0010","c":"0.0020","h":"0.0025","l":"0.0015","v":"1000","n":100,"x":false,"q":"1.0000","V":"500","Q":"0.500","B":"123456"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineRequest
        {
            Symbol = "bnbusdt",
            Interval = KlineInterval.Interval1s,
        };

        using var subscription = client.Kline(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@kline_1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineWithOptionalParameters()
    {
        const string example = """""{"e":"kline","E":1672515782136,"s":"BNBBTC","k":{"t":1672515780000,"T":1672515839999,"s":"BNBBTC","i":"1m","f":100,"L":200,"o":"0.0010","c":"0.0020","h":"0.0025","l":"0.0015","v":"1000","n":100,"x":false,"q":"1.0000","V":"500","Q":"0.500","B":"123456"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineRequest
        {
            Symbol = "bnbusdt",
            Interval = KlineInterval.Interval1s,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.Kline(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@kline_1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineOffset()
    {
        const string example = """""{"e":"kline","E":1672515782136,"s":"BNBBTC","k":{"t":1672515780000,"T":1672515839999,"s":"BNBBTC","i":"1m","f":100,"L":200,"o":"0.0010","c":"0.0020","h":"0.0025","l":"0.0015","v":"1000","n":100,"x":false,"q":"1.0000","V":"500","Q":"0.500","B":"123456"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineOffsetRequest
        {
            Symbol = "bnbusdt",
            Interval = KlineOffsetInterval.Interval1s,
        };

        using var subscription = client.KlineOffset(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@kline_1s@+08:00", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineOffsetWithOptionalParameters()
    {
        const string example = """""{"e":"kline","E":1672515782136,"s":"BNBBTC","k":{"t":1672515780000,"T":1672515839999,"s":"BNBBTC","i":"1m","f":100,"L":200,"o":"0.0010","c":"0.0020","h":"0.0025","l":"0.0015","v":"1000","n":100,"x":false,"q":"1.0000","V":"500","Q":"0.500","B":"123456"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineOffsetRequest
        {
            Symbol = "bnbusdt",
            Interval = KlineOffsetInterval.Interval1s,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.KlineOffset(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@kline_1s@+08:00", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MiniTicker()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1672515782136,"s":"BNBBTC","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MiniTickerRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.MiniTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@miniTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MiniTickerWithOptionalParameters()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1672515782136,"s":"BNBBTC","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MiniTickerRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.MiniTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@miniTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialBookDepth()
    {
        const string example = """""{"lastUpdateId":160,"bids":[["0.0024","10"]],"asks":[["0.0026","100"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialBookDepthRequest
        {
            Symbol = "bnbusdt",
            Levels = PartialBookDepthLevels.Levels5,
        };

        using var subscription = client.PartialBookDepth(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@depth5", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialBookDepthWithOptionalParameters()
    {
        const string example = """""{"lastUpdateId":160,"bids":[["0.0024","10"]],"asks":[["0.0026","100"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialBookDepthRequest
        {
            Symbol = "bnbusdt",
            Levels = PartialBookDepthLevels.Levels5,
            Id = "e9d6b4349871b40611412680b3445fac",
            UpdateSpeed = PartialBookDepthUpdateSpeed.UpdateSpeed100ms,
        };

        using var subscription = client.PartialBookDepth(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@depth5@100ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ReferencePrice()
    {
        const string example = """""{"e":"referencePrice","s":"BAZUSD","r":"1.00","t":1770313263917}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ReferencePriceRequest
        {
            Symbol = "bazusd",
        };

        using var subscription = client.ReferencePrice(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bazusd@referencePrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ReferencePriceWithOptionalParameters()
    {
        const string example = """""{"e":"referencePrice","s":"BAZUSD","r":"1.00","t":1770313263917}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ReferencePriceRequest
        {
            Symbol = "bazusd",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.ReferencePrice(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bazusd@referencePrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task RollingWindowTicker()
    {
        const string example = """""{"e":"1hTicker","E":1672515782136,"s":"BNBBTC","p":"0.0015","P":"250.00","o":"0.0010","h":"0.0025","l":"0.0010","c":"0.0025","w":"0.0018","v":"10000","q":"18","O":0,"C":1675216573749,"F":0,"L":18150,"n":18151}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new RollingWindowTickerRequest
        {
            Symbol = "bnbusdt",
            WindowSize = RollingWindowTickerWindowSize.WindowSize1h,
        };

        using var subscription = client.RollingWindowTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@ticker_1h", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task RollingWindowTickerWithOptionalParameters()
    {
        const string example = """""{"e":"1hTicker","E":1672515782136,"s":"BNBBTC","p":"0.0015","P":"250.00","o":"0.0010","h":"0.0025","l":"0.0010","c":"0.0025","w":"0.0018","v":"10000","q":"18","O":0,"C":1675216573749,"F":0,"L":18150,"n":18151}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new RollingWindowTickerRequest
        {
            Symbol = "bnbusdt",
            WindowSize = RollingWindowTickerWindowSize.WindowSize1h,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.RollingWindowTicker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@ticker_1h", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task Ticker()
    {
        const string example = """""{"e":"24hrTicker","E":1672515782136,"s":"BNBBTC","p":"0.0015","P":"250.00","w":"0.0018","x":"0.0009","c":"0.0025","Q":"10","b":"0.0024","B":"10","a":"0.0026","A":"100","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","O":0,"C":1675216573749,"F":0,"L":18150,"n":18151}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TickerRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.Ticker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@ticker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TickerWithOptionalParameters()
    {
        const string example = """""{"e":"24hrTicker","E":1672515782136,"s":"BNBBTC","p":"0.0015","P":"250.00","w":"0.0018","x":"0.0009","c":"0.0025","Q":"10","b":"0.0024","B":"10","a":"0.0026","A":"100","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","O":0,"C":1675216573749,"F":0,"L":18150,"n":18151}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TickerRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.Ticker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@ticker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task Trade()
    {
        const string example = """""{"e":"trade","E":1672515782136,"s":"BNBBTC","t":12345,"p":"0.001","q":"100","T":1672515782136,"m":true,"M":true}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradeRequest
        {
            Symbol = "bnbusdt",
        };

        using var subscription = client.Trade(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@trade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradeWithOptionalParameters()
    {
        const string example = """""{"e":"trade","E":1672515782136,"s":"BNBBTC","t":12345,"p":"0.001","q":"100","T":1672515782136,"m":true,"M":true}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new SpotWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradeRequest
        {
            Symbol = "bnbusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.Trade(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("bnbusdt@trade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
