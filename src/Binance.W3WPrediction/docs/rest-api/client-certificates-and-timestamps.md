# Client Certificates and Timestamps

A client certificate (mutual TLS) is set with the certificate and its private key, as PEM text or files. `TimestampProvider` returns the time for the `timestamp` of signed requests instead of the host clock (or set `TimeOffset`, a fixed offset added to it).

```csharp
using Binance.Common;
using Binance.W3WPrediction.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    ClientCertificateFile = "/path/to/client.pem",
    ClientKeyFile = "/path/to/client.key",
    TimestampProvider = () => DateTimeOffset.UtcNow + clockSkew,
};
using var client = W3WPredictionRestApi.Production(config);

var response = await client.ListPredictionCategoriesAsync();

Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
```
