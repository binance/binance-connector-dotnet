//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Alpha.WebSocketStreams;

namespace Binance.Alpha.Tests.WebSocketStreams;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    [Fact]
    public async Task AggregateTradeStream()
    {
        const string example = """""{"e":"aggTrade","E":1771828569861,"T":1771828569702,"a":2684294,"f":2684294,"l":2684294,"m":false,"p":"0.08530000","q":"879.24000000","s":"ALPHA_474USDT"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AggregateTradeStreamRequest
        {
            Symbol = "alpha_116usdt",
        };

        using var subscription = client.AggregateTradeStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@aggTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AggregateTradeStreamWithOptionalParameters()
    {
        const string example = """""{"e":"aggTrade","E":1771828569861,"T":1771828569702,"a":2684294,"f":2684294,"l":2684294,"m":false,"p":"0.08530000","q":"879.24000000","s":"ALPHA_474USDT"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AggregateTradeStreamRequest
        {
            Symbol = "alpha_116usdt",
            Id = 532601580L,
        };

        using var subscription = client.AggregateTradeStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@aggTrade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllBookTickerStream()
    {
        const string example = """""{"e":"bookTicker","E":1773108379067,"T":1773108379054,"u":6663207693,"s":"ALPHA_116USDT","b":"8.30000000","B":"0.91076900","a":"9.30000000","A":"2.00353200"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllBookTickerStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllBookTickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"bookTicker","E":1773108379067,"T":1773108379054,"u":6663207693,"s":"ALPHA_116USDT","b":"8.30000000","B":"0.91076900","a":"9.30000000","A":"2.00353200"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllBookTickerStreamRequest
        {
            Id = 532601580L,
        };

        using var subscription = client.AllBookTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMiniTickerStream()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1773109449908,"s":"ALPHA_116USDT","c":"8.40000000","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64739.03978900","q":"543810.36005090"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllMiniTickerStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!miniTicker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllMiniTickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1773109449908,"s":"ALPHA_116USDT","c":"8.40000000","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64739.03978900","q":"543810.36005090"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllMiniTickerStreamRequest
        {
            Id = 532601580L,
        };

        using var subscription = client.AllMiniTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!miniTicker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllTickerStream()
    {
        const string example = """""{"e":"24hrTicker","E":1773109631569,"s":"ALPHA_116USDT","p":"0.00000000","P":"0.00","w":"8.40003127","c":"8.40000000","Q":"0.49293200","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64750.63418500","q":"543907.35169250","O":1773023220000,"C":1773109631555,"F":19847634,"L":19911287,"n":217505}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllTickerStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!ticker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllTickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"24hrTicker","E":1773109631569,"s":"ALPHA_116USDT","p":"0.00000000","P":"0.00","w":"8.40003127","c":"8.40000000","Q":"0.49293200","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64750.63418500","q":"543907.35169250","O":1773023220000,"C":1773109631555,"F":19847634,"L":19911287,"n":217505}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllTickerStreamRequest
        {
            Id = 532601580L,
        };

        using var subscription = client.AllTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("!ticker@arr", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllTokens24hTickerStream()
    {
        const string example = """""{"e":"tickerList","d":[{"ca":"0x8fce...@56","cnt24":10426,"fdv":"72834145.18711072","hc":"6822","liq":"1442996.98151177662835","mc":"13542034.24008014","p":"0.072849536538593663","pc24":"-2.32","s":"1","t":1771825733000,"vol24":"12930712.213702157742688594285"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.AllTokens24hTickerStream();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("came@allTokens@ticker24", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task AllTokens24hTickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"tickerList","d":[{"ca":"0x8fce...@56","cnt24":10426,"fdv":"72834145.18711072","hc":"6822","liq":"1442996.98151177662835","mc":"13542034.24008014","p":"0.072849536538593663","pc24":"-2.32","s":"1","t":1771825733000,"vol24":"12930712.213702157742688594285"}]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new AllTokens24hTickerStreamRequest
        {
            Id = 532601580L,
        };

        using var subscription = client.AllTokens24hTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("came@allTokens@ticker24", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task BookTickerStream()
    {
        const string example = """""{"e":"bookTicker","E":1773108379067,"T":1773108379054,"u":6663207693,"s":"ALPHA_116USDT","b":"8.30000000","B":"0.91076900","a":"9.30000000","A":"2.00353200"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new BookTickerStreamRequest
        {
            Symbol = "alpha_116usdt",
        };

        using var subscription = client.BookTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task BookTickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"bookTicker","E":1773108379067,"T":1773108379054,"u":6663207693,"s":"ALPHA_116USDT","b":"8.30000000","B":"0.91076900","a":"9.30000000","A":"2.00353200"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new BookTickerStreamRequest
        {
            Symbol = "alpha_116usdt",
            Id = 532601580L,
        };

        using var subscription = client.BookTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@bookTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContractKlineStream()
    {
        const string example = """""{"ca":"G7vQW...@CT_501","e":"kline","k":{"o":"0.15584372258086979622","c":"0.15584957424118055058","h":"0.15584957424118055058","l":"0.15584372258086979622","v":"2.8584092999332775480","ot":1771828655000,"ct":1771828656000,"i":"1s"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ContractKlineStreamRequest
        {
            ContractAddress = "G7vQWurMkMMm2dU3iZpXYFTHT9Biio4F4gZCrwFpKNwG",
            ChainId = "CT_501",
            Interval = ContractKlineStreamInterval.Interval1s,
        };

        using var subscription = client.ContractKlineStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("came@G7vQWurMkMMm2dU3iZpXYFTHT9Biio4F4gZCrwFpKNwG@CT_501@kline_1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task ContractKlineStreamWithOptionalParameters()
    {
        const string example = """""{"ca":"G7vQW...@CT_501","e":"kline","k":{"o":"0.15584372258086979622","c":"0.15584957424118055058","h":"0.15584957424118055058","l":"0.15584372258086979622","v":"2.8584092999332775480","ot":1771828655000,"ct":1771828656000,"i":"1s"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new ContractKlineStreamRequest
        {
            ContractAddress = "G7vQWurMkMMm2dU3iZpXYFTHT9Biio4F4gZCrwFpKNwG",
            ChainId = "CT_501",
            Interval = ContractKlineStreamInterval.Interval1s,
            Id = 532601580L,
        };

        using var subscription = client.ContractKlineStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("came@G7vQWurMkMMm2dU3iZpXYFTHT9Biio4F4gZCrwFpKNwG@CT_501@kline_1s", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task FullDepthStream()
    {
        const string example = """""{"e":"depthUpdate","E":1771828614381,"T":1771828614258,"U":42648947917,"u":42648948229,"pu":42648947321,"s":"ALPHA_474USDT","b":[["0.16479999","0"],["0.16480000","18.68000000"]],"a":[["0.16490000","500.00000000"],["0.16500000","0"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new FullDepthStreamRequest
        {
            Symbol = "alpha_116usdt",
            Interval = FullDepthStreamInterval.Interval0ms,
        };

        using var subscription = client.FullDepthStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@fulldepth@0ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task FullDepthStreamWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":1771828614381,"T":1771828614258,"U":42648947917,"u":42648948229,"pu":42648947321,"s":"ALPHA_474USDT","b":[["0.16479999","0"],["0.16480000","18.68000000"]],"a":[["0.16490000","500.00000000"],["0.16500000","0"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new FullDepthStreamRequest
        {
            Symbol = "alpha_116usdt",
            Interval = FullDepthStreamInterval.Interval0ms,
            Id = 532601580L,
        };

        using var subscription = client.FullDepthStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@fulldepth@0ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineStream()
    {
        const string example = """""{"e":"kline","E":1773111055144,"s":"ALPHA_116USDT","k":{"t":1773111000000,"T":1773111059999,"s":"ALPHA_116USDT","i":"1m","f":19912696,"L":19912765,"o":"8.40000000","c":"8.40000000","h":"8.40000000","l":"8.40000000","v":"63.64876300","n":218,"x":false,"q":"534.64960920","V":"63.64876300","Q":"534.64960920","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineStreamRequest
        {
            Symbol = "alpha_116usdt",
            Interval = KlineStreamInterval.Interval1m,
        };

        using var subscription = client.KlineStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@kline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task KlineStreamWithOptionalParameters()
    {
        const string example = """""{"e":"kline","E":1773111055144,"s":"ALPHA_116USDT","k":{"t":1773111000000,"T":1773111059999,"s":"ALPHA_116USDT","i":"1m","f":19912696,"L":19912765,"o":"8.40000000","c":"8.40000000","h":"8.40000000","l":"8.40000000","v":"63.64876300","n":218,"x":false,"q":"534.64960920","V":"63.64876300","Q":"534.64960920","B":"0"}}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new KlineStreamRequest
        {
            Symbol = "alpha_116usdt",
            Interval = KlineStreamInterval.Interval1m,
            Id = 532601580L,
        };

        using var subscription = client.KlineStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@kline_1m", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MiniTickerStream()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1773109449908,"s":"ALPHA_116USDT","c":"8.40000000","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64739.03978900","q":"543810.36005090"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MiniTickerStreamRequest
        {
            Symbol = "alpha_116usdt",
        };

        using var subscription = client.MiniTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@miniTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task MiniTickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"24hrMiniTicker","E":1773109449908,"s":"ALPHA_116USDT","c":"8.40000000","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64739.03978900","q":"543810.36005090"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new MiniTickerStreamRequest
        {
            Symbol = "alpha_116usdt",
            Id = 532601580L,
        };

        using var subscription = client.MiniTickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@miniTicker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialDepthStream()
    {
        const string example = """""{"e":"depthUpdate","E":1773110222878,"T":1773110222767,"U":6663367135,"u":6663367147,"pu":6663366971,"s":"ALPHA_116USDT","b":[["0.16479999","0"],["0.16480000","18.68000000"]],"a":[["0.16490000","500.00000000"],["0.16500000","0"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialDepthStreamRequest
        {
            Symbol = "alpha_116usdt",
            Levels = PartialDepthStreamLevels.Levels5,
            Interval = PartialDepthStreamInterval.Interval0ms,
        };

        using var subscription = client.PartialDepthStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@depth5@0ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task PartialDepthStreamWithOptionalParameters()
    {
        const string example = """""{"e":"depthUpdate","E":1773110222878,"T":1773110222767,"U":6663367135,"u":6663367147,"pu":6663366971,"s":"ALPHA_116USDT","b":[["0.16479999","0"],["0.16480000","18.68000000"]],"a":[["0.16490000","500.00000000"],["0.16500000","0"]]}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new PartialDepthStreamRequest
        {
            Symbol = "alpha_116usdt",
            Levels = PartialDepthStreamLevels.Levels5,
            Interval = PartialDepthStreamInterval.Interval0ms,
            Id = 532601580L,
        };

        using var subscription = client.PartialDepthStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@depth5@0ms", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TickerStream()
    {
        const string example = """""{"e":"24hrTicker","E":1773109631569,"s":"ALPHA_116USDT","p":"0.00000000","P":"0.00","w":"8.40003127","c":"8.40000000","Q":"0.49293200","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64750.63418500","q":"543907.35169250","O":1773023220000,"C":1773109631555,"F":19847634,"L":19911287,"n":217505}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TickerStreamRequest
        {
            Symbol = "alpha_116usdt",
        };

        using var subscription = client.TickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@ticker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TickerStreamWithOptionalParameters()
    {
        const string example = """""{"e":"24hrTicker","E":1773109631569,"s":"ALPHA_116USDT","p":"0.00000000","P":"0.00","w":"8.40003127","c":"8.40000000","Q":"0.49293200","o":"8.40000000","h":"8.50000000","l":"8.30000000","v":"64750.63418500","q":"543907.35169250","O":1773023220000,"C":1773109631555,"F":19847634,"L":19911287,"n":217505}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TickerStreamRequest
        {
            Symbol = "alpha_116usdt",
            Id = 532601580L,
        };

        using var subscription = client.TickerStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@ticker", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradeStream()
    {
        const string example = """""{"e":"trade","E":1773110023891,"T":1773110023877,"s":"ALPHA_116USDT","t":19911650,"p":"8.40000000","q":"0.97915700","m":false}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradeStreamRequest
        {
            Symbol = "alpha_116usdt",
        };

        using var subscription = client.TradeStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@trade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task TradeStreamWithOptionalParameters()
    {
        const string example = """""{"e":"trade","E":1773110023891,"T":1773110023877,"s":"ALPHA_116USDT","t":19911650,"p":"8.40000000","q":"0.97915700","m":false}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new AlphaWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new TradeStreamRequest
        {
            Symbol = "alpha_116usdt",
            Id = 532601580L,
        };

        using var subscription = client.TradeStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("alpha_116usdt@trade", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
