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

namespace Binance.Stocks.WebSocketStreams;

public sealed class OrderReportStreamResponse
{
    /// <summary>Event type, always "orderReport".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time (epoch milliseconds); server push time.</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>
    /// Execution type: "ORDER_UPDATE" (still open) or "ORDER_TERMINAL" (reached terminal state).
    /// </summary>
    [JsonPropertyName("x")]
    public string? X { get; set; }

    /// <summary>Order ID (UUID).</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Asset ID (internal identifier).</summary>
    [JsonPropertyName("ai")]
    public string? Ai { get; set; }

    /// <summary>
    /// Base asset — the internal asset code with an EQ_ prefix (e.g. "EQ_AAPL"), not the bare ticker used
    /// in REST responses / order input. Strip the EQ_ prefix to match a symbol used elsewhere.
    /// </summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Quote currency, e.g. "USD".</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Order side: "buy" or "sell". Note: lowercase, unlike REST responses.</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>
    /// Order type: "market" / "limit" / "stop" / "stop_limit" / "trailing_stop". Note: lowercase.
    /// </summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Limit price; null for market orders.</summary>
    [JsonPropertyName("p")]
    public decimal? P { get; set; }

    /// <summary>Order quantity (shares); 0 when the order was submitted as notional.</summary>
    [JsonPropertyName("Q")]
    public decimal? QUppercase { get; set; }

    /// <summary>
    /// Order notional; set when the order was submitted as notional (market buy), null when submitted as
    /// quantity.
    /// </summary>
    [JsonPropertyName("N")]
    public decimal? NUppercase { get; set; }

    /// <summary>Filled quantity.</summary>
    [JsonPropertyName("fq")]
    public decimal? Fq { get; set; }

    /// <summary>Filled notional (= filledQty × filledAvgPrice).</summary>
    [JsonPropertyName("FN")]
    public decimal? FNUppercase { get; set; }

    /// <summary>Total cost — cumulative buy-in cost including the commission fee.</summary>
    [JsonPropertyName("tc")]
    public decimal? Tc { get; set; }

    /// <summary>
    /// Fill progress percentage (0–100, 2 dp). By notional: FN / N × 100. By qty: fq / Q × 100.
    /// </summary>
    [JsonPropertyName("Z")]
    public decimal? ZUppercase { get; set; }

    /// <summary>Trading session label, e.g. "Regular", "24 Hours Trading".</summary>
    [JsonPropertyName("n")]
    public string? N { get; set; }

    /// <summary>
    /// Order status, e.g. "accepted", "partially_filled", "filled", "canceled". Note: lowercase, unlike
    /// REST responses.
    /// </summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Order create time (epoch milliseconds).</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Order update time (epoch milliseconds).</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }
}
