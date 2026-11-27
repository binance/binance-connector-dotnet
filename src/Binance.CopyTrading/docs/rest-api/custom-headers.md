# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.CopyTrading.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = CopyTradingRestApi.Production(config);

var response = await client.GetFuturesLeadTraderStatusAsync();

Console.WriteLine(CopyTradingRestApiJson.ToJson(response.Data()));
```
