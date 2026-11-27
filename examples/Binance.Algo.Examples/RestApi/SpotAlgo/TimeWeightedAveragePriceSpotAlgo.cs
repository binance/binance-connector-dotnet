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

public static class TimeWeightedAveragePriceSpotAlgo
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new AlgoRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? AlgoRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.TimeWeightedAveragePriceSpotAlgoAsync(new()
            {
                Symbol = "BTCUSDT",
                Side = TimeWeightedAveragePriceSpotAlgoSide.Buy,
                Quantity = 1m,
                Duration = 5000L,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(AlgoRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"TimeWeightedAveragePriceSpotAlgoAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

