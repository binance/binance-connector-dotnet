namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class BSwap : SpotService
    {
        public BSwap(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public BSwap(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string LIST_ALL_SWAP_POOLS = "/sapi/v1/bswap/pools";

        /// <summary>
        /// Get metadata about all swap pools.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>List of Swap Pools.</returns>
        public async Task<string> ListAllSwapPools()
        {
            var result = await this.SendPublicAsync<string>(
                LIST_ALL_SWAP_POOLS,
                HttpMethod.Get);

            return result;
        }

        private const string GET_LIQUIDITY_INFORMATION_OF_A_POOL = "/sapi/v1/bswap/liquidity";

        /// <summary>
        /// Get liquidity information and user share of a pool.<para />
        /// Weight(IP):.<para />
        /// - `1` for one pool;.<para />
        /// - `10` when the poolId parameter is omitted;.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Pool Liquidation information.</returns>
        public async Task<string> GetLiquidityInformationOfAPool(long? poolId = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_LIQUIDITY_INFORMATION_OF_A_POOL,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ADD_LIQUIDITY = "/sapi/v1/bswap/liquidityAdd";

        /// <summary>
        /// Add liquidity to a pool.<para />
        /// Weight(UID): 1000 (Additional: 3 times one second).
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="asset"></param>
        /// <param name="quantity"></param>
        /// <param name="type">* `Single` - to add a single token.<para />
        /// * `Combination` - to add dual tokens.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Operation Id.</returns>
        public async Task<string> AddLiquidity(long poolId, string asset, decimal quantity, string type = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ADD_LIQUIDITY,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "type", type },
                    { "asset", asset },
                    { "quantity", quantity },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string REMOVE_LIQUIDITY = "/sapi/v1/bswap/liquidityRemove";

        /// <summary>
        /// Remove liquidity from a pool, `type` include `SINGLE` and `COMBINATION`, asset is mandatory for single asset removal.<para />
        /// Weight(UID): 1000 (Additional: 3 times one second).
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="type">* `SINGLE` - for single asset removal.<para />
        /// * `COMBINATION` - for combination of all coins removal.</param>
        /// <param name="shareAmount"></param>
        /// <param name="asset">Mandatory for single asset removal.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Operation Id.</returns>
        public async Task<string> RemoveLiquidity(long poolId, LiquidityRemovalType type, decimal shareAmount, string[] asset = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REMOVE_LIQUIDITY,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "type", type },
                    { "asset", asset },
                    { "shareAmount", shareAmount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_LIQUIDITY_OPERATION_RECORD = "/sapi/v1/bswap/liquidityOps";

        /// <summary>
        /// Get liquidity operation (add/remove) records.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="operationId"></param>
        /// <param name="poolId"></param>
        /// <param name="operation"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Liquidity Operation Record.</returns>
        public async Task<string> GetLiquidityOperationRecord(long? operationId = null, long? poolId = null, LiquidityOperation? operation = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_LIQUIDITY_OPERATION_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "operationId", operationId },
                    { "poolId", poolId },
                    { "operation", operation },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string REQUEST_QUOTE = "/sapi/v1/bswap/quote";

        /// <summary>
        /// Request a quote for swap quote asset (selling asset) for base asset (buying asset), essentially price/exchange rates.<para />
        /// quoteQty is quantity of quote asset (to sell).<para />
        /// Please be noted the quote is for reference only, the actual price will change as the liquidity changes, it's recommended to swap immediate after request a quote for slippage prevention.<para />
        /// Weight(UID): 150.
        /// </summary>
        /// <param name="quoteAsset"></param>
        /// <param name="baseAsset"></param>
        /// <param name="quoteQty"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Quote Info.</returns>
        public async Task<string> RequestQuote(string quoteAsset, string baseAsset, decimal quoteQty, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REQUEST_QUOTE,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "quoteAsset", quoteAsset },
                    { "baseAsset", baseAsset },
                    { "quoteQty", quoteQty },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string SWAP = "/sapi/v1/bswap/swap";

        /// <summary>
        /// Swap `quoteAsset` for `baseAsset`.<para />
        /// Weight(UID): 1000 (Additional: 3 times one second).
        /// </summary>
        /// <param name="quoteAsset"></param>
        /// <param name="baseAsset"></param>
        /// <param name="quoteQty"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Swap Id.</returns>
        public async Task<string> Swap(string quoteAsset, string baseAsset, decimal quoteQty, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                SWAP,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "quoteAsset", quoteAsset },
                    { "baseAsset", baseAsset },
                    { "quoteQty", quoteQty },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_SWAP_HISTORY = "/sapi/v1/bswap/swap";

        /// <summary>
        /// Get swap history.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="swapId"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="status">* `0` - pending for swap.<para />
        /// * `1` - success.<para />
        /// * `2` - failed.</param>
        /// <param name="quoteAsset"></param>
        /// <param name="baseAsset"></param>
        /// <param name="limit">default 3, max 100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Swap History.</returns>
        public async Task<string> GetSwapHistory(long? swapId = null, long? startTime = null, long? endTime = null, SwapStatus? status = null, string quoteAsset = null, string baseAsset = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SWAP_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "swapId", swapId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "status", status },
                    { "quoteAsset", quoteAsset },
                    { "baseAsset", baseAsset },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string POOL_CONFIGURE = "/sapi/v1/bswap/poolConfigure";

        /// <summary>
        /// Weight(IP): 150.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Pool Information.</returns>
        public async Task<string> PoolConfigure(long? poolId = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                POOL_CONFIGURE,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ADD_LIQUIDITY_PREVIEW = "/sapi/v1/bswap/addLiquidityPreview";

        /// <summary>
        /// Calculate expected share amount for adding liquidity in single or dual token.<para />
        /// Weight(IP): 150.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="type">* `SINGLE` - for adding a single token.<para />
        /// * `COMBINATION` - for adding dual tokens.</param>
        /// <param name="quoteAsset"></param>
        /// <param name="quoteQty"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Add Liquidity Preview.</returns>
        public async Task<string> AddLiquidityPreview(long poolId, string type, string quoteAsset, decimal quoteQty, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ADD_LIQUIDITY_PREVIEW,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "type", type },
                    { "quoteAsset", quoteAsset },
                    { "quoteQty", quoteQty },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string REMOVE_LIQUIDITY_PREVIEW = "/sapi/v1/bswap/removeLiquidityPreview";

        /// <summary>
        /// Calculate the expected asset amount of single token redemption or dual token redemption.<para />
        /// Weight(IP): 150.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="type">* `SINGLE` - remove and obtain a single token.<para />
        /// * `COMBINATION` - remove and obtain dual token.</param>
        /// <param name="quoteAsset"></param>
        /// <param name="shareAmount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Remove Liquidity Preview.</returns>
        public async Task<string> RemoveLiquidityPreview(long poolId, string type, string quoteAsset, decimal shareAmount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REMOVE_LIQUIDITY_PREVIEW,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "type", type },
                    { "quoteAsset", quoteAsset },
                    { "shareAmount", shareAmount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_UNCLAIMED_REWARDS_RECORD = "/sapi/v1/bswap/unclaimedRewards";

        /// <summary>
        /// Get unclaimed rewards record.<para />
        ///  .<para />
        /// Weight(UID): 1000.
        /// </summary>
        /// <param name="type">0: Swap rewards, 1: Liquidity rewards, default to 0.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Unclaimed rewards record.</returns>
        public async Task<string> GetUnclaimedRewardsRecord(int? type = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_UNCLAIMED_REWARDS_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string CLAIM_REWARDS = "/sapi/v1/bswap/claimRewards";

        /// <summary>
        /// Claim swap rewards or liquidity rewards.<para />
        ///  .<para />
        /// Weight(UID): 1000.
        /// </summary>
        /// <param name="type">0: Swap rewards, 1: Liquidity rewards, default to 0.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Result of claim.</returns>
        public async Task<string> ClaimRewards(int? type = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                CLAIM_REWARDS,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_CLAIMED_HISTORY = "/sapi/v1/bswap/claimedHistory";

        /// <summary>
        /// Get history of claimed rewards.<para />
        ///  .<para />
        /// Weight(UID): 1000.
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="assetRewards"></param>
        /// <param name="type">0: Swap rewards, 1: Liquidity rewards, default to 0.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 3, max 100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Claimed History.</returns>
        public async Task<string> GetClaimedHistory(long? poolId = null, string assetRewards = null, int? type = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_CLAIMED_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "poolId", poolId },
                    { "assetRewards", assetRewards },
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