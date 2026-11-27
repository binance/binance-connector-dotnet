//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.SubAccount.RestApi;

/// <summary>The System.Text.Json context of the SubAccount RestApi models: <c>JsonSerializer.Serialize(value, SubAccountRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AddIpRestrictionForSubAccountApiKeyResponse), TypeInfoPropertyName = "AddIpRestrictionForSubAccountApiKeyResponse")]
[JsonSerializable(typeof(CreateAVirtualSubAccountResponse), TypeInfoPropertyName = "CreateAVirtualSubAccountResponse")]
[JsonSerializable(typeof(CreateSubAccountApiKeyResponse), TypeInfoPropertyName = "CreateSubAccountApiKeyResponse")]
[JsonSerializable(typeof(CreateSubAccountApiKeyV2Response), TypeInfoPropertyName = "CreateSubAccountApiKeyV2Response")]
[JsonSerializable(typeof(DeleteIpListForASubAccountApiKeyResponse), TypeInfoPropertyName = "DeleteIpListForASubAccountApiKeyResponse")]
[JsonSerializable(typeof(DepositAssetsIntoTheManagedSubAccountResponse), TypeInfoPropertyName = "DepositAssetsIntoTheManagedSubAccountResponse")]
[JsonSerializable(typeof(EnableFuturesForSubAccountResponse), TypeInfoPropertyName = "EnableFuturesForSubAccountResponse")]
[JsonSerializable(typeof(EnableOptionsForSubAccountResponse), TypeInfoPropertyName = "EnableOptionsForSubAccountResponse")]
[JsonSerializable(typeof(FuturesTransferForSubAccountResponse), TypeInfoPropertyName = "FuturesTransferForSubAccountResponse")]
[JsonSerializable(typeof(GetDetailOnSubAccountsFuturesAccountResponse), TypeInfoPropertyName = "GetDetailOnSubAccountsFuturesAccountResponse")]
[JsonSerializable(typeof(GetDetailOnSubAccountsFuturesAccountV2Response), TypeInfoPropertyName = "GetDetailOnSubAccountsFuturesAccountV2Response")]
[JsonSerializable(typeof(GetDetailOnSubAccountsMarginAccountResponse), TypeInfoPropertyName = "GetDetailOnSubAccountsMarginAccountResponse")]
[JsonSerializable(typeof(GetFuturesPositionRiskOfSubAccountV2Response), TypeInfoPropertyName = "GetFuturesPositionRiskOfSubAccountV2Response")]
[JsonSerializable(typeof(GetIpRestrictionForASubAccountApiKeyResponse), TypeInfoPropertyName = "GetIpRestrictionForASubAccountApiKeyResponse")]
[JsonSerializable(typeof(GetManagedSubAccountDepositAddressResponse), TypeInfoPropertyName = "GetManagedSubAccountDepositAddressResponse")]
[JsonSerializable(typeof(GetMovePositionHistoryForSubAccountResponse), TypeInfoPropertyName = "GetMovePositionHistoryForSubAccountResponse")]
[JsonSerializable(typeof(GetSubAccountDepositAddressResponse), TypeInfoPropertyName = "GetSubAccountDepositAddressResponse")]
[JsonSerializable(typeof(GetSummaryOfSubAccountsFuturesAccountResponse), TypeInfoPropertyName = "GetSummaryOfSubAccountsFuturesAccountResponse")]
[JsonSerializable(typeof(GetSummaryOfSubAccountsFuturesAccountV2Response), TypeInfoPropertyName = "GetSummaryOfSubAccountsFuturesAccountV2Response")]
[JsonSerializable(typeof(GetSummaryOfSubAccountsMarginAccountResponse), TypeInfoPropertyName = "GetSummaryOfSubAccountsMarginAccountResponse")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(List<GetFuturesPositionRiskOfSubAccountResponseInner>), TypeInfoPropertyName = "ListGetFuturesPositionRiskOfSubAccountResponseInner")]
[JsonSerializable(typeof(List<GetSubAccountDepositHistoryResponseInner>), TypeInfoPropertyName = "ListGetSubAccountDepositHistoryResponseInner")]
[JsonSerializable(typeof(List<GetSubAccountsStatusOnMarginOrFuturesResponseInner>), TypeInfoPropertyName = "ListGetSubAccountsStatusOnMarginOrFuturesResponseInner")]
[JsonSerializable(typeof(List<MovePositionForSubAccountOrderArgsParameterInner>), TypeInfoPropertyName = "ListMovePositionForSubAccountOrderArgsParameterInner")]
[JsonSerializable(typeof(List<QueryManagedSubAccountAssetDetailsResponseInner>), TypeInfoPropertyName = "ListQueryManagedSubAccountAssetDetailsResponseInner")]
[JsonSerializable(typeof(List<QuerySubAccountSpotAssetTransferHistoryResponseInner>), TypeInfoPropertyName = "ListQuerySubAccountSpotAssetTransferHistoryResponseInner")]
[JsonSerializable(typeof(List<SubAccountTransferHistoryResponseInner>), TypeInfoPropertyName = "ListSubAccountTransferHistoryResponseInner")]
[JsonSerializable(typeof(MarginTransferForSubAccountResponse), TypeInfoPropertyName = "MarginTransferForSubAccountResponse")]
[JsonSerializable(typeof(ModifySubAccountApiKeyPermissionResponse), TypeInfoPropertyName = "ModifySubAccountApiKeyPermissionResponse")]
[JsonSerializable(typeof(MovePositionForSubAccountResponse), TypeInfoPropertyName = "MovePositionForSubAccountResponse")]
[JsonSerializable(typeof(QueryManagedSubAccountFuturesAssetDetailsResponse), TypeInfoPropertyName = "QueryManagedSubAccountFuturesAssetDetailsResponse")]
[JsonSerializable(typeof(QueryManagedSubAccountListResponse), TypeInfoPropertyName = "QueryManagedSubAccountListResponse")]
[JsonSerializable(typeof(QueryManagedSubAccountMarginAssetDetailsResponse), TypeInfoPropertyName = "QueryManagedSubAccountMarginAssetDetailsResponse")]
[JsonSerializable(typeof(QueryManagedSubAccountSnapshotResponse), TypeInfoPropertyName = "QueryManagedSubAccountSnapshotResponse")]
[JsonSerializable(typeof(QueryManagedSubAccountTransferLogMasterAccountInvestorResponse), TypeInfoPropertyName = "QueryManagedSubAccountTransferLogMasterAccountInvestorResponse")]
[JsonSerializable(typeof(QueryManagedSubAccountTransferLogMasterAccountTradingResponse), TypeInfoPropertyName = "QueryManagedSubAccountTransferLogMasterAccountTradingResponse")]
[JsonSerializable(typeof(QueryManagedSubAccountTransferLogSubAccountTradingResponse), TypeInfoPropertyName = "QueryManagedSubAccountTransferLogSubAccountTradingResponse")]
[JsonSerializable(typeof(QuerySubAccountApiKeyResponse), TypeInfoPropertyName = "QuerySubAccountApiKeyResponse")]
[JsonSerializable(typeof(QuerySubAccountAssetsAssetManagementResponse), TypeInfoPropertyName = "QuerySubAccountAssetsAssetManagementResponse")]
[JsonSerializable(typeof(QuerySubAccountAssetsResponse), TypeInfoPropertyName = "QuerySubAccountAssetsResponse")]
[JsonSerializable(typeof(QuerySubAccountFuturesAssetTransferHistoryResponse), TypeInfoPropertyName = "QuerySubAccountFuturesAssetTransferHistoryResponse")]
[JsonSerializable(typeof(QuerySubAccountListResponse), TypeInfoPropertyName = "QuerySubAccountListResponse")]
[JsonSerializable(typeof(QuerySubAccountSpotAssetsSummaryResponse), TypeInfoPropertyName = "QuerySubAccountSpotAssetsSummaryResponse")]
[JsonSerializable(typeof(QuerySubAccountTransactionStatisticsResponse), TypeInfoPropertyName = "QuerySubAccountTransactionStatisticsResponse")]
[JsonSerializable(typeof(QueryUniversalTransferHistoryResponse), TypeInfoPropertyName = "QueryUniversalTransferHistoryResponse")]
[JsonSerializable(typeof(SubAccountFuturesAssetTransferResponse), TypeInfoPropertyName = "SubAccountFuturesAssetTransferResponse")]
[JsonSerializable(typeof(TransferToMasterResponse), TypeInfoPropertyName = "TransferToMasterResponse")]
[JsonSerializable(typeof(TransferToSubAccountOfSameMasterResponse), TypeInfoPropertyName = "TransferToSubAccountOfSameMasterResponse")]
[JsonSerializable(typeof(UniversalTransferResponse), TypeInfoPropertyName = "UniversalTransferResponse")]
[JsonSerializable(typeof(WithdrawlAssetsFromTheManagedSubAccountResponse), TypeInfoPropertyName = "WithdrawlAssetsFromTheManagedSubAccountResponse")]
public sealed partial class SubAccountRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the SubAccount RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
