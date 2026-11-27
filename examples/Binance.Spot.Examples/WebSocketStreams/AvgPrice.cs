//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Spot.WebSocketStreams;

namespace Binance.Spot.Examples.WebSocketStreams;

public static class AvgPrice
{
    public static async Task Main()
    {
        var client = new SpotWebSocketStreams(new WebSocketStreamsConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? SpotWebSocketStreams.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            using var subscription = connection.AvgPrice(new() { Symbol = "bnbusdt" });

            // Prints the events of the next 10 seconds.
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await foreach (var e in subscription.Events.ReadAllAsync(timeout.Token))
                    Console.WriteLine(SpotWebSocketStreamsJson.ToJson(e));
            }
            catch (OperationCanceledException)
            {
            }
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"AvgPrice() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

