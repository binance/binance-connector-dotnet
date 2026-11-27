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

public sealed class AggregateTradeStreamsResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Aggregate trade ID</summary>
    [JsonPropertyName("a")]
    public long? A { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>First trade ID</summary>
    [JsonPropertyName("f")]
    public long? F { get; set; }

    /// <summary>Last trade ID</summary>
    [JsonPropertyName("l")]
    public long? L { get; set; }

    /// <summary>Trade time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Is the buyer the market maker?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
