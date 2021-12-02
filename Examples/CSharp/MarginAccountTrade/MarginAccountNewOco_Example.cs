namespace Binance.Spot.MarginAccountTradeExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class MarginAccountNewOco_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<MarginAccountNewOco_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            var marginAccountTrade = new MarginAccountTrade(httpClient);

            var result = await marginAccountTrade.MarginAccountNewOco("LTCBTC", Side.BUY, 0.624363m, 522.23m, 515.38276m);
        }
    }
}