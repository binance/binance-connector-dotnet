# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.C2C.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = C2CRestApi.Production(config);

var response = await client.GetC2CTradeHistoryAsync();

Console.WriteLine(C2CRestApiJson.ToJson(response.Data()));
```
