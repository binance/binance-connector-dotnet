# Custom Headers

Add headers to every request.

```csharp
using Binance.Common;
using Binance.Staking.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CustomHeaders = new Dictionary<string, string> { ["X-Custom-Header"] = "value" },
};
using var client = StakingRestApi.Production(config);

var response = await client.EthStakingAccountAsync();

Console.WriteLine(StakingRestApiJson.ToJson(response.Data()));
```
