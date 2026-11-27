//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

namespace Binance.DerivativesTradingUsdsFutures.Tests.WebSocketStreams.PublicApi;

[Trait("Category", "Native")]
public class PublicApiTests
{
    [Fact]
    public async Task AllBookTickersStream()
    {
        const string example = """""{"e":"bookTicker","u":400900217,"E":1568014460893,"T":1568014460891,"s":"BNBUSDT","b":"25.35190000","B":"31.21000000","a":"25.36520000","A":"40.66000000","ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllBookTickersStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllBookTickersStreamWithOptionalParameters()
    {
        const string example = """""{"e":"bookTicker","u":400900217,"E":1568014460893,"T":1568014460891,"s":"BNBUSDT","b":"25.35190000","B":"31.21000000","a":"25.36520000","A":"40.66000000","ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllBookTickersStreamRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AllBookTickersStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task DiffBookDepthStreams()
    {
        const string example = """""{"e":"depthUpdate","E":123456789,"T":123456788,"s":"BNBUSDT","U":157,"u":160,"pu":149,"b":[["0.0024","10"]],"a":[["0.0026","100"]],"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new DiffBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.DiffBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@depth", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task DiffBookDepthStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":123456789,"T":123456788,"s":"BNBUSDT","U":157,"u":160,"pu":149,"b":[["0.0024","10"]],"a":[["0.0026","100"]],"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new DiffBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
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
    public async Task IndividualSymbolBookTickerStreams()
    {
        const string example = """""{"e":"bookTicker","u":400900217,"E":1568014460893,"T":1568014460891,"s":"BNBUSDT","ps":"BNBUSDT","b":"25.35190000","B":"31.21000000","a":"25.36520000","A":"40.66000000","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"bookTicker","u":400900217,"E":1568014460893,"T":1568014460891,"s":"BNBUSDT","ps":"BNBUSDT","b":"25.35190000","B":"31.21000000","a":"25.36520000","A":"40.66000000","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndividualSymbolBookTickerStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
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
        const string example = """""{"e":"depthUpdate","E":1571889248277,"T":1571889248276,"s":"BTCUSDT","U":390497796,"u":390497878,"pu":390497794,"b":[["7403.89"]],"a":[["7405.96"]],"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            Levels = PartialBookDepthStreamsLevels.Levels5,
        };

        using var subscription = client.PartialBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@depth5", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialBookDepthStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":1571889248277,"T":1571889248276,"s":"BTCUSDT","U":390497796,"u":390497878,"pu":390497794,"b":[["7403.89"]],"a":[["7405.96"]],"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            Levels = PartialBookDepthStreamsLevels.Levels5,
            Id = "e9d6b4349871b40611412680b3445fac",
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
    public async Task RpiDiffBookDepthStreams()
    {
        const string example = """""{"e":"depthUpdate","E":123456789,"T":123456788,"s":"BNBUSDT","U":157,"u":160,"pu":149,"b":[["0.0024","10"]],"a":[["0.0026","100"]],"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new RpiDiffBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.RpiDiffBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@rpiDepth@500ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task RpiDiffBookDepthStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":123456789,"T":123456788,"s":"BNBUSDT","U":157,"u":160,"pu":149,"b":[["0.0024","10"]],"a":[["0.0026","100"]],"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new RpiDiffBookDepthStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.RpiDiffBookDepthStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@rpiDepth@500ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
