namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Convert_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetConvertTradeHistory
        [Fact]
        public async void GetConvertTradeHistory_Response()
        {
            var responseContent = "{\"list\":[{\"quoteId\":\"f3b91c525b2644c7bc1e1cd31b6e1aa6\",\"orderId\":940708407462087200,\"orderStatus\":\"SUCCESS\",\"fromAsset\":\"USDT\",\"fromAmount\":\"20\",\"toAsset\":\"BNB\",\"toAmount\":\"0.06154036\",\"ratio\":\"0.00307702\",\"inverseRatio\":\"324.99\",\"createTime\":1624248872184}],\"startTime\":1623824139000,\"endTime\":1626416139000,\"limit\":100,\"moreData\":false}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/convert/tradeFlow", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Convert convert = new Convert(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await convert.GetConvertTradeHistory(1563189166000, 1563282766000);

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}