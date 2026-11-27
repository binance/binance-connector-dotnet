# Retries

Configure the number of attempts and the delay between them (`Backoff`, a `TimeSpan`). `GET` and `DELETE` requests are retried after a network error or an HTTP 500, 502, 503 or 504. Every retry of a signed request is signed again.

```csharp
using Binance.Common;
using Binance.SimpleEarn.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Retries = 5, Backoff = TimeSpan.FromSeconds(2),
};
using var client = SimpleEarnRestApi.Production(config);

var response = await client.GetBfusdAccountAsync();

Console.WriteLine(SimpleEarnRestApiJson.ToJson(response.Data()));
```
