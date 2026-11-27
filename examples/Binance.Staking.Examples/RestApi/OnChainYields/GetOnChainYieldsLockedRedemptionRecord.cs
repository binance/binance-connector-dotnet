//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Staking.RestApi;

namespace Binance.Staking.Examples.RestApi.OnChainYields;

public static class GetOnChainYieldsLockedRedemptionRecord
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new StakingRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? StakingRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.GetOnChainYieldsLockedRedemptionRecordAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(StakingRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetOnChainYieldsLockedRedemptionRecordAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

