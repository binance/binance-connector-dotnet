//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.DerivativesTradingCoinFutures.WebSocketStreams;

namespace Binance.DerivativesTradingCoinFutures.Tests.WebSocketStreams;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    [Fact]
    public async Task AggregateTradeStreams()
    {
        const string example = """""{"e":"aggTrade","E":1591261134288,"a":424951,"s":"BTCUSD_200626","p":"9643.5","q":"2","f":606073,"l":606073,"T":1591261134199,"m":false,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AggregateTradeStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.AggregateTradeStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@aggTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AggregateTradeStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"aggTrade","E":1591261134288,"a":424951,"s":"BTCUSD_200626","p":"9643.5","q":"2","f":606073,"l":606073,"T":1591261134199,"m":false,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AggregateTradeStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AggregateTradeStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@aggTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllBookTickersStream()
    {
        const string example = """""{"e":"bookTicker","u":17242169,"s":"BTCUSD_200626","b":"9548.1","B":"52","a":"9548.5","A":"11","T":1591268628155,"E":1591268628166,"ps":"BTCUSD","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"bookTicker","u":17242169,"s":"BTCUSD_200626","b":"9548.1","B":"52","a":"9548.5","A":"11","T":1591268628155,"E":1591268628166,"ps":"BTCUSD","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task AllMarketLiquidationOrderStreams()
    {
        const string example = """""{"e":"forceOrder","E":1591154240950,"o":{"s":"BTCUSD_200925","ps":"BTCUSD","S":"SELL","o":"LIMIT","f":"IOC","q":"1","p":"9425.5","ap":"9496.5","X":"FILLED","l":"1","z":"1","T":1591154240949},"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllMarketLiquidationOrderStreams();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!forceOrder@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMarketLiquidationOrderStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"forceOrder","E":1591154240950,"o":{"s":"BTCUSD_200925","ps":"BTCUSD","S":"SELL","o":"LIMIT","f":"IOC","q":"1","p":"9425.5","ap":"9496.5","X":"FILLED","l":"1","z":"1","T":1591154240949},"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllMarketLiquidationOrderStreamsRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AllMarketLiquidationOrderStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!forceOrder@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMarketMiniTickersStream()
    {
        const string example = """""[{"e":"24hrMiniTicker","E":1591267704450,"s":"BTCUSD_200626","ps":"BTCUSD","c":"9561.7","o":"9580.9","h":"10000.0","l":"7000.0","v":"487476","q":"33264343847.22378500","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllMarketMiniTickersStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!miniTicker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMarketMiniTickersStreamWithOptionalParameters()
    {
        const string example = """""[{"e":"24hrMiniTicker","E":1591267704450,"s":"BTCUSD_200626","ps":"BTCUSD","c":"9561.7","o":"9580.9","h":"10000.0","l":"7000.0","v":"487476","q":"33264343847.22378500","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllMarketMiniTickersStreamRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AllMarketMiniTickersStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!miniTicker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMarketTickersStreams()
    {
        const string example = """""[{"e":"24hrTicker","E":1591268262453,"s":"BTCUSD_200626","p":"-43.4","P":"-0.452","w":"0.00147974","c":"9548.5","Q":"2","o":"9591.9","h":"10000.0","l":"7000.0","v":"487850","q":"32968676323.46222700","O":1591181820000,"C":1591268262442,"F":512014,"L":615289,"n":103272,"ps":"BTCUSD","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllMarketTickersStreams();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!ticker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMarketTickersStreamsWithOptionalParameters()
    {
        const string example = """""[{"e":"24hrTicker","E":1591268262453,"s":"BTCUSD_200626","p":"-43.4","P":"-0.452","w":"0.00147974","c":"9548.5","Q":"2","o":"9591.9","h":"10000.0","l":"7000.0","v":"487850","q":"32968676323.46222700","O":1591181820000,"C":1591268262442,"F":512014,"L":615289,"n":103272,"ps":"BTCUSD","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllMarketTickersStreamsRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AllMarketTickersStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!ticker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickStreams()
    {
        const string example = """""{"e":"continuous_kline","E":1591261542539,"ps":"BTCUSD","ct":"NEXT_QUARTER","k":{"t":1591261500000,"T":1591261559999,"i":"1m","f":606400,"L":606430,"o":"9638.9","c":"9639.8","h":"9639.8","l":"9638.6","v":"156","n":31,"x":false,"q":"1.61836886","V":"73","Q":"0.75731156","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ContinuousContractKlineCandlestickStreamsRequest
        {
            Pair = "btcusdt",
            ContractType = ContinuousContractKlineCandlestickStreamsContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickStreamsInterval.Interval1m,
        };

        using var subscription = client.ContinuousContractKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt_perpetual@continuousKline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"continuous_kline","E":1591261542539,"ps":"BTCUSD","ct":"NEXT_QUARTER","k":{"t":1591261500000,"T":1591261559999,"i":"1m","f":606400,"L":606430,"o":"9638.9","c":"9639.8","h":"9639.8","l":"9638.6","v":"156","n":31,"x":false,"q":"1.61836886","V":"73","Q":"0.75731156","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ContinuousContractKlineCandlestickStreamsRequest
        {
            Pair = "btcusdt",
            ContractType = ContinuousContractKlineCandlestickStreamsContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickStreamsInterval.Interval1m,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.ContinuousContractKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt_perpetual@continuousKline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContractInfoStream()
    {
        const string example = """""{"e":"contractInfo","E":1669647330375,"s":"APTUSD_PERP","ps":"APTUSD","ct":"PERPETUAL","dt":4133404800000,"ot":1666594800000,"cs":"TRADING","bks":[{"bs":1,"bnf":0,"bnc":500000,"mmr":0.0065,"cf":75,"mi":51,"ma":75}],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.ContractInfoStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!contractInfo", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContractInfoStreamWithOptionalParameters()
    {
        const string example = """""{"e":"contractInfo","E":1669647330375,"s":"APTUSD_PERP","ps":"APTUSD","ct":"PERPETUAL","dt":4133404800000,"ot":1666594800000,"cs":"TRADING","bks":[{"bs":1,"bnf":0,"bnc":500000,"mmr":0.0065,"cf":75,"mi":51,"ma":75}],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ContractInfoStreamRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.ContractInfoStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!contractInfo", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task DiffBookDepthStreams()
    {
        const string example = """""{"e":"depthUpdate","E":1591270260907,"T":1591270260891,"s":"BTCUSD_200626","ps":"BTCUSD","U":17285681,"u":17285702,"pu":17285675,"b":[["9517.6","10"]],"a":[["9518.5","45"]],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"depthUpdate","E":1591270260907,"T":1591270260891,"s":"BTCUSD_200626","ps":"BTCUSD","U":17285681,"u":17285702,"pu":17285675,"b":[["9517.6","10"]],"a":[["9518.5","45"]],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task IndexKlineCandlestickStreams()
    {
        const string example = """""{"e":"indexPrice_kline","E":1591267070033,"ps":"BTCUSD","k":{"t":1591267020000,"T":1591267079999,"s":"0","i":"1m","f":1591267020000,"L":1591267070000,"o":"9542.21900000","c":"9542.50440000","h":"9542.71640000","l":"9542.21040000","v":"0","n":51,"x":false,"q":"0","V":"0","Q":"0","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndexKlineCandlestickStreamsRequest
        {
            Pair = "btcusdt",
            Interval = IndexKlineCandlestickStreamsInterval.Interval1m,
        };

        using var subscription = client.IndexKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@indexPriceKline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndexKlineCandlestickStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"indexPrice_kline","E":1591267070033,"ps":"BTCUSD","k":{"t":1591267020000,"T":1591267079999,"s":"0","i":"1m","f":1591267020000,"L":1591267070000,"o":"9542.21900000","c":"9542.50440000","h":"9542.71640000","l":"9542.21040000","v":"0","n":51,"x":false,"q":"0","V":"0","Q":"0","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndexKlineCandlestickStreamsRequest
        {
            Pair = "btcusdt",
            Interval = IndexKlineCandlestickStreamsInterval.Interval1m,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.IndexKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@indexPriceKline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndexPriceStream()
    {
        const string example = """""{"e":"indexPriceUpdate","E":1591261236000,"i":"BTCUSD","p":"9636.57860000"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndexPriceStreamRequest
        {
            Pair = "btcusdt",
        };

        using var subscription = client.IndexPriceStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@indexPrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndexPriceStreamWithOptionalParameters()
    {
        const string example = """""{"e":"indexPriceUpdate","E":1591261236000,"i":"BTCUSD","p":"9636.57860000"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndexPriceStreamRequest
        {
            Pair = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
            UpdateSpeed = IndexPriceStreamUpdateSpeed.UpdateSpeed1s,
        };

        using var subscription = client.IndexPriceStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@indexPrice@1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndividualSymbolBookTickerStreams()
    {
        const string example = """""{"e":"bookTicker","u":17242169,"s":"BTCUSD_200626","b":"9548.1","B":"52","a":"9548.5","A":"11","T":1591268628155,"E":1591268628166,"ps":"BTCUSD","st":2}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"bookTicker","u":17242169,"s":"BTCUSD_200626","b":"9548.1","B":"52","a":"9548.5","A":"11","T":1591268628155,"E":1591268628166,"ps":"BTCUSD","st":2}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task IndividualSymbolMiniTickerStream()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1591267704450,"s":"BTCUSD_200626","ps":"BTCUSD","c":"9561.7","o":"9580.9","h":"10000.0","l":"7000.0","v":"487476","q":"33264343847.22378500","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndividualSymbolMiniTickerStreamRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.IndividualSymbolMiniTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@miniTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndividualSymbolMiniTickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1591267704450,"s":"BTCUSD_200626","ps":"BTCUSD","c":"9561.7","o":"9580.9","h":"10000.0","l":"7000.0","v":"487476","q":"33264343847.22378500","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndividualSymbolMiniTickerStreamRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.IndividualSymbolMiniTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@miniTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndividualSymbolTickerStreams()
    {
        const string example = """""{"e":"24hrTicker","E":1591268262453,"s":"BTCUSD_200626","p":"-43.4","P":"-0.452","w":"0.00147974","c":"9548.5","Q":"2","o":"9591.9","h":"10000.0","l":"7000.0","v":"487850","q":"32968676323.46222700","O":1591181820000,"C":1591268262442,"F":512014,"L":615289,"n":103272,"ps":"BTCUSD","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndividualSymbolTickerStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.IndividualSymbolTickerStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@ticker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndividualSymbolTickerStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"24hrTicker","E":1591268262453,"s":"BTCUSD_200626","p":"-43.4","P":"-0.452","w":"0.00147974","c":"9548.5","Q":"2","o":"9591.9","h":"10000.0","l":"7000.0","v":"487850","q":"32968676323.46222700","O":1591181820000,"C":1591268262442,"F":512014,"L":615289,"n":103272,"ps":"BTCUSD","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndividualSymbolTickerStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.IndividualSymbolTickerStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@ticker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineCandlestickStreams()
    {
        const string example = """""{"e":"kline","E":1591261542539,"s":"BTCUSD_200626","k":{"t":1591261500000,"T":1591261559999,"s":"BTCUSD_200626","i":"1m","f":606400,"L":606430,"o":"9638.9","c":"9639.8","h":"9639.8","l":"9638.6","v":"156","n":31,"x":false,"q":"1.61836886","V":"73","Q":"0.75731156","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineCandlestickStreamsRequest
        {
            Symbol = "btcusdt",
            Interval = KlineCandlestickStreamsInterval.Interval1m,
        };

        using var subscription = client.KlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@kline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineCandlestickStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"kline","E":1591261542539,"s":"BTCUSD_200626","k":{"t":1591261500000,"T":1591261559999,"s":"BTCUSD_200626","i":"1m","f":606400,"L":606430,"o":"9638.9","c":"9639.8","h":"9639.8","l":"9638.6","v":"156","n":31,"x":false,"q":"1.61836886","V":"73","Q":"0.75731156","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineCandlestickStreamsRequest
        {
            Symbol = "btcusdt",
            Interval = KlineCandlestickStreamsInterval.Interval1m,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.KlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@kline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceKlineCandlestickStreams()
    {
        const string example = """""{"e":"markPrice_kline","E":1591267398004,"ps":"BTCUSD","k":{"t":1591267380000,"T":1591267439999,"s":"BTCUSD_200626","i":"1m","f":1591267380000,"L":1591267398000,"o":"9539.67161333","c":"9540.82761333","h":"9540.82761333","l":"9539.66961333","v":"0","n":19,"x":false,"q":"0","V":"0","Q":"0","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarkPriceKlineCandlestickStreamsRequest
        {
            Symbol = "btcusdt",
            Interval = MarkPriceKlineCandlestickStreamsInterval.Interval1m,
        };

        using var subscription = client.MarkPriceKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@markPriceKline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceKlineCandlestickStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"markPrice_kline","E":1591267398004,"ps":"BTCUSD","k":{"t":1591267380000,"T":1591267439999,"s":"BTCUSD_200626","i":"1m","f":1591267380000,"L":1591267398000,"o":"9539.67161333","c":"9540.82761333","h":"9540.82761333","l":"9539.66961333","v":"0","n":19,"x":false,"q":"0","V":"0","Q":"0","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarkPriceKlineCandlestickStreamsRequest
        {
            Symbol = "btcusdt",
            Interval = MarkPriceKlineCandlestickStreamsInterval.Interval1m,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.MarkPriceKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@markPriceKline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceOfAllSymbolsOfAPair()
    {
        const string example = """""[{"e":"markPriceUpdate","E":1596095725000,"s":"BTCUSD_201225","p":"10934.62615417","P":"10962.17178236","i":"10933.62615417","r":"","T":0,"st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarkPriceOfAllSymbolsOfAPairRequest
        {
            Pair = "btcusdt",
        };

        using var subscription = client.MarkPriceOfAllSymbolsOfAPair(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@markPrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceOfAllSymbolsOfAPairWithOptionalParameters()
    {
        const string example = """""[{"e":"markPriceUpdate","E":1596095725000,"s":"BTCUSD_201225","p":"10934.62615417","P":"10962.17178236","i":"10933.62615417","r":"","T":0,"st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarkPriceOfAllSymbolsOfAPairRequest
        {
            Pair = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
            UpdateSpeed = MarkPriceOfAllSymbolsOfAPairUpdateSpeed.UpdateSpeed1s,
        };

        using var subscription = client.MarkPriceOfAllSymbolsOfAPair(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@markPrice@1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceStream()
    {
        const string example = """""{"e":"markPriceUpdate","E":1596095725000,"s":"BTCUSD_201225","p":"10934.62615417","P":"10962.17178236","i":"10933.62615417","r":"","T":0,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarkPriceStreamRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.MarkPriceStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@markPrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceStreamWithOptionalParameters()
    {
        const string example = """""{"e":"markPriceUpdate","E":1596095725000,"s":"BTCUSD_201225","p":"10934.62615417","P":"10962.17178236","i":"10933.62615417","r":"","T":0,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarkPriceStreamRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
            UpdateSpeed = MarkPriceStreamUpdateSpeed.UpdateSpeed1s,
        };

        using var subscription = client.MarkPriceStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@markPrice@1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarketLiquidationOrderStreams()
    {
        const string example = """""{"e":"forceOrder","E":1591154240950,"o":{"s":"BTCUSD_200925","ps":"BTCUSD","S":"SELL","o":"LIMIT","f":"IOC","q":"1","p":"9425.5","ap":"9496.5","X":"FILLED","l":"1","z":"1","T":1591154240949}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarketLiquidationOrderStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.MarketLiquidationOrderStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@forceOrder", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarketLiquidationOrderStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"forceOrder","E":1591154240950,"o":{"s":"BTCUSD_200925","ps":"BTCUSD","S":"SELL","o":"LIMIT","f":"IOC","q":"1","p":"9425.5","ap":"9496.5","X":"FILLED","l":"1","z":"1","T":1591154240949}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarketLiquidationOrderStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.MarketLiquidationOrderStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@forceOrder", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialBookDepthStreams()
    {
        const string example = """""{"e":"depthUpdate","E":1591269996801,"T":1591269996646,"s":"BTCUSD_200626","ps":"BTCUSD","U":17276694,"u":17276701,"pu":17276678,"b":[["9523.0"]],"a":[["9524.6"]],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"depthUpdate","E":1591269996801,"T":1591269996646,"s":"BTCUSD_200626","ps":"BTCUSD","U":17276694,"u":17276701,"pu":17276678,"b":[["9523.0"]],"a":[["9524.6"]],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
}
