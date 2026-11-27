# Client Certificates and Timestamps

A client certificate (mutual TLS) is set with the certificate and its private key, as PEM text or files. `TimestampProvider` returns the time for the `timestamp` of signed requests instead of the host clock (or set `TimeOffset`, a fixed offset added to it).

```csharp
using Binance.Common;
using Binance.StockOptions.RestApi;

var config = new RestApiConfig
{
    ClientCertificateFile = "/path/to/client.pem",
    ClientKeyFile = "/path/to/client.key",
    TimestampProvider = () => DateTimeOffset.UtcNow + clockSkew,
};
using var client = StockOptionsRestApi.Production(config);

var response = await client.OptionContractsAsync(new()
{
    UnderlyingSymbol = "NVDA",
    ExpirationDate = "2026-09-30",
});

Console.WriteLine(StockOptionsRestApiJson.ToJson(response.Data()));
```
