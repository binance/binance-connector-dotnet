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

public sealed class IndividualSymbolBookTickerStreamsResponse
{
    /// <summary>event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>order book updateId</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>pair (After CM migration)</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>best bid price</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>best bid qty</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }

    /// <summary>best ask price</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>best ask qty</summary>
    [JsonPropertyName("A")]
    public string? AUppercase { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
