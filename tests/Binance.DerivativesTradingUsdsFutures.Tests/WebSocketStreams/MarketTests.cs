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

namespace Binance.DerivativesTradingUsdsFutures.Tests.WebSocketStreams.Market;

[Trait("Category", "Native")]
public class MarketApiTests
{
    [Fact]
    public async Task AggregateTradeStreams()
    {
        const string example = """""{"e":"aggTrade","E":123456789,"s":"BNBUSDT","a":5933014,"p":"0.001","q":"100","nq":"100","f":100,"l":105,"T":123456785,"m":true,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"aggTrade","E":123456789,"s":"BNBUSDT","a":5933014,"p":"0.001","q":"100","nq":"100","f":100,"l":105,"T":123456785,"m":true,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task AllMarketLiquidationOrderStreams()
    {
        const string example = """""{"e":"forceOrder","E":1568014460893,"o":{"s":"BTCUSDT","S":"SELL","o":"LIMIT","f":"IOC","q":"0.014","p":"9910","ap":"9910","X":"FILLED","l":"0.014","z":"0.014","T":1568014460893},"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"forceOrder","E":1568014460893,"o":{"s":"BTCUSDT","S":"SELL","o":"LIMIT","f":"IOC","q":"0.014","p":"9910","ap":"9910","X":"FILLED","l":"0.014","z":"0.014","T":1568014460893},"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""[{"e":"24hrMiniTicker","E":123456789,"s":"BNBUSDT","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","ps":"BTCUSDT","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""[{"e":"24hrMiniTicker","E":123456789,"s":"BNBUSDT","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","ps":"BTCUSDT","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""[{"e":"24hrTicker","E":123456789,"s":"BNBUSDT","p":"0.0015","P":"250.00","w":"0.0018","c":"0.0025","Q":"10","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","O":0,"C":86400000,"F":0,"L":18150,"n":18151,"ps":"BTCUSDT","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""[{"e":"24hrTicker","E":123456789,"s":"BNBUSDT","p":"0.0015","P":"250.00","w":"0.0018","c":"0.0025","Q":"10","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","O":0,"C":86400000,"F":0,"L":18150,"n":18151,"ps":"BTCUSDT","st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task AssetIndex()
    {
        const string example = """""[{"e":"assetIndexUpdate","E":1686749230000,"s":"ADAUSD","i":"0.27462452","b":"0.10000000","a":"0.10000000","B":"0.24716207","A":"0.30208698","q":"0.05000000","g":"0.05000000","Q":"0.26089330","G":"0.28835575"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AssetIndex();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!assetIndex@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AssetIndexWithOptionalParameters()
    {
        const string example = """""[{"e":"assetIndexUpdate","E":1686749230000,"s":"ADAUSD","i":"0.27462452","b":"0.10000000","a":"0.10000000","B":"0.24716207","A":"0.30208698","q":"0.05000000","g":"0.05000000","Q":"0.26089330","G":"0.28835575"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AssetIndexRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.AssetIndex(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!assetIndex@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task CompositeIndexSymbolInformationStreams()
    {
        const string example = """""{"e":"compositeIndex","E":1602310596000,"s":"DEFIUSDT","p":"554.41604065","C":"baseAsset","c":[{"b":"BAL","q":"USDT","w":"1.04884844","W":"0.01457800","i":"24.33521021"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new CompositeIndexSymbolInformationStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.CompositeIndexSymbolInformationStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@compositeIndex", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task CompositeIndexSymbolInformationStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"compositeIndex","E":1602310596000,"s":"DEFIUSDT","p":"554.41604065","C":"baseAsset","c":[{"b":"BAL","q":"USDT","w":"1.04884844","W":"0.01457800","i":"24.33521021"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new CompositeIndexSymbolInformationStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.CompositeIndexSymbolInformationStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@compositeIndex", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickStreams()
    {
        const string example = """""{"e":"continuous_kline","E":1607443058651,"ps":"BTCUSDT","ct":"PERPETUAL","k":{"t":1607443020000,"T":1607443079999,"i":"1m","f":116467658886,"L":116468012423,"o":"18787.00","c":"18804.04","h":"18804.04","l":"18786.54","v":"197.664","n":543,"x":false,"q":"3715253.19494","V":"184.769","Q":"3472925.84746","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ContinuousContractKlineCandlestickStreamsRequest
        {
            Pair = "btcusdt",
            ContractType = ContinuousContractKlineCandlestickStreamsContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickStreamsInterval.Interval1s,
        };

        using var subscription = client.ContinuousContractKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt_perpetual@continuousKline_1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContinuousContractKlineCandlestickStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"continuous_kline","E":1607443058651,"ps":"BTCUSDT","ct":"PERPETUAL","k":{"t":1607443020000,"T":1607443079999,"i":"1m","f":116467658886,"L":116468012423,"o":"18787.00","c":"18804.04","h":"18804.04","l":"18786.54","v":"197.664","n":543,"x":false,"q":"3715253.19494","V":"184.769","Q":"3472925.84746","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ContinuousContractKlineCandlestickStreamsRequest
        {
            Pair = "btcusdt",
            ContractType = ContinuousContractKlineCandlestickStreamsContractType.Perpetual,
            Interval = ContinuousContractKlineCandlestickStreamsInterval.Interval1s,
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.ContinuousContractKlineCandlestickStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt_perpetual@continuousKline_1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContractInfoStream()
    {
        const string example = """""{"e":"contractInfo","E":1669356423908,"s":"IOTAUSDT","ct":"PERPETUAL","dt":4133404800000,"ot":1569398400000,"cs":"TRADING","bks":[{"bs":1,"bnf":0,"bnc":5000,"mmr":0.01,"cf":0,"mi":21,"ma":50}],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"contractInfo","E":1669356423908,"s":"IOTAUSDT","ct":"PERPETUAL","dt":4133404800000,"ot":1569398400000,"cs":"TRADING","bks":[{"bs":1,"bnf":0,"bnc":5000,"mmr":0.01,"cf":0,"mi":21,"ma":50}],"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task IndividualSymbolMiniTickerStream()
    {
        const string example = """""{"e":"24hrMiniTicker","E":123456789,"s":"BNBUSDT","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"24hrMiniTicker","E":123456789,"s":"BNBUSDT","c":"0.0025","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"24hrTicker","E":123456789,"s":"BNBUSDT","p":"0.0015","P":"250.00","w":"0.0018","c":"0.0025","Q":"10","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","O":0,"C":86400000,"F":0,"L":18150,"n":18151,"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"24hrTicker","E":123456789,"s":"BNBUSDT","p":"0.0015","P":"250.00","w":"0.0018","c":"0.0025","Q":"10","o":"0.0010","h":"0.0025","l":"0.0010","v":"10000","q":"18","O":0,"C":86400000,"F":0,"L":18150,"n":18151,"ps":"BTCUSDT","st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"kline","E":1638747660000,"s":"BTCUSDT","k":{"t":1638747660000,"T":1638747719999,"s":"BTCUSDT","i":"1m","f":100,"L":200,"o":"0.0010","c":"0.0020","h":"0.0025","l":"0.0015","v":"1000","n":100,"x":false,"q":"1.0000","V":"500","Q":"0.500","B":"123456"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"kline","E":1638747660000,"s":"BTCUSDT","k":{"t":1638747660000,"T":1638747719999,"s":"BTCUSDT","i":"1m","f":100,"L":200,"o":"0.0010","c":"0.0020","h":"0.0025","l":"0.0015","v":"1000","n":100,"x":false,"q":"1.0000","V":"500","Q":"0.500","B":"123456"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task LiquidationOrderStreams()
    {
        const string example = """""{"e":"forceOrder","E":1568014460893,"o":{"s":"BTCUSDT","S":"SELL","o":"LIMIT","f":"IOC","q":"0.014","p":"9910","ap":"9910","X":"FILLED","l":"0.014","z":"0.014","T":1568014460893}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new LiquidationOrderStreamsRequest
        {
            Symbol = "btcusdt",
        };

        using var subscription = client.LiquidationOrderStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@forceOrder", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task LiquidationOrderStreamsWithOptionalParameters()
    {
        const string example = """""{"e":"forceOrder","E":1568014460893,"o":{"s":"BTCUSDT","S":"SELL","o":"LIMIT","f":"IOC","q":"0.014","p":"9910","ap":"9910","X":"FILLED","l":"0.014","z":"0.014","T":1568014460893}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new LiquidationOrderStreamsRequest
        {
            Symbol = "btcusdt",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.LiquidationOrderStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@forceOrder", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceStream()
    {
        const string example = """""{"e":"markPriceUpdate","E":1562305380000,"s":"BTCUSDT","p":"11794.15000000","i":"11784.62659091","P":"11784.25641265","r":"0.00038167","ap":"11794.15000000","T":1562306400000,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"markPriceUpdate","E":1562305380000,"s":"BTCUSDT","p":"11794.15000000","i":"11784.62659091","P":"11784.25641265","r":"0.00038167","ap":"11794.15000000","T":1562306400000,"st":1}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
    public async Task MarkPriceStreamForAllMarket()
    {
        const string example = """""[{"e":"markPriceUpdate","E":1562305380000,"s":"BTCUSDT","p":"11185.87786614","i":"11784.62659091","P":"11784.25641265","r":"0.00030000","ap":"11185.87786614","T":1562306400000,"st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.MarkPriceStreamForAllMarket();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!markPrice@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MarkPriceStreamForAllMarketWithOptionalParameters()
    {
        const string example = """""[{"e":"markPriceUpdate","E":1562305380000,"s":"BTCUSDT","p":"11185.87786614","i":"11784.62659091","P":"11784.25641265","r":"0.00030000","ap":"11185.87786614","T":1562306400000,"st":1}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MarkPriceStreamForAllMarketRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
            UpdateSpeed = MarkPriceStreamForAllMarketUpdateSpeed.UpdateSpeed1s,
        };

        using var subscription = client.MarkPriceStreamForAllMarket(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!markPrice@arr@1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradingSessionStream()
    {
        const string example = """""{"e":"EquityUpdate","E":1765244143062,"t":1765242000000,"T":1765270800000,"S":"OVERNIGHT"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.TradingSessionStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("tradingSession", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradingSessionStreamWithOptionalParameters()
    {
        const string example = """""{"e":"EquityUpdate","E":1765244143062,"t":1765242000000,"T":1765270800000,"S":"OVERNIGHT"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingUsdsFuturesWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradingSessionStreamRequest
        {
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.TradingSessionStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("tradingSession", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
