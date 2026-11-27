# Compression

Enable or disable compression for WebSocket messages.

```csharp
using Binance.Common;
using Binance.Spot.WebSocketApi;

var config = new WebSocketApiConfig { Compression = false };
var client = SpotWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.ExchangeInfoAsync();

Console.WriteLine(SpotWebSocketApiJson.ToJson(response.Data()));
```
