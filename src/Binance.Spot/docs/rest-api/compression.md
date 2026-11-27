# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Spot.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = SpotRestApi.Production(config);

var response = await client.ExchangeInfoAsync();

Console.WriteLine(SpotRestApiJson.ToJson(response.Data()));
```
