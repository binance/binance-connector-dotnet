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

namespace Binance.Spot.WebSocketApi;

public sealed class ExecutionReport
{
    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Client order ID</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>Side</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>Order type</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Time in force</summary>
    [JsonPropertyName("f")]
    public string? F { get; set; }

    /// <summary>Order quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Order price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Stop price</summary>
    [JsonPropertyName("P")]
    public string? PUppercase { get; set; }

    /// <summary>Iceberg quantity</summary>
    [JsonPropertyName("F")]
    public string? FUppercase { get; set; }

    /// <summary>OrderListId</summary>
    [JsonPropertyName("g")]
    public long? G { get; set; }

    /// <summary>Original client order ID; This is the ID of the order being canceled</summary>
    [JsonPropertyName("C")]
    public string? CUppercase { get; set; }

    /// <summary>Current execution type</summary>
    [JsonPropertyName("x")]
    public string? X { get; set; }

    /// <summary>Current order status</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>Order reject reason; Please see Order Reject Reason for more information.</summary>
    [JsonPropertyName("r")]
    public string? R { get; set; }

    /// <summary>Order ID</summary>
    [JsonPropertyName("i")]
    public long? I { get; set; }

    /// <summary>Last executed quantity</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Cumulative filled quantity</summary>
    [JsonPropertyName("z")]
    public string? Z { get; set; }

    /// <summary>Last executed price</summary>
    [JsonPropertyName("L")]
    public string? LUppercase { get; set; }

    /// <summary>Commission amount</summary>
    [JsonPropertyName("n")]
    public string? N { get; set; }

    /// <summary>Commission asset</summary>
    [JsonPropertyName("N")]
    public string? NUppercase { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Trade ID</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Prevented Match Id; This is only visible if the order expired due to STP</summary>
    [JsonPropertyName("v")]
    public long? V { get; set; }

    /// <summary>Execution Id</summary>
    [JsonPropertyName("I")]
    public long? IUppercase { get; set; }

    /// <summary>Is the order on the book?</summary>
    [JsonPropertyName("w")]
    public bool? W { get; set; }

    /// <summary>Is this trade the maker side?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }

    /// <summary>Ignore</summary>
    [JsonPropertyName("M")]
    public bool? MUppercase { get; set; }

    /// <summary>Order creation time</summary>
    [JsonPropertyName("O")]
    public long? OUppercase { get; set; }

    /// <summary>Cumulative quote asset transacted quantity</summary>
    [JsonPropertyName("Z")]
    public string? ZUppercase { get; set; }

    /// <summary>Last quote asset transacted quantity (i.e. lastPrice * lastQty)</summary>
    [JsonPropertyName("Y")]
    public string? YUppercase { get; set; }

    /// <summary>Quote Order Quantity</summary>
    [JsonPropertyName("Q")]
    public string? QUppercase { get; set; }

    /// <summary>Working Time; This is only visible if the order has been placed on the book.</summary>
    [JsonPropertyName("W")]
    public long? WUppercase { get; set; }

    /// <summary>SelfTradePreventionMode</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>Trailing Delta</summary>
    [JsonPropertyName("d")]
    public long? D { get; set; }

    /// <summary>Trailing Time</summary>
    [JsonPropertyName("D")]
    public long? DUppercase { get; set; }

    /// <summary>Strategy Id</summary>
    [JsonPropertyName("j")]
    public long? J { get; set; }

    /// <summary>Strategy Type</summary>
    [JsonPropertyName("J")]
    public long? JUppercase { get; set; }

    /// <summary>Prevented Quantity</summary>
    [JsonPropertyName("A")]
    public string? AUppercase { get; set; }

    /// <summary>Last Prevented Quantity</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }

    /// <summary>Trade Group Id</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>Counter Order Id</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }

    /// <summary>Counter Symbol</summary>
    [JsonPropertyName("Cs")]
    public string? Cs { get; set; }

    /// <summary>Prevented Execution Quantity</summary>
    [JsonPropertyName("pl")]
    public string? Pl { get; set; }

    /// <summary>Prevented Execution Price</summary>
    [JsonPropertyName("pL")]
    public string? PLUppercase { get; set; }

    /// <summary>Prevented Execution Quote Qty</summary>
    [JsonPropertyName("pY")]
    public string? PYUppercase { get; set; }

    /// <summary>
    /// Quote Notional Limit. Appears only if the order was placed with a quote notional limit.
    /// </summary>
    [JsonPropertyName("Qq")]
    public string? Qq { get; set; }

    /// <summary>
    /// Effective Self Trade Prevention Mode. Appears on prevented-match reports when the applied STP mode
    /// differs from the order's selfTradePreventionMode. Values: EXPIRE_MAKER, EXPIRE_BOTH, DECREMENT.
    /// </summary>
    [JsonPropertyName("eV")]
    public string? EVUppercase { get; set; }

    /// <summary>Match Type</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Allocation ID</summary>
    [JsonPropertyName("a")]
    public long? A { get; set; }

    /// <summary>Working Floor</summary>
    [JsonPropertyName("k")]
    public string? K { get; set; }

    /// <summary>UsedSor</summary>
    [JsonPropertyName("uS")]
    public bool? USUppercase { get; set; }

    /// <summary>Pegged Price Type</summary>
    [JsonPropertyName("gP")]
    public string? GPUppercase { get; set; }

    /// <summary>Pegged Offset Type</summary>
    [JsonPropertyName("gOT")]
    public string? GOTUppercase { get; set; }

    /// <summary>Pegged Offset Value</summary>
    [JsonPropertyName("gOV")]
    public long? GOVUppercase { get; set; }

    /// <summary>Pegged Price</summary>
    [JsonPropertyName("gp")]
    public string? Gp { get; set; }

    /// <summary>Expiry Reason. Appears when the order has expired.</summary>
    [JsonPropertyName("eR")]
    public string? ERUppercase { get; set; }
}
