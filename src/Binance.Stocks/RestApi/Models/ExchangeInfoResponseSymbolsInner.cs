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

namespace Binance.Stocks.RestApi;

public sealed class ExchangeInfoResponseSymbolsInner
{
    /// <summary>US-equity ticker, e.g. AAPL.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Trading direction allowed — one of BUY_SELL / BUY / SELL / NONE.</summary>
    [JsonPropertyName("tradability")]
    public string? Tradability { get; set; }

    /// <summary>Last time the tradability value was updated (ms epoch).</summary>
    [JsonPropertyName("tradabilityUpdateTime")]
    public long? TradabilityUpdateTime { get; set; }

    /// <summary>Whether the symbol supports overnight trading.</summary>
    [JsonPropertyName("overnightSupported")]
    public bool? OvernightSupported { get; set; }

    /// <summary>Whether fractional shares are supported during the regular session.</summary>
    [JsonPropertyName("fractionable")]
    public bool? Fractionable { get; set; }

    /// <summary>Whether fractional shares are supported during extended hours.</summary>
    [JsonPropertyName("fractionableEh")]
    public bool? FractionableEh { get; set; }

    /// <summary>Whether extended-session trading is enabled.</summary>
    [JsonPropertyName("extendedSession")]
    public bool? ExtendedSession { get; set; }

    /// <summary>Maximum number of open orders a user may have for this symbol.</summary>
    [JsonPropertyName("maxNumOrders")]
    public long? MaxNumOrders { get; set; }

    /// <summary>Lot size — minimum increment for quantity.</summary>
    [JsonPropertyName("stepSize")]
    public string? StepSize { get; set; }

    /// <summary>Upper price multiplier limit relative to reference.</summary>
    [JsonPropertyName("multiplierUp")]
    public string? MultiplierUp { get; set; }

    /// <summary>Lower price multiplier limit relative to reference.</summary>
    [JsonPropertyName("multiplierDown")]
    public string? MultiplierDown { get; set; }

    /// <summary>Minimum allowed quantity.</summary>
    [JsonPropertyName("minQty")]
    public string? MinQty { get; set; }

    /// <summary>Maximum allowed quantity.</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Minimum order notional (USD).</summary>
    [JsonPropertyName("minNotional")]
    public string? MinNotional { get; set; }

    /// <summary>Maximum order notional (USD).</summary>
    [JsonPropertyName("maxNotional")]
    public string? MaxNotional { get; set; }

    /// <summary>Listing timestamp (ms epoch).</summary>
    [JsonPropertyName("listingTime")]
    public long? ListingTime { get; set; }

    /// <summary>Scheduled delisting timestamp (ms epoch); null if not scheduled for delisting.</summary>
    [JsonPropertyName("delistingTime")]
    public long? DelistingTime { get; set; }
}
