# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.W3WPrediction.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = W3WPredictionRestApi.Production(config);

var response = await client.ListPredictionCategoriesAsync();

Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
```
