//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Wallet.RestApi;

namespace Binance.Wallet.Examples.RestApi.TravelRule;

public static class DepositHistoryTravelRule
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new WalletRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? WalletRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.DepositHistoryTravelRuleAsync();

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(WalletRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"DepositHistoryTravelRuleAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

