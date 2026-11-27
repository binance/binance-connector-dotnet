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

namespace Binance.Stocks.RestApi;

/// <summary>
/// Top-level fields mirror an order row from /order/history (orderId, symbol, quote, side, orderType,
/// limitPrice, avgFilledPrice, qty, notional, filledQty, filledTotal, fee, session, status, createdAt,
/// updatedAt), plus a trades array. clientOrderId is present only in Order Detail, not in Order
/// History.
/// </summary>
public sealed class EquityOrderDetailResponse
{
    /// <summary>Equity order id.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>Client-supplied order id. Present only in Order Detail, not in Order History.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>US-equity ticker.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Quote asset.</summary>
    [JsonPropertyName("quote")]
    public string? Quote { get; set; }

    /// <summary>BUY / SELL.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>MARKET / LIMIT.</summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    /// <summary>Limit price (USD). Non-null for LIMIT, null for MARKET.</summary>
    [JsonPropertyName("limitPrice")]
    public string? LimitPrice { get; set; }

    /// <summary>Average fill price (USD). Only present when the order has at least one fill.</summary>
    [JsonPropertyName("avgFilledPrice")]
    public string? AvgFilledPrice { get; set; }

    /// <summary>Requested quantity.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Requested notional.</summary>
    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    /// <summary>Cumulative filled quantity.</summary>
    [JsonPropertyName("filledQty")]
    public string? FilledQty { get; set; }

    /// <summary>Cumulative filled notional.</summary>
    [JsonPropertyName("filledTotal")]
    public string? FilledTotal { get; set; }

    /// <summary>Total commission fee (USD).</summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>Trading session.</summary>
    [JsonPropertyName("session")]
    public string? Session { get; set; }

    /// <summary>Order lifecycle status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Order creation time (ms epoch).</summary>
    [JsonPropertyName("createdAt")]
    public long? CreatedAt { get; set; }

    /// <summary>Last update time (ms epoch).</summary>
    [JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }

    /// <summary>Trade executions for this order, most recent first. Empty array when no fills.</summary>
    [JsonPropertyName("trades")]
    public List<EquityOrderDetailResponseTradesInner>? Trades { get; set; }
}
