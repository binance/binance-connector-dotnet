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
        /// - You have a Binance account.<para />
        /// - You have passed kyc.<para />
        /// - You have a sufﬁcient balance in your Binance funding wallet.<para />
        /// - You need Enable Withdrawals for the API Key which requests this endpoint.<para />
        /// Daily creation volume: 2 BTC / 24H Daily creation times: 200 Codes / 24H.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="token">The coin type contained in the Binance Code.</param>
        /// <param name="amount">The amount of the coin.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Code creation.</returns>
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
        /// <param name="code">Binance Code.</param>
        /// <param name="externalUid">Each external unique ID represents a unique user on the partner platform. The function helps you to identify the redemption behavior of different users, such as redemption frequency and amount. It also helps risk and limit control of a single account, such as daily limit on redemption volume, frequency, and incorrect number of entries. This will also prevent a single user account reach the partner's daily redemption limits. We strongly recommend you to use this feature and transfer us the User ID of your users if you have different users redeeming Binance codes on your platform. To protect user data privacy, you may choose to transfer the user id in any desired format (max. 400 characters).</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Redeemed Information.</returns>
        public async Task<string> RedeemBinanceCode(string code, string externalUid = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REDEEM_BINANCE_CODE,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "code", code },
                    { "externalUid", externalUid },
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
        /// <returns>Code Verification.</returns>
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

        private const string FETCH_RSA_PUBLIC_KEY = "/sapi/v1/giftcard/cryptography/rsa-public-key";

        /// <summary>
        /// This API is for fetching the RSA Public Key.<para />
        /// This RSA Public key will be used to encrypt the card code.<para />
        /// Please note that the RSA Public key fetched is valid only for the current day.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>RSA Public Key..</returns>
        public async Task<string> FetchRsaPublicKey(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                FETCH_RSA_PUBLIC_KEY,
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