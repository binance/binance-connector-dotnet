//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingOptions.RestApi;

namespace Binance.DerivativesTradingOptions.Examples.RestApi.Trade;

public static class CancelMultipleOptionOrders
{
    public static async Task Main()
    {
        // This request changes the account of the API key: the example runs on the testnet, so that no real
        // order is placed. Use testnet API keys (they are separate from the production ones).
        using var client = new DerivativesTradingOptionsRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingOptionsRestApi.TestnetUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.CancelMultipleOptionOrdersAsync(new() { Symbol = "BTC-200730-9000-C" });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingOptionsRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"CancelMultipleOptionOrdersAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

