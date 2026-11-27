//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Mining.RestApi;

namespace Binance.Mining.Examples.RestApi;

public static class HashrateResaleDetail
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new MiningRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? MiningRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.HashrateResaleDetailAsync(new() { ConfigId = 168L });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(MiningRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"HashrateResaleDetailAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

