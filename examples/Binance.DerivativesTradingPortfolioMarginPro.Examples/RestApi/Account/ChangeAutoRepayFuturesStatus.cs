//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.RestApi;

namespace Binance.DerivativesTradingPortfolioMarginPro.Examples.RestApi.Account;

public static class ChangeAutoRepayFuturesStatus
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new DerivativesTradingPortfolioMarginProRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingPortfolioMarginProRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.ChangeAutoRepayFuturesStatusAsync(new()
            {
                AutoRepay = ChangeAutoRepayFuturesStatusAutoRepay.True,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingPortfolioMarginProRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"ChangeAutoRepayFuturesStatusAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

