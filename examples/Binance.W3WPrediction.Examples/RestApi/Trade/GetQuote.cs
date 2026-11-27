//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.W3WPrediction.RestApi;

namespace Binance.W3WPrediction.Examples.RestApi.Trade;

public static class GetQuote
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
            var response = await client.GetQuoteAsync(new()
            {
                WalletAddress = "0x12e32db8817e292508c34111cbc4b23340df542c",
                TokenId = "112233",
                Side = GetQuoteSide.Buy,
                AmountIn = "1000000000000000000",
                OrderType = GetQuoteOrderType.Market,
                SlippageBps = 1200L,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"GetQuoteAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

