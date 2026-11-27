# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.SimpleEarn.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = SimpleEarnRestApi.Production(config);

var response = await client.GetBfusdAccountAsync();

Console.WriteLine(SimpleEarnRestApiJson.ToJson(response.Data()));
```
