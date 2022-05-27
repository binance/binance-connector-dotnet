namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class SubAccount : SpotService
    {
        public SubAccount(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public SubAccount(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string CREATE_A_VIRTUAL_SUBACCOUNT = "/sapi/v1/sub-account/virtualSubAccount";

        /// <summary>
        /// - This request will generate a virtual sub account under your master account.<para />
        /// - You need to enable "trade" option for the api key which requests this endpoint.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="subAccountString">Please input a string. We will create a virtual email using that string for you to register.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Return the created virtual email.</returns>
        public async Task<string> CreateAVirtualSubaccount(string subAccountString, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                CREATE_A_VIRTUAL_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "subAccountString", subAccountString },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_SUBACCOUNT_LIST = "/sapi/v1/sub-account/list";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="isFreeze"></param>
        /// <param name="page">Default 1.</param>
        /// <param name="limit">Default 1; max 200.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of sub-accounts.</returns>
        public async Task<string> QuerySubaccountList(string email = null, bool? isFreeze = null, int? page = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_SUBACCOUNT_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "isFreeze", isFreeze },
                    { "page", page },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_SUBACCOUNT_SPOT_ASSET_TRANSFER_HISTORY = "/sapi/v1/sub-account/sub/transfer/history";

        /// <summary>
        /// - fromEmail and toEmail cannot be sent at the same time.<para />
        /// - Return fromEmail equal master account email by default.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="fromEmail">Sub-account email.</param>
        /// <param name="toEmail">Sub-account email.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="limit">Default 1.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Sub-account Spot Asset Transfer History.</returns>
        public async Task<string> QuerySubaccountSpotAssetTransferHistory(string fromEmail = null, string toEmail = null, long? startTime = null, long? endTime = null, int? page = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_SUBACCOUNT_SPOT_ASSET_TRANSFER_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "fromEmail", fromEmail },
                    { "toEmail", toEmail },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_SUBACCOUNT_FUTURES_ASSET_TRANSFER_HISTORY = "/sapi/v1/sub-account/futures/internalTransfer";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="futuresType">1:USDT-margined Futures, 2: Coin-margined Futures.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="limit">Default value: 50, Max value: 500.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Sub-account Futures Asset Transfer History.</returns>
        public async Task<string> QuerySubaccountFuturesAssetTransferHistory(string email, FuturesType futuresType, long? startTime = null, long? endTime = null, int? page = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_SUBACCOUNT_FUTURES_ASSET_TRANSFER_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "futuresType", futuresType },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string SUBACCOUNT_FUTURES_ASSET_TRANSFER = "/sapi/v1/sub-account/futures/internalTransfer";

        /// <summary>
        /// - Master account can transfer max 2000 times a minute.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="fromEmail">Sender email.</param>
        /// <param name="toEmail">Recipient email.</param>
        /// <param name="futuresType">1:USDT-margined Futures,2: Coin-margined Futures.</param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Futures Asset Transfer Info.</returns>
        public async Task<string> SubaccountFuturesAssetTransfer(string fromEmail, string toEmail, FuturesType futuresType, string asset, decimal amount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                SUBACCOUNT_FUTURES_ASSET_TRANSFER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "fromEmail", fromEmail },
                    { "toEmail", toEmail },
                    { "futuresType", futuresType },
                    { "asset", asset },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_SUBACCOUNT_ASSETS = "/sapi/v3/sub-account/assets";

        /// <summary>
        /// Fetch sub-account assets.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of assets balances.</returns>
        public async Task<string> QuerySubaccountAssets(string email, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_SUBACCOUNT_ASSETS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_SUBACCOUNT_SPOT_ASSETS_SUMMARY = "/sapi/v1/sub-account/spotSummary";

        /// <summary>
        /// Get BTC valued asset summary of subaccounts.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="size">Default:10 Max:20.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Summary of Sub-account Spot Assets.</returns>
        public async Task<string> QuerySubaccountSpotAssetsSummary(string email = null, long? page = null, long? size = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_SUBACCOUNT_SPOT_ASSETS_SUMMARY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "page", page },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_SUBACCOUNT_DEPOSIT_ADDRESS = "/sapi/v1/capital/deposit/subAddress";

        /// <summary>
        /// Fetch sub-account deposit address.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="coin">Coin name.</param>
        /// <param name="network"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Deposit address info.</returns>
        public async Task<string> GetSubaccountDepositAddress(string email, string coin, string network = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SUBACCOUNT_DEPOSIT_ADDRESS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "coin", coin },
                    { "network", network },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_SUBACCOUNT_DEPOSIT_HISTORY = "/sapi/v1/capital/deposit/subHisrec";

        /// <summary>
        /// Fetch sub-account deposit history.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="coin">Coin name.</param>
        /// <param name="status">0(0:pending,6: credited but cannot withdraw, 1:success).</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Sub-account deposit history.</returns>
        public async Task<string> GetSubaccountDepositHistory(string email, string coin = null, DepositStatus? status = null, long? startTime = null, long? endTime = null, int? limit = null, int? offset = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SUBACCOUNT_DEPOSIT_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "coin", coin },
                    { "status", status },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "offset", offset },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_SUBACCOUNTS_STATUS_ON_MARGIN_FUTURES = "/sapi/v1/sub-account/status";

        /// <summary>
        /// - If no `email` sent, all sub-accounts' information will be returned.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Status on Margin/Futures.</returns>
        public async Task<string> GetSubaccountsStatusOnMarginFutures(string email = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SUBACCOUNTS_STATUS_ON_MARGIN_FUTURES,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ENABLE_MARGIN_FOR_SUBACCOUNT = "/sapi/v1/sub-account/margin/enable";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin status.</returns>
        public async Task<string> EnableMarginForSubaccount(string email, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ENABLE_MARGIN_FOR_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_DETAIL_ON_SUBACCOUNTS_MARGIN_ACCOUNT = "/sapi/v1/sub-account/margin/account";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin sub-account details.</returns>
        public async Task<string> GetDetailOnSubaccountsMarginAccount(string email, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_DETAIL_ON_SUBACCOUNTS_MARGIN_ACCOUNT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_SUMMARY_OF_SUBACCOUNTS_MARGIN_ACCOUNT = "/sapi/v1/sub-account/margin/accountSummary";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin sub-account details.</returns>
        public async Task<string> GetSummaryOfSubaccountsMarginAccount(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SUMMARY_OF_SUBACCOUNTS_MARGIN_ACCOUNT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ENABLE_FUTURES_FOR_SUBACCOUNT = "/sapi/v1/sub-account/futures/enable";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Futures status.</returns>
        public async Task<string> EnableFuturesForSubaccount(string email, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ENABLE_FUTURES_FOR_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_DETAIL_ON_SUBACCOUNTS_FUTURES_ACCOUNT = "/sapi/v1/sub-account/futures/account";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Futures account details.</returns>
        public async Task<string> GetDetailOnSubaccountsFuturesAccount(string email, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_DETAIL_ON_SUBACCOUNTS_FUTURES_ACCOUNT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_SUMMARY_OF_SUBACCOUNTS_FUTURES_ACCOUNT = "/sapi/v1/sub-account/futures/accountSummary";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Futures account summary.</returns>
        public async Task<string> GetSummaryOfSubaccountsFuturesAccount(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SUMMARY_OF_SUBACCOUNTS_FUTURES_ACCOUNT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_FUTURES_POSITIONRISK_OF_SUBACCOUNT = "/sapi/v1/sub-account/futures/positionRisk";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Futures account summary.</returns>
        public async Task<string> GetFuturesPositionriskOfSubaccount(string email, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_FUTURES_POSITIONRISK_OF_SUBACCOUNT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string FUTURES_TRANSFER_FOR_SUBACCOUNT = "/sapi/v1/sub-account/futures/transfer";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="type">* `1` - transfer from subaccount's spot account to its USDT-margined futures account.<para />
        /// * `2` - transfer from subaccount's USDT-margined futures account to its spot account.<para />
        /// * `3` - transfer from subaccount's spot account to its COIN-margined futures account.<para />
        /// * `4` - transfer from subaccount's COIN-margined futures account to its spot account.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> FuturesTransferForSubaccount(string email, string asset, decimal amount, FuturesTransferType type, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                FUTURES_TRANSFER_FOR_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "asset", asset },
                    { "amount", amount },
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MARGIN_TRANSFER_FOR_SUBACCOUNT = "/sapi/v1/sub-account/margin/transfer";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="type">* `1` - transfer from subaccount's spot account to margin account.<para />
        /// * `2` - transfer from subaccount's margin account to its spot account.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> MarginTransferForSubaccount(string email, string asset, decimal amount, MarginTransferType type, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_TRANSFER_FOR_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "asset", asset },
                    { "amount", amount },
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string TRANSFER_TO_SUBACCOUNT_OF_SAME_MASTER = "/sapi/v1/sub-account/transfer/subToSub";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="toEmail">Recipient email.</param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> TransferToSubaccountOfSameMaster(string toEmail, string asset, decimal amount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                TRANSFER_TO_SUBACCOUNT_OF_SAME_MASTER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "toEmail", toEmail },
                    { "asset", asset },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string TRANSFER_TO_MASTER = "/sapi/v1/sub-account/transfer/subToMaster";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> TransferToMaster(string asset, decimal amount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                TRANSFER_TO_MASTER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string SUBACCOUNT_TRANSFER_HISTORY = "/sapi/v1/sub-account/transfer/subUserHistory";

        /// <summary>
        /// - If `type` is not sent, the records of type 2: transfer out will be returned by default.<para />
        /// - If `startTime` and `endTime` are not sent, the recent 30-day data will be returned.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="type">* `1` - transfer in.<para />
        /// * `2` - transfer out.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> SubaccountTransferHistory(string asset = null, TransferDirection? type = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                SUBACCOUNT_TRANSFER_HISTORY,
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

        private const string UNIVERSAL_TRANSFER = "/sapi/v1/sub-account/universalTransfer";

        /// <summary>
        /// - You need to enable "internal transfer" option for the api key which requests this endpoint.<para />
        /// - Transfer from master account by default if fromEmail is not sent.<para />
        /// - Transfer to master account by default if toEmail is not sent.<para />
        /// - Transfer between futures accounts is not supported.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="fromAccountType"></param>
        /// <param name="toAccountType"></param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="fromEmail">Sub-account email.</param>
        /// <param name="toEmail">Sub-account email.</param>
        /// <param name="clientTranId"></param>
        /// <param name="symbol">Only supported under ISOLATED_MARGIN type.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> UniversalTransfer(UniversalTransferAccountType fromAccountType, UniversalTransferAccountType toAccountType, string asset, decimal amount, string fromEmail = null, string toEmail = null, string clientTranId = null, string symbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                UNIVERSAL_TRANSFER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "fromEmail", fromEmail },
                    { "toEmail", toEmail },
                    { "fromAccountType", fromAccountType },
                    { "toAccountType", toAccountType },
                    { "clientTranId", clientTranId },
                    { "symbol", symbol },
                    { "asset", asset },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_UNIVERSAL_TRANSFER_HISTORY = "/sapi/v1/sub-account/universalTransfer";

        /// <summary>
        /// - `fromEmail` and `toEmail` cannot be sent at the same time.<para />
        /// - Return `fromEmail` equal master account email by default.<para />
        /// - The query time period must be less then 30 days.<para />
        /// - If startTime and endTime not sent, return records of the last 30 days by default.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="fromEmail">Sub-account email.</param>
        /// <param name="toEmail">Sub-account email.</param>
        /// <param name="clientTranId"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="limit">Default 500, Max 500.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer History.</returns>
        public async Task<string> QueryUniversalTransferHistory(string fromEmail = null, string toEmail = null, string clientTranId = null, long? startTime = null, long? endTime = null, int? page = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_UNIVERSAL_TRANSFER_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "fromEmail", fromEmail },
                    { "toEmail", toEmail },
                    { "clientTranId", clientTranId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "page", page },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_DETAIL_ON_SUBACCOUNTS_FUTURES_ACCOUNT_V2 = "/sapi/v2/sub-account/futures/account";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="futuresType">* `1` - USDT Margined Futures.<para />
        /// * `2` - COIN Margined Futures.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>USDT or COIN Margined Futures Details.</returns>
        public async Task<string> GetDetailOnSubaccountsFuturesAccountV2(string email, FuturesType futuresType, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_DETAIL_ON_SUBACCOUNTS_FUTURES_ACCOUNT_V2,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "futuresType", futuresType },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_SUMMARY_OF_SUBACCOUNTS_FUTURES_ACCOUNT_V2 = "/sapi/v2/sub-account/futures/accountSummary";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="futuresType">* `1` - USDT Margined Futures.<para />
        /// * `2` - COIN Margined Futures.</param>
        /// <param name="page">Default 1.</param>
        /// <param name="limit">Default 10, Max 20.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>USDT or COIN Margined Futures Summary.</returns>
        public async Task<string> GetSummaryOfSubaccountsFuturesAccountV2(FuturesType futuresType, int? page = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_SUMMARY_OF_SUBACCOUNTS_FUTURES_ACCOUNT_V2,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "futuresType", futuresType },
                    { "page", page },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_FUTURES_POSITIONRISK_OF_SUBACCOUNT_V2 = "/sapi/v2/sub-account/futures/positionRisk";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="futuresType">* `1` - USDT Margined Futures.<para />
        /// * `2` - COIN Margined Futures.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>USDT or COIN Margined Futures Position Risk.</returns>
        public async Task<string> GetFuturesPositionriskOfSubaccountV2(string email, FuturesType futuresType, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_FUTURES_POSITIONRISK_OF_SUBACCOUNT_V2,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "futuresType", futuresType },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ENABLE_LEVERAGE_TOKEN_FOR_SUBACCOUNT = "/sapi/v1/sub-account/blvt/enable";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="enableBlvt">Only true for now.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>BLVT status.</returns>
        public async Task<string> EnableLeverageTokenForSubaccount(string email, bool enableBlvt, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ENABLE_LEVERAGE_TOKEN_FOR_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "enableBlvt", enableBlvt },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DEPOSIT_ASSETS_INTO_THE_MANAGED_SUBACCOUNT = "/sapi/v1/managed-subaccount/deposit";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="toEmail">Recipient email.</param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> DepositAssetsIntoTheManagedSubaccount(string toEmail, string asset, decimal amount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DEPOSIT_ASSETS_INTO_THE_MANAGED_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "toEmail", toEmail },
                    { "asset", asset },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MANAGED_SUBACCOUNT_ASSET_DETAILS = "/sapi/v1/managed-subaccount/asset";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of asset details.</returns>
        public async Task<string> QueryManagedSubaccountAssetDetails(string email, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MANAGED_SUBACCOUNT_ASSET_DETAILS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string WITHDRAWL_ASSETS_FROM_THE_MANAGED_SUBACCOUNT = "/sapi/v1/managed-subaccount/withdraw";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="fromEmail">Sender email.</param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="transferDate">Withdrawals is automatically occur on the transfer date(UTC0). If a date is not selected, the withdrawal occurs right now.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> WithdrawlAssetsFromTheManagedSubaccount(string fromEmail, string asset, decimal amount, long? transferDate = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                WITHDRAWL_ASSETS_FROM_THE_MANAGED_SUBACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "fromEmail", fromEmail },
                    { "asset", asset },
                    { "amount", amount },
                    { "transferDate", transferDate },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MANAGED_SUBACCOUNT_SNAPSHOT = "/sapi/v1/managed-subaccount/accountSnapshot";

        /// <summary>
        /// - The query time period must be less then 30 days.<para />
        /// - Support query within the last one month only.<para />
        /// - If `startTime` and `endTime` not sent, return records of the last 7 days by default.<para />
        /// Weight(IP): 2400.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="type">"SPOT", "MARGIN"（cross）, "FUTURES"（UM）.</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="limit">min 7, max 30, default 7.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Sub-account spot snapshot.</returns>
        public async Task<string> QueryManagedSubaccountSnapshot(string email, string type, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MANAGED_SUBACCOUNT_SNAPSHOT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "type", type },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ENABLE_OR_DISABLE_IP_RESTRICTION_FOR_A_SUBACCOUNT_API_KEY = "/sapi/v1/sub-account/subAccountApi/ipRestriction";

        /// <summary>
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="subAccountApiKey"></param>
        /// <param name="ipRestrict">true or false.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>IP Restriction information.</returns>
        public async Task<string> EnableOrDisableIpRestrictionForASubaccountApiKey(string email, string subAccountApiKey, bool ipRestrict, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ENABLE_OR_DISABLE_IP_RESTRICTION_FOR_A_SUBACCOUNT_API_KEY,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "subAccountApiKey", subAccountApiKey },
                    { "ipRestrict", ipRestrict },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_IP_RESTRICTION_FOR_A_SUBACCOUNT_API_KEY = "/sapi/v1/sub-account/subAccountApi/ipRestriction";

        /// <summary>
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="subAccountApiKey"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>IP Restriction information.</returns>
        public async Task<string> GetIpRestrictionForASubaccountApiKey(string email, string subAccountApiKey, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_IP_RESTRICTION_FOR_A_SUBACCOUNT_API_KEY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "subAccountApiKey", subAccountApiKey },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ADD_IP_LIST_FOR_A_SUBACCOUNT_API_KEY = "/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList";

        /// <summary>
        /// Before the usage of this endpoint, please ensure `POST /sapi/v1/sub-account/subAccountApi/ipRestriction` was used to enable the IP restriction.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="subAccountApiKey"></param>
        /// <param name="ipAddress">Can be added in batches, separated by commas.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Add IP information.</returns>
        public async Task<string> AddIpListForASubaccountApiKey(string email, string subAccountApiKey, string ipAddress, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ADD_IP_LIST_FOR_A_SUBACCOUNT_API_KEY,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "subAccountApiKey", subAccountApiKey },
                    { "ipAddress", ipAddress },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DELETE_IP_LIST_FOR_A_SUBACCOUNT_API_KEY = "/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList";

        /// <summary>
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="email">Sub-account email.</param>
        /// <param name="subAccountApiKey"></param>
        /// <param name="ipAddress">Can be added in batches, separated by commas.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Delete IP information.</returns>
        public async Task<string> DeleteIpListForASubaccountApiKey(string email, string subAccountApiKey, string ipAddress, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DELETE_IP_LIST_FOR_A_SUBACCOUNT_API_KEY,
                HttpMethod.Delete,
                query: new Dictionary<string, object>
                {
                    { "email", email },
                    { "subAccountApiKey", subAccountApiKey },
                    { "ipAddress", ipAddress },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}