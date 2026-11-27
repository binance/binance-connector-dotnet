# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Pay.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = PayRestApi.Production(config);

var response = await client.GetPayTradeHistoryAsync();

Console.WriteLine(PayRestApiJson.ToJson(response.Data()));
```
