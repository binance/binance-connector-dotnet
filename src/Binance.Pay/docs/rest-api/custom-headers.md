# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Pay.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = PayRestApi.Production(config);

var response = await client.GetPayTradeHistoryAsync();

Console.WriteLine(PayRestApiJson.ToJson(response.Data()));
```
