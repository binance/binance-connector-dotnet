//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.SubAccount.RestApi;

namespace Binance.SubAccount.Examples.RestApi.ManagedSubAccount;

public static class QueryManagedSubAccountTransferLogMasterAccountTrading
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new SubAccountRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? SubAccountRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.QueryManagedSubAccountTransferLogMasterAccountTradingAsync(new()
            {
                Email = "abc@test.com",
                StartTime = 1623319461670L,
                EndTime = 1641782889000L,
                Page = 1L,
                Limit = 10L,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SubAccountRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"QueryManagedSubAccountTransferLogMasterAccountTradingAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

