# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Rebate.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = RebateRestApi.Production(config);

var response = await client.GetSpotRebateHistoryRecordsAsync();

Console.WriteLine(RebateRestApiJson.ToJson(response.Data()));
```
