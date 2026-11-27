# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Fiat.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = FiatRestApi.Production(config);

var response = await client.GetFiatDepositWithdrawHistoryAsync(new() { TransactionType = "0" });

Console.WriteLine(FiatRestApiJson.ToJson(response.Data()));
```
