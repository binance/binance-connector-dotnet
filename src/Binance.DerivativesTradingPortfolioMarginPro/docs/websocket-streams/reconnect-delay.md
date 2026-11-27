# Reconnect Delay

Specify the delay between WebSocket reconnection attempts for streams (a `TimeSpan`); after a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it. After a reconnect the client subscribes again to every stream.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

var config = new WebSocketStreamsConfig { ReconnectDelay = TimeSpan.FromSeconds(3) };
var client = DerivativesTradingPortfolioMarginProWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

var listenKey = "your-listen-key"; // from StartUserDataStreamAsync of Binance.DerivativesTradingPortfolioMargin

using var userData = connection.UserData(listenKey);

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in userData.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(DerivativesTradingPortfolioMarginProWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
