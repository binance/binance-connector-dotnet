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

namespace Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

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

    /// <summary>Trailing Delta; This is only visible if the order was a trailing stop order.</summary>
    [JsonPropertyName("d")]
    public long? D { get; set; }

    /// <summary>Iceberg quantity; Will not be visible if not iceberg order</summary>
    [JsonPropertyName("F")]
    public string? FUppercase { get; set; }

    /// <summary>OrderListId</summary>
    [JsonPropertyName("g")]
    public long? G { get; set; }

    /// <summary>
    /// Original client order ID; Only visible on cancellation of order, the ID of the order being canceled.
    /// </summary>
    [JsonPropertyName("C")]
    public string? CUppercase { get; set; }

    /// <summary>Current execution type</summary>
    [JsonPropertyName("x")]
    public string? X { get; set; }

    /// <summary>Current order status</summary>
    [JsonPropertyName("X")]
    public string? XUppercase { get; set; }

    /// <summary>Order reject reason; Only visible if there is a rejection, will be an error code.</summary>
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

    /// <summary>Commission asset; Only visible when there is a commission amount.</summary>
    [JsonPropertyName("N")]
    public string? NUppercase { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Trade ID</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Prevented Match Id; This is only visible if the order expire due to STP trigger.</summary>
    [JsonPropertyName("v")]
    public long? V { get; set; }

    /// <summary>updateId</summary>
    [JsonPropertyName("I")]
    public long? IUppercase { get; set; }

    /// <summary>Is the order on the book?</summary>
    [JsonPropertyName("w")]
    public bool? W { get; set; }

    /// <summary>Is this trade the maker side?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }

    /// <summary>Order creation time</summary>
    [JsonPropertyName("O")]
    public long? OUppercase { get; set; }

    /// <summary>Cumulative quote asset transacted quantity</summary>
    [JsonPropertyName("Z")]
    public string? ZUppercase { get; set; }

    /// <summary>Last quote asset transacted quantity (i.e. lastPrice * lastQty)</summary>
    [JsonPropertyName("Y")]
    public string? YUppercase { get; set; }

    /// <summary>Quote Order Quantity; This is only visible if indicated in the order</summary>
    [JsonPropertyName("Q")]
    public string? QUppercase { get; set; }

    /// <summary>Trailing Time; This is only visible if the trailing stop order has been activated.</summary>
    [JsonPropertyName("D")]
    public long? DUppercase { get; set; }

    /// <summary>
    /// Strategy ID; This is only visible if the strategyId parameter was provided upon order placement
    /// </summary>
    [JsonPropertyName("j")]
    public long? J { get; set; }

    /// <summary>
    /// Strategy Type; This is only visible if the strategyType parameter was provided upon order placement
    /// </summary>
    [JsonPropertyName("J")]
    public long? JUppercase { get; set; }

    /// <summary>Working Time; This is only visible if the order has been placed on the book.</summary>
    [JsonPropertyName("W")]
    public long? WUppercase { get; set; }

    /// <summary>selfTradePreventionMode</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>
    /// TradeGroupId; This is only visible if the account is part of a trade group and the order expired due
    /// to STP trigger.
    /// </summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>CounterOrderId; This is only visible if the order expired due to STP trigger.</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }

    /// <summary>Prevented Quantity; This is only visible if the order expired due to STP trigger.</summary>
    [JsonPropertyName("A")]
    public string? AUppercase { get; set; }

    /// <summary>
    /// Last Prevented Quantity; This is only visible if the order expired due to STP trigger.
    /// </summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }

    /// <summary>Counter Symbol; This is only visible if the order expired due to STP trigger.</summary>
    [JsonPropertyName("Cs")]
    public string? Cs { get; set; }

    /// <summary>
    /// Prevented Execution Quantity; This is only visible if the order expired due to STP trigger.
    /// </summary>
    [JsonPropertyName("pl")]
    public string? Pl { get; set; }

    /// <summary>
    /// Prevented Execution Price; This is only visible if the order expired due to STP trigger.
    /// </summary>
    [JsonPropertyName("pL")]
    public string? PLUppercase { get; set; }

    /// <summary>
    /// Prevented Execution Quote Qty; This is only visible if the order expired due to STP trigger.
    /// </summary>
    [JsonPropertyName("pY")]
    public string? PYUppercase { get; set; }

    /// <summary>Expiry Reason; This is only visible if the order has expired.</summary>
    [JsonPropertyName("eR")]
    public string? ERUppercase { get; set; }
}
