//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.W3WPrediction.RestApi;

namespace Binance.W3WPrediction.Examples.RestApi.Position;

public static class QueryPositions
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new W3WPredictionRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? W3WPredictionRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.QueryPositionsAsync(new()
            {
                WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"QueryPositionsAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

