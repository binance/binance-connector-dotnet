# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.GiftCard.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = GiftCardRestApi.Production(config);

var response = await client.FetchRsaPublicKeyAsync();

Console.WriteLine(GiftCardRestApiJson.ToJson(response.Data()));
```
