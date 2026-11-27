# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Stocks.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = StocksRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(StocksRestApiJson.ToJson(response.Data()));
```
