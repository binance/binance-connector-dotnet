namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Pay : SpotService
    {
        public Pay(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Pay(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_PAY_TRADE_HISTORY = "/sapi/v1/pay/transactions";

        /// <summary>
        /// - If startTimestamp and endTimestamp are not sent, the recent 90 days' data will be returned.<para />
        /// - The max interval between startTimestamp and endTimestamp is 90 days.<para />
        /// - Support for querying orders within the last 18 months.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="startTimestamp">UTC timestamp in ms.</param>
        /// <param name="endTimestamp">UTC timestamp in ms.</param>
        /// <param name="limit">default 100, max 100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Pay History.</returns>
        public async Task<string> GetPayTradeHistory(long? startTimestamp = null, long? endTimestamp = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_PAY_TRADE_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "startTimestamp", startTimestamp },
                    { "endTimestamp", endTimestamp },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}