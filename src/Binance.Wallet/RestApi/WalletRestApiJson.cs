//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Wallet.RestApi;

/// <summary>The System.Text.Json context of the Wallet RestApi models: <c>JsonSerializer.Serialize(value, WalletRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountApiTradingStatusResponse), TypeInfoPropertyName = "AccountApiTradingStatusResponse")]
[JsonSerializable(typeof(AccountInfoResponse), TypeInfoPropertyName = "AccountInfoResponse")]
[JsonSerializable(typeof(AccountStatusResponse), TypeInfoPropertyName = "AccountStatusResponse")]
[JsonSerializable(typeof(AssetDetailResponse), TypeInfoPropertyName = "AssetDetailResponse")]
[JsonSerializable(typeof(AssetDividendRecordResponse), TypeInfoPropertyName = "AssetDividendRecordResponse")]
[JsonSerializable(typeof(BrokerWithdrawResponse), TypeInfoPropertyName = "BrokerWithdrawResponse")]
[JsonSerializable(typeof(CheckQuestionnaireRequirementsResponse), TypeInfoPropertyName = "CheckQuestionnaireRequirementsResponse")]
[JsonSerializable(typeof(DailyAccountSnapshotResponse), TypeInfoPropertyName = "DailyAccountSnapshotResponse")]
[JsonSerializable(typeof(DepositAddressResponse), TypeInfoPropertyName = "DepositAddressResponse")]
[JsonSerializable(typeof(DustConvertResponse), TypeInfoPropertyName = "DustConvertResponse")]
[JsonSerializable(typeof(DustConvertibleAssetsResponse), TypeInfoPropertyName = "DustConvertibleAssetsResponse")]
[JsonSerializable(typeof(DustTransferResponse), TypeInfoPropertyName = "DustTransferResponse")]
[JsonSerializable(typeof(DustlogResponse), TypeInfoPropertyName = "DustlogResponse")]
[JsonSerializable(typeof(FetchWithdrawQuotaResponse), TypeInfoPropertyName = "FetchWithdrawQuotaResponse")]
[JsonSerializable(typeof(GetApiKeyPermissionResponse), TypeInfoPropertyName = "GetApiKeyPermissionResponse")]
[JsonSerializable(typeof(GetAssetsThatCanBeConvertedIntoBnbResponse), TypeInfoPropertyName = "GetAssetsThatCanBeConvertedIntoBnbResponse")]
[JsonSerializable(typeof(GetCloudMiningPaymentAndRefundHistoryResponse), TypeInfoPropertyName = "GetCloudMiningPaymentAndRefundHistoryResponse")]
[JsonSerializable(typeof(GetCountryListResponse), TypeInfoPropertyName = "GetCountryListResponse")]
[JsonSerializable(typeof(GetRegionListResponse), TypeInfoPropertyName = "GetRegionListResponse")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(List<AllCoinsInformationResponseInner>), TypeInfoPropertyName = "ListAllCoinsInformationResponseInner")]
[JsonSerializable(typeof(List<DepositHistoryResponseInner>), TypeInfoPropertyName = "ListDepositHistoryResponseInner")]
[JsonSerializable(typeof(List<DepositHistoryTravelRuleResponseInner>), TypeInfoPropertyName = "ListDepositHistoryTravelRuleResponseInner")]
[JsonSerializable(typeof(List<DepositHistoryV2ResponseInner>), TypeInfoPropertyName = "ListDepositHistoryV2ResponseInner")]
[JsonSerializable(typeof(List<FetchAddressVerificationListResponseInner>), TypeInfoPropertyName = "ListFetchAddressVerificationListResponseInner")]
[JsonSerializable(typeof(List<FetchDepositAddressListWithNetworkResponseInner>), TypeInfoPropertyName = "ListFetchDepositAddressListWithNetworkResponseInner")]
[JsonSerializable(typeof(List<FetchWithdrawAddressListResponseInner>), TypeInfoPropertyName = "ListFetchWithdrawAddressListResponseInner")]
[JsonSerializable(typeof(List<FundingWalletResponseInner>), TypeInfoPropertyName = "ListFundingWalletResponseInner")]
[JsonSerializable(typeof(List<GetOpenSymbolListResponseInner>), TypeInfoPropertyName = "ListGetOpenSymbolListResponseInner")]
[JsonSerializable(typeof(List<GetSpotAssetTagsResponseInner>), TypeInfoPropertyName = "ListGetSpotAssetTagsResponseInner")]
[JsonSerializable(typeof(List<GetSymbolsDelistScheduleForSpotResponseInner>), TypeInfoPropertyName = "ListGetSymbolsDelistScheduleForSpotResponseInner")]
[JsonSerializable(typeof(List<QueryUserWalletBalanceResponseInner>), TypeInfoPropertyName = "ListQueryUserWalletBalanceResponseInner")]
[JsonSerializable(typeof(List<TradeFeeResponseInner>), TypeInfoPropertyName = "ListTradeFeeResponseInner")]
[JsonSerializable(typeof(List<UserAssetResponseInner>), TypeInfoPropertyName = "ListUserAssetResponseInner")]
[JsonSerializable(typeof(List<VaspListResponseInner>), TypeInfoPropertyName = "ListVaspListResponseInner")]
[JsonSerializable(typeof(List<WithdrawHistoryResponseInner>), TypeInfoPropertyName = "ListWithdrawHistoryResponseInner")]
[JsonSerializable(typeof(List<WithdrawHistoryV1ResponseInner>), TypeInfoPropertyName = "ListWithdrawHistoryV1ResponseInner")]
[JsonSerializable(typeof(OneClickArrivalDepositApplyResponse), TypeInfoPropertyName = "OneClickArrivalDepositApplyResponse")]
[JsonSerializable(typeof(QueryUserDelegationHistoryResponse), TypeInfoPropertyName = "QueryUserDelegationHistoryResponse")]
[JsonSerializable(typeof(QueryUserUniversalTransferHistoryResponse), TypeInfoPropertyName = "QueryUserUniversalTransferHistoryResponse")]
[JsonSerializable(typeof(SubmitDepositQuestionnaireResponse), TypeInfoPropertyName = "SubmitDepositQuestionnaireResponse")]
[JsonSerializable(typeof(SubmitDepositQuestionnaireTravelRuleResponse), TypeInfoPropertyName = "SubmitDepositQuestionnaireTravelRuleResponse")]
[JsonSerializable(typeof(SubmitDepositQuestionnaireV2Response), TypeInfoPropertyName = "SubmitDepositQuestionnaireV2Response")]
[JsonSerializable(typeof(SystemStatusResponse), TypeInfoPropertyName = "SystemStatusResponse")]
[JsonSerializable(typeof(ToggleBnbBurnOnSpotTradeAndMarginInterestResponse), TypeInfoPropertyName = "ToggleBnbBurnOnSpotTradeAndMarginInterestResponse")]
[JsonSerializable(typeof(UserUniversalTransferResponse), TypeInfoPropertyName = "UserUniversalTransferResponse")]
[JsonSerializable(typeof(WithdrawResponse), TypeInfoPropertyName = "WithdrawResponse")]
[JsonSerializable(typeof(WithdrawTravelRuleResponse), TypeInfoPropertyName = "WithdrawTravelRuleResponse")]
public sealed partial class WalletRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Wallet RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
