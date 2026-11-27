# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Pay.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = PayRestApi.Production(config);

var response = await client.GetPayTradeHistoryAsync();

Console.WriteLine(PayRestApiJson.ToJson(response.Data()));
```
