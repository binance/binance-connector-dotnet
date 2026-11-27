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

public sealed class MarginAccountNewOcoResponse
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

    /// <summary>will not return if no margin trade happens</summary>
    [JsonPropertyName("marginBuyBorrowAmount")]
    public string? MarginBuyBorrowAmount { get; set; }

    /// <summary>will not return if no margin trade happens</summary>
    [JsonPropertyName("marginBuyBorrowAsset")]
    public string? MarginBuyBorrowAsset { get; set; }

    /// <summary>if isolated margin</summary>
    [JsonPropertyName("isIsolated")]
    public bool? IsIsolated { get; set; }

    /// <summary>orders list.</summary>
    [JsonPropertyName("orders")]
    public List<MarginAccountNewOcoResponseOrdersInner>? Orders { get; set; }

    [JsonPropertyName("orderReports")]
    public List<MarginAccountNewOcoResponseOrderReportsInner>? OrderReports { get; set; }
}
