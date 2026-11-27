# Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

```csharp
using Binance.Common;
using Binance.W3WPrediction.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Mode = WebSocketMode.Pool(3),
};
var client = W3WPredictionWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync(mode: WebSocketMode.Pool(5)); // or the configured mode

using var subscription = connection.BatchClaimPartiallySucceeded();

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(W3WPredictionWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
