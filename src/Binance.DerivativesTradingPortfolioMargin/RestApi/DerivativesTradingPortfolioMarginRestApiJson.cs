//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

/// <summary>The System.Text.Json context of the DerivativesTradingPortfolioMargin RestApi models: <c>JsonSerializer.Serialize(value, DerivativesTradingPortfolioMarginRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountBalanceResponse), TypeInfoPropertyName = "AccountBalanceResponse")]
[JsonSerializable(typeof(AccountBalanceResponse2), TypeInfoPropertyName = "AccountBalanceResponse2")]
[JsonSerializable(typeof(AccountInformationResponse), TypeInfoPropertyName = "AccountInformationResponse")]
[JsonSerializable(typeof(BnbTransferResponse), TypeInfoPropertyName = "BnbTransferResponse")]
[JsonSerializable(typeof(CancelAllCmOpenConditionalOrdersResponse), TypeInfoPropertyName = "CancelAllCmOpenConditionalOrdersResponse")]
[JsonSerializable(typeof(CancelAllCmOpenOrdersResponse), TypeInfoPropertyName = "CancelAllCmOpenOrdersResponse")]
[JsonSerializable(typeof(CancelAllUmAlgoOpenOrdersResponse), TypeInfoPropertyName = "CancelAllUmAlgoOpenOrdersResponse")]
[JsonSerializable(typeof(CancelAllUmOpenOrdersResponse), TypeInfoPropertyName = "CancelAllUmOpenOrdersResponse")]
[JsonSerializable(typeof(CancelCmConditionalOrderResponse), TypeInfoPropertyName = "CancelCmConditionalOrderResponse")]
[JsonSerializable(typeof(CancelCmOrderResponse), TypeInfoPropertyName = "CancelCmOrderResponse")]
[JsonSerializable(typeof(CancelMarginAccountOcoOrdersResponse), TypeInfoPropertyName = "CancelMarginAccountOcoOrdersResponse")]
[JsonSerializable(typeof(CancelMarginAccountOrderResponse), TypeInfoPropertyName = "CancelMarginAccountOrderResponse")]
[JsonSerializable(typeof(CancelUmAlgoOrderResponse), TypeInfoPropertyName = "CancelUmAlgoOrderResponse")]
[JsonSerializable(typeof(CancelUmOrderResponse), TypeInfoPropertyName = "CancelUmOrderResponse")]
[JsonSerializable(typeof(ChangeAutoRepayFuturesStatusResponse), TypeInfoPropertyName = "ChangeAutoRepayFuturesStatusResponse")]
[JsonSerializable(typeof(ChangeCmInitialLeverageResponse), TypeInfoPropertyName = "ChangeCmInitialLeverageResponse")]
[JsonSerializable(typeof(ChangeCmPositionModeResponse), TypeInfoPropertyName = "ChangeCmPositionModeResponse")]
[JsonSerializable(typeof(ChangeUmInitialLeverageResponse), TypeInfoPropertyName = "ChangeUmInitialLeverageResponse")]
[JsonSerializable(typeof(ChangeUmPositionModeResponse), TypeInfoPropertyName = "ChangeUmPositionModeResponse")]
[JsonSerializable(typeof(FundAutoCollectionResponse), TypeInfoPropertyName = "FundAutoCollectionResponse")]
[JsonSerializable(typeof(FundCollectionByAssetResponse), TypeInfoPropertyName = "FundCollectionByAssetResponse")]
[JsonSerializable(typeof(FuturesTradfiPerpsContractResponse), TypeInfoPropertyName = "FuturesTradfiPerpsContractResponse")]
[JsonSerializable(typeof(GetAutoRepayFuturesStatusResponse), TypeInfoPropertyName = "GetAutoRepayFuturesStatusResponse")]
[JsonSerializable(typeof(GetCmAccountDetailResponse), TypeInfoPropertyName = "GetCmAccountDetailResponse")]
[JsonSerializable(typeof(GetCmCurrentPositionModeResponse), TypeInfoPropertyName = "GetCmCurrentPositionModeResponse")]
[JsonSerializable(typeof(GetCmFuturesOrderDownloadLinkByIdResponse), TypeInfoPropertyName = "GetCmFuturesOrderDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetCmFuturesTradeDownloadLinkByIdResponse), TypeInfoPropertyName = "GetCmFuturesTradeDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetCmFuturesTransactionDownloadLinkByIdResponse), TypeInfoPropertyName = "GetCmFuturesTransactionDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetDownloadIdForCmFuturesOrderHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForCmFuturesOrderHistoryResponse")]
[JsonSerializable(typeof(GetDownloadIdForCmFuturesTradeHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForCmFuturesTradeHistoryResponse")]
[JsonSerializable(typeof(GetDownloadIdForCmFuturesTransactionHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForCmFuturesTransactionHistoryResponse")]
[JsonSerializable(typeof(GetDownloadIdForUmFuturesOrderHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForUmFuturesOrderHistoryResponse")]
[JsonSerializable(typeof(GetDownloadIdForUmFuturesTradeHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForUmFuturesTradeHistoryResponse")]
[JsonSerializable(typeof(GetDownloadIdForUmFuturesTransactionHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForUmFuturesTransactionHistoryResponse")]
[JsonSerializable(typeof(GetMarginBorrowLoanInterestHistoryResponse), TypeInfoPropertyName = "GetMarginBorrowLoanInterestHistoryResponse")]
[JsonSerializable(typeof(GetUmAccountDetailResponse), TypeInfoPropertyName = "GetUmAccountDetailResponse")]
[JsonSerializable(typeof(GetUmAccountDetailV2Response), TypeInfoPropertyName = "GetUmAccountDetailV2Response")]
[JsonSerializable(typeof(GetUmCurrentPositionModeResponse), TypeInfoPropertyName = "GetUmCurrentPositionModeResponse")]
[JsonSerializable(typeof(GetUmFuturesBnbBurnStatusResponse), TypeInfoPropertyName = "GetUmFuturesBnbBurnStatusResponse")]
[JsonSerializable(typeof(GetUmFuturesOrderDownloadLinkByIdResponse), TypeInfoPropertyName = "GetUmFuturesOrderDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetUmFuturesTradeDownloadLinkByIdResponse), TypeInfoPropertyName = "GetUmFuturesTradeDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetUmFuturesTransactionDownloadLinkByIdResponse), TypeInfoPropertyName = "GetUmFuturesTransactionDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetUserCommissionRateForCmResponse), TypeInfoPropertyName = "GetUserCommissionRateForCmResponse")]
[JsonSerializable(typeof(GetUserCommissionRateForUmResponse), TypeInfoPropertyName = "GetUserCommissionRateForUmResponse")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(List<AccountBalanceResponse1Inner>), TypeInfoPropertyName = "ListAccountBalanceResponse1Inner")]
[JsonSerializable(typeof(List<CancelMarginAccountAllOpenOrdersOnASymbolResponseInner>), TypeInfoPropertyName = "ListCancelMarginAccountAllOpenOrdersOnASymbolResponseInner")]
[JsonSerializable(typeof(List<CmAccountTradeListResponseInner>), TypeInfoPropertyName = "ListCmAccountTradeListResponseInner")]
[JsonSerializable(typeof(List<CmNotionalAndLeverageBracketsResponseInner>), TypeInfoPropertyName = "ListCmNotionalAndLeverageBracketsResponseInner")]
[JsonSerializable(typeof(List<CmPositionAdlQuantileEstimationResponseInner>), TypeInfoPropertyName = "ListCmPositionAdlQuantileEstimationResponseInner")]
[JsonSerializable(typeof(List<GetCmIncomeHistoryResponseInner>), TypeInfoPropertyName = "ListGetCmIncomeHistoryResponseInner")]
[JsonSerializable(typeof(List<GetUmIncomeHistoryResponseInner>), TypeInfoPropertyName = "ListGetUmIncomeHistoryResponseInner")]
[JsonSerializable(typeof(List<MarginAccountTradeListResponseInner>), TypeInfoPropertyName = "ListMarginAccountTradeListResponseInner")]
[JsonSerializable(typeof(List<QueryAllCmConditionalOrdersResponseInner>), TypeInfoPropertyName = "ListQueryAllCmConditionalOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryAllCmOrdersResponseInner>), TypeInfoPropertyName = "ListQueryAllCmOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryAllCurrentCmOpenConditionalOrdersResponseInner>), TypeInfoPropertyName = "ListQueryAllCurrentCmOpenConditionalOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryAllCurrentUmOpenAlgoOrdersResponseInner>), TypeInfoPropertyName = "ListQueryAllCurrentUmOpenAlgoOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryAllCurrentUmOpenOrdersResponseInner>), TypeInfoPropertyName = "ListQueryAllCurrentUmOpenOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryAllMarginAccountOrdersResponseInner>), TypeInfoPropertyName = "ListQueryAllMarginAccountOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryCmModifyOrderHistoryResponseInner>), TypeInfoPropertyName = "ListQueryCmModifyOrderHistoryResponseInner")]
[JsonSerializable(typeof(List<QueryCmPositionInformationResponseInner>), TypeInfoPropertyName = "ListQueryCmPositionInformationResponseInner")]
[JsonSerializable(typeof(List<QueryCurrentMarginOpenOrderResponseInner>), TypeInfoPropertyName = "ListQueryCurrentMarginOpenOrderResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsAllOcoResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsAllOcoResponseInner")]
[JsonSerializable(typeof(List<QueryMarginAccountsOpenOcoResponseInner>), TypeInfoPropertyName = "ListQueryMarginAccountsOpenOcoResponseInner")]
[JsonSerializable(typeof(List<QueryPortfolioMarginNegativeBalanceInterestHistoryResponseInner>), TypeInfoPropertyName = "ListQueryPortfolioMarginNegativeBalanceInterestHistoryResponseInner")]
[JsonSerializable(typeof(List<QueryUmAlgoOrderHistoryResponseInner>), TypeInfoPropertyName = "ListQueryUmAlgoOrderHistoryResponseInner")]
[JsonSerializable(typeof(List<QueryUmModifyOrderHistoryResponseInner>), TypeInfoPropertyName = "ListQueryUmModifyOrderHistoryResponseInner")]
[JsonSerializable(typeof(List<QueryUmPositionInformationResponseInner>), TypeInfoPropertyName = "ListQueryUmPositionInformationResponseInner")]
[JsonSerializable(typeof(List<QueryUserRateLimitResponseInner>), TypeInfoPropertyName = "ListQueryUserRateLimitResponseInner")]
[JsonSerializable(typeof(List<QueryUsersCmForceOrdersResponseInner>), TypeInfoPropertyName = "ListQueryUsersCmForceOrdersResponseInner")]
[JsonSerializable(typeof(List<QueryUsersUmForceOrdersResponseInner>), TypeInfoPropertyName = "ListQueryUsersUmForceOrdersResponseInner")]
[JsonSerializable(typeof(List<UmAccountTradeListResponseInner>), TypeInfoPropertyName = "ListUmAccountTradeListResponseInner")]
[JsonSerializable(typeof(List<UmFuturesSymbolConfigurationResponseInner>), TypeInfoPropertyName = "ListUmFuturesSymbolConfigurationResponseInner")]
[JsonSerializable(typeof(List<UmNotionalAndLeverageBracketsResponseInner>), TypeInfoPropertyName = "ListUmNotionalAndLeverageBracketsResponseInner")]
[JsonSerializable(typeof(List<UmPositionAdlQuantileEstimationResponseInner>), TypeInfoPropertyName = "ListUmPositionAdlQuantileEstimationResponseInner")]
[JsonSerializable(typeof(MarginAccountBorrowResponse), TypeInfoPropertyName = "MarginAccountBorrowResponse")]
[JsonSerializable(typeof(MarginAccountNewOcoResponse), TypeInfoPropertyName = "MarginAccountNewOcoResponse")]
[JsonSerializable(typeof(MarginAccountRepayDebtResponse), TypeInfoPropertyName = "MarginAccountRepayDebtResponse")]
[JsonSerializable(typeof(MarginAccountRepayResponse), TypeInfoPropertyName = "MarginAccountRepayResponse")]
[JsonSerializable(typeof(MarginMaxBorrowResponse), TypeInfoPropertyName = "MarginMaxBorrowResponse")]
[JsonSerializable(typeof(ModifyCmOrderResponse), TypeInfoPropertyName = "ModifyCmOrderResponse")]
[JsonSerializable(typeof(ModifyUmOrderResponse), TypeInfoPropertyName = "ModifyUmOrderResponse")]
[JsonSerializable(typeof(NewCmConditionalOrderResponse), TypeInfoPropertyName = "NewCmConditionalOrderResponse")]
[JsonSerializable(typeof(NewCmOrderResponse), TypeInfoPropertyName = "NewCmOrderResponse")]
[JsonSerializable(typeof(NewMarginOrderResponse), TypeInfoPropertyName = "NewMarginOrderResponse")]
[JsonSerializable(typeof(NewUmAlgoOrderResponse), TypeInfoPropertyName = "NewUmAlgoOrderResponse")]
[JsonSerializable(typeof(NewUmOrderResponse), TypeInfoPropertyName = "NewUmOrderResponse")]
[JsonSerializable(typeof(PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponse), TypeInfoPropertyName = "PortfolioMarginUmTradingQuantitativeRulesIndicatorsResponse")]
[JsonSerializable(typeof(QueryCmConditionalOrderHistoryResponse), TypeInfoPropertyName = "QueryCmConditionalOrderHistoryResponse")]
[JsonSerializable(typeof(QueryCmOrderResponse), TypeInfoPropertyName = "QueryCmOrderResponse")]
[JsonSerializable(typeof(QueryCurrentCmOpenConditionalOrderResponse), TypeInfoPropertyName = "QueryCurrentCmOpenConditionalOrderResponse")]
[JsonSerializable(typeof(QueryCurrentUmOpenAlgoOrderResponse), TypeInfoPropertyName = "QueryCurrentUmOpenAlgoOrderResponse")]
[JsonSerializable(typeof(QueryCurrentUmOpenOrderResponse), TypeInfoPropertyName = "QueryCurrentUmOpenOrderResponse")]
[JsonSerializable(typeof(QueryMarginAccountOrderResponse), TypeInfoPropertyName = "QueryMarginAccountOrderResponse")]
[JsonSerializable(typeof(QueryMarginAccountsOcoResponse), TypeInfoPropertyName = "QueryMarginAccountsOcoResponse")]
[JsonSerializable(typeof(QueryMarginLoanRecordResponse), TypeInfoPropertyName = "QueryMarginLoanRecordResponse")]
[JsonSerializable(typeof(QueryMarginMaxWithdrawResponse), TypeInfoPropertyName = "QueryMarginMaxWithdrawResponse")]
[JsonSerializable(typeof(QueryMarginRepayRecordResponse), TypeInfoPropertyName = "QueryMarginRepayRecordResponse")]
[JsonSerializable(typeof(QueryUmOrderResponse), TypeInfoPropertyName = "QueryUmOrderResponse")]
[JsonSerializable(typeof(QueryUserNegativeBalanceAutoExchangeRecordResponse), TypeInfoPropertyName = "QueryUserNegativeBalanceAutoExchangeRecordResponse")]
[JsonSerializable(typeof(QueryUsersMarginForceOrdersResponse), TypeInfoPropertyName = "QueryUsersMarginForceOrdersResponse")]
[JsonSerializable(typeof(RepayFuturesNegativeBalanceResponse), TypeInfoPropertyName = "RepayFuturesNegativeBalanceResponse")]
[JsonSerializable(typeof(StartUserDataStreamResponse), TypeInfoPropertyName = "StartUserDataStreamResponse")]
[JsonSerializable(typeof(ToggleBnbBurnOnUmFuturesTradeResponse), TypeInfoPropertyName = "ToggleBnbBurnOnUmFuturesTradeResponse")]
[JsonSerializable(typeof(UmFuturesAccountConfigurationResponse), TypeInfoPropertyName = "UmFuturesAccountConfigurationResponse")]
public sealed partial class DerivativesTradingPortfolioMarginRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingPortfolioMargin RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
