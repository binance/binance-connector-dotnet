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

public sealed class FullDepthStreamResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time (ms)</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Matching time (ms)</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>First updateId in this event</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }

    /// <summary>Last updateId in this event</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>Previous updateId from the last push</summary>
    [JsonPropertyName("pu")]
    public long? Pu { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>bids to be updated</summary>
    [JsonPropertyName("b")]
    public List<List<string>>? B { get; set; }

    /// <summary>asks to be updated</summary>
    [JsonPropertyName("a")]
    public List<List<string>>? A { get; set; }
}
