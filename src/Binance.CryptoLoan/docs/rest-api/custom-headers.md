# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.CryptoLoan.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = CryptoLoanRestApi.Production(config);

var response = await client.GetFlexibleLoanAssetsDataAsync();

Console.WriteLine(CryptoLoanRestApiJson.ToJson(response.Data()));
```
