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

namespace Binance.Alpha.WebSocketStreams;

public sealed class AggregateTradeStreamResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time (ms)</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Trade time (ms)</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Aggregated trade ID</summary>
    [JsonPropertyName("a")]
    public long? A { get; set; }

    /// <summary>First trade ID in the aggregation</summary>
    [JsonPropertyName("f")]
    public long? F { get; set; }

    /// <summary>Last trade ID in the aggregation</summary>
    [JsonPropertyName("l")]
    public long? L { get; set; }

    /// <summary>Is the buyer the market maker</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }
}
