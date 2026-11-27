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

public sealed class QueryAllAlgoOrdersResponseInner
{
    [JsonPropertyName("algoId")]
    public long? AlgoId { get; set; }

    [JsonPropertyName("clientAlgoId")]
    public string? ClientAlgoId { get; set; }

    [JsonPropertyName("algoType")]
    public string? AlgoType { get; set; }

    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    [JsonPropertyName("algoStatus")]
    public string? AlgoStatus { get; set; }

    [JsonPropertyName("actualOrderId")]
    public string? ActualOrderId { get; set; }

    [JsonPropertyName("actualPrice")]
    public string? ActualPrice { get; set; }

    [JsonPropertyName("triggerPrice")]
    public string? TriggerPrice { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Reserved field, ignore.</summary>
    [JsonPropertyName("icebergQuantity")]
    public string? IcebergQuantity { get; set; }

    [JsonPropertyName("tpTriggerPrice")]
    public string? TpTriggerPrice { get; set; }

    [JsonPropertyName("tpPrice")]
    public string? TpPrice { get; set; }

    [JsonPropertyName("slTriggerPrice")]
    public string? SlTriggerPrice { get; set; }

    [JsonPropertyName("slPrice")]
    public string? SlPrice { get; set; }

    [JsonPropertyName("tpOrderType")]
    public string? TpOrderType { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    [JsonPropertyName("workingType")]
    public string? WorkingType { get; set; }

    [JsonPropertyName("priceMatch")]
    public string? PriceMatch { get; set; }

    [JsonPropertyName("closePosition")]
    public bool? ClosePosition { get; set; }

    [JsonPropertyName("priceProtect")]
    public bool? PriceProtect { get; set; }

    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    [JsonPropertyName("triggerTime")]
    public long? TriggerTime { get; set; }

    [JsonPropertyName("goodTillDate")]
    public long? GoodTillDate { get; set; }
}
