//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Rebate.RestApi;

namespace Binance.Rebate.Examples.RestApi;

public static class GetSpotRebateHistoryRecords
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new RebateRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? RebateRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.GetSpotRebateHistoryRecordsAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(RebateRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetSpotRebateHistoryRecordsAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

