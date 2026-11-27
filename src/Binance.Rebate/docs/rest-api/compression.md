# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Rebate.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = RebateRestApi.Production(config);

var response = await client.GetSpotRebateHistoryRecordsAsync();

Console.WriteLine(RebateRestApiJson.ToJson(response.Data()));
```
