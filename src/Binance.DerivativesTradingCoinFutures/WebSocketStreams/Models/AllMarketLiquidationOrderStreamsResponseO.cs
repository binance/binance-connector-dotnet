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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

/// <summary>Order Type</summary>
public sealed class AllMarketLiquidationOrderStreamsResponseO
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>Side</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>Order Type</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Time in Force</summary>
    [JsonPropertyName("f")]
    public string? F { get; set; }

    /// <summary>Original Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Average Price</summary>
    [JsonPropertyName("ap")]
    public string? Ap { get; set; }

    /// <summary>Order Status</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>Order Last Filled Quantity</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Order Filled Accumulated Quantity</summary>
    [JsonPropertyName("z")]
    public string? Z { get; set; }

    /// <summary>Order Trade Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }
}
