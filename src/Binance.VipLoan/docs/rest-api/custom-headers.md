# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.VipLoan.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = VipLoanRestApi.Production(config);

var response = await client.GetCollateralAssetDataAsync();

Console.WriteLine(VipLoanRestApiJson.ToJson(response.Data()));
```
