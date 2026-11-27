# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Convert.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = ConvertRestApi.Production(config);

var response = await client.ListAllConvertPairsAsync();

Console.WriteLine(ConvertRestApiJson.ToJson(response.Data()));
```
