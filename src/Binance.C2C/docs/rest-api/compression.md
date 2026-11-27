# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.C2C.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = C2CRestApi.Production(config);

var response = await client.GetC2CTradeHistoryAsync();

Console.WriteLine(C2CRestApiJson.ToJson(response.Data()));
```
