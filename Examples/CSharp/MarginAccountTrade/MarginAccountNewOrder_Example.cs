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

    public class MarginAccountNewOrder_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<MarginAccountNewOrder_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            var marginAccountTrade = new MarginAccountTrade(httpClient);

            var result = await marginAccountTrade.MarginAccountNewOrder("BTCUSDT", Side.SELL, OrderType.MARKET);
        }
    }
}