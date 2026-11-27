# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.DerivativesTradingCoinFutures.RestApi;

var config = new RestApiConfig
{
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = DerivativesTradingCoinFuturesRestApi.Production(config);

var response = await client.CheckServerTimeAsync();

Console.WriteLine(DerivativesTradingCoinFuturesRestApiJson.ToJson(response.Data()));
```
