# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.SubAccount.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = SubAccountRestApi.Production(config);

var response = await client.GetSubAccountsStatusOnMarginOrFuturesAsync();

Console.WriteLine(SubAccountRestApiJson.ToJson(response.Data()));
```
