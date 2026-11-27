//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Spot.RestApi;

namespace Binance.Spot.Examples.RestApi.Account;

public static class AccountCommission
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new SpotRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? SpotRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.AccountCommissionAsync(new() { Symbol = "BTCUSDT" });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SpotRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"AccountCommissionAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

