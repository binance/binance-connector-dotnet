# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = DerivativesTradingUsdsFuturesRestApi.Production(config);

var response = await client.AdlRiskAsync();

Console.WriteLine(DerivativesTradingUsdsFuturesRestApiJson.ToJson(response.Data()));
```
