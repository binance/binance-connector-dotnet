//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Alpha.RestApi;

namespace Binance.Alpha.Examples.RestApi.MarketData;

public static class FullDepth
{
    public static async Task Main()
    {
        using var client = new AlphaRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? AlphaRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.FullDepthAsync(new() { Symbol = "ALPHA_175USDT" });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(AlphaRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"FullDepthAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

