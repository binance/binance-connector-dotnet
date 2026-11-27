//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Algo.RestApi;

namespace Binance.Algo.Examples.RestApi.SpotAlgo;

public static class QueryHistoricalAlgoOrdersSpotAlgo
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new AlgoRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? AlgoRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.QueryHistoricalAlgoOrdersSpotAlgoAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(AlgoRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"QueryHistoricalAlgoOrdersSpotAlgoAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

