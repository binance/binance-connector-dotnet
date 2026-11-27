# Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

```csharp
using Binance.Common;
using Binance.SimpleEarn.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Proxy = new ProxyConfig("127.0.0.1", 8080, ProxyProtocol.Http, Username: "proxy-user", Password: "proxy-password"),
};
using var client = SimpleEarnRestApi.Production(config);

var response = await client.GetBfusdAccountAsync();

Console.WriteLine(SimpleEarnRestApiJson.ToJson(response.Data()));
```
