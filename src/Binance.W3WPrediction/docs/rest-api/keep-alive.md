# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.W3WPrediction.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = W3WPredictionRestApi.Production(config);

var response = await client.ListPredictionCategoriesAsync();

Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
```
