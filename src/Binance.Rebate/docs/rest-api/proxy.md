# Proxy

The REST API supports HTTP/HTTPS proxy configurations, with optional Basic authentication. Without `Proxy`, the proxy variables of the environment are used.

```csharp
using Binance.Common;
using Binance.Rebate.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Proxy = new ProxyConfig("127.0.0.1", 8080, ProxyProtocol.Http, Username: "proxy-user", Password: "proxy-password"),
};
using var client = RebateRestApi.Production(config);

var response = await client.GetSpotRebateHistoryRecordsAsync();

Console.WriteLine(RebateRestApiJson.ToJson(response.Data()));
```
