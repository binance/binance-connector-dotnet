namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class MarginAccountTrade_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region CrossMarginAccountTransfer
        [Fact]
        public async void CrossMarginAccountTransfer_Response()
        {
            var responseContent = "{\"tranId\":345196462}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/transfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.CrossMarginAccountTransfer("BTC", 1.01m, MarginTransferType.SPOT_TO_MARGIN);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountBorrow
        [Fact]
        public async void MarginAccountBorrow_Response()
        {
            var responseContent = "{\"tranId\":345196462}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/loan", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.MarginAccountBorrow("BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountRepay
        [Fact]
        public async void MarginAccountRepay_Response()
        {
            var responseContent = "{\"tranId\":345196462}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/repay", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.MarginAccountRepay("BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAsset
        [Fact]
        public async void QueryMarginAsset_Response()
        {
            var responseContent = "{\"assetFullName\":\"Binance Coin\",\"assetName\":\"BNB\",\"isBorrowable\":false,\"isMortgageable\":true,\"userMinBorrow\":\"0.00000000\",\"userMinRepay\":\"0.00000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/asset", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAsset("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryCrossMarginPair
        [Fact]
        public async void QueryCrossMarginPair_Response()
        {
            var responseContent = "{\"id\":323355778339572400,\"symbol\":\"BNBUSDT\",\"base\":\"BTC\",\"quote\":\"USDT\",\"isMarginTrade\":true,\"isBuyAllowed\":true,\"isSellAllowed\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/pair", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryCrossMarginPair("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetAllMarginAssets
        [Fact]
        public async void GetAllMarginAssets_Response()
        {
            var responseContent = "[{\"assetFullName\":\"Binance coin\",\"assetName\":\"BNB\",\"isBorrowable\":true,\"isMortgageable\":true,\"userMinBorrow\":\"0.00000000\",\"userMinRepay\":\"0.00000000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/allAssets", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetAllMarginAssets();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetAllCrossMarginPairs
        [Fact]
        public async void GetAllCrossMarginPairs_Response()
        {
            var responseContent = "[{\"base\":\"BNB\",\"id\":351637150141315840,\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"BTC\",\"symbol\":\"BNBBTC\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/allPairs", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetAllCrossMarginPairs();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginPriceindex
        [Fact]
        public async void QueryMarginPriceindex_Response()
        {
            var responseContent = "{\"calcTime\":1562046418000,\"price\":\"0.00333930\",\"symbol\":\"BNBBTC\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/priceIndex", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginPriceindex("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountNewOrder
        [Fact]
        public async void MarginAccountNewOrder_Response()
        {
            var responseContent = "{\"symbol\":\"BTCUSDT\",\"orderId\":28,\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"isIsolated\":true,\"transactTime\":1507725176595}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/order", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.MarginAccountNewOrder("BNBUSDT", Side.SELL, OrderType.MARKET);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountCancelOrder
        [Fact]
        public async void MarginAccountCancelOrder_Response()
        {
            var responseContent = "{\"symbol\":\"LTCBTC\",\"orderId\":28,\"origClientOrderId\":\"msXkySR3u5uYwpvRMFsi3u\",\"clientOrderId\":\"6gCrw2kRUAF9CvJDGP16IP\",\"price\":\"1.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"8.00000000\",\"cummulativeQuoteQty\":\"8.00000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"SELL\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/order", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.MarginAccountCancelOrder("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountCancelAllOpenOrdersOnASymbol
        [Fact]
        public async void MarginAccountCancelAllOpenOrdersOnASymbol_Response()
        {
            var responseContent = "[{\"symbol\":\"BNBUSDT\",\"isIsolated\":true,\"origClientOrderId\":\"E6APeyTJvkMvLMYMqu1KQ4\",\"orderId\":11,\"orderListId\":-1,\"clientOrderId\":\"pXLV6Hz6mprAcVYpVMTGgx\",\"price\":\"0.089853\",\"origQty\":\"0.178622\",\"executedQty\":\"0.000000\",\"cummulativeQuoteQty\":\"0.000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"BUY\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/openOrders", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.MarginAccountCancelAllOpenOrdersOnASymbol("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetCrossMarginTransferHistory
        [Fact]
        public async void GetCrossMarginTransferHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"amount\":\"\",\"asset\":\"\",\"status\":\"\",\"timestamp\":0,\"txId\":0,\"type\":\"\"}],\"total\":3}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/transfer", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetCrossMarginTransferHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryLoanRecord
        [Fact]
        public async void QueryLoanRecord_Response()
        {
            var responseContent = "{\"rows\":[{\"isolatedSymbol\":\"\",\"txId\":0,\"asset\":\"\",\"principal\":\"\",\"timestamp\":0,\"status\":\"\"}],\"total\":0}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/loan", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryLoanRecord("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryRepayRecord
        [Fact]
        public async void QueryRepayRecord_Response()
        {
            var responseContent = "{\"rows\":[{\"isolatedSymbol\":\"BNBUSDT\",\"amount\":\"14.00000000\",\"asset\":\"BNB\",\"interest\":\"0.01866667\",\"principal\":\"13.98133333\",\"status\":\"CONFIRMED\",\"timestamp\":1563438204000,\"txId\":2970933056}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/repay", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryRepayRecord("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetInterestHistory
        [Fact]
        public async void GetInterestHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"isolatedSymbol\":\"BNBUSDT\",\"asset\":\"BNB\",\"interest\":\"0.01866667\",\"interestAccuredTime\":1566813600,\"interestRate\":\"0.01600000\",\"principal\":\"36.22000000\",\"type\":\"ON_BORROW\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/interestHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetInterestHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetForceLiquidationRecord
        [Fact]
        public async void GetForceLiquidationRecord_Response()
        {
            var responseContent = "{\"rows\":[{\"avgPrice\":\"\",\"executedQty\":\"\",\"orderId\":0,\"price\":\"\",\"qty\":\"\",\"side\":\"\",\"symbol\":\"\",\"timeInForce\":\"\",\"isIsolated\":true,\"updatedTime\":0}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/forceLiquidationRec", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetForceLiquidationRecord();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryCrossMarginAccountDetails
        [Fact]
        public async void QueryCrossMarginAccountDetails_Response()
        {
            var responseContent = "{\"borrowEnabled\":true,\"marginLevel\":\"11.64405625\",\"totalAssetOfBtc\":\"6.82728457\",\"totalLiabilityOfBtc\":\"0.58633215\",\"totalNetAssetOfBtc\":\"6.24095242\",\"tradeEnabled\":true,\"transferEnabled\":true,\"userAssets\":[{\"asset\":\"BTC\",\"borrowed\":\"0.00000000\",\"free\":\"0.00499500\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00499500\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/account", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryCrossMarginAccountDetails();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsOrder
        [Fact]
        public async void QueryMarginAccountsOrder_Response()
        {
            var responseContent = "{\"clientOrderId\":\"ZwfQzuDIGpceVhKW5DvCmO\",\"cummulativeQuoteQty\":\"0.00000000\",\"executedQty\":\"0.00000000\",\"icebergQty\":\"0.00000000\",\"isWorking\":true,\"orderId\":213205622,\"origQty\":\"0.30000000\",\"price\":\"0.00493630\",\"side\":\"SELL\",\"status\":\"NEW\",\"stopPrice\":\"0.00000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":true,\"time\":1562133008725,\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"updateTime\":1562133008725}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/order", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAccountsOrder("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsOpenOrders
        [Fact]
        public async void QueryMarginAccountsOpenOrders_Response()
        {
            var responseContent = "[{\"clientOrderId\":\"ZwfQzuDIGpceVhKW5DvCmO\",\"cummulativeQuoteQty\":\"0.00000000\",\"executedQty\":\"0.00000000\",\"icebergQty\":\"0.00000000\",\"isWorking\":true,\"orderId\":213205622,\"origQty\":\"0.30000000\",\"price\":\"0.00493630\",\"side\":\"SELL\",\"status\":\"NEW\",\"stopPrice\":\"0.00000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":true,\"time\":1562133008725,\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"updateTime\":1562133008725}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/openOrders", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAccountsOpenOrders();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsAllOrders
        [Fact]
        public async void QueryMarginAccountsAllOrders_Response()
        {
            var responseContent = "[{\"clientOrderId\":\"ZwfQzuDIGpceVhKW5DvCmO\",\"cummulativeQuoteQty\":\"0.00000000\",\"executedQty\":\"0.00000000\",\"icebergQty\":\"0.00000000\",\"isWorking\":true,\"orderId\":213205622,\"origQty\":\"0.30000000\",\"price\":\"0.00493630\",\"side\":\"SELL\",\"status\":\"NEW\",\"stopPrice\":\"0.00000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":true,\"time\":1562133008725,\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"updateTime\":1562133008725}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/allOrders", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAccountsAllOrders("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountNewOco
        [Fact]
        public async void MarginAccountNewOco_Response()
        {
            var responseContent = "{\"orderListId\":0,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"JYVpp3F0f5CAG15DhtrqLp\",\"transactionTime\":1563417480525,\"symbol\":\"LTCBTC\",\"marginBuyBorrowAmount\":\"5\",\"marginBuyBorrowAsset\":\"BTC\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}],\"orderReports\":[{\"symbol\":\"\",\"orderId\":0,\"orderListId\":0,\"clientOrderId\":\"\",\"transactTime\":0,\"price\":\"\",\"origQty\":\"\",\"executedQty\":\"\",\"cummulativeQuoteQty\":\"\",\"status\":\"\",\"timeInForce\":\"\",\"type\":\"\",\"side\":\"\",\"stopPrice\":\"\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/order/oco", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.MarginAccountNewOco("BNBUSDT", Side.SELL, 0.1m, 400.15m, 390.3m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountCancelOco
        [Fact]
        public async void MarginAccountCancelOco_Response()
        {
            var responseContent = "{\"orderListId\":0,\"contingencyType\":\"OCO\",\"listStatusType\":\"ALL_DONE\",\"listOrderStatus\":\"ALL_DONE\",\"listClientOrderId\":\"C3wyj4WVEktd7u9aVBRXcN\",\"transactionTime\":1574040868128,\"symbol\":\"BNBUSDT\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}],\"orderReports\":[{\"symbol\":\"\",\"origClientOrderId\":\"\",\"orderId\":0,\"orderListId\":0,\"clientOrderId\":\"\",\"price\":\"\",\"origQty\":\"\",\"executedQty\":\"\",\"cummulativeQuoteQty\":\"\",\"status\":\"\",\"timeInForce\":\"\",\"type\":\"\",\"side\":\"\",\"stopPrice\":\"\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/orderList", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.MarginAccountCancelOco("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsOco
        [Fact]
        public async void QueryMarginAccountsOco_Response()
        {
            var responseContent = "{\"orderListId\":27,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"h2USkA5YQpaXHPIrkd96xE\",\"transactionTime\":1565245656253,\"symbol\":\"LTCBTC\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/orderList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAccountsOco();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsAllOco
        [Fact]
        public async void QueryMarginAccountsAllOco_Response()
        {
            var responseContent = "[{\"orderListId\":29,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"amEEAXryFzFwYF1FeRpUoZ\",\"transactionTime\":1565245913483,\"symbol\":\"LTCBTC\",\"isIsolated\":true,\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/allOrderList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAccountsAllOco();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsOpenOco
        [Fact]
        public async void QueryMarginAccountsOpenOco_Response()
        {
            var responseContent = "[{\"orderListId\":31,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"wuB13fmulKj3YjdqWEcsnp\",\"transactionTime\":1565246080644,\"symbol\":\"LTCBTC\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"\",\"orderId\":0,\"clientOrderId\":\"\"}]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/openOrderList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAccountsOpenOco();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsTradeList
        [Fact]
        public async void QueryMarginAccountsTradeList_Response()
        {
            var responseContent = "[{\"commission\":\"0.00006000\",\"commissionAsset\":\"BTC\",\"id\":28,\"isBestMatch\":true,\"isBuyer\":true,\"isMaker\":true,\"orderId\":28,\"price\":\"0.02000000\",\"qty\":\"1.02000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":false,\"time\":1507725176595}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/myTrades", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginAccountsTradeList("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMaxBorrow
        [Fact]
        public async void QueryMaxBorrow_Response()
        {
            var responseContent = "{\"amount\":\"1.69248805\",\"borrowLimit\":\"60\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/maxBorrowable", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMaxBorrow("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMaxTransferoutAmount
        [Fact]
        public async void QueryMaxTransferoutAmount_Response()
        {
            var responseContent = "{\"amount\":\"\",\"borrowLimit\":\"\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/maxTransferable", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMaxTransferoutAmount("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region IsolatedMarginAccountTransfer
        [Fact]
        public async void IsolatedMarginAccountTransfer_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/transfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.IsolatedMarginAccountTransfer("BTC", "BNBUSDT", IsolatedMarginAccountTransferType.SPOT, IsolatedMarginAccountTransferType.ISOLATED_MARGIN, 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetIsolatedMarginTransferHistory
        [Fact]
        public async void GetIsolatedMarginTransferHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"amount\":\"0.10000000\",\"asset\":\"BNB\",\"status\":\"CONFIRMED\",\"timestamp\":1566898617000,\"txId\":5240372201,\"transFrom\":\"SPOT\",\"transTo\":\"ISOLATED_MARGIN\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/transfer", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetIsolatedMarginTransferHistory("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryIsolatedMarginAccountInfo
        [Fact]
        public async void QueryIsolatedMarginAccountInfo_Response()
        {
            var responseContent = "{\"assets\":[{\"baseAsset\":{\"asset\":\"BTC\",\"borrowEnabled\":true,\"borrowed\":\"0.00000000\",\"free\":\"0.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00000000\",\"netAssetOfBtc\":\"0.00000000\",\"repayEnabled\":true,\"totalAsset\":\"0.00000000\"},\"quoteAsset\":{\"asset\":\"USDT\",\"borrowEnabled\":true,\"borrowed\":\"0.00000000\",\"free\":\"0.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00000000\",\"netAssetOfBtc\":\"0.00000000\",\"repayEnabled\":true,\"totalAsset\":\"0.00000000\"},\"symbol\":\"BTCUSDT\",\"isolatedCreated\":true,\"enabled\":true,\"marginLevel\":\"0.00000000\",\"marginLevelStatus\":\"EXCESSIVE\",\"marginRatio\":\"0.00000000\",\"indexPrice\":\"10000.00000000\",\"liquidatePrice\":\"1000.00000000\",\"liquidateRate\":\"1.00000000\",\"tradeEnabled\":true}],\"totalAssetOfBtc\":\"0.00000000\",\"totalLiabilityOfBtc\":\"0.00000000\",\"totalNetAssetOfBtc\":\"0.00000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/account", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryIsolatedMarginAccountInfo();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DisableIsolatedMarginAccount
        [Fact]
        public async void DisableIsolatedMarginAccount_Response()
        {
            var responseContent = "{\"success\":true,\"symbol\":\"BTCUSDT\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/account", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.DisableIsolatedMarginAccount("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region EnableIsolatedMarginAccount
        [Fact]
        public async void EnableIsolatedMarginAccount_Response()
        {
            var responseContent = "{\"success\":true,\"symbol\":\"BTCUSDT\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/account", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.EnableIsolatedMarginAccount("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryEnabledIsolatedMarginAccountLimit
        [Fact]
        public async void QueryEnabledIsolatedMarginAccountLimit_Response()
        {
            var responseContent = "{\"enabledAccount\":5,\"maxAccount\":20}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/accountLimit", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryEnabledIsolatedMarginAccountLimit();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryIsolatedMarginSymbol
        [Fact]
        public async void QueryIsolatedMarginSymbol_Response()
        {
            var responseContent = "{\"symbol\":\"BTCUSDT\",\"base\":\"BTC\",\"quote\":\"USDT\",\"isMarginTrade\":true,\"isBuyAllowed\":true,\"isSellAllowed\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/pair", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryIsolatedMarginSymbol("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetAllIsolatedMarginSymbol
        [Fact]
        public async void GetAllIsolatedMarginSymbol_Response()
        {
            var responseContent = "[{\"symbol\":\"BTCUSDT\",\"base\":\"BTC\",\"quote\":\"USDT\",\"isMarginTrade\":true,\"isBuyAllowed\":true,\"isSellAllowed\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolated/allPairs", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetAllIsolatedMarginSymbol();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region ToggleBnbBurnOnSpotTradeAndMarginInterest
        [Fact]
        public async void ToggleBnbBurnOnSpotTradeAndMarginInterest_Response()
        {
            var responseContent = "{\"spotBNBBurn\":true,\"interestBNBBurn\":false}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bnbBurn", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.ToggleBnbBurnOnSpotTradeAndMarginInterest();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetBnbBurnStatus
        [Fact]
        public async void GetBnbBurnStatus_Response()
        {
            var responseContent = "{\"spotBNBBurn\":true,\"interestBNBBurn\":false}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bnbBurn", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.GetBnbBurnStatus();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginInterestRateHistory
        [Fact]
        public async void QueryMarginInterestRateHistory_Response()
        {
            var responseContent = "[{\"asset\":\"BTC\",\"dailyInterestRate\":\"0.00025000\",\"timestamp\":1611544731000,\"vipLevel\":1}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/interestRateHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryMarginInterestRateHistory("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryCrossMarginFeeData
        [Fact]
        public async void QueryCrossMarginFeeData_Response()
        {
            var responseContent = "[{\"vipLevel\":0,\"coin\":\"BTC\",\"transferIn\":true,\"borrowable\":true,\"dailyInterest\":\"0.00026125\",\"yearlyInterest\":\"0.0953\",\"borrowLimit\":\"180\",\"marginablePairs\":[\"\"]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/crossMarginData", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryCrossMarginFeeData();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryIsolatedMarginFeeData
        [Fact]
        public async void QueryIsolatedMarginFeeData_Response()
        {
            var responseContent = "[{\"vipLevel\":0,\"symbol\":\"BTCUSDT\",\"leverage\":\"10\",\"data\":[{\"coin\":\"\",\"dailyInterest\":\"\",\"borrowLimit\":\"\"}]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolatedMarginData", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryIsolatedMarginFeeData();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryIsolatedMarginTierData
        [Fact]
        public async void QueryIsolatedMarginTierData_Response()
        {
            var responseContent = "[{\"symbol\":\"BTCUSDT\",\"tier\":1,\"effectiveMultiple\":\"10\",\"initialRiskRatio\":\"1.111\",\"liquidationRiskRatio\":\"1.05\",\"baseAssetMaxBorrowable\":\"9\",\"quoteAssetMaxBorrowable\":\"70000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/isolatedMarginTier", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryIsolatedMarginTierData("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryCurrentMarginOrderCountUsage
        [Fact]
        public async void QueryCurrentMarginOrderCountUsage_Response()
        {
            var responseContent = "[{\"rateLimitType\":\"ORDERS\",\"interval\":\"SECOND\",\"intervalNum\":10,\"limit\":10000,\"count\":0},{\"rateLimitType\":\"ORDERS\",\"interval\":\"DAY\",\"intervalNum\":1,\"limit\":20000,\"count\":0}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/margin/rateLimit/order", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            MarginAccountTrade marginAccountTrade = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await marginAccountTrade.QueryCurrentMarginOrderCountUsage();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}