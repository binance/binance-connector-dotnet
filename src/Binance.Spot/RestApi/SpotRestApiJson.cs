//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Binance.Spot.RestApi;

/// <summary>The System.Text.Json context of the Spot RestApi models: <c>JsonSerializer.Serialize(value, SpotRestApiJson.Default.TypeName)</c>, also under Native AOT.</summary>
[JsonSourceGenerationOptions(NumberHandling = JsonNumberHandling.AllowReadingFromString, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(AccountCommissionResponse), TypeInfoPropertyName = "AccountCommissionResponse")]
[JsonSerializable(typeof(AvgPriceResponse), TypeInfoPropertyName = "AvgPriceResponse")]
[JsonSerializable(typeof(DeleteOrderListResponse), TypeInfoPropertyName = "DeleteOrderListResponse")]
[JsonSerializable(typeof(DeleteOrderResponse), TypeInfoPropertyName = "DeleteOrderResponse")]
[JsonSerializable(typeof(DepthResponse), TypeInfoPropertyName = "DepthResponse")]
[JsonSerializable(typeof(ExchangeInfoResponse), TypeInfoPropertyName = "ExchangeInfoResponse")]
[JsonSerializable(typeof(ExchangeMaxNumAlgoOrdersFilter), TypeInfoPropertyName = "ExchangeMaxNumAlgoOrdersFilter")]
[JsonSerializable(typeof(ExchangeMaxNumIcebergOrdersFilter), TypeInfoPropertyName = "ExchangeMaxNumIcebergOrdersFilter")]
[JsonSerializable(typeof(ExchangeMaxNumOrderListsFilter), TypeInfoPropertyName = "ExchangeMaxNumOrderListsFilter")]
[JsonSerializable(typeof(ExchangeMaxNumOrdersFilter), TypeInfoPropertyName = "ExchangeMaxNumOrdersFilter")]
[JsonSerializable(typeof(ExecutionRulesResponse), TypeInfoPropertyName = "ExecutionRulesResponse")]
[JsonSerializable(typeof(GetAccountResponse), TypeInfoPropertyName = "GetAccountResponse")]
[JsonSerializable(typeof(GetOrderListResponse), TypeInfoPropertyName = "GetOrderListResponse")]
[JsonSerializable(typeof(GetOrderResponse), TypeInfoPropertyName = "GetOrderResponse")]
[JsonSerializable(typeof(IcebergPartsFilter), TypeInfoPropertyName = "IcebergPartsFilter")]
[JsonSerializable(typeof(JsonElement), TypeInfoPropertyName = "JsonElement")]
[JsonSerializable(typeof(List<AggTradesResponseInner>), TypeInfoPropertyName = "ListAggTradesResponseInner")]
[JsonSerializable(typeof(List<AllOrderListResponseInner>), TypeInfoPropertyName = "ListAllOrderListResponseInner")]
[JsonSerializable(typeof(List<AllOrdersResponseInner>), TypeInfoPropertyName = "ListAllOrdersResponseInner")]
[JsonSerializable(typeof(List<DeleteOpenOrdersResponseInner>), TypeInfoPropertyName = "ListDeleteOpenOrdersResponseInner")]
[JsonSerializable(typeof(List<GetOpenOrdersResponseInner>), TypeInfoPropertyName = "ListGetOpenOrdersResponseInner")]
[JsonSerializable(typeof(List<GetTradesResponseInner>), TypeInfoPropertyName = "ListGetTradesResponseInner")]
[JsonSerializable(typeof(List<HistoricalBlockTradesResponseInner>), TypeInfoPropertyName = "ListHistoricalBlockTradesResponseInner")]
[JsonSerializable(typeof(List<List<KlinesItemInner>>), TypeInfoPropertyName = "ListListKlinesItemInner")]
[JsonSerializable(typeof(List<MyAllocationsResponseInner>), TypeInfoPropertyName = "ListMyAllocationsResponseInner")]
[JsonSerializable(typeof(List<MyPreventedMatchesResponseInner>), TypeInfoPropertyName = "ListMyPreventedMatchesResponseInner")]
[JsonSerializable(typeof(List<MyTradesResponseInner>), TypeInfoPropertyName = "ListMyTradesResponseInner")]
[JsonSerializable(typeof(List<OpenOrderListResponseInner>), TypeInfoPropertyName = "ListOpenOrderListResponseInner")]
[JsonSerializable(typeof(List<OrderAmendmentsResponseInner>), TypeInfoPropertyName = "ListOrderAmendmentsResponseInner")]
[JsonSerializable(typeof(List<RateLimitOrderResponseInner>), TypeInfoPropertyName = "ListRateLimitOrderResponseInner")]
[JsonSerializable(typeof(List<Ticker24hrResponse2Inner>), TypeInfoPropertyName = "ListTicker24hrResponse2Inner")]
[JsonSerializable(typeof(List<TickerBookTickerResponse2Inner>), TypeInfoPropertyName = "ListTickerBookTickerResponse2Inner")]
[JsonSerializable(typeof(List<TickerPriceResponse2Inner>), TypeInfoPropertyName = "ListTickerPriceResponse2Inner")]
[JsonSerializable(typeof(List<TickerResponse2Inner>), TypeInfoPropertyName = "ListTickerResponse2Inner")]
[JsonSerializable(typeof(List<TickerTradingDayResponse2Inner>), TypeInfoPropertyName = "ListTickerTradingDayResponse2Inner")]
[JsonSerializable(typeof(LotSizeFilter), TypeInfoPropertyName = "LotSizeFilter")]
[JsonSerializable(typeof(MarketLotSizeFilter), TypeInfoPropertyName = "MarketLotSizeFilter")]
[JsonSerializable(typeof(MaxAssetFilter), TypeInfoPropertyName = "MaxAssetFilter")]
[JsonSerializable(typeof(MaxNumAlgoOrdersFilter), TypeInfoPropertyName = "MaxNumAlgoOrdersFilter")]
[JsonSerializable(typeof(MaxNumIcebergOrdersFilter), TypeInfoPropertyName = "MaxNumIcebergOrdersFilter")]
[JsonSerializable(typeof(MaxNumOrderAmendsFilter), TypeInfoPropertyName = "MaxNumOrderAmendsFilter")]
[JsonSerializable(typeof(MaxNumOrderListsFilter), TypeInfoPropertyName = "MaxNumOrderListsFilter")]
[JsonSerializable(typeof(MaxNumOrdersFilter), TypeInfoPropertyName = "MaxNumOrdersFilter")]
[JsonSerializable(typeof(MaxPositionFilter), TypeInfoPropertyName = "MaxPositionFilter")]
[JsonSerializable(typeof(MinNotionalFilter), TypeInfoPropertyName = "MinNotionalFilter")]
[JsonSerializable(typeof(MyFiltersResponse), TypeInfoPropertyName = "MyFiltersResponse")]
[JsonSerializable(typeof(NewOrderResponse), TypeInfoPropertyName = "NewOrderResponse")]
[JsonSerializable(typeof(NotionalFilter), TypeInfoPropertyName = "NotionalFilter")]
[JsonSerializable(typeof(OrderAmendKeepPriorityResponse), TypeInfoPropertyName = "OrderAmendKeepPriorityResponse")]
[JsonSerializable(typeof(OrderCancelReplaceResponse), TypeInfoPropertyName = "OrderCancelReplaceResponse")]
[JsonSerializable(typeof(OrderListOcoResponse), TypeInfoPropertyName = "OrderListOcoResponse")]
[JsonSerializable(typeof(OrderListOpoResponse), TypeInfoPropertyName = "OrderListOpoResponse")]
[JsonSerializable(typeof(OrderListOpocoResponse), TypeInfoPropertyName = "OrderListOpocoResponse")]
[JsonSerializable(typeof(OrderListOtoResponse), TypeInfoPropertyName = "OrderListOtoResponse")]
[JsonSerializable(typeof(OrderListOtocoResponse), TypeInfoPropertyName = "OrderListOtocoResponse")]
[JsonSerializable(typeof(OrderOcoResponse), TypeInfoPropertyName = "OrderOcoResponse")]
[JsonSerializable(typeof(OrderTestResponse), TypeInfoPropertyName = "OrderTestResponse")]
[JsonSerializable(typeof(PercentPriceBySideFilter), TypeInfoPropertyName = "PercentPriceBySideFilter")]
[JsonSerializable(typeof(PercentPriceFilter), TypeInfoPropertyName = "PercentPriceFilter")]
[JsonSerializable(typeof(PriceFilter), TypeInfoPropertyName = "PriceFilter")]
[JsonSerializable(typeof(ReferencePriceCalculationResponse), TypeInfoPropertyName = "ReferencePriceCalculationResponse")]
[JsonSerializable(typeof(ReferencePriceResponse), TypeInfoPropertyName = "ReferencePriceResponse")]
[JsonSerializable(typeof(SorOrderResponse), TypeInfoPropertyName = "SorOrderResponse")]
[JsonSerializable(typeof(SorOrderTestResponse), TypeInfoPropertyName = "SorOrderTestResponse")]
[JsonSerializable(typeof(TPlusSellFilter), TypeInfoPropertyName = "TPlusSellFilter")]
[JsonSerializable(typeof(Ticker24hrResponse), TypeInfoPropertyName = "Ticker24hrResponse")]
[JsonSerializable(typeof(Ticker24hrResponse1), TypeInfoPropertyName = "Ticker24hrResponse1")]
[JsonSerializable(typeof(TickerBookTickerResponse), TypeInfoPropertyName = "TickerBookTickerResponse")]
[JsonSerializable(typeof(TickerBookTickerResponse1), TypeInfoPropertyName = "TickerBookTickerResponse1")]
[JsonSerializable(typeof(TickerPriceResponse), TypeInfoPropertyName = "TickerPriceResponse")]
[JsonSerializable(typeof(TickerPriceResponse1), TypeInfoPropertyName = "TickerPriceResponse1")]
[JsonSerializable(typeof(TickerResponse), TypeInfoPropertyName = "TickerResponse")]
[JsonSerializable(typeof(TickerResponse1), TypeInfoPropertyName = "TickerResponse1")]
[JsonSerializable(typeof(TickerTradingDayResponse), TypeInfoPropertyName = "TickerTradingDayResponse")]
[JsonSerializable(typeof(TickerTradingDayResponse1), TypeInfoPropertyName = "TickerTradingDayResponse1")]
[JsonSerializable(typeof(TimeResponse), TypeInfoPropertyName = "TimeResponse")]
[JsonSerializable(typeof(TrailingDeltaFilter), TypeInfoPropertyName = "TrailingDeltaFilter")]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(string))]
public sealed partial class SpotRestApiJson : JsonSerializerContext
{
    private static JsonSerializerOptions? s_indented;

    /// <summary>Writes a model of the Spot RestApi (or a list of them) as indented JSON. It works under Native AOT.</summary>
    /// <typeparam name="T">The model, or a list of models.</typeparam>
    /// <param name="value">The value to write.</param>
    public static string ToJson<T>(T value)
    {
        var options = s_indented ??= new JsonSerializerOptions(Default.Options) { WriteIndented = true };
        return JsonSerializer.Serialize(value, (System.Text.Json.Serialization.Metadata.JsonTypeInfo<T>)options.GetTypeInfo(typeof(T)));
    }
}
