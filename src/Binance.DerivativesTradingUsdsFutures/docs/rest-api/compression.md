# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = DerivativesTradingUsdsFuturesRestApi.Production(config);

var response = await client.AdlRiskAsync();

Console.WriteLine(DerivativesTradingUsdsFuturesRestApiJson.ToJson(response.Data()));
```
