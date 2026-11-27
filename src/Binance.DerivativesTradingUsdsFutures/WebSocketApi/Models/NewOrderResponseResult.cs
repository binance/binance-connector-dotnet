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

public sealed class NewOrderResponseResult
{
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    [JsonPropertyName("cumQty")]
    public string? CumQty { get; set; }

    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    [JsonPropertyName("closePosition")]
    public bool? ClosePosition { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    [JsonPropertyName("workingType")]
    public string? WorkingType { get; set; }

    [JsonPropertyName("priceProtect")]
    public bool? PriceProtect { get; set; }

    [JsonPropertyName("origType")]
    public string? OrigType { get; set; }

    [JsonPropertyName("priceMatch")]
    public string? PriceMatch { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    [JsonPropertyName("goodTillDate")]
    public long? GoodTillDate { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
