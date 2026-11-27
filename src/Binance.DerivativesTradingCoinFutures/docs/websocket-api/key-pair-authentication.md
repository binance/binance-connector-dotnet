# Key Pair Based Authentication

Use RSA or Ed25519 private keys for WebSocket API authentication.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

var config = new WebSocketApiConfig
{
    ApiKey = "your-api-key",
    PrivateKeyFile = "/path/to/private-key.pem",
};
var client = DerivativesTradingCoinFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.AccountInformationAsync();

Console.WriteLine(DerivativesTradingCoinFuturesWebSocketApiJson.ToJson(response.Data()));
```
