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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class IndividualSymbolBookTickerStreamsResponse
{
    /// <summary>event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>order book updateId</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>best bid price</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>bid bid quantity</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }

    /// <summary>best ask price</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>best ask quantity</summary>
    [JsonPropertyName("A")]
    public string? AUppercase { get; set; }

    /// <summary>transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }
}
