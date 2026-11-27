# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Mining.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = MiningRestApi.Production(config);

var response = await client.AcquiringAlgorithmAsync();

Console.WriteLine(MiningRestApiJson.ToJson(response.Data()));
```
