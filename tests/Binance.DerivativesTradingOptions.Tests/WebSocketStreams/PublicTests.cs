//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingOptions.WebSocketStreams;

namespace Binance.DerivativesTradingOptions.Tests.WebSocketStreams.PublicApi;

[Trait("Category", "Native")]
public class PublicApiTests
{
    [Fact]
    public async Task DiffBookDepthStreams()
    {
        const string example = """""{"e":"depthUpdate","E":1762866729459,"T":1762866729358,"s":"BTC-251123-126000-C","U":465,"u":465,"pu":464,"b":[["1100.000","0.6000"]],"a":[["1300.000","0.6000"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new DiffBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            UpdateSpeed = DiffBookDepthStreamsUpdateSpeed.UpdateSpeed100ms,
        };

        using var subscription = client.DiffBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@depth@100ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task DiffBookDepthStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":1762866729459,"T":1762866729358,"s":"BTC-251123-126000-C","U":465,"u":465,"pu":464,"b":[["1100.000","0.6000"]],"a":[["1300.000","0.6000"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new DiffBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            UpdateSpeed = DiffBookDepthStreamsUpdateSpeed.UpdateSpeed100ms,
            Id = 532601580L,
        };

        using var subscription = client.DiffBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@depth@100ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task Hour24Ticker()
    {
        const string example = """""{"e":"24hrTicker","E":1764080707933,"s":"ETH-251226-3000-C","p":"0.0000","P":"0.00","w":"200.0000","c":"200.0000","Q":"1.0000","o":"200.0000","h":"200.0000","l":"200.0000","v":"9.0000","q":"1800.0000","O":1764051060000,"C":1764080707933,"F":1,"L":22,"n":9}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new Hour24TickerRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.Hour24Ticker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task Hour24TickerWithOptionalParameters()
    {
        const string example = """""{"e":"24hrTicker","E":1764080707933,"s":"ETH-251226-3000-C","p":"0.0000","P":"0.00","w":"200.0000","c":"200.0000","Q":"1.0000","o":"200.0000","h":"200.0000","l":"200.0000","v":"9.0000","q":"1800.0000","O":1764051060000,"C":1764080707933,"F":1,"L":22,"n":9}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new Hour24TickerRequest
        {
            Symbol = "btcusdt",
            Id = 532601580L,
            ExpirationDate = "251230",
        };

        using var subscription = client.Hour24Ticker(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionTicker251230", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndividualSymbolBookTickerStreams()
    {
        const string example = """""{"e":"bookTicker","u":2472,"s":"BTC-251226-110000-C","b":"5000.000","B":"0.2000","a":"5100.000","A":"0.1000","T":1763041762942,"E":1763041762942}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndividualSymbolBookTickerStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.IndividualSymbolBookTickerStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndividualSymbolBookTickerStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"bookTicker","u":2472,"s":"BTC-251226-110000-C","b":"5000.000","B":"0.2000","a":"5100.000","A":"0.1000","T":1763041762942,"E":1763041762942}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndividualSymbolBookTickerStreamsRequest
        {
            Symbol = "btcusdt",
            Id = 532601580L,
        };

        using var subscription = client.IndividualSymbolBookTickerStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialBookDepthStreams()
    {
        const string example = """""{"e":"depthUpdate","E":1762866729459,"T":1762866729358,"s":"BTC-251123-126000-C","U":465,"u":465,"pu":464,"b":[["1100.000"]],"a":[["1300.000"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            Level = PartialBookDepthStreamsLevel.Level5,
            UpdateSpeed = PartialBookDepthStreamsUpdateSpeed.UpdateSpeed100ms,
        };

        using var subscription = client.PartialBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@depth5@100ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialBookDepthStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":1762866729459,"T":1762866729358,"s":"BTC-251123-126000-C","U":465,"u":465,"pu":464,"b":[["1100.000"]],"a":[["1300.000"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            Level = PartialBookDepthStreamsLevel.Level5,
            UpdateSpeed = PartialBookDepthStreamsUpdateSpeed.UpdateSpeed100ms,
            Id = 532601580L,
        };

        using var subscription = client.PartialBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@depth5@100ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradeStreams()
    {
        const string example = """""{"e":"trade","E":1762856064204,"T":1762856064203,"s":"BTC-251123-126000-C","t":4,"p":"1300.000","q":"0.1000","X":"MARKET","S":"BUY","m":false}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradeStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.TradeStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradeStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"trade","E":1762856064204,"T":1762856064203,"s":"BTC-251123-126000-C","t":4,"p":"1300.000","q":"0.1000","X":"MARKET","S":"BUY","m":false}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradeStreamsRequest
        {
            Symbol = "btcusdt",
            Id = 532601580L,
        };

        using var subscription = client.TradeStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
