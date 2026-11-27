//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.WebSocketApi;

namespace Binance.DerivativesTradingUsdsFutures.Examples.WebSocketApi.UserDataStreams;

public static class KeepaliveUserDataStream
{
    public static async Task Main()
    {
        var client = new DerivativesTradingUsdsFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? DerivativesTradingUsdsFuturesWebSocketApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            var response = await connection.KeepaliveUserDataStreamAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingUsdsFuturesWebSocketApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"KeepaliveUserDataStreamAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

