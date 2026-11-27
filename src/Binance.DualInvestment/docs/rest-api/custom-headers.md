# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.DualInvestment.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = DualInvestmentRestApi.Production(config);

var response = await client.GetDualInvestmentProductListAsync(new()
{
    OptionType = GetDualInvestmentProductListOptionType.Call,
    ExercisedCoin = "USDT",
    InvestCoin = "BNB",
});

Console.WriteLine(DualInvestmentRestApiJson.ToJson(response.Data()));
```
