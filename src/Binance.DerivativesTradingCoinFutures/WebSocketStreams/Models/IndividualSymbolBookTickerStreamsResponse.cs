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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

public sealed class IndividualSymbolBookTickerStreamsResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Order book update Id</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Best bid price</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Best bid qty</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }

    /// <summary>Best ask price</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Best ask qty</summary>
    [JsonPropertyName("A")]
    public string? AUppercase { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
