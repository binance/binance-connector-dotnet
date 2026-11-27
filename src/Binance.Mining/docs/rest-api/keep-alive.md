# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Mining.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = MiningRestApi.Production(config);

var response = await client.AcquiringAlgorithmAsync();

Console.WriteLine(MiningRestApiJson.ToJson(response.Data()));
```
