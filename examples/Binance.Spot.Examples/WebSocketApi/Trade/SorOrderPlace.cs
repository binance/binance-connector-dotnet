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

public static class SorOrderPlace
{
    public static async Task Main()
    {
        // This request changes the account of the API key: the example runs on the demo environment, so that no real
        // order is placed. Use demo API keys (they are separate from the production ones).
        var client = new SpotWebSocketApi(new WebSocketApiConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? SpotWebSocketApi.DemoUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            var response = await connection.SorOrderPlaceAsync(new()
            {
                Symbol = "BNBUSDT",
                Side = SorOrderPlaceSide.Buy,
                Type = SorOrderPlaceType.Market,
                Quantity = 1m,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SpotWebSocketApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"SorOrderPlaceAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

