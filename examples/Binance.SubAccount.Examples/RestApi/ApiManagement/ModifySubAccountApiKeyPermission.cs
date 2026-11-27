//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.SubAccount.RestApi;

namespace Binance.SubAccount.Examples.RestApi.ApiManagement;

public static class ModifySubAccountApiKeyPermission
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
            var response = await client.ModifySubAccountApiKeyPermissionAsync(new()
            {
                Email = "123@test.com",
                SubAccountApiKey = "k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf",
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(SubAccountRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"ModifySubAccountApiKeyPermissionAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

