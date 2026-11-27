# Timeout

Set the timeout for WebSocket API requests (a `TimeSpan`). A request without a response in time fails with a `BinanceException`.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

var config = new WebSocketApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Timeout = TimeSpan.FromSeconds(10),
};
var client = DerivativesTradingCoinFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.AccountInformationAsync();

Console.WriteLine(DerivativesTradingCoinFuturesWebSocketApiJson.ToJson(response.Data()));
```
