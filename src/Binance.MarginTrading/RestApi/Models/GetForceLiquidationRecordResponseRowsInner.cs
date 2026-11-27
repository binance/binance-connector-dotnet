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

namespace Binance.MarginTrading.RestApi;

public sealed class GetForceLiquidationRecordResponseRowsInner
{
    /// <summary>avg Price.</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>executed Qty.</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>order Id.</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>qty.</summary>
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }

    /// <summary>side.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>is Isolated.</summary>
    [JsonPropertyName("isIsolated")]
    public bool? IsIsolated { get; set; }

    /// <summary>updated Time.</summary>
    [JsonPropertyName("updatedTime")]
    public long? UpdatedTime { get; set; }
}
