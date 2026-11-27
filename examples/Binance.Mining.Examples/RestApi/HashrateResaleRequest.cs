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

public static class HashrateResaleRequest
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new MiningRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? MiningRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.HashrateResaleRequestAsync(new()
            {
                UserName = "test",
                Algo = "sha256",
                EndDate = 1770736694138L,
                StartDate = 1770736694138L,
                ToPoolUser = "S19pro",
                HashRate = 100000000L,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(MiningRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"HashrateResaleRequestAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

