//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingCoinFutures.WebSocketApi;

namespace Binance.DerivativesTradingCoinFutures.Examples.WebSocketApi.Trade;

public static class NewOrder
{
    public static async Task Main()
    {
        // This request changes the account of the API key: the example runs on the testnet, so that no real
        // order is placed. Use testnet API keys (they are separate from the production ones).
        var client = new DerivativesTradingCoinFuturesWebSocketApi(new WebSocketApiConfig
        {
            Url = Environment.GetEnvironmentVariable("WS_URL") ?? DerivativesTradingCoinFuturesWebSocketApi.TestnetUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            await using var connection = await client.ConnectAsync();

            var response = await connection.NewOrderAsync(new()
            {
                Symbol = "BTCUSD_PERP",
                Side = NewOrderSide.Buy,
                Type = NewOrderType.Limit,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingCoinFuturesWebSocketApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"NewOrderAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

