namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class SpotAccountTrade_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region TestNewOrder
        [Fact]
        public async void TestNewOrder_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/order/test", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.TestNewOrder("BNBUSDT", Side.SELL, OrderType.MARKET);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region NewOrder
        [Fact]
        public async void NewOrder_Response()
        {
            var responseContent = "{\"symbol\":\"BTCUSDT\",\"orderId\":28,\"orderListId\":-1,\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"transactTime\":1507725176595}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/order", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.NewOrder("BNBUSDT", Side.SELL, OrderType.MARKET);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CancelOrder
        [Fact]
        public async void CancelOrder_Response()
        {
            var responseContent = "{\"symbol\":\"BNBBTC\",\"origClientOrderId\":\"msXkySR3u5uYwpvRMFsi3u\",\"orderId\":28,\"orderListId\":-1,\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"price\":\"1.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"10.00000000\",\"cummulativeQuoteQty\":\"10.00000000\",\"status\":\"FILLED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"SELL\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/order", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.CancelOrder("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CancelAllOpenOrdersOnASymbol
        [Fact]
        public async void CancelAllOpenOrdersOnASymbol_Response()
        {
            var responseContent = "[{\"symbol\":\"BNBBTC\",\"origClientOrderId\":\"msXkySR3u5uYwpvRMFsi3u\",\"orderId\":28,\"orderListId\":-1,\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"price\":\"1.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"10.00000000\",\"cummulativeQuoteQty\":\"10.00000000\",\"status\":\"FILLED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"SELL\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/openOrders", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.CancelAllOpenOrdersOnASymbol("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryOrder
        [Fact]
        public async void QueryOrder_Response()
        {
            var responseContent = "{\"symbol\":\"LTCBTC\",\"orderId\":1,\"orderListId\":-1,\"clientOrderId\":\"myOrder1\",\"price\":\"0.1\",\"origQty\":\"1.0\",\"executedQty\":\"0.0\",\"cummulativeQuoteQty\":\"0.0\",\"status\":\"NEW\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"BUY\",\"stopPrice\":\"0.0\",\"icebergQty\":\"0.0\",\"time\":1499827319559,\"updateTime\":1499827319559,\"isWorking\":true,\"origQuoteOrderQty\":\"0.00000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/order", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.QueryOrder("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CurrentOpenOrders
        [Fact]
        public async void CurrentOpenOrders_Response()
        {
            var responseContent = "[{\"symbol\":\"LTCBTC\",\"orderId\":1,\"orderListId\":-1,\"clientOrderId\":\"myOrder1\",\"price\":\"0.1\",\"origQty\":\"1.0\",\"executedQty\":\"0.0\",\"cummulativeQuoteQty\":\"0.0\",\"status\":\"NEW\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"BUY\",\"stopPrice\":\"0.0\",\"icebergQty\":\"0.0\",\"time\":1499827319559,\"updateTime\":1499827319559,\"isWorking\":true,\"origQuoteOrderQty\":\"0.00000000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/openOrders", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.CurrentOpenOrders();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AllOrders
        [Fact]
        public async void AllOrders_Response()
        {
            var responseContent = "[{\"symbol\":\"LTCBTC\",\"orderId\":1,\"orderListId\":-1,\"clientOrderId\":\"myOrder1\",\"price\":\"0.1\",\"origQty\":\"1.0\",\"executedQty\":\"0.0\",\"cummulativeQuoteQty\":\"0.0\",\"status\":\"NEW\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"BUY\",\"stopPrice\":\"0.0\",\"icebergQty\":\"0.0\",\"time\":1499827319559,\"updateTime\":1499827319559,\"isWorking\":true,\"origQuoteOrderQty\":\"0.00000000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/allOrders", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.AllOrders("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region NewOco
        [Fact]
        public async void NewOco_Response()
        {
            var responseContent = "{\"orderListId\":0,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"JYVpp3F0f5CAG15DhtrqLp\",\"transactionTime\":1563417480525,\"symbol\":\"LTCBTC\",\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}],\"orderReports\":[{\"symbol\":\"\",\"orderId\":0,\"orderListId\":0,\"clientOrderId\":\"\",\"transactTime\":0,\"price\":\"\",\"origQty\":\"\",\"executedQty\":\"\",\"cummulativeQuoteQty\":\"\",\"status\":\"\",\"timeInForce\":\"\",\"type\":\"\",\"side\":\"\",\"stopPrice\":\"\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/order/oco", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.NewOco("BNBUSDT", Side.SELL, 0.1m, 400.15m, 390.3m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CancelOco
        [Fact]
        public async void CancelOco_Response()
        {
            var responseContent = "{\"orderListId\":1929,\"contingencyType\":\"OCO\",\"listStatusType\":\"ALL_DONE\",\"listOrderStatus\":\"ALL_DONE\",\"listClientOrderId\":\"C3wyj4WVEktd7u9aVBRXcN\",\"transactionTime\":1574040868128,\"symbol\":\"BNBBTC\",\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}],\"orderReports\":[{\"symbol\":\"\",\"origClientOrderId\":\"\",\"orderId\":0,\"orderListId\":0,\"clientOrderId\":\"\",\"price\":\"\",\"origQty\":\"\",\"executedQty\":\"\",\"cummulativeQuoteQty\":\"\",\"status\":\"\",\"timeInForce\":\"\",\"type\":\"\",\"side\":\"\",\"stopPrice\":\"\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/orderList", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.CancelOco("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryOco
        [Fact]
        public async void QueryOco_Response()
        {
            var responseContent = "{\"orderListId\":27,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"h2USkA5YQpaXHPIrkd96xE\",\"transactionTime\":1565245656253,\"symbol\":\"LTCBTC\",\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/orderList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.QueryOco();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryAllOco
        [Fact]
        public async void QueryAllOco_Response()
        {
            var responseContent = "[{\"orderListId\":29,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"amEEAXryFzFwYF1FeRpUoZ\",\"transactionTime\":1565245913483,\"symbol\":\"LTCBTC\",\"isIsolated\":true,\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/allOrderList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.QueryAllOco();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryOpenOco
        [Fact]
        public async void QueryOpenOco_Response()
        {
            var responseContent = "[{\"orderListId\":31,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"wuB13fmulKj3YjdqWEcsnp\",\"transactionTime\":1565246080644,\"symbol\":\"LTCBTC\",\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/openOrderList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.QueryOpenOco();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AccountInformation
        [Fact]
        public async void AccountInformation_Response()
        {
            var responseContent = "{\"makerCommission\":15,\"takerCommission\":15,\"buyerCommission\":0,\"sellerCommission\":0,\"canTrade\":true,\"canWithdraw\":true,\"canDeposit\":true,\"updateTime\":123456789,\"accountType\":\"SPOT\",\"balances\":[{\"asset\":\"BTC\",\"free\":\"4723846.89208129\",\"locked\":\"0.00000000\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/account", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.AccountInformation();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AccountTradeList
        [Fact]
        public async void AccountTradeList_Response()
        {
            var responseContent = "[{\"symbol\":\"BNBBTC\",\"id\":28457,\"orderId\":100234,\"orderListId\":-1,\"price\":\"4.00000100\",\"qty\":\"12.00000000\",\"quoteQty\":\"48.000012\",\"commission\":\"10.10000000\",\"commissionAsset\":\"BNB\",\"time\":1499865549590,\"isBuyer\":false,\"isMaker\":false,\"isBestMatch\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/myTrades", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.AccountTradeList("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryCurrentOrderCountUsage
        [Fact]
        public async void QueryCurrentOrderCountUsage_Response()
        {
            var responseContent = "[{\"rateLimitType\":\"\",\"interval\":\"\",\"intervalNum\":0,\"limit\":0,\"count\":0}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/api/v3/rateLimit/order", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SpotAccountTrade spotAccountTrade = new SpotAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await spotAccountTrade.QueryCurrentOrderCountUsage();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}