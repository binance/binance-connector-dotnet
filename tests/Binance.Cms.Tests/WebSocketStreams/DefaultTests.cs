//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Common.Tests;
using Binance.Cms.WebSocketStreams;

namespace Binance.Cms.Tests.WebSocketStreams;

[Trait("Category", "Native")]
public class DefaultApiTests
{
    [Fact]
    public async Task ComAnnouncementEn()
    {
        const string example = """""{"catalogId":161,"catalogName":"Delisting","publishDate":1753257631403,"title":"Notice of...","body":"This is...","disclaimer":"Trade on-the-go..."}""""";

        using var server = new MiniWsServer(MiniWsServer.AcceptSubscribes) { Signed = true };
        await using var client = await new CmsWebSocketStreams(new WebSocketStreamsConfig { Url = server.Url, ApiKey = "test-key", ApiSecret = "test-secret" }).ConnectAsync();

        using var subscription = client.ComAnnouncementEn();

        Assert.True(await MiniWsServer.WaitFor(() => server.Subscribes() == 1));
        var stream = server.SubscribedStream();
        Assert.Equal("com_announcement_en", stream);

        server.Publish(stream, example);

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        var message = await subscription.Events.ReadAsync(timeout.Token);
        ExampleAssert.Matches(example, message);
    }
}
