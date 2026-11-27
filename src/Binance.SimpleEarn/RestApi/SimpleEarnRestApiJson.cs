//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.SimpleEarn.RestApi;

/// <summary>The System.Text.Json context of the SimpleEarn RestApi models: <c>JsonSerializer.Serialize(value, SimpleEarnRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(GetBfusdAccountResponse), TypeInfoPropertyName = "GetBfusdAccountResponse")]
[JsonSerializable(typeof(GetBfusdQuotaDetailsResponse), TypeInfoPropertyName = "GetBfusdQuotaDetailsResponse")]
[JsonSerializable(typeof(GetBfusdRateHistoryResponse), TypeInfoPropertyName = "GetBfusdRateHistoryResponse")]
[JsonSerializable(typeof(GetBfusdRedemptionHistoryResponse), TypeInfoPropertyName = "GetBfusdRedemptionHistoryResponse")]
[JsonSerializable(typeof(GetBfusdRewardsHistoryResponse), TypeInfoPropertyName = "GetBfusdRewardsHistoryResponse")]
[JsonSerializable(typeof(GetBfusdSubscriptionHistoryResponse), TypeInfoPropertyName = "GetBfusdSubscriptionHistoryResponse")]
[JsonSerializable(typeof(GetCollateralRecordResponse), TypeInfoPropertyName = "GetCollateralRecordResponse")]
[JsonSerializable(typeof(GetFlexiblePersonalLeftQuotaResponse), TypeInfoPropertyName = "GetFlexiblePersonalLeftQuotaResponse")]
[JsonSerializable(typeof(GetFlexibleProductPositionResponse), TypeInfoPropertyName = "GetFlexibleProductPositionResponse")]
[JsonSerializable(typeof(GetFlexibleRedemptionRecordResponse), TypeInfoPropertyName = "GetFlexibleRedemptionRecordResponse")]
[JsonSerializable(typeof(GetFlexibleRewardsHistoryResponse), TypeInfoPropertyName = "GetFlexibleRewardsHistoryResponse")]
[JsonSerializable(typeof(GetFlexibleSubscriptionPreviewResponse), TypeInfoPropertyName = "GetFlexibleSubscriptionPreviewResponse")]
[JsonSerializable(typeof(GetFlexibleSubscriptionRecordResponse), TypeInfoPropertyName = "GetFlexibleSubscriptionRecordResponse")]
[JsonSerializable(typeof(GetLockedPersonalLeftQuotaResponse), TypeInfoPropertyName = "GetLockedPersonalLeftQuotaResponse")]
[JsonSerializable(typeof(GetLockedProductPositionResponse), TypeInfoPropertyName = "GetLockedProductPositionResponse")]
[JsonSerializable(typeof(GetLockedRedemptionRecordResponse), TypeInfoPropertyName = "GetLockedRedemptionRecordResponse")]
[JsonSerializable(typeof(GetLockedRewardsHistoryResponse), TypeInfoPropertyName = "GetLockedRewardsHistoryResponse")]
[JsonSerializable(typeof(GetLockedSubscriptionRecordResponse), TypeInfoPropertyName = "GetLockedSubscriptionRecordResponse")]
[JsonSerializable(typeof(GetRateHistoryResponse), TypeInfoPropertyName = "GetRateHistoryResponse")]
[JsonSerializable(typeof(GetRwusdAccountResponse), TypeInfoPropertyName = "GetRwusdAccountResponse")]
[JsonSerializable(typeof(GetRwusdQuotaDetailsResponse), TypeInfoPropertyName = "GetRwusdQuotaDetailsResponse")]
[JsonSerializable(typeof(GetRwusdRateHistoryResponse), TypeInfoPropertyName = "GetRwusdRateHistoryResponse")]
[JsonSerializable(typeof(GetRwusdRedemptionHistoryResponse), TypeInfoPropertyName = "GetRwusdRedemptionHistoryResponse")]
[JsonSerializable(typeof(GetRwusdRewardsHistoryResponse), TypeInfoPropertyName = "GetRwusdRewardsHistoryResponse")]
[JsonSerializable(typeof(GetRwusdSubscriptionHistoryResponse), TypeInfoPropertyName = "GetRwusdSubscriptionHistoryResponse")]
[JsonSerializable(typeof(GetSimpleEarnFlexibleProductListResponse), TypeInfoPropertyName = "GetSimpleEarnFlexibleProductListResponse")]
[JsonSerializable(typeof(GetSimpleEarnLockedProductListResponse), TypeInfoPropertyName = "GetSimpleEarnLockedProductListResponse")]
[JsonSerializable(typeof(GetYieldArenaActivitiesResponse), TypeInfoPropertyName = "GetYieldArenaActivitiesResponse")]
[JsonSerializable(typeof(List<GetLockedSubscriptionPreviewResponseInner>), TypeInfoPropertyName = "ListGetLockedSubscriptionPreviewResponseInner")]
[JsonSerializable(typeof(RedeemBfusdResponse), TypeInfoPropertyName = "RedeemBfusdResponse")]
[JsonSerializable(typeof(RedeemFlexibleProductResponse), TypeInfoPropertyName = "RedeemFlexibleProductResponse")]
[JsonSerializable(typeof(RedeemLockedProductResponse), TypeInfoPropertyName = "RedeemLockedProductResponse")]
[JsonSerializable(typeof(RedeemRwusdResponse), TypeInfoPropertyName = "RedeemRwusdResponse")]
[JsonSerializable(typeof(SetFlexibleAutoSubscribeResponse), TypeInfoPropertyName = "SetFlexibleAutoSubscribeResponse")]
[JsonSerializable(typeof(SetLockedAutoSubscribeResponse), TypeInfoPropertyName = "SetLockedAutoSubscribeResponse")]
[JsonSerializable(typeof(SetLockedProductRedeemOptionResponse), TypeInfoPropertyName = "SetLockedProductRedeemOptionResponse")]
[JsonSerializable(typeof(SimpleAccountResponse), TypeInfoPropertyName = "SimpleAccountResponse")]
[JsonSerializable(typeof(SubscribeBfusdResponse), TypeInfoPropertyName = "SubscribeBfusdResponse")]
[JsonSerializable(typeof(SubscribeFlexibleProductResponse), TypeInfoPropertyName = "SubscribeFlexibleProductResponse")]
[JsonSerializable(typeof(SubscribeLockedProductResponse), TypeInfoPropertyName = "SubscribeLockedProductResponse")]
[JsonSerializable(typeof(SubscribeRwusdResponse), TypeInfoPropertyName = "SubscribeRwusdResponse")]
public sealed partial class SimpleEarnRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the SimpleEarn RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
