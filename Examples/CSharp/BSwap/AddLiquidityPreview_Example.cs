namespace Binance.Spot.BSwapExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class AddLiquidityPreview_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<AddLiquidityPreview_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            string apiKey = "api-key";
            string apiSecret = "api-secret";

            var bSwap = new BSwap(httpClient, apiKey, apiSecret);

            var result = await bSwap.AddLiquidityPreview(2, "SINGLE", "USDT", 12415.2m);
        }
    }
}