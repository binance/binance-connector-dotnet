# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Alpha.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = AlphaRestApi.Production(config);

var response = await client.GetExchangeInfoAsync();

Console.WriteLine(AlphaRestApiJson.ToJson(response.Data()));
```
