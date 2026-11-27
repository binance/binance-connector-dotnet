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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

public sealed class TradeLite
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Transaction Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Original Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Original Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Is this trade the maker side?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }

    /// <summary>Client Order Id</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>Side</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>Last Filled Price</summary>
    [JsonPropertyName("L")]
    public string? LUppercase { get; set; }

    /// <summary>Order Last Filled Quantity</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Trade Id</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Order Id</summary>
    [JsonPropertyName("i")]
    public long? I { get; set; }
}
