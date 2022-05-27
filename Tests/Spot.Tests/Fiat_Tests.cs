namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Fiat_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetFiatDepositWithdrawHistory
        [Fact]
        public async void GetFiatDepositWithdrawHistory_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderNo\":\"7d76d611-0568-4f43-afb6-24cac7767365\",\"fiatCurrency\":\"BRL\",\"indicatedAmount\":\"10.00\",\"amount\":\"10.00\",\"totalFee\":\"0.00\",\"method\":\"BankAccount\",\"status\":\"Expired\",\"createTime\":1626144956000,\"updateTime\":1626400907000}],\"total\":1,\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/fiat/orders", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Fiat fiat = new Fiat(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await fiat.GetFiatDepositWithdrawHistory(FiatOrderTransactionType.DEPOSIT);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetFiatPaymentsHistory
        [Fact]
        public async void GetFiatPaymentsHistory_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":[{\"orderNo\":\"353fca443f06466db0c4dc89f94f027a\",\"sourceAmount\":\"20.00\",\"fiatCurrency\":\"EUR\",\"obtainAmount\":\"4.462\",\"cryptoCurrency\":\"LUNA\",\"totalFee\":\"0.2\",\"price\":\"4.437472\",\"status\":\"Failed\",\"createTime\":1624529919000,\"updateTime\":1624529919000}],\"total\":1,\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/fiat/payments", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Fiat fiat = new Fiat(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await fiat.GetFiatPaymentsHistory(FiatPaymentTransactionType.BUY);

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}