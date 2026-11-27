//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Binance.Common;
using Binance.Stocks.RestApi;

namespace Binance.Stocks.Examples.RestApi.Tokenized;

public static class TokenizedConvertStatus
{
    public static async Task Main()
    {
        // A signed request: set API_KEY and API_SECRET.
        using var client = new StocksRestApi(new RestApiConfig
        {
            BasePath = Environment.GetEnvironmentVariable("BASE_PATH") ?? StocksRestApi.ProductionUrl,
            ApiKey = Environment.GetEnvironmentVariable("API_KEY"),
            ApiSecret = Environment.GetEnvironmentVariable("API_SECRET"),
        });

        try
        {
            var response = await client.TokenizedConvertStatusAsync(new()
            {
                IssuerRequestId = "mint-20260505-8f3b9e1a2d3c4b5a",
                ConvertType = TokenizedConvertStatusConvertType.Mint,
            });

            Console.WriteLine("Rate limits: " + string.Join("; ", response.RateLimits));
            Console.WriteLine(StocksRestApiJson.ToJson(response.Data()));
        }
        catch (BinanceException e)
        {
            Console.Error.WriteLine($"TokenizedConvertStatusAsync() failed: {e.Kind} {e.Code} {e.Message}");
        }
    }
}

