# Timeout

You can configure a timeout for requests (a `TimeSpan`). If an attempt takes longer than the timeout (connecting, writing the request and reading the whole response), it is aborted with a `BinanceTimeoutException`.

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

var config = new RestApiConfig { Timeout = TimeSpan.FromSeconds(5) };
using var client = SpotRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(SpotRestApiJson.ToJson(response.Data()));
```
