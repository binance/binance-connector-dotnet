# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = DerivativesTradingPortfolioMarginRestApi.Production(config);

var response = await client.TestConnectivityAsync();

Console.WriteLine(DerivativesTradingPortfolioMarginRestApiJson.ToJson(response.Data()));
```
