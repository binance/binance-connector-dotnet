# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Rebate.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = RebateRestApi.Production(config);

var response = await client.GetSpotRebateHistoryRecordsAsync();

Console.WriteLine(RebateRestApiJson.ToJson(response.Data()));
```
