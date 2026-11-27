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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class QueryOrderResponseResult
{
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    [JsonPropertyName("cumQuote")]
    public string? CumQuote { get; set; }

    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    [JsonPropertyName("origType")]
    public string? OrigType { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>please ignore when order type is TRAILING_STOP_MARKET</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>if Close-All</summary>
    [JsonPropertyName("closePosition")]
    public bool? ClosePosition { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>order time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

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

    [JsonPropertyName("workingType")]
    public string? WorkingType { get; set; }

    /// <summary>if conditional order trigger is protected</summary>
    [JsonPropertyName("priceProtect")]
    public bool? PriceProtect { get; set; }

    [JsonPropertyName("priceMatch")]
    public string? PriceMatch { get; set; }

    /// <summary>Self-trade prevention mode</summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    /// <summary>Order good till date timestamp</summary>
    [JsonPropertyName("goodTillDate")]
    public long? GoodTillDate { get; set; }
}
