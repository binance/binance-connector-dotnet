//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.StockOptions.WebSocketStreams;

namespace Binance.StockOptions.Examples.WebSocketStreams.UserStreams;

public static class OrderReportV2Stream
{
    public static async Task Main()
    {
        var client = new StockOptionsWebSocketStreams(new WebSocketStreamsConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? StockOptionsWebSocketStreams.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            using var subscription = connection.OrderReportV2Stream(new()
            {
                ListenKey = "3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13",
            });

            // Prints the events of the next 10 seconds.
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await foreach (var e in subscription.Events.ReadAllAsync(timeout.Token))
                    Console.WriteLine(StockOptionsWebSocketStreamsJson.ToJson(e));
            }
            catch (OperationCanceledException)
            {
            }
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"OrderReportV2Stream() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

