# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.MarginTrading.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = MarginTradingRestApi.Production(config);

var response = await client.CrossMarginCollateralRatioAsync();

Console.WriteLine(MarginTradingRestApiJson.ToJson(response.Data()));
```
