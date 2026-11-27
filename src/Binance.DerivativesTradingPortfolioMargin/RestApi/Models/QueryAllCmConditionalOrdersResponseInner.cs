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

public sealed class QueryAllCmConditionalOrdersResponseInner
{
    /// <summary>New Client Strategy ID.</summary>
    [JsonPropertyName("newClientStrategyId")]
    public string? NewClientStrategyId { get; set; }

    /// <summary>Strategy ID.</summary>
    [JsonPropertyName("strategyId")]
    public long? StrategyId { get; set; }

    /// <summary>Strategy Status.</summary>
    [JsonPropertyName("strategyStatus")]
    public string? StrategyStatus { get; set; }

    /// <summary>Strategy Type.</summary>
    [JsonPropertyName("strategyType")]
    public string? StrategyType { get; set; }

    /// <summary>Orig Qty.</summary>
    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

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

    /// <summary>please ignore when order type is TRAILING_STOP_MARKET</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Normal orderID after trigger if appliable, only have when the strategy is triggered
    /// </summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>
    /// Normal order status after trigger if appliable, only have when the strategy is triggered
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>order time</summary>
    [JsonPropertyName("bookTime")]
    public long? BookTime { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>Trigger Time.</summary>
    [JsonPropertyName("triggerTime")]
    public long? TriggerTime { get; set; }

    /// <summary>Time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Normal order type after trigger if appliable</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>activation price, only return with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("activatePrice")]
    public string? ActivatePrice { get; set; }

    /// <summary>callback rate, only return with TRAILING_STOP_MARKET order</summary>
    [JsonPropertyName("priceRate")]
    public string? PriceRate { get; set; }
}
