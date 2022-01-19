namespace Binance.Spot.Tests
{
    using System;
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
            var responseContent = "{\"tranId\":100000001}";
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

            var result = await marginAccountTrade.CrossMarginAccountTransfer("BTC", 1.2765m, MarginTransferType.SPOT_TO_MARGIN);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountBorrow
        [Fact]
        public async void MarginAccountBorrow_Response()
        {
            var responseContent = "{\"tranId\":100000001}";
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

            var result = await marginAccountTrade.MarginAccountBorrow("BTC", 1.3786m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountRepay
        [Fact]
        public async void MarginAccountRepay_Response()
        {
            var responseContent = "{\"tranId\":100000001}";
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

            var result = await marginAccountTrade.MarginAccountRepay("BTC", 1.3765m);

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

            var result = await marginAccountTrade.QueryMarginAsset("BNB");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryCrossMarginPair
        [Fact]
        public async void QueryCrossMarginPair_Response()
        {
            var responseContent = "{\"id\":323355778339572400,\"symbol\":\"BTCUSDT\",\"base\":\"BTC\",\"quote\":\"USDT\",\"isMarginTrade\":true,\"isBuyAllowed\":true,\"isSellAllowed\":true}";
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

            var result = await marginAccountTrade.QueryCrossMarginPair("BTCUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetAllMarginAssets
        [Fact]
        public async void GetAllMarginAssets_Response()
        {
            var responseContent = "[{\"assetFullName\":\"USD coin\",\"assetName\":\"USDC\",\"isBorrowable\":true,\"isMortgageable\":true,\"userMinBorrow\":\"0.00000000\",\"userMinRepay\":\"0.00000000\"},{\"assetFullName\":\"BNB-coin\",\"assetName\":\"BNB\",\"isBorrowable\":true,\"isMortgageable\":true,\"userMinBorrow\":\"1.00000000\",\"userMinRepay\":\"0.00000000\"},{\"assetFullName\":\"Tether\",\"assetName\":\"USDT\",\"isBorrowable\":true,\"isMortgageable\":true,\"userMinBorrow\":\"1.00000000\",\"userMinRepay\":\"0.00000000\"},{\"assetFullName\":\"etherum\",\"assetName\":\"ETH\",\"isBorrowable\":true,\"isMortgageable\":true,\"userMinBorrow\":\"0.00000000\",\"userMinRepay\":\"0.00000000\"},{\"assetFullName\":\"Bitcoin\",\"assetName\":\"BTC\",\"isBorrowable\":true,\"isMortgageable\":true,\"userMinBorrow\":\"0.00000000\",\"userMinRepay\":\"0.00000000\"}]";
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
            var responseContent = "[{\"base\":\"BNB\",\"id\":351637150141315861,\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"BTC\",\"symbol\":\"BNBBTC\"},{\"base\":\"TRX\",\"id\":351637923235429141,\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"BTC\",\"symbol\":\"TRXBTC\"},{\"base\":\"XRP\",\"id\":351638112213990165,\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"BTC\",\"symbol\":\"XRPBTC\"},{\"base\":\"ETH\",\"id\":351638524530850581,\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"BTC\",\"symbol\":\"ETHBTC\"},{\"base\":\"BNB\",\"id\":376870400832855109,\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"USDT\",\"symbol\":\"BNBUSDT\"}]";
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

            var result = await marginAccountTrade.QueryMarginPriceindex("BNBBTC");

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

            var result = await marginAccountTrade.MarginAccountNewOrder("BTCUSDT", Side.SELL, OrderType.MARKET);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountCancelOrder
        [Fact]
        public async void MarginAccountCancelOrder_Response()
        {
            var responseContent = "{\"symbol\":\"LTCBTC\",\"isIsolated\":true,\"orderId\":28,\"origClientOrderId\":\"myOrder1\",\"clientOrderId\":\"cancelMyOrder1\",\"price\":\"1.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"8.00000000\",\"cummulativeQuoteQty\":\"8.00000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"SELL\"}";
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

            var result = await marginAccountTrade.MarginAccountCancelOrder("LTCBTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountCancelAllOpenOrdersOnASymbol
        [Fact]
        public async void MarginAccountCancelAllOpenOrdersOnASymbol_Response()
        {
            var responseContent = "[{\"symbol\":\"BTCUSDT\",\"isIsolated\":true,\"origClientOrderId\":\"E6APeyTJvkMvLMYMqu1KQ4\",\"orderId\":11,\"orderListId\":-1,\"clientOrderId\":\"pXLV6Hz6mprAcVYpVMTGgx\",\"price\":\"0.089853\",\"origQty\":\"0.178622\",\"executedQty\":\"0.000000\",\"cummulativeQuoteQty\":\"0.000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"BUY\"},{\"symbol\":\"BTCUSDT\",\"isIsolated\":false,\"origClientOrderId\":\"A3EF2HCwxgZPFMrfwbgrhv\",\"orderId\":13,\"orderListId\":-1,\"clientOrderId\":\"pXLV6Hz6mprAcVYpVMTGgx\",\"price\":\"0.090430\",\"origQty\":\"0.178622\",\"executedQty\":\"0.000000\",\"cummulativeQuoteQty\":\"0.000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"side\":\"BUY\"},{\"orderListId\":1929,\"contingencyType\":\"OCO\",\"listStatusType\":\"ALL_DONE\",\"listOrderStatus\":\"ALL_DONE\",\"listClientOrderId\":\"2inzWQdDvZLHbbAmAozX2N\",\"transactionTime\":1585230948299,\"symbol\":\"BTCUSDT\",\"isIsolated\":true,\"orders\":[{\"symbol\":\"BTCUSDT\",\"orderId\":20,\"clientOrderId\":\"CwOOIPHSmYywx6jZX77TdL\"},{\"symbol\":\"BTCUSDT\",\"orderId\":21,\"clientOrderId\":\"461cPg51vQjV3zIMOXNz39\"}],\"orderReports\":[{\"symbol\":\"BTCUSDT\",\"origClientOrderId\":\"CwOOIPHSmYywx6jZX77TdL\",\"orderId\":20,\"orderListId\":1929,\"clientOrderId\":\"pXLV6Hz6mprAcVYpVMTGgx\",\"price\":\"0.668611\",\"origQty\":\"0.690354\",\"executedQty\":\"0.000000\",\"cummulativeQuoteQty\":\"0.000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"STOP_LOSS_LIMIT\",\"side\":\"BUY\",\"stopPrice\":\"0.378131\",\"icebergQty\":\"0.017083\"},{\"symbol\":\"BTCUSDT\",\"origClientOrderId\":\"461cPg51vQjV3zIMOXNz39\",\"orderId\":21,\"orderListId\":1929,\"clientOrderId\":\"pXLV6Hz6mprAcVYpVMTGgx\",\"price\":\"0.008791\",\"origQty\":\"0.690354\",\"executedQty\":\"0.000000\",\"cummulativeQuoteQty\":\"0.000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT_MAKER\",\"side\":\"BUY\",\"icebergQty\":\"0.639962\"}]}]";
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

            var result = await marginAccountTrade.MarginAccountCancelAllOpenOrdersOnASymbol("BTCUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetCrossMarginTransferHistory
        [Fact]
        public async void GetCrossMarginTransferHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"amount\":\"0.10000000\",\"asset\":\"BNB\",\"status\":\"CONFIRMED\",\"timestamp\":1566898617,\"txId\":5240372201,\"type\":\"ROLL_IN\"},{\"amount\":\"5.00000000\",\"asset\":\"USDT\",\"status\":\"CONFIRMED\",\"timestamp\":1566888436,\"txId\":5239810406,\"type\":\"ROLL_OUT\"},{\"amount\":\"1.00000000\",\"asset\":\"EOS\",\"status\":\"CONFIRMED\",\"timestamp\":1566888403,\"txId\":5239808703,\"type\":\"ROLL_IN\"}],\"total\":3}";
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
            var responseContent = "{\"rows\":[{\"isolatedSymbol\":\"BNBUSDT\",\"txId\":12807067523,\"asset\":\"BNB\",\"principal\":\"0.84624403\",\"timestamp\":1555056425000,\"status\":\"CONFIRMED\"}],\"total\":1}";
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

            var result = await marginAccountTrade.QueryLoanRecord("BNB");

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

            var result = await marginAccountTrade.QueryRepayRecord("BNB");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetInterestHistory
        [Fact]
        public async void GetInterestHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"isolatedSymbol\":\"BNBUSDT\",\"asset\":\"BNB\",\"interest\":\"0.02414667\",\"interestAccuredTime\":1566813600000,\"interestRate\":\"0.01600000\",\"principal\":\"36.22000000\",\"type\":\"ON_BORROW\"}],\"total\":1}";
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
            var responseContent = "{\"rows\":[{\"avgPrice\":\"0.00388359\",\"executedQty\":\"31.39000000\",\"orderId\":180015097,\"price\":\"0.00388110\",\"qty\":\"31.39000000\",\"side\":\"SELL\",\"symbol\":\"BNBBTC\",\"timeInForce\":\"GTC\",\"isIsolated\":true,\"updatedTime\":1558941374745}],\"total\":1}";
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
            var responseContent = "{\"borrowEnabled\":true,\"marginLevel\":\"11.64405625\",\"totalAssetOfBtc\":\"6.82728457\",\"totalLiabilityOfBtc\":\"0.58633215\",\"totalNetAssetOfBtc\":\"6.24095242\",\"tradeEnabled\":true,\"transferEnabled\":true,\"userAssets\":[{\"asset\":\"BTC\",\"borrowed\":\"0.00000000\",\"free\":\"0.00499500\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00499500\"},{\"asset\":\"BNB\",\"borrowed\":\"201.66666672\",\"free\":\"2346.50000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"2144.83333328\"},{\"asset\":\"ETH\",\"borrowed\":\"0.00000000\",\"free\":\"0.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00000000\"},{\"asset\":\"USDT\",\"borrowed\":\"0.00000000\",\"free\":\"0.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00000000\"}]}";
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

            var result = await marginAccountTrade.QueryMarginAccountsOrder("BNBBTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsOpenOrders
        [Fact]
        public async void QueryMarginAccountsOpenOrders_Response()
        {
            var responseContent = "[{\"clientOrderId\":\"qhcZw71gAkCCTv0t0k8LUK\",\"cummulativeQuoteQty\":\"0.00000000\",\"executedQty\":\"0.00000000\",\"icebergQty\":\"0.00000000\",\"isWorking\":true,\"orderId\":211842552,\"origQty\":\"0.30000000\",\"price\":\"0.00475010\",\"side\":\"SELL\",\"status\":\"NEW\",\"stopPrice\":\"0.00000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":true,\"time\":1562040170089,\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"updateTime\":1562040170089}]";
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
            var responseContent = "[{\"clientOrderId\":\"D2KDy4DIeS56PvkM13f8cP\",\"cummulativeQuoteQty\":\"0.00000000\",\"executedQty\":\"0.00000000\",\"icebergQty\":\"0.00000000\",\"isWorking\":false,\"orderId\":41295,\"origQty\":\"5.31000000\",\"price\":\"0.22500000\",\"side\":\"SELL\",\"status\":\"CANCELED\",\"stopPrice\":\"0.18000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":false,\"time\":1565769338806,\"timeInForce\":\"GTC\",\"type\":\"TAKE_PROFIT_LIMIT\",\"updateTime\":1565769342148},{\"clientOrderId\":\"gXYtqhcEAs2Rn9SUD9nRKx\",\"cummulativeQuoteQty\":\"0.00000000\",\"executedQty\":\"0.00000000\",\"icebergQty\":\"1.00000000\",\"isWorking\":true,\"orderId\":41296,\"origQty\":\"6.65000000\",\"price\":\"0.18000000\",\"side\":\"SELL\",\"status\":\"CANCELED\",\"stopPrice\":\"0.00000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":false,\"time\":1565769348687,\"timeInForce\":\"GTC\",\"type\":\"LIMIT\",\"updateTime\":1565769352226},{\"clientOrderId\":\"duDq1BqohhcMmdMs9FSuDy\",\"cummulativeQuoteQty\":\"0.39450000\",\"executedQty\":\"2.63000000\",\"icebergQty\":\"0.00000000\",\"isWorking\":true,\"orderId\":41297,\"origQty\":\"2.63000000\",\"price\":\"0.00000000\",\"side\":\"SELL\",\"status\":\"FILLED\",\"stopPrice\":\"0.00000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":false,\"time\":1565769358139,\"timeInForce\":\"GTC\",\"type\":\"MARKET\",\"updateTime\":1565769358139}]";
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

            var result = await marginAccountTrade.QueryMarginAccountsAllOrders("BNBBTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountNewOco
        [Fact]
        public async void MarginAccountNewOco_Response()
        {
            var responseContent = "{\"orderListId\":0,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"JYVpp3F0f5CAG15DhtrqLp\",\"transactionTime\":1563417480525,\"symbol\":\"LTCBTC\",\"marginBuyBorrowAmount\":\"5\",\"marginBuyBorrowAsset\":\"BTC\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"LTCBTC\",\"orderId\":2,\"clientOrderId\":\"Kk7sqHb9J6mJWTMDVW7Vos\"},{\"symbol\":\"LTCBTC\",\"orderId\":3,\"clientOrderId\":\"xTXKaGYd4bluPVp78IVRvl\"}],\"orderReports\":[{\"symbol\":\"LTCBTC\",\"orderId\":2,\"orderListId\":0,\"clientOrderId\":\"Kk7sqHb9J6mJWTMDVW7Vos\",\"transactTime\":1563417480525,\"price\":\"0.000000\",\"origQty\":\"0.624363\",\"executedQty\":\"0.000000\",\"cummulativeQuoteQty\":\"0.000000\",\"status\":\"NEW\",\"timeInForce\":\"GTC\",\"type\":\"STOP_LOSS\",\"side\":\"BUY\",\"stopPrice\":\"0.960664\"},{\"symbol\":\"LTCBTC\",\"orderId\":3,\"orderListId\":0,\"clientOrderId\":\"xTXKaGYd4bluPVp78IVRvl\",\"transactTime\":1563417480525,\"price\":\"0.036435\",\"origQty\":\"0.624363\",\"executedQty\":\"0.000000\",\"cummulativeQuoteQty\":\"0.000000\",\"status\":\"NEW\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT_MAKER\",\"side\":\"BUY\"}]}";
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

            var result = await marginAccountTrade.MarginAccountNewOco("LTCBTC", Side.BUY, 0.624363m, 522.23m, 515.38276m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginAccountCancelOco
        [Fact]
        public async void MarginAccountCancelOco_Response()
        {
            var responseContent = "{\"orderListId\":0,\"contingencyType\":\"OCO\",\"listStatusType\":\"ALL_DONE\",\"listOrderStatus\":\"ALL_DONE\",\"listClientOrderId\":\"C3wyj4WVEktd7u9aVBRXcN\",\"transactionTime\":1574040868128,\"symbol\":\"LTCBTC\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"LTCBTC\",\"orderId\":2,\"clientOrderId\":\"pO9ufTiFGg3nw2fOdgeOXa\"},{\"symbol\":\"LTCBTC\",\"orderId\":3,\"clientOrderId\":\"TXOvglzXuaubXAaENpaRCB\"}],\"orderReports\":[{\"symbol\":\"LTCBTC\",\"origClientOrderId\":\"pO9ufTiFGg3nw2fOdgeOXa\",\"orderId\":2,\"orderListId\":0,\"clientOrderId\":\"unfWT8ig8i0uj6lPuYLez6\",\"price\":\"1.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"0.00000000\",\"cummulativeQuoteQty\":\"0.00000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"STOP_LOSS_LIMIT\",\"side\":\"SELL\",\"stopPrice\":\"1.00000000\"},{\"symbol\":\"LTCBTC\",\"origClientOrderId\":\"TXOvglzXuaubXAaENpaRCB\",\"orderId\":3,\"orderListId\":0,\"clientOrderId\":\"unfWT8ig8i0uj6lPuYLez6\",\"price\":\"3.00000000\",\"origQty\":\"10.00000000\",\"executedQty\":\"0.00000000\",\"cummulativeQuoteQty\":\"0.00000000\",\"status\":\"CANCELED\",\"timeInForce\":\"GTC\",\"type\":\"LIMIT_MAKER\",\"side\":\"SELL\"}]}";
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

            var result = await marginAccountTrade.MarginAccountCancelOco("LTCBTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryMarginAccountsOco
        [Fact]
        public async void QueryMarginAccountsOco_Response()
        {
            var responseContent = "{\"orderListId\":27,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"h2USkA5YQpaXHPIrkd96xE\",\"transactionTime\":1565245656253,\"symbol\":\"LTCBTC\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"LTCBTC\",\"orderId\":4,\"clientOrderId\":\"qD1gy3kc3Gx0rihm9Y3xwS\"},{\"symbol\":\"LTCBTC\",\"orderId\":5,\"clientOrderId\":\"ARzZ9I00CPM8i3NhmU9Ega\"}]}";
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
            var responseContent = "[{\"orderListId\":29,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"amEEAXryFzFwYF1FeRpUoZ\",\"transactionTime\":1565245913483,\"symbol\":\"LTCBTC\",\"isIsolated\":true,\"orders\":[{\"symbol\":\"LTCBTC\",\"orderId\":4,\"clientOrderId\":\"oD7aesZqjEGlZrbtRpy5zB\"},{\"symbol\":\"LTCBTC\",\"orderId\":5,\"clientOrderId\":\"Jr1h6xirOxgeJOUuYQS7V3\"}]},{\"orderListId\":28,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"hG7hFNxJV6cZy3Ze4AUT4d\",\"transactionTime\":1565245913407,\"symbol\":\"LTCBTC\",\"orders\":[{\"symbol\":\"LTCBTC\",\"orderId\":2,\"clientOrderId\":\"j6lFOfbmFMRjTYA7rRJ0LP\"},{\"symbol\":\"LTCBTC\",\"orderId\":3,\"clientOrderId\":\"z0KCjOdditiLS5ekAFtK81\"}]}]";
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
            var responseContent = "[{\"orderListId\":31,\"contingencyType\":\"OCO\",\"listStatusType\":\"EXEC_STARTED\",\"listOrderStatus\":\"EXECUTING\",\"listClientOrderId\":\"wuB13fmulKj3YjdqWEcsnp\",\"transactionTime\":1565246080644,\"symbol\":\"LTCBTC\",\"isIsolated\":false,\"orders\":[{\"symbol\":\"LTCBTC\",\"orderId\":4,\"clientOrderId\":\"r3EH2N76dHfLoSZWIUw1bT\"},{\"symbol\":\"LTCBTC\",\"orderId\":5,\"clientOrderId\":\"Cv1SnyPD3qhqpbjpYEHbd2\"}]}]";
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
            var responseContent = "[{\"commission\":\"0.00006000\",\"commissionAsset\":\"BTC\",\"id\":34,\"isBestMatch\":true,\"isBuyer\":false,\"isMaker\":false,\"orderId\":39324,\"price\":\"0.02000000\",\"qty\":\"3.00000000\",\"symbol\":\"BNBBTC\",\"isIsolated\":false,\"time\":1561973357171}]";
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

            var result = await marginAccountTrade.QueryMarginAccountsTradeList("BNBBTC");

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
            var responseContent = "{\"amount\":\"3.59498107\"}";
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
            var responseContent = "{\"tranId\":100000001}";
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

            var result = await marginAccountTrade.IsolatedMarginAccountTransfer("BTC", "BTCUSDT", IsolatedMarginAccountTransferType.SPOT, IsolatedMarginAccountTransferType.ISOLATED_MARGIN, 0.23715m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetIsolatedMarginTransferHistory
        [Fact]
        public async void GetIsolatedMarginTransferHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"amount\":\"0.10000000\",\"asset\":\"BNB\",\"status\":\"CONFIRMED\",\"timestamp\":1566898617000,\"txId\":5240372201,\"transFrom\":\"SPOT\",\"transTo\":\"ISOLATED_MARGIN\"},{\"amount\":\"5.00000000\",\"asset\":\"USDT\",\"status\":\"CONFIRMED\",\"timestamp\":1566888436123,\"txId\":5239810406,\"transFrom\":\"ISOLATED_MARGIN\",\"transTo\":\"SPOT\"}],\"total\":2}";
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

            var result = await marginAccountTrade.DisableIsolatedMarginAccount("BTCUSDT");

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

            var result = await marginAccountTrade.EnableIsolatedMarginAccount("BTCUSDT");

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

            var result = await marginAccountTrade.QueryIsolatedMarginSymbol("BTCUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetAllIsolatedMarginSymbol
        [Fact]
        public async void GetAllIsolatedMarginSymbol_Response()
        {
            var responseContent = "[{\"base\":\"BNB\",\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"BTC\",\"symbol\":\"BNBBTC\"},{\"base\":\"TRX\",\"isBuyAllowed\":true,\"isMarginTrade\":true,\"isSellAllowed\":true,\"quote\":\"BTC\",\"symbol\":\"TRXBTC\"}]";
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
            var responseContent = "[{\"asset\":\"BTC\",\"dailyInterestRate\":\"0.00025000\",\"timestamp\":1611544731000,\"vipLevel\":1},{\"asset\":\"BTC\",\"dailyInterestRate\":\"0.00035000\",\"timestamp\":1610248118000,\"vipLevel\":1}]";
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
            MarginAccountTrade margin = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await margin.QueryCrossMarginFeeData();

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
            MarginAccountTrade margin = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await margin.QueryIsolatedMarginFeeData();

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
            MarginAccountTrade margin = new MarginAccountTrade(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await margin.QueryIsolatedMarginTierData("BNBUSDT");

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}