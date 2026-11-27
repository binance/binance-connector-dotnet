# Reconnect Delay

Specify the delay between WebSocket reconnection attempts for streams (a `TimeSpan`); after a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it. After a reconnect the client subscribes again to every stream.

```csharp
using Binance.Common;
using Binance.W3WPrediction.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    ReconnectDelay = TimeSpan.FromSeconds(3),
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
