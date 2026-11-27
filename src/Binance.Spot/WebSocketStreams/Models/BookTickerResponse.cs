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

public sealed class BookTickerResponse
{
    /// <summary>Order book updateId</summary>
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
}
