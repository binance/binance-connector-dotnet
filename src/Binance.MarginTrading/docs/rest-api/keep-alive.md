# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.MarginTrading.RestApi;

var config = new RestApiConfig { KeepAlive = false };
using var client = MarginTradingRestApi.Production(config);

var response = await client.CrossMarginCollateralRatioAsync();

Console.WriteLine(MarginTradingRestApiJson.ToJson(response.Data()));
```
