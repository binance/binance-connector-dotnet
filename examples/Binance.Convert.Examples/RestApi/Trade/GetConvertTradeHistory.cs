//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Convert.RestApi;

namespace Binance.Convert.Examples.RestApi.Trade;

public static class GetConvertTradeHistory
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new ConvertRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? ConvertRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.GetConvertTradeHistoryAsync(new()
            {
                StartTime = 1623319461670L,
                EndTime = 1641782889000L,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(ConvertRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetConvertTradeHistoryAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

