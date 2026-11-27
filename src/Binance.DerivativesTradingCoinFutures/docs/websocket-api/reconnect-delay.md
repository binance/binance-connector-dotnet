# Reconnect Delay

Specify the delay between WebSocket reconnection attempts (a `TimeSpan`); after a failed attempt, a backoff of 1 second doubling up to 60 seconds, with random jitter, is added to it.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

var config = new WebSocketApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    ReconnectDelay = TimeSpan.FromSeconds(3),
};
var client = DerivativesTradingCoinFuturesWebSocketApi.Production(config);
await using var connection = await client.ConnectAsync();

var response = await connection.AccountInformationAsync();

Console.WriteLine(DerivativesTradingCoinFuturesWebSocketApiJson.ToJson(response.Data()));
```
