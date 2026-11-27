# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.W3WPrediction.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
var client = W3WPredictionWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

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
