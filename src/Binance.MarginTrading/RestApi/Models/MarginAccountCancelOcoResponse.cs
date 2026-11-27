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

public sealed class MarginAccountCancelOcoResponse
{
    /// <summary>order List Id.</summary>
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    /// <summary>contingency Type.</summary>
    [JsonPropertyName("contingencyType")]
    public string? ContingencyType { get; set; }

    /// <summary>list Status Type.</summary>
    [JsonPropertyName("listStatusType")]
    public string? ListStatusType { get; set; }

    /// <summary>list Order Status.</summary>
    [JsonPropertyName("listOrderStatus")]
    public string? ListOrderStatus { get; set; }

    /// <summary>list Client Order Id.</summary>
    [JsonPropertyName("listClientOrderId")]
    public string? ListClientOrderId { get; set; }

    /// <summary>transaction Time.</summary>
    [JsonPropertyName("transactionTime")]
    public long? TransactionTime { get; set; }

    /// <summary>symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>if isolated margin</summary>
    [JsonPropertyName("isIsolated")]
    public bool? IsIsolated { get; set; }

    /// <summary>orders list.</summary>
    [JsonPropertyName("orders")]
    public List<MarginAccountCancelOcoResponseOrdersInner>? Orders { get; set; }

    /// <summary>order Reports.</summary>
    [JsonPropertyName("orderReports")]
    public List<MarginAccountCancelOcoResponseOrderReportsInner>? OrderReports { get; set; }
}
