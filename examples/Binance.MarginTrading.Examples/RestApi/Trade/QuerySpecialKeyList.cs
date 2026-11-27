//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.MarginTrading.RestApi;

namespace Binance.MarginTrading.Examples.RestApi.Trade;

public static class QuerySpecialKeyList
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new MarginTradingRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? MarginTradingRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.QuerySpecialKeyListAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(MarginTradingRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"QuerySpecialKeyListAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

