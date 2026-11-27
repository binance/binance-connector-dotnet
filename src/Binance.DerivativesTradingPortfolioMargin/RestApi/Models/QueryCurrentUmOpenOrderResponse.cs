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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class QueryCurrentUmOpenOrderResponse
{
    /// <summary>Avg Price.</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>Client Order ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>Cum Quote.</summary>
    [JsonPropertyName("cumQuote")]
    public string? CumQuote { get; set; }

    /// <summary>Executed Qty.</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>
    /// Normal orderID after trigger if appliable, only have when the strategy is triggered
    /// </summary>
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

    /// <summary>BOTH means that it is the position of One-way Mode</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>order time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Normal order type after trigger if appliable</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>self trading preventation mode</summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>order pre-set auot cancel time for TIF GTD order</summary>
    [JsonPropertyName("goodTillDate")]
    public long? GoodTillDate { get; set; }

    /// <summary>Price Match.</summary>
    [JsonPropertyName("priceMatch")]
    public string? PriceMatch { get; set; }
}
