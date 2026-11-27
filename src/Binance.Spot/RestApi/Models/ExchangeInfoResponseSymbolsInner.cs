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

public sealed class ExchangeInfoResponseSymbolsInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    [JsonPropertyName("baseAssetPrecision")]
    public long? BaseAssetPrecision { get; set; }

    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>will be removed in future api versions (v4+)</summary>
    [JsonPropertyName("quotePrecision")]
    public long? QuotePrecision { get; set; }

    [JsonPropertyName("quoteAssetPrecision")]
    public long? QuoteAssetPrecision { get; set; }

    [JsonPropertyName("baseCommissionPrecision")]
    public long? BaseCommissionPrecision { get; set; }

    [JsonPropertyName("quoteCommissionPrecision")]
    public long? QuoteCommissionPrecision { get; set; }

    [JsonPropertyName("orderTypes")]
    public List<string>? OrderTypes { get; set; }

    [JsonPropertyName("icebergAllowed")]
    public bool? IcebergAllowed { get; set; }

    [JsonPropertyName("ocoAllowed")]
    public bool? OcoAllowed { get; set; }

    [JsonPropertyName("otoAllowed")]
    public bool? OtoAllowed { get; set; }

    [JsonPropertyName("opoAllowed")]
    public bool? OpoAllowed { get; set; }

    [JsonPropertyName("quoteOrderQtyMarketAllowed")]
    public bool? QuoteOrderQtyMarketAllowed { get; set; }

    [JsonPropertyName("allowTrailingStop")]
    public bool? AllowTrailingStop { get; set; }

    [JsonPropertyName("cancelReplaceAllowed")]
    public bool? CancelReplaceAllowed { get; set; }

    [JsonPropertyName("amendAllowed")]
    public bool? AmendAllowed { get; set; }

    [JsonPropertyName("pegInstructionsAllowed")]
    public bool? PegInstructionsAllowed { get; set; }

    [JsonPropertyName("marketQuoteNotionalLimitAllowed")]
    public bool? MarketQuoteNotionalLimitAllowed { get; set; }

    [JsonPropertyName("limitQuoteNotionalLimitAllowed")]
    public bool? LimitQuoteNotionalLimitAllowed { get; set; }

    [JsonPropertyName("isSpotTradingAllowed")]
    public bool? IsSpotTradingAllowed { get; set; }

    [JsonPropertyName("isMarginTradingAllowed")]
    public bool? IsMarginTradingAllowed { get; set; }

    /// <summary>
    /// Symbol filters are explained on the "Filters" page: All symbol filters are optional.
    /// </summary>
    [JsonPropertyName("filters")]
    public List<MyFiltersResponseSymbolFiltersInner>? Filters { get; set; }

    [JsonPropertyName("permissions")]
    public List<string>? Permissions { get; set; }

    [JsonPropertyName("permissionSets")]
    public List<List<string>>? PermissionSets { get; set; }

    [JsonPropertyName("defaultSelfTradePreventionMode")]
    public string? DefaultSelfTradePreventionMode { get; set; }

    [JsonPropertyName("allowedSelfTradePreventionModes")]
    public List<string>? AllowedSelfTradePreventionModes { get; set; }
}
