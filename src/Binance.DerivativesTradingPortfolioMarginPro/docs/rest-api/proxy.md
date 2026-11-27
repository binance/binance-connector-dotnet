# Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.RestApi;

var config = new RestApiConfig
{
    Proxy = new ProxyConfig("127.0.0.1", 8080, ProxyProtocol.Http, Username: "proxy-user", Password: "proxy-password"),
};
using var client = DerivativesTradingPortfolioMarginProRestApi.Production(config);

var response = await client.GetPortfolioMarginTieredCollateralRatesAsync();

Console.WriteLine(DerivativesTradingPortfolioMarginProRestApiJson.ToJson(response.Data()));
```
