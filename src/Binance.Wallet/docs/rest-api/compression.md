# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Wallet.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = WalletRestApi.Production(config);

var response = await client.GetOpenSymbolListAsync();

Console.WriteLine(WalletRestApiJson.ToJson(response.Data()));
```
