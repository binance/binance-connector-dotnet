//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.MarginTrading.RestApi;

/// <summary>The System.Text.Json context of the MarginTrading RestApi models: <c>JsonSerializer.Serialize(value, MarginTradingRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AdjustCrossMarginMaxLeverageResponse), TypeInfoPropertyName = "AdjustCrossMarginMaxLeverageResponse")]
[JsonSerializable(typeof(CreateSpecialKeyResponse), TypeInfoPropertyName = "CreateSpecialKeyResponse")]
[JsonSerializable(typeof(DisableIsolatedMarginAccountResponse), TypeInfoPropertyName = "DisableIsolatedMarginAccountResponse")]
[JsonSerializable(typeof(EnableIsolatedMarginAccountResponse), TypeInfoPropertyName = "EnableIsolatedMarginAccountResponse")]
[JsonSerializable(typeof(GetBnbBurnStatusResponse), TypeInfoPropertyName = "GetBnbBurnStatusResponse")]
[JsonSerializable(typeof(GetCrossMarginTransferHistoryResponse), TypeInfoPropertyName = "GetCrossMarginTransferHistoryResponse")]
[JsonSerializable(typeof(GetForceLiquidationRecordResponse), TypeInfoPropertyName = "GetForceLiquidationRecordResponse")]
[JsonSerializable(typeof(GetInterestHistoryResponse), TypeInfoPropertyName = "GetInterestHistoryResponse")]
[JsonSerializable(typeof(GetLimitPricePairsResponse), TypeInfoPropertyName = "GetLimitPricePairsResponse")]
[JsonSerializable(typeof(GetMarginRestrictedAssetsResponse), TypeInfoPropertyName = "GetMarginRestrictedAssetsResponse")]
[JsonSerializable(typeof(GetSmallLiabilityExchangeHistoryResponse), TypeInfoPropertyName = "GetSmallLiabilityExchangeHistoryResponse")]
[JsonSerializable(typeof(GetSummaryOfMarginAccountResponse), TypeInfoPropertyName = "GetSummaryOfMarginAccountResponse")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(LiquidationLoanRepayResponse), TypeInfoPropertyName = "LiquidationLoanRepayResponse")]
[JsonSerializable(typeof(List<CrossMarginCollateralRatioResponseInner>), TypeInfoPropertyName = "ListCrossMarginCollateralRatioResponseInner")]
[JsonSerializable(typeof(List<GetAllCrossMarginPairsResponseInner>), TypeInfoPropertyName = "ListGetAllCrossMarginPairsResponseInner")]
[JsonSerializable(typeof(List<GetAllIsolatedMarginSymbolResponseInner>), TypeInfoPropertyName = "ListGetAllIsolatedMarginSymbolResponseInner")]
[JsonSerializable(typeof(List<GetAllMarginAssetsResponseInner>), TypeInfoPropertyName = "ListGetAllMarginAssetsResponseInner")]
[JsonSerializable(typeof(List<GetDelistScheduleResponseInner>), TypeInfoPropertyName = "ListGetDelistScheduleResponseInner")]
[JsonSerializable(typeof(List<GetFutureHourlyInterestRateResponseInner>), TypeInfoPropertyName = "ListGetFutureHourlyInterestRateResponseInner")]
[JsonSerializable(typeof(List<GetListScheduleResponseInner>), TypeInfoPropertyName = "ListGetListScheduleResponseInner")]
[JsonSerializable(typeof(List<GetMarginAssetRiskBasedLiquidationRatioResponseInner>), TypeInfoPropertyName = "ListGetMarginAssetRiskBasedLiquidationRatioResponseInner")]
[JsonSerializable(typeof(List<GetSmallLiabilityExchangeCoinListResponseInner>), TypeInfoPropertyName = "ListGetSmallLiabilityExchangeCoinListResponseInner")]
[JsonSerializable(typeof(List<MarginAccountCancelAllOpenOrdersOnASymbolResponseInner>), TypeInfoPropertyName = "ListMarginAccountCancelAllOpenOrdersOnASymbolResponseInner")]
[JsonSerializable(typeof(List<QueryCrossIsolatedMarginCapitalFlowResponseInner>), TypeInfoPropertyName = "ListQueryCrossIsolatedMarginCapitalFlowResponseInner")]
[JsonSerializable(typeof(List<QueryCrossMarginFeeDataResponseInner>), TypeInfoPropertyName = "ListQueryCrossMarginFeeDataResponseInner")]
[JsonSerializable(typeof(List<QueryCurrentMarginOrderCountUsageResponseInner>), TypeInfoPropertyName = "ListQueryCurrentMarginOrderCountUsageResponseInner")]
[JsonSerializable(typeof(List<QueryIsolatedMarginFeeDataResponseInner>), TypeInfoPropertyName = "ListQueryIsolatedMarginFeeDataResponseInner")]
[JsonSerializable(typeof(List<QueryIsolatedMarginTierDataResponseInner>), TypeInfoPropertyName = "ListQueryIsolatedMarginTierDataResponseInner")]
[JsonSerializable(typeof(List<QueryLiabilityCoinLeverageBracketInCrossMarginProModeResponseInner>), TypeInfoPropertyName = "ListQueryLiabilityCoinLeverageBracketInCrossMarginProModeResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsAllOcoResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsAllOcoResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsAllOrdersResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsAllOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsOpenOcoResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsOpenOcoResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsOpenOrdersResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsOpenOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsOpenOtootocoOrderListsResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsOpenOtootocoOrderListsResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsTradeListResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsTradeListResponseInner")]
[JsonSerializable(typeof(List<QueryMarginInterestRateHistoryResponseInner>), TypeInfoPropertyName = "ListQueryMarginInterestRateHistoryResponseInner")]
[JsonSerializable(typeof(List<QueryPreventedMatchesResponseInner>), TypeInfoPropertyName = "ListQueryPreventedMatchesResponseInner")]
[JsonSerializable(typeof(List<QuerySpecialKeyListResponseInner>), TypeInfoPropertyName = "ListQuerySpecialKeyListResponseInner")]
[JsonSerializable(typeof(MarginAccountBorrowRepayResponse), TypeInfoPropertyName = "MarginAccountBorrowRepayResponse")]
[JsonSerializable(typeof(MarginAccountCancelOcoResponse), TypeInfoPropertyName = "MarginAccountCancelOcoResponse")]
[JsonSerializable(typeof(MarginAccountCancelOrderResponse), TypeInfoPropertyName = "MarginAccountCancelOrderResponse")]
[JsonSerializable(typeof(MarginAccountNewOcoResponse), TypeInfoPropertyName = "MarginAccountNewOcoResponse")]
[JsonSerializable(typeof(MarginAccountNewOrderResponse), TypeInfoPropertyName = "MarginAccountNewOrderResponse")]
[JsonSerializable(typeof(MarginAccountNewOtoResponse), TypeInfoPropertyName = "MarginAccountNewOtoResponse")]
[JsonSerializable(typeof(MarginAccountNewOtocoResponse), TypeInfoPropertyName = "MarginAccountNewOtocoResponse")]
[JsonSerializable(typeof(MarginManualLiquidationResponse), TypeInfoPropertyName = "MarginManualLiquidationResponse")]
[JsonSerializable(typeof(QueryBorrowRepayRecordsInMarginAccountResponse), TypeInfoPropertyName = "QueryBorrowRepayRecordsInMarginAccountResponse")]
[JsonSerializable(typeof(QueryCrossMarginAccountDetailsResponse), TypeInfoPropertyName = "QueryCrossMarginAccountDetailsResponse")]
[JsonSerializable(typeof(QueryEnabledIsolatedMarginAccountLimitResponse), TypeInfoPropertyName = "QueryEnabledIsolatedMarginAccountLimitResponse")]
[JsonSerializable(typeof(QueryIsolatedMarginAccountInfoResponse), TypeInfoPropertyName = "QueryIsolatedMarginAccountInfoResponse")]
[JsonSerializable(typeof(QueryLiquidationLoanRepayHistoryResponse), TypeInfoPropertyName = "QueryLiquidationLoanRepayHistoryResponse")]
[JsonSerializable(typeof(QueryLiquidationLoanResponse), TypeInfoPropertyName = "QueryLiquidationLoanResponse")]
[JsonSerializable(typeof(QueryMarginAccountsOcoResponse), TypeInfoPropertyName = "QueryMarginAccountsOcoResponse")]
[JsonSerializable(typeof(QueryMarginAccountsOrderResponse), TypeInfoPropertyName = "QueryMarginAccountsOrderResponse")]
[JsonSerializable(typeof(QueryMarginAvailableInventoryResponse), TypeInfoPropertyName = "QueryMarginAvailableInventoryResponse")]
[JsonSerializable(typeof(QueryMarginPriceindexResponse), TypeInfoPropertyName = "QueryMarginPriceindexResponse")]
[JsonSerializable(typeof(QueryMaxBorrowResponse), TypeInfoPropertyName = "QueryMaxBorrowResponse")]
[JsonSerializable(typeof(QueryMaxTransferOutAmountResponse), TypeInfoPropertyName = "QueryMaxTransferOutAmountResponse")]
[JsonSerializable(typeof(QuerySpecialKeyResponse), TypeInfoPropertyName = "QuerySpecialKeyResponse")]
[JsonSerializable(typeof(StartUserDataStreamResponse), TypeInfoPropertyName = "StartUserDataStreamResponse")]
[JsonSerializable(typeof(StartUserDataStreamV2Response), TypeInfoPropertyName = "StartUserDataStreamV2Response")]
public sealed partial class MarginTradingRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the MarginTrading RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
