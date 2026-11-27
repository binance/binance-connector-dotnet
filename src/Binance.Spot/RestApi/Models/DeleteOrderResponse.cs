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

namespace Binance.Spot.RestApi;

public sealed class DeleteOrderResponse
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Unless it's part of an order list, value will be -1</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    [JsonPropertyName("origClientOrderId")]
    public string? OrigClientOrderId { get; set; }

    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    [JsonPropertyName("transactTime")]
    public long? TransactTime { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    [JsonPropertyName("origQuoteOrderQty")]
    public string? OrigQuoteOrderQty { get; set; }

    [JsonPropertyName("cummulativeQuoteQty")]
    public string? CummulativeQuoteQty { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>
    /// Quantity for the iceberg order. Appears only if the parameter icebergQty was sent in the request.
    /// </summary>
    [JsonPropertyName("icebergQty")]
    public string? IcebergQty { get; set; }

    /// <summary>
    /// When used together with symbol, can be used to query a prevented match. Appears only if the order
    /// expired due to STP.
    /// </summary>
    [JsonPropertyName("preventedMatchId")]
    public long? PreventedMatchId { get; set; }

    /// <summary>
    /// Order quantity that expired due to STP. Appears only if the order expired due to STP.
    /// </summary>
    [JsonPropertyName("preventedQuantity")]
    public string? PreventedQuantity { get; set; }

    /// <summary>
    /// Price when the algorithmic order will be triggered. Appears for STOP_LOSS, TAKE_PROFIT,
    /// STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT orders.
    /// </summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>
    /// Can be used to label an order that's part of an order strategy. Appears if the parameter was
    /// populated in the request.
    /// </summary>
    [JsonPropertyName("strategyId")]
    public long? StrategyId { get; set; }

    /// <summary>
    /// Can be used to label an order that is using an order strategy. Appears if the parameter was
    /// populated in the request.
    /// </summary>
    [JsonPropertyName("strategyType")]
    public long? StrategyType { get; set; }

    /// <summary>
    /// Delta price change required before order activation. Appears for trailing stop orders.
    /// </summary>
    [JsonPropertyName("trailingDelta")]
    public long? TrailingDelta { get; set; }

    /// <summary>
    /// Time when the trailing order becomes active and starts tracking price changes. Appears only for
    /// trailing stop orders.
    /// </summary>
    [JsonPropertyName("trailingTime")]
    public long? TrailingTime { get; set; }

    /// <summary>Indicates whether the order used SOR. Appears when placing orders using SOR.</summary>
    [JsonPropertyName("usedSor")]
    public bool? UsedSor { get; set; }

    /// <summary>
    /// Indicates whether the order is being filled by SOR or by the order book to which it was submitted.
    /// Appears when placing orders using SOR.
    /// </summary>
    [JsonPropertyName("workingFloor")]
    public string? WorkingFloor { get; set; }

    /// <summary>Price peg type. Only for pegged orders.</summary>
    [JsonPropertyName("pegPriceType")]
    public string? PegPriceType { get; set; }

    /// <summary>Price peg offset type. Only for pegged orders, if requested.</summary>
    [JsonPropertyName("pegOffsetType")]
    public string? PegOffsetType { get; set; }

    /// <summary>Price peg offset value. Only for pegged orders, if requested.</summary>
    [JsonPropertyName("pegOffsetValue")]
    public long? PegOffsetValue { get; set; }

    /// <summary>Current price the order is pegged at. Only for pegged orders, once determined.</summary>
    [JsonPropertyName("peggedPrice")]
    public string? PeggedPrice { get; set; }

    /// <summary>Cause of the order's expiration. Returned when an order has expired.</summary>
    [JsonPropertyName("expiryReason")]
    public string? ExpiryReason { get; set; }
}
