# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.SubAccount.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = SubAccountRestApi.Production(config);

var response = await client.GetSubAccountsStatusOnMarginOrFuturesAsync();

Console.WriteLine(SubAccountRestApiJson.ToJson(response.Data()));
```
