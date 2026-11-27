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

public static class MarginAccountNewOto
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
            var response = await client.MarginAccountNewOtoAsync(new()
            {
                Symbol = "BTCUSDT",
                WorkingType = MarginAccountNewOtoWorkingType.Limit,
                WorkingSide = MarginAccountNewOtoWorkingSide.Buy,
                WorkingPrice = 1.0m,
                WorkingQuantity = 1.0m,
                WorkingIcebergQty = 1.0m,
                PendingType = MarginAccountNewOtoPendingType.Limit,
                PendingSide = MarginAccountNewOtoPendingSide.Buy,
                PendingQuantity = 1.0m,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(MarginTradingRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"MarginAccountNewOtoAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

