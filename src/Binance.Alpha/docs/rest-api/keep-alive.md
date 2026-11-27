# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Alpha.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = AlphaRestApi.Production(config);

var response = await client.GetExchangeInfoAsync();

Console.WriteLine(AlphaRestApiJson.ToJson(response.Data()));
```
