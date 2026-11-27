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

public sealed class AccountBlockTradeListResponseInnerLegsInner
{
    /// <summary>create Time</summary>
    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    /// <summary>update Time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>order Id</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>order Price</summary>
    [JsonPropertyName("orderPrice")]
    public decimal? OrderPrice { get; set; }

    /// <summary>order Quantity</summary>
    [JsonPropertyName("orderQuantity")]
    public decimal? OrderQuantity { get; set; }

    /// <summary>order Status</summary>
    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }

    /// <summary>executed Qty</summary>
    [JsonPropertyName("executedQty")]
    public decimal? ExecutedQty { get; set; }

    /// <summary>executed Amount</summary>
    [JsonPropertyName("executedAmount")]
    public decimal? ExecutedAmount { get; set; }

    /// <summary>fee</summary>
    [JsonPropertyName("fee")]
    public decimal? Fee { get; set; }

    /// <summary>order Type</summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    /// <summary>order Side</summary>
    [JsonPropertyName("orderSide")]
    public string? OrderSide { get; set; }

    /// <summary>id</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>trade Id</summary>
    [JsonPropertyName("tradeId")]
    public long? TradeId { get; set; }

    /// <summary>trade Price</summary>
    [JsonPropertyName("tradePrice")]
    public decimal? TradePrice { get; set; }

    /// <summary>trade Qty</summary>
    [JsonPropertyName("tradeQty")]
    public decimal? TradeQty { get; set; }

    /// <summary>trade Time</summary>
    [JsonPropertyName("tradeTime")]
    public long? TradeTime { get; set; }

    /// <summary>liquidity</summary>
    [JsonPropertyName("liquidity")]
    public string? Liquidity { get; set; }

    /// <summary>commission</summary>
    [JsonPropertyName("commission")]
    public decimal? Commission { get; set; }
}
