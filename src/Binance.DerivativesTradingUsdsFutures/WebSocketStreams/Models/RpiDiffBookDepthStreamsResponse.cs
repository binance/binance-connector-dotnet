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

public sealed class RpiDiffBookDepthStreamsResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>First update ID in event</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }

    /// <summary>Final update ID in event</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>Final update Id in last stream(ie u in last stream)</summary>
    [JsonPropertyName("pu")]
    public long? Pu { get; set; }

    /// <summary>Bids to be updated</summary>
    [JsonPropertyName("b")]
    public List<List<string>>? B { get; set; }

    /// <summary>Asks to be updated</summary>
    [JsonPropertyName("a")]
    public List<List<string>>? A { get; set; }

    /// <summary>(After CM migration) Pair symbol</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
