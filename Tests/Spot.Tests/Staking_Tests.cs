namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Staking_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetStakingProductList
        [Fact]
        public async void GetStakingProductList_Response()
        {
            var responseContent = "[{\"projectId\":\"Axs*90\",\"detail\":{\"asset\":\"AXS\",\"rewardAsset\":\"AXS\",\"duration\":90,\"renewable\":true,\"apy\":\"1.2069\"},\"quota\":{\"totalPersonalQuota\":\"2\",\"minimum\":\"0.001\"}},{\"projectId\":\"Fio*90\",\"detail\":{\"asset\":\"FIO\",\"rewardAsset\":\"FIO\",\"duration\":90,\"renewable\":true,\"apy\":\"1.0769\"},\"quota\":{\"totalPersonalQuota\":\"600\",\"minimum\":\"0.1\"}}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/staking/productList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Staking staking = new Staking(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await staking.GetStakingProductList("STAKING");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region PurchaseStakingProduct
        [Fact]
        public async void PurchaseStakingProduct_Response()
        {
            var responseContent = "{\"positionId\":\"12345\",\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/staking/purchase", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Staking staking = new Staking(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await staking.PurchaseStakingProduct("STAKING", "Axs*90", 10.1m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RedeemStakingProduct
        [Fact]
        public async void RedeemStakingProduct_Response()
        {
            var responseContent = "{\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/staking/redeem", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Staking staking = new Staking(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await staking.RedeemStakingProduct("STAKING", "Axs*90");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetStakingProductPosition
        [Fact]
        public async void GetStakingProductPosition_Response()
        {
            var responseContent = "[{\"positionId\":\"123123\",\"projectId\":\"Axs*90\",\"asset\":\"AXS\",\"amount\":\"122.09202928\",\"purchaseTime\":\"1646182276000\",\"duration\":\"60\",\"accrualDays\":\"4\",\"rewardAsset\":\"AXS\",\"APY\":\"0.2032\",\"rewardAmt\":\"5.17181528\",\"extraRewardAsset\":\"BNB\",\"extraRewardAPY\":\"0.0203\",\"estExtraRewardAmt\":\"5.17181528\",\"nextInterestPay\":\"1.29295383\",\"nextInterestPayDate\":\"1646697600000\",\"payInterestPeriod\":\"1\",\"redeemAmountEarly\":\"2802.24068892\",\"interestEndDate\":\"1651449600000\",\"deliverDate\":\"1651536000000\",\"redeemPeriod\":\"1\",\"redeemingAmt\":\"232.2323\",\"partialAmtDeliverDate\":\"1651536000000\",\"canRedeemEarly\":true,\"renewable\"：true,\"type\":\"AUTO\",\"status\":\"HOLDING\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/staking/position", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Staking staking = new Staking(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await staking.GetStakingProductPosition("STAKING");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetStakingHistory
        [Fact]
        public async void GetStakingHistory_Response()
        {
            var responseContent = "[{\"positionId\":\"123123\",\"time\":1575018510000,\"asset\":\"BNB\",\"project\":\"BSC\",\"amount\":\"21312.23223\",\"lockPeriod\":\"30\",\"deliverDate\":\"1575018510000\",\"type\":\"AUTO\",\"status\":\"success\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/staking/stakingRecord", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Staking staking = new Staking(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await staking.GetStakingHistory("STAKING", "SUBSCRIPTION");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region SetAutoStaking
        [Fact]
        public async void SetAutoStaking_Response()
        {
            var responseContent = "{\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/staking/setAutoStaking", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Staking staking = new Staking(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await staking.SetAutoStaking("STAKING", "1234", "true");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetPersonalLeftQuotaOfStakingProduct
        [Fact]
        public async void GetPersonalLeftQuotaOfStakingProduct_Response()
        {
            var responseContent = "[{\"leftPersonalQuota\":\"1000\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/staking/personalLeftQuota", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Staking staking = new Staking(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await staking.GetPersonalLeftQuotaOfStakingProduct("STAKING", "Axs*90");

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}