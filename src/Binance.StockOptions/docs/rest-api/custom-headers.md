# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.StockOptions.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = StockOptionsRestApi.Production(config);

var response = await client.OptionContractsAsync(new()
{
    UnderlyingSymbol = "NVDA",
    ExpirationDate = "2026-09-30",
});

Console.WriteLine(StockOptionsRestApiJson.ToJson(response.Data()));
```
