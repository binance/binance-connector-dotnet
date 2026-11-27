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

namespace Binance.Algo.RestApi;

public sealed class QuerySubOrdersFutureAlgoResponseSubOrdersInner
{
    /// <summary>Algo order ID</summary>
    [JsonPropertyName("algoId")]
    public long? AlgoId { get; set; }

    /// <summary>Sub-order ID</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Sub-order status</summary>
    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }

    /// <summary>Executed quantity</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>Executed amount</summary>
    [JsonPropertyName("executedAmt")]
    public string? ExecutedAmt { get; set; }

    /// <summary>Fee amount</summary>
    [JsonPropertyName("feeAmt")]
    public string? FeeAmt { get; set; }

    /// <summary>Fee asset</summary>
    [JsonPropertyName("feeAsset")]
    public string? FeeAsset { get; set; }

    /// <summary>Order creation time</summary>
    [JsonPropertyName("bookTime")]
    public long? BookTime { get; set; }

    /// <summary>Average execution price</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>Trading side</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Sub-order execution sequence ID</summary>
    [JsonPropertyName("subId")]
    public long? SubId { get; set; }

    /// <summary>Time in force</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Original order quantity</summary>
    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }
}
