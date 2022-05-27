namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class BLVT : SpotService
    {
        public BLVT(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public BLVT(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_BLVT_INFO = "/sapi/v1/blvt/tokenInfo";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <returns>List of token information.</returns>
        public async Task<string> GetBlvtInfo(string tokenName = null)
        {
            var result = await this.SendPublicAsync<string>(
                GET_BLVT_INFO,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                });

            return result;
        }

        private const string SUBSCRIBE_BLVT = "/sapi/v1/blvt/subscribe";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="cost">Spot balance.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Subscription Info.</returns>
        public async Task<string> SubscribeBlvt(string tokenName, decimal cost, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                SUBSCRIBE_BLVT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "cost", cost },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_SUBSCRIPTION_RECORD = "/sapi/v1/blvt/subscribe/record";

        /// <summary>
        /// - Only the data of the latest 90 days is available.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="id"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of subscription record.</returns>
        public async Task<string> QuerySubscriptionRecord(string tokenName = null, long? id = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_SUBSCRIPTION_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "id", id },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string REDEEM_BLVT = "/sapi/v1/blvt/redeem";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Redemption record.</returns>
        public async Task<string> RedeemBlvt(string tokenName, decimal amount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REDEEM_BLVT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_REDEMPTION_RECORD = "/sapi/v1/blvt/redeem/record";

        /// <summary>
        /// - Only the data of the latest 90 days is available.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="id"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">default 1000, max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of redemption record.</returns>
        public async Task<string> QueryRedemptionRecord(string tokenName = null, long? id = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_REDEMPTION_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "id", id },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_BLVT_USER_LIMIT_INFO = "/sapi/v1/blvt/userLimit";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="tokenName">BTCDOWN, BTCUP.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of token limits.</returns>
        public async Task<string> GetBlvtUserLimitInfo(string tokenName = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_BLVT_USER_LIMIT_INFO,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "tokenName", tokenName },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}