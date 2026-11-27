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

namespace Binance.Spot.RestApi;

public sealed class OrderOcoResponseOrderReportsInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    [JsonPropertyName("transactTime")]
    public long? TransactTime { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    [JsonPropertyName("origQuoteOrderQty")]
    public string? OrigQuoteOrderQty { get; set; }

    [JsonPropertyName("cummulativeQuoteQty")]
    public string? CummulativeQuoteQty { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("workingTime")]
    public long? WorkingTime { get; set; }

    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }

    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }
}
