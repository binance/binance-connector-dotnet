//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.StockOptions.RestApi;

namespace Binance.StockOptions.Examples.RestApi.UserData;

public static class OptionTradeHistory
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new StockOptionsRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? StockOptionsRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.OptionTradeHistoryAsync(new()
            {
                StartTime = 1790100000000L,
                EndTime = 1790200000000L,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(StockOptionsRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"OptionTradeHistoryAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

