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

    public class CancelAnExistingOrderAndSendANewOrder_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<CancelAnExistingOrderAndSendANewOrder_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            string apiKey = "api-key";
            string apiSecret = "api-secret";

            var spotAccountTrade = new SpotAccountTrade(httpClient, apiKey, apiSecret);

            var result = await spotAccountTrade.CancelAnExistingOrderAndSendANewOrder("BNBUSDT", Side.SELL, OrderType.LIMIT, "STOP_ON_FAILURE", cancelOrderId: 12, timeInForce: TimeInForce.GTC, quantity: 10.1m, price: 295.92m);
        }
    }
}