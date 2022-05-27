namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class PortfolioMargin : SpotService
    {
        public PortfolioMargin(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public PortfolioMargin(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_PORTFOLIO_MARGIN_ACCOUNT_INFO = "/sapi/v1/portfolio/account";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Portfolio account..</returns>
        public async Task<string> GetPortfolioMarginAccountInfo(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_PORTFOLIO_MARGIN_ACCOUNT_INFO,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}