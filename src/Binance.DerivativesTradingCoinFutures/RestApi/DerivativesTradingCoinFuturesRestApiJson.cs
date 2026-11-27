//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.DerivativesTradingCoinFutures.RestApi;

/// <summary>The System.Text.Json context of the DerivativesTradingCoinFutures RestApi models: <c>JsonSerializer.Serialize(value, DerivativesTradingCoinFuturesRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountInformationResponse), TypeInfoPropertyName = "AccountInformationResponse")]
[JsonSerializable(typeof(AutoCancelAllOpenOrdersResponse), TypeInfoPropertyName = "AutoCancelAllOpenOrdersResponse")]
[JsonSerializable(typeof(CancelAlgoOrderResponse), TypeInfoPropertyName = "CancelAlgoOrderResponse")]
[JsonSerializable(typeof(CancelAllAlgoOpenOrdersResponse), TypeInfoPropertyName = "CancelAllAlgoOpenOrdersResponse")]
[JsonSerializable(typeof(CancelAllOpenOrdersResponse), TypeInfoPropertyName = "CancelAllOpenOrdersResponse")]
[JsonSerializable(typeof(CancelOrderResponse), TypeInfoPropertyName = "CancelOrderResponse")]
[JsonSerializable(typeof(ChangeInitialLeverageResponse), TypeInfoPropertyName = "ChangeInitialLeverageResponse")]
[JsonSerializable(typeof(ChangeMarginTypeResponse), TypeInfoPropertyName = "ChangeMarginTypeResponse")]
[JsonSerializable(typeof(ChangePositionModeResponse), TypeInfoPropertyName = "ChangePositionModeResponse")]
[JsonSerializable(typeof(CheckServerTimeResponse), TypeInfoPropertyName = "CheckServerTimeResponse")]
[JsonSerializable(typeof(ExchangeInformationResponse), TypeInfoPropertyName = "ExchangeInformationResponse")]
[JsonSerializable(typeof(GetCurrentPositionModeResponse), TypeInfoPropertyName = "GetCurrentPositionModeResponse")]
[JsonSerializable(typeof(GetDownloadIdForFuturesOrderHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForFuturesOrderHistoryResponse")]
[JsonSerializable(typeof(GetDownloadIdForFuturesTradeHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForFuturesTradeHistoryResponse")]
[JsonSerializable(typeof(GetDownloadIdForFuturesTransactionHistoryResponse), TypeInfoPropertyName = "GetDownloadIdForFuturesTransactionHistoryResponse")]
[JsonSerializable(typeof(GetFuturesOrderHistoryDownloadLinkByIdResponse), TypeInfoPropertyName = "GetFuturesOrderHistoryDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetFuturesTradeDownloadLinkByIdResponse), TypeInfoPropertyName = "GetFuturesTradeDownloadLinkByIdResponse")]
[JsonSerializable(typeof(GetFuturesTransactionHistoryDownloadLinkByIdResponse), TypeInfoPropertyName = "GetFuturesTransactionHistoryDownloadLinkByIdResponse")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(KeepaliveUserDataStreamResponse), TypeInfoPropertyName = "KeepaliveUserDataStreamResponse")]
[JsonSerializable(typeof(List<AccountTradeListResponseInner>), TypeInfoPropertyName = "ListAccountTradeListResponseInner")]
[JsonSerializable(typeof(List<AllOrdersResponseInner>), TypeInfoPropertyName = "ListAllOrdersResponseInner")]
[JsonSerializable(typeof(List<BasisResponseInner>), TypeInfoPropertyName = "ListBasisResponseInner")]
[JsonSerializable(typeof(List<CancelMultipleOrdersResponseInner>), TypeInfoPropertyName = "ListCancelMultipleOrdersResponseInner")]
[JsonSerializable(typeof(List<CompressedAggregateTradesListResponseInner>), TypeInfoPropertyName = "ListCompressedAggregateTradesListResponseInner")]
[JsonSerializable(typeof(List<CurrentAllAlgoOpenOrdersResponseInner>), TypeInfoPropertyName = "ListCurrentAllAlgoOpenOrdersResponseInner")]
[JsonSerializable(typeof(List<CurrentAllOpenOrdersResponseInner>), TypeInfoPropertyName = "ListCurrentAllOpenOrdersResponseInner")]
[JsonSerializable(typeof(List<FuturesAccountBalanceResponseInner>), TypeInfoPropertyName = "ListFuturesAccountBalanceResponseInner")]
[JsonSerializable(typeof(List<GetFundingRateHistoryOfPerpetualFuturesResponseInner>), TypeInfoPropertyName = "ListGetFundingRateHistoryOfPerpetualFuturesResponseInner")]
[JsonSerializable(typeof(List<GetFundingRateInfoResponseInner>), TypeInfoPropertyName = "ListGetFundingRateInfoResponseInner")]
[JsonSerializable(typeof(List<GetIncomeHistoryResponseInner>), TypeInfoPropertyName = "ListGetIncomeHistoryResponseInner")]
[JsonSerializable(typeof(List<GetOrderModifyHistoryResponseInner>), TypeInfoPropertyName = "ListGetOrderModifyHistoryResponseInner")]
[JsonSerializable(typeof(List<GetPositionMarginChangeHistoryResponseInner>), TypeInfoPropertyName = "ListGetPositionMarginChangeHistoryResponseInner")]
[JsonSerializable(typeof(List<IndexPriceAndMarkPriceResponseInner>), TypeInfoPropertyName = "ListIndexPriceAndMarkPriceResponseInner")]
[JsonSerializable(typeof(List<List<ContinuousContractKlineCandlestickDataItemInner>>), TypeInfoPropertyName = "ListListContinuousContractKlineCandlestickDataItemInner")]
[JsonSerializable(typeof(List<List<IndexPriceKlineCandlestickDataItemInner>>), TypeInfoPropertyName = "ListListIndexPriceKlineCandlestickDataItemInner")]
[JsonSerializable(typeof(List<List<PremiumIndexKlineDataItemInner>>), TypeInfoPropertyName = "ListListPremiumIndexKlineDataItemInner")]
[JsonSerializable(typeof(List<LongShortRatioResponseInner>), TypeInfoPropertyName = "ListLongShortRatioResponseInner")]
[JsonSerializable(typeof(List<ModifyMultipleOrdersBatchOrdersParameterInner>), TypeInfoPropertyName = "ListModifyMultipleOrdersBatchOrdersParameterInner")]
[JsonSerializable(typeof(List<ModifyMultipleOrdersResponseInner>), TypeInfoPropertyName = "ListModifyMultipleOrdersResponseInner")]
[JsonSerializable(typeof(List<NotionalBracketForPairResponseInner>), TypeInfoPropertyName = "ListNotionalBracketForPairResponseInner")]
[JsonSerializable(typeof(List<NotionalBracketForSymbolResponseInner>), TypeInfoPropertyName = "ListNotionalBracketForSymbolResponseInner")]
[JsonSerializable(typeof(List<OldTradesLookupResponseInner>), TypeInfoPropertyName = "ListOldTradesLookupResponseInner")]
[JsonSerializable(typeof(List<OpenInterestStatisticsResponseInner>), TypeInfoPropertyName = "ListOpenInterestStatisticsResponseInner")]
[JsonSerializable(typeof(List<PlaceMultipleOrdersBatchOrdersParameterInner>), TypeInfoPropertyName = "ListPlaceMultipleOrdersBatchOrdersParameterInner")]
[JsonSerializable(typeof(List<PlaceMultipleOrdersResponseInner>), TypeInfoPropertyName = "ListPlaceMultipleOrdersResponseInner")]
[JsonSerializable(typeof(List<PositionAdlQuantileEstimationResponseInner>), TypeInfoPropertyName = "ListPositionAdlQuantileEstimationResponseInner")]
[JsonSerializable(typeof(List<PositionInformationResponseInner>), TypeInfoPropertyName = "ListPositionInformationResponseInner")]
[JsonSerializable(typeof(List<QueryAllAlgoOrdersResponseInner>), TypeInfoPropertyName = "ListQueryAllAlgoOrdersResponseInner")]
[JsonSerializable(typeof(List<RecentTradesListResponseInner>), TypeInfoPropertyName = "ListRecentTradesListResponseInner")]
[JsonSerializable(typeof(List<SymbolOrderBookTickerResponseInner>), TypeInfoPropertyName = "ListSymbolOrderBookTickerResponseInner")]
[JsonSerializable(typeof(List<SymbolPriceTickerResponseInner>), TypeInfoPropertyName = "ListSymbolPriceTickerResponseInner")]
[JsonSerializable(typeof(List<TakerBuySellVolumeResponseInner>), TypeInfoPropertyName = "ListTakerBuySellVolumeResponseInner")]
[JsonSerializable(typeof(List<Ticker24hrPriceChangeStatisticsResponseInner>), TypeInfoPropertyName = "ListTicker24hrPriceChangeStatisticsResponseInner")]
[JsonSerializable(typeof(List<TopTraderLongShortRatioAccountsResponseInner>), TypeInfoPropertyName = "ListTopTraderLongShortRatioAccountsResponseInner")]
[JsonSerializable(typeof(List<TopTraderLongShortRatioPositionsResponseInner>), TypeInfoPropertyName = "ListTopTraderLongShortRatioPositionsResponseInner")]
[JsonSerializable(typeof(List<UsersForceOrdersResponseInner>), TypeInfoPropertyName = "ListUsersForceOrdersResponseInner")]
[JsonSerializable(typeof(ModifyIsolatedPositionMarginResponse), TypeInfoPropertyName = "ModifyIsolatedPositionMarginResponse")]
[JsonSerializable(typeof(ModifyOrderResponse), TypeInfoPropertyName = "ModifyOrderResponse")]
[JsonSerializable(typeof(NewAlgoOrderResponse), TypeInfoPropertyName = "NewAlgoOrderResponse")]
[JsonSerializable(typeof(NewOrderResponse), TypeInfoPropertyName = "NewOrderResponse")]
[JsonSerializable(typeof(OpenInterestResponse), TypeInfoPropertyName = "OpenInterestResponse")]
[JsonSerializable(typeof(OrderBookResponse), TypeInfoPropertyName = "OrderBookResponse")]
[JsonSerializable(typeof(QueryAlgoOrderResponse), TypeInfoPropertyName = "QueryAlgoOrderResponse")]
[JsonSerializable(typeof(QueryCurrentOpenOrderResponse), TypeInfoPropertyName = "QueryCurrentOpenOrderResponse")]
[JsonSerializable(typeof(QueryIndexPriceConstituentsResponse), TypeInfoPropertyName = "QueryIndexPriceConstituentsResponse")]
[JsonSerializable(typeof(QueryOrderResponse), TypeInfoPropertyName = "QueryOrderResponse")]
[JsonSerializable(typeof(StartUserDataStreamResponse), TypeInfoPropertyName = "StartUserDataStreamResponse")]
[JsonSerializable(typeof(UserCommissionRateResponse), TypeInfoPropertyName = "UserCommissionRateResponse")]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(string))]
public sealed partial class DerivativesTradingCoinFuturesRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the DerivativesTradingCoinFutures RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
