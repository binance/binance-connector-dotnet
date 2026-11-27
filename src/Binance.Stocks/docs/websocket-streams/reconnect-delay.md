# Reconnect Delay

Specify the delay between WebSocket reconnection attempts for streams (a `TimeSpan`); after a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it. After a reconnect the client subscribes again to every stream.

```csharp
using Binance.Common;
using Binance.Stocks.WebSocketStreams;

var config = new WebSocketStreamsConfig { ReconnectDelay = TimeSpan.FromSeconds(3) };
var client = StocksWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.CalendarStream();

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(StocksWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
