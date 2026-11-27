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

public sealed class CurrentOpenOrdersResponseInner
{
    /// <summary>Equity order id.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>US-equity ticker.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Quote asset (e.g. USDC).</summary>
    [JsonPropertyName("quote")]
    public string? Quote { get; set; }

    /// <summary>BUY / SELL.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>MARKET / LIMIT.</summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }

    /// <summary>Limit price (USD). Non-null for LIMIT orders, null for MARKET.</summary>
    [JsonPropertyName("limitPrice")]
    public string? LimitPrice { get; set; }

    /// <summary>Average fill price (USD). null until the first fill.</summary>
    [JsonPropertyName("avgFilledPrice")]
    public string? AvgFilledPrice { get; set; }

    /// <summary>Requested quantity. null for BUY MARKET (use notional instead).</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Requested notional. Non-null for BUY MARKET; null otherwise.</summary>
    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    /// <summary>Cumulative filled quantity.</summary>
    [JsonPropertyName("filledQty")]
    public string? FilledQty { get; set; }

    /// <summary>Cumulative filled notional. Populated only for BUY MARKET.</summary>
    [JsonPropertyName("filledTotal")]
    public string? FilledTotal { get; set; }

    /// <summary>Total commission fee (USD).</summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>
    /// Trading session the order was placed under: RTH / EXTENDED / 24H. null for MARKET orders.
    /// </summary>
    [JsonPropertyName("session")]
    public string? Session { get; set; }

    /// <summary>
    /// Order lifecycle status — one of NEW / ACCEPTED / PARTIALLY_FILLED / FILLED / CANCELED / EXPIRED /
    /// REJECTED.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Order creation time (ms epoch).</summary>
    [JsonPropertyName("createdAt")]
    public long? CreatedAt { get; set; }

    /// <summary>Last update time (ms epoch).</summary>
    [JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }
}
