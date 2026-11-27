# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.DualInvestment.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = DualInvestmentRestApi.Production(config);

var response = await client.GetDualInvestmentProductListAsync(new()
{
    OptionType = GetDualInvestmentProductListOptionType.Call,
    ExercisedCoin = "USDT",
    InvestCoin = "BNB",
});

Console.WriteLine(DualInvestmentRestApiJson.ToJson(response.Data()));
```
