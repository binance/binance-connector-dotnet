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

public sealed class QueryOptionOrderHistoryResponseInner
{
    /// <summary>order Id</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>quantity</summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>executed Qty</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>side</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>type</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>time In Force</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>reduce Only</summary>
    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    /// <summary>create Time</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>update Time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>status</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>avg Price</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>client Order Id</summary>
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
}
