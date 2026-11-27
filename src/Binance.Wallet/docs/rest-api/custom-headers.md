# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Wallet.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = WalletRestApi.Production(config);

var response = await client.GetOpenSymbolListAsync();

Console.WriteLine(WalletRestApiJson.ToJson(response.Data()));
```
