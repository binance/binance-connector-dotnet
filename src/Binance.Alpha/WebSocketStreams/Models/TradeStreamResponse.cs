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

public sealed class TradeStreamResponse
{
    /// <summary>eventType</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>eventTime</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>tradeTime</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>tradeId</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>fillPrice</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>fillQty</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>isBuyerMaker</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }
}
