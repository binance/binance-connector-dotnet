//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Stocks.RestApi;

namespace Binance.Stocks.Examples.RestApi.MarketData;

public static class TokenizedAssets
{
    public static async Task Main()
    {
        using var client = new StocksRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? StocksRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.TokenizedAssetsAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(StocksRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"TokenizedAssetsAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

