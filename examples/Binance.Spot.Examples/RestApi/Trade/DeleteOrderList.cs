//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Spot.RestApi;

namespace Binance.Spot.Examples.RestApi.Trade;

public static class DeleteOrderList
{
    public static async Task Main()
    {
        // This request changes the account of the API key: the example runs on the demo environment, so that no real
        // order is placed. Use demo API keys (they are separate from the production ones).
        using var client = new SpotRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? SpotRestApi.DemoUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.DeleteOrderListAsync(new() { Symbol = "BNBUSDT" });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SpotRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"DeleteOrderListAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

