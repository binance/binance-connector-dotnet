# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Mining.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = MiningRestApi.Production(config);

var response = await client.AcquiringAlgorithmAsync();

Console.WriteLine(MiningRestApiJson.ToJson(response.Data()));
```
