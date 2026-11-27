# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Stocks.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = StocksRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(StocksRestApiJson.ToJson(response.Data()));
```
