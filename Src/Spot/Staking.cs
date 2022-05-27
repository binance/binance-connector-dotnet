namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Staking : SpotService
    {
        public Staking(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Staking(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string GET_STAKING_PRODUCT_LIST = "/sapi/v1/staking/productList";

        /// <summary>
        /// Get available Staking product list.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="product">* `STAKING` - for Locked Staking.<para />
        /// * `F_DEFI` - for flexible DeFi Staking.<para />
        /// * `L_DEFI` - for locked DeFi Staking.</param>
        /// <param name="asset"></param>
        /// <param name="current">Currently querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10, Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Product list..</returns>
        public async Task<string> GetStakingProductList(string product, string asset = null, long? current = null, long? size = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_STAKING_PRODUCT_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "product", product },
                    { "asset", asset },
                    { "current", current },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string PURCHASE_STAKING_PRODUCT = "/sapi/v1/staking/purchase";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="product">* `STAKING` - for Locked Staking.<para />
        /// * `F_DEFI` - for flexible DeFi Staking.<para />
        /// * `L_DEFI` - for locked DeFi Staking.</param>
        /// <param name="productId"></param>
        /// <param name="amount"></param>
        /// <param name="renewable">true or false, default false. Active if product is `STAKING` or `L_DEFI`.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Position Id..</returns>
        public async Task<string> PurchaseStakingProduct(string product, string productId, decimal amount, string renewable = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                PURCHASE_STAKING_PRODUCT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "product", product },
                    { "productId", productId },
                    { "amount", amount },
                    { "renewable", renewable },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string REDEEM_STAKING_PRODUCT = "/sapi/v1/staking/redeem";

        /// <summary>
        /// Redeem Staking product. Locked staking and Locked DeFI staking belong to early redemption, redeeming in advance will result in loss of interest that you have earned.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="product">* `STAKING` - for Locked Staking.<para />
        /// * `F_DEFI` - for flexible DeFi Staking.<para />
        /// * `L_DEFI` - for locked DeFi Staking.</param>
        /// <param name="productId"></param>
        /// <param name="positionId">Mandatory if product is `STAKING` or `L_DEFI`.</param>
        /// <param name="amount">Mandatory if product is `F_DEFI`.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Success..</returns>
        public async Task<string> RedeemStakingProduct(string product, string productId, string positionId = null, decimal? amount = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REDEEM_STAKING_PRODUCT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "product", product },
                    { "positionId", positionId },
                    { "productId", productId },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_STAKING_PRODUCT_POSITION = "/sapi/v1/staking/position";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="product">* `STAKING` - for Locked Staking.<para />
        /// * `F_DEFI` - for flexible DeFi Staking.<para />
        /// * `L_DEFI` - for locked DeFi Staking.</param>
        /// <param name="productId"></param>
        /// <param name="asset"></param>
        /// <param name="current">Currently querying the page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10, Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Position..</returns>
        public async Task<string> GetStakingProductPosition(string product, string productId = null, string asset = null, long? current = null, long? size = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_STAKING_PRODUCT_POSITION,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "product", product },
                    { "productId", productId },
                    { "asset", asset },
                    { "current", current },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_STAKING_HISTORY = "/sapi/v1/staking/stakingRecord";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="product">* `STAKING` - for Locked Staking.<para />
        /// * `F_DEFI` - for flexible DeFi Staking.<para />
        /// * `L_DEFI` - for locked DeFi Staking.</param>
        /// <param name="txnType">`SUBSCRIPTION`, `REDEMPTION`, `INTEREST`.</param>
        /// <param name="asset"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="current">Currently querying the page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10, Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Staking History..</returns>
        public async Task<string> GetStakingHistory(string product, string txnType, string asset = null, long? startTime = null, long? endTime = null, long? current = null, long? size = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_STAKING_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "product", product },
                    { "txnType", txnType },
                    { "asset", asset },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string SET_AUTO_STAKING = "/sapi/v1/staking/setAutoStaking";

        /// <summary>
        /// Set auto staking on Locked Staking or Locked DeFi Staking.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="product">* `STAKING` - for Locked Staking.<para />
        /// * `L_DEFI` - for locked DeFi Staking.</param>
        /// <param name="positionId"></param>
        /// <param name="renewable">true or false.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Success..</returns>
        public async Task<string> SetAutoStaking(string product, string positionId, string renewable, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                SET_AUTO_STAKING,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "product", product },
                    { "positionId", positionId },
                    { "renewable", renewable },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_PERSONAL_LEFT_QUOTA_OF_STAKING_PRODUCT = "/sapi/v1/staking/personalLeftQuota";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="product">* `STAKING` - for Locked Staking.<para />
        /// * `F_DEFI` - for flexible DeFi Staking.<para />
        /// * `L_DEFI` - for locked DeFi Staking.</param>
        /// <param name="productId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Quota..</returns>
        public async Task<string> GetPersonalLeftQuotaOfStakingProduct(string product, string productId, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_PERSONAL_LEFT_QUOTA_OF_STAKING_PRODUCT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "product", product },
                    { "productId", productId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}