namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Market_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region TestConnectivity
        [Fact]
        public async void TestConnectivity_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ping", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.TestConnectivity();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CheckServerTime
        [Fact]
        public async void CheckServerTime_Response()
        {
            var responseContent = "{\"serverTime\":1499827319559}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/time", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.CheckServerTime();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region ExchangeInformation
        [Fact]
        public async void ExchangeInformation_Response()
        {
            var responseContent = "{\"timezone\":\"UTC\",\"serverTime\":1592882214236,\"rateLimits\":[{\"rateLimitType\":\"REQUEST_WEIGHT\",\"interval\":\"MINUTE\",\"intervalNum\":1,\"limit\":1200}],\"exchangeFilters\":[{}],\"symbols\":[{\"symbol\":\"ETHBTC\",\"status\":\"TRADING\",\"baseAsset\":\"ETH\",\"baseAssetPrecision\":8,\"quoteAsset\":\"BTC\",\"quoteAssetPrecision\":8,\"baseCommissionPrecision\":8,\"quoteCommissionPrecision\":8,\"orderTypes\":[\"LIMIT\"],\"icebergAllowed\":true,\"ocoAllowed\":true,\"quoteOrderQtyMarketAllowed\":true,\"allowTrailingStop\":false,\"isSpotTradingAllowed\":true,\"isMarginTradingAllowed\":true,\"filters\":[{\"filterType\":\"PRICE_FILTER\",\"minPrice\":\"0.00000100\",\"maxPrice\":\"100000.00000000\",\"tickSize\":\"0.00000100\"}],\"permissions\":[\"SPOT\"]}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/exchangeInfo", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.ExchangeInformation();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region OrderBook
        [Fact]
        public async void OrderBook_Response()
        {
            var responseContent = "{\"lastUpdateId\":1027024,\"bids\":[[\"4.00000000\",\"431.00000000\"]],\"asks\":[[\"4.00000200\",\"12.00000000\"]]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/depth", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.OrderBook("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RecentTradesList
        [Fact]
        public async void RecentTradesList_Response()
        {
            var responseContent = "[{\"id\":345196462,\"price\":\"9638.99000000\",\"qty\":\"0.02077200\",\"quoteQty\":\"0.02077200\",\"time\":1592887772684,\"isBuyerMaker\":true,\"isBestMatch\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/trades", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.RecentTradesList("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region OldTradeLookup
        [Fact]
        public async void OldTradeLookup_Response()
        {
            var responseContent = "[{\"id\":345196462,\"price\":\"9638.99000000\",\"qty\":\"0.02077200\",\"quoteQty\":\"0.02077200\",\"time\":1592887772684,\"isBuyerMaker\":true,\"isBestMatch\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/historicalTrades", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.OldTradeLookup("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CompressedAggregateTradesList
        [Fact]
        public async void CompressedAggregateTradesList_Response()
        {
            var responseContent = "[{\"a\":26129,\"p\":\"0.01633102\",\"q\":\"4.70443515\",\"f\":27781,\"l\":27781,\"T\":1498793709153,\"m\":true,\"M\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/aggTrades", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.CompressedAggregateTradesList("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region KlineCandlestickData
        [Fact]
        public async void KlineCandlestickData_Response()
        {
            var responseContent = "[[0]]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/klines", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.KlineCandlestickData("BNBUSDT", Interval.ONE_MINUTE);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CurrentAveragePrice
        [Fact]
        public async void CurrentAveragePrice_Response()
        {
            var responseContent = "{\"mins\":5,\"price\":\"9.35751834\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/avgPrice", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.CurrentAveragePrice("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region TwentyFourHrTickerPriceChangeStatistics
        [Fact]
        public async void TwentyFourHrTickerPriceChangeStatistics_Response()
        {
            var responseContent = "{\"symbol\":\"BNBBTC\",\"priceChange\":\"0.17160000\",\"priceChangePercent\":\"1.060\",\"prevClosePrice\":\"16.35920000\",\"lastPrice\":\"27.84000000\",\"bidPrice\":\"16.34488284\",\"bidQty\":\"16.34488284\",\"askPrice\":\"16.35920000\",\"askQty\":\"25.06000000\",\"openPrice\":\"16.18760000\",\"highPrice\":\"16.55000000\",\"lowPrice\":\"16.16940000\",\"volume\":\"1678279.95000000\",\"quoteVolume\":\"27431289.14792300\",\"openTime\":1592808788637,\"closeTime\":1592895188637,\"firstId\":62683296,\"lastId\":62739253,\"count\":55958}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ticker/24hr", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.TwentyFourHrTickerPriceChangeStatistics();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region SymbolPriceTicker
        [Fact]
        public async void SymbolPriceTicker_Response()
        {
            var responseContent = "{\"symbol\":\"BNBBTC\",\"price\":\"0.17160000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ticker/price", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.SymbolPriceTicker();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region SymbolOrderBookTicker
        [Fact]
        public async void SymbolOrderBookTicker_Response()
        {
            var responseContent = "{\"symbol\":\"BNBBTC\",\"bidPrice\":\"16.36240000\",\"bidQty\":\"256.78000000\",\"askPrice\":\"16.36450000\",\"askQty\":\"12.56000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ticker/bookTicker", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.SymbolOrderBookTicker();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RollingWindowPriceChangeStatistics
        [Fact]
        public async void RollingWindowPriceChangeStatistics_Response()
        {
            var responseContent = "{\"symbol\":\"BNBBTC\",\"priceChange\":\"-8.00000000\",\"priceChangePercent\":\"-88.889\",\"weightedAvgPrice\":\"2.60427807\",\"openPrice\":\"9.00000000\",\"highPrice\":\"9.00000000\",\"lowPrice\":\"1.00000000\",\"lastPrice\":\"1.00000000\",\"volume\":\"187.00000000\",\"quoteVolume\":\"487.00000000\",\"openTime\":1641859200000,\"closeTime\":1642031999999,\"firstId\":0,\"lastId\":60,\"count\":61}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/ticker", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Market market = new Market(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await market.RollingWindowPriceChangeStatistics();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}