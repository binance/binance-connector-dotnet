# Time Unit

Specify the time unit for WebSocket Streams timestamps (`Millisecond` or `Microsecond`).

```csharp
using Binance.Common;
using Binance.Spot.WebSocketStreams;

var config = new WebSocketStreamsConfig { TimeUnit = TimeUnit.Microsecond };
var client = SpotWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.AggTrade(new() { Symbol = "bnbusdt" });

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(SpotWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
