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

public sealed class OrderStatusResponseResult
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Present only for orders that belong to an order list.</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>Always present. Zero if the order type does not use quoteOrderQty.</summary>
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

    /// <summary>Always present. Zero if the order type does not use stopPrice.</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>Present only if trailingDelta was set on the order.</summary>
    [JsonPropertyName("trailingDelta")]
    public long? TrailingDelta { get; set; }

    /// <summary>Present only if trailingDelta was set on the order.</summary>
    [JsonPropertyName("trailingTime")]
    public long? TrailingTime { get; set; }

    /// <summary>Always present. Zero for non-iceberg orders.</summary>
    [JsonPropertyName("icebergQty")]
    public string? IcebergQty { get; set; }

    /// <summary>Order placement time.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Time of the last update to the order.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    [JsonPropertyName("isWorking")]
    public bool? IsWorking { get; set; }

    [JsonPropertyName("workingTime")]
    public long? WorkingTime { get; set; }

    /// <summary>Present only if strategyId was set on the order.</summary>
    [JsonPropertyName("strategyId")]
    public long? StrategyId { get; set; }

    /// <summary>Present only if strategyType was set on the order.</summary>
    [JsonPropertyName("strategyType")]
    public long? StrategyType { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>Present only if the order expired due to STP.</summary>
    [JsonPropertyName("preventedMatchId")]
    public long? PreventedMatchId { get; set; }

    /// <summary>Present only if the order expired due to STP.</summary>
    [JsonPropertyName("preventedQuantity")]
    public string? PreventedQuantity { get; set; }

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
}
