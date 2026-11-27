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

public sealed class ReferencePriceResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Reference price (null if no reference price)</summary>
    [JsonPropertyName("r")]
    public string? R { get; set; }

    /// <summary>Engine timestamp when reference price was valid</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }
}
