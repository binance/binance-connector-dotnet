# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Algo.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = AlgoRestApi.Production(config);

var response = await client.QueryCurrentAlgoOpenOrdersFutureAlgoAsync();

Console.WriteLine(AlgoRestApiJson.ToJson(response.Data()));
```
