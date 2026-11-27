//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketStreams;

namespace Binance.DerivativesTradingCoinFutures.Examples.WebSocketStreams;

public static class PartialBookDepthStreams
{
    public static async Task Main()
    {
        var client = new DerivativesTradingCoinFuturesWebSocketStreams(new WebSocketStreamsConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? DerivativesTradingCoinFuturesWebSocketStreams.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            using var subscription = connection.PartialBookDepthStreams(new()
            {
                Symbol = "btcusdt",
                Levels = PartialBookDepthStreamsLevels.Levels5,
            });

            // Prints the events of the next 10 seconds.
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await foreach (var e in subscription.Events.ReadAllAsync(timeout.Token))
                    Console.WriteLine(DerivativesTradingCoinFuturesWebSocketStreamsJson.ToJson(e));
            }
            catch (OperationCanceledException)
            {
            }
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"PartialBookDepthStreams() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

