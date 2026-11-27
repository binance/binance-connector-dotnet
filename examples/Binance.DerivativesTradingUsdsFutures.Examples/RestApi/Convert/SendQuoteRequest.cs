//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingUsdsFutures.RestApi;

namespace Binance.DerivativesTradingUsdsFutures.Examples.RestApi.Convert;

public static class SendQuoteRequest
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new DerivativesTradingUsdsFuturesRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingUsdsFuturesRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.SendQuoteRequestAsync(new()
            {
                FromAsset = "BTC",
                ToAsset = "USDT",
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingUsdsFuturesRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"SendQuoteRequestAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

