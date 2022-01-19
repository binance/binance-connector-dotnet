namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Convert : SpotService
    {
        public Convert(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Convert(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_CONVERT_TRADE_HISTORY = "/sapi/v1/convert/tradeFlow";

        /// <summary>
        /// - The max interval between startTime and endTime is 30 days.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">default 100, max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Convert Trade History.</returns>
        public async Task<string> GetConvertTradeHistory(long startTime, long endTime, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_CONVERT_TRADE_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}