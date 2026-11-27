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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

/// <summary>Indicates that combined is set to true.</summary>
public sealed class NewOrderResponseResult
{
    /// <summary>Sub-order ID</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Client order ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>Latest token price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Original order quantity</summary>
    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    /// <summary>Executed quantity</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>Cumulative filled quantity.</summary>
    [JsonPropertyName("cumQty")]
    public string? CumQty { get; set; }

    /// <summary>Time in force</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Order type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Whether the order is reduce-only.</summary>
    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    /// <summary>if Close-All</summary>
    [JsonPropertyName("closePosition")]
    public bool? ClosePosition { get; set; }

    /// <summary>Trading side</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>please ignore when order type is TRAILING_STOP_MARKET</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>Stop trigger price type.</summary>
    [JsonPropertyName("workingType")]
    public string? WorkingType { get; set; }

    /// <summary>if conditional order trigger is protected</summary>
    [JsonPropertyName("priceProtect")]
    public bool? PriceProtect { get; set; }

    /// <summary>Original order type.</summary>
    [JsonPropertyName("origType")]
    public string? OrigType { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
