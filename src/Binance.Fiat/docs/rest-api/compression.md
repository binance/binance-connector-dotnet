# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Fiat.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = FiatRestApi.Production(config);

var response = await client.GetFiatDepositWithdrawHistoryAsync(new() { TransactionType = "0" });

Console.WriteLine(FiatRestApiJson.ToJson(response.Data()));
```
