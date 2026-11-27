# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Convert.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = ConvertRestApi.Production(config);

var response = await client.ListAllConvertPairsAsync();

Console.WriteLine(ConvertRestApiJson.ToJson(response.Data()));
```
