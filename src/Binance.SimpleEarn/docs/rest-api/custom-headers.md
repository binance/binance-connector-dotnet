# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.SimpleEarn.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = SimpleEarnRestApi.Production(config);

var response = await client.GetBfusdAccountAsync();

Console.WriteLine(SimpleEarnRestApiJson.ToJson(response.Data()));
```
