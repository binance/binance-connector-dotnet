namespace Binance.Futures
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Shared.Models;

    public class FMarket : FuturesService
    {
        public FMarket(string baseUrl = DEFAULT_FUTURES_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public FMarket(HttpClient httpClient, string baseUrl = DEFAULT_FUTURES_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public FMarket(HttpClient httpClient, IBinanceSignatureService signatureService, string baseUrl = DEFAULT_FUTURES_BASE_URL, string apiKey = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, signatureService: signatureService)
        {
        }

        private const string TEST_CONNECTIVITY = "/fapi/v1/ping";

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

        private const string CHECK_SERVER_TIME = "/fapi/v1/time";

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
        public async Task<DateTime> GetServerTime()
        {
            var d = await CheckServerTime();
            long dn = Helper.ConvertStringToLong(d);
            return Helper.UnixTimeStampToDateTime(dn);
        }

        private const string EXCHANGE_INFORMATION = "/fapi/v1/exchangeInfo";

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

        private const string ORDER_BOOK = "/fapi/v1/depth";

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

        private const string RECENT_TRADES_LIST = "/fapi/v1/trades";

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

        private const string OLD_TRADE_LOOKUP = "/fapi/v1/historicalTrades";

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

        private const string COMPRESSED_AGGREGATE_TRADES_LIST = "/fapi/v1/aggTrades";

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

        private const string KLINE_CANDLESTICK_DATA = "/fapi/v1/klines";

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
        public async Task<List<Candlestick>> KlineCandlestick(string symbol, Interval interval, long? startTime = null, long? endTime = null, int? limit = null)
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
            List<Candlestick> data = ConvertStringToSymbolPrice(result);
            return data;
        }
        public List<Candlestick> ConvertStringToSymbolPrice(string content)
        {
            string[] cArray = content.Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
            List<Candlestick> list = new List<Candlestick>();
            foreach (string s in cArray)
            {
                string[] fields = s.Split(',');
                Candlestick uc = new Candlestick();
                uc.OpenTime = Helper.GetJsonTime(fields[0]);
                uc.OpenPrice = Helper.ConvertStringToDecimal(fields[1]);
                uc.HighPrice = Helper.ConvertStringToDecimal(fields[2]);
                uc.LowPrice = Helper.ConvertStringToDecimal(fields[3]);
                uc.ClosePrice = Helper.ConvertStringToDecimal(fields[4]);
                uc.Volume = Helper.ConvertStringToDecimal(fields[5]);
                uc.CloseTime = Helper.GetJsonTime(fields[6]);
                uc.NumberOfTrades = Helper.ConvertStringToLong(fields[7]);
                list.Add(uc);
            }
            return list;
        }
        public async Task<T> KlineCandlestickData<T>(string symbol, Interval interval, long? startTime = null, long? endTime = null, int? limit = null)
        {
            var result = await this.SendPublicAsync<T>(
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

        private const string CURRENT_AVERAGE_PRICE = "/fapi/v1/avgPrice";

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

        private const string TWENTY_FOUR_HR_TICKER_PRICE_CHANGE_STATISTICS = "/fapi/v1/ticker/24hr";

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

        private const string SYMBOL_PRICE_TICKER = "/fapi/v1/ticker/price";

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

        private const string SYMBOL_ORDER_BOOK_TICKER = "/fapi/v1/ticker/bookTicker";

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

        private const string ROLLING_WINDOW_PRICE_CHANGE_STATISTICS = "/fapi/v1/ticker";

        /// <summary>
        /// The window used to compute statistics is typically slightly wider than requested windowSize.<para />
        /// openTime for /api/v3/ticker always starts on a minute, while the closeTime is the current time of the request. As such, the effective window might be up to 1 minute wider than requested.<para />
        /// E.g. If the closeTime is 1641287867099 (January 04, 2022 09:17:47:099 UTC) , and the windowSize is 1d. the openTime will be: 1641201420000 (January 3, 2022, 09:17:00 UTC).<para />
        /// Weight(IP): 2 for each requested symbol regardless of windowSize.<para />
        /// The weight for this request will cap at 100 once the number of symbols in the request is more than 50.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols">Either symbol or symbols must be provided.<para />
        /// Examples of accepted format for the symbols parameter: ["BTCUSDT","BNBUSDT"] or %5B%22BTCUSDT%22,%22BNBUSDT%22%5D.<para />
        /// The maximum number of symbols allowed in a request is 100.</param>
        /// <param name="windowSize">Defaults to 1d if no parameter provided.<para />
        /// Supported windowSize values:.<para />
        /// 1m,2m....59m for minutes.<para />
        /// 1h, 2h....23h - for hours.<para />
        /// 1d...7d - for days.<para />
        /// Units cannot be combined (e.g. 1d2h is not allowed).</param>
        /// <returns>Rolling price ticker.</returns>
        public async Task<string> RollingWindowPriceChangeStatistics(string symbol = null, string symbols = null, string windowSize = null)
        {
            var result = await this.SendPublicAsync<string>(
                ROLLING_WINDOW_PRICE_CHANGE_STATISTICS,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "symbol", symbol },
                    { "symbols", symbols },
                    { "windowSize", windowSize },
                });

            return result;
        }
    }
}