namespace Binance.Spot.SpotAccountTradeExamples
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class AccountInformation_Example
    {
        public static async Task Main(string[] args)
        {
            string apiKey;
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<AccountInformation_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

           // Sign by API secret key
            apiKey = "the_api_key";
            string apiSecret = "the_api_secret";
            var spotAccountTradeHMAC = new SpotAccountTrade(httpClient, new BinanceHmac(apiSecret), apiKey: apiKey, baseUrl: "https://testnet.binance.vision");
            var resultHMAC = await spotAccountTradeHMAC.AccountInformation();

            // Sign by RSA key
            apiKey = "the_api_key";
            string privateKey = File.ReadAllText("/Users/john/ssl/Private_key.pem");
            var spotAccountTradeRSA = new SpotAccountTrade(httpClient, new BinanceRsa(privateKey), apiKey: apiKey, baseUrl: "https://testnet.binance.vision");
            var resultRSA = await spotAccountTradeRSA.AccountInformation();
        }
    }
}