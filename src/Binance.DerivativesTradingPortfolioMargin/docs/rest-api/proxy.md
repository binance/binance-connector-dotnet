# Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

var config = new RestApiConfig
{
    Proxy = new ProxyConfig("127.0.0.1", 8080, ProxyProtocol.Http, Username: "proxy-user", Password: "proxy-password"),
};
using var client = DerivativesTradingPortfolioMarginRestApi.Production(config);

var response = await client.TestConnectivityAsync();

Console.WriteLine(DerivativesTradingPortfolioMarginRestApiJson.ToJson(response.Data()));
```
