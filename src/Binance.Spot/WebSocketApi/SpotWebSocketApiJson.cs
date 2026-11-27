//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Spot.WebSocketApi;

/// <summary>The System.Text.Json context of the Spot WebSocketApi models: <c>JsonSerializer.Serialize(value, SpotWebSocketApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountCommissionResponseResult), TypeInfoPropertyName = "AccountCommissionResponseResult")]
[JsonSerializable(typeof(AccountStatusResponseResult), TypeInfoPropertyName = "AccountStatusResponseResult")]
[JsonSerializable(typeof(AvgPriceResponseResult), TypeInfoPropertyName = "AvgPriceResponseResult")]
[JsonSerializable(typeof(BalanceUpdate), TypeInfoPropertyName = "BalanceUpdate")]
[JsonSerializable(typeof(DepthResponseResult), TypeInfoPropertyName = "DepthResponseResult")]
[JsonSerializable(typeof(EventStreamTerminated), TypeInfoPropertyName = "EventStreamTerminated")]
[JsonSerializable(typeof(ExchangeInfoResponse), TypeInfoPropertyName = "ExchangeInfoResponse")]
[JsonSerializable(typeof(ExchangeMaxNumAlgoOrdersFilter), TypeInfoPropertyName = "ExchangeMaxNumAlgoOrdersFilter")]
[JsonSerializable(typeof(ExchangeMaxNumIcebergOrdersFilter), TypeInfoPropertyName = "ExchangeMaxNumIcebergOrdersFilter")]
[JsonSerializable(typeof(ExchangeMaxNumOrderListsFilter), TypeInfoPropertyName = "ExchangeMaxNumOrderListsFilter")]
[JsonSerializable(typeof(ExchangeMaxNumOrdersFilter), TypeInfoPropertyName = "ExchangeMaxNumOrdersFilter")]
[JsonSerializable(typeof(ExecutionReport), TypeInfoPropertyName = "ExecutionReport")]
[JsonSerializable(typeof(ExecutionRulesResponseResult), TypeInfoPropertyName = "ExecutionRulesResponseResult")]
[JsonSerializable(typeof(ExternalLockUpdate), TypeInfoPropertyName = "ExternalLockUpdate")]
[JsonSerializable(typeof(IcebergPartsFilter), TypeInfoPropertyName = "IcebergPartsFilter")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(List<AccountRateLimitsOrdersResponseResultInner>), TypeInfoPropertyName = "ListAccountRateLimitsOrdersResponseResultInner")]
[JsonSerializable(typeof(List<AllOrderListsResponseResultInner>), TypeInfoPropertyName = "ListAllOrderListsResponseResultInner")]
[JsonSerializable(typeof(List<AllOrdersResponseResultInner>), TypeInfoPropertyName = "ListAllOrdersResponseResultInner")]
[JsonSerializable(typeof(List<BlockTradesHistoricalResponseResultInner>), TypeInfoPropertyName = "ListBlockTradesHistoricalResponseResultInner")]
[JsonSerializable(typeof(List<List<KlinesResponseResultInnerInner>>), TypeInfoPropertyName = "ListListKlinesResponseResultInnerInner")]
[JsonSerializable(typeof(List<MyAllocationsResponseResultInner>), TypeInfoPropertyName = "ListMyAllocationsResponseResultInner")]
[JsonSerializable(typeof(List<MyPreventedMatchesResponseResultInner>), TypeInfoPropertyName = "ListMyPreventedMatchesResponseResultInner")]
[JsonSerializable(typeof(List<MyTradesResponseResultInner>), TypeInfoPropertyName = "ListMyTradesResponseResultInner")]
[JsonSerializable(typeof(List<OpenOrderListsStatusResponseResultInner>), TypeInfoPropertyName = "ListOpenOrderListsStatusResponseResultInner")]
[JsonSerializable(typeof(List<OpenOrdersCancelAllResponseResultInner>), TypeInfoPropertyName = "ListOpenOrdersCancelAllResponseResultInner")]
[JsonSerializable(typeof(List<OpenOrdersStatusResponseResultInner>), TypeInfoPropertyName = "ListOpenOrdersStatusResponseResultInner")]
[JsonSerializable(typeof(List<OrderAmendmentsResponseResultInner>), TypeInfoPropertyName = "ListOrderAmendmentsResponseResultInner")]
[JsonSerializable(typeof(List<SessionSubscriptionsResponseResultInner>), TypeInfoPropertyName = "ListSessionSubscriptionsResponseResultInner")]
[JsonSerializable(typeof(List<SorOrderPlaceResponseResultInner>), TypeInfoPropertyName = "ListSorOrderPlaceResponseResultInner")]
[JsonSerializable(typeof(List<Ticker24hrResponse2ResultInner>), TypeInfoPropertyName = "ListTicker24hrResponse2ResultInner")]
[JsonSerializable(typeof(List<TickerBookResponse2ResultInner>), TypeInfoPropertyName = "ListTickerBookResponse2ResultInner")]
[JsonSerializable(typeof(List<TickerPriceResponse2ResultInner>), TypeInfoPropertyName = "ListTickerPriceResponse2ResultInner")]
[JsonSerializable(typeof(List<TickerResponse2ResultInner>), TypeInfoPropertyName = "ListTickerResponse2ResultInner")]
[JsonSerializable(typeof(List<TickerTradingDayResponse2ResultInner>), TypeInfoPropertyName = "ListTickerTradingDayResponse2ResultInner")]
[JsonSerializable(typeof(List<TradesAggregateResponseResultInner>), TypeInfoPropertyName = "ListTradesAggregateResponseResultInner")]
[JsonSerializable(typeof(List<TradesHistoricalResponseResultInner>), TypeInfoPropertyName = "ListTradesHistoricalResponseResultInner")]
[JsonSerializable(typeof(List<TradesRecentResponseResultInner>), TypeInfoPropertyName = "ListTradesRecentResponseResultInner")]
[JsonSerializable(typeof(ListStatus), TypeInfoPropertyName = "ListStatus")]
[JsonSerializable(typeof(LotSizeFilter), TypeInfoPropertyName = "LotSizeFilter")]
[JsonSerializable(typeof(MarketLotSizeFilter), TypeInfoPropertyName = "MarketLotSizeFilter")]
[JsonSerializable(typeof(MaxNumAlgoOrdersFilter), TypeInfoPropertyName = "MaxNumAlgoOrdersFilter")]
[JsonSerializable(typeof(MaxNumIcebergOrdersFilter), TypeInfoPropertyName = "MaxNumIcebergOrdersFilter")]
[JsonSerializable(typeof(MaxNumOrderAmendsFilter), TypeInfoPropertyName = "MaxNumOrderAmendsFilter")]
[JsonSerializable(typeof(MaxNumOrderListsFilter), TypeInfoPropertyName = "MaxNumOrderListsFilter")]
[JsonSerializable(typeof(MaxNumOrdersFilter), TypeInfoPropertyName = "MaxNumOrdersFilter")]
[JsonSerializable(typeof(MaxPositionFilter), TypeInfoPropertyName = "MaxPositionFilter")]
[JsonSerializable(typeof(MinNotionalFilter), TypeInfoPropertyName = "MinNotionalFilter")]
[JsonSerializable(typeof(MyFiltersResponse), TypeInfoPropertyName = "MyFiltersResponse")]
[JsonSerializable(typeof(NotionalFilter), TypeInfoPropertyName = "NotionalFilter")]
[JsonSerializable(typeof(OrderAmendKeepPriorityResponseResult), TypeInfoPropertyName = "OrderAmendKeepPriorityResponseResult")]
[JsonSerializable(typeof(OrderCancelReplaceResponseResult), TypeInfoPropertyName = "OrderCancelReplaceResponseResult")]
[JsonSerializable(typeof(OrderCancelResponseResult), TypeInfoPropertyName = "OrderCancelResponseResult")]
[JsonSerializable(typeof(OrderListCancelResponseResult), TypeInfoPropertyName = "OrderListCancelResponseResult")]
[JsonSerializable(typeof(OrderListPlaceOcoResponseResult), TypeInfoPropertyName = "OrderListPlaceOcoResponseResult")]
[JsonSerializable(typeof(OrderListPlaceOpoResponseResult), TypeInfoPropertyName = "OrderListPlaceOpoResponseResult")]
[JsonSerializable(typeof(OrderListPlaceOpocoResponseResult), TypeInfoPropertyName = "OrderListPlaceOpocoResponseResult")]
[JsonSerializable(typeof(OrderListPlaceOtoResponseResult), TypeInfoPropertyName = "OrderListPlaceOtoResponseResult")]
[JsonSerializable(typeof(OrderListPlaceOtocoResponseResult), TypeInfoPropertyName = "OrderListPlaceOtocoResponseResult")]
[JsonSerializable(typeof(OrderListPlaceResponseResult), TypeInfoPropertyName = "OrderListPlaceResponseResult")]
[JsonSerializable(typeof(OrderListStatusResponseResult), TypeInfoPropertyName = "OrderListStatusResponseResult")]
[JsonSerializable(typeof(OrderPlaceResponseResult), TypeInfoPropertyName = "OrderPlaceResponseResult")]
[JsonSerializable(typeof(OrderStatusResponseResult), TypeInfoPropertyName = "OrderStatusResponseResult")]
[JsonSerializable(typeof(OrderTestResponseResult), TypeInfoPropertyName = "OrderTestResponseResult")]
[JsonSerializable(typeof(OutboundAccountPosition), TypeInfoPropertyName = "OutboundAccountPosition")]
[JsonSerializable(typeof(PercentPriceBySideFilter), TypeInfoPropertyName = "PercentPriceBySideFilter")]
[JsonSerializable(typeof(PercentPriceFilter), TypeInfoPropertyName = "PercentPriceFilter")]
[JsonSerializable(typeof(PriceFilter), TypeInfoPropertyName = "PriceFilter")]
[JsonSerializable(typeof(ReferencePriceCalculationResponseResult), TypeInfoPropertyName = "ReferencePriceCalculationResponseResult")]
[JsonSerializable(typeof(ReferencePriceResponseResult), TypeInfoPropertyName = "ReferencePriceResponseResult")]
[JsonSerializable(typeof(SessionLogonResponseResult), TypeInfoPropertyName = "SessionLogonResponseResult")]
[JsonSerializable(typeof(SessionLogoutResponseResult), TypeInfoPropertyName = "SessionLogoutResponseResult")]
[JsonSerializable(typeof(SessionStatusResponseResult), TypeInfoPropertyName = "SessionStatusResponseResult")]
[JsonSerializable(typeof(SorOrderTestResponseResult), TypeInfoPropertyName = "SorOrderTestResponseResult")]
[JsonSerializable(typeof(TPlusSellFilter), TypeInfoPropertyName = "TPlusSellFilter")]
[JsonSerializable(typeof(Ticker24hrResponse1), TypeInfoPropertyName = "Ticker24hrResponse1")]
[JsonSerializable(typeof(Ticker24hrResponse1Result), TypeInfoPropertyName = "Ticker24hrResponse1Result")]
[JsonSerializable(typeof(Ticker24hrResponse2), TypeInfoPropertyName = "Ticker24hrResponse2")]
[JsonSerializable(typeof(Ticker24hrResponseResult), TypeInfoPropertyName = "Ticker24hrResponseResult")]
[JsonSerializable(typeof(TickerBookResponse1), TypeInfoPropertyName = "TickerBookResponse1")]
[JsonSerializable(typeof(TickerBookResponse1Result), TypeInfoPropertyName = "TickerBookResponse1Result")]
[JsonSerializable(typeof(TickerBookResponse2), TypeInfoPropertyName = "TickerBookResponse2")]
[JsonSerializable(typeof(TickerBookResponseResult), TypeInfoPropertyName = "TickerBookResponseResult")]
[JsonSerializable(typeof(TickerPriceResponse1), TypeInfoPropertyName = "TickerPriceResponse1")]
[JsonSerializable(typeof(TickerPriceResponse1Result), TypeInfoPropertyName = "TickerPriceResponse1Result")]
[JsonSerializable(typeof(TickerPriceResponse2), TypeInfoPropertyName = "TickerPriceResponse2")]
[JsonSerializable(typeof(TickerPriceResponseResult), TypeInfoPropertyName = "TickerPriceResponseResult")]
[JsonSerializable(typeof(TickerResponse1), TypeInfoPropertyName = "TickerResponse1")]
[JsonSerializable(typeof(TickerResponse1Result), TypeInfoPropertyName = "TickerResponse1Result")]
[JsonSerializable(typeof(TickerResponse2), TypeInfoPropertyName = "TickerResponse2")]
[JsonSerializable(typeof(TickerResponseResult), TypeInfoPropertyName = "TickerResponseResult")]
[JsonSerializable(typeof(TickerTradingDayResponse1), TypeInfoPropertyName = "TickerTradingDayResponse1")]
[JsonSerializable(typeof(TickerTradingDayResponse1Result), TypeInfoPropertyName = "TickerTradingDayResponse1Result")]
[JsonSerializable(typeof(TickerTradingDayResponse2), TypeInfoPropertyName = "TickerTradingDayResponse2")]
[JsonSerializable(typeof(TickerTradingDayResponseResult), TypeInfoPropertyName = "TickerTradingDayResponseResult")]
[JsonSerializable(typeof(TimeResponseResult), TypeInfoPropertyName = "TimeResponseResult")]
[JsonSerializable(typeof(TrailingDeltaFilter), TypeInfoPropertyName = "TrailingDeltaFilter")]
[JsonSerializable(typeof(UserDataStreamEventsResponse), TypeInfoPropertyName = "UserDataStreamEventsResponse")]
[JsonSerializable(typeof(UserDataStreamSubscribeResponseResult), TypeInfoPropertyName = "UserDataStreamSubscribeResponseResult")]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(string))]
public sealed partial class SpotWebSocketApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Spot WebSocketApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
