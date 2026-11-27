# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Convert.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = ConvertRestApi.Production(config);

var response = await client.ListAllConvertPairsAsync();

Console.WriteLine(ConvertRestApiJson.ToJson(response.Data()));
```
