# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

var config = new WebSocketStreamsConfig { Compression = false };
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
