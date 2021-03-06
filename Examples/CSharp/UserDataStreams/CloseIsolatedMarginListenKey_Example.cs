namespace Binance.Spot.UserDataStreamsExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class CloseIsolatedMarginListenKey_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<CloseIsolatedMarginListenKey_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            string apiKey = "api-key";
            string apiSecret = "api-secret";

            var userDataStreams = new UserDataStreams(httpClient, apiKey: apiKey, apiSecret: apiSecret);

            var result = await userDataStreams.CloseIsolatedMarginListenKey("BTCUSDT", "listen-key");
        }
    }
}