# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = DerivativesTradingCoinFuturesRestApi.Production(config);

var response = await client.CheckServerTimeAsync();

Console.WriteLine(DerivativesTradingCoinFuturesRestApiJson.ToJson(response.Data()));
```
