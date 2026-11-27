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

public sealed class CancelMarginAccountOcoOrdersResponse
{
    /// <summary>Order List ID.</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    /// <summary>Contingency Type.</summary>
    [JsonPropertyName("contingencyType")]
    public string? ContingencyType { get; set; }

    /// <summary>List Status Type.</summary>
    [JsonPropertyName("listStatusType")]
    public string? ListStatusType { get; set; }

    /// <summary>List Order Status.</summary>
    [JsonPropertyName("listOrderStatus")]
    public string? ListOrderStatus { get; set; }

    /// <summary>List Client Order ID.</summary>
    [JsonPropertyName("listClientOrderId")]
    public string? ListClientOrderId { get; set; }

    /// <summary>Transaction Time.</summary>
    [JsonPropertyName("transactionTime")]
    public long? TransactionTime { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Orders.</summary>
    [JsonPropertyName("orders")]
    public List<CancelMarginAccountOcoOrdersResponseOrdersInner>? Orders { get; set; }

    /// <summary>Order Reports.</summary>
    [JsonPropertyName("orderReports")]
    public List<CancelMarginAccountOcoOrdersResponseOrderReportsInner>? OrderReports { get; set; }
}
