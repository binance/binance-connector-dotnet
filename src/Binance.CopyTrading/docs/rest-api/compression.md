# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.CopyTrading.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = CopyTradingRestApi.Production(config);

var response = await client.GetFuturesLeadTraderStatusAsync();

Console.WriteLine(CopyTradingRestApiJson.ToJson(response.Data()));
```
