# Client Certificates and Timestamps

A client certificate (mutual TLS) is set with the certificate and its private key, as PEM text or files. `TimestampProvider` returns the time for the `timestamp` of signed requests instead of the host clock (or set `TimeOffset`, a fixed offset added to it).

```csharp
using Binance.Common;
using Binance.C2C.RestApi;

var config = new RestApiConfig
{
    ClientCertificateFile = "/path/to/client.pem",
    ClientKeyFile = "/path/to/client.key",
    TimestampProvider = () => DateTimeOffset.UtcNow + clockSkew,
};
using var client = C2CRestApi.Production(config);

var response = await client.GetC2CTradeHistoryAsync();

Console.WriteLine(C2CRestApiJson.ToJson(response.Data()));
```
