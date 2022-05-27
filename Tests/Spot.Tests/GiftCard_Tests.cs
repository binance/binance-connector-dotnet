namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class GiftCard_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region CreateBinanceCode
        [Fact]
        public async void CreateBinanceCode_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"referenceNo\":\"0033002327977405\",\"code\":\"AOGANK3NB4GIT3C6\"},\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/giftcard/createCode", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            GiftCard giftCard = new GiftCard(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await giftCard.CreateBinanceCode("BTC", 1.01);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RedeemBinanceCode
        [Fact]
        public async void RedeemBinanceCode_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"token\":\"BNB\",\"amount\":\"10\",\"referenceNo\":\"0033002327977405\",\"identityNo\":\"10316281761814589440\"},\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/giftcard/redeemCode", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            GiftCard giftCard = new GiftCard(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await giftCard.RedeemBinanceCode("000000");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region VerifyBinanceCode
        [Fact]
        public async void VerifyBinanceCode_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":{\"valid\":true,\"token\":\"BNB\",\"amount\":\"0.00000001\"},\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/giftcard/verify", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            GiftCard giftCard = new GiftCard(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await giftCard.VerifyBinanceCode("000000000000000000");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region FetchRsaPublicKey
        [Fact]
        public async void FetchRsaPublicKey_Response()
        {
            var responseContent = "{\"code\":\"000000\",\"message\":\"success\",\"data\":\"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCXBBVKLAc1GQ5FsIFFqOHrPTox5noBONIKr+IAedTR9FkVxq6e65updEbfdhRNkMOeYIO2i0UylrjGC0X8YSoIszmrVHeV0l06Zh1oJuZos1+7N+WLuz9JvlPaawof3GUakTxYWWCa9+8KIbLKsoKMdfS96VT+8iOXO3quMGKUmQIDAQAB\",\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/giftcard/cryptography/rsa-public-key", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            GiftCard giftCard = new GiftCard(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await giftCard.FetchRsaPublicKey();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}