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

namespace Binance.Stocks.Tests.WebSocketStreams.UserStreams;

[Trait("Category", "Native")]
public class UserStreamsApiTests
{
    [Fact]
    public async Task OrderReportStream()
    {
        const string example = """""{"e":"orderReport","E":1710000000000,"x":"ORDER_UPDATE","i":"b0b6dd9d-8b9b-48a9-ba46-b9d54906e415","ai":"4ce9353c-66d1-46c2-898f-fce867ab0247","b":"EQ_AAPL","q":"USD","S":"buy","o":"limit","p":185.5,"Q":10,"N":1,"fq":5,"FN":927.5,"tc":1856.2,"Z":50,"n":"Regular","s":"partially_filled","T":1710000000000,"U":1710000060000}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OrderReportStreamRequest
        {
            ListenKey = "pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s6af0dkfj2a97b8a91d",
        };

        using var subscription = client.OrderReportStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s6af0dkfj2a97b8a91d@orderReport", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task OrderReportStreamWithOptionalParameters()
    {
        const string example = """""{"e":"orderReport","E":1710000000000,"x":"ORDER_UPDATE","i":"b0b6dd9d-8b9b-48a9-ba46-b9d54906e415","ai":"4ce9353c-66d1-46c2-898f-fce867ab0247","b":"EQ_AAPL","q":"USD","S":"buy","o":"limit","p":185.5,"Q":10,"N":1,"fq":5,"FN":927.5,"tc":1856.2,"Z":50,"n":"Regular","s":"partially_filled","T":1710000000000,"U":1710000060000}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StocksWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OrderReportStreamRequest
        {
            ListenKey = "pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s6af0dkfj2a97b8a91d",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.OrderReportStream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("pqia91ma19a5s61cv6a81va65sdf19v8a65a1a5s6af0dkfj2a97b8a91d@orderReport", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
