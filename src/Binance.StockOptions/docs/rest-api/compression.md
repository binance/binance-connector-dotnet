# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.StockOptions.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = StockOptionsRestApi.Production(config);

var response = await client.OptionContractsAsync(new()
{
    UnderlyingSymbol = "NVDA",
    ExpirationDate = "2026-09-30",
});

Console.WriteLine(StockOptionsRestApiJson.ToJson(response.Data()));
```
