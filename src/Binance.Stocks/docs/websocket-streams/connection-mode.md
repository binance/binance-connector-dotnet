# Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

```csharp
using Binance.Common;
using Binance.Stocks.WebSocketStreams;

var config = new WebSocketStreamsConfig { Mode = WebSocketMode.Pool(3) };
var client = StocksWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync(mode: WebSocketMode.Pool(5)); // or the configured mode

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
