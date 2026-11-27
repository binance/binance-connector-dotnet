//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.W3WPrediction.RestApi;

namespace Binance.W3WPrediction.Examples.RestApi.Otc;

public static class PreviewOtcBlocktrade
{
    public static async Task Main()
    {
        // This request changes the account of the API key: it can place or cancel real orders or move funds.
        using var client = new W3WPredictionRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? W3WPredictionRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.PreviewOtcBlocktradeAsync(new()
            {
                SecretToken = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"PreviewOtcBlocktradeAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

