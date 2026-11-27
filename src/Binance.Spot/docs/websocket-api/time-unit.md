# Time Unit

Specify the time unit for WebSocket API timestamps (`Millisecond` or `Microsecond`).

```csharp
using Binance.Common;
using Binance.Spot.WebSocketApi;

var config = new WebSocketApiConfig { TimeUnit = TimeUnit.Microsecond };
var client = SpotWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.ExchangeInfoAsync();

Console.WriteLine(SpotWebSocketApiJson.ToJson(response.Data()));
```
