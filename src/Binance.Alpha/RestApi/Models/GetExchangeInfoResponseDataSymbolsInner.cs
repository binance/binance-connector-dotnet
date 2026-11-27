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

namespace Binance.Alpha.RestApi;

public sealed class GetExchangeInfoResponseDataSymbolsInner
{
    /// <summary>Trading symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Trading status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Base asset symbol.</summary>
    [JsonPropertyName("baseAsset")]
    public string? BaseAsset { get; set; }

    /// <summary>Quote asset symbol.</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>Allowed precision for price.</summary>
    [JsonPropertyName("pricePrecision")]
    public long? PricePrecision { get; set; }

    /// <summary>Allowed precision for quantity.</summary>
    [JsonPropertyName("quantityPrecision")]
    public long? QuantityPrecision { get; set; }

    /// <summary>Base asset precision.</summary>
    [JsonPropertyName("baseAssetPrecision")]
    public long? BaseAssetPrecision { get; set; }

    /// <summary>Quote asset precision.</summary>
    [JsonPropertyName("quotePrecision")]
    public long? QuotePrecision { get; set; }

    /// <summary>Trading filters and constraints.</summary>
    [JsonPropertyName("filters")]
    public List<GetExchangeInfoResponseDataSymbolsInnerFiltersInner>? Filters { get; set; }

    /// <summary>Supported order types for this symbol.</summary>
    [JsonPropertyName("orderTypes")]
    public List<string>? OrderTypes { get; set; }
}
