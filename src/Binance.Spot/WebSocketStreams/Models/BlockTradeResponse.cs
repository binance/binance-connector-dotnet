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

public sealed class BlockTradeResponse
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

    /// <summary>Block Trade ID</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Trade time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Is the buyer the maker?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }
}
