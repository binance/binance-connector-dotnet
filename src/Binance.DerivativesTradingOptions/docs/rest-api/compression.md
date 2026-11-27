# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingOptions.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = DerivativesTradingOptionsRestApi.Production(config);

var response = await client.CheckServerTimeAsync();

Console.WriteLine(DerivativesTradingOptionsRestApiJson.ToJson(response.Data()));
```
