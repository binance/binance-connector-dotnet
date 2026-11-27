# Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

```csharp
using Binance.Common;
using Binance.C2C.RestApi;

var config = new RestApiConfig
{
    Proxy = new ProxyConfig("127.0.0.1", 8080, ProxyProtocol.Http, Username: "proxy-user", Password: "proxy-password"),
};
using var client = C2CRestApi.Production(config);

var response = await client.GetC2CTradeHistoryAsync();

Console.WriteLine(C2CRestApiJson.ToJson(response.Data()));
```
