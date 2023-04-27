namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class WebSocketApiAccountTrade
    {
        private WebSocketApi wsApi;

        public WebSocketApiAccountTrade(WebSocketApi wsApi)
        {
            this.wsApi = wsApi;
        }

        /// <summary>
        /// Get current account information.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Account details.</returns>
        public async Task AccountInfoAsync(long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("account.status", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Query your current order rate limit.<para />
        /// Weight(IP): 20.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Account order rate limits.</returns>
        public async Task AccountOrderRateLimitsAsync(long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("account.rateLimits.orders", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Query information about all your orders – active, canceled, filled – filtered by time range.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="orderId">Order ID to begin at.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Account orders.</returns>
        public async Task AllOrdersAsync(string symbol, long? orderId = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "orderId", orderId },
                { "startTime", startTime },
                { "endTime", endTime },
                { "limit", limit },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("allOrders", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Query information about all your OCOs, filtered by time range.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="fromId">Order list ID to begin at.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Account OCO orders.</returns>
        public async Task AllOcoOrdersAsync(long? fromId = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "fromId", fromId },
                { "startTime", startTime },
                { "endTime", endTime },
                { "limit", limit },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("allOrderLists", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Query information about all your trades, filtered by time range.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="orderId">startTime and endTime cannot be used together with orderId.</param>
        /// <param name="fromId">Trade id to fetch from. fromId cannot be used together with startTime and endTime.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Account trades.</returns>
        public async Task AccountTradeListAsync(string symbol, long? orderId = null, long? fromId = null, long? startTime = null, long? endTime = null, int? limit = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "orderId", orderId },
                { "fromId", fromId },
                { "startTime", startTime },
                { "endTime", endTime },
                { "limit", limit },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("myTrades", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Displays the list of orders that were expired because of STP trigger.<para />
        /// | Parameter                     | Weight(IP)  |.<para />
        /// |-------------------------------|-------------|.<para />
        /// | If symbol is invalid          | 1           |.<para />
        /// | Querying by preventedMatchId  | 2           |.<para />
        /// | Querying by orderId           | 2           |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="preventedMatchId"></param>
        /// <param name="orderId"></param>
        /// <param name="fromPreventedMatchId"></param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Account prevented matches.</returns>
        public async Task AccountPreventedMatchesAsync(string symbol, long? preventedMatchId = null, long? orderId = null, long? fromPreventedMatchId = null, int? limit = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "preventedMatchId", preventedMatchId },
                { "orderId", orderId },
                { "fromPreventedMatchId", fromPreventedMatchId },
                { "limit", limit },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("myPreventedMatches", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Creates and validates a new order but does not send it into the matching engine.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="side"></param>
        /// <param name="type">Order type.</param>
        /// <param name="timeInForce">Order time in force.</param>
        /// <param name="price">Order price.</param>
        /// <param name="quantity">Order quantity.</param>
        /// <param name="quoteOrderQty">Quote quantity.</param>
        /// <param name="newClientOrderId">Arbitrary unique ID among open orders. Automatically generated if not sent.</param>
        /// <param name="newOrderRespType">Set the response JSON. MARKET and LIMIT order types default to FULL, all other orders default to ACK.</param>
        /// <param name="stopPrice">Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</param>
        /// <param name="trailingDelta">Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</param>
        /// <param name="icebergQty">Used with LIMIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT to create an iceberg order.</param>
        /// <param name="strategyId">Arbitrary numeric value identifying the order within an order strategy.</param>
        /// <param name="strategyType">Arbitrary numeric value identifying the order strategy. The value cannot be less than 1000000.</param>
        /// <param name="selfTradePreventionMode">The allowed enums is dependent on what is configured on the symbol. The possible supported values are EXPIRE_TAKER, EXPIRE_MAKER, EXPIRE_BOTH, NONE.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>OK.</returns>
        public async Task TestNewOrderAsync(string symbol, Side side, OrderType type, TimeInForce? timeInForce = null, decimal? price = null, decimal? quantity = null, decimal? quoteOrderQty = null, string newClientOrderId = null, NewOrderResponseType? newOrderRespType = null, decimal? stopPrice = null, int? trailingDelta = null, decimal? icebergQty = null, int? strategyId = null, int? strategyType = null, SelfTradePreventionMode? selfTradePreventionMode = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "side", side },
                { "type", type },
                { "timeInForce", timeInForce },
                { "price", price },
                { "quantity", quantity },
                { "quoteOrderQty", quoteOrderQty },
                { "newClientOrderId", newClientOrderId },
                { "newOrderRespType", newOrderRespType },
                { "stopPrice", stopPrice },
                { "trailingDelta", trailingDelta },
                { "icebergQty", icebergQty },
                { "strategyId", strategyId },
                { "strategyType", strategyType },
                { "selfTradePreventionMode", selfTradePreventionMode },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("order.test", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Send in a new order.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="side"></param>
        /// <param name="type">Order type.</param>
        /// <param name="timeInForce">Order time in force.</param>
        /// <param name="price">Order price.</param>
        /// <param name="quantity">Order quantity.</param>
        /// <param name="quoteOrderQty">Quote quantity.</param>
        /// <param name="newClientOrderId">Arbitrary unique ID among open orders. Automatically generated if not sent.</param>
        /// <param name="newOrderRespType">Set the response JSON. MARKET and LIMIT order types default to FULL, all other orders default to ACK.</param>
        /// <param name="stopPrice">Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</param>
        /// <param name="trailingDelta">Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</param>
        /// <param name="icebergQty">Used with LIMIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT to create an iceberg order.</param>
        /// <param name="strategyId">Arbitrary numeric value identifying the order within an order strategy.</param>
        /// <param name="strategyType">Arbitrary numeric value identifying the order strategy. The value cannot be less than 1000000.</param>
        /// <param name="selfTradePreventionMode">The allowed enums is dependent on what is configured on the symbol. The possible supported values are EXPIRE_TAKER, EXPIRE_MAKER, EXPIRE_BOTH, NONE.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Order result.</returns>
        public async Task NewOrderAsync(string symbol, Side side, OrderType type, TimeInForce? timeInForce = null, decimal? price = null, decimal? quantity = null, decimal? quoteOrderQty = null, string newClientOrderId = null, NewOrderResponseType? newOrderRespType = null, decimal? stopPrice = null, int? trailingDelta = null, decimal? icebergQty = null, int? strategyId = null, int? strategyType = null, SelfTradePreventionMode? selfTradePreventionMode = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "side", side },
                { "type", type },
                { "timeInForce", timeInForce },
                { "price", price },
                { "quantity", quantity },
                { "quoteOrderQty", quoteOrderQty },
                { "newClientOrderId", newClientOrderId },
                { "newOrderRespType", newOrderRespType },
                { "stopPrice", stopPrice },
                { "trailingDelta", trailingDelta },
                { "icebergQty", icebergQty },
                { "strategyId", strategyId },
                { "strategyType", strategyType },
                { "selfTradePreventionMode", selfTradePreventionMode },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("order.place", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Check execution status of an order.<para />
        /// - If both orderId and origClientOrderId parameters are specified, only orderId is used and origClientOrderId is ignored.<para />
        /// - For some historical orders `cummulativeQuoteQty` will be &lt; 0, meaning the data is not available at this time.<para />
        /// Weight(IP): 2.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="orderId">Lookup order by orderId.</param>
        /// <param name="origClientOrderId">Lookup order by clientOrderId.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Order result.</returns>
        public async Task QueryOrderAsync(string symbol, long? orderId = null, string origClientOrderId = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (orderId == null && origClientOrderId == null)
            {
                throw new ArgumentException("Either orderId or origClientOrderId must be sent.");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "orderId", orderId },
                { "origClientOrderId", origClientOrderId },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("order.status", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Cancel an active order.<para />
        /// Either `orderId` or `origClientOrderId` must be sent.<para />
        /// newClientOrderId will replace clientOrderId of the canceled order, freeing it up for new orders.<para />
        /// If you cancel an order that is a part of an OCO pair, the entire OCO is canceled.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="orderId">Cancel order by orderId.</param>
        /// <param name="origClientOrderId">Cancel order by clientOrderId.</param>
        /// <param name="newClientOrderId">New ID for the canceled order. Automatically generated if not sent.</param>
        /// <param name="cancelRestrictions">Determines whether the cancel will succeed if the order status is NEW or PARTIALLY_FILLED.</param>
        /// ONLY_NEW - Cancel will succeed if the order status is NEW.<para />
        /// ONLY_PARTIALLY_FILLED - Cancel will succeed if order status is PARTIALLY_FILLED.<para />
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Cancelled order..</returns>
        public async Task CancelOrderAsync(string symbol, long? orderId = null, string origClientOrderId = null,  string newClientOrderId = null, string cancelRestrictions = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (orderId == null && origClientOrderId == null)
            {
                throw new ArgumentException("Either orderId or origClientOrderId must be sent.");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "orderId", orderId },
                { "origClientOrderId", origClientOrderId },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("order.cancel", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Cancel an existing order and immediately place a new order instead of the canceled one.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="side"></param>
        /// <param name="type">Order type.</param>
        /// <param name="cancelReplaceMode">- `STOP_ON_FAILURE` If the cancel request fails, the new order placement will not be attempted.<para />
        /// - `ALLOW_FAILURES` If new order placement will be attempted even if cancel request fails.</param>
        /// <param name="timeInForce">Order time in force.</param>
        /// <param name="quantity">Order quantity.</param>
        /// <param name="quoteOrderQty">Quote quantity.</param>
        /// <param name="price">Order price.</param>
        /// <param name="cancelNewClientOrderId">New ID for the canceled order. Automatically generated if not sent.</param>
        /// <param name="cancelOrigClientOrderId">Cancel order by clientOrderId.</param>
        /// <param name="cancelOrderId">Cancel order by orderId.</param>
        /// <param name="newClientOrderId">Used to identify the new order. Automatically generated by default.</param>
        /// <param name="strategyId">Identify an order as part of a strategy.</param>
        /// <param name="strategyType">The value cannot be less than 1000000.</param>
        /// <param name="stopPrice">Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</param>
        /// <param name="trailingDelta">Used with STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.</param>
        /// <param name="icebergQty">Used with LIMIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT to create an iceberg order.</param>
        /// <param name="newOrderRespType">Select response format: ACK, RESULT, FULL. MARKET and LIMIT order types default to FULL, all other orders default to ACK.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Cancel and Replace order details.</returns>
        public async Task CancelAndReplaceOrderAsync(string symbol, Side side, OrderType type, string cancelReplaceMode, TimeInForce? timeInForce = null, decimal? quantity = null, decimal? quoteOrderQty = null, decimal? price = null, string cancelNewClientOrderId = null, string cancelOrigClientOrderId = null, long? cancelOrderId = null, string newClientOrderId = null, int? strategyId = null, int? strategyType = null, decimal? stopPrice = null, decimal? trailingDelta = null, decimal? icebergQty = null, NewOrderResponseType? newOrderRespType = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cancelOrigClientOrderId == null && cancelOrderId == null)
            {
                throw new ArgumentException("Either cancelOrigClientOrderId or cancelOrderId must be sent.");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "side", side },
                { "type", type },
                { "cancelReplaceMode", cancelReplaceMode },
                { "timeInForce", timeInForce },
                { "quantity", quantity },
                { "quoteOrderQty", quoteOrderQty },
                { "price", price },
                { "cancelNewClientOrderId", cancelNewClientOrderId },
                { "cancelOrigClientOrderId", cancelOrigClientOrderId },
                { "cancelOrderId", cancelOrderId },
                { "newClientOrderId", newClientOrderId },
                { "strategyId", strategyId },
                { "strategyType", strategyType },
                { "stopPrice", stopPrice },
                { "trailingDelta", trailingDelta },
                { "icebergQty", icebergQty },
                { "newOrderRespType", newOrderRespType },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("order.cancelReplace", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Query execution status of all open orders.<para />
        /// | Parameter           | Weight(IP)  |.<para />
        /// |---------------------|-------------|.<para />
        /// | symbol              | 3           |.<para />
        /// | none                | 40          |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT. If omitted, open orders for all symbols are returned.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Open orders result.</returns>
        public async Task CurrentOpenOrdersAsync(string symbol, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("openOrders.status", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Cancel all open orders on a symbol, including OCO orders. Cancellation reports for orders and OCOs have the same format as in order.cancel.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT. If omitted, open orders for all symbols are returned.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Canceled orders result.</returns>
        public async Task CancelAllOpenOrdersOnASymbolAsync(string symbol, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("openOrders.cancelAll", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Send in a new OCO.<para />
        /// - Price Restrictions:.<para />
        ///   - `SELL`: `price` &gt; Market Price &gt; `stopPrice`.<para />
        ///   - `BUY`: `price` &lt; Market Price &lt; `stopPrice`.<para />
        /// - Quantity Restrictions:.<para />
        ///     - Both legs must have the same quantity.<para />
        ///     - `ICEBERG` quantities however do not have to be the same.<para />
        /// - Order Rate Limit.<para />
        ///     - `OCO` counts as 2 orders against the order rate limit.<para />
        ///     .<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="price">Order price.</param>
        /// <param name="stopPrice">Either stopPrice or trailingDelta, or both must be specified.</param>
        /// <param name="listClientOrderId">Arbitrary unique ID among open OCOs. Automatically generated if not sent.</param>
        /// <param name="limitClientOrderId">Arbitrary unique ID among open orders for the limit order. Automatically generated if not sent.</param>
        /// <param name="limitStrategyId">Arbitrary numeric value identifying the limit order within an order strategy.</param>
        /// <param name="limitStrategyType">Arbitrary numeric value identifying the limit order strategy. Values smaller than 1000000 are reserved and cannot be used.</param>
        /// <param name="limitIcebergQty"></param>
        /// <param name="trailingDelta"></param>
        /// <param name="stopClientOrderId">Arbitrary unique ID among open orders for the stop order. Automatically generated if not sent.</param>
        /// <param name="stopStrategyId">Arbitrary numeric value identifying the stop order within an order strategy.</param>
        /// <param name="stopStrategyType">Arbitrary numeric value identifying the stop order strategy. Values smaller than 1000000 are reserved and cannot be used.</param>
        /// <param name="stopLimitPrice">If provided, stopLimitTimeInForce is required.</param>
        /// <param name="stopIcebergQty"></param>
        /// <param name="stopLimitTimeInForce"></param>
        /// <param name="newOrderRespType">Select response format: ACK, RESULT, FULL (default).</param>
        /// <param name="selfTradePreventionMode">The allowed enums is dependent on what is configured on the symbol. The possible supported values are EXPIRE_TAKER, EXPIRE_MAKER, EXPIRE_BOTH, NONE.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>OCO Order result.</returns>
        public async Task NewOcoOrderAsync(string symbol, Side side, decimal quantity, decimal price, decimal? stopPrice = null, string listClientOrderId = null, string limitClientOrderId = null, int? limitStrategyId = null, int? limitStrategyType = null, decimal? limitIcebergQty = null, decimal? trailingDelta = null, string stopClientOrderId = null, int? stopStrategyId = null, int? stopStrategyType = null, decimal? stopLimitPrice = null, decimal? stopIcebergQty = null, TimeInForce? stopLimitTimeInForce = null, NewOrderResponseType? newOrderRespType = null, SelfTradePreventionMode? selfTradePreventionMode = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stopPrice == null && trailingDelta == null)
            {
                throw new ArgumentException("Either stopPrice or trailingDelta, or both must be specified.");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "side", side },
                { "quantity", quantity },
                { "price", price },
                { "stopPrice", stopPrice },
                { "listClientOrderId", listClientOrderId },
                { "limitClientOrderId", limitClientOrderId },
                { "limitStrategyId", limitStrategyId },
                { "limitStrategyType", limitStrategyType },
                { "limitIcebergQty", limitIcebergQty },
                { "trailingDelta", trailingDelta },
                { "stopClientOrderId", stopClientOrderId },
                { "stopStrategyId", stopStrategyId },
                { "stopStrategyType", stopStrategyType },
                { "stopLimitPrice", stopLimitPrice },
                { "stopIcebergQty", stopIcebergQty },
                { "stopLimitTimeInForce", stopLimitTimeInForce },
                { "newOrderRespType", newOrderRespType },
                { "selfTradePreventionMode", selfTradePreventionMode },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("orderList.place", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Check execution status of an OCO.<para />
        /// If both origClientOrderId and orderListId parameters are specified, only origClientOrderId is used and orderListId is ignored.<para />
        /// Weight(IP): 2.
        /// </summary>
        /// <param name="origClientOrderId">Query OCO by listClientOrderId.</param>
        /// <param name="orderListId">Query OCO by orderListId.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Oco Order result.</returns>
        public async Task QueryOcoOrderAsync(string origClientOrderId = null, long? orderListId = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (origClientOrderId == null && orderListId == null)
            {
                throw new ArgumentException("Either orderId or origClientOrderId must be sent.");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "origClientOrderId", origClientOrderId },
                { "orderListId", orderListId },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("orderList.status", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Cancel an active OCO.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="orderListId">Cancel OCO by orderListId.</param>
        /// <param name="listClientOrderId">Cancel OCO by listClientId.</param>
        /// <param name="newClientOrderId">New ID for the canceled OCO. Automatically generated if not sent.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Canceled Oco Order result.</returns>
        public async Task CancelOcoOrderAsync(string symbol, long? orderListId = null, string listClientOrderId = null, string newClientOrderId = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (orderListId == null && listClientOrderId == null)
            {
                throw new ArgumentException("Either orderId or origClientOrderId must be sent.");
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "orderListId", orderListId },
                { "listClientOrderId", listClientOrderId },
                { "newClientOrderId", newClientOrderId },
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("orderList.cancel", parameters, requestId, cancellationToken);
        }

       /// <summary>
        /// Query execution status of all open OCOs.<para />
        /// Weight(IP): 3.
        /// </summary>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Open OCOs result.</returns>
        public async Task CurrentOpenOcoOrdersAsync(long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "recvWindow", recvWindow },
            };

            await this.wsApi.SendSignedAsync("openOrderLists.status", parameters, requestId, cancellationToken);
        }
    }
}