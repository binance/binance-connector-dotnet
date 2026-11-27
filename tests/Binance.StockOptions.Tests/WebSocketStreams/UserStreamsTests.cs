//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.StockOptions.WebSocketStreams;

namespace Binance.StockOptions.Tests.WebSocketStreams.UserStreams;

[Trait("Category", "Native")]
public class UserStreamsApiTests
{
    [Fact]
    public async Task OrderReportV2Stream()
    {
        const string example = """""{"e":"orderReportV2","E":1792679109312,"x":"ORDER_UPDATE","i":"b0b6dd9d-8b9b-48a9-ba46-b9d54906e415","ci":"6a1f3c2e-90b4-4d7e-a1c5-2f8e7d6b5a40","ai":"8d3f2a61-5c7e-4b90-9e1d-3a6c4f2b7e18","b":"EQ_SPCX","q":"USDC","S":"buy","o":"limit","p":0.57,"Q":1,"N":1,"fq":0,"FN":0,"tc":57.66,"Z":0,"n":"RTH","s":"accepted","T":1792679109000,"U":1792679109000,"ac":"us_option","os":"SPCX261023C00005000","u":"SPCX","rs":"SPCX","ct":"CALL","sp":5,"ed":1792771200000,"m":100,"pi":"buy_to_open"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StockOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OrderReportV2StreamRequest
        {
            ListenKey = "3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13",
        };

        using var subscription = client.OrderReportV2Stream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13@orderReportV2", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }

    [Fact]
    public async Task OrderReportV2StreamWithOptionalParameters()
    {
        const string example = """""{"e":"orderReportV2","E":1792679109312,"x":"ORDER_UPDATE","i":"b0b6dd9d-8b9b-48a9-ba46-b9d54906e415","ci":"6a1f3c2e-90b4-4d7e-a1c5-2f8e7d6b5a40","ai":"8d3f2a61-5c7e-4b90-9e1d-3a6c4f2b7e18","b":"EQ_SPCX","q":"USDC","S":"buy","o":"limit","p":0.57,"Q":1,"N":1,"fq":0,"FN":0,"tc":57.66,"Z":0,"n":"RTH","s":"accepted","T":1792679109000,"U":1792679109000,"ac":"us_option","os":"SPCX261023C00005000","u":"SPCX","rs":"SPCX","ct":"CALL","sp":5,"ed":1792771200000,"m":100,"pi":"buy_to_open"}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes);
        await using var client = await new StockOptionsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        var request = new OrderReportV2StreamRequest
        {
            ListenKey = "3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13",
            Id = "e9d6b4349871b40611412680b3445fac",
        };

        using var subscription = client.OrderReportV2Stream(request);

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13@orderReportV2", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
