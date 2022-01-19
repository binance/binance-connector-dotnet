namespace Binance.Spot.Tests
{
    using System;
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
            var responseContent = "{\"timezone\":\"UTC\",\"serverTime\":1565246363776,\"rateLimits\":[{}],\"exchangeFilters\":[],\"symbols\":[{\"symbol\":\"ETHBTC\",\"status\":\"TRADING\",\"baseAsset\":\"ETH\",\"baseAssetPrecision\":8,\"quoteAsset\":\"BTC\",\"quotePrecision\":8,\"quoteAssetPrecision\":8,\"orderTypes\":[\"LIMIT\",\"LIMIT_MAKER\",\"MARKET\",\"STOP_LOSS\",\"STOP_LOSS_LIMIT\",\"TAKE_PROFIT\",\"TAKE_PROFIT_LIMIT\"],\"icebergAllowed\":true,\"ocoAllowed\":true,\"isSpotTradingAllowed\":true,\"isMarginTradingAllowed\":true,\"filters\":[],\"permissions\":[\"SPOT\",\"MARGIN\"]}]}";
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

            var result = await market.OrderBook("BTCUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RecentTradesList
        [Fact]
        public async void RecentTradesList_Response()
        {
            var responseContent = "[{\"id\":28457,\"price\":\"4.00000100\",\"qty\":\"12.00000000\",\"quoteQty\":\"48.000012\",\"time\":1499865549590,\"isBuyerMaker\":true,\"isBestMatch\":true}]";
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

            var result = await market.RecentTradesList("BTCUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region OldTradeLookup
        [Fact]
        public async void OldTradeLookup_Response()
        {
            var responseContent = "[{\"id\":28457,\"price\":\"4.00000100\",\"qty\":\"12.00000000\",\"quoteQty\":\"48.000012\",\"time\":1499865549590,\"isBuyerMaker\":true,\"isBestMatch\":true}]";
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

            var result = await market.OldTradeLookup("BTCUSDT");

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

            var result = await market.CompressedAggregateTradesList("BTCUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region KlineCandlestickData
        [Fact]
        public async void KlineCandlestickData_Response()
        {
            var responseContent = "[[1499040000000,\"0.01634790\",\"0.80000000\",\"0.01575800\",\"0.01577100\",\"148976.11427815\",1499644799999,\"2434.19055334\",308,\"1756.87402397\",\"28.46694368\",\"17928899.62484339\"]]";
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

            var result = await market.KlineCandlestickData("BTCUSDT", Interval.FIFTEEN_MINUTE);

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

            var result = await market.CurrentAveragePrice("BTCUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region TwentyFourHrTickerPriceChangeStatistics
        [Fact]
        public async void TwentyFourHrTickerPriceChangeStatistics_Response()
        {
            var responseContent = "{\"symbol\":\"BNBBTC\",\"priceChange\":\"-94.99999800\",\"priceChangePercent\":\"-95.960\",\"weightedAvgPrice\":\"0.29628482\",\"prevClosePrice\":\"0.10002000\",\"lastPrice\":\"4.00000200\",\"lastQty\":\"200.00000000\",\"bidPrice\":\"4.00000000\",\"askPrice\":\"4.00000200\",\"openPrice\":\"99.00000000\",\"highPrice\":\"100.00000000\",\"lowPrice\":\"0.10000000\",\"volume\":\"8913.30000000\",\"quoteVolume\":\"15.30000000\",\"openTime\":1499783499040,\"closeTime\":1499869899040,\"firstId\":28385,\"lastId\":28460,\"count\":76}";
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
            var responseContent = "{\"symbol\":\"LTCBTC\",\"price\":\"4.00000200\"}";
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
            var responseContent = "{\"symbol\":\"LTCBTC\",\"bidPrice\":\"4.00000000\",\"bidQty\":\"431.00000000\",\"askPrice\":\"4.00000200\",\"askQty\":\"9.00000000\"}";
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
    }
}