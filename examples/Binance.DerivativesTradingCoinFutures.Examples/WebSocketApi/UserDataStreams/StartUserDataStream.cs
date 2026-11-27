//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

namespace Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.UserDataStreams;

public static class StartUserDataStream
{
    public static async Task Main()
    {
        var client = new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? DerivativesTradingCoinFuturesWebSocketApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            var response = await connection.StartUserDataStreamAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingCoinFuturesWebSocketApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"StartUserDataStreamAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

