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

public sealed class OrderCancelResponseResult
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>clientOrderId that was canceled</summary>
    [JsonPropertyName("origClientOrderId")]
    public string? OrigClientOrderId { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>set only for legs of an order list</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    /// <summary>newClientOrderId from request</summary>
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

    /// <summary>present only if stopPrice set for the order</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>present only if trailingDelta set for the order</summary>
    [JsonPropertyName("trailingDelta")]
    public long? TrailingDelta { get; set; }

    /// <summary>present only if icebergQty set for the order</summary>
    [JsonPropertyName("icebergQty")]
    public string? IcebergQty { get; set; }

    /// <summary>present only if strategyId set for the order</summary>
    [JsonPropertyName("strategyId")]
    public long? StrategyId { get; set; }

    /// <summary>present only if strategyType set for the order</summary>
    [JsonPropertyName("strategyType")]
    public long? StrategyType { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>Appears only if the order expired due to STP.</summary>
    [JsonPropertyName("preventedMatchId")]
    public long? PreventedMatchId { get; set; }

    /// <summary>Order quantity that expired due to STP.</summary>
    [JsonPropertyName("preventedQuantity")]
    public string? PreventedQuantity { get; set; }

    /// <summary>Time when the trailing order is now active and tracking price changes.</summary>
    [JsonPropertyName("trailingTime")]
    public long? TrailingTime { get; set; }

    /// <summary>Field that determines whether order used SOR.</summary>
    [JsonPropertyName("usedSor")]
    public bool? UsedSor { get; set; }

    /// <summary>Determines whether the order is being filled by the SOR or by the order book.</summary>
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

    /// <summary>Current price order is pegged at. Only for pegged orders, once determined.</summary>
    [JsonPropertyName("peggedPrice")]
    public string? PeggedPrice { get; set; }

    /// <summary>Cause of the order's expiration. Appears when an order has expired.</summary>
    [JsonPropertyName("expiryReason")]
    public string? ExpiryReason { get; set; }

    [JsonPropertyName("contingencyType")]
    public string? ContingencyType { get; set; }

    [JsonPropertyName("listStatusType")]
    public string? ListStatusType { get; set; }

    [JsonPropertyName("listOrderStatus")]
    public string? ListOrderStatus { get; set; }

    [JsonPropertyName("listClientOrderId")]
    public string? ListClientOrderId { get; set; }

    [JsonPropertyName("transactionTime")]
    public long? TransactionTime { get; set; }

    [JsonPropertyName("orders")]
    public List<OpenOrdersCancelAllResponseResultInnerOrdersInner>? Orders { get; set; }

    /// <summary>order list order's status format is the same as for individual orders.</summary>
    [JsonPropertyName("orderReports")]
    public List<OpenOrdersCancelAllResponseResultInnerOrderReportsInner>? OrderReports { get; set; }
}
