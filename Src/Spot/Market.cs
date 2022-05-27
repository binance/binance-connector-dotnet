namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Market : SpotService
    {
        public Market(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Market(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string TEST_CONNECTIVITY = "/api/v3/ping";

        /// <summary>
        /// Test connectivity to the Rest API.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>OK.</returns>
        public async Task<string> TestConnectivity()
        {
            var result = await this.SendPublicAsync<string>(
                TEST_CONNECTIVITY,
                HttpMethod.Get);

            return result;
        }

        private const string CHECK_SERVER_TIME = "/api/v3/time";

        /// <summary>
        /// Test connectivity to the Rest API and get the current server time.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>Binance server UTC timestamp.</returns>
        public async Task<string> CheckServerTime()
        {
            var result = await this.SendPublicAsync<string>(
                CHECK_SERVER_TIME,
                HttpMethod.Get);

            return result;
        }

        private const string EXCHANGE_INFORMATION = "/api/v3/exchangeInfo";

        /// <summary>
        /// Current exchange trading rules and symbol information.<para />
        /// - If any symbol provided in either symbol or symbols do not exist, the endpoint will throw an error.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols"></param>
        /// <returns>Current exchange trading rules and symbol information.</returns>
        public async Task<string> ExchangeInformation(string symbol = null, string symbols = null)
        {
            var result = await this.SendPublicAsync<string>(
                EXCHANGE_INFORMATION,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "symbols", symbols },
                });

            return result;
        }

        private const string ORDER_BOOK = "/api/v3/depth";

        /// <summary>
        /// | Limit               | Weight(IP)  |.<para />
        /// |---------------------|-------------|.<para />
        /// | 1-100               | 1           |.<para />
        /// | 101-500             | 5           |.<para />
        /// | 501-1000            | 10          |.<para />
        /// | 1001-5000           | 50          |.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit">If limit > 5000, then the response will truncate to 5000.</param>
        /// <returns>Order book.</returns>
        public async Task<string> OrderBook(string symbol, int? limit = null)
        {
            var result = await this.SendPublicAsync<string>(
                ORDER_BOOK,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "limit", limit },
                });

            return result;
        }

        private const string RECENT_TRADES_LIST = "/api/v3/trades";

        /// <summary>
        /// Get recent trades.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns>Trade list.</returns>
        public async Task<string> RecentTradesList(string symbol, int? limit = null)
        {
            var result = await this.SendPublicAsync<string>(
                RECENT_TRADES_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "limit", limit },
                });

            return result;
        }

        private const string OLD_TRADE_LOOKUP = "/api/v3/historicalTrades";

        /// <summary>
        /// Get older market trades.<para />
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <returns>Trade list.</returns>
        public async Task<string> OldTradeLookup(string symbol, int? limit = null, long? fromId = null)
        {
            var result = await this.SendPublicAsync<string>(
                OLD_TRADE_LOOKUP,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "limit", limit },
                    { "fromId", fromId },
                });

            return result;
        }

        private const string COMPRESSED_AGGREGATE_TRADES_LIST = "/api/v3/aggTrades";

        /// <summary>
        /// Get compressed, aggregate trades. Trades that fill at the time, from the same order, with the same price will have the quantity aggregated.<para />
        /// - If `startTime` and `endTime` are sent, time between startTime and endTime must be less than 1 hour.<para />
        /// - If `fromId`, `startTime`, and `endTime` are not sent, the most recent aggregate trades will be returned.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="fromId">Trade id to fetch from. Default gets most recent trades.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns>Trade list.</returns>
        public async Task<string> CompressedAggregateTradesList(string symbol, long? fromId = null, long? startTime = null, long? endTime = null, int? limit = null)
        {
            var result = await this.SendPublicAsync<string>(
                COMPRESSED_AGGREGATE_TRADES_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "fromId", fromId },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                });

            return result;
        }

        private const string KLINE_CANDLESTICK_DATA = "/api/v3/klines";

        /// <summary>
        /// Kline/candlestick bars for a symbol.<para />
        /// Klines are uniquely identified by their open time.<para />
        /// - If `startTime` and `endTime` are not sent, the most recent klines are returned.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="interval">kline intervals.</param>
        /// <param name="startTime">UTC timestamp in ms.</param>
        /// <param name="endTime">UTC timestamp in ms.</param>
        /// <param name="limit">Default 500; max 1000.</param>
        /// <returns>Kline data.</returns>
        public async Task<string> KlineCandlestickData(string symbol, Interval interval, long? startTime = null, long? endTime = null, int? limit = null)
        {
            var result = await this.SendPublicAsync<string>(
                KLINE_CANDLESTICK_DATA,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "interval", interval },
                    { "startTime", startTime },
                    { "endTime", endTime },
                    { "limit", limit },
                });

            return result;
        }

        private const string CURRENT_AVERAGE_PRICE = "/api/v3/avgPrice";

        /// <summary>
        /// Current average price for a symbol.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <returns>Average price.</returns>
        public async Task<string> CurrentAveragePrice(string symbol)
        {
            var result = await this.SendPublicAsync<string>(
                CURRENT_AVERAGE_PRICE,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                });

            return result;
        }

        private const string TWENTY_FOUR_HR_TICKER_PRICE_CHANGE_STATISTICS = "/api/v3/ticker/24hr";

        /// <summary>
        /// 24 hour rolling window price change statistics. Careful when accessing this with no symbol.<para />
        /// - If the symbol is not sent, tickers for all symbols will be returned in an array.<para />
        /// Weight(IP):.<para />
        /// - `1` for a single symbol;.<para />
        /// - `40` when the symbol parameter is omitted;.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols"></param>
        /// <returns>24hr ticker.</returns>
        public async Task<string> TwentyFourHrTickerPriceChangeStatistics(string symbol = null, string symbols = null)
        {
            var result = await this.SendPublicAsync<string>(
                TWENTY_FOUR_HR_TICKER_PRICE_CHANGE_STATISTICS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "symbols", symbols },
                });

            return result;
        }

        private const string SYMBOL_PRICE_TICKER = "/api/v3/ticker/price";

        /// <summary>
        /// Latest price for a symbol or symbols.<para />
        /// - If the symbol is not sent, prices for all symbols will be returned in an array.<para />
        /// Weight(IP):.<para />
        /// - `1` for a single symbol;.<para />
        /// - `2` when the symbol parameter is omitted;.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols"></param>
        /// <returns>Price ticker.</returns>
        public async Task<string> SymbolPriceTicker(string symbol = null, string symbols = null)
        {
            var result = await this.SendPublicAsync<string>(
                SYMBOL_PRICE_TICKER,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "symbols", symbols },
                });

            return result;
        }

        private const string SYMBOL_ORDER_BOOK_TICKER = "/api/v3/ticker/bookTicker";

        /// <summary>
        /// Best price/qty on the order book for a symbol or symbols.<para />
        /// - If the symbol is not sent, bookTickers for all symbols will be returned in an array.<para />
        /// Weight(IP):.<para />
        /// - `1` for a single symbol;.<para />
        /// - `2` when the symbol parameter is omitted;.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols"></param>
        /// <returns>Order book ticker.</returns>
        public async Task<string> SymbolOrderBookTicker(string symbol = null, string symbols = null)
        {
            var result = await this.SendPublicAsync<string>(
                SYMBOL_ORDER_BOOK_TICKER,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "symbols", symbols },
                });

            return result;
        }
    }
}