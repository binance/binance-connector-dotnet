//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DualInvestment.RestApi;

namespace Binance.DualInvestment.Examples.RestApi.Trade;

public static class GetDualInvestmentPositions
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new DualInvestmentRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DualInvestmentRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.GetDualInvestmentPositionsAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DualInvestmentRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetDualInvestmentPositionsAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

