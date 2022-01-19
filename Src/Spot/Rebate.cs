namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Rebate : SpotService
    {
        public Rebate(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Rebate(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_SPOT_REBATE_HISTORY_RECORDS = "/sapi/v1/rebate/taxQuery";

        /// <summary>
        /// - The max interval between startTime and endTime is 90 days.<para />
        /// - If startTime and endTime are not sent, the recent 7 days' data will be returned.<para />
        /// - The earliest startTime is supported on June 10, 2020.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">default 1.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Rebate History.</returns>
        public async Task<string> GetSpotRebateHistoryRecords(long? startTime = null, long? endTime = null, int? page = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SPOT_REBATE_HISTORY_RECORDS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}