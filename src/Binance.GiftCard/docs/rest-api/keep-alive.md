# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.GiftCard.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = GiftCardRestApi.Production(config);

var response = await client.FetchRsaPublicKeyAsync();

Console.WriteLine(GiftCardRestApiJson.ToJson(response.Data()));
```
