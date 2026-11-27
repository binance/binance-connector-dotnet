# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = DerivativesTradingPortfolioMarginProRestApi.Production(config);

var response = await client.GetPortfolioMarginTieredCollateralRatesAsync();

Console.WriteLine(DerivativesTradingPortfolioMarginProRestApiJson.ToJson(response.Data()));
```
