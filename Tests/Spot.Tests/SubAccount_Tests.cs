namespace Binance.Spot.Tests
{
    using System.Net;
    using System.Net.Http;
    using Binance.Spot.Models;
    using Moq;
    using Moq.Protected;
    using Xunit;

    public class SubAccount_Tests
    {
        private string apiKey = "api-key";
        private string apiSecret = "api-secret";

        #region CreateAVirtualSubaccount
        [Fact]
        public async void CreateAVirtualSubaccount_Response()
        {
            var responseContent = "{\"email\":\"addsdd_virtual@aasaixwqnoemail.com\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/virtualSubAccount", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.CreateAVirtualSubaccount("testaccount");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QuerySubaccountList
        [Fact]
        public async void QuerySubaccountList_Response()
        {
            var responseContent = "{\"subAccounts\":[{\"email\":\"testsub@gmail.com\",\"isFreeze\":false,\"createTime\":1544433328000,\"isManagedSubAccount\":false,\"isAssetManagementSubAccount\":false}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/list", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QuerySubaccountList();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QuerySubaccountSpotAssetTransferHistory
        [Fact]
        public async void QuerySubaccountSpotAssetTransferHistory_Response()
        {
            var responseContent = "[{\"from\":\"aaa@test.com\",\"to\":\"bbb@test.com\",\"asset\":\"BTC\",\"qty\":10,\"status\":\"SUCCESS\",\"tranId\":6489943656,\"time\":1544433328000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/sub/transfer/history", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QuerySubaccountSpotAssetTransferHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QuerySubaccountFuturesAssetTransferHistory
        [Fact]
        public async void QuerySubaccountFuturesAssetTransferHistory_Response()
        {
            var responseContent = "{\"success\":true,\"futuresType\":2,\"transfers\":[{\"from\":\"aaa@test.com\",\"to\":\"bbb@test.com\",\"asset\":\"BTC\",\"qty\":\"1\",\"tranId\":11897001102,\"time\":1544433328000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/internalTransfer", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QuerySubaccountFuturesAssetTransferHistory("testaccount@email.com", FuturesType.COIN_MARGINED_FUTURES);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region SubaccountFuturesAssetTransfer
        [Fact]
        public async void SubaccountFuturesAssetTransfer_Response()
        {
            var responseContent = "{\"success\":true,\"txnId\":\"2934662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/internalTransfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.SubaccountFuturesAssetTransfer("testaccount@email.com", "testaccount2@email.com", FuturesType.COIN_MARGINED_FUTURES, "BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QuerySubaccountAssets
        [Fact]
        public async void QuerySubaccountAssets_Response()
        {
            var responseContent = "{\"balances\":[{\"asset\":\"ADA\",\"free\":10000,\"locked\":0}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v3/sub-account/assets", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QuerySubaccountAssets("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QuerySubaccountSpotAssetsSummary
        [Fact]
        public async void QuerySubaccountSpotAssetsSummary_Response()
        {
            var responseContent = "{\"totalCount\":1,\"masterAccountTotalAsset\":\"0.23231201\",\"spotSubUserAssetBtcVoList\":[{\"email\":\"sub123@test.com\",\"totalAsset\":\"9999.00000000\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/spotSummary", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QuerySubaccountSpotAssetsSummary();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetSubaccountDepositAddress
        [Fact]
        public async void GetSubaccountDepositAddress_Response()
        {
            var responseContent = "{\"address\":\"TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV\",\"coin\":\"USDT\",\"tag\":\"\",\"url\":\"https://tronscan.org/#/address/TDunhSa7jkTNuKrusUTU1MUHtqXoBPKETV\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/deposit/subAddress", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetSubaccountDepositAddress("testaccount@email.com", "BNB");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetSubaccountDepositHistory
        [Fact]
        public async void GetSubaccountDepositHistory_Response()
        {
            var responseContent = "[{\"amount\":\"0.00999800\",\"coin\":\"PAXG\",\"network\":\"ETH\",\"status\":1,\"address\":\"0x788cabe9236ce061e5a892e1a59395a81fc8d62c\",\"addressTag\":\"\",\"txId\":\"0xaad4654a3234aa6118af9b4b335f5ae81c360b2394721c019b5d1e75328b09f3\",\"insertTime\":1599621997000,\"transferType\":0,\"confirmTimes\":\"12/12\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/capital/deposit/subHisrec", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetSubaccountDepositHistory("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetSubaccountsStatusOnMarginFutures
        [Fact]
        public async void GetSubaccountsStatusOnMarginFutures_Response()
        {
            var responseContent = "[{\"email\":\"123@test.com\",\"isSubUserEnabled\":true,\"isUserActive\":true,\"insertTime\":1570791523523,\"isMarginEnabled\":true,\"isFutureEnabled\":true,\"mobile\":1570791523523}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/status", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetSubaccountsStatusOnMarginFutures();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region EnableMarginForSubaccount
        [Fact]
        public async void EnableMarginForSubaccount_Response()
        {
            var responseContent = "{\"email\":\"123@test.com\",\"isMarginEnabled\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/enable", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.EnableMarginForSubaccount("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetDetailOnSubaccountsMarginAccount
        [Fact]
        public async void GetDetailOnSubaccountsMarginAccount_Response()
        {
            var responseContent = "{\"email\":\"123@test.com\",\"marginLevel\":\"11.64405625\",\"totalAssetOfBtc\":\"6.82728457\",\"totalLiabilityOfBtc\":\"0.58633215\",\"totalNetAssetOfBtc\":\"6.24095242\",\"marginTradeCoeffVo\":{\"forceLiquidationBar\":\"1.10000000\",\"marginCallBar\":\"1.50000000\",\"normalBar\":\"2.00000000\"},\"marginUserAssetVoList\":[{\"asset\":\"BTC\",\"borrowed\":\"0.00000000\",\"free\":\"0.00499500\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"0.00499500\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/account", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetDetailOnSubaccountsMarginAccount("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetSummaryOfSubaccountsMarginAccount
        [Fact]
        public async void GetSummaryOfSubaccountsMarginAccount_Response()
        {
            var responseContent = "{\"totalAssetOfBtc\":\"4.33333333\",\"totalLiabilityOfBtc\":\"2.11111112\",\"totalNetAssetOfBtc\":\"2.22222221\",\"subAccountList\":[{\"email\":\"123@test.com\",\"totalAssetOfBtc\":\"2.11111111\",\"totalLiabilityOfBtc\":\"1.11111111\",\"totalNetAssetOfBtc\":\"1.00000000\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/accountSummary", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetSummaryOfSubaccountsMarginAccount();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region EnableFuturesForSubaccount
        [Fact]
        public async void EnableFuturesForSubaccount_Response()
        {
            var responseContent = "{\"email\":\"123@test.com\",\"isFuturesEnabled\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/enable", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.EnableFuturesForSubaccount("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetDetailOnSubaccountsFuturesAccount
        [Fact]
        public async void GetDetailOnSubaccountsFuturesAccount_Response()
        {
            var responseContent = "{\"email\":\"abc@test.com\",\"asset\":\"USDT\",\"assets\":[{\"asset\":\"USDT\",\"initialMargin\":\"0.00000000\",\"maintenanceMargin\":\"0.00000000\",\"marginBalance\":\"0.88308000\",\"maxWithdrawAmount\":\"0.88308000\",\"openOrderInitialMargin\":\"0.00000000\",\"positionInitialMargin\":\"0.00000000\",\"unrealizedProfit\":\"0.00000000\",\"walletBalance\":\"0.88308000\"}],\"canDeposit\":true,\"canTrade\":true,\"canWithdraw\":true,\"feeTier\":2,\"maxWithdrawAmount\":\"0.88308000\",\"totalInitialMargin\":\"0.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"0.88308000\",\"totalOpenOrderInitialMargin\":\"0.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"0.88308000\",\"updateTime\":1576756674610}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/account", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetDetailOnSubaccountsFuturesAccount("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetSummaryOfSubaccountsFuturesAccount
        [Fact]
        public async void GetSummaryOfSubaccountsFuturesAccount_Response()
        {
            var responseContent = "{\"totalInitialMargin\":\"9.83137400\",\"totalMaintenanceMargin\":\"0.41568700\",\"totalMarginBalance\":\"23.03235621\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.83137400\",\"totalUnrealizedProfit\":\"0.03219710\",\"totalWalletBalance\":\"22.15879444\",\"asset\":\"USD\",\"subAccountList\":[{\"email\":\"123@test.com\",\"totalInitialMargin\":\"9.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"22.12659734\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"22.12659734\",\"asset\":\"USD\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/accountSummary", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetSummaryOfSubaccountsFuturesAccount();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetFuturesPositionriskOfSubaccount
        [Fact]
        public async void GetFuturesPositionriskOfSubaccount_Response()
        {
            var responseContent = "[{\"entryPrice\":\"9975.12000\",\"leverage\":\"50\",\"maxNotional\":\"1000000\",\"liquidationPrice\":\"7963.54\",\"markPrice\":\"9973.50770517\",\"positionAmount\":\"0.010\",\"symbol\":\"BTCUSDT\",\"unrealizedProfit\":\"-0.01612295\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/positionRisk", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetFuturesPositionriskOfSubaccount("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region FuturesTransferForSubaccount
        [Fact]
        public async void FuturesTransferForSubaccount_Response()
        {
            var responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/futures/transfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.FuturesTransferForSubaccount("testaccount@email.com", "BTC", 1.01m, FuturesTransferType.SPOT_TO_USDT_MARGINED_FUTURES);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region MarginTransferForSubaccount
        [Fact]
        public async void MarginTransferForSubaccount_Response()
        {
            var responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/margin/transfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.MarginTransferForSubaccount("testaccount@email.com", "BTC", 1.01m, MarginTransferType.SPOT_TO_MARGIN);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region TransferToSubaccountOfSameMaster
        [Fact]
        public async void TransferToSubaccountOfSameMaster_Response()
        {
            var responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/transfer/subToSub", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.TransferToSubaccountOfSameMaster("testaccount@email.com", "BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region TransferToMaster
        [Fact]
        public async void TransferToMaster_Response()
        {
            var responseContent = "{\"txnId\":\"2966662589\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/transfer/subToMaster", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.TransferToMaster("BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region SubaccountTransferHistory
        [Fact]
        public async void SubaccountTransferHistory_Response()
        {
            var responseContent = "[{\"counterParty\":\"master\",\"email\":\"master@test.com\",\"type\":1,\"asset\":\"BTC\",\"qty\":\"1\",\"fromAccountType\":\"SPOT\",\"toAccountType\":\"SPOT\",\"status\":\"SUCCESS\",\"tranId\":11798835829,\"time\":1544433325000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/transfer/subUserHistory", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.SubaccountTransferHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region UniversalTransfer
        [Fact]
        public async void UniversalTransfer_Response()
        {
            var responseContent = "{\"tranId\":11945860693}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/universalTransfer", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.UniversalTransfer(UniversalTransferAccountType.SPOT, UniversalTransferAccountType.COIN_FUTURE, "BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryUniversalTransferHistory
        [Fact]
        public async void QueryUniversalTransferHistory_Response()
        {
            var responseContent = "[{\"tranId\":11945860693,\"fromEmail\":\"master@test.com\",\"toEmail\":\"subaccount1@test.com\",\"asset\":\"BTC\",\"amount\":\"0.1\",\"fromAccountType\":\"SPOT\",\"toAccountType\":\"COIN_FUTURE\",\"status\":\"SUCCESS\",\"createTimeStamp\":1544433325000}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/universalTransfer", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QueryUniversalTransferHistory();

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetDetailOnSubaccountsFuturesAccountV2
        [Fact]
        public async void GetDetailOnSubaccountsFuturesAccountV2_Response()
        {
            var responseContent = "{\"futureAccountResp\":{\"email\":\"abc@test.com\",\"assets\":[{\"asset\":\"USDT\",\"initialMargin\":\"0.00000000\",\"maintenanceMargin\":\"0.00000000\",\"marginBalance\":\"0.88308000\",\"maxWithdrawAmount\":\"0.88308000\",\"openOrderInitialMargin\":\"0.00000000\",\"positionInitialMargin\":\"0.00000000\",\"unrealizedProfit\":\"0.00000000\",\"walletBalance\":\"0.88308000\"}],\"canDeposit\":true,\"canTrade\":true,\"canWithdraw\":true,\"feeTier\":2,\"maxWithdrawAmount\":\"0.88308000\",\"totalInitialMargin\":\"0.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"0.88308000\",\"totalOpenOrderInitialMargin\":\"0.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"0.88308000\",\"updateTime\":1576756674610}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/sub-account/futures/account", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetDetailOnSubaccountsFuturesAccountV2("testaccount@email.com", FuturesType.USDT_MARGINED_FUTURES);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetSummaryOfSubaccountsFuturesAccountV2
        [Fact]
        public async void GetSummaryOfSubaccountsFuturesAccountV2_Response()
        {
            var responseContent = "{\"futureAccountSummaryResp\":{\"totalInitialMargin\":\"9.83137400\",\"totalMaintenanceMargin\":\"0.41568700\",\"totalMarginBalance\":\"23.03235621\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.83137400\",\"totalUnrealizedProfit\":\"0.03219710\",\"totalWalletBalance\":\"22.15879444\",\"asset\":\"USD\",\"subAccountList\":[{\"email\":\"123@test.com\",\"totalInitialMargin\":\"9.00000000\",\"totalMaintenanceMargin\":\"0.00000000\",\"totalMarginBalance\":\"22.12659734\",\"totalOpenOrderInitialMargin\":\"9.00000000\",\"totalPositionInitialMargin\":\"0.00000000\",\"totalUnrealizedProfit\":\"0.00000000\",\"totalWalletBalance\":\"22.12659734\",\"asset\":\"USD\"}]}}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/sub-account/futures/accountSummary", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetSummaryOfSubaccountsFuturesAccountV2(FuturesType.USDT_MARGINED_FUTURES);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetFuturesPositionriskOfSubaccountV2
        [Fact]
        public async void GetFuturesPositionriskOfSubaccountV2_Response()
        {
            var responseContent = "{\"futurePositionRiskVos\":[{\"entryPrice\":\"9975.12000\",\"leverage\":\"50\",\"maxNotional\":\"1000000\",\"liquidationPrice\":\"7963.54\",\"markPrice\":\"9973.50770517\",\"positionAmount\":\"0.010\",\"symbol\":\"BTCUSDT\",\"unrealizedProfit\":\"-0.01612295\"}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v2/sub-account/futures/positionRisk", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetFuturesPositionriskOfSubaccountV2("testaccount@email.com", FuturesType.USDT_MARGINED_FUTURES);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region EnableLeverageTokenForSubaccount
        [Fact]
        public async void EnableLeverageTokenForSubaccount_Response()
        {
            var responseContent = "{\"email\":\"123@test.com\",\"enableBlvt\":true}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/blvt/enable", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.EnableLeverageTokenForSubaccount("testaccount@email.com", true);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DepositAssetsIntoTheManagedSubaccount
        [Fact]
        public async void DepositAssetsIntoTheManagedSubaccount_Response()
        {
            var responseContent = "{\"tranId\":66157362489}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/managed-subaccount/deposit", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.DepositAssetsIntoTheManagedSubaccount("testaccount@email.com", "BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryManagedSubaccountAssetDetails
        [Fact]
        public async void QueryManagedSubaccountAssetDetails_Response()
        {
            var responseContent = "[{\"coin\":\"INJ\",\"name\":\"Injective Protocol\",\"totalBalance\":\"0\",\"availableBalance\":\"0\",\"inOrder\":\"0\",\"btcValue\":\"0\"}]";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/managed-subaccount/asset", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QueryManagedSubaccountAssetDetails("testaccount@email.com");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region WithdrawlAssetsFromTheManagedSubaccount
        [Fact]
        public async void WithdrawlAssetsFromTheManagedSubaccount_Response()
        {
            var responseContent = "{\"tranId\":66157362489}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/managed-subaccount/withdraw", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.WithdrawlAssetsFromTheManagedSubaccount("testaccount@email.com", "BTC", 1.01m);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region QueryManagedSubaccountSnapshot
        [Fact]
        public async void QueryManagedSubaccountSnapshot_Response()
        {
            var responseContent = "{\"code\":200,\"msg\":\"\",\"snapshotVos\":[{\"data\":{\"balances\":[{\"asset\":\"BTC\",\"free\":\"0.09905021\",\"locked\":\"0.00000000\"},{\"asset\":\"USDT\",\"free\":\"1.89109409\",\"locked\":\"0.00000000\"}],\"totalAssetOfBtc\":\"0.09942700\"},\"type\":\"spot\",\"updateTime\":1576281599000}]}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/managed-subaccount/accountSnapshot", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.QueryManagedSubaccountSnapshot("testaccount@email.com", "SPOT");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region EnableOrDisableIpRestrictionForASubaccountApiKey
        [Fact]
        public async void EnableOrDisableIpRestrictionForASubaccountApiKey_Response()
        {
            var responseContent = "{\"ipRestrict\":\"true\",\"ipList\":[\"0.0.0.0\"],\"updateTime\":1636369557189,\"apiKey\":\"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.EnableOrDisableIpRestrictionForASubaccountApiKey("testaccount@email.com", "subAccountApiKey", true);

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region GetIpRestrictionForASubaccountApiKey
        [Fact]
        public async void GetIpRestrictionForASubaccountApiKey_Response()
        {
            var responseContent = "{\"ipRestrict\":\"true\",\"ipList\":[\"\"],\"updateTime\":1636369557189,\"apiKey\":\"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction", HttpMethod.Get)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.GetIpRestrictionForASubaccountApiKey("testaccount@email.com", "subAccountApiKey");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region AddIpListForASubaccountApiKey
        [Fact]
        public async void AddIpListForASubaccountApiKey_Response()
        {
            var responseContent = "{\"ip\":\"8.34.21.1015.24.40.1\",\"updateTime\":1636369557189,\"apiKey\":\"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList", HttpMethod.Post)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.AddIpListForASubaccountApiKey("testaccount@email.com", "subAccountApiKey", "000.000.000.000");

            Assert.Equal(responseContent, result);
        }
        #endregion

        #region DeleteIpListForASubaccountApiKey
        [Fact]
        public async void DeleteIpListForASubaccountApiKey_Response()
        {
            var responseContent = "{\"ipRestrict\":\"true\",\"ipList\":[\"\"],\"updateTime\":1636369557189,\"apiKey\":\"k5V49ldtn4tszj6W3hystegdfvmGbqDzjmkCtpTvC0G74WhK7yd4rfCTo4lShf\"}";
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .SetupSendAsync("/sapi/v1/sub-account/subAccountApi/ipRestriction/ipList", HttpMethod.Delete)
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent),
                });
            SubAccount subAccount = new SubAccount(
                new HttpClient(mockMessageHandler.Object),
                apiKey: this.apiKey,
                apiSecret: this.apiSecret);

            var result = await subAccount.DeleteIpListForASubaccountApiKey("testaccount@email.com", "subAccountApiKey", "000.000.000.000");

            Assert.Equal(responseContent, result);
        }
        #endregion
    }
}