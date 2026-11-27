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

public sealed class OrderTradeUpdateO
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Client Order Id</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

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

    /// <summary>Original Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Average Price</summary>
    [JsonPropertyName("ap")]
    public string? Ap { get; set; }

    /// <summary>Execution Type</summary>
    [JsonPropertyName("x")]
    public string? X { get; set; }

    /// <summary>Order Status</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>Order Id</summary>
    [JsonPropertyName("i")]
    public long? I { get; set; }

    /// <summary>Order Last Filled Quantity</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Order Filled Accumulated Quantity</summary>
    [JsonPropertyName("z")]
    public string? Z { get; set; }

    /// <summary>Last Filled Price</summary>
    [JsonPropertyName("L")]
    public string? LUppercase { get; set; }

    /// <summary>Commission Asset</summary>
    [JsonPropertyName("N")]
    public string? NUppercase { get; set; }

    /// <summary>Commission, negative means fee charge</summary>
    [JsonPropertyName("n")]
    public string? N { get; set; }

    /// <summary>Order Trade Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Trade Id</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Bids qty</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Ask qty</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Is this trade the maker side?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }

    /// <summary>Is this reduce only</summary>
    [JsonPropertyName("R")]
    public bool? RUppercase { get; set; }

    /// <summary>Original Order Type</summary>
    [JsonPropertyName("ot")]
    public string? Ot { get; set; }

    /// <summary>Realized Profit of the trade</summary>
    [JsonPropertyName("rp")]
    public string? Rp { get; set; }

    /// <summary>STP mode</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }
}
