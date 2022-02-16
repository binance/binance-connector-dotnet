namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class GiftCard : SpotService
    {
        public GiftCard(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public GiftCard(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string CREATE_BINANCE_CODE = "/sapi/v1/giftcard/createCode";

        /// <summary>
        /// This API is for creating a Binance Code. To get started with, please make sure:.<para />
        /// You have a Binance account.<para />
        /// You have passed kyc.<para />
        /// You have a sufﬁcient balance in your Binance funding wallet.<para />
        /// You need Enable Withdrawals for the API Key which requests this endpoint.<para />
        /// Weight(IP): 1.<para />
        /// Daily creation volume: 2 BTC / 24H Daily creation times: 200 Codes / 24H.
        /// </summary>
        /// <param name="token">The coin type contained in the Binance Code.</param>
        /// <param name="amount">The amount of the coin.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Binance Gift Card Code.</returns>
        public async Task<string> CreateBinanceCode(string token, double amount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                CREATE_BINANCE_CODE,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "token", token },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string REDEEM_BINANCE_CODE = "/sapi/v1/giftcard/redeemCode";

        /// <summary>
        /// This API is for redeeming the Binance Code. Once redeemed, the coins will be deposited in your funding wallet.<para />
        /// Please note that if you enter the wrong code 5 times within 24 hours, you will no longer be able to redeem any Binance Code that day.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="code">Binance code.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Binance Gift Card details.</returns>
        public async Task<string> RedeemBinanceCode(string code, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REDEEM_BINANCE_CODE,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "code", code },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string VERIFY_BINANCE_CODE = "/sapi/v1/giftcard/verify";

        /// <summary>
        /// This API is for verifying whether the Binance Code is valid or not by entering Binance Code or reference number.<para />
        /// Please note that if you enter the wrong binance code 5 times within an hour, you will no longer be able to verify any binance code for that hour.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="referenceNo">reference number.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Binance Gift Card details.</returns>
        public async Task<string> VerifyBinanceCode(string referenceNo, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                VERIFY_BINANCE_CODE,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "referenceNo", referenceNo },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}