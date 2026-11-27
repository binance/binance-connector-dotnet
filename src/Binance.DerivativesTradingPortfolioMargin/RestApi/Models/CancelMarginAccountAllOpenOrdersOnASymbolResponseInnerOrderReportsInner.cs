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

public sealed class CancelMarginAccountAllOpenOrdersOnASymbolResponseInnerOrderReportsInner
{
    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Orig Client Order ID.</summary>
    [JsonPropertyName("origClientOrderId")]
    public string? OrigClientOrderId { get; set; }

    /// <summary>
    /// Normal orderID after trigger if appliable, only have when the strategy is triggered
    /// </summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    /// <summary>Order List ID.</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    /// <summary>Client Order ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>Price.</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Orig Qty.</summary>
    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    /// <summary>Executed Qty.</summary>
    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    /// <summary>Cummulative Quote Qty.</summary>
    [JsonPropertyName("cummulativeQuoteQty")]
    public string? CummulativeQuoteQty { get; set; }

    /// <summary>Status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Time In Force.</summary>
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }

    /// <summary>Normal order type after trigger if appliable</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Side.</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>please ignore when order type is TRAILING_STOP_MARKET</summary>
    [JsonPropertyName("stopPrice")]
    public string? StopPrice { get; set; }

    /// <summary>Iceberg Qty.</summary>
    [JsonPropertyName("icebergQty")]
    public string? IcebergQty { get; set; }
}
