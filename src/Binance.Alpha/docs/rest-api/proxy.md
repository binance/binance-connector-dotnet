# Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

```csharp
using Binance.Common;
using Binance.Alpha.RestApi;

var config = new RestApiConfig
{
    Proxy = new ProxyConfig("127.0.0.1", 8080, ProxyProtocol.Http, Username: "proxy-user", Password: "proxy-password"),
};
using var client = AlphaRestApi.Production(config);

var response = await client.GetExchangeInfoAsync();

Console.WriteLine(AlphaRestApiJson.ToJson(response.Data()));
```
