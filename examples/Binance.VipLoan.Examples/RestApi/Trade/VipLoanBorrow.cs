//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.VipLoan.RestApi;

namespace Binance.VipLoan.Examples.RestApi.Trade;

public static class VipLoanBorrow
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new VipLoanRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? VipLoanRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.VipLoanBorrowAsync(new()
            {
                LoanAccountId = 1L,
                LoanCoin = "BTC",
                LoanAmount = 1.0m,
                CollateralAccountId = "12345678,12345678,12345678",
                CollateralCoin = "BUSD,USDT,USDT-Earn,ETH",
                IsFlexibleRate = true,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(VipLoanRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"VipLoanBorrowAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

