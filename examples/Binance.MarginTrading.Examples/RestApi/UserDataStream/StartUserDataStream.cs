//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.MarginTrading.RestApi;

namespace Binance.MarginTrading.Examples.RestApi.UserDataStream;

public static class StartUserDataStream
{
    public static async Task Main()
    {
        using var client = new MarginTradingRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? MarginTradingRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.StartUserDataStreamAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(MarginTradingRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"StartUserDataStreamAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

