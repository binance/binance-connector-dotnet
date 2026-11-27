# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.DualInvestment.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = DualInvestmentRestApi.Production(config);

var response = await client.GetDualInvestmentProductListAsync(new()
{
    OptionType = GetDualInvestmentProductListOptionType.Call,
    ExercisedCoin = "USDT",
    InvestCoin = "BNB",
});

Console.WriteLine(DualInvestmentRestApiJson.ToJson(response.Data()));
```
