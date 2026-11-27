//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.SubAccount.RestApi;

namespace Binance.SubAccount.Examples.RestApi.AssetManagement;

public static class TransferToSubAccountOfSameMaster
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new SubAccountRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? SubAccountRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.TransferToSubAccountOfSameMasterAsync(new()
            {
                ToEmail = "abc@test.com",
                Asset = "BTC",
                Amount = 1.0m,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SubAccountRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"TransferToSubAccountOfSameMasterAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

