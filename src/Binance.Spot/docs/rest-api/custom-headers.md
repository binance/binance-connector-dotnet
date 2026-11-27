# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = SpotRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(SpotRestApiJson.ToJson(response.Data()));
```
