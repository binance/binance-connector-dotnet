namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Fiat : SpotService
    {
        public Fiat(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Fiat(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_FIAT_DEPOSIT_WITHDRAW_HISTORY = "/sapi/v1/fiat/orders";

        /// <summary>
        /// - If beginTime and endTime are not sent, the recent 30-day data will be returned.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="transactionType">* `0` - deposit.<para />
        /// * `1` - withdraw.</param>
        /// <param name="beginTime"></param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="rows">Default 100, max 500.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>History of deposit/withdraw orders.</returns>
        public async Task<string> GetFiatDepositWithdrawHistory(FiatOrderTransactionType transactionType, long? beginTime = null, long? endTime = null, int? page = null, int? rows = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_FIAT_DEPOSIT_WITHDRAW_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "transactionType", transactionType },
                    { "beginTime", beginTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "rows", rows },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_FIAT_PAYMENTS_HISTORY = "/sapi/v1/fiat/payments";

        /// <summary>
        /// - If beginTime and endTime are not sent, the recent 30-day data will be returned.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="transactionType">* `0` - deposit.<para />
        /// * `1` - withdraw.</param>
        /// <param name="beginTime"></param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="rows">Default 100, max 500.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>History of fiat payments.</returns>
        public async Task<string> GetFiatPaymentsHistory(FiatPaymentTransactionType transactionType, long? beginTime = null, long? endTime = null, int? page = null, int? rows = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_FIAT_PAYMENTS_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "transactionType", transactionType },
                    { "beginTime", beginTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "rows", rows },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}