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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class PlaceMultipleOrdersResponseInner
{
    /// <summary>System order number</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Option trading pair</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Order Price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Order Quantity</summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>Number of executed quantity</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>fee</summary>
    [JsonPropertyName("fee")]
    public long? Fee { get; set; }

    /// <summary>Buy/sell direction</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Order type</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Time in force method</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Order is reduce only Y/N</summary>
    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    /// <summary>post Only</summary>
    [JsonPropertyName("postOnly")]
    public bool? PostOnly { get; set; }

    /// <summary>Order Time</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>Update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>Order status</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Average price of completed trade</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>Client order ID</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>price Scale</summary>
    [JsonPropertyName("priceScale")]
    public long? PriceScale { get; set; }

    /// <summary>quantity Scale</summary>
    [JsonPropertyName("quantityScale")]
    public long? QuantityScale { get; set; }

    /// <summary>option Side</summary>
    [JsonPropertyName("optionSide")]
    public string? OptionSide { get; set; }

    /// <summary>quote Asset</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }

    /// <summary>mmp</summary>
    [JsonPropertyName("mmp")]
    public bool? Mmp { get; set; }

    /// <summary>self trading prevention mode</summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }
}
