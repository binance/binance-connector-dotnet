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

namespace Binance.Spot.WebSocketApi;

public sealed class OrderListPlaceOtocoResponseResult
{
    [JsonPropertyName("orderListId")]
    public long? OrderListId { get; set; }

    [JsonPropertyName("contingencyType")]
    public string? ContingencyType { get; set; }

    [JsonPropertyName("listStatusType")]
    public string? ListStatusType { get; set; }

    [JsonPropertyName("listOrderStatus")]
    public string? ListOrderStatus { get; set; }

    [JsonPropertyName("listClientOrderId")]
    public string? ListClientOrderId { get; set; }

    [JsonPropertyName("transactionTime")]
    public long? TransactionTime { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("orders")]
    public List<OrderListPlaceOtocoResponseResultOrdersInner>? Orders { get; set; }

    [JsonPropertyName("orderReports")]
    public List<OrderListPlaceOtocoResponseResultOrderReportsInner>? OrderReports { get; set; }
}
