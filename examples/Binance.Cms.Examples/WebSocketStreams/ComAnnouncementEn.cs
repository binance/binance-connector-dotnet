//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Cms.WebSocketStreams;

namespace Binance.Cms.Examples.WebSocketStreams;

public static class ComAnnouncementEn
{
    public static async Task Main()
    {
        var client = new CmsWebSocketStreams(new WebSocketStreamsConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? CmsWebSocketStreams.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            using var subscription = connection.ComAnnouncementEn();

            // Prints the events of the next 10 seconds.
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await foreach (var e in subscription.Events.ReadAllAsync(timeout.Token))
                    Console.WriteLine(CmsWebSocketStreamsJson.ToJson(e));
            }
            catch (OperationCanceledException)
            {
            }
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"ComAnnouncementEn() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

