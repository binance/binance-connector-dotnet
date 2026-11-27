# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Wallet.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = WalletRestApi.Production(config);

var response = await client.GetOpenSymbolListAsync();

Console.WriteLine(WalletRestApiJson.ToJson(response.Data()));
```
