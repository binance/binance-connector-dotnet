# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.DerivativesTradingOptions.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = DerivativesTradingOptionsRestApi.Production(config);

var response = await client.CheckServerTimeAsync();

Console.WriteLine(DerivativesTradingOptionsRestApiJson.ToJson(response.Data()));
```
