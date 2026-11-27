# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

var config = new WebSocketStreamsConfig { Compression = false };
var client = DerivativesTradingUsdsFuturesWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.AggregateTradeStreams(new() { Symbol = "btcusdt" });

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(DerivativesTradingUsdsFuturesWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
