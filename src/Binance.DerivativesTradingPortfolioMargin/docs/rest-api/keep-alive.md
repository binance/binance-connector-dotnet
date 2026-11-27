# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = DerivativesTradingPortfolioMarginRestApi.Production(config);

var response = await client.TestConnectivityAsync();

Console.WriteLine(DerivativesTradingPortfolioMarginRestApiJson.ToJson(response.Data()));
```
