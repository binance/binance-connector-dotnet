# Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketStreams;

var config = new WebSocketStreamsConfig { Mode = WebSocketMode.Pool(3) };
var client = DerivativesTradingCoinFuturesWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync(mode: WebSocketMode.Pool(5)); // or the configured mode

using var subscription = connection.AggregateTradeStreams(new() { Symbol = "btcusdt" });

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(DerivativesTradingCoinFuturesWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
