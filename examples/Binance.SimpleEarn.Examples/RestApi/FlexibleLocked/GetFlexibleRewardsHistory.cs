//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.SimpleEarn.RestApi;

namespace Binance.SimpleEarn.Examples.RestApi.FlexibleLocked;

public static class GetFlexibleRewardsHistory
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new SimpleEarnRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? SimpleEarnRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.GetFlexibleRewardsHistoryAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SimpleEarnRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetFlexibleRewardsHistoryAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

