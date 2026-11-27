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

namespace Binance.Spot.WebSocketStreams;

public sealed class DiffBookDepthResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>First update ID in event</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }

    /// <summary>Final update ID in event</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>Bids to be updated</summary>
    [JsonPropertyName("b")]
    public List<List<string>>? B { get; set; }

    /// <summary>Asks to be updated</summary>
    [JsonPropertyName("a")]
    public List<List<string>>? A { get; set; }
}
