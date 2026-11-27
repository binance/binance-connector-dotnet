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

public sealed class QueryCurrentAlgoOpenOrdersFutureAlgoResponseOrdersInner
{
    /// <summary>Algo order ID</summary>
    [JsonPropertyName("algoId")]
    public long? AlgoId { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Trading side</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>Position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Total order quantity</summary>
    [JsonPropertyName("totalQty")]
    public string? TotalQty { get; set; }

    /// <summary>Executed quantity</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>Executed amount</summary>
    [JsonPropertyName("executedAmt")]
    public string? ExecutedAmt { get; set; }

    /// <summary>Average execution price</summary>
    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    /// <summary>Client-defined algo order ID</summary>
    [JsonPropertyName("clientAlgoId")]
    public string? ClientAlgoId { get; set; }

    /// <summary>Order creation time</summary>
    [JsonPropertyName("bookTime")]
    public long? BookTime { get; set; }

    /// <summary>End time</summary>
    [JsonPropertyName("endTime")]
    public long? EndTime { get; set; }

    /// <summary>Algo order status</summary>
    [JsonPropertyName("algoStatus")]
    public string? AlgoStatus { get; set; }

    /// <summary>Algo order type</summary>
    [JsonPropertyName("algoType")]
    public string? AlgoType { get; set; }

    /// <summary>Execution urgency</summary>
    [JsonPropertyName("urgency")]
    public string? Urgency { get; set; }
}
