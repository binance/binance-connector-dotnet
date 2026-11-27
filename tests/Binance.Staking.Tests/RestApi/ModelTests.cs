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
using Binance.Staking.RestApi;

namespace Binance.Staking.Tests.RestApi;

/// <summary>Decodes an instance of every model, built from its schema, with the serializer context of the module.</summary>
public class ModelTests
{
    private static readonly JsonSerializerOptions Reflection = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };

    public static TheoryData<string, string> Cases => new()
    {
        { "ClaimBoostRewardsResponse", "{\"success\":true}" },
        { "EthStakingAccountResponse", "{\"holdingInETH\":\"1.22330928\",\"holdings\":{\"wbethAmount\":\"1.10928781\",\"bethAmount\":\"1.90002112\"},\"thirtyDaysProfitInETH\":\"0.22330928\",\"profit\":{\"amountFromWBETH\":\"0.12330928\",\"amountFromBETH\":\"0.1\"}}" },
        { "EthStakingAccountResponseHoldings", "{\"wbethAmount\":\"1.10928781\",\"bethAmount\":\"1.90002112\"}" },
        { "EthStakingAccountResponseProfit", "{\"amountFromWBETH\":\"0.12330928\",\"amountFromBETH\":\"0.1\"}" },
        { "GetBnsolRateHistoryResponse", "{\"rows\":[{\"annualPercentageRate\":\"0.00006408\",\"exchangeRate\":\"1.001212343432\",\"boostRewards\":[{\"boostAPR\":\"0.12000000\",\"rewardsAsset\":\"SOL\"}],\"time\":1577233578000}],\"total\":\"1\"}" },
        { "GetBnsolRateHistoryResponseRowsInner", "{\"annualPercentageRate\":\"0.00006408\",\"exchangeRate\":\"1.001212343432\",\"boostRewards\":[{\"boostAPR\":\"0.12000000\",\"rewardsAsset\":\"SOL\"}],\"time\":1577233578000}" },
        { "GetBnsolRateHistoryResponseRowsInnerBoostRewardsInner", "{\"boostAPR\":\"0.12000000\",\"rewardsAsset\":\"SOL\"}" },
        { "GetBnsolRewardsHistoryResponse", "{\"estRewardsInSOL\":\"1.23230920\",\"rows\":[{\"time\":1575018510000,\"amountInSOL\":\"0.23223\",\"holding\":\"2.3223\",\"holdingInSOL\":\"2.4231\",\"annualPercentageRate\":\"0.5\"}],\"total\":1}" },
        { "GetBnsolRewardsHistoryResponseRowsInner", "{\"time\":1575018510000,\"amountInSOL\":\"0.23223\",\"holding\":\"2.3223\",\"holdingInSOL\":\"2.4231\",\"annualPercentageRate\":\"0.5\"}" },
        { "GetBoostRewardsHistoryResponse", "{\"rows\":[{\"time\":1729520680,\"token\":\"SOL\",\"amount\":\"1.20291028\",\"bnsolHolding\":\"2.0928798\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetBoostRewardsHistoryResponseRowsInner", "{\"time\":1729520680,\"token\":\"SOL\",\"amount\":\"1.20291028\",\"bnsolHolding\":\"2.0928798\",\"status\":\"SUCCESS\"}" },
        { "GetCurrentEthStakingQuotaResponse", "{\"leftStakingPersonalQuota\":\"1000\",\"leftRedemptionPersonalQuota\":\"1000\",\"minStakeAmount\":\"0.00010000\",\"minRedeemAmount\":\"0.00000001\",\"redeemPeriod\":20,\"stakeable\":true,\"redeemable\":true,\"commissionFee\":\"0.05000000\",\"calculating\":false}" },
        { "GetEthRedemptionHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"arrivalTime\":1575018510000,\"asset\":\"WBETH\",\"amount\":\"21312.23223\",\"distributeAsset\":\"ETH\",\"distributeAmount\":\"21338.0699\",\"conversionRatio\":\"1.00121234\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetEthRedemptionHistoryResponseRowsInner", "{\"time\":1575018510000,\"arrivalTime\":1575018510000,\"asset\":\"WBETH\",\"amount\":\"21312.23223\",\"distributeAsset\":\"ETH\",\"distributeAmount\":\"21338.0699\",\"conversionRatio\":\"1.00121234\",\"status\":\"SUCCESS\"}" },
        { "GetEthStakingHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"asset\":\"ETH\",\"amount\":\"21312.23223\",\"distributeAsset\":\"WBETH\",\"distributeAmount\":\"21286.42584\",\"conversionRatio\":\"1.00121234\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetEthStakingHistoryResponseRowsInner", "{\"time\":1575018510000,\"asset\":\"ETH\",\"amount\":\"21312.23223\",\"distributeAsset\":\"WBETH\",\"distributeAmount\":\"21286.42584\",\"conversionRatio\":\"1.00121234\",\"status\":\"SUCCESS\"}" },
        { "GetOnChainYieldsLockedPersonalLeftQuotaResponse", "{\"leftPersonalQuota\":\"1000\"}" },
        { "GetOnChainYieldsLockedProductListResponse", "{\"rows\":[{\"projectId\":\"Solv-60d\",\"detail\":{\"asset\":\"BTC\",\"rewardAsset\":\"SOLV\",\"duration\":60,\"renewable\":true,\"isSoldOut\":true,\"apr\":\"0.039\",\"status\":\"PREHEATING\",\"subscriptionStartTime\":1646182276000,\"canRedeemToFlex\":true},\"quota\":{\"totalPersonalQuota\":\"2\",\"minimum\":\"0.001\"}}],\"total\":1}" },
        { "GetOnChainYieldsLockedProductListResponseRowsInner", "{\"projectId\":\"Solv-60d\",\"detail\":{\"asset\":\"BTC\",\"rewardAsset\":\"SOLV\",\"duration\":60,\"renewable\":true,\"isSoldOut\":true,\"apr\":\"0.039\",\"status\":\"PREHEATING\",\"subscriptionStartTime\":1646182276000,\"canRedeemToFlex\":true},\"quota\":{\"totalPersonalQuota\":\"2\",\"minimum\":\"0.001\"}}" },
        { "GetOnChainYieldsLockedProductListResponseRowsInnerDetail", "{\"asset\":\"BTC\",\"rewardAsset\":\"SOLV\",\"duration\":60,\"renewable\":true,\"isSoldOut\":true,\"apr\":\"0.039\",\"status\":\"PREHEATING\",\"subscriptionStartTime\":1646182276000,\"canRedeemToFlex\":true}" },
        { "GetOnChainYieldsLockedProductListResponseRowsInnerQuota", "{\"totalPersonalQuota\":\"2\",\"minimum\":\"0.001\"}" },
        { "GetOnChainYieldsLockedProductPositionResponse", "{\"rows\":[{\"positionId\":\"123123\",\"projectId\":\"Solv-60d\",\"asset\":\"BTC\",\"amount\":\"122.09202928\",\"purchaseTime\":\"1646182276000\",\"duration\":\"60\",\"accrualDays\":\"4\",\"rewardAsset\":\"SOLV\",\"APY\":\"0.039\",\"rewardAmt\":\"5.17181528\",\"nextPay\":\"1.29295383\",\"nextPayDate\":\"1646697600000\",\"payPeriod\":\"1\",\"rewardsPayDate\":\"1646697600000\",\"rewardsEndDate\":\"1651449600000\",\"deliverDate\":\"1651536000000\",\"nextSubscriptionDate\":\"1651536000000\",\"redeemingAmt\":\"232.2323\",\"redeemTo\":\"FLEXIBLE\",\"canRedeemEarly\":true,\"autoSubscribe\":true,\"type\":\"AUTO\",\"status\":\"HOLDING\"}],\"total\":1}" },
        { "GetOnChainYieldsLockedProductPositionResponseRowsInner", "{\"positionId\":\"123123\",\"projectId\":\"Solv-60d\",\"asset\":\"BTC\",\"amount\":\"122.09202928\",\"purchaseTime\":\"1646182276000\",\"duration\":\"60\",\"accrualDays\":\"4\",\"rewardAsset\":\"SOLV\",\"APY\":\"0.039\",\"rewardAmt\":\"5.17181528\",\"nextPay\":\"1.29295383\",\"nextPayDate\":\"1646697600000\",\"payPeriod\":\"1\",\"rewardsPayDate\":\"1646697600000\",\"rewardsEndDate\":\"1651449600000\",\"deliverDate\":\"1651536000000\",\"nextSubscriptionDate\":\"1651536000000\",\"redeemingAmt\":\"232.2323\",\"redeemTo\":\"FLEXIBLE\",\"canRedeemEarly\":true,\"autoSubscribe\":true,\"type\":\"AUTO\",\"status\":\"HOLDING\"}" },
        { "GetOnChainYieldsLockedRedemptionRecordResponse", "{\"rows\":[{\"positionId\":\"123123\",\"redeemId\":40607,\"time\":1575018510000,\"asset\":\"BTC\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\",\"originalAmount\":\"21312.23223\",\"type\":\"NORMAL\",\"deliverDate\":\"1575018510000\",\"lossAmount\":\"0.00001232\",\"isComplete\":true,\"rewardAsset\":\"SOLV\",\"rewardAmt\":\"5.17181528\",\"status\":\"PAID\"}],\"total\":1}" },
        { "GetOnChainYieldsLockedRedemptionRecordResponseRowsInner", "{\"positionId\":\"123123\",\"redeemId\":40607,\"time\":1575018510000,\"asset\":\"BTC\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\",\"originalAmount\":\"21312.23223\",\"type\":\"NORMAL\",\"deliverDate\":\"1575018510000\",\"lossAmount\":\"0.00001232\",\"isComplete\":true,\"rewardAsset\":\"SOLV\",\"rewardAmt\":\"5.17181528\",\"status\":\"PAID\"}" },
        { "GetOnChainYieldsLockedRewardsHistoryResponse", "{\"rows\":[{\"positionId\":\"123123\",\"time\":1575018510000,\"asset\":\"BNB\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\"}],\"total\":1}" },
        { "GetOnChainYieldsLockedRewardsHistoryResponseRowsInner", "{\"positionId\":\"123123\",\"time\":1575018510000,\"asset\":\"BNB\",\"lockPeriod\":\"30\",\"amount\":\"21312.23223\"}" },
        { "GetOnChainYieldsLockedSubscriptionPreviewResponse", "{\"rewardAsset\":\"SOLV\",\"totalRewardAmt\":\"5.17181528\",\"nextPay\":\"1.29295383\",\"nextPayDate\":\"1646697600000\",\"rewardsPayDate\":\"1646697600000\",\"valueDate\":\"1646697600000\",\"rewardsEndDate\":\"1651449600000\",\"deliverDate\":\"1651536000000\",\"nextSubscriptionDate\":\"1651536000000\"}" },
        { "GetOnChainYieldsLockedSubscriptionRecordResponse", "{\"rows\":[{\"positionId\":\"123123\",\"purchaseId\":\"26055\",\"projectId\":\"Solv-60d\",\"clientId\":\"ABC\",\"time\":1575018510000,\"asset\":\"BTC\",\"amount\":\"21312.23223\",\"lockPeriod\":\"30\",\"type\":\"AUTO\",\"sourceAccount\":\"SPOT\",\"amtFromSpot\":\"30\",\"amtFromFunding\":\"70\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetOnChainYieldsLockedSubscriptionRecordResponseRowsInner", "{\"positionId\":\"123123\",\"purchaseId\":\"26055\",\"projectId\":\"Solv-60d\",\"clientId\":\"ABC\",\"time\":1575018510000,\"asset\":\"BTC\",\"amount\":\"21312.23223\",\"lockPeriod\":\"30\",\"type\":\"AUTO\",\"sourceAccount\":\"SPOT\",\"amtFromSpot\":\"30\",\"amtFromFunding\":\"70\",\"status\":\"SUCCESS\"}" },
        { "GetSoftStakingProductListResponse", "{\"status\":true,\"totalRewardsUsdt\":\"3.09827182\",\"rows\":[{\"asset\":\"BNB\",\"minAmount\":\"0.5\",\"maxCap\":\"1000\",\"apr\":\"0.0015\",\"stakedAmount\":\"2.14\",\"totalProfit\":\"0.00171234\"}],\"total\":2}" },
        { "GetSoftStakingProductListResponseRowsInner", "{\"asset\":\"BNB\",\"minAmount\":\"0.5\",\"maxCap\":\"1000\",\"apr\":\"0.0015\",\"stakedAmount\":\"2.14\",\"totalProfit\":\"0.00171234\"}" },
        { "GetSoftStakingRewardsHistoryResponse", "{\"rows\":[{\"asset\":\"BNB\",\"rewards\":\"0.00000557\",\"rewardAsset\":\"BNB\",\"avgAmount\":\"2.14\",\"time\":1754007978000}],\"total\":2}" },
        { "GetSoftStakingRewardsHistoryResponseRowsInner", "{\"asset\":\"BNB\",\"rewards\":\"0.00000557\",\"rewardAsset\":\"BNB\",\"avgAmount\":\"2.14\",\"time\":1754007978000}" },
        { "GetSolRedemptionHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"arrivalTime\":1575018510000,\"asset\":\"BNSOL\",\"amount\":\"21312.23223\",\"distributeAsset\":\"SOL\",\"distributeAmount\":\"21338.0699\",\"exchangeRate\":\"1.00121234\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetSolRedemptionHistoryResponseRowsInner", "{\"time\":1575018510000,\"arrivalTime\":1575018510000,\"asset\":\"BNSOL\",\"amount\":\"21312.23223\",\"distributeAsset\":\"SOL\",\"distributeAmount\":\"21338.0699\",\"exchangeRate\":\"1.00121234\",\"status\":\"SUCCESS\"}" },
        { "GetSolStakingHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"asset\":\"SOL\",\"amount\":\"21312.23223\",\"distributeAsset\":\"BNSOL\",\"distributeAmount\":\"21286.42584\",\"exchangeRate\":\"1.00121234\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetSolStakingHistoryResponseRowsInner", "{\"time\":1575018510000,\"asset\":\"SOL\",\"amount\":\"21312.23223\",\"distributeAsset\":\"BNSOL\",\"distributeAmount\":\"21286.42584\",\"exchangeRate\":\"1.00121234\",\"status\":\"SUCCESS\"}" },
        { "GetSolStakingQuotaDetailsResponse", "{\"leftStakingPersonalQuota\":\"1000\",\"leftRedemptionPersonalQuota\":\"1000\",\"minStakeAmount\":\"0.01000000\",\"minRedeemAmount\":\"0.00000001\",\"redeemPeriod\":4,\"stakeable\":true,\"redeemable\":true,\"soldOut\":false,\"commissionFee\":\"0.25000000\",\"nextEpochTime\":725993969475,\"calculating\":false}" },
        { "GetUnclaimedRewardsResponseInner", "{\"amount\":\"1.00000011\",\"rewardsAsset\":\"SOL\"}" },
        { "GetWbethRateHistoryResponse", "{\"rows\":[{\"annualPercentageRate\":\"0.00006408\",\"exchangeRate\":\"1.00121234\",\"time\":1577233578000}],\"total\":\"1\"}" },
        { "GetWbethRateHistoryResponseRowsInner", "{\"annualPercentageRate\":\"0.00006408\",\"exchangeRate\":\"1.00121234\",\"time\":1577233578000}" },
        { "GetWbethRewardsHistoryResponse", "{\"estRewardsInETH\":\"1.23230920\",\"rows\":[{\"time\":1575018510000,\"amountInETH\":\"0.23223\",\"holding\":\"2.3223\",\"holdingInETH\":\"2.4231\",\"annualPercentageRate\":\"0.5\"}],\"total\":1}" },
        { "GetWbethRewardsHistoryResponseRowsInner", "{\"time\":1575018510000,\"amountInETH\":\"0.23223\",\"holding\":\"2.3223\",\"holdingInETH\":\"2.4231\",\"annualPercentageRate\":\"0.5\"}" },
        { "GetWbethUnwrapHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"fromAsset\":\"WBETH\",\"fromAmount\":\"21312.23223\",\"toAsset\":\"BETH\",\"toAmount\":\"21312.23223\",\"exchangeRate\":\"1.01243253\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetWbethUnwrapHistoryResponseRowsInner", "{\"time\":1575018510000,\"fromAsset\":\"WBETH\",\"fromAmount\":\"21312.23223\",\"toAsset\":\"BETH\",\"toAmount\":\"21312.23223\",\"exchangeRate\":\"1.01243253\",\"status\":\"SUCCESS\"}" },
        { "GetWbethWrapHistoryResponse", "{\"rows\":[{\"time\":1575018510000,\"fromAsset\":\"BETH\",\"fromAmount\":\"21312.23223\",\"toAsset\":\"WBETH\",\"toAmount\":\"21312.23223\",\"exchangeRate\":\"1.01243253\",\"status\":\"SUCCESS\"}],\"total\":1}" },
        { "GetWbethWrapHistoryResponseRowsInner", "{\"time\":1575018510000,\"fromAsset\":\"BETH\",\"fromAmount\":\"21312.23223\",\"toAsset\":\"WBETH\",\"toAmount\":\"21312.23223\",\"exchangeRate\":\"1.01243253\",\"status\":\"SUCCESS\"}" },
        { "OnChainYieldsAccountResponse", "{\"totalAmountInBTC\":\"0.01067982\",\"totalAmountInUSDT\":\"77.13289230\",\"totalFlexibleAmountInBTC\":\"0.00000000\",\"totalFlexibleAmountInUSDT\":\"0.00000000\",\"totalLockedInBTC\":\"0.01067982\",\"totalLockedInUSDT\":\"77.13289230\"}" },
        { "RedeemEthResponse", "{\"success\":true,\"ethAmount\":\"0.23092091\",\"redeemId\":1234567,\"conversionRatio\":\"1.00121234\",\"arrivalTime\":1575018510000}" },
        { "RedeemOnChainYieldsLockedProductResponse", "{\"redeemId\":40607,\"success\":true}" },
        { "RedeemSolResponse", "{\"success\":true,\"solAmount\":\"0.23092091\",\"redeemId\":1234567,\"exchangeRate\":\"1.00121234\",\"arrivalTime\":1575018510000}" },
        { "SetOnChainYieldsLockedAutoSubscribeResponse", "{\"success\":true}" },
        { "SetOnChainYieldsLockedProductRedeemOptionResponse", "{\"success\":true}" },
        { "SetSoftStakingResponse", "{\"success\":true}" },
        { "SolStakingAccountResponse", "{\"bnsolAmount\":\"1.10928781\",\"holdingInSOL\":\"1.22330928\",\"thirtyDaysProfitInSOL\":\"0.22330928\"}" },
        { "SubscribeEthStakingResponse", "{\"success\":true,\"wbethAmount\":\"0.23092091\",\"purchaseId\":1234567,\"conversionRatio\":\"1.001212342342\"}" },
        { "SubscribeOnChainYieldsLockedProductResponse", "{\"purchaseId\":40607,\"positionId\":\"12345\",\"amount\":\"75.46000000\",\"success\":true}" },
        { "SubscribeSolStakingResponse", "{\"success\":true,\"bnsolAmount\":\"0.23092091\",\"purchaseId\":1234567,\"exchangeRate\":\"1.001212342342\"}" },
        { "WrapBethResponse", "{\"success\":true,\"wbethAmount\":\"0.23092091\",\"exchangeRate\":\"1.001212343432\"}" },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void DecodesAndRoundTrips(string name, string json)
    {
        var assembly = typeof(StakingRestApi).Assembly;
        var type = assembly.GetType($"Binance.Staking.RestApi.{name.Split('/')[0]}", throwOnError: true)!;
        var context = (JsonSerializerContext)assembly.GetType("Binance.Staking.RestApi.StakingRestApiJson")!.GetProperty("Default")!.GetValue(null)!;
        // A model that no operation returns is not in the serializer context, so it is decoded by reflection.
        var info = context.GetTypeInfo(type);
        var model = info is null ? JsonSerializer.Deserialize(json, type, Reflection) : JsonSerializer.Deserialize(json, info);
        ExampleAssert.Matches(json, model);
    }
}
