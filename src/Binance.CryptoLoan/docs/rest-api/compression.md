# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.CryptoLoan.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = CryptoLoanRestApi.Production(config);

var response = await client.GetFlexibleLoanAssetsDataAsync();

Console.WriteLine(CryptoLoanRestApiJson.ToJson(response.Data()));
```
