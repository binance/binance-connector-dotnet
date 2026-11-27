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

public sealed class QueryUsersMarginForceOrdersResponseRowsInner
{
    /// <summary>Avg Price.</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>Executed Qty.</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>
    /// Normal orderID after trigger if appliable, only have when the strategy is triggered
    /// </summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>Side.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Updated Time.</summary>
    [JsonPropertyName("updatedTime")]
    public long? UpdatedTime { get; set; }
}
