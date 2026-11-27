# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.GiftCard.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = GiftCardRestApi.Production(config);

var response = await client.FetchRsaPublicKeyAsync();

Console.WriteLine(GiftCardRestApiJson.ToJson(response.Data()));
```
