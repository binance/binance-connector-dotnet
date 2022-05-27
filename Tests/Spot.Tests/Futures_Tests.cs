namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class Futures_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region NewFutureAccountTransfer
        [Fact]
        public async void NewFutureAccountTransfer_Response()
        {
            var responseContent = "{\"tranId\":100000001}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/transfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.NewFutureAccountTransfer("USDT", 522.23m, FuturesTransferType.SPOT_TO_USDT_MARGINED_FUTURES);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetFutureAccountTransactionHistoryList
        [Fact]
        public async void GetFutureAccountTransactionHistoryList_Response()
        {
            var responseContent = "{\"rows\":[{\"asset\":\"USDT\",\"tranId\":100000001,\"amount\":\"40.84624400\",\"type\":\"1\",\"timestamp\":1555056425000,\"status\":\"CONFIRMED\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/transfer", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.GetFutureAccountTransactionHistoryList("USDT", 1631318399000);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region BorrowForCrosscollateral
        [Fact]
        public async void BorrowForCrosscollateral_Response()
        {
            var responseContent = "{\"coin\":\"USDT\",\"amount\":\"4.50000000\",\"collateralCoin\":\"BUSD\",\"collateralAmount\":\"5.00000000\",\"time\":1582540328433,\"borrowId\":\"438648398970089472\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/borrow", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.BorrowForCrosscollateral("USDT", "BUSD");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralBorrowHistory
        [Fact]
        public async void CrosscollateralBorrowHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"confirmedTime\":1582540328433,\"coin\":\"USDT\",\"collateralRate\":\"0.89991001\",\"leftTotal\":\"4.5\",\"leftPrincipal\":\"4.5\",\"deadline\":4736102399000,\"collateralCoin\":\"BUSD\",\"collateralAmount\":\"5.0\",\"orderStatus\":\"PENDING\",\"borrowId\":\"438648398970089472\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/borrow/history", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralBorrowHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RepayForCrosscollateral
        [Fact]
        public async void RepayForCrosscollateral_Response()
        {
            var responseContent = "{\"coin\":\"USDT\",\"amount\":\"1.68\",\"collateralCoin\":\"BUSD\",\"repayId\":\"439659223998894080\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/repay", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.RepayForCrosscollateral("USDT", "BUSD", 1.68m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralRepaymentHistory
        [Fact]
        public async void CrosscollateralRepaymentHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"coin\":\"USDT\",\"amount\":\"1.68\",\"collateralCoin\":\"BUSD\",\"repayType\":\"NORMAL\",\"releasedCollateral\":\"1.80288889\",\"price\":\"1.001\",\"repayCollateral\":\"10010\",\"confirmedTime\":1582781327575,\"updateTime\":1582794387516,\"status\":\"PENDING\",\"repayId\":\"439659223998894080\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/repay/history", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralRepaymentHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralWallet
        [Fact]
        public async void CrosscollateralWallet_Response()
        {
            var responseContent = "{\"totalCrossCollateral\":\"5.8238577133\",\"totalBorrowed\":\"5.07000000\",\"totalInterest\":\"0.0\",\"interestFreeLimit\":\"100000\",\"asset\":\"USDT\",\"crossCollaterals\":[{\"collateralCoin\":\"BUSD\",\"locked\":\"5.82211108\",\"loanAmount\":\"5.07\",\"currentCollateralRate\":\"0.87168984\",\"interestFreeLimitUsed\":\"5.07\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"},{\"collateralCoin\":\"BTC\",\"locked\":\"0\",\"loanAmount\":\"0\",\"currentCollateralRate\":\"0\",\"interestFreeLimitUsed\":\"0\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/wallet", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralWallet();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralWalletV2
        [Fact]
        public async void CrosscollateralWalletV2_Response()
        {
            var responseContent = "{\"totalCrossCollateral\":\"5.8238577133\",\"totalBorrowed\":\"5.07000000\",\"totalInterest\":\"0.0\",\"interestFreeLimit\":\"100000\",\"asset\":\"USD\",\"crossCollaterals\":[{\"loanCoin\":\"USDT\",\"collateralCoin\":\"BUSD\",\"locked\":\"5.82211108\",\"loanAmount\":\"5.07\",\"currentCollateralRate\":\"0.87168984\",\"interestFreeLimitUsed\":\"5.07\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"},{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BTC\",\"locked\":\"0\",\"loanAmount\":\"0\",\"currentCollateralRate\":\"0\",\"interestFreeLimitUsed\":\"0\",\"principalForInterest\":\"0.0\",\"interest\":\"0.0\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/wallet", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralWalletV2();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralInformation
        [Fact]
        public async void CrosscollateralInformation_Response()
        {
            var responseContent = "[{\"collateralCoin\":\"BUSD\",\"rate\":\"0.9\",\"marginCallCollateralRate\":\"0.95\",\"liquidationCollateralRate\":\"0.98\",\"currentCollateralRate\":\"0.87168984\",\"interestRate\":\"0.0\",\"interestGracePeriod\":\"0\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/configs", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralInformation();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralInformationV2
        [Fact]
        public async void CrosscollateralInformationV2_Response()
        {
            var responseContent = "[{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BTC\",\"rate\":\"0.9\",\"marginCallCollateralRate\":\"0.95\",\"liquidationCollateralRate\":\"0.98\",\"currentCollateralRate\":\"0.87168984\",\"interestRate\":\"0.0\",\"interestGracePeriod\":\"0\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/configs", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralInformationV2();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CalculateRateAfterAdjustCrosscollateralLtv
        [Fact]
        public async void CalculateRateAfterAdjustCrosscollateralLtv_Response()
        {
            var responseContent = "{\"afterCollateralRate\":\"0.89736451\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/calcAdjustLevel", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CalculateRateAfterAdjustCrosscollateralLtv("BUSD", 1.2376m, LoanDirection.ADDITIONAL);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CalculateRateAfterAdjustCrosscollateralLtvV2
        [Fact]
        public async void CalculateRateAfterAdjustCrosscollateralLtvV2_Response()
        {
            var responseContent = "{\"afterCollateralRate\":\"0.89736451\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/calcAdjustLevel", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CalculateRateAfterAdjustCrosscollateralLtvV2("BTC", "BUSD", 1.2375m, LoanDirection.ADDITIONAL);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetMaxAmountForAdjustCrosscollateralLtv
        [Fact]
        public async void GetMaxAmountForAdjustCrosscollateralLtv_Response()
        {
            var responseContent = "{\"maxInAmount\":\"9.97109038\",\"maxOutAmount\":\"0.50952693\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/calcMaxAdjustAmount", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.GetMaxAmountForAdjustCrosscollateralLtv("USDT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetMaxAmountForAdjustCrosscollateralLtvV2
        [Fact]
        public async void GetMaxAmountForAdjustCrosscollateralLtvV2_Response()
        {
            var responseContent = "{\"maxInAmount\":\"9.97109038\",\"maxOutAmount\":\"0.50952693\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/calcMaxAdjustAmount", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.GetMaxAmountForAdjustCrosscollateralLtvV2("BTC", "BUSD");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AdjustCrosscollateralLtv
        [Fact]
        public async void AdjustCrosscollateralLtv_Response()
        {
            var responseContent = "{\"collateralCoin\":\"BUSD\",\"direction\":\"ADDITIONAL\",\"amount\":\"5.00000000\",\"time\":1583540328433}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/adjustCollateral", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.AdjustCrosscollateralLtv("BUSD", 5m, LoanDirection.ADDITIONAL);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AdjustCrosscollateralLtvV2
        [Fact]
        public async void AdjustCrosscollateralLtvV2_Response()
        {
            var responseContent = "{\"loanCoin\":\"BUSD\",\"collateralCoin\":\"BTC\",\"direction\":\"ADDITIONAL\",\"amount\":\"5.00000000\",\"time\":1583540328433}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/futures/loan/adjustCollateral", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.AdjustCrosscollateralLtvV2("BUSD", "BTC", 5m, LoanDirection.ADDITIONAL);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AdjustCrosscollateralLtvHistory
        [Fact]
        public async void AdjustCrosscollateralLtvHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"amount\":\".17398184\",\"collateralCoin\":\"BUSD\",\"coin\":\"USDT\",\"preCollateralRate\":\"0.87054861\",\"afterCollateralRate\":\"0.89736451\",\"direction\":\"REDUCED\",\"status\":\"COMPLETED\",\"adjustTime\":1583978243588}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/adjustCollateral/history", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.AdjustCrosscollateralLtvHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralLiquidationHistory
        [Fact]
        public async void CrosscollateralLiquidationHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"collateralAmountForLiquidation\":\"10.12345678\",\"collateralCoin\":\"BUSD\",\"forceLiquidationStartTime\":1583978243588,\"coin\":\"USDT\",\"restCollateralAmountAfterLiquidation\":\"15.12345678\",\"restLoanAmount\":\"11.12345678\",\"status\":\"PENDING\"}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/liquidationHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralLiquidationHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CheckCollateralRepayLimit
        [Fact]
        public async void CheckCollateralRepayLimit_Response()
        {
            var responseContent = "{\"coin\":\"USDT\",\"collateralCoin\":\"BTC\",\"max\":\"15000\",\"min\":\"15\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepayLimit", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CheckCollateralRepayLimit("USDT", "BTC");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetCollateralRepayQuote
        [Fact]
        public async void GetCollateralRepayQuote_Response()
        {
            var responseContent = "{\"coin\":\"USDT\",\"collateralCoin\":\"BTC\",\"amount\":\"0.00222\",\"quoteId\":\"8a03da95f0ad4fdc8067e3b6cde72423\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepay", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.GetCollateralRepayQuote("USDT", "BTC", 0.00222m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region RepayWithCollateral
        [Fact]
        public async void RepayWithCollateral_Response()
        {
            var responseContent = "{\"coin\":\"USDT\",\"collateralCoin\":\"BTC\",\"amount\":\"30\",\"quoteId\":\"3eece81ca2734042b2f538ea0d9cbdd3\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepay", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.RepayWithCollateral("3eece81ca2734042b2f538ea0d9cbdd3");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CollateralRepaymentResult
        [Fact]
        public async void CollateralRepaymentResult_Response()
        {
            var responseContent = "{\"quoteId\":\"3eece81ca2734042b2f538ea0d9cbdd3\",\"status\":\"SUCCESS\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/collateralRepayResult", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CollateralRepaymentResult("3eece81ca2734042b2f538ea0d9cbdd3");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region CrosscollateralInterestHistory
        [Fact]
        public async void CrosscollateralInterestHistory_Response()
        {
            var responseContent = "{\"rows\":[{\"collateralCoin\":\"BUSD\",\"interestCoin\":\"USDT\",\"interest\":\"2.354\",\"interestFreeLimitUsed\":\"0\",\"principalForInterest\":\"10000\",\"interestRate\":\"0.002\",\"time\":1582794387516}],\"total\":1}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/futures/loan/interestHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            Futures futures = new Futures(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await futures.CrosscollateralInterestHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}