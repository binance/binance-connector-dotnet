//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.DualInvestment.RestApi;

namespace Binance.DualInvestment.Examples.RestApi.Trade;

public static class SubscribeDualInvestmentProducts
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new DualInvestmentRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? DualInvestmentRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.SubscribeDualInvestmentProductsAsync(new()
            {
                Id = "741590",
                OrderId = "8257205859",
                DepositAmount = 1m,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(DualInvestmentRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"SubscribeDualInvestmentProductsAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

