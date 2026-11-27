//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DerivativesTradingCoinFutures.RestApi;

namespace Binance.DerivativesTradingCoinFutures.Examples.RestApi.MarketData;

public static class GetFundingRateInfo
{
    public static async Task Main()
    {
        using var client = new DerivativesTradingCoinFuturesRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DerivativesTradingCoinFuturesRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.GetFundingRateInfoAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DerivativesTradingCoinFuturesRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetFundingRateInfoAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

