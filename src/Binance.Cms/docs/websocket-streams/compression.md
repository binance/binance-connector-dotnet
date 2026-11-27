# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.Cms.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
var client = CmsWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.ComAnnouncementEn();

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(CmsWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
