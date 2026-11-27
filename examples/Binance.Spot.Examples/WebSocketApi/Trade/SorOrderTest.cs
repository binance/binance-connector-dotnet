//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Spot.WebSocketApi;

namespace Binance.Spot.Examples.WebSocketApi.Trade;

public static class SorOrderTest
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        var client = new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? SpotWebSocketApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            var response = await connection.SorOrderTestAsync(new()
            {
                Symbol = "BNBUSDT",
                Side = SorOrderTestSide.Buy,
                Type = SorOrderTestType.Market,
                Quantity = 1m,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SpotWebSocketApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"SorOrderTestAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

