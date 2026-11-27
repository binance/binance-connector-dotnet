# Time Unit

The REST API supports different time units for timestamp values. Set `TimeUnit` to send and receive microseconds instead of milliseconds.

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

var config = new RestApiConfig { TimeUnit = TimeUnit.Microsecond };
using var client = SpotRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(SpotRestApiJson.ToJson(response.Data()));
```
