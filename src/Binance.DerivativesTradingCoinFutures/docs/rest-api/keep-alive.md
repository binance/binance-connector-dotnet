# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = DerivativesTradingCoinFuturesRestApi.Production(config);

var response = await client.CheckServerTimeAsync();

Console.WriteLine(DerivativesTradingCoinFuturesRestApiJson.ToJson(response.Data()));
```
