//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingOptions.WebSocketStreams;

namespace Binance.DerivativesTradingOptions.Examples.WebSocketStreams.Market;

public static class OptionMarkPrice
{
    public static async Task Main()
    {
        var client = new DerivativesTradingOptionsWebSocketStreams(new WebSocketStreamsConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? DerivativesTradingOptionsWebSocketStreams.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            using var subscription = connection.OptionMarkPrice(new() { Underlying = "btcusdt" });

            // Prints the events of the next 10 seconds.
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await foreach (var e in subscription.Events.ReadAllAsync(timeout.Token))
                    Console.WriteLine(DerivativesTradingOptionsWebSocketStreamsJson.ToJson(e));
            }
            catch (OperationCanceledException)
            {
            }
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"OptionMarkPrice() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

