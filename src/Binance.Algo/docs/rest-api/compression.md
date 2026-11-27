# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Algo.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = AlgoRestApi.Production(config);

var response = await client.QueryCurrentAlgoOpenOrdersFutureAlgoAsync();

Console.WriteLine(AlgoRestApiJson.ToJson(response.Data()));
```
