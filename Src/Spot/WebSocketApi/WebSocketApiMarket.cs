namespace Binance.Spot
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot.Models;

    public class WebSocketApiMarket
    {
        private WebSocketApi wsApi;

        public WebSocketApiMarket(WebSocketApi wsApi)
        {
            this.wsApi = wsApi;
        }

        /// <summary>
        /// Get current order book.<para />
        /// | Limit               | Weight(IP)  |.<para />
        /// |---------------------|-------------|.<para />
        /// | 1-100               | 1           |.<para />
        /// | 101-500             | 5           |.<para />
        /// | 501-1000            | 10          |.<para />
        /// | 1001-5000           | 50          |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit">If limit > 5000, then the response will truncate to 5000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Order book.</returns>
        public async Task OrderBookAsync(string symbol, int? limit = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "limit", limit },
            };
            await this.wsApi.SendAsync("depth", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Get recent trades.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Trade list.</returns>
        public async Task RecentTradesListAsync(string symbol, int? limit = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "limit", limit },
            };
            await this.wsApi.SendAsync("trades.recent", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Get historical trades.<para />
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Trade list.</returns>
        public async Task HistoricalTradesAsync(string symbol, int? fromId = null, int? limit = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "fromId", fromId },
                { "limit", limit },
            };
            await this.wsApi.SendApiAsync("trades.historical", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Get aggregate trades.<para />
        /// An aggregate trade (aggtrade) represents one or more individual trades. Trades that fill at the same time, from the same taker order, with the same price – those trades are collected into an aggregate trade with total quantity of the individual trades.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Aggregated Trades list.</returns>
        public async Task AggregateTradesListAsync(string symbol, int? fromId = null, long? startTime = null, long? endTime = null, int? limit = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "fromId", fromId },
                { "startTime", startTime },
                { "endTime", endTime },
                { "limit", limit },
            };
            await this.wsApi.SendAsync("trades.aggregate", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Kline/candlestick bars for a symbol.<para />
        /// Klines are uniquely identified by their open and close time.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="interval">kline intervals.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Klines.</returns>
        public async Task KlinesAsync(string symbol, Interval interval, long? startTime = null, long? endTime = null, int? limit = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "interval", interval },
                { "startTime", startTime },
                { "endTime", endTime },
                { "limit", limit },
            };
            await this.wsApi.SendAsync("klines", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Get klines (candlestick bars) optimized for presentation.<para />
        /// This request is similar to klines, having the same parameters and response. uiKlines return modified kline data, optimized for presentation of candlestick charts.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="interval">kline intervals.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>UI Klines.</returns>
        public async Task UiKlinesAsync(string symbol, Interval interval, long? startTime = null, long? endTime = null, int? limit = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "interval", interval },
                { "startTime", startTime },
                { "endTime", endTime },
                { "limit", limit },
            };
            await this.wsApi.SendAsync("uiKlines", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Current average price for a symbol.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Average price.</returns>
        public async Task CurrentAveragePriceAsync(string symbol, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
            };
            await this.wsApi.SendAsync("avgPrice", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// 24 hour rolling window price change statistics.<para />
        /// | Symbols             | Weight(IP)  |.<para />
        /// |---------------------|-------------|.<para />
        /// | 1-20                | 1           |.<para />
        /// | 21-100              | 20          |.<para />
        /// | 501 or more         | 40          |.<para />
        /// | all symbols         | 40          |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols"></param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>24hr ticker.</returns>
        public async Task TwentyFourHrTickerPriceChangeStatisticsAsync(string symbol = null, string[] symbols = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "symbols", symbols },
            };

            BinanceParametersUtils.EnsureOnlyOneValidKey(parameters, new string[] { "symbol", "symbols" });
            await this.wsApi.SendAsync("ticker.24hr", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Get rolling window price change statistics with a custom window.<para />
        /// | Symbols             | Weight(IP)  |.<para />
        /// |---------------------|-------------|.<para />
        /// | 1-50                |2 per symbol |.<para />
        /// | 51-100              | 100         |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols">Either symbol or symbols must be provided.</param>
        /// <param name="type">Ticker type: FULL (default) or MINI.</param>
        /// <param name="windowSize">Defaults to 1d if no parameter provided.</param>
        /// Supported windowSize values:.<para />
        /// 1m,2m....59m - for minutes.<para />
        /// 1h, 2h....23h - for hours.<para />
        /// 1d...7d - for days.<para />
        /// Units cannot be combined (e.g. 1d2h is not allowed).<para />
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Rolling price ticker.</returns>
        public async Task RollingWindowPriceChangeStatisticsAsync(string symbol = null, string[] symbols = null, TickerType? type = null, string windowSize = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "symbols", symbols },
                { "type", type },
                { "windowSize", windowSize },
            };

            BinanceParametersUtils.EnsureOnlyOneValidKey(parameters, new string[] { "symbol", "symbols" });
            await this.wsApi.SendAsync("ticker", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Get the latest market price for a symbol.<para />
        /// | Parameter           | Weight(IP)  |.<para />
        /// |---------------------|-------------|.<para />
        /// | symbol              | 1           |.<para />
        /// | symbols             | 2           |.<para />
        /// | none                | 2           |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols">Query price for multiple symbols.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Price ticker.</returns>
        public async Task SymbolPriceTickerAsync(string symbol = null, string[] symbols = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "symbols", symbols },
            };

            BinanceParametersUtils.EnsureOnlyOneValidKey(parameters, new string[] { "symbol", "symbols" });
            await this.wsApi.SendAsync("ticker.price", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Get the current best price and quantity on the order book.<para />
        /// | Parameter           | Weight(IP)  |.<para />
        /// |---------------------|-------------|.<para />
        /// | symbol              | 1           |.<para />
        /// | symbols             | 2           |.<para />
        /// | none                | 2           |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols">Query price for multiple symbols.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>OrderBook ticker.</returns>
        public async Task SymbolOrderBookTickerAsync(string symbol = null, string[] symbols = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "symbols", symbols },
            };

            BinanceParametersUtils.EnsureOnlyOneValidKey(parameters, new string[] { "symbol", "symbols" });
            await this.wsApi.SendAsync("ticker.book", parameters, requestId, cancellationToken);
        }
    }
}
