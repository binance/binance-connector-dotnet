# Connection Mode

Choose between a single connection (`WebSocketMode.Single`, the default) and a pool of connections, in the configuration or for
one connection.

```csharp
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.WebSocketApi;

var config = new WebSocketApiConfig { Mode = WebSocketMode.Pool(3) };
var client = DerivativesTradingUsdsFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync(); // or client.ConnectAsync(WebSocketMode.Pool(5))

var response = await connection.SymbolOrderBookTickerAsync();

Console.WriteLine(DerivativesTradingUsdsFuturesWebSocketApiJson.ToJson(response.Data()));
```
