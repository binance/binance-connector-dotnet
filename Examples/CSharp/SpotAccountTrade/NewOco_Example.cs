namespace Binance.Spot.SpotAccountTradeExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class NewOco_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<NewOco_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            var spotAccountTrade = new SpotAccountTrade(httpClient);

            var result = await spotAccountTrade.NewOco("LTCBTC", Side.BUY, 522.23m, 127.54398m, 137.027m);
        }
    }
}