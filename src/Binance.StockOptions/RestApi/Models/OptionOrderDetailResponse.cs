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

namespace Binance.StockOptions.RestApi;

public sealed class OptionOrderDetailResponse
{
    /// <summary>Option order ID.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>Client order ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>OCC option contract symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Underlying US-equity ticker.</summary>
    [JsonPropertyName("underlyingSymbol")]
    public string? UnderlyingSymbol { get; set; }

    /// <summary>
    /// OCC root symbol. Differs from underlyingSymbol for contracts adjusted by a corporate action (e.g.
    /// GOOG1).
    /// </summary>
    [JsonPropertyName("rootSymbol")]
    public string? RootSymbol { get; set; }

    /// <summary>CALL / PUT.</summary>
    [JsonPropertyName("contractType")]
    public string? ContractType { get; set; }

    /// <summary>Strike price.</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>
    /// Expiration date as the millisecond timestamp of 12:00 ET on the expiration day. Convert in
    /// America/New_York and take the date part (see General Info).
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public long? ExpirationDate { get; set; }

    /// <summary>Premium multiplier. Order cost = price × quantity × multiplier.</summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }

    /// <summary>Position intent: BUY_TO_OPEN / SELL_TO_CLOSE / SELL_TO_OPEN / BUY_TO_CLOSE.</summary>
    [JsonPropertyName("positionIntent")]
    public string? PositionIntent { get; set; }

    /// <summary>
    /// true if the order was initiated by the broker's automatic liquidation rather than by the user.
    /// </summary>
    [JsonPropertyName("autoLiquidation")]
    public bool? AutoLiquidation { get; set; }

    /// <summary>Quote asset (named quoteAsset in Current Open Option Orders).</summary>
    [JsonPropertyName("quote")]
    public string? Quote { get; set; }

    /// <summary>BUY / SELL.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>
    /// Order type: LIMIT; MARKET for orders placed by the broker's automatic liquidation on the expiration
    /// date.
    /// </summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    /// <summary>
    /// Limit price (premium per share). Returned as reported by the broker regardless of order type; not
    /// returned for MARKET orders, which have no limit price.
    /// </summary>
    [JsonPropertyName("limitPrice")]
    public string? LimitPrice { get; set; }

    /// <summary>
    /// Average fill price (premium per share) as reported by the broker, returned for all order types. Not
    /// returned if the order has no fills.
    /// </summary>
    [JsonPropertyName("avgFilledPrice")]
    public string? AvgFilledPrice { get; set; }

    /// <summary>Order quantity (contracts).</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Cumulative filled quantity (contracts).</summary>
    [JsonPropertyName("filledQty")]
    public string? FilledQty { get; set; }

    /// <summary>Cumulative filled amount.</summary>
    [JsonPropertyName("filledTotal")]
    public string? FilledTotal { get; set; }

    /// <summary>
    /// Cumulative fees = commission + sec + taf + cat + orf + occ (excluding platformFee). Fees are
    /// returned at the order level only; individual fills carry no fee.
    /// </summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>Order status, e.g. FILLED / PARTIALLY_FILLED / CANCELED / EXPIRED / REJECTED.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Creation time (ms).</summary>
    [JsonPropertyName("createdAt")]
    public long? CreatedAt { get; set; }

    /// <summary>Last update time (ms).</summary>
    [JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }

    /// <summary>Time in force. Always DAY.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Commission.</summary>
    [JsonPropertyName("commission")]
    public string? Commission { get; set; }

    /// <summary>Platform fee.</summary>
    [JsonPropertyName("platformFee")]
    public string? PlatformFee { get; set; }

    /// <summary>SEC fee. Charged on sell orders only; 0 for buy orders.</summary>
    [JsonPropertyName("sec")]
    public string? Sec { get; set; }

    /// <summary>FINRA TAF. Charged on sell orders only; 0 for buy orders.</summary>
    [JsonPropertyName("taf")]
    public string? Taf { get; set; }

    /// <summary>FINRA CAT fee.</summary>
    [JsonPropertyName("cat")]
    public string? Cat { get; set; }

    /// <summary>Options Regulatory Fee (ORF).</summary>
    [JsonPropertyName("orf")]
    public string? Orf { get; set; }

    /// <summary>OCC clearing fee.</summary>
    [JsonPropertyName("occ")]
    public string? Occ { get; set; }

    /// <summary>
    /// Cumulative filled amount, same as filledTotal (average fill price × filled quantity × multiplier),
    /// excluding fees.
    /// </summary>
    [JsonPropertyName("total")]
    public string? Total { get; set; }

    /// <summary>Fully filled time (ms).</summary>
    [JsonPropertyName("filledAt")]
    public long? FilledAt { get; set; }

    /// <summary>Cancel time (ms). Returned only for canceled orders.</summary>
    [JsonPropertyName("canceledAt")]
    public long? CanceledAt { get; set; }

    /// <summary>Expiry time (ms). Returned only for expired orders.</summary>
    [JsonPropertyName("expiredAt")]
    public long? ExpiredAt { get; set; }

    /// <summary>
    /// Millisecond timestamp of 14:00 ET on the settlement date. Returned only for sell orders with fills.
    /// </summary>
    [JsonPropertyName("settlementDate")]
    public long? SettlementDate { get; set; }

    /// <summary>
    /// Fills of this order, sorted by execution time in descending order. Individual fills carry no fee;
    /// see the order-level fee and itemized fees.
    /// </summary>
    [JsonPropertyName("trades")]
    public List<OptionOrderDetailResponseTradesInner>? Trades { get; set; }
}
