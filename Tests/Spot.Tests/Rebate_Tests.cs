namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Rebate_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetSpotRebateHistoryRecords
        [Fact]
        public async void GetSpotRebateHistoryRecords_Response()
        {
            var responseContent = "{\"status\":\"OK\",\"type\":\"GENERAL\",\"code\":\"000000000\",\"data\":{\"page\":1,\"totalRecords\":2,\"totalPageNum\":1,\"data\":[{\"asset\":\"USDT\",\"type\":1,\"amount\":\"0.0001126\",\"updateTime\":1637651320000}]}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/rebate/taxQuery", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Rebate rebate = new Rebate(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await rebate.GetSpotRebateHistoryRecords();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}