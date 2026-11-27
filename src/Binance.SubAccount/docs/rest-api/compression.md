# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.SubAccount.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = SubAccountRestApi.Production(config);

var response = await client.GetSubAccountsStatusOnMarginOrFuturesAsync();

Console.WriteLine(SubAccountRestApiJson.ToJson(response.Data()));
```
