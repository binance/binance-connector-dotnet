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
using Binance.SimpleEarn.RestApi;

namespace Binance.SimpleEarn.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "GetBfusdAccountResponse", "{\"bfusdAmount\":\"100\",\"usdtProfit\":\"11.00\",\"bfusdProfit\":\"1.81\"}" },
        { "GetBfusdQuotaDetailsResponse", "{\"subscriptionQuota\":{\"leftQuota\":\"1000\"},\"fastRedemptionQuota\":{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.001\",\"freeQuota\":\"100\"},\"standardRedemptionQuota\":{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.0005\",\"redeemPeriod\":3}}" },
        { "GetBfusdQuotaDetailsResponseFastRedemptionQuota", "{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.001\",\"freeQuota\":\"100\"}" },
        { "GetBfusdQuotaDetailsResponseStandardRedemptionQuota", "{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.0005\",\"redeemPeriod\":3}" },
        { "GetBfusdQuotaDetailsResponseSubscriptionQuota", "{\"leftQuota\":\"1000\"}" },
        { "GetBfusdRateHistoryResponse", "{\"rows\":[{\"annualPercentageRate\":\"0.0418\",\"time\":1577233578000}],\"total\":\"1\"}" },
        { "GetBfusdRateHistoryResponseRowsInner", "{\"annualPercentageRate\":\"0.0418\",\"time\":1577233578000}" },
        { "GetBfusdRedemptionHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"asset\":\"BFUSD\",\"amount\":\"51\",\"receiveAsset\":\"USDT\",\"receiveAmount\":\"50\",\"fee\":\"1\",\"arrivalTime\":1575018510000,\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetBfusdRedemptionHistoryResponseRowsInner", "{\"time\":1575018510000,\"asset\":\"BFUSD\",\"amount\":\"51\",\"receiveAsset\":\"USDT\",\"receiveAmount\":\"50\",\"fee\":\"1\",\"arrivalTime\":1575018510000,\"status\":\"SUCCESS\"}" },
        { "GetBfusdRewardsHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"rewardAsset\":\"BFUSD\",\"rewardsAmount\":\"1\",\"BFUSDPosition\":\"100\",\"annualPercentageRate\":\"0.0418\"}],\"total\":1}" },
        { "GetBfusdRewardsHistoryResponseRowsInner", "{\"time\":1575018510000,\"rewardAsset\":\"BFUSD\",\"rewardsAmount\":\"1\",\"BFUSDPosition\":\"100\",\"annualPercentageRate\":\"0.0418\"}" },
        { "GetBfusdSubscriptionHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"asset\":\"USDT\",\"amount\":\"100\",\"receiveAsset\":\"BFUSD\",\"receiveAmount\":\"100\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetBfusdSubscriptionHistoryResponseRowsInner", "{\"time\":1575018510000,\"asset\":\"USDT\",\"amount\":\"100\",\"receiveAsset\":\"BFUSD\",\"receiveAmount\":\"100\",\"status\":\"SUCCESS\"}" },
        { "GetCollateralRecordResponse", "{\"rows\":[{\"amount\":\"100.00000000\",\"productId\":\"BUSD001\",\"asset\":\"USDT\",\"createTime\":1575018510000,\"type\":\"REPAY\",\"productName\":\"USDT\",\"orderId\":26055}],\"total\":\"1\"}" },
        { "GetCollateralRecordResponseRowsInner", "{\"amount\":\"100.00000000\",\"productId\":\"BUSD001\",\"asset\":\"USDT\",\"createTime\":1575018510000,\"type\":\"REPAY\",\"productName\":\"USDT\",\"orderId\":26055}" },
        { "GetFlexiblePersonalLeftQuotaResponse", "{\"leftPersonalQuota\":\"1000\"}" },
        { "GetFlexibleProductPositionResponse", "{\"rows\":[{\"totalAmount\":\"75.46000000\",\"tierAnnualPercentageRate\":{\"0-5BTC\":0.05,\"5-10BTC\":0.03},\"latestAnnualPercentageRate\":\"0.02599895\",\"yesterdayAirdropPercentageRate\":\"0.02599895\",\"asset\":\"USDT\",\"airDropAsset\":\"BETH\",\"canRedeem\":true,\"collateralAmount\":\"232.23123213\",\"productId\":\"USDT001\",\"yesterdayRealTimeRewards\":\"0.10293829\",\"cumulativeBonusRewards\":\"0.22759183\",\"cumulativeRealTimeRewards\":\"0.22759183\",\"cumulativeTotalRewards\":\"0.45459183\",\"autoSubscribe\":true}],\"total\":1}" },
        { "GetFlexibleProductPositionResponseRowsInner", "{\"totalAmount\":\"75.46000000\",\"tierAnnualPercentageRate\":{\"0-5BTC\":0.05,\"5-10BTC\":0.03},\"latestAnnualPercentageRate\":\"0.02599895\",\"yesterdayAirdropPercentageRate\":\"0.02599895\",\"asset\":\"USDT\",\"airDropAsset\":\"BETH\",\"canRedeem\":true,\"collateralAmount\":\"232.23123213\",\"productId\":\"USDT001\",\"yesterdayRealTimeRewards\":\"0.10293829\",\"cumulativeBonusRewards\":\"0.22759183\",\"cumulativeRealTimeRewards\":\"0.22759183\",\"cumulativeTotalRewards\":\"0.45459183\",\"autoSubscribe\":true}" },
        { "GetFlexibleProductPositionResponseRowsInnerTierAnnualPercentageRate", "{\"0-5BTC\":0.05,\"5-10BTC\":0.03}" },
        { "GetFlexibleRedemptionRecordResponse", "{\"rows\":[{\"amount\":\"10.54000000\",\"asset\":\"USDT\",\"time\":1577257222000,\"projectId\":\"USDT001\",\"redeemId\":40607,\"destAccount\":\"SPOT\",\"status\":\"PAID\"}],\"total\":1}" },
        { "GetFlexibleRedemptionRecordResponseRowsInner", "{\"amount\":\"10.54000000\",\"asset\":\"USDT\",\"time\":1577257222000,\"projectId\":\"USDT001\",\"redeemId\":40607,\"destAccount\":\"SPOT\",\"status\":\"PAID\"}" },
        { "GetFlexibleRewardsHistoryResponse", "{\"rows\":[{\"asset\":\"BUSD\",\"rewards\":\"0.00006408\",\"projectId\":\"USDT001\",\"type\":\"BONUS\",\"time\":1577233578000}],\"total\":2}" },
        { "GetFlexibleRewardsHistoryResponseRowsInner", "{\"asset\":\"BUSD\",\"rewards\":\"0.00006408\",\"projectId\":\"USDT001\",\"type\":\"BONUS\",\"time\":1577233578000}" },
        { "GetFlexibleSubscriptionPreviewResponse", "{\"totalAmount\":\"1232.32230982\",\"rewardAsset\":\"BUSD\",\"airDropAsset\":\"BETH\",\"estDailyBonusRewards\":\"0.22759183\",\"estDailyRealTimeRewards\":\"0.22759183\",\"estDailyAirdropRewards\":\"0.22759183\"}" },
        { "GetFlexibleSubscriptionRecordResponse", "{\"rows\":[{\"amount\":\"100.00000000\",\"asset\":\"USDT\",\"time\":1575018510000,\"purchaseId\":26055,\"productId\":\"USDT001\",\"type\":\"AUTO\",\"sourceAccount\":\"SPOT\",\"amtFromSpot\":\"30\",\"amtFromFunding\":\"70\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetFlexibleSubscriptionRecordResponseRowsInner", "{\"amount\":\"100.00000000\",\"asset\":\"USDT\",\"time\":1575018510000,\"purchaseId\":26055,\"productId\":\"USDT001\",\"type\":\"AUTO\",\"sourceAccount\":\"SPOT\",\"amtFromSpot\":\"30\",\"amtFromFunding\":\"70\",\"status\":\"SUCCESS\"}" },
        { "GetLockedPersonalLeftQuotaResponse", "{\"leftPersonalQuota\":\"1000\"}" },
        { "GetLockedProductPositionResponse", "{\"rows\":[{\"positionId\":123123,\"parentPositionId\":123122,\"projectId\":\"Axs*90\",\"asset\":\"AXS\",\"amount\":\"122.09202928\",\"purchaseTime\":1646182276000,\"duration\":\"60\",\"accrualDays\":\"4\",\"rewardAsset\":\"AXS\",\"APY\":\"0.2032\",\"rewardAmt\":\"5.17181528\",\"extraRewardAsset\":\"BNB\",\"extraRewardAPR\":\"0.0203\",\"estExtraRewardAmt\":\"5.17181528\",\"boostRewardAsset\":\"AXS\",\"boostApr\":\"0.0121\",\"totalBoostRewardAmt\":\"3.98201829\",\"nextPay\":\"1.29295383\",\"nextPayDate\":1646697600000,\"payPeriod\":\"1\",\"redeemAmountEarly\":\"2802.24068892\",\"rewardsEndDate\":1651449600000,\"deliverDate\":1651536000000,\"redeemPeriod\":\"1\",\"redeemingAmt\":\"232.2323\",\"redeemTo\":\"FLEXIBLE\",\"partialAmtDeliverDate\":1651536000000,\"canRedeemEarly\":true,\"canFastRedemption\":true,\"autoSubscribe\":true,\"type\":\"AUTO\",\"status\":\"HOLDING\",\"canReStake\":true}],\"total\":1}" },
        { "GetLockedProductPositionResponseRowsInner", "{\"positionId\":123123,\"parentPositionId\":123122,\"projectId\":\"Axs*90\",\"asset\":\"AXS\",\"amount\":\"122.09202928\",\"purchaseTime\":1646182276000,\"duration\":\"60\",\"accrualDays\":\"4\",\"rewardAsset\":\"AXS\",\"APY\":\"0.2032\",\"rewardAmt\":\"5.17181528\",\"extraRewardAsset\":\"BNB\",\"extraRewardAPR\":\"0.0203\",\"estExtraRewardAmt\":\"5.17181528\",\"boostRewardAsset\":\"AXS\",\"boostApr\":\"0.0121\",\"totalBoostRewardAmt\":\"3.98201829\",\"nextPay\":\"1.29295383\",\"nextPayDate\":1646697600000,\"payPeriod\":\"1\",\"redeemAmountEarly\":\"2802.24068892\",\"rewardsEndDate\":1651449600000,\"deliverDate\":1651536000000,\"redeemPeriod\":\"1\",\"redeemingAmt\":\"232.2323\",\"redeemTo\":\"FLEXIBLE\",\"partialAmtDeliverDate\":1651536000000,\"canRedeemEarly\":true,\"canFastRedemption\":true,\"autoSubscribe\":true,\"type\":\"AUTO\",\"status\":\"HOLDING\",\"canReStake\":true}" },
        { "GetLockedRedemptionRecordResponse", "{\"rows\":[{\"positionId\":123123,\"redeemId\":40607,\"time\":1575018510000,\"asset\":\"BNB\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\",\"originalAmount\":\"21312.23223\",\"type\":\"MATURE\",\"deliverDate\":1575018510000,\"lossAmount\":\"0.00001232\",\"isComplete\":true,\"rewardAsset\":\"AXS\",\"rewardAmt\":\"5.17181528\",\"extraRewardAsset\":\"BNB\",\"estExtraRewardAmt\":\"5.17181528\",\"status\":\"PAID\"}],\"total\":1}" },
        { "GetLockedRedemptionRecordResponseRowsInner", "{\"positionId\":123123,\"redeemId\":40607,\"time\":1575018510000,\"asset\":\"BNB\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\",\"originalAmount\":\"21312.23223\",\"type\":\"MATURE\",\"deliverDate\":1575018510000,\"lossAmount\":\"0.00001232\",\"isComplete\":true,\"rewardAsset\":\"AXS\",\"rewardAmt\":\"5.17181528\",\"extraRewardAsset\":\"BNB\",\"estExtraRewardAmt\":\"5.17181528\",\"status\":\"PAID\"}" },
        { "GetLockedRewardsHistoryResponse", "{\"rows\":[{\"positionId\":123123,\"time\":1575018510000,\"asset\":\"BNB\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\",\"type\":\"Locked Rewards\"}],\"total\":1}" },
        { "GetLockedRewardsHistoryResponseRowsInner", "{\"positionId\":123123,\"time\":1575018510000,\"asset\":\"BNB\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\",\"type\":\"Locked Rewards\"}" },
        { "GetLockedSubscriptionPreviewResponseInner", "{\"rewardAsset\":\"AXS\",\"totalRewardAmt\":\"5.17181528\",\"extraRewardAsset\":\"BNB\",\"estTotalExtraRewardAmt\":\"5.17181528\",\"boostRewardAsset\":\"AXS\",\"estDailyRewardAmt\":\"1.20928901\",\"nextPay\":\"1.29295383\",\"nextPayDate\":1646697600000,\"valueDate\":1646697600000,\"rewardsEndDate\":1651449600000,\"deliverDate\":1651536000000,\"nextSubscriptionDate\":1651536000000}" },
        { "GetLockedSubscriptionRecordResponse", "{\"rows\":[{\"positionId\":123123,\"purchaseId\":\"26055\",\"projectId\":\"Axs*90\",\"time\":1575018510000,\"asset\":\"BNB\",\"amount\":\"21312.23223\",\"lockPeriod\":\"30\",\"type\":\"AUTO\",\"sourceAccount\":\"SPOT\",\"amtFromSpot\":\"30\",\"amtFromFunding\":\"70\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetLockedSubscriptionRecordResponseRowsInner", "{\"positionId\":123123,\"purchaseId\":\"26055\",\"projectId\":\"Axs*90\",\"time\":1575018510000,\"asset\":\"BNB\",\"amount\":\"21312.23223\",\"lockPeriod\":\"30\",\"type\":\"AUTO\",\"sourceAccount\":\"SPOT\",\"amtFromSpot\":\"30\",\"amtFromFunding\":\"70\",\"status\":\"SUCCESS\"}" },
        { "GetRateHistoryResponse", "{\"rows\":[{\"productId\":\"BUSD001\",\"asset\":\"BUSD\",\"annualPercentageRate\":\"0.00006408\",\"time\":1577233578000}],\"total\":\"1\"}" },
        { "GetRateHistoryResponseRowsInner", "{\"productId\":\"BUSD001\",\"asset\":\"BUSD\",\"annualPercentageRate\":\"0.00006408\",\"time\":1577233578000}" },
        { "GetRwusdAccountResponse", "{\"rwusdAmount\":\"100\",\"totalProfit\":\"12.81\"}" },
        { "GetRwusdQuotaDetailsResponse", "{\"subscriptionQuota\":{\"assets\":[\"x\"],\"leftQuota\":\"1000\",\"minimum\":\"0.10000000\"},\"fastRedemptionQuota\":{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.0005\",\"freeQuota\":\"100\"},\"standardRedemptionQuota\":{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.001\",\"redeemPeriod\":3},\"subscribeEnable\":true,\"redeemEnable\":true}" },
        { "GetRwusdQuotaDetailsResponseFastRedemptionQuota", "{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.0005\",\"freeQuota\":\"100\"}" },
        { "GetRwusdQuotaDetailsResponseStandardRedemptionQuota", "{\"leftQuota\":\"2\",\"minimum\":\"0.1\",\"fee\":\"0.001\",\"redeemPeriod\":3}" },
        { "GetRwusdQuotaDetailsResponseSubscriptionQuota", "{\"assets\":[\"x\"],\"leftQuota\":\"1000\",\"minimum\":\"0.10000000\"}" },
        { "GetRwusdRateHistoryResponse", "{\"rows\":[{\"annualPercentageRate\":\"0.0418\",\"time\":1577233578000}],\"total\":\"1\"}" },
        { "GetRwusdRateHistoryResponseRowsInner", "{\"annualPercentageRate\":\"0.0418\",\"time\":1577233578000}" },
        { "GetRwusdRedemptionHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"asset\":\"RWUSD\",\"amount\":\"51\",\"receiveAsset\":\"USDC\",\"receiveAmount\":\"50\",\"fee\":\"1\",\"arrivalTime\":1575018510000,\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetRwusdRedemptionHistoryResponseRowsInner", "{\"time\":1575018510000,\"asset\":\"RWUSD\",\"amount\":\"51\",\"receiveAsset\":\"USDC\",\"receiveAmount\":\"50\",\"fee\":\"1\",\"arrivalTime\":1575018510000,\"status\":\"SUCCESS\"}" },
        { "GetRwusdRewardsHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"rewardsAmount\":\"1\",\"rwusdPosition\":\"100\",\"annualPercentageRate\":\"0.0418\"}],\"total\":1}" },
        { "GetRwusdRewardsHistoryResponseRowsInner", "{\"time\":1575018510000,\"rewardsAmount\":\"1\",\"rwusdPosition\":\"100\",\"annualPercentageRate\":\"0.0418\"}" },
        { "GetRwusdSubscriptionHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"asset\":\"USDC\",\"amount\":\"100\",\"receiveAsset\":\"RWUSD\",\"receiveAmount\":\"100\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetRwusdSubscriptionHistoryResponseRowsInner", "{\"time\":1575018510000,\"asset\":\"USDC\",\"amount\":\"100\",\"receiveAsset\":\"RWUSD\",\"receiveAmount\":\"100\",\"status\":\"SUCCESS\"}" },
        { "GetSimpleEarnFlexibleProductListResponse", "{\"rows\":[{\"asset\":\"BTC\",\"latestAnnualPercentageRate\":\"0.05000000\",\"tierAnnualPercentageRate\":{\"0-5BTC\":0.05,\"5-10BTC\":0.03},\"airDropPercentageRate\":\"0.05000000\",\"canPurchase\":true,\"canRedeem\":true,\"isSoldOut\":true,\"hot\":true,\"minPurchaseAmount\":\"0.01000000\",\"productId\":\"BTC001\",\"subscriptionStartTime\":1646182276000,\"status\":\"PURCHASING\"}],\"total\":1}" },
        { "GetSimpleEarnFlexibleProductListResponseRowsInner", "{\"asset\":\"BTC\",\"latestAnnualPercentageRate\":\"0.05000000\",\"tierAnnualPercentageRate\":{\"0-5BTC\":0.05,\"5-10BTC\":0.03},\"airDropPercentageRate\":\"0.05000000\",\"canPurchase\":true,\"canRedeem\":true,\"isSoldOut\":true,\"hot\":true,\"minPurchaseAmount\":\"0.01000000\",\"productId\":\"BTC001\",\"subscriptionStartTime\":1646182276000,\"status\":\"PURCHASING\"}" },
        { "GetSimpleEarnLockedProductListResponse", "{\"rows\":[{\"projectId\":\"Axs*90\",\"detail\":{\"asset\":\"AXS\",\"rewardAsset\":\"AXS\",\"duration\":90,\"renewable\":true,\"isSoldOut\":true,\"apr\":\"1.2069\",\"status\":\"CREATED\",\"subscriptionStartTime\":1646182276000,\"extraRewardAsset\":\"BNB\",\"extraRewardAPR\":\"0.23\",\"boostRewardAsset\":\"AXS\",\"boostApr\":\"0.0121\",\"boostEndTime\":1646182276000},\"quota\":{\"totalPersonalQuota\":\"2\",\"minimum\":\"0.001\"}}],\"total\":1}" },
        { "GetSimpleEarnLockedProductListResponseRowsInner", "{\"projectId\":\"Axs*90\",\"detail\":{\"asset\":\"AXS\",\"rewardAsset\":\"AXS\",\"duration\":90,\"renewable\":true,\"isSoldOut\":true,\"apr\":\"1.2069\",\"status\":\"CREATED\",\"subscriptionStartTime\":1646182276000,\"extraRewardAsset\":\"BNB\",\"extraRewardAPR\":\"0.23\",\"boostRewardAsset\":\"AXS\",\"boostApr\":\"0.0121\",\"boostEndTime\":1646182276000},\"quota\":{\"totalPersonalQuota\":\"2\",\"minimum\":\"0.001\"}}" },
        { "GetSimpleEarnLockedProductListResponseRowsInnerDetail", "{\"asset\":\"AXS\",\"rewardAsset\":\"AXS\",\"duration\":90,\"renewable\":true,\"isSoldOut\":true,\"apr\":\"1.2069\",\"status\":\"CREATED\",\"subscriptionStartTime\":1646182276000,\"extraRewardAsset\":\"BNB\",\"extraRewardAPR\":\"0.23\",\"boostRewardAsset\":\"AXS\",\"boostApr\":\"0.0121\",\"boostEndTime\":1646182276000}" },
        { "GetSimpleEarnLockedProductListResponseRowsInnerQuota", "{\"totalPersonalQuota\":\"2\",\"minimum\":\"0.001\"}" },
        { "GetYieldArenaActivitiesResponse", "{\"activities\":[{\"activityId\":10001,\"activityType\":\"AIRDROP\",\"title\":\"Hold FDUSD & Earn BNB Airdrop\",\"description\":\"Subscribe to FDUSD Flexible and earn bonus BNB airdrop.\",\"rewardPoolInUsd\":\"50000\",\"rewardToken\":[\"x\"],\"redirectUrl\":\"https://www.binance.com/en/earn/arena/airdrop-123\",\"startTime\":1713052800000,\"endTime\":1713657600000}]}" },
        { "GetYieldArenaActivitiesResponseActivitiesInner", "{\"activityId\":10001,\"activityType\":\"AIRDROP\",\"title\":\"Hold FDUSD & Earn BNB Airdrop\",\"description\":\"Subscribe to FDUSD Flexible and earn bonus BNB airdrop.\",\"rewardPoolInUsd\":\"50000\",\"rewardToken\":[\"x\"],\"redirectUrl\":\"https://www.binance.com/en/earn/arena/airdrop-123\",\"startTime\":1713052800000,\"endTime\":1713657600000}" },
        { "RedeemBfusdResponse", "{\"success\":true,\"receiveAmount\":\"0.23092091\",\"fee\":\"0.00000012\",\"arrivalTime\":1575018510000}" },
        { "RedeemFlexibleProductResponse", "{\"redeemId\":40607,\"success\":true}" },
        { "RedeemLockedProductResponse", "{\"redeemId\":40607,\"success\":true}" },
        { "RedeemRwusdResponse", "{\"success\":true,\"receiveAmount\":\"0.23092091\",\"fee\":\"0.00000012\",\"arrivalTime\":1575018510000}" },
        { "SetFlexibleAutoSubscribeResponse", "{\"success\":true}" },
        { "SetLockedAutoSubscribeResponse", "{\"success\":true}" },
        { "SetLockedProductRedeemOptionResponse", "{\"success\":true}" },
        { "SimpleAccountResponse", "{\"totalAmountInBTC\":\"0.01067982\",\"totalAmountInUSDT\":\"77.13289230\",\"totalFlexibleAmountInBTC\":\"0.00000000\",\"totalFlexibleAmountInUSDT\":\"0.00000000\",\"totalLockedInBTC\":\"0.01067982\",\"totalLockedInUSDT\":\"77.13289230\"}" },
        { "SubscribeBfusdResponse", "{\"success\":true,\"bfusdAmount\":\"0.22091092\"}" },
        { "SubscribeFlexibleProductResponse", "{\"purchaseId\":40607,\"success\":true}" },
        { "SubscribeLockedProductResponse", "{\"purchaseId\":40607,\"positionId\":\"12345\",\"success\":true}" },
        { "SubscribeRwusdResponse", "{\"success\":true,\"rwusdAmount\":\"0.22091092\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(SimpleEarnRestApi).Assembly;
        var type = assembly.GetType($"Binance.SimpleEarn.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.SimpleEarn.RestApi.SimpleEarnRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
