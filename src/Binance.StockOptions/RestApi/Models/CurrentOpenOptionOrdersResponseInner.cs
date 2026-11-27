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

public sealed class CurrentOpenOptionOrdersResponseInner
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

    /// <summary>Quote asset.</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>BUY / SELL.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>
    /// Order type: LIMIT; MARKET for orders placed by the broker's automatic liquidation on the expiration
    /// date.
    /// </summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    /// <summary>Limit price (premium per share).</summary>
    [JsonPropertyName("limitPrice")]
    public string? LimitPrice { get; set; }

    /// <summary>Order quantity (contracts).</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Cumulative filled quantity (contracts).</summary>
    [JsonPropertyName("filledQty")]
    public string? FilledQty { get; set; }

    /// <summary>Cumulative filled amount.</summary>
    [JsonPropertyName("filledNotional")]
    public string? FilledNotional { get; set; }

    /// <summary>
    /// Amount locked from the wallet when the order was placed (a snapshot, not updated after fills or
    /// cancellation): premium plus fees for buy-to-open and for buy-to-close of a covered call; for
    /// buy-to-close of a cash-secured put, only the shortfall remaining after the released collateral
    /// (usually 0); the collateral for sell-to-open (number of shares for a covered call, cash for a
    /// cash-secured put); 0 for sell-to-close. Not returned for broker automatic liquidation orders.
    /// </summary>
    [JsonPropertyName("totalCost")]
    public string? TotalCost { get; set; }

    /// <summary>Fill progress percentage (0–100).</summary>
    [JsonPropertyName("filledPercent")]
    public string? FilledPercent { get; set; }

    /// <summary>
    /// Order status: NEW / PENDING_NEW / ACCEPTED / PARTIALLY_FILLED / PENDING_CANCEL / PENDING_REPLACE.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Creation time (ms).</summary>
    [JsonPropertyName("createdAt")]
    public long? CreatedAt { get; set; }

    /// <summary>Last update time (ms).</summary>
    [JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }
}
