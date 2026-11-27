# Key Pair Based Authentication

Use RSA or Ed25519 private keys for WebSocket API authentication.

```csharp
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.WebSocketApi;

var config = new WebSocketApiConfig
{
    ApiKey = "your-api-key",
    PrivateKeyFile = "/path/to/private-key.pem",
};
var client = DerivativesTradingUsdsFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.SymbolOrderBookTickerAsync();

Console.WriteLine(DerivativesTradingUsdsFuturesWebSocketApiJson.ToJson(response.Data()));
```
