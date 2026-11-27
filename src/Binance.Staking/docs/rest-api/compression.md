# Compression

Enable or disable response compression (enabled by default).

```csharp
using Binance.Common;
using Binance.Staking.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    Compression = false,
};
using var client = StakingRestApi.Production(config);

var response = await client.EthStakingAccountAsync();

Console.WriteLine(StakingRestApiJson.ToJson(response.Data()));
```
