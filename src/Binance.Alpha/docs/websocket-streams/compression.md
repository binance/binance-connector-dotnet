# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.Alpha.WebSocketStreams;

var config = new WebSocketStreamsConfig { Compression = false };
var client = AlphaWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.AggregateTradeStream(new() { Symbol = "alpha_116usdt" });

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(AlphaWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
