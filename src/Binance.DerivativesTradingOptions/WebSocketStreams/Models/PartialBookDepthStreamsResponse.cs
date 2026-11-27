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

public sealed class PartialBookDepthStreamsResponse
{
    /// <summary>event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Option symbol</summary>
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

    /// <summary>Buy order</summary>
    [JsonPropertyName("b")]
    public List<List<string>>? B { get; set; }

    /// <summary>Sell order</summary>
    [JsonPropertyName("a")]
    public List<List<string>>? A { get; set; }
}
