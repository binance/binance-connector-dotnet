namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Pay_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetPayTradeHistory
        [Fact]
        public async void GetPayTradeHistory_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderType\":\"C2C\",\"transactionId\":\"M_P_71505104267788288\",\"transactionTime\":1610090460133,\"amount\":\"23.72469206\",\"currency\":\"BNB\",\"fundsDetail\":[{\"currency\":\"\",\"amount\":\"\"}]}],\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/pay/transactions", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Pay pay = new Pay(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await pay.GetPayTradeHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}