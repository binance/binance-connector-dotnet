//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;

namespace Binance.DerivativesTradingPortfolioMargin.Examples.RestApi.Trade;

public static class NewUmAlgoOrder
{
    public static async Task Main()
    {
        // This request changes the account of the API key: the example runs on the testnet, so that no real
        // order is placed. Use testnet API keys (they are separate from the production ones).
        using var client = new DerivativesTradingPortfolioMarginRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingPortfolioMarginRestApi.TestnetUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.NewUmAlgoOrderAsync(new()
            {
                AlgoType = NewUmAlgoOrderAlgoType.Conditional,
                Symbol = "BNBUSDT",
                Side = NewUmAlgoOrderSide.Buy,
                Type = NewUmAlgoOrderType.Stop,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingPortfolioMarginRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"NewUmAlgoOrderAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

