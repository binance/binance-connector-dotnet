# Retries

Configure the number of attempts and the delay between them (`Backoff`, a `TimeSpan`). `GET` and `DELETE` requests are retried after a network error or an HTTP 500, 502, 503 or 504. Every retry of a signed request is signed again.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.RestApi;

var config = new RestApiConfig { Retries = 5, Backoff = TimeSpan.FromSeconds(2) };
using var client = DerivativesTradingCoinFuturesRestApi.Production(config);

var response = await client.CheckServerTimeAsync();

Console.WriteLine(DerivativesTradingCoinFuturesRestApiJson.ToJson(response.Data()));
```
