# Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

```csharp
using Binance.Common;
using Binance.StockOptions.RestApi;

var config = new RestApiConfig
{
    Proxy = new ProxyConfig("127.0.0.1", 8080, ProxyProtocol.Http, Username: "proxy-user", Password: "proxy-password"),
};
using var client = StockOptionsRestApi.Production(config);

var response = await client.OptionContractsAsync(new()
{
    UnderlyingSymbol = "NVDA",
    ExpirationDate = "2026-09-30",
});

Console.WriteLine(StockOptionsRestApiJson.ToJson(response.Data()));
```
