# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.DerivativesTradingOptions.WebSocketStreams;

var config = new WebSocketStreamsConfig { Compression = false };
var client = DerivativesTradingOptionsWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.IndexPriceStreams();

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(DerivativesTradingOptionsWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
