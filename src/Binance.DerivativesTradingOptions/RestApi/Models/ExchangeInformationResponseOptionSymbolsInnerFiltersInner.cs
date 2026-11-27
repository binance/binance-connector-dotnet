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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class ExchangeInformationResponseOptionSymbolsInnerFiltersInner
{
    /// <summary>filter Type</summary>
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    /// <summary>min Price</summary>
    [JsonPropertyName("minPrice")]
    public string? MinPrice { get; set; }

    /// <summary>max Price</summary>
    [JsonPropertyName("maxPrice")]
    public string? MaxPrice { get; set; }

    /// <summary>tick Size</summary>
    [JsonPropertyName("tickSize")]
    public string? TickSize { get; set; }

    /// <summary>Minimum order quantity</summary>
    [JsonPropertyName("minQty")]
    public string? MinQty { get; set; }

    /// <summary>Maximum order quantity</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>step Size</summary>
    [JsonPropertyName("stepSize")]
    public string? StepSize { get; set; }
}
