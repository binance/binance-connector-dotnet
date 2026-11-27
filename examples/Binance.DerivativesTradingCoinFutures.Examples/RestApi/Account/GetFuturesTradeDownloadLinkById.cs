//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingCoinFutures.RestApi;

namespace Binance.DerivativesTradingCoinFutures.Examples.RestApi.Account;

public static class GetFuturesTradeDownloadLinkById
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new DerivativesTradingCoinFuturesRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingCoinFuturesRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.GetFuturesTradeDownloadLinkByIdAsync(new()
            {
                DownloadId = "545923594199212032",
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingCoinFuturesRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetFuturesTradeDownloadLinkByIdAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

