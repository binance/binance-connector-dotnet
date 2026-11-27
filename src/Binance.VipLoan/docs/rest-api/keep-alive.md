# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.VipLoan.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = VipLoanRestApi.Production(config);

var response = await client.GetCollateralAssetDataAsync();

Console.WriteLine(VipLoanRestApiJson.ToJson(response.Data()));
```
