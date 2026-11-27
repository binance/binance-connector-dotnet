# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.DerivativesTradingOptions.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = DerivativesTradingOptionsRestApi.Production(config);

var response = await client.CheckServerTimeAsync();

Console.WriteLine(DerivativesTradingOptionsRestApiJson.ToJson(response.Data()));
```
