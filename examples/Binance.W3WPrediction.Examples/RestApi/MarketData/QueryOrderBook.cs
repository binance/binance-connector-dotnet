//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.W3WPrediction.RestApi;

namespace Binance.W3WPrediction.Examples.RestApi.MarketData;

public static class QueryOrderBook
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
            var response = await client.QueryOrderBookAsync(new()
            {
                Vendor = "predict_fun",
                MarketId = 5567895L,
                TokenId = "112233",
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"QueryOrderBookAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

