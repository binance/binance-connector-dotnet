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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class UsersForceOrdersResponseInner
{
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair.</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    [JsonPropertyName("cumQuote")]
    public string? CumQuote { get; set; }

    /// <summary>Cum Base.</summary>
    [JsonPropertyName("cumBase")]
    public string? CumBase { get; set; }

    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }

    [JsonPropertyName("closePosition")]
    public bool? ClosePosition { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    [JsonPropertyName("workingType")]
    public string? WorkingType { get; set; }

    [JsonPropertyName("origType")]
    public string? OrigType { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
