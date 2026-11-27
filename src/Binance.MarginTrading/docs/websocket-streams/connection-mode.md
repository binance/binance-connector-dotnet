# Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

```csharp
using Binance.Common;
using Binance.MarginTrading.RestApi;
using Binance.MarginTrading.WebSocketStreams;

var config = new WebSocketStreamsConfig { Mode = WebSocketMode.Pool(3) };
var client = MarginTradingWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync(mode: WebSocketMode.Pool(5)); // or the configured mode

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
