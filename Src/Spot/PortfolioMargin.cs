namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
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

        public PortfolioMargin(HttpClient httpClient, IBinanceSignatureService signatureService, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, signatureService: signatureService)
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

        private const string PORTFOLIO_MARGIN_COLLATERAL_RATE = "/sapi/v1/portfolio/collateralRate";

        /// <summary>
        /// Portfolio Margin Collateral Rate.<para />
        /// Weight(IP): 50.
        /// </summary>
        /// <returns>Portfolio Margin Collateral Rate..</returns>
        public async Task<string> PortfolioMarginCollateralRate()
        {
            var result = await this.SendPublicAsync<string>(
                PORTFOLIO_MARGIN_COLLATERAL_RATE,
                HttpMethod.Get);

            return result;
        }

        private const string QUERY_PORTFOLIO_MARGIN_BANKRUPTCY_LOAN_AMOUNT = "/sapi/v1/portfolio/pmLoan";

        /// <summary>
        /// Query Portfolio Margin Bankruptcy Loan Amount.<para />
        /// Weight(UID): 500.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Portfolio Margin Bankruptcy Loan Amount..</returns>
        public async Task<string> QueryPortfolioMarginBankruptcyLoanAmount(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_PORTFOLIO_MARGIN_BANKRUPTCY_LOAN_AMOUNT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string PORTFOLIO_MARGIN_BANKRUPTCY_LOAN_REPAY = "/sapi/v1/portfolio/repay";

        /// <summary>
        /// Repay Portfolio Margin Bankruptcy Loan.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transaction..</returns>
        public async Task<string> PortfolioMarginBankruptcyLoanRepay(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                PORTFOLIO_MARGIN_BANKRUPTCY_LOAN_REPAY,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}