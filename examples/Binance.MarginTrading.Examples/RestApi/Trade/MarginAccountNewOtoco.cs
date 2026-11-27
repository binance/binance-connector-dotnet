//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.MarginTrading.RestApi;

namespace Binance.MarginTrading.Examples.RestApi.Trade;

public static class MarginAccountNewOtoco
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new MarginTradingRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? MarginTradingRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.MarginAccountNewOtocoAsync(new()
            {
                Symbol = "BTCUSDT",
                WorkingType = MarginAccountNewOtocoWorkingType.Limit,
                WorkingSide = MarginAccountNewOtocoWorkingSide.Buy,
                WorkingPrice = 1.0m,
                WorkingQuantity = 1.0m,
                PendingSide = MarginAccountNewOtocoPendingSide.Buy,
                PendingQuantity = 1.0m,
                PendingAboveType = MarginAccountNewOtocoPendingAboveType.LimitMaker,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(MarginTradingRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"MarginAccountNewOtocoAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

