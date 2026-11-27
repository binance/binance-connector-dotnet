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

namespace Binance.DerivativesTradingOptions.Tests.WebSocketStreams.Market;

[Trait("Category", "Native")]
public class MarketApiTests
{
    [Fact]
    public async Task IndexPriceStreams()
    {
        const string example = """""[{"e":"indexPrice","E":1763092572229,"s":"ETHUSDT","p":"3224.51976744"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.IndexPriceStreams();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!index@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task IndexPriceStreamsWithOptionalParameters()
    {
        const string example = """""[{"e":"indexPrice","E":1763092572229,"s":"ETHUSDT","p":"3224.51976744"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new IndexPriceStreamsRequest
        {
            Id = 532601580L,
        };

        using var subscription = client.IndexPriceStreams(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!index@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineCandlestickStreams()
    {
        const string example = """""{"e":"kline","E":1638747660000,"s":"BTC-200630-9000-P","k":{"t":1638747660000,"T":1638747719999,"s":"BTC-200630-9000-P","i":"1m","f":0,"L":0,"o":"1000","c":"1000","h":"1000","l":"1000","v":"0","n":0,"x":false,"q":"0","V":"0","Q":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

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
        const string example = """""{"e":"kline","E":1638747660000,"s":"BTC-200630-9000-P","k":{"t":1638747660000,"T":1638747719999,"s":"BTC-200630-9000-P","i":"1m","f":0,"L":0,"o":"1000","c":"1000","h":"1000","l":"1000","v":"0","n":0,"x":false,"q":"0","V":"0","Q":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineCandlestickStreamsRequest
        {
            Symbol = "btcusdt",
            Interval = KlineCandlestickStreamsInterval.Interval1m,
            Id = 532601580L,
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
    public async Task NewSymbolInfo()
    {
        const string example = """""{"e":"optionSymbol","E":1669356423908,"s":"BTC-250926-140000-C","ps":"BTCUSDT","qa":"USDT","d":"CALL","sp":"21000","dt":4133404800000,"u":1,"ot":1569398400000,"cs":"TRADING"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.NewSymbolInfo();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!optionSymbol", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task NewSymbolInfoWithOptionalParameters()
    {
        const string example = """""{"e":"optionSymbol","E":1669356423908,"s":"BTC-250926-140000-C","ps":"BTCUSDT","qa":"USDT","d":"CALL","sp":"21000","dt":4133404800000,"u":1,"ot":1569398400000,"cs":"TRADING"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new NewSymbolInfoRequest
        {
            Id = 532601580L,
        };

        using var subscription = client.NewSymbolInfo(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!optionSymbol", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task OpenInterest()
    {
        const string example = """""[{"e":"openInterest","E":1668759300045,"s":"ETH-221125-2700-C","o":"1580.87","h":"1912992.178168204"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OpenInterestRequest
        {
            Underlying = "btcusdt",
            ExpirationDate = "220930",
        };

        using var subscription = client.OpenInterest(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionOpenInterest@220930", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task OpenInterestWithOptionalParameters()
    {
        const string example = """""[{"e":"openInterest","E":1668759300045,"s":"ETH-221125-2700-C","o":"1580.87","h":"1912992.178168204"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OpenInterestRequest
        {
            Underlying = "btcusdt",
            ExpirationDate = "220930",
            Id = 532601580L,
        };

        using var subscription = client.OpenInterest(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionOpenInterest@220930", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task OptionMarkPrice()
    {
        const string example = """""[{"s":"BTC-251120-126000-C","mp":"770.543","E":1762867543321,"e":"markPrice","i":"104334.60217391","P":"0.000","bo":"0.000","ao":"900.000","bq":"0.0000","aq":"0.2000","b":"-1.0","a":"0.98161161","hl":"924.652","ll":"616.435","vo":"0.9408058","rf":"0.0","d":"0.11111964","t":"-164.26702615","g":"0.00001245","v":"30.63855919"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OptionMarkPriceRequest
        {
            Underlying = "btcusdt",
        };

        using var subscription = client.OptionMarkPrice(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionMarkPrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task OptionMarkPriceWithOptionalParameters()
    {
        const string example = """""[{"s":"BTC-251120-126000-C","mp":"770.543","E":1762867543321,"e":"markPrice","i":"104334.60217391","P":"0.000","bo":"0.000","ao":"900.000","bq":"0.0000","aq":"0.2000","b":"-1.0","a":"0.98161161","hl":"924.652","ll":"616.435","vo":"0.9408058","rf":"0.0","d":"0.11111964","t":"-164.26702615","g":"0.00001245","v":"30.63855919"}]""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OptionMarkPriceRequest
        {
            Underlying = "btcusdt",
            Id = 532601580L,
        };

        using var subscription = client.OptionMarkPrice(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("btcusdt@optionMarkPrice", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
