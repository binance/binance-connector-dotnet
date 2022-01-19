namespace Binance.Spot.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Mining_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region AcquiringAlgorithm
        [Fact]
        public async void AcquiringAlgorithm_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":[{\"algoName\":\"sha256\",\"algoId\":1,\"poolIndex\":0,\"unit\":\"h/s\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/pub/algoList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.AcquiringAlgorithm();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AcquiringCoinname
        [Fact]
        public async void AcquiringCoinname_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":[{\"coinName\":\"BTC\",\"coinId\":1,\"poolIndex\":0,\"algoId\":1,\"algoName\":\"sha256\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/pub/coinList", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.AcquiringCoinname();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RequestForDetailMinerList
        [Fact]
        public async void RequestForDetailMinerList_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":[{\"workerName\":\"bhdc1.16A10404B\",\"type\":\"H_hashrate\",\"hashrateDatas\":[{\"time\":1587902400000,\"hashrate\":\"0\",\"reject\":0},{\"time\":1587906000000,\"hashrate\":\"0\",\"reject\":0}]},{\"workerName\":\"bhdc1.16A10404B\",\"type\":\"D_hashrate\",\"hashrateDatas\":[{\"time\":1587902400000,\"hashrate\":\"0\",\"reject\":0},{\"time\":1587906000000,\"hashrate\":\"0\",\"reject\":0}]}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/worker/detail", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.RequestForDetailMinerList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RequestForMinerList
        [Fact]
        public async void RequestForMinerList_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":{\"workerDatas\":[{\"workerId\":\"1420554439452400131\",\"workerName\":\"2X73\",\"status\":3,\"hashRate\":0,\"dayHashRate\":0,\"rejectRate\":0,\"lastShareTime\":1587712919000},{\"workerId\":\"7893926126382807951\",\"workerName\":\"AZDC1.1A10101\",\"status\":2,\"hashRate\":29711247541680,\"dayHashRate\":12697781298013.66,\"rejectRate\":0,\"lastShareTime\":1587969727000}],\"totalNum\":18530,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/worker/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.RequestForMinerList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region EarningsList
        [Fact]
        public async void EarningsList_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":{\"accountProfits\":[{\"time\":1586188800000,\"type\":31,\"hashTransfer\":null,\"transferAmount\":null,\"dayHashRate\":129129903378244,\"profitAmount\":8.6083060304,\"coinName\":\"BTC\",\"status\":2},{\"time\":1607529600000,\"coinName\":\"BTC\",\"type\":0,\"dayHashRate\":9942053925926,\"profitAmount\":0.85426469,\"hashTransfer\":200000000000,\"transferAmount\":0.02180958,\"status\":2},{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":31,\"dayHashRate\":200000000000,\"profitAmount\":0.02905916,\"hashTransfer\":null,\"transferAmount\":null,\"status\":2}],\"totalNum\":3,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/payment/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.EarningsList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region ExtraBonusList
        [Fact]
        public async void ExtraBonusList_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":{\"otherProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":4,\"profitAmount\":0.0011859,\"status\":2}],\"totalNum\":3,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/payment/other", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.ExtraBonusList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region HashrateResaleList
        [Fact]
        public async void HashrateResaleList_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":{\"configDetails\":[{\"configId\":168,\"poolUsername\":\"123\",\"toPoolUsername\":\"user1\",\"algoName\":\"Ethash\",\"hashRate\":5000000,\"startDay\":20201210,\"endDay\":20210405,\"status\":1},{\"configId\":166,\"poolUsername\":\"pop\",\"toPoolUsername\":\"111111\",\"algoName\":\"Ethash\",\"hashRate\":3320000,\"startDay\":20201226,\"endDay\":20201227,\"status\":0}],\"totalNum\":21,\"pageSize\":200}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/config/details/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.HashrateResaleList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region HashrateResaleDetail
        [Fact]
        public async void HashrateResaleDetail_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":{\"profitTransferDetails\":[{\"poolUsername\":\"test4001\",\"toPoolUsername\":\"pop\",\"algoName\":\"sha256\",\"hashRate\":200000000000,\"day\":20201213,\"amount\":0.2256872,\"coinName\":\"BTC\"},{\"poolUsername\":\"test4001\",\"toPoolUsername\":\"pop\",\"algoName\":\"sha256\",\"hashRate\":200000000000,\"day\":20201213,\"amount\":0.2256872,\"coinName\":\"BTC\"}],\"totalNum\":8,\"pageSize\":200}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/profit/details", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.HashrateResaleDetail();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region HashrateResaleRequest
        [Fact]
        public async void HashrateResaleRequest_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":171}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/config", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.HashrateResaleRequest();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CancelHashrateResaleConfiguration
        [Fact]
        public async void CancelHashrateResaleConfiguration_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/hash-transfer/config/cancel", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.CancelHashrateResaleConfiguration();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region StatisticList
        [Fact]
        public async void StatisticList_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":{\"fifteenMinHashRate\":\"457835490067496409.00000000\",\"dayHashRate\":\"214289268068874127.65000000\",\"validNum\":0,\"invalidNum\":17562,\"profitToday\":{\"BTC\":\"0.00314332\",\"BSV\":\"56.17055953\",\"BCH\":\"106.61586001\"},\"profitYesterday\":{\"BTC\":\"0.00314332\",\"BSV\":\"56.17055953\",\"BCH\":\"106.61586001\"},\"userName\":\"test\",\"unit\":\"h/s\",\"algo\":\"sha256\"}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/statistics/user/status", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.StatisticList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AccountList
        [Fact]
        public async void AccountList_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":[{\"type\":\"H_hashrate\",\"userName\":\"test\",\"list\":[{\"time\":1585267200000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"},{\"time\":1585353600000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"}]},{\"type\":\"D_hashrate\",\"userName\":\"test\",\"list\":[{\"time\":1587906000000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"},{\"time\":1587909600000,\"hashrate\":\"0.00000000\",\"reject\":\"0.00000000\"}]}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/statistics/user/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.AccountList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MiningAccountEarning
        [Fact]
        public async void MiningAccountEarning_Response()
        {
            var responseContent = "{\"code\":0,\"msg\":\"\",\"data\":{\"accountProfits\":[{\"time\":1607443200000,\"coinName\":\"BTC\",\"type\":2,\"puid\":59985472,\"subName\":\"vdvaghani\",\"amount\":0.09186957}],\"totalNum\":3,\"pageSize\":20}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/mining/payment/uid", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Mining mining = new Mining(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await mining.MiningAccountEarning("sha256");

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}