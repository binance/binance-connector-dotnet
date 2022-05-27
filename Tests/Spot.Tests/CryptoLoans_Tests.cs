namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class CryptoLoans_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetCryptoLoansIncomeHistory
        [Fact]
        public async void GetCryptoLoansIncomeHistory_Response()
        {
            var responseContent = "[{\"asset\":\"BUSD\",\"type\":\"borrowIn\",\"amount\":\"100\",\"timestamp\":1633771139847,\"tranId\":\"80423589583\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/loan/income", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            CryptoLoans cryptoLoans = new CryptoLoans(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await cryptoLoans.GetCryptoLoansIncomeHistory("BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}