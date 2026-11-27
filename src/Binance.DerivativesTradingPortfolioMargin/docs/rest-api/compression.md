# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = DerivativesTradingPortfolioMarginRestApi.Production(config);

var response = await client.TestConnectivityAsync();

Console.WriteLine(DerivativesTradingPortfolioMarginRestApiJson.ToJson(response.Data()));
```
