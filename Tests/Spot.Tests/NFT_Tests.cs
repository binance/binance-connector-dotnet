namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class NFT_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region GetNftTransactionHistory
        [Fact]
        public async void GetNftTransactionHistory_Response()
        {
            var responseContent = "{\"total\":1,\"list\":[{\"orderNo\":\"1_470502070600699904\",\"tokens\":[{\"network\":\"BSC\",\"tokenId\":\"216000000496\",\"contractAddress\":\"MYSTERY_BOX0000087\"}],\"tradeTime\":1626941236000,\"tradeAmount\":\"19.60000000\",\"tradeCurrency\":\"BNB\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/history/transactions", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            NFT nft = new NFT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await nft.GetNftTransactionHistory(1);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetNftDepositHistory
        [Fact]
        public async void GetNftDepositHistory_Response()
        {
            var responseContent = "{\"total\":1,\"list\":[{\"network\":\"ETH\",\"txID\":0,\"contractAdrress\":\"0xe507c961ee127d4439977a61af39c34eafee0dc6\",\"tokenId\":\"10014\",\"timestamp\":1629986047000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/history/deposit", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            NFT nft = new NFT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await nft.GetNftDepositHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetNftWithdrawHistory
        [Fact]
        public async void GetNftWithdrawHistory_Response()
        {
            var responseContent = "{\"total\":178,\"list\":[{\"network\":\"ETH\",\"txID\":\"0x2be5eed31d787fdb4880bc631c8e76bdfb6150e137f5cf1732e0416ea206f57f\",\"contractAdrress\":\"0xe507c961ee127d4439977a61af39c34eafee0dc6\",\"tokenId\":\"1000001247\",\"timestamp\":1633674433000,\"fee\":0.1,\"feeAsset\":\"ETH\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/history/withdraw", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            NFT nft = new NFT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await nft.GetNftWithdrawHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetNftAsset
        [Fact]
        public async void GetNftAsset_Response()
        {
            var responseContent = "{\"total\":347,\"list\":[{\"network\":\"BSC\",\"contractAddress\":\"REGULAR11234567891779\",\"tokenId\":\"100900000017\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/nft/user/getAsset", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            NFT nft = new NFT(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await nft.GetNftAsset();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}