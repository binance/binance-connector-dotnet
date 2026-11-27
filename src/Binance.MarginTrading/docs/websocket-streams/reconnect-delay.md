# Reconnect Delay

Specify the delay between WebSocket reconnection attempts for streams (a `TimeSpan`); after a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it. After a reconnect the client subscribes again to every stream.

```csharp
using Binance.Common;
using Binance.MarginTrading.RestApi;
using Binance.MarginTrading.WebSocketStreams;

var config = new WebSocketStreamsConfig { ReconnectDelay = TimeSpan.FromSeconds(3) };
var client = MarginTradingWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var rest = MarginTradingRestApi.Production(new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
});
// Keep the listen key open with KeepaliveUserDataStreamAsync at least every 60 minutes.
var listenKey = (await rest.StartUserDataStreamAsync()).Data()!.ListenKey!;

using var riskData = connection.RiskData(listenKey);

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in riskData.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(MarginTradingWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
