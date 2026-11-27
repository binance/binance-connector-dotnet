# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Stocks.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = StocksRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(StocksRestApiJson.ToJson(response.Data()));
```
