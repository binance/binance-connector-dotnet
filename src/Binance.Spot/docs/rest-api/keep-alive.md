# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = SpotRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(SpotRestApiJson.ToJson(response.Data()));
```
