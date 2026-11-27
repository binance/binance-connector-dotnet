# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = DerivativesTradingUsdsFuturesRestApi.Production(config);

var response = await client.AdlRiskAsync();

Console.WriteLine(DerivativesTradingUsdsFuturesRestApiJson.ToJson(response.Data()));
```
