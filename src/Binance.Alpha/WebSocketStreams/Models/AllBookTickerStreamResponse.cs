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

public sealed class AllBookTickerStreamResponse
{
    /// <summary>eventType</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>eventTime</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>transactionTime</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>updateId</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>bid1Price</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>bid1Quantity</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }

    /// <summary>ask1Price</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>ask1Quantity</summary>
    [JsonPropertyName("A")]
    public string? AUppercase { get; set; }
}
