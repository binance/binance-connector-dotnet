# Timeout

You can configure a timeout for requests (a `TimeSpan`). If an attempt takes longer than the timeout (connecting, writing the request and reading the whole response), it is aborted with a `BinanceTimeoutException`.

```csharp
using Binance.Common;
using Binance.CryptoLoan.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Timeout = TimeSpan.FromSeconds(5),
};
using var client = CryptoLoanRestApi.Production(config);

var response = await client.GetFlexibleLoanAssetsDataAsync();

Console.WriteLine(CryptoLoanRestApiJson.ToJson(response.Data()));
```
