//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.CryptoLoan.RestApi;

namespace Binance.CryptoLoan.Examples.RestApi.FlexibleRate;

public static class FlexibleLoanRepay
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new CryptoLoanRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? CryptoLoanRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.FlexibleLoanRepayAsync(new()
            {
                LoanCoin = "BUSD",
                CollateralCoin = "BNB",
                RepayAmount = 1m,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(CryptoLoanRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"FlexibleLoanRepayAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

