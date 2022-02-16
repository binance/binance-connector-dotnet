namespace Binance.Spot.GiftCardExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class VerifyBinanceCode_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<VerifyBinanceCode_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            var giftCard = new GiftCard(httpClient);

            var result = await giftCard.VerifyBinanceCode("00000000000000000");
        }
    }
}