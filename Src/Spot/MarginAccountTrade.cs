namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class MarginAccountTrade : SpotService
    {
        public MarginAccountTrade(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public MarginAccountTrade(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string CROSS_MARGIN_ACCOUNT_TRANSFER = "/sapi/v1/margin/transfer";

        /// <summary>
        /// Execute transfer between spot account and cross margin account.<para />
        /// Weight(IP): 600.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="type">* `1` - transfer from main account to margin account.<para />
        /// * `2` - transfer from margin account to main account.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transfer Id.</returns>
        public async Task<string> CrossMarginAccountTransfer(string asset, decimal amount, MarginTransferType type, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                CROSS_MARGIN_ACCOUNT_TRANSFER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "amount", amount },
                    { "type", type },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MARGIN_ACCOUNT_BORROW = "/sapi/v1/margin/loan";

        /// <summary>
        /// Apply for a loan.<para />
        /// - If "isIsolated" = "TRUE", "symbol" must be sent.<para />
        /// - "isIsolated" = "FALSE" for crossed margin loan.<para />
        /// Weight(UID): 3000.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transaction id.</returns>
        public async Task<string> MarginAccountBorrow(string asset, decimal amount, bool? isIsolated = null, string symbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_ACCOUNT_BORROW,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "isIsolated", isIsolated },
                    { "symbol", symbol },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MARGIN_ACCOUNT_REPAY = "/sapi/v1/margin/repay";

        /// <summary>
        /// Repay loan for margin account.<para />
        /// - If "isIsolated" = "TRUE", "symbol" must be sent.<para />
        /// - "isIsolated" = "FALSE" for crossed margin repay.<para />
        /// Weight(IP): 3000.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transaction id.</returns>
        public async Task<string> MarginAccountRepay(string asset, decimal amount, bool? isIsolated = null, string symbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_ACCOUNT_REPAY,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "isIsolated", isIsolated },
                    { "symbol", symbol },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ASSET = "/sapi/v1/margin/asset";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="asset"></param>
        /// <returns>Asset details.</returns>
        public async Task<string> QueryMarginAsset(string asset)
        {
            var result = await this.SendPublicAsync<string>(
                QUERY_MARGIN_ASSET,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                });

            return result;
        }

        private const string QUERY_CROSS_MARGIN_PAIR = "/sapi/v1/margin/pair";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <returns>Margin pair details.</returns>
        public async Task<string> QueryCrossMarginPair(string symbol)
        {
            var result = await this.SendPublicAsync<string>(
                QUERY_CROSS_MARGIN_PAIR,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                });

            return result;
        }

        private const string GET_ALL_MARGIN_ASSETS = "/sapi/v1/margin/allAssets";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>Assets details.</returns>
        public async Task<string> GetAllMarginAssets()
        {
            var result = await this.SendPublicAsync<string>(
                GET_ALL_MARGIN_ASSETS,
                HttpMethod.Get);

            return result;
        }

        private const string GET_ALL_CROSS_MARGIN_PAIRS = "/sapi/v1/margin/allPairs";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>Margin pairs.</returns>
        public async Task<string> GetAllCrossMarginPairs()
        {
            var result = await this.SendPublicAsync<string>(
                GET_ALL_CROSS_MARGIN_PAIRS,
                HttpMethod.Get);

            return result;
        }

        private const string QUERY_MARGIN_PRICEINDEX = "/sapi/v1/margin/priceIndex";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <returns>Price index.</returns>
        public async Task<string> QueryMarginPriceindex(string symbol)
        {
            var result = await this.SendPublicAsync<string>(
                QUERY_MARGIN_PRICEINDEX,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                });

            return result;
        }

        private const string MARGIN_ACCOUNT_NEW_ORDER = "/sapi/v1/margin/order";

        /// <summary>
        /// Post a new order for margin account.<para />
        /// Weight(UID): 6.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="side"></param>
        /// <param name="type">Order type.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="quantity"></param>
        /// <param name="quoteOrderQty">Quote quantity.</param>
        /// <param name="price">Order price.</param>
        /// <param name="stopPrice">Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</param>
        /// <param name="newClientOrderId">Used to uniquely identify this cancel. Automatically generated by default.</param>
        /// <param name="icebergQty">Used with LIMIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT to create an iceberg order.</param>
        /// <param name="newOrderRespType">Set the response JSON.</param>
        /// <param name="sideEffectType">Default `NO_SIDE_EFFECT`.</param>
        /// <param name="timeInForce">Order time in force.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin order info.</returns>
        public async Task<string> MarginAccountNewOrder(string symbol, Side side, OrderType type, bool? isIsolated = null, decimal? quantity = null, decimal? quoteOrderQty = null, decimal? price = null, decimal? stopPrice = null, string newClientOrderId = null, decimal? icebergQty = null, NewOrderResponseType? newOrderRespType = null, SideEffectType? sideEffectType = null, TimeInForce? timeInForce = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_ACCOUNT_NEW_ORDER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "side", side },
                    { "type", type },
                    { "quantity", quantity },
                    { "quoteOrderQty", quoteOrderQty },
                    { "price", price },
                    { "stopPrice", stopPrice },
                    { "newClientOrderId", newClientOrderId },
                    { "icebergQty", icebergQty },
                    { "newOrderRespType", newOrderRespType },
                    { "sideEffectType", sideEffectType },
                    { "timeInForce", timeInForce },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MARGIN_ACCOUNT_CANCEL_ORDER = "/sapi/v1/margin/order";

        /// <summary>
        /// Cancel an active order for margin account.<para />
        /// Either `orderId` or `origClientOrderId` must be sent.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="orderId">Order id.</param>
        /// <param name="origClientOrderId">Order id from client.</param>
        /// <param name="newClientOrderId">Used to uniquely identify this cancel. Automatically generated by default.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Cancelled margin order details.</returns>
        public async Task<string> MarginAccountCancelOrder(string symbol, bool? isIsolated = null, long? orderId = null, string origClientOrderId = null, string newClientOrderId = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_ACCOUNT_CANCEL_ORDER,
                HttpMethod.Delete,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "orderId", orderId },
                    { "origClientOrderId", origClientOrderId },
                    { "newClientOrderId", newClientOrderId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MARGIN_ACCOUNT_CANCEL_ALL_OPEN_ORDERS_ON_A_SYMBOL = "/sapi/v1/margin/openOrders";

        /// <summary>
        /// - Cancels all active orders on a symbol for margin account.<para />
        /// - This includes OCO orders.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Cancelled margin orders.</returns>
        public async Task<string> MarginAccountCancelAllOpenOrdersOnASymbol(string symbol, bool? isIsolated = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_ACCOUNT_CANCEL_ALL_OPEN_ORDERS_ON_A_SYMBOL,
                HttpMethod.Delete,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_CROSS_MARGIN_TRANSFER_HISTORY = "/sapi/v1/margin/transfer";

        /// <summary>
        /// - Response in descending order.<para />
        /// - Returns data for last 7 days by default.<para />
        /// - Set `archived` to `true` to query data from 6 months ago.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="type">Transfer Type.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="archived">Default: false. Set to true for archived data from 6 months ago.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin account transfer history, response in descending order.</returns>
        public async Task<string> GetCrossMarginTransferHistory(string asset = null, CrossMarginTransferType? type = null, long? startTime = null, long? endTime = null, int? current = null, int? size = null, bool? archived = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_CROSS_MARGIN_TRANSFER_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "type", type },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "archived", archived },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_LOAN_RECORD = "/sapi/v1/margin/loan";

        /// <summary>
        /// - `txId` or `startTime` must be sent. `txId` takes precedence.<para />
        /// - Response in descending order.<para />
        /// - If `isolatedSymbol` is not sent, crossed margin data will be returned.<para />
        /// - Set `archived` to `true` to query data from 6 months ago.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="isolatedSymbol">Isolated symbol.</param>
        /// <param name="txId">the tranId in  `POST /sapi/v1/margin/loan`.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="archived">Default: false. Set to true for archived data from 6 months ago.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Loan records.</returns>
        public async Task<string> QueryLoanRecord(string asset, string isolatedSymbol = null, long? txId = null, long? startTime = null, long? endTime = null, long? current = null, long? size = null, bool? archived = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_LOAN_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "isolatedSymbol", isolatedSymbol },
                    { "txId", txId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "archived", archived },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_REPAY_RECORD = "/sapi/v1/margin/repay";

        /// <summary>
        /// - `txId` or `startTime` must be sent. `txId` takes precedence.<para />
        /// - Response in descending order.<para />
        /// - If `isolatedSymbol` is not sent, crossed margin data will be returned.<para />
        /// - Set `archived` to `true` to query data from 6 months ago.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="isolatedSymbol">Isolated symbol.</param>
        /// <param name="txId">the tranId in  `POST /sapi/v1/margin/repay`.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="archived">Default: false. Set to true for archived data from 6 months ago.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Load records.</returns>
        public async Task<string> QueryRepayRecord(string asset, string isolatedSymbol = null, long? txId = null, long? startTime = null, long? endTime = null, long? current = null, long? size = null, bool? archived = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_REPAY_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "isolatedSymbol", isolatedSymbol },
                    { "txId", txId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "archived", archived },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_INTEREST_HISTORY = "/sapi/v1/margin/interestHistory";

        /// <summary>
        /// - Response in descending order.<para />
        /// - If `isolatedSymbol` is not sent, crossed margin data will be returned.<para />
        /// - Set `archived` to `true` to query data from 6 months ago.<para />
        /// - `type` in response has 4 enums:.<para />
        ///   - `PERIODIC` interest charged per hour.<para />
        ///   - `ON_BORROW` first interest charged on borrow.<para />
        ///   - `PERIODIC_CONVERTED` interest charged per hour converted into BNB.<para />
        ///   - `ON_BORROW_CONVERTED` first interest charged on borrow converted into BNB.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="isolatedSymbol">Isolated symbol.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="archived">Default: false. Set to true for archived data from 6 months ago.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Interest History, response in descending order.</returns>
        public async Task<string> GetInterestHistory(string asset = null, string isolatedSymbol = null, long? startTime = null, long? endTime = null, long? current = null, long? size = null, bool? archived = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_INTEREST_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "isolatedSymbol", isolatedSymbol },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "archived", archived },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_FORCE_LIQUIDATION_RECORD = "/sapi/v1/margin/forceLiquidationRec";

        /// <summary>
        /// - Response in descending order.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="isolatedSymbol">Isolated symbol.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="archived"></param>
        /// <returns>Force Liquidation History, response in descending order.</returns>
        public async Task<string> GetForceLiquidationRecord(long? startTime = null, long? endTime = null, string isolatedSymbol = null, long? current = null, long? size = null, long? recvWindow = null, bool? archived = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_FORCE_LIQUIDATION_RECORD,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "isolatedSymbol", isolatedSymbol },
                    { "current", current },
                    { "size", size },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                    { "archived", archived },
                });

            return result;
        }

        private const string QUERY_CROSS_MARGIN_ACCOUNT_DETAILS = "/sapi/v1/margin/account";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin account details.</returns>
        public async Task<string> QueryCrossMarginAccountDetails(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_CROSS_MARGIN_ACCOUNT_DETAILS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ACCOUNTS_ORDER = "/sapi/v1/margin/order";

        /// <summary>
        /// - Either `orderId` or `origClientOrderId` must be sent.<para />
        /// - For some historical orders `cummulativeQuoteQty` will be &lt; 0, meaning the data is not available at this time.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="orderId">Order id.</param>
        /// <param name="origClientOrderId">Order id from client.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Interest History, response in descending order.</returns>
        public async Task<string> QueryMarginAccountsOrder(string symbol, bool? isIsolated = null, long? orderId = null, string origClientOrderId = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_ACCOUNTS_ORDER,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "orderId", orderId },
                    { "origClientOrderId", origClientOrderId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ACCOUNTS_OPEN_ORDERS = "/sapi/v1/margin/openOrders";

        /// <summary>
        /// - If the `symbol` is not sent, orders for all symbols will be returned in an array.<para />
        /// - When all symbols are returned, the number of requests counted against the rate limiter is equal to the number of symbols currently trading on the exchange.<para />
        /// - If isIsolated ="TRUE", symbol must be sent.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin open orders list.</returns>
        public async Task<string> QueryMarginAccountsOpenOrders(string symbol = null, bool? isIsolated = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_ACCOUNTS_OPEN_ORDERS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ACCOUNTS_ALL_ORDERS = "/sapi/v1/margin/allOrders";

        /// <summary>
        /// - If `orderId` is set, it will get orders &gt;= that orderId. Otherwise most recent orders are returned.<para />
        /// - For some historical orders `cummulativeQuoteQty` will be &lt; 0, meaning the data is not available at this time.<para />
        /// Weight(IP): 200.<para />
        /// Request Limit: 60 times/min per IP.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="orderId">Order id.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin order list.</returns>
        public async Task<string> QueryMarginAccountsAllOrders(string symbol, bool? isIsolated = null, long? orderId = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_ACCOUNTS_ALL_ORDERS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "orderId", orderId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MARGIN_ACCOUNT_NEW_OCO = "/sapi/v1/margin/order/oco";

        /// <summary>
        /// Send in a new OCO for a margin account.<para />
        /// - Price Restrictions:.<para />
        ///   - SELL: Limit Price &gt; Last Price &gt; Stop Price.<para />
        ///   - BUY: Limit Price &lt; Last Price &lt; Stop Price.<para />
        /// - Quantity Restrictions:.<para />
        ///   - Both legs must have the same quantity.<para />
        ///   - ICEBERG quantities however do not have to be the same.<para />
        /// - Order Rate Limit.<para />
        ///   - OCO counts as 2 orders against the order rate limit.<para />
        /// Weight(UID): 6.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="price">Order price.</param>
        /// <param name="stopPrice"></param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="listClientOrderId">A unique Id for the entire orderList.</param>
        /// <param name="limitClientOrderId">A unique Id for the limit order.</param>
        /// <param name="limitIcebergQty"></param>
        /// <param name="stopClientOrderId">A unique Id for the stop loss/stop loss limit leg.</param>
        /// <param name="stopLimitPrice">If provided, stopLimitTimeInForce is required.</param>
        /// <param name="stopIcebergQty"></param>
        /// <param name="stopLimitTimeInForce"></param>
        /// <param name="newOrderRespType">Set the response JSON.</param>
        /// <param name="sideEffectType">Default `NO_SIDE_EFFECT`.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>New Margin OCO details.</returns>
        public async Task<string> MarginAccountNewOco(string symbol, Side side, decimal quantity, decimal price, decimal stopPrice, bool? isIsolated = null, string listClientOrderId = null, string limitClientOrderId = null, decimal? limitIcebergQty = null, string stopClientOrderId = null, decimal? stopLimitPrice = null, decimal? stopIcebergQty = null, TimeInForce? stopLimitTimeInForce = null, NewOrderResponseType? newOrderRespType = null, SideEffectType? sideEffectType = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_ACCOUNT_NEW_OCO,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "listClientOrderId", listClientOrderId },
                    { "side", side },
                    { "quantity", quantity },
                    { "limitClientOrderId", limitClientOrderId },
                    { "price", price },
                    { "limitIcebergQty", limitIcebergQty },
                    { "stopClientOrderId", stopClientOrderId },
                    { "stopPrice", stopPrice },
                    { "stopLimitPrice", stopLimitPrice },
                    { "stopIcebergQty", stopIcebergQty },
                    { "stopLimitTimeInForce", stopLimitTimeInForce },
                    { "newOrderRespType", newOrderRespType },
                    { "sideEffectType", sideEffectType },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MARGIN_ACCOUNT_CANCEL_OCO = "/sapi/v1/margin/orderList";

        /// <summary>
        /// Cancel an entire Order List for a margin account.<para />
        /// - Canceling an individual leg will cancel the entire OCO.<para />
        /// - Either `orderListId` or `listClientOrderId` must be provided.<para />
        /// Weight(UID): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="orderListId">Order list id.</param>
        /// <param name="listClientOrderId">A unique Id for the entire orderList.</param>
        /// <param name="newClientOrderId">Used to uniquely identify this cancel. Automatically generated by default.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin OCO details.</returns>
        public async Task<string> MarginAccountCancelOco(string symbol, bool? isIsolated = null, long? orderListId = null, string listClientOrderId = null, string newClientOrderId = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MARGIN_ACCOUNT_CANCEL_OCO,
                HttpMethod.Delete,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "orderListId", orderListId },
                    { "listClientOrderId", listClientOrderId },
                    { "newClientOrderId", newClientOrderId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ACCOUNTS_OCO = "/sapi/v1/margin/orderList";

        /// <summary>
        /// Retrieves a specific OCO based on provided optional parameters.<para />
        /// - Either `orderListId` or `origClientOrderId` must be provided.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="symbol">Mandatory for isolated margin, not supported for cross margin.</param>
        /// <param name="orderListId">Order list id.</param>
        /// <param name="origClientOrderId">Order id from client.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin OCO details.</returns>
        public async Task<string> QueryMarginAccountsOco(bool? isIsolated = null, string symbol = null, long? orderListId = null, string origClientOrderId = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_ACCOUNTS_OCO,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "isIsolated", isIsolated },
                    { "symbol", symbol },
                    { "orderListId", orderListId },
                    { "origClientOrderId", origClientOrderId },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ACCOUNTS_ALL_OCO = "/sapi/v1/margin/allOrderList";

        /// <summary>
        /// Retrieves all OCO for a specific margin account based on provided optional parameters.<para />
        /// Weight(IP): 200.
        /// </summary>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="symbol">Mandatory for isolated margin, not supported for cross margin.</param>
        /// <param name="fromId">If supplied, neither `startTime` or `endTime` can be provided.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default Value: 500; Max Value: 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of Margin OCO orders.</returns>
        public async Task<string> QueryMarginAccountsAllOco(bool? isIsolated = null, string symbol = null, long? fromId = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_ACCOUNTS_ALL_OCO,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "isIsolated", isIsolated },
                    { "symbol", symbol },
                    { "fromId", fromId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ACCOUNTS_OPEN_OCO = "/sapi/v1/margin/openOrderList";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="symbol">Mandatory for isolated margin, not supported for cross margin.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of Open Margin OCO orders.</returns>
        public async Task<string> QueryMarginAccountsOpenOco(bool? isIsolated = null, string symbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_ACCOUNTS_OPEN_OCO,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "isIsolated", isIsolated },
                    { "symbol", symbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_ACCOUNTS_TRADE_LIST = "/sapi/v1/margin/myTrades";

        /// <summary>
        /// - If `fromId` is set, it will get orders &gt;= that `fromId`. Otherwise most recent trades are returned.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of margin trades.</returns>
        public async Task<string> QueryMarginAccountsTradeList(string symbol, bool? isIsolated = null, long? startTime = null, long? endTime = null, long? fromId = null, int? limit = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_ACCOUNTS_TRADE_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "isIsolated", isIsolated },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "fromId", fromId },
                    { "limit", limit },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MAX_BORROW = "/sapi/v1/margin/maxBorrowable";

        /// <summary>
        /// - If `isolatedSymbol` is not sent, crossed margin data will be sent.<para />
        /// - `borrowLimit` is also available from https://www.binance.com/en/margin-fee.<para />
        /// Weight(IP): 50.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="isolatedSymbol">Isolated symbol.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Details on max borrow amount.</returns>
        public async Task<string> QueryMaxBorrow(string asset, bool? isolatedSymbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MAX_BORROW,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "isolatedSymbol", isolatedSymbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MAX_TRANSFEROUT_AMOUNT = "/sapi/v1/margin/maxTransferable";

        /// <summary>
        /// - If `isolatedSymbol` is not sent, crossed margin data will be sent.<para />
        /// Weight(IP): 50.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="isolatedSymbol">Isolated symbol.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Details on max transferable amount.</returns>
        public async Task<string> QueryMaxTransferoutAmount(string asset, bool? isolatedSymbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MAX_TRANSFEROUT_AMOUNT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "isolatedSymbol", isolatedSymbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ISOLATED_MARGIN_ACCOUNT_TRANSFER = "/sapi/v1/margin/isolated/transfer";

        /// <summary>
        /// Weight(UID): 600.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="transFrom"></param>
        /// <param name="transTo"></param>
        /// <param name="amount"></param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Transaction Id.</returns>
        public async Task<string> IsolatedMarginAccountTransfer(string asset, string symbol, IsolatedMarginAccountTransferType transFrom, IsolatedMarginAccountTransferType transTo, decimal amount, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ISOLATED_MARGIN_ACCOUNT_TRANSFER,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "symbol", symbol },
                    { "transFrom", transFrom },
                    { "transTo", transTo },
                    { "amount", amount },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_ISOLATED_MARGIN_TRANSFER_HISTORY = "/sapi/v1/margin/isolated/transfer";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="asset"></param>
        /// <param name="transFrom"></param>
        /// <param name="transTo"></param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="current">Current querying page. Start from 1. Default:1.</param>
        /// <param name="size">Default:10 Max:100.</param>
        /// <param name="archived">Default: false. Set to true for archived data from 6 months ago.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Isolated Margin Transfer History.</returns>
        public async Task<string> GetIsolatedMarginTransferHistory(string symbol, string asset = null, IsolatedMarginAccountTransferType? transFrom = null, IsolatedMarginAccountTransferType? transTo = null, long? startTime = null, long? endTime = null, long? current = null, long? size = null, string archived = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_ISOLATED_MARGIN_TRANSFER_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "symbol", symbol },
                    { "transFrom", transFrom },
                    { "transTo", transTo },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "current", current },
                    { "size", size },
                    { "archived", archived },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_ISOLATED_MARGIN_ACCOUNT_INFO = "/sapi/v1/margin/isolated/account";

        /// <summary>
        /// - If "symbols" is not sent, all isolated assets will be returned.<para />
        /// - If "symbols" is sent, only the isolated assets of the sent symbols will be returned.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbols">Max 5 symbols can be sent; separated by ','.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Isolated Margin Account Info when "symbols" is not sent.</returns>
        public async Task<string> QueryIsolatedMarginAccountInfo(string symbols = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_ISOLATED_MARGIN_ACCOUNT_INFO,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbols", symbols },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string DISABLE_ISOLATED_MARGIN_ACCOUNT = "/sapi/v1/margin/isolated/account";

        /// <summary>
        /// Disable isolated margin account for a specific symbol. Each trading pair can only be deactivated once every 24 hours .<para />
        /// Weight(UID): 300.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Isolated Margin Account status.</returns>
        public async Task<string> DisableIsolatedMarginAccount(string symbol, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                DISABLE_ISOLATED_MARGIN_ACCOUNT,
                HttpMethod.Delete,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ENABLE_ISOLATED_MARGIN_ACCOUNT = "/sapi/v1/margin/isolated/account";

        /// <summary>
        /// Enable isolated margin account for a specific symbol.<para />
        /// Weight(UID): 300.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Isolated Margin Account status.</returns>
        public async Task<string> EnableIsolatedMarginAccount(string symbol, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ENABLE_ISOLATED_MARGIN_ACCOUNT,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_ENABLED_ISOLATED_MARGIN_ACCOUNT_LIMIT = "/sapi/v1/margin/isolated/accountLimit";

        /// <summary>
        /// Query enabled isolated margin account limit.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Number of enabled Isolated Margin Account and its limit.</returns>
        public async Task<string> QueryEnabledIsolatedMarginAccountLimit(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_ENABLED_ISOLATED_MARGIN_ACCOUNT_LIMIT,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_ISOLATED_MARGIN_SYMBOL = "/sapi/v1/margin/isolated/pair";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Isolated Margin Symbol.</returns>
        public async Task<string> QueryIsolatedMarginSymbol(string symbol, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_ISOLATED_MARGIN_SYMBOL,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_ALL_ISOLATED_MARGIN_SYMBOL = "/sapi/v1/margin/isolated/allPairs";

        /// <summary>
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>All Isolated Margin Symbols.</returns>
        public async Task<string> GetAllIsolatedMarginSymbol(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_ALL_ISOLATED_MARGIN_SYMBOL,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string TOGGLE_BNB_BURN_ON_SPOT_TRADE_AND_MARGIN_INTEREST = "/sapi/v1/bnbBurn";

        /// <summary>
        /// - "spotBNBBurn" and "interestBNBBurn" should be sent at least one.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="spotBNBBurn">Determines whether to use BNB to pay for trading fees on SPOT.</param>
        /// <param name="interestBNBBurn">Determines whether to use BNB to pay for margin loan's interest.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Status on BNB to pay for trading fees.</returns>
        public async Task<string> ToggleBnbBurnOnSpotTradeAndMarginInterest(bool? spotBNBBurn = null, bool? interestBNBBurn = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                TOGGLE_BNB_BURN_ON_SPOT_TRADE_AND_MARGIN_INTEREST,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "spotBNBBurn", spotBNBBurn },
                    { "interestBNBBurn", interestBNBBurn },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string GET_BNB_BURN_STATUS = "/sapi/v1/bnbBurn";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Status on BNB to pay for trading fees.</returns>
        public async Task<string> GetBnbBurnStatus(long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                GET_BNB_BURN_STATUS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_MARGIN_INTEREST_RATE_HISTORY = "/sapi/v1/margin/interestRateHistory";

        /// <summary>
        /// The max interval between startTime and endTime is 30 days.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="vipLevel">Defaults to user's vip level.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Margin Interest Rate History.</returns>
        public async Task<string> QueryMarginInterestRateHistory(string asset, int? vipLevel = null, long? startTime = null, long? endTime = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_MARGIN_INTEREST_RATE_HISTORY,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "asset", asset },
                    { "vipLevel", vipLevel },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_CROSS_MARGIN_FEE_DATA = "/sapi/v1/margin/crossMarginData";

        /// <summary>
        /// Get cross margin fee data collection with any vip level or user's current specific data as https://www.binance.com/en/margin-fee.<para />
        /// Weight(IP): 1 when coin is specified; 5 when the coin parameter is omitted.
        /// </summary>
        /// <param name="vipLevel">Defaults to user's vip level.</param>
        /// <param name="coin">Coin name.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Cross Margin Fee Data.</returns>
        public async Task<string> QueryCrossMarginFeeData(int? vipLevel = null, string coin = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_CROSS_MARGIN_FEE_DATA,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "vipLevel", vipLevel },
                    { "coin", coin },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_ISOLATED_MARGIN_FEE_DATA = "/sapi/v1/margin/isolatedMarginData";

        /// <summary>
        /// Get isolated margin fee data collection with any vip level or user's current specific data as https://www.binance.com/en/margin-fee.<para />
        /// Weight(IP): 1 when a single is specified; 10 when the symbol parameter is omitted.
        /// </summary>
        /// <param name="vipLevel">Defaults to user's vip level.</param>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Isolated Margin Fee Data.</returns>
        public async Task<string> QueryIsolatedMarginFeeData(int? vipLevel = null, string symbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_ISOLATED_MARGIN_FEE_DATA,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "vipLevel", vipLevel },
                    { "symbol", symbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_ISOLATED_MARGIN_TIER_DATA = "/sapi/v1/margin/isolatedMarginTier";

        /// <summary>
        /// Get isolated margin tier data collection with any tier as https://www.binance.com/en/margin-data.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="tier">All margin tier data will be returned if tier is omitted.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Isolated Margin Tier Data.</returns>
        public async Task<string> QueryIsolatedMarginTierData(string symbol, string tier = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_ISOLATED_MARGIN_TIER_DATA,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "tier", tier },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string QUERY_CURRENT_MARGIN_ORDER_COUNT_USAGE = "/sapi/v1/margin/rateLimit/order";

        /// <summary>
        /// Displays the user's current margin order count usage for all intervals.<para />
        /// Weight(IP): 20.
        /// </summary>
        /// <param name="isIsolated">* `TRUE` - For isolated margin.<para />
        /// * `FALSE` - Default, not for isolated margin.</param>
        /// <param name="symbol">isolated symbol, mandatory for isolated margin.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Usage..</returns>
        public async Task<string> QueryCurrentMarginOrderCountUsage(string isIsolated = null, string symbol = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                QUERY_CURRENT_MARGIN_ORDER_COUNT_USAGE,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "isIsolated", isIsolated },
                    { "symbol", symbol },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}