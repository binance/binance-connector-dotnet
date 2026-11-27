# Compression

Enable or disable compression for WebSocket messages.

```csharp
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.WebSocketApi;

var config = new WebSocketApiConfig { Compression = false };
var client = DerivativesTradingUsdsFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.SymbolOrderBookTickerAsync();

Console.WriteLine(DerivativesTradingUsdsFuturesWebSocketApiJson.ToJson(response.Data()));
```
