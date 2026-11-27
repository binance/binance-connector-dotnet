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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class ExchangeInformationResponseSymbolsInnerFiltersInner
{
    /// <summary>Filter Type.</summary>
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    /// <summary>Max Price.</summary>
    [JsonPropertyName("maxPrice")]
    public string? MaxPrice { get; set; }

    /// <summary>Min Price.</summary>
    [JsonPropertyName("minPrice")]
    public string? MinPrice { get; set; }

    /// <summary>Tick Size.</summary>
    [JsonPropertyName("tickSize")]
    public string? TickSize { get; set; }

    /// <summary>Max Qty.</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Min Qty.</summary>
    [JsonPropertyName("minQty")]
    public string? MinQty { get; set; }

    /// <summary>Step Size.</summary>
    [JsonPropertyName("stepSize")]
    public string? StepSize { get; set; }

    /// <summary>Limit.</summary>
    [JsonPropertyName("limit")]
    public long? Limit { get; set; }

    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    /// <summary>Multiplier Up.</summary>
    [JsonPropertyName("multiplierUp")]
    public string? MultiplierUp { get; set; }

    /// <summary>Multiplier Down.</summary>
    [JsonPropertyName("multiplierDown")]
    public string? MultiplierDown { get; set; }

    [JsonPropertyName("multiplierDecimal")]
    public string? MultiplierDecimal { get; set; }
}
