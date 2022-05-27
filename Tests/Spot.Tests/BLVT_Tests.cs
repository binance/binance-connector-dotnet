namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class BLVT_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetBlvtInfo
        [Fact]
        public async void GetBlvtInfo_Response()
        {
            var responseContent = "[{\"tokenName\":\"BTCDOWN\",\"description\":\"3X Short Bitcoin Token\",\"underlying\":\"BTC\",\"tokenIssued\":\"717953.95\",\"basket\":\"-821.474 BTCUSDT Futures\",\"currentBaskets\":[{\"symbol\":\"BTCUSDT\",\"amount\":\"-1183.984\",\"notionalValue\":\"-22871089.96704\"}],\"nav\":\"4.79\",\"realLeverage\":\"-2.316\",\"fundingRate\":\"0.001020\",\"dailyManagementFee\":\"0.0001\",\"purchaseFeePct\":\"0.0010\",\"dailyPurchaseLimit\":\"100000.00\",\"redeemFeePct\":\"0.0010\",\"dailyRedeemLimit\":\"1000000.00\",\"timestamp\":1583127900000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/blvt/tokenInfo", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BLVT blvt = new BLVT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await blvt.GetBlvtInfo();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region SubscribeBlvt
        [Fact]
        public async void SubscribeBlvt_Response()
        {
            var responseContent = "{\"id\":123,\"status\":\"S\",\"tokenName\":\"LINKUP\",\"amount\":\"0.9559090500\",\"cost\":\"9.99999995\",\"timestamp\":1600249972899}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/blvt/subscribe", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BLVT blvt = new BLVT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await blvt.SubscribeBlvt("BTCDOWN", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QuerySubscriptionRecord
        [Fact]
        public async void QuerySubscriptionRecord_Response()
        {
            var responseContent = "{\"id\":1,\"tokenName\":\"LINKUP\",\"amount\":\"0.54216292\",\"nav\":\"18.42621386\",\"fee\":\"0.00999000\",\"totalCharge\":\"9.99999991\",\"timestamp\":1599127217916}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/blvt/subscribe/record", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BLVT blvt = new BLVT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await blvt.QuerySubscriptionRecord();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RedeemBlvt
        [Fact]
        public async void RedeemBlvt_Response()
        {
            var responseContent = "{\"id\":123,\"status\":\"S\",\"tokenName\":\"LINKUP\",\"redeemAmount\":\"0.95590905\",\"amount\":\"10.05022099\",\"timestamp\":1600250279614}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/blvt/redeem", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BLVT blvt = new BLVT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await blvt.RedeemBlvt("BTCDOWN", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryRedemptionRecord
        [Fact]
        public async void QueryRedemptionRecord_Response()
        {
            var responseContent = "[{\"id\":1,\"tokenName\":\"LINKUP\",\"amount\":\"0.54216292\",\"nav\":\"18.36345064\",\"fee\":\"0.00995598\",\"netProceed\":\"9.94602604\",\"timestamp\":1599128003050}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/blvt/redeem/record", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BLVT blvt = new BLVT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await blvt.QueryRedemptionRecord();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetBlvtUserLimitInfo
        [Fact]
        public async void GetBlvtUserLimitInfo_Response()
        {
            var responseContent = "[{\"tokenName\":\"LINKUP\",\"userDailyTotalPurchaseLimit\":\"1000\",\"userDailyTotalRedeemLimit\":\"1000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/blvt/userLimit", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BLVT blvt = new BLVT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await blvt.GetBlvtUserLimitInfo();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}