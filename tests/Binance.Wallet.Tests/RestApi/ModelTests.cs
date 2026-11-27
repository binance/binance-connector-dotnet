//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common.Tests;
using Binance.Wallet.RestApi;

namespace Binance.Wallet.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "AccountApiTradingStatusResponse", "{\"data\":{\"isLocked\":false,\"plannedRecoverTime\":0,\"triggerCondition\":{\"GCR\":150,\"IFER\":150,\"UFR\":300},\"updateTime\":1547630471725}}" },
        { "AccountApiTradingStatusResponseData", "{\"isLocked\":false,\"plannedRecoverTime\":0,\"triggerCondition\":{\"GCR\":150,\"IFER\":150,\"UFR\":300},\"updateTime\":1547630471725}" },
        { "AccountApiTradingStatusResponseDataTriggerCondition", "{\"GCR\":150,\"IFER\":150,\"UFR\":300}" },
        { "AccountInfoResponse", "{\"vipLevel\":0,\"isMarginEnabled\":true,\"isFutureEnabled\":true,\"isOptionsEnabled\":true,\"isPortfolioMarginRetailEnabled\":true}" },
        { "AccountStatusResponse", "{\"data\":\"Normal\"}" },
        { "AllCoinsInformationResponseInner", "{\"coin\":\"1MBABYDOGE\",\"depositAllEnable\":true,\"withdrawAllEnable\":true,\"name\":\"1M x BABYDOGE\",\"free\":\"34941.1\",\"locked\":\"0\",\"freeze\":\"0\",\"withdrawing\":\"0\",\"ipoing\":\"0\",\"ipoable\":\"0\",\"storage\":\"0\",\"isLegalMoney\":false,\"trading\":true,\"networkList\":[{\"network\":\"BSC\",\"coin\":\"1MBABYDOGE\",\"withdrawIntegerMultiple\":\"0.01\",\"isDefault\":false,\"depositEnable\":true,\"withdrawEnable\":true,\"depositDesc\":\"x\",\"withdrawDesc\":\"x\",\"specialTips\":\"x\",\"specialWithdrawTips\":\"x\",\"name\":\"BNB Smart Chain (BEP20)\",\"resetAddressStatus\":false,\"addressRegex\":\"^(0x)[0-9A-Fa-f]{40}$\",\"memoRegex\":\"x\",\"withdrawFee\":\"10\",\"withdrawMin\":\"20\",\"withdrawMax\":\"9999999999\",\"withdrawInternalMin\":\"0.01\",\"depositDust\":\"0.01\",\"minConfirm\":5,\"unLockConfirm\":0,\"sameAddress\":false,\"withdrawTag\":false,\"estimatedArrivalTime\":1,\"busy\":false,\"contractAddressUrl\":\"https://bscscan.com/token/\",\"contractAddress\":\"0xc748673057861a797275cd8a068abb95a902e8de\",\"denomination\":1000000}]}" },
        { "AllCoinsInformationResponseInnerNetworkListInner", "{\"network\":\"BSC\",\"coin\":\"1MBABYDOGE\",\"withdrawIntegerMultiple\":\"0.01\",\"isDefault\":false,\"depositEnable\":true,\"withdrawEnable\":true,\"depositDesc\":\"x\",\"withdrawDesc\":\"x\",\"specialTips\":\"x\",\"specialWithdrawTips\":\"x\",\"name\":\"BNB Smart Chain (BEP20)\",\"resetAddressStatus\":false,\"addressRegex\":\"^(0x)[0-9A-Fa-f]{40}$\",\"memoRegex\":\"x\",\"withdrawFee\":\"10\",\"withdrawMin\":\"20\",\"withdrawMax\":\"9999999999\",\"withdrawInternalMin\":\"0.01\",\"depositDust\":\"0.01\",\"minConfirm\":5,\"unLockConfirm\":0,\"sameAddress\":false,\"withdrawTag\":false,\"estimatedArrivalTime\":1,\"busy\":false,\"contractAddressUrl\":\"https://bscscan.com/token/\",\"contractAddress\":\"0xc748673057861a797275cd8a068abb95a902e8de\",\"denomination\":1000000}" },
        { "AssetDetailResponse", "{\"CTR\":{\"minWithdrawAmount\":\"70.00000000\",\"depositStatus\":false,\"withdrawFee\":35,\"withdrawStatus\":true,\"depositTip\":\"Delisted, Deposit Suspended\"},\"SKY\":{\"minWithdrawAmount\":\"0.02000000\",\"depositStatus\":true,\"withdrawFee\":0.01,\"withdrawStatus\":true}}" },
        { "AssetDetailResponseCTR", "{\"minWithdrawAmount\":\"70.00000000\",\"depositStatus\":false,\"withdrawFee\":35,\"withdrawStatus\":true,\"depositTip\":\"Delisted, Deposit Suspended\"}" },
        { "AssetDetailResponseSKY", "{\"minWithdrawAmount\":\"0.02000000\",\"depositStatus\":true,\"withdrawFee\":0.01,\"withdrawStatus\":true}" },
        { "AssetDividendRecordResponse", "{\"rows\":[{\"id\":1637366104,\"amount\":\"10.00000000\",\"asset\":\"BHFT\",\"divTime\":1563189166000,\"enInfo\":\"BHFT distribution\",\"tranId\":2968885920,\"direction\":1}],\"total\":2}" },
        { "AssetDividendRecordResponseRowsInner", "{\"id\":1637366104,\"amount\":\"10.00000000\",\"asset\":\"BHFT\",\"divTime\":1563189166000,\"enInfo\":\"BHFT distribution\",\"tranId\":2968885920,\"direction\":1}" },
        { "BrokerWithdrawResponse", "{\"trId\":123456,\"accepted\":true,\"info\":\"Withdraw request accepted\"}" },
        { "CheckQuestionnaireRequirementsResponse", "{\"questionnaireCountryCode\":\"AE\"}" },
        { "DailyAccountSnapshotResponse", "{\"code\":200,\"msg\":\"x\",\"snapshotVos\":[{\"data\":{\"balances\":[{\"asset\":\"BTC\",\"free\":\"0.09905021\",\"locked\":\"0.00000000\"}],\"totalAssetOfBtc\":\"0.09942700\",\"marginLevel\":\"2748.02909813\",\"totalLiabilityOfBtc\":\"0.00000100\",\"totalNetAssetOfBtc\":\"0.00274750\",\"userAssets\":[{\"asset\":\"XRP\",\"borrowed\":\"0.00000000\",\"free\":\"1.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"1.00000000\"}],\"assets\":[{\"asset\":\"USDT\",\"marginBalance\":\"118.99782335\",\"walletBalance\":\"120.23811389\"}],\"position\":[{\"entryPrice\":\"7130.41000000\",\"markPrice\":\"7257.66239673\",\"positionAmt\":\"0.01000000\",\"symbol\":\"BTCUSDT\",\"unRealizedProfit\":\"1.24029054\"}]},\"type\":\"spot\",\"updateTime\":1576281599000}]}" },
        { "DailyAccountSnapshotResponseSnapshotVosInner", "{\"data\":{\"balances\":[{\"asset\":\"BTC\",\"free\":\"0.09905021\",\"locked\":\"0.00000000\"}],\"totalAssetOfBtc\":\"0.09942700\",\"marginLevel\":\"2748.02909813\",\"totalLiabilityOfBtc\":\"0.00000100\",\"totalNetAssetOfBtc\":\"0.00274750\",\"userAssets\":[{\"asset\":\"XRP\",\"borrowed\":\"0.00000000\",\"free\":\"1.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"1.00000000\"}],\"assets\":[{\"asset\":\"USDT\",\"marginBalance\":\"118.99782335\",\"walletBalance\":\"120.23811389\"}],\"position\":[{\"entryPrice\":\"7130.41000000\",\"markPrice\":\"7257.66239673\",\"positionAmt\":\"0.01000000\",\"symbol\":\"BTCUSDT\",\"unRealizedProfit\":\"1.24029054\"}]},\"type\":\"spot\",\"updateTime\":1576281599000}" },
        { "DailyAccountSnapshotResponseSnapshotVosInnerData", "{\"balances\":[{\"asset\":\"BTC\",\"free\":\"0.09905021\",\"locked\":\"0.00000000\"}],\"totalAssetOfBtc\":\"0.09942700\",\"marginLevel\":\"2748.02909813\",\"totalLiabilityOfBtc\":\"0.00000100\",\"totalNetAssetOfBtc\":\"0.00274750\",\"userAssets\":[{\"asset\":\"XRP\",\"borrowed\":\"0.00000000\",\"free\":\"1.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"1.00000000\"}],\"assets\":[{\"asset\":\"USDT\",\"marginBalance\":\"118.99782335\",\"walletBalance\":\"120.23811389\"}],\"position\":[{\"entryPrice\":\"7130.41000000\",\"markPrice\":\"7257.66239673\",\"positionAmt\":\"0.01000000\",\"symbol\":\"BTCUSDT\",\"unRealizedProfit\":\"1.24029054\"}]}" },
        { "DailyAccountSnapshotResponseSnapshotVosInnerDataAssetsInner", "{\"asset\":\"USDT\",\"marginBalance\":\"118.99782335\",\"walletBalance\":\"120.23811389\"}" },
        { "DailyAccountSnapshotResponseSnapshotVosInnerDataBalancesInner", "{\"asset\":\"BTC\",\"free\":\"0.09905021\",\"locked\":\"0.00000000\"}" },
        { "DailyAccountSnapshotResponseSnapshotVosInnerDataPositionInner", "{\"entryPrice\":\"7130.41000000\",\"markPrice\":\"7257.66239673\",\"positionAmt\":\"0.01000000\",\"symbol\":\"BTCUSDT\",\"unRealizedProfit\":\"1.24029054\"}" },
        { "DailyAccountSnapshotResponseSnapshotVosInnerDataUserAssetsInner", "{\"asset\":\"XRP\",\"borrowed\":\"0.00000000\",\"free\":\"1.00000000\",\"interest\":\"0.00000000\",\"locked\":\"0.00000000\",\"netAsset\":\"1.00000000\"}" },
        { "DepositAddressResponse", "{\"address\":\"1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv\",\"coin\":\"BTC\",\"tag\":\"x\",\"url\":\"https://btc.com/1HPn8Rx2y6nNSfagQBKy27GB99Vbzg89wv\"}" },
        { "DepositHistoryResponseInner", "{\"id\":\"769800519366885376\",\"amount\":\"0.001\",\"coin\":\"BNB\",\"network\":\"BNB\",\"status\":1,\"address\":\"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23\",\"addressTag\":\"101764890\",\"txId\":\"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC\",\"insertTime\":1661493146000,\"completeTime\":1661493146000,\"transferType\":0,\"confirmTimes\":\"1/1\",\"unlockConfirm\":0,\"walletType\":0,\"travelRuleStatus\":0}" },
        { "DepositHistoryTravelRuleResponseInner", "{\"trId\":123451123,\"tranId\":17644346245865,\"amount\":\"0.001\",\"coin\":\"BNB\",\"network\":\"BNB\",\"depositStatus\":0,\"travelRuleStatus\":1,\"travelRuleStatusV2\":\"PENDING\",\"address\":\"bnb136ns6lfw4zs5hg4n85vdthaad7hq5m4gtkgf23\",\"addressTag\":\"101764890\",\"txId\":\"98A3EA560C6B3336D348B6C83F0F95ECE4F1F5919E94BD006E5BF3BF264FACFC\",\"insertTime\":1661493146000,\"completeTime\":1661493206000,\"transferType\":0,\"confirmTimes\":\"1/1\",\"requireQuestionnaire\":false,\"questionnaire\":\"{\\\"question1\\\":\\\"answer1\\\",\\\"question2\\\":\\\"answer2\\\"}\"}" },
        { "DepositHistoryV2ResponseInner", "{\"depositId\":\"4615328107052018945\",\"amount\":\"0.01\",\"network\":\"AVAXC\",\"coin\":\"AVAX\",\"depositStatus\":1,\"travelRuleReqStatus\":0,\"address\":\"0x0010627ab66d69232f4080d54e0f838b4dc3894a\",\"addressTag\":\"x\",\"txId\":\"0xdde578983015741eed764e7ca10defb5a2caafdca3db5f92872d24a96beb1879\",\"transferType\":0,\"confirmTimes\":\"12/12\",\"requireQuestionnaire\":false,\"questionnaire\":{\"vaspName\":\"BINANCE\",\"depositOriginator\":0},\"insertTime\":1753053392000}" },
        { "DepositHistoryV2ResponseInnerQuestionnaire", "{\"vaspName\":\"BINANCE\",\"depositOriginator\":0}" },
        { "DustConvertResponse", "{\"totalTransfered\":\"3.5971223\",\"totalServiceCharge\":\"0.0794964\",\"transferResult\":[{\"tranId\":2987331510,\"fromAsset\":\"USDT\",\"amount\":\"1\",\"transferedAmount\":\"3.5971223\",\"serviceChargeAmount\":\"0.0794964\",\"operateTime\":1765212029749}]}" },
        { "DustConvertResponseTransferResultInner", "{\"tranId\":2987331510,\"fromAsset\":\"USDT\",\"amount\":\"1\",\"transferedAmount\":\"3.5971223\",\"serviceChargeAmount\":\"0.0794964\",\"operateTime\":1765212029749}" },
        { "DustConvertibleAssetsResponse", "{\"dribbletPercentage\":\"0.02\",\"totalTransferQuotaAssetAmount\":\"0.7899968\",\"totalTransferTargetAssetAmount\":\"0.7899968\",\"dribbletBase\":\"10\",\"details\":[{\"asset\":\"AR\",\"assetFullName\":\"AR\",\"amountFree\":\"0.00856\",\"exchange\":\"0.00073616\",\"toQuotaAssetAmount\":\"0.036808\",\"toTargetAssetAmount\":\"0.036808\",\"toTargetAssetOffExchange\":\"0.03607184\"}]}" },
        { "DustConvertibleAssetsResponseDetailsInner", "{\"asset\":\"AR\",\"assetFullName\":\"AR\",\"amountFree\":\"0.00856\",\"exchange\":\"0.00073616\",\"toQuotaAssetAmount\":\"0.036808\",\"toTargetAssetAmount\":\"0.036808\",\"toTargetAssetOffExchange\":\"0.03607184\"}" },
        { "DustTransferResponse", "{\"totalServiceCharge\":\"0.02102542\",\"totalTransfered\":\"1.05127099\",\"transferResult\":[{\"amount\":\"0.03000000\",\"fromAsset\":\"ETH\",\"operateTime\":1563368549307,\"serviceChargeAmount\":\"0.00500000\",\"tranId\":2970932918,\"transferedAmount\":\"0.25000000\"}]}" },
        { "DustTransferResponseTransferResultInner", "{\"amount\":\"0.03000000\",\"fromAsset\":\"ETH\",\"operateTime\":1563368549307,\"serviceChargeAmount\":\"0.00500000\",\"tranId\":2970932918,\"transferedAmount\":\"0.25000000\"}" },
        { "DustlogResponse", "{\"total\":8,\"userAssetDribblets\":[{\"operateTime\":1615985535000,\"totalTransferedAmount\":\"0.00132256\",\"totalServiceChargeAmount\":\"0.00002699\",\"transId\":45178372831,\"userAssetDribbletDetails\":[{\"transId\":4359321,\"serviceChargeAmount\":\"0.000009\",\"amount\":\"0.0009\",\"operateTime\":1615985535000,\"transferedAmount\":\"0.000441\",\"fromAsset\":\"USDT\",\"targetAsset\":\"BNB\"}]}]}" },
        { "DustlogResponseUserAssetDribbletsInner", "{\"operateTime\":1615985535000,\"totalTransferedAmount\":\"0.00132256\",\"totalServiceChargeAmount\":\"0.00002699\",\"transId\":45178372831,\"userAssetDribbletDetails\":[{\"transId\":4359321,\"serviceChargeAmount\":\"0.000009\",\"amount\":\"0.0009\",\"operateTime\":1615985535000,\"transferedAmount\":\"0.000441\",\"fromAsset\":\"USDT\",\"targetAsset\":\"BNB\"}]}" },
        { "DustlogResponseUserAssetDribbletsInnerUserAssetDribbletDetailsInner", "{\"transId\":4359321,\"serviceChargeAmount\":\"0.000009\",\"amount\":\"0.0009\",\"operateTime\":1615985535000,\"transferedAmount\":\"0.000441\",\"fromAsset\":\"USDT\",\"targetAsset\":\"BNB\"}" },
        { "FetchAddressVerificationListResponseInner", "{\"status\":\"PENDING\",\"token\":\"AVAX\",\"network\":\"AVAXC\",\"walletAddress\":\"0xc03a6aa728a8dde7464c33828424ede7553a0021\",\"addressQuestionnaire\":{\"sendTo\":1,\"satoshiToken\":\"AVAX\",\"isAddressOwner\":1,\"verifyMethod\":1}}" },
        { "FetchAddressVerificationListResponseInnerAddressQuestionnaire", "{\"sendTo\":1,\"satoshiToken\":\"AVAX\",\"isAddressOwner\":1,\"verifyMethod\":1}" },
        { "FetchDepositAddressListWithNetworkResponseInner", "{\"coin\":\"ETH\",\"address\":\"0xD316E95Fd9E8E237Cb11f8200Babbc5D8D177BA4\",\"tag\":\"x\",\"isDefault\":0}" },
        { "FetchWithdrawAddressListResponseInner", "{\"address\":\"1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa\",\"addressTag\":\"x\",\"coin\":\"BTC\",\"name\":\"Satoshi\",\"network\":\"BTC\",\"origin\":\"bla\",\"originType\":\"others\",\"whiteStatus\":true}" },
        { "FetchWithdrawQuotaResponse", "{\"wdQuota\":\"10000\",\"usedWdQuota\":\"1000\"}" },
        { "FundingWalletResponseInner", "{\"asset\":\"USDT\",\"free\":\"1\",\"locked\":\"0\",\"freeze\":\"0\",\"withdrawing\":\"0\",\"btcValuation\":\"0.00000091\"}" },
        { "GetApiKeyPermissionResponse", "{\"ipRestrict\":false,\"createTime\":1623840271000,\"enableReading\":true,\"enableWithdrawals\":false,\"enableInternalTransfer\":true,\"enableMargin\":false,\"enableFutures\":false,\"permitsUniversalTransfer\":true,\"enableVanillaOptions\":false,\"enableFixApiTrade\":false,\"enableFixReadOnly\":true,\"enableSpotAndMarginTrading\":false,\"enablePortfolioMarginTrading\":true}" },
        { "GetAssetsThatCanBeConvertedIntoBnbResponse", "{\"details\":[{\"asset\":\"ADA\",\"assetFullName\":\"ADA\",\"amountFree\":\"6.21\",\"toBTC\":\"0.00016848\",\"toBNB\":\"0.01777302\",\"toBNBOffExchange\":\"0.01741756\",\"exchange\":\"0.00035546\"}],\"totalTransferBtc\":\"0.00016848\",\"totalTransferBNB\":\"0.01777302\",\"dribbletPercentage\":\"0.02\"}" },
        { "GetAssetsThatCanBeConvertedIntoBnbResponseDetailsInner", "{\"asset\":\"ADA\",\"assetFullName\":\"ADA\",\"amountFree\":\"6.21\",\"toBTC\":\"0.00016848\",\"toBNB\":\"0.01777302\",\"toBNBOffExchange\":\"0.01741756\",\"exchange\":\"0.00035546\"}" },
        { "GetCloudMiningPaymentAndRefundHistoryResponse", "{\"total\":5,\"rows\":[{\"createTime\":1667880112000,\"tranId\":121230610120,\"type\":248,\"asset\":\"USDT\",\"amount\":\"25.0068\",\"status\":\"S\"}]}" },
        { "GetCloudMiningPaymentAndRefundHistoryResponseRowsInner", "{\"createTime\":1667880112000,\"tranId\":121230610120,\"type\":248,\"asset\":\"USDT\",\"amount\":\"25.0068\",\"status\":\"S\"}" },
        { "GetCountryListResponse", "{\"countries\":[{\"countryCode\":\"au\",\"countryName\":\"Australia\",\"blockType\":\"supported\",\"depositAllowed\":true,\"withdrawalAllowed\":true,\"hasRegionRestrictions\":false}],\"lastUpdated\":1716300000000}" },
        { "GetCountryListResponseCountriesInner", "{\"countryCode\":\"au\",\"countryName\":\"Australia\",\"blockType\":\"supported\",\"depositAllowed\":true,\"withdrawalAllowed\":true,\"hasRegionRestrictions\":false}" },
        { "GetOpenSymbolListResponseInner", "{\"openTime\":1686161202000,\"symbols\":[\"x\"]}" },
        { "GetRegionListResponse", "{\"countryCode\":\"au\",\"regions\":[{\"regionName\":\"New South Wales\",\"blockType\":\"supported\",\"depositAllowed\":true,\"withdrawalAllowed\":true}],\"lastUpdated\":1716300000000}" },
        { "GetRegionListResponseRegionsInner", "{\"regionName\":\"New South Wales\",\"blockType\":\"supported\",\"depositAllowed\":true,\"withdrawalAllowed\":true}" },
        { "GetSpotAssetTagsResponseInner", "{\"assetCode\":\"BNB\",\"assetName\":\"BNB\",\"trading\":true,\"tags\":[\"x\"]}" },
        { "GetSymbolsDelistScheduleForSpotResponseInner", "{\"delistTime\":1686161202000,\"symbols\":[\"x\"]}" },
        { "OneClickArrivalDepositApplyResponse", "{\"code\":\"000000\",\"message\":\"success\",\"data\":true,\"success\":true}" },
        { "QueryUserDelegationHistoryResponse", "{\"total\":3316,\"rows\":[{\"clientTranId\":\"293915932290879488\",\"transferType\":\"Undelegate\",\"asset\":\"ETH\",\"amount\":\"1\",\"time\":1695205406000}]}" },
        { "QueryUserDelegationHistoryResponseRowsInner", "{\"clientTranId\":\"293915932290879488\",\"transferType\":\"Undelegate\",\"asset\":\"ETH\",\"amount\":\"1\",\"time\":1695205406000}" },
        { "QueryUserUniversalTransferHistoryResponse", "{\"total\":2,\"rows\":[{\"asset\":\"USDT\",\"amount\":\"1\",\"type\":\"MAIN_UMFUTURE\",\"status\":\"CONFIRMED\",\"tranId\":11415955596,\"timestamp\":1544433328000}]}" },
        { "QueryUserUniversalTransferHistoryResponseRowsInner", "{\"asset\":\"USDT\",\"amount\":\"1\",\"type\":\"MAIN_UMFUTURE\",\"status\":\"CONFIRMED\",\"tranId\":11415955596,\"timestamp\":1544433328000}" },
        { "QueryUserWalletBalanceResponseInner", "{\"activate\":true,\"balance\":\"0\",\"walletName\":\"Spot\",\"assetBalances\":[{\"asset\":\"USDT\",\"assetName\":\"TetherUS\",\"free\":\"6.238383\",\"locked\":\"0\",\"freeze\":\"0\",\"withdrawing\":\"0\",\"btcValuation\":\"6.238383\"}]}" },
        { "QueryUserWalletBalanceResponseInnerAssetBalancesInner", "{\"asset\":\"USDT\",\"assetName\":\"TetherUS\",\"free\":\"6.238383\",\"locked\":\"0\",\"freeze\":\"0\",\"withdrawing\":\"0\",\"btcValuation\":\"6.238383\"}" },
        { "SubmitDepositQuestionnaireResponse", "{\"trId\":765127651,\"accepted\":true,\"info\":\"Deposit questionnaire accepted.\"}" },
        { "SubmitDepositQuestionnaireTravelRuleResponse", "{\"trId\":765127651,\"accepted\":true,\"info\":\"Deposit questionnaire accepted.\"}" },
        { "SubmitDepositQuestionnaireV2Response", "{\"trId\":765127651,\"accepted\":true,\"info\":\"Deposit questionnaire accepted.\"}" },
        { "SystemStatusResponse", "{\"status\":0,\"msg\":\"normal\"}" },
        { "ToggleBnbBurnOnSpotTradeAndMarginInterestResponse", "{\"spotBNBBurn\":true,\"interestBNBBurn\":false}" },
        { "TradeFeeResponseInner", "{\"symbol\":\"ADABNB\",\"makerCommission\":\"0.001\",\"takerCommission\":\"0.001\"}" },
        { "UserAssetResponseInner", "{\"asset\":\"AVAX\",\"free\":\"1\",\"locked\":\"0\",\"freeze\":\"0\",\"withdrawing\":\"0\",\"ipoable\":\"0\",\"btcValuation\":\"0\"}" },
        { "UserUniversalTransferResponse", "{\"tranId\":13526853623}" },
        { "VaspListResponseInner", "{\"vaspName\":\"Binance\",\"vaspCode\":\"BINANCE\",\"identifier\":\"xxx\"}" },
        { "WithdrawHistoryResponseInner", "{\"id\":\"b6ae22b3aa844210a7041aee7589627c\",\"amount\":\"8.91000000\",\"transactionFee\":\"0.004\",\"coin\":\"USDT\",\"status\":6,\"address\":\"0x94df8b352de7f46f64b01d3666bf6e936e44ce60\",\"txId\":\"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268\",\"applyTime\":\"2019-10-12 11:12:02\",\"network\":\"ETH\",\"transferType\":0,\"withdrawOrderId\":\"WITHDRAWtest123\",\"info\":\"The address is not valid. Please confirm with the recipient\",\"confirmNo\":3,\"walletType\":1,\"txKey\":\"x\",\"completeTime\":\"2023-03-23 16:52:41\"}" },
        { "WithdrawHistoryV1ResponseInner", "{\"id\":\"b6ae22b3aa844210a7041aee7589627c\",\"trId\":1234456,\"amount\":\"8.91000000\",\"transactionFee\":\"0.004\",\"coin\":\"USDT\",\"withdrawalStatus\":6,\"travelRuleStatus\":0,\"address\":\"0x94df8b352de7f46f64b01d3666bf6e936e44ce60\",\"txId\":\"0xb5ef8c13b968a406cc62a93a8bd80f9e9a906ef1b3fcf20a2e48573c17659268\",\"applyTime\":\"2019-10-12 11:12:02\",\"network\":\"ETH\",\"transferType\":0,\"withdrawOrderId\":\"WITHDRAWtest123\",\"info\":\"The address is not valid. Please confirm with the recipient\",\"confirmNo\":3,\"walletType\":1,\"txKey\":\"x\",\"questionnaire\":\"{\\\"question1\\\":\\\"answer1\\\",\\\"question2\\\":\\\"answer2\\\"}\",\"completeTime\":\"2023-03-23 16:52:41\"}" },
        { "WithdrawResponse", "{\"id\":\"7213fea8e94b4a5593d507237e5a555b\"}" },
        { "WithdrawTravelRuleResponse", "{\"trId\":123456,\"accepted\":true,\"info\":\"Withdraw request accepted\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(WalletRestApi).Assembly;
        var type = assembly.GetType($"Binance.Wallet.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Wallet.RestApi.WalletRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
