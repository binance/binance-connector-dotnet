namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Wallet : SpotService
    {
        public Wallet(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Wallet(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string SYSTEM_STATUS = "/sapi/v1/system/status";

        /// <summary>
        /// Fetch system status.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>OK.</returns>
        public async Task<string> SystemStatus()
        {
            var result = await this.SendPublicAsync<string>(
                SYSTEM_STATUS,
                HttpMethod.Get);

            return result;
        }

        private const string ALL_COINS_INFORMATION = "/sapi/v1/capital/config/getall";

        /// <summary>
        /// Get information of coins (available for deposit and withdraw) for user.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>All coins details information.</returns>
        public async Task<string> AllCoinsInformation(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ALL_COINS_INFORMATION,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DAILY_ACCOUNT_SNAPSHOT = "/sapi/v1/accountSnapshot";

        /// <summary>
        /// - The query time period must be less than 30 days.<para />
        /// - Support query within the last one month only.<para />
        /// - If startTimeand endTime not sent, return records of the last 7 days by default.<para />
        /// Weight(IP): 2400.
        /// </summary>
        /// <param name="type">"SPOT", "MARGIN", "FUTURES".</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Account Snapshot.</returns>
        public async Task<string> DailyAccountSnapshot(AccountType type, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DAILY_ACCOUNT_SNAPSHOT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "type", type },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DISABLE_FAST_WITHDRAW_SWITCH = "/sapi/v1/account/disableFastWithdrawSwitch";

        /// <summary>
        /// - This request will disable fastwithdraw switch under your account.<para />
        /// - You need to enable "trade" option for the api key which requests this endpoint.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>OK.</returns>
        public async Task<string> DisableFastWithdrawSwitch(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DISABLE_FAST_WITHDRAW_SWITCH,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ENABLE_FAST_WITHDRAW_SWITCH = "/sapi/v1/account/enableFastWithdrawSwitch";

        /// <summary>
        /// - This request will enable fastwithdraw switch under your account. You need to enable "trade" option for the api key which requests this endpoint.<para />
        /// - When Fast Withdraw Switch is on, transferring funds to a Binance account will be done instantly. There is no on-chain transaction, no transaction ID and no withdrawal fee.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>OK.</returns>
        public async Task<string> EnableFastWithdrawSwitch(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ENABLE_FAST_WITHDRAW_SWITCH,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string WITHDRAW = "/sapi/v1/capital/withdraw/apply";

        /// <summary>
        /// Submit a withdraw request.<para />
        /// - If `network` not send, return with default network of the coin.<para />
        /// - You can get `network` and `isDefault` in `networkList` of a coin in the response of `Get /sapi/v1/capital/config/getall (HMAC SHA256)`.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="coin">Coin name.</param>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="withdrawOrderId">Client id for withdraw.</param>
        /// <param name="network">Get the value from `GET /sapi/v1/capital/config/getall`.</param>
        /// <param name="addressTag">Secondary address identifier for coins like XRP,XMR etc.</param>
        /// <param name="transactionFeeFlag">When making internal transfer.<para />
        /// - `true` ->  returning the fee to the destination account;.<para />
        /// - `false` -> returning the fee back to the departure account.</param>
        /// <param name="name"></param>
        /// <param name="walletType">The wallet type for withdraw，0-Spot wallet, 1- Funding wallet. Default is Spot wallet.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transafer Id.</returns>
        public async Task<string> Withdraw(string coin, string address, decimal amount, string withdrawOrderId = null, string network = null, string addressTag = null, bool? transactionFeeFlag = null, string name = null, int? walletType = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                WITHDRAW,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "withdrawOrderId", withdrawOrderId },
                    { "network", network },
                    { "address", address },
                    { "addressTag", addressTag },
                    { "amount", amount },
                    { "transactionFeeFlag", transactionFeeFlag },
                    { "name", name },
                    { "walletType", walletType },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DEPOSIT_HISTORY = "/sapi/v1/capital/deposit/hisrec";

        /// <summary>
        /// Fetch deposit history.<para />
        /// - Please notice the default `startTime` and `endTime` to make sure that time interval is within 0-90 days.<para />
        /// - If both `startTime` and `endTime` are sent, time between `startTime` and `endTime` must be less than 90 days.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="coin">Coin name.</param>
        /// <param name="status">* `0` - pending.<para />
        /// * `6` - credited but cannot withdraw.<para />
        /// * `1` - success.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="offset"></param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of deposits.</returns>
        public async Task<string> DepositHistory(string coin = null, DepositStatus? status = null, long? startTime = null, long? endTime = null, int? offset = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DEPOSIT_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "status", status },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "offset", offset },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string WITHDRAW_HISTORY = "/sapi/v1/capital/withdraw/history";

        /// <summary>
        /// Fetch withdraw history.<para />
        /// - `network` may not be in the response for old withdraw.<para />
        /// - Please notice the default `startTime` and `endTime` to make sure that time interval is within 0-90 days.<para />
        /// - If both `startTime` and `endTime` are sent, time between `startTime` and `endTime` must be less than 90 days.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="coin">Coin name.</param>
        /// <param name="withdrawOrderId"></param>
        /// <param name="status">* `0` - Email Sent.<para />
        /// * `1` - Cancelled.<para />
        /// * `2` - Awaiting Approval.<para />
        /// * `3` - Rejected.<para />
        /// * `4` - Processing.<para />
        /// * `5` - Failure.<para />
        /// * `6` - Completed.</param>
        /// <param name="offset"></param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of withdraw history.</returns>
        public async Task<string> WithdrawHistory(string coin = null, string withdrawOrderId = null, WithdrawStatus? status = null, int? offset = null, int? limit = null, long? startTime = null, long? endTime = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                WITHDRAW_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "withdrawOrderId", withdrawOrderId },
                    { "status", status },
                    { "offset", offset },
                    { "limit", limit },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DEPOSIT_ADDRESS = "/sapi/v1/capital/deposit/address";

        /// <summary>
        /// Fetch deposit address with network.<para />
        /// - If network is not send, return with default network of the coin.<para />
        /// - You can get network and isDefault in networkList in the response of Get /sapi/v1/capital/config/getall (HMAC SHA256).<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="coin">Coin name.</param>
        /// <param name="network"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Deposit address info.</returns>
        public async Task<string> DepositAddress(string coin, string network = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DEPOSIT_ADDRESS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "coin", coin },
                    { "network", network },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ACCOUNT_STATUS = "/sapi/v1/account/status";

        /// <summary>
        /// Fetch account status detail.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>OK.</returns>
        public async Task<string> AccountStatus(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ACCOUNT_STATUS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ACCOUNT_API_TRADING_STATUS = "/sapi/v1/account/apiTradingStatus";

        /// <summary>
        /// Fetch account API trading status with details.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Account API trading status.</returns>
        public async Task<string> AccountApiTradingStatus(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ACCOUNT_API_TRADING_STATUS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DUSTLOG = "/sapi/v1/asset/dribblet";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Dust log records.</returns>
        public async Task<string> Dustlog(long? startTime = null, long? endTime = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DUSTLOG,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string BNB_CONVERTABLE_ASSETS = "/sapi/v1/asset/dust-btc";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Account assets available to be converted to BNB.</returns>
        public async Task<string> BnbConvertableAssets(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                BNB_CONVERTABLE_ASSETS,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DUST_TRANSFER = "/sapi/v1/asset/dust";

        /// <summary>
        /// Convert dust assets to BNB.<para />
        /// Weight(UID): 10.
        /// </summary>
        /// <param name="asset">The asset being converted. For example, asset=BTC&amp;asset=USDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Dust log records.</returns>
        public async Task<string> DustTransfer(string[] asset, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DUST_TRANSFER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ASSET_DIVIDEND_RECORD = "/sapi/v1/asset/assetDividend";

        /// <summary>
        /// Query asset Dividend Record.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Records of asset devidend.</returns>
        public async Task<string> AssetDividendRecord(string asset = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ASSET_DIVIDEND_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ASSET_DETAIL = "/sapi/v1/asset/assetDetail";

        /// <summary>
        /// Fetch details of assets supported on Binance.<para />
        /// - Please get network and other deposit or withdraw details from `GET /sapi/v1/capital/config/getall`.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Asset detail.</returns>
        public async Task<string> AssetDetail(string asset = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ASSET_DETAIL,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string TRADE_FEE = "/sapi/v1/asset/tradeFee";

        /// <summary>
        /// Fetch trade fee.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Trade fee info per symbol.</returns>
        public async Task<string> TradeFee(string symbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                TRADE_FEE,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_USER_UNIVERSAL_TRANSFER_HISTORY = "/sapi/v1/asset/transfer";

        /// <summary>
        /// - `fromSymbol` must be sent when type are ISOLATEDMARGIN_MARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.<para />
        /// - `toSymbol` must be sent when type are MARGIN_ISOLATEDMARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.<para />
        /// - Support query within the last 6 months only.<para />
        /// - If `startTime` and `endTime` not sent, return records of the last 7 days by default.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="type">Universal transfer type.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="fromSymbol">Must be sent when type are ISOLATEDMARGIN_MARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.</param>
        /// <param name="toSymbol">Must be sent when type are MARGIN_ISOLATEDMARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Universal transfer history.</returns>
        public async Task<string> QueryUserUniversalTransferHistory(UniversalTransferType type, long? startTime = null, long? endTime = null, int? current = null, int? size = null, string fromSymbol = null, string toSymbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_USER_UNIVERSAL_TRANSFER_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "type", type },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "fromSymbol", fromSymbol },
                    { "toSymbol", toSymbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string USER_UNIVERSAL_TRANSFER = "/sapi/v1/asset/transfer";

        /// <summary>
        /// You need to enable `Permits Universal Transfer` option for the api key which requests this endpoint.<para />
        /// - `fromSymbol` must be sent when type are ISOLATEDMARGIN_MARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.<para />
        /// - `toSymbol` must be sent when type are MARGIN_ISOLATEDMARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.<para />
        /// ENUM of transfer types:.<para />
        /// - MAIN_UMFUTURE Spot account transfer to USDⓈ-M Futures account.<para />
        /// - MAIN_CMFUTURE Spot account transfer to COIN-M Futures account.<para />
        /// - MAIN_MARGIN Spot account transfer to Margin（cross）account.<para />
        /// - UMFUTURE_MAIN USDⓈ-M Futures account transfer to Spot account.<para />
        /// - UMFUTURE_MARGIN USDⓈ-M Futures account transfer to Margin（cross）account.<para />
        /// - CMFUTURE_MAIN COIN-M Futures account transfer to Spot account.<para />
        /// - CMFUTURE_MARGIN COIN-M Futures account transfer to Margin(cross) account.<para />
        /// - MARGIN_MAIN Margin（cross）account transfer to Spot account.<para />
        /// - MARGIN_UMFUTURE Margin（cross）account transfer to USDⓈ-M Futures.<para />
        /// - MARGIN_CMFUTURE Margin（cross）account transfer to COIN-M Futures.<para />
        /// - ISOLATEDMARGIN_MARGIN Isolated margin account transfer to Margin(cross) account.<para />
        /// - MARGIN_ISOLATEDMARGIN Margin(cross) account transfer to Isolated margin account.<para />
        /// - ISOLATEDMARGIN_ISOLATEDMARGIN Isolated margin account transfer to Isolated margin account.<para />
        /// - MAIN_FUNDING Spot account transfer to Funding account.<para />
        /// - FUNDING_MAIN Funding account transfer to Spot account.<para />
        /// - FUNDING_UMFUTURE Funding account transfer to UMFUTURE account.<para />
        /// - UMFUTURE_FUNDING UMFUTURE account transfer to Funding account.<para />
        /// - MARGIN_FUNDING MARGIN account transfer to Funding account.<para />
        /// - FUNDING_MARGIN Funding account transfer to Margin account.<para />
        /// - FUNDING_CMFUTURE Funding account transfer to CMFUTURE account.<para />
        /// - CMFUTURE_FUNDING CMFUTURE account transfer to Funding account.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="type">Universal transfer type.</param>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="fromSymbol">Must be sent when type are ISOLATEDMARGIN_MARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.</param>
        /// <param name="toSymbol">Must be sent when type are MARGIN_ISOLATEDMARGIN and ISOLATEDMARGIN_ISOLATEDMARGIN.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer id.</returns>
        public async Task<string> UserUniversalTransfer(UniversalTransferType type, string asset, decimal amount, string fromSymbol = null, string toSymbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                USER_UNIVERSAL_TRANSFER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "type", type },
                    { "asset", asset },
                    { "amount", amount },
                    { "fromSymbol", fromSymbol },
                    { "toSymbol", toSymbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string FUNDING_WALLET = "/sapi/v1/asset/get-funding-asset";

        /// <summary>
        /// - Currently supports querying the following business assets：Binance Pay, Binance Card, Binance Gift Card, Stock Token.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="needBtcValuation"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Funding asset detail.</returns>
        public async Task<string> FundingWallet(string asset = null, bool? needBtcValuation = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                FUNDING_WALLET,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "needBtcValuation", needBtcValuation },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_API_KEY_PERMISSION = "/sapi/v1/account/apiRestrictions";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>API Key permissions.</returns>
        public async Task<string> GetApiKeyPermission(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_API_KEY_PERMISSION,
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