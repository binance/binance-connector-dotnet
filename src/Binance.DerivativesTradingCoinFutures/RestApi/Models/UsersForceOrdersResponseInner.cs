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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class UsersForceOrdersResponseInner
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

    /// <summary>Average execution price</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>Original order quantity</summary>
    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    /// <summary>Executed quantity</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>Cumulative base asset amount.</summary>
    [JsonPropertyName("cumBase")]
    public string? CumBase { get; set; }

    /// <summary>Cumulative quote asset amount.</summary>
    [JsonPropertyName("cumQuote")]
    public string? CumQuote { get; set; }

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

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>order pre-set auto cancel time for TIF GTD order</summary>
    [JsonPropertyName("goodTillDate")]
    public long? GoodTillDate { get; set; }
}
