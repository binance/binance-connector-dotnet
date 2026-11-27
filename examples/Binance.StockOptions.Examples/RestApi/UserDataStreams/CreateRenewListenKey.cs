//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.StockOptions.RestApi;

namespace Binance.StockOptions.Examples.RestApi.UserDataStreams;

public static class CreateRenewListenKey
{
    public static async Task Main()
    {
        using var client = new StockOptionsRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? StockOptionsRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.CreateRenewListenKeyAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(StockOptionsRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"CreateRenewListenKeyAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

