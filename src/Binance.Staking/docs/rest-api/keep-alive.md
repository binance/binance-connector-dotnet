# Keep-Alive

Enable HTTP keep-alive for persistent connections (enabled by default).

```csharp
using Binance.Common;
using Binance.Staking.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    KeepAlive = false,
};
using var client = StakingRestApi.Production(config);

var response = await client.EthStakingAccountAsync();

Console.WriteLine(StakingRestApiJson.ToJson(response.Data()));
```
