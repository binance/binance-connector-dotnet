# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Alpha.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = AlphaRestApi.Production(config);

var response = await client.GetExchangeInfoAsync();

Console.WriteLine(AlphaRestApiJson.ToJson(response.Data()));
```
