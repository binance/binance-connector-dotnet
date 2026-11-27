# Reconnect Delay

Specify the delay between WebSocket reconnection attempts (a `TimeSpan`); after a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it.

```csharp
using Binance.Common;
using Binance.Spot.WebSocketApi;

var config = new WebSocketApiConfig { ReconnectDelay = TimeSpan.FromSeconds(3) };
var client = SpotWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.ExchangeInfoAsync();

Console.WriteLine(SpotWebSocketApiJson.ToJson(response.Data()));
```
