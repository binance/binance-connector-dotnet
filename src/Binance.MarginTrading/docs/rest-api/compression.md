# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.MarginTrading.RestApi;

var config = new RestApiConfig { Compression = false };
using var client = MarginTradingRestApi.Production(config);

var response = await client.CrossMarginCollateralRatioAsync();

Console.WriteLine(MarginTradingRestApiJson.ToJson(response.Data()));
```
