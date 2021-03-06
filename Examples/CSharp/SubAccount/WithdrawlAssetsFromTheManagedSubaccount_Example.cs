namespace Binance.Spot.SubAccountExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class WithdrawlAssetsFromTheManagedSubaccount_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<WithdrawlAssetsFromTheManagedSubaccount_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            string apiKey = "api-key";
            string apiSecret = "api-secret";

            var subAccount = new SubAccount(httpClient, apiKey: apiKey, apiSecret: apiSecret);

            var result = await subAccount.WithdrawlAssetsFromTheManagedSubaccount("testaccount@email.com", "BTC", 1.01m);
        }
    }
}