# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = DerivativesTradingPortfolioMarginProRestApi.Production(config);

var response = await client.GetPortfolioMarginTieredCollateralRatesAsync();

Console.WriteLine(DerivativesTradingPortfolioMarginProRestApiJson.ToJson(response.Data()));
```
