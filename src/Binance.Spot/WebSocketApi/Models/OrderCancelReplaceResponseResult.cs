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

public sealed class OrderCancelReplaceResponseResult
{
    [JsonPropertyName("cancelResult")]
    public string? CancelResult { get; set; }

    [JsonPropertyName("newOrderResult")]
    public string? NewOrderResult { get; set; }

    [JsonPropertyName("cancelResponse")]
    public OrderCancelReplaceResponseResultCancelResponse? CancelResponse { get; set; }

    [JsonPropertyName("newOrderResponse")]
    public OrderCancelReplaceResponseResultNewOrderResponse? NewOrderResponse { get; set; }
}
