//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Spot.WebSocketApi;

namespace Binance.Spot.Examples.WebSocketApi.UserDataStream;

public static class UserDataStreamSubscribeSignature
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

            using var subscription = await connection.UserDataStreamSubscribeSignatureAsync();

            Console.WriteLine(SpotWebSocketApiJson.ToJson(subscription.Response.Data()));

            // Prints the events of the next 10 seconds.
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await foreach (var e in subscription.Events.ReadAllAsync(timeout.Token))
                    Console.WriteLine(SpotWebSocketApiJson.ToJson(e));
            }
            catch (OperationCanceledException)
            {
            }
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"UserDataStreamSubscribeSignatureAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

