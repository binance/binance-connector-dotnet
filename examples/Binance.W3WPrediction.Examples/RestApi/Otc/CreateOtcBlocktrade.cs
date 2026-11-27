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

public static class CreateOtcBlocktrade
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
            var response = await client.CreateOtcBlocktradeAsync(new()
            {
                MarketId = "123",
                TokenId = "71321045679252212594626385532706912750332728571942532289631379312455583992563",
                Side = CreateOtcBlocktradeSide.Buy,
                MakerAmount = "600000000000000000000",
                TakerAmount = "1000000000000000000000",
                PricePerShare = "0.65",
                Expiration = 1790000000L,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"CreateOtcBlocktradeAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

