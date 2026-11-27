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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

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

    /// <summary>Stop Price. Please ignore with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("sp")]
    public string? Sp { get; set; }

    /// <summary>Execution Type</summary>
    [JsonPropertyName("x")]
    public string? X { get; set; }

    /// <summary>Order Status</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>Order Id</summary>
    [JsonPropertyName("i")]
    public long? I { get; set; }

    /// <summary>
    /// modifyId, only pushed for AMENDMENT (order modification) events when a modifyId was provided in the
    /// request
    /// </summary>
    [JsonPropertyName("M")]
    public string? MUppercase { get; set; }

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

    /// <summary>Commission</summary>
    [JsonPropertyName("n")]
    public string? N { get; set; }

    /// <summary>Order Trade Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Trade Id</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Bids Notional</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Ask Notional</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Is this trade the maker side?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }

    /// <summary>Is this reduce only</summary>
    [JsonPropertyName("R")]
    public bool? RUppercase { get; set; }

    /// <summary>Stop Price Working Type</summary>
    [JsonPropertyName("wt")]
    public string? Wt { get; set; }

    /// <summary>Original Order Type</summary>
    [JsonPropertyName("ot")]
    public string? Ot { get; set; }

    /// <summary>Position Side</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>If Close-All, pushed with conditional order</summary>
    [JsonPropertyName("cp")]
    public bool? Cp { get; set; }

    /// <summary>Activation Price, only pushed with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("AP")]
    public string? APUppercase { get; set; }

    /// <summary>Callback Rate, only pushed with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("cr")]
    public string? Cr { get; set; }

    /// <summary>If price protection is turned on</summary>
    [JsonPropertyName("pP")]
    public bool? PPUppercase { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("si")]
    public long? Si { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("ss")]
    public long? Ss { get; set; }

    /// <summary>Realized Profit of the trade</summary>
    [JsonPropertyName("rp")]
    public string? Rp { get; set; }

    /// <summary>STP mode</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>Price match mode</summary>
    [JsonPropertyName("pm")]
    public string? Pm { get; set; }

    /// <summary>TIF GTD order auto cancel time</summary>
    [JsonPropertyName("gtd")]
    public long? Gtd { get; set; }

    /// <summary>Expiry Reason</summary>
    [JsonPropertyName("er")]
    public string? Er { get; set; }
}
