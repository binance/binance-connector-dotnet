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

public static class VipLoanFixedRateBorrow
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
            var response = await client.VipLoanFixedRateBorrowAsync(new()
            {
                SupplyRequest = "1212:0.12:100;3434:0.13:50",
                BorrowCoin = "BUSD",
                LoanTerm = 30L,
                BorrowUid = 12345678L,
                CollateralCoin = "BNB,BNB-Earn,ETH,BTC",
                CollateralAccountId = "12345,67890,13579",
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(VipLoanRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"VipLoanFixedRateBorrowAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

