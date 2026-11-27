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

public sealed class AssetIndexResponseInner
{
    /// <summary>Event type.</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time.</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Asset index symbol.</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Index price.</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Bid buffer.</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Ask buffer.</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Bid rate.</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }

    /// <summary>Ask rate.</summary>
    [JsonPropertyName("A")]
    public string? AUppercase { get; set; }

    /// <summary>Auto exchange bid buffer.</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Auto exchange ask buffer.</summary>
    [JsonPropertyName("g")]
    public string? G { get; set; }

    /// <summary>Auto exchange bid rate.</summary>
    [JsonPropertyName("Q")]
    public string? QUppercase { get; set; }

    /// <summary>Auto exchange ask rate.</summary>
    [JsonPropertyName("G")]
    public string? GUppercase { get; set; }
}
