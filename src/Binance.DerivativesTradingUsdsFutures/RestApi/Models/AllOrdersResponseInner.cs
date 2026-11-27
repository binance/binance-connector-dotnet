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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class AllOrdersResponseInner
{
    /// <summary>Avg Price.</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>Client Order Id.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>Cum Quote.</summary>
    [JsonPropertyName("cumQuote")]
    public string? CumQuote { get; set; }

    /// <summary>Cum Base.</summary>
    [JsonPropertyName("cumBase")]
    public string? CumBase { get; set; }

    /// <summary>Executed Qty.</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>Order Id.</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Orig Qty.</summary>
    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    /// <summary>Orig Type.</summary>
    [JsonPropertyName("origType")]
    public string? OrigType { get; set; }

    /// <summary>Price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Reduce Only.</summary>
    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    /// <summary>Side.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Position Side.</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>please ignore when order type is TRAILING_STOP_MARKET</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>if Close-All</summary>
    [JsonPropertyName("closePosition")]
    public bool? ClosePosition { get; set; }

    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair.</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>order time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>activation price, only return with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("activatePrice")]
    public string? ActivatePrice { get; set; }

    /// <summary>callback rate, only return with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("priceRate")]
    public string? PriceRate { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>Working Type.</summary>
    [JsonPropertyName("workingType")]
    public string? WorkingType { get; set; }

    /// <summary>if conditional order trigger is protected</summary>
    [JsonPropertyName("priceProtect")]
    public bool? PriceProtect { get; set; }

    /// <summary>price match mode</summary>
    [JsonPropertyName("priceMatch")]
    public string? PriceMatch { get; set; }

    /// <summary>self trading preventation mode</summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>order pre-set auot cancel time for TIF GTD order</summary>
    [JsonPropertyName("goodTillDate")]
    public long? GoodTillDate { get; set; }
}
