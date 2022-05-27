namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class CryptoLoans : SpotService
    {
        public CryptoLoans(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public CryptoLoans(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_CRYPTO_LOANS_INCOME_HISTORY = "/sapi/v1/loan/income";

        /// <summary>
        /// - If startTime and endTime are not sent, the recent 7-day data will be returned.<para />
        /// - The max interval between startTime and endTime is 30 days.<para />
        /// Weight(UID): 6000.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="type">All types will be returned by default.<para />
        /// * `borrowIn`.<para />
        /// * `collateralSpent`.<para />
        /// * `repayAmount`.<para />
        /// * `collateralReturn` - Collateral return after repayment.<para />
        /// * `addCollateral`.<para />
        /// * `removeCollateral`.<para />
        /// * `collateralReturnAfterLiquidation`.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">default 20, max 100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Loan History.</returns>
        public async Task<string> GetCryptoLoansIncomeHistory(string asset, string type = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_CRYPTO_LOANS_INCOME_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "type", type },
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