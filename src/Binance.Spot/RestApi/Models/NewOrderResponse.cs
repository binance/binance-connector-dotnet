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

public sealed class NewOrderResponse
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Unless it's part of an order list, value will be -1</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

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

    [JsonPropertyName("workingTime")]
    public long? WorkingTime { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>Appears for STOP_LOSS, TAKE_PROFIT, STOP_LOSS_LIMIT, and TAKE_PROFIT_LIMIT orders.</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>Delta price change required before order activation.</summary>
    [JsonPropertyName("trailingDelta")]
    public long? TrailingDelta { get; set; }

    /// <summary>Appears only if the parameter icebergQty was sent in the request.</summary>
    [JsonPropertyName("icebergQty")]
    public string? IcebergQty { get; set; }

    /// <summary>Appears only if the strategyId parameter was provided upon order placement.</summary>
    [JsonPropertyName("strategyId")]
    public long? StrategyId { get; set; }

    /// <summary>Appears only if the strategyType parameter was provided upon order placement.</summary>
    [JsonPropertyName("strategyType")]
    public long? StrategyType { get; set; }

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

    [JsonPropertyName("fills")]
    public List<NewOrderResponseFillsInner>? Fills { get; set; }
}
