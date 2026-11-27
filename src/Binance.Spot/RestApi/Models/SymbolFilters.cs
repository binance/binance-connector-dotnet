//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common;

namespace Binance.Spot.RestApi;

[JsonConverter(typeof(OneOfConverter<SymbolFilters>))]
public sealed class SymbolFilters : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => SpotRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(PriceFilter), typeof(PercentPriceFilter), typeof(PercentPriceBySideFilter), typeof(LotSizeFilter), typeof(MinNotionalFilter), typeof(NotionalFilter), typeof(IcebergPartsFilter), typeof(MarketLotSizeFilter), typeof(MaxNumOrdersFilter), typeof(MaxNumAlgoOrdersFilter), typeof(MaxNumIcebergOrdersFilter), typeof(MaxPositionFilter), typeof(TrailingDeltaFilter), typeof(TPlusSellFilter), typeof(MaxNumOrderListsFilter), typeof(MaxNumOrderAmendsFilter)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;

    /// <summary>The alternative the tag filterType selects, or null when the tag is missing or unknown.</summary>
    public object? Value => Json.ValueKind == JsonValueKind.Object && Json.TryGetProperty("filterType", out var tag)
        ? tag.GetString() switch
        {
            "ICEBERG_PARTS" => As<IcebergPartsFilter>(),
            "LOT_SIZE" => As<LotSizeFilter>(),
            "MARKET_LOT_SIZE" => As<MarketLotSizeFilter>(),
            "MAX_NUM_ALGO_ORDERS" => As<MaxNumAlgoOrdersFilter>(),
            "MAX_NUM_ICEBERG_ORDERS" => As<MaxNumIcebergOrdersFilter>(),
            "MAX_NUM_ORDERS" => As<MaxNumOrdersFilter>(),
            "MAX_NUM_ORDER_AMENDS" => As<MaxNumOrderAmendsFilter>(),
            "MAX_NUM_ORDER_LISTS" => As<MaxNumOrderListsFilter>(),
            "MAX_POSITION" => As<MaxPositionFilter>(),
            "MIN_NOTIONAL" => As<MinNotionalFilter>(),
            "NOTIONAL" => As<NotionalFilter>(),
            "PERCENT_PRICE" => As<PercentPriceFilter>(),
            "PERCENT_PRICE_BY_SIDE" => As<PercentPriceBySideFilter>(),
            "PRICE_FILTER" => As<PriceFilter>(),
            "TRAILING_DELTA" => As<TrailingDeltaFilter>(),
            "T_PLUS_SELL" => As<TPlusSellFilter>(),
            _ => null,
        }
        : null;
}
