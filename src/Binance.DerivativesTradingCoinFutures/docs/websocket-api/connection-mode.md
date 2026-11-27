# Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

var config = new WebSocketApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Mode = WebSocketMode.Pool(3),
};
var client = DerivativesTradingCoinFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync(); // or client.ConnectAsync(WebSocketMode.Pool(5))

var response = await connection.AccountInformationAsync();

Console.WriteLine(DerivativesTradingCoinFuturesWebSocketApiJson.ToJson(response.Data()));
```
