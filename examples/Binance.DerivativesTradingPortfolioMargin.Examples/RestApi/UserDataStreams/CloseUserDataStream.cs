//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

namespace Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.UserDataStreams;

public static class CloseUserDataStream
{
    public static async Task Main()
    {
        using var client = new DerivativesTradingPortfolioMarginRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingPortfolioMarginRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.CloseUserDataStreamAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingPortfolioMarginRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"CloseUserDataStreamAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

