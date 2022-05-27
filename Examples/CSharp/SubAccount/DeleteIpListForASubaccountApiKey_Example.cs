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

    public class DeleteIpListForASubaccountApiKey_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<DeleteIpListForASubaccountApiKey_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            string apiKey = "api-key";
            string apiSecret = "api-secret";

            var subAccount = new SubAccount(httpClient, apiKey, apiSecret);

            var result = await subAccount.DeleteIpListForASubaccountApiKey("testaccount@email.com", "subAccountApiKey", "000.000.000.000");
        }
    }
}