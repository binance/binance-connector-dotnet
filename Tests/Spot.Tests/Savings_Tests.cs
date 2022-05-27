namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Savings_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetFlexibleProductList
        [Fact]
        public async void GetFlexibleProductList_Response()
        {
            var responseContent = "[{\"asset\":\"BTC\",\"avgAnnualInterestRate\":\"0.00250025\",\"canPurchase\":true,\"canRedeem\":true,\"dailyInterestPerThousand\":\"0.00685000\",\"featured\":true,\"minPurchaseAmount\":\"0.01000000\",\"productId\":\"BTC001\",\"purchasedAmount\":\"16.32467016\",\"status\":\"PURCHASING\",\"upLimit\":\"200.00000000\",\"upLimitPerUser\":\"5.00000000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/product/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetFlexibleProductList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetLeftDailyPurchaseQuotaOfFlexibleProduct
        [Fact]
        public async void GetLeftDailyPurchaseQuotaOfFlexibleProduct_Response()
        {
            var responseContent = "{\"asset\":\"BUSD\",\"leftQuota\":\"50000.00000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/userLeftQuota", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetLeftDailyPurchaseQuotaOfFlexibleProduct("1234");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region PurchaseFlexibleProduct
        [Fact]
        public async void PurchaseFlexibleProduct_Response()
        {
            var responseContent = "{\"purchaseId\":40607}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/purchase", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.PurchaseFlexibleProduct("1234", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetLeftDailyRedemptionQuotaOfFlexibleProduct
        [Fact]
        public async void GetLeftDailyRedemptionQuotaOfFlexibleProduct_Response()
        {
            var responseContent = "{\"asset\":\"USDT\",\"dailyQuota\":\"10000000.00000000\",\"leftQuota\":\"0.00000000\",\"minRedemptionAmount\":\"0.10000000\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/userRedemptionQuota", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetLeftDailyRedemptionQuotaOfFlexibleProduct("1234", RedemptionType.FAST);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RedeemFlexibleProduct
        [Fact]
        public async void RedeemFlexibleProduct_Response()
        {
            var responseContent = "{}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/redeem", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.RedeemFlexibleProduct("1234", 1.01m, RedemptionType.FAST);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetFlexibleProductPosition
        [Fact]
        public async void GetFlexibleProductPosition_Response()
        {
            var responseContent = "[{\"annualInterestRate\":\"0.02600000\",\"asset\":\"USDT\",\"avgAnnualInterestRate\":\"0.02599895\",\"canRedeem\":true,\"dailyInterestRate\":\"0.00007123\",\"freeAmount\":\"75.46000000\",\"freezeAmount\":\"0.00000000\",\"lockedAmount\":\"0.00000000\",\"productId\":\"USDT001\",\"productName\":\"USDT\",\"redeemingAmount\":\"0.00000000\",\"todayPurchasedAmount\":\"0.00000000\",\"totalAmount\":\"75.46000000\",\"totalInterest\":\"0.22759183\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/daily/token/position", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetFlexibleProductPosition("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetFixedAndActivityProjectList
        [Fact]
        public async void GetFixedAndActivityProjectList_Response()
        {
            var responseContent = "[{\"asset\":\"USDT\",\"displayPriority\":1,\"duration\":90,\"interestPerLot\":\"1.35810000\",\"interestRate\":\"0.05510000\",\"lotSize\":\"100.00000000\",\"lotsLowLimit\":1,\"lotsPurchased\":74155,\"lotsUpLimit\":80000,\"maxLotsPerUser\":2000,\"needKyc\":true,\"projectId\":\"CUSDT90DAYSS001\",\"projectName\":\"USDT\",\"status\":\"PURCHASING\",\"type\":\"CUSTOMIZED_FIXED\",\"withAreaLimitation\":true}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/project/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetFixedAndActivityProjectList(FixedAndActivityProjectType.ACTIVITY);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region PurchaseFixedActivityProject
        [Fact]
        public async void PurchaseFixedActivityProject_Response()
        {
            var responseContent = "{\"purchaseId\":\"18356\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/customizedFixed/purchase", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.PurchaseFixedActivityProject("1234", 1);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetFixedActivityProjectPosition
        [Fact]
        public async void GetFixedActivityProjectPosition_Response()
        {
            var responseContent = "[{\"asset\":\"USDT\",\"canTransfer\":true,\"createTimestamp\":1587010770000,\"duration\":14,\"endTime\":1588291200000,\"interest\":\"0.19950000\",\"interestRate\":\"0.05201250\",\"lot\":1,\"positionId\":51724,\"principal\":\"100.00000000\",\"projectId\":\"CUSDT14DAYSS001\",\"projectName\":\"USDT\",\"purchaseTime\":1587010771000,\"redeemDate\":\"2020-05-01\",\"startTime\":1587081600000,\"status\":\"HOLDING\",\"type\":\"CUSTOMIZED_FIXED\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/project/position/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetFixedActivityProjectPosition("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region LendingAccount
        [Fact]
        public async void LendingAccount_Response()
        {
            var responseContent = "{\"positionAmountVos\":[{\"amount\":\"75.46000000\",\"amountInBTC\":\"0.01044819\",\"amountInUSDT\":\"75.46000000\",\"asset\":\"USDT\"}],\"totalAmountInBTC\":\"0.01067982\",\"totalAmountInUSDT\":\"77.13289230\",\"totalFixedAmountInBTC\":\"0.00000000\",\"totalFixedAmountInUSDT\":\"0.00000000\",\"totalFlexibleInBTC\":\"0.01067982\",\"totalFlexibleInUSDT\":\"77.13289230\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/account", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.LendingAccount();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetPurchaseRecord
        [Fact]
        public async void GetPurchaseRecord_Response()
        {
            var responseContent = "[{\"amount\":\"100.00000000\",\"asset\":\"USDT\",\"createTime\":1575018510000,\"lendingType\":\"DAILY\",\"productName\":\"USDT\",\"purchaseId\":26055,\"status\":\"SUCCESS\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/purchaseRecord", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetPurchaseRecord(LendingType.DAILY);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetRedemptionRecord
        [Fact]
        public async void GetRedemptionRecord_Response()
        {
            var responseContent = "[{\"amount\":\"10.54000000\",\"asset\":\"USDT\",\"createTime\":1577257222000,\"principal\":\"10.54000000\",\"projectId\":\"USDT001\",\"projectName\":\"USDT\",\"status\":\"PAID\",\"type\":\"FAST\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/redemptionRecord", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetRedemptionRecord(LendingType.DAILY);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetInterestHistory
        [Fact]
        public async void GetInterestHistory_Response()
        {
            var responseContent = "[{\"asset\":\"BUSD\",\"interest\":\"0.00006408\",\"lendingType\":\"DAILY\",\"productName\":\"BUSD\",\"time\":1577233578000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/union/interestHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.GetInterestHistory(LendingType.DAILY);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region ChangeFixedActivityPositionToDailyPosition
        [Fact]
        public async void ChangeFixedActivityPositionToDailyPosition_Response()
        {
            var responseContent = "{\"dailyPurchaseId\":862290,\"success\":true,\"time\":1577233578000}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/lending/positionChanged", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Savings savings = new Savings(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await savings.ChangeFixedActivityPositionToDailyPosition("1234", 1);

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}