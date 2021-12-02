namespace Binance.Spot.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class BSwap_Tests
    {
        private string apiKey = "vmPUZE6mv9SD5VNHk4HlWFsOr6aKE2zvsw0MuIgwCIPy6utIco14y7Ju91duEh8A";
        private string apiSecret = "NhqPtmdSJYdKjVHjA7PZj4Mge3R5YNiP1e3UZjInClVN65XAbvqqM6A7H5fATj0j";

        #region ListAllSwapPools
        [Fact]
        public async void ListAllSwapPools_Response()
        {
            var responseContent = "[{\"poolId\":2,\"poolName\":\"BUSD/USDT\",\"assets\":[\"BUSD\",\"USDT\"]},{\"poolId\":3,\"poolName\":\"BUSD/DAI\",\"assets\":[\"BUSD\",\"DAI\"]},{\"poolId\":4,\"poolName\":\"USDT/DAI\",\"assets\":[\"USDT\",\"DAI\"]}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/pools", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.ListAllSwapPools();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetLiquidityInformationOfAPool
        [Fact]
        public async void GetLiquidityInformationOfAPool_Response()
        {
            var responseContent = "[{\"poolId\":2,\"poolNmae\":\"BUSD/USDT\",\"updateTime\":1565769342148,\"liquidity\":{\"BUSD\":100000315.79,\"USDT\":99999245.54},\"share\":{\"shareAmount\":12415,\"sharePercentage\":0.00006207,\"asset\":{\"BUSD\":6207.02,\"USDT\":6206.95}}}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidity", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.GetLiquidityInformationOfAPool();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AddLiquidity
        [Fact]
        public async void AddLiquidity_Response()
        {
            var responseContent = "{\"operationId\":12341}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidityAdd", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.AddLiquidity(2, "USDT", 522.23m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RemoveLiquidity
        [Fact]
        public async void RemoveLiquidity_Response()
        {
            var responseContent = "{\"operationId\":12341}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidityRemove", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.RemoveLiquidity(2, LiquidityRemovalType.SINGLE, 522.23m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetLiquidityOperationRecord
        [Fact]
        public async void GetLiquidityOperationRecord_Response()
        {
            var responseContent = "[{\"operationId\":12341,\"poolId\":2,\"poolName\":\"BUSD/USDT\",\"operation\":\"ADD\",\"status\":1,\"updateTime\":1565769342148,\"shareAmount\":\"10.1\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/liquidityOps", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.GetLiquidityOperationRecord();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RequestQuote
        [Fact]
        public async void RequestQuote_Response()
        {
            var responseContent = "{\"quoteAsset\":\"USDT\",\"baseAsset\":\"BUSD\",\"quoteQty\":300000,\"baseQty\":299975,\"price\":1.00008334,\"slippage\":0.00007245,\"fee\":120}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/quote", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.RequestQuote("USDT", "BUSD", 300000m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region Swap
        [Fact]
        public async void Swap_Response()
        {
            var responseContent = "{\"swapId\":2314}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/swap", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.Swap("USDT", "BUSD", 300000m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetSwapHistory
        [Fact]
        public async void GetSwapHistory_Response()
        {
            var responseContent = "[{\"swapId\":2314,\"swapTime\":1565770342148,\"status\":0,\"quoteAsset\":\"USDT\",\"baseAsset\":\"BUSD\",\"quoteQty\":300000,\"baseQty\":299975,\"price\":1.00008334,\"fee\":120}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/swap", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.GetSwapHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}