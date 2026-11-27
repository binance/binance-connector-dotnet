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

namespace Binance.StockOptions.WebSocketStreams;

public sealed class OrderReportV2StreamResponse
{
    /// <summary>Event type, always "orderReportV2".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Push time (ms).</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>
    /// ORDER_UPDATE: the order is open (new, accepted by the broker, partially filled, cancel pending,
    /// etc.). ORDER_TERMINAL: the order reached a terminal state and will not be pushed again.
    /// </summary>
    [JsonPropertyName("x")]
    public string? X { get; set; }

    /// <summary>Order ID. REST field orderId.</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Client order ID. REST field clientOrderId.</summary>
    [JsonPropertyName("ci")]
    public string? Ci { get; set; }

    /// <summary>Broker-side asset ID. Not needed by callers.</summary>
    [JsonPropertyName("ai")]
    public string? Ai { get; set; }

    /// <summary>
    /// Internal asset code (e.g. EQ_SPCX). Not needed by callers; read the underlying from u. May be null
    /// for expiration-day auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>
    /// Quote asset; USDC for options. REST field quoteAsset. May be null for expiration-day
    /// auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Side: "buy" / "sell". Note: lowercase, unlike REST side.</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }

    /// <summary>
    /// Order type, lowercase: "limit" for user orders; "market" for expiration-day auto-liquidation orders
    /// by the broker. REST orderType is uppercase.
    /// </summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>
    /// Limit price (premium per share). REST field limitPrice. May be null for expiration-day
    /// auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("p")]
    public decimal? P { get; set; }

    /// <summary>Order quantity (contracts). REST field qty.</summary>
    [JsonPropertyName("Q")]
    public decimal? QUppercase { get; set; }

    /// <summary>Order notional. Always null for options.</summary>
    [JsonPropertyName("N")]
    public decimal? NUppercase { get; set; }

    /// <summary>Cumulative filled quantity (contracts). REST field filledQty.</summary>
    [JsonPropertyName("fq")]
    public decimal? Fq { get; set; }

    /// <summary>
    /// Cumulative filled amount (USD) = average fill price × filled contracts × multiplier. REST field
    /// filledNotional.
    /// </summary>
    [JsonPropertyName("FN")]
    public decimal? FNUppercase { get; set; }

    /// <summary>
    /// Amount locked from the wallet at placement: premium plus fees for buy to open and buy to close
    /// (covered call); for buy to close (cash-secured put), only the shortfall after the collateral is
    /// released (usually 0); the collateral for sell to open (shares for a covered call, cash for a
    /// cash-secured put); 0 for sell to close. REST field totalCost. May be null for expiration-day
    /// auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("tc")]
    public decimal? Tc { get; set; }

    /// <summary>Fill progress percentage (0–100, 2 dp) = fq / Q × 100. REST field filledPercent.</summary>
    [JsonPropertyName("Z")]
    public decimal? ZUppercase { get; set; }

    /// <summary>Trading session; always RTH for options.</summary>
    [JsonPropertyName("n")]
    public string? N { get; set; }

    /// <summary>
    /// Order status, lowercase. With ORDER_UPDATE: new / pending_new / accepted / partially_filled /
    /// pending_cancel / pending_replace. With ORDER_TERMINAL: filled / canceled / expired / rejected /
    /// replaced. REST field status is uppercase.
    /// </summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Order creation time (ms). REST field createdAt.</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Order last update time (ms). REST field updatedAt.</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }

    /// <summary>Asset class: us_option (US stock options) / us_equity (US stocks).</summary>
    [JsonPropertyName("ac")]
    public string? Ac { get; set; }

    /// <summary>OCC contract symbol. REST field symbol.</summary>
    [JsonPropertyName("os")]
    public string? Os { get; set; }

    /// <summary>
    /// Underlying US-equity ticker. REST field underlyingSymbol. May be null for expiration-day
    /// auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("u")]
    public string? U { get; set; }

    /// <summary>
    /// OCC root; differs from u for contracts adjusted by a corporate action. REST field rootSymbol.
    /// </summary>
    [JsonPropertyName("rs")]
    public string? Rs { get; set; }

    /// <summary>
    /// CALL / PUT. REST field contractType. May be null for expiration-day auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("ct")]
    public string? Ct { get; set; }

    /// <summary>
    /// Strike price. REST field strikePrice. May be null for expiration-day auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("sp")]
    public decimal? Sp { get; set; }

    /// <summary>
    /// Expiration date as the millisecond timestamp of 12:00 ET on the expiration day, same as REST
    /// expirationDate. May be null for expiration-day auto-liquidation orders.
    /// </summary>
    [JsonPropertyName("ed")]
    public long? Ed { get; set; }

    /// <summary>Contract multiplier. REST field multiplier.</summary>
    [JsonPropertyName("m")]
    public decimal? M { get; set; }

    /// <summary>
    /// Position intent, lowercase: buy_to_open / sell_to_close / sell_to_open / buy_to_close. REST field
    /// positionIntent is uppercase.
    /// </summary>
    [JsonPropertyName("pi")]
    public string? Pi { get; set; }
}
