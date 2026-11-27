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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class ExchangeInformationResponseSymbolsInnerFiltersInner
{
    /// <summary>Filter type.</summary>
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    /// <summary>Maximum price.</summary>
    [JsonPropertyName("maxPrice")]
    public string? MaxPrice { get; set; }

    /// <summary>Minimum price.</summary>
    [JsonPropertyName("minPrice")]
    public string? MinPrice { get; set; }

    /// <summary>Tick size.</summary>
    [JsonPropertyName("tickSize")]
    public string? TickSize { get; set; }

    /// <summary>maximum quantity of base asset</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Minimum quantity.</summary>
    [JsonPropertyName("minQty")]
    public string? MinQty { get; set; }

    /// <summary>Step size.</summary>
    [JsonPropertyName("stepSize")]
    public string? StepSize { get; set; }

    /// <summary>Maximum allowed orders for this rule.</summary>
    [JsonPropertyName("limit")]
    public long? Limit { get; set; }

    /// <summary>Upper multiplier bound.</summary>
    [JsonPropertyName("multiplierUp")]
    public string? MultiplierUp { get; set; }

    /// <summary>Lower multiplier bound.</summary>
    [JsonPropertyName("multiplierDown")]
    public string? MultiplierDown { get; set; }

    /// <summary>Multiplier decimal precision.</summary>
    [JsonPropertyName("multiplierDecimal")]
    public string? MultiplierDecimal { get; set; }
}
