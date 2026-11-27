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

public sealed class TradeStreamsResponse
{
    /// <summary>event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>trade completed time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Option trading symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>trade ID</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>quantity, always positive</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>trade type enum, "MARKET" for Orderbook trading, "BLOCK" for Block trade</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>direction</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>Is the buyer the market maker?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }
}
