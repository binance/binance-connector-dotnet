//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.VipLoan.RestApi;

namespace Binance.VipLoan.Examples.RestApi.MarketData;

public static class QueryVIPLoanFixedRateMarket
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new VipLoanRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? VipLoanRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.QueryVIPLoanFixedRateMarketAsync(new() { LoanCoin = "USDT" });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(VipLoanRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"QueryVIPLoanFixedRateMarketAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

