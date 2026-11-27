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

public sealed class EquityTradeHistoryResponseRowsInner
{
    /// <summary>Execution (per-fill) id.</summary>
    [JsonPropertyName("executionId")]
    public string? ExecutionId { get; set; }

    /// <summary>The owning order's id.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

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

    /// <summary>Execution price (USD).</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Executed quantity.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Notional of this execution (qty × price).</summary>
    [JsonPropertyName("total")]
    public string? Total { get; set; }

    /// <summary>Execution time (ms epoch).</summary>
    [JsonPropertyName("executionAt")]
    public long? ExecutionAt { get; set; }

    /// <summary>Last update time (ms epoch).</summary>
    [JsonPropertyName("updatedAt")]
    public long? UpdatedAt { get; set; }
}
