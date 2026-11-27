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

public sealed class MarginAccountCancelOcoResponseOrderReportsInner
{
    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>orig Client Order Id.</summary>
    [JsonPropertyName("origClientOrderId")]
    public string? OrigClientOrderId { get; set; }

    /// <summary>order Id.</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>order List Id.</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    /// <summary>client Order Id.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>orig Qty.</summary>
    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    /// <summary>executed Qty.</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>cummulative Quote Qty.</summary>
    [JsonPropertyName("cummulativeQuoteQty")]
    public string? CummulativeQuoteQty { get; set; }

    /// <summary>status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>side.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>stop Price.</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>self Trade Prevention Mode.</summary>
    [JsonPropertyName("selfTradePreventionMode")]
    public string? SelfTradePreventionMode { get; set; }
}
