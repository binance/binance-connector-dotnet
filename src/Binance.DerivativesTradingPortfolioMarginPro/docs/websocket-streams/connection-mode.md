# Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

var config = new WebSocketStreamsConfig { Mode = WebSocketMode.Pool(3) };
var client = DerivativesTradingPortfolioMarginProWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync(mode: WebSocketMode.Pool(5)); // or the configured mode

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
