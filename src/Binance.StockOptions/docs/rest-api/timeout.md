# Timeout

You can configure a timeout for requests (a `TimeSpan`). If an attempt takes longer than the timeout (connecting, writing the request and reading the whole response), it is aborted with a `BinanceTimeoutException`.

```csharp
using Binance.Common;
using Binance.StockOptions.RestApi;

var config = new RestApiConfig { Timeout = TimeSpan.FromSeconds(5) };
using var client = StockOptionsRestApi.Production(config);

var response = await client.OptionContractsAsync(new()
{
    UnderlyingSymbol = "NVDA",
    ExpirationDate = "2026-09-30",
});

Console.WriteLine(StockOptionsRestApiJson.ToJson(response.Data()));
```
