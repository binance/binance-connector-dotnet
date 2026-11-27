# Retries

Configure the number of attempts and the delay between them (`Backoff`, a `TimeSpan`). `GET` and `DELETE` requests are retried after a network error or an HTTP 500, 502, 503 or 504. Every retry of a signed request is signed again.

```csharp
using Binance.Common;
using Binance.Pay.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Retries = 5, Backoff = TimeSpan.FromSeconds(2),
};
using var client = PayRestApi.Production(config);

var response = await client.GetPayTradeHistoryAsync();

Console.WriteLine(PayRestApiJson.ToJson(response.Data()));
```
