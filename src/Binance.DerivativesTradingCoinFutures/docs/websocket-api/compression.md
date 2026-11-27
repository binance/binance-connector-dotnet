# Compression

Enable or disable compression for WebSocket messages.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

var config = new WebSocketApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
var client = DerivativesTradingCoinFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.AccountInformationAsync();

Console.WriteLine(DerivativesTradingCoinFuturesWebSocketApiJson.ToJson(response.Data()));
```
