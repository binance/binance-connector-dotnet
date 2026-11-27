//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

#pragma warning disable CS0618 // This endpoint is deprecated.
using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.RestApi;

namespace Binance.DerivativesTradingUsdsFutures.Examples.RestApi.MarketData;

public static class SymbolPriceTicker
{
    public static async Task Main()
    {
        using var client = new DerivativesTradingUsdsFuturesRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingUsdsFuturesRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.SymbolPriceTickerAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingUsdsFuturesRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"SymbolPriceTickerAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

