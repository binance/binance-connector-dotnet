# Timeout

Set the timeout for WebSocket API requests (a `TimeSpan`). A request without a response in time fails with a `BinanceException`.

```csharp
using Binance.Common;
using Binance.Spot.WebSocketApi;

var config = new WebSocketApiConfig { Timeout = TimeSpan.FromSeconds(10) };
var client = SpotWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.ExchangeInfoAsync();

Console.WriteLine(SpotWebSocketApiJson.ToJson(response.Data()));
```
