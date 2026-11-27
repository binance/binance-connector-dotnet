# Compression

Enable or disable compression for WebSocket Streams messages.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;
using Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

var config = new WebSocketStreamsConfig { Compression = false };
var client = DerivativesTradingPortfolioMarginWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var rest = DerivativesTradingPortfolioMarginRestApi.Production(new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
});
// Keep the listen key open with KeepaliveUserDataStreamAsync at least every 60 minutes.
var listenKey = (await rest.StartUserDataStreamAsync()).Data()!.ListenKey!;

using var userData = connection.UserData(listenKey);

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in userData.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(DerivativesTradingPortfolioMarginWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
