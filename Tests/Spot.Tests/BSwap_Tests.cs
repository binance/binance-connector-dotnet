namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class BSwap_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region ListAllSwapPools
        [Fact]
        public async void ListAllSwapPools_Response()
        {
            var responseContent = "[{\"poolId\":2,\"poolName\":\"BUSD/USDT\",\"assets\":[\"\"]}]";
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

            var result = await bSwap.AddLiquidity(2, "BTC", 12415.2m);

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

            var result = await bSwap.RemoveLiquidity(2, LiquidityRemovalType.SINGLE, 12415.2m);

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

            var result = await bSwap.RequestQuote("USDT", "BUSD", 12415.2m);

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

            var result = await bSwap.Swap("USDT", "BUSD", 12415.2m);

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

        #region PoolConfigure
        [Fact]
        public async void PoolConfigure_Response()
        {
            var responseContent = "[{\"poolId\":2,\"poolNmae\":\"BUSD/USDT\",\"updateTime\":1565769342148,\"liquidity\":{\"constantA\":2000,\"minRedeemShare\":0.1,\"slippageTolerance\":0.2},\"assetConfigure\":{\"BUSD\":{\"minAdd\":10,\"maxAdd\":20,\"minSwap\":10,\"maxSwap\":30},\"USDT\":{\"minAdd\":10,\"maxAdd\":20,\"minSwap\":10,\"maxSwap\":30}}}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/poolConfigure", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.PoolConfigure();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AddLiquidityPreview
        [Fact]
        public async void AddLiquidityPreview_Response()
        {
            var responseContent = "{\"quoteAsset\":\"USDT\",\"baseAsset\":\"BUSD\",\"quoteAmt\":300000,\"baseAmt\":299975,\"price\":1.00008334,\"share\":1.23}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/addLiquidityPreview", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.AddLiquidityPreview(2, "SINGLE", "USDT", 12415.2m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RemoveLiquidityPreview
        [Fact]
        public async void RemoveLiquidityPreview_Response()
        {
            var responseContent = "{\"quoteAsset\":\"USDT\",\"baseAsset\":\"BUSD\",\"quoteAmt\":300000,\"baseAmt\":299975,\"price\":1.00008334}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/removeLiquidityPreview", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.RemoveLiquidityPreview(2, "SINGLE", "USDT", 12415.2m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetUnclaimedRewardsRecord
        [Fact]
        public async void GetUnclaimedRewardsRecord_Response()
        {
            var responseContent = "{\"totalUnclaimedRewards\":{\"BUSD\":100000315.79,\"BNB\":1e-8,\"USDT\":2e-8},\"details\":{\"BNB/USDT\":{\"BUSD\":100000315.79,\"USDT\":2e-8},\"BNB/BTC\":{\"BNB\":1e-8}}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/unclaimedRewards", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.GetUnclaimedRewardsRecord();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region ClaimRewards
        [Fact]
        public async void ClaimRewards_Response()
        {
            var responseContent = "{\"success\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/claimRewards", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.ClaimRewards();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetClaimedHistory
        [Fact]
        public async void GetClaimedHistory_Response()
        {
            var responseContent = "[{\"poolId\":52,\"poolName\":\"BNB/USDT\",\"assetRewards\":\"BNB\",\"claimTime\":1565769342148,\"claimAmount\":2.3e-7,\"status\":1}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/bswap/claimedHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            BSwap bSwap = new BSwap(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await bSwap.GetClaimedHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}