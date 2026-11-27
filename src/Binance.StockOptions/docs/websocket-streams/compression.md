# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.StockOptions.WebSocketStreams;

var config = new WebSocketStreamsConfig { Compression = false };
var client = StockOptionsWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.OrderReportV2Stream(new()
{
    ListenKey = "3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13",
});

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(StockOptionsWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
