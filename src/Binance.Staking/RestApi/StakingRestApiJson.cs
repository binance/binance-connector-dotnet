//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Staking.RestApi;

/// <summary>The System.Text.Json context of the Staking RestApi models: <c>JsonSerializer.Serialize(value, StakingRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(ClaimBoostRewardsResponse), TypeInfoPropertyName = "ClaimBoostRewardsResponse")]
[JsonSerializable(typeof(EthStakingAccountResponse), TypeInfoPropertyName = "EthStakingAccountResponse")]
[JsonSerializable(typeof(GetBnsolRateHistoryResponse), TypeInfoPropertyName = "GetBnsolRateHistoryResponse")]
[JsonSerializable(typeof(GetBnsolRewardsHistoryResponse), TypeInfoPropertyName = "GetBnsolRewardsHistoryResponse")]
[JsonSerializable(typeof(GetBoostRewardsHistoryResponse), TypeInfoPropertyName = "GetBoostRewardsHistoryResponse")]
[JsonSerializable(typeof(GetCurrentEthStakingQuotaResponse), TypeInfoPropertyName = "GetCurrentEthStakingQuotaResponse")]
[JsonSerializable(typeof(GetEthRedemptionHistoryResponse), TypeInfoPropertyName = "GetEthRedemptionHistoryResponse")]
[JsonSerializable(typeof(GetEthStakingHistoryResponse), TypeInfoPropertyName = "GetEthStakingHistoryResponse")]
[JsonSerializable(typeof(GetOnChainYieldsLockedPersonalLeftQuotaResponse), TypeInfoPropertyName = "GetOnChainYieldsLockedPersonalLeftQuotaResponse")]
[JsonSerializable(typeof(GetOnChainYieldsLockedProductListResponse), TypeInfoPropertyName = "GetOnChainYieldsLockedProductListResponse")]
[JsonSerializable(typeof(GetOnChainYieldsLockedProductPositionResponse), TypeInfoPropertyName = "GetOnChainYieldsLockedProductPositionResponse")]
[JsonSerializable(typeof(GetOnChainYieldsLockedRedemptionRecordResponse), TypeInfoPropertyName = "GetOnChainYieldsLockedRedemptionRecordResponse")]
[JsonSerializable(typeof(GetOnChainYieldsLockedRewardsHistoryResponse), TypeInfoPropertyName = "GetOnChainYieldsLockedRewardsHistoryResponse")]
[JsonSerializable(typeof(GetOnChainYieldsLockedSubscriptionPreviewResponse), TypeInfoPropertyName = "GetOnChainYieldsLockedSubscriptionPreviewResponse")]
[JsonSerializable(typeof(GetOnChainYieldsLockedSubscriptionRecordResponse), TypeInfoPropertyName = "GetOnChainYieldsLockedSubscriptionRecordResponse")]
[JsonSerializable(typeof(GetSoftStakingProductListResponse), TypeInfoPropertyName = "GetSoftStakingProductListResponse")]
[JsonSerializable(typeof(GetSoftStakingRewardsHistoryResponse), TypeInfoPropertyName = "GetSoftStakingRewardsHistoryResponse")]
[JsonSerializable(typeof(GetSolRedemptionHistoryResponse), TypeInfoPropertyName = "GetSolRedemptionHistoryResponse")]
[JsonSerializable(typeof(GetSolStakingHistoryResponse), TypeInfoPropertyName = "GetSolStakingHistoryResponse")]
[JsonSerializable(typeof(GetSolStakingQuotaDetailsResponse), TypeInfoPropertyName = "GetSolStakingQuotaDetailsResponse")]
[JsonSerializable(typeof(GetWbethRateHistoryResponse), TypeInfoPropertyName = "GetWbethRateHistoryResponse")]
[JsonSerializable(typeof(GetWbethRewardsHistoryResponse), TypeInfoPropertyName = "GetWbethRewardsHistoryResponse")]
[JsonSerializable(typeof(GetWbethUnwrapHistoryResponse), TypeInfoPropertyName = "GetWbethUnwrapHistoryResponse")]
[JsonSerializable(typeof(GetWbethWrapHistoryResponse), TypeInfoPropertyName = "GetWbethWrapHistoryResponse")]
[JsonSerializable(typeof(List<GetUnclaimedRewardsResponseInner>), TypeInfoPropertyName = "ListGetUnclaimedRewardsResponseInner")]
[JsonSerializable(typeof(OnChainYieldsAccountResponse), TypeInfoPropertyName = "OnChainYieldsAccountResponse")]
[JsonSerializable(typeof(RedeemEthResponse), TypeInfoPropertyName = "RedeemEthResponse")]
[JsonSerializable(typeof(RedeemOnChainYieldsLockedProductResponse), TypeInfoPropertyName = "RedeemOnChainYieldsLockedProductResponse")]
[JsonSerializable(typeof(RedeemSolResponse), TypeInfoPropertyName = "RedeemSolResponse")]
[JsonSerializable(typeof(SetOnChainYieldsLockedAutoSubscribeResponse), TypeInfoPropertyName = "SetOnChainYieldsLockedAutoSubscribeResponse")]
[JsonSerializable(typeof(SetOnChainYieldsLockedProductRedeemOptionResponse), TypeInfoPropertyName = "SetOnChainYieldsLockedProductRedeemOptionResponse")]
[JsonSerializable(typeof(SetSoftStakingResponse), TypeInfoPropertyName = "SetSoftStakingResponse")]
[JsonSerializable(typeof(SolStakingAccountResponse), TypeInfoPropertyName = "SolStakingAccountResponse")]
[JsonSerializable(typeof(SubscribeEthStakingResponse), TypeInfoPropertyName = "SubscribeEthStakingResponse")]
[JsonSerializable(typeof(SubscribeOnChainYieldsLockedProductResponse), TypeInfoPropertyName = "SubscribeOnChainYieldsLockedProductResponse")]
[JsonSerializable(typeof(SubscribeSolStakingResponse), TypeInfoPropertyName = "SubscribeSolStakingResponse")]
[JsonSerializable(typeof(WrapBethResponse), TypeInfoPropertyName = "WrapBethResponse")]
public sealed partial class StakingRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Staking RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
