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

public sealed class AvgPriceResponse
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

    /// <summary>Average price interval</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Average price</summary>
    [JsonPropertyName("w")]
    public string? W { get; set; }

    /// <summary>Last trade time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }
}
