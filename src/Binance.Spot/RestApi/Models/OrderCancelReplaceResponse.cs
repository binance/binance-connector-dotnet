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

/// <summary>
/// Both the cancel and the new order placement succeeded, and the account has not exceeded its unfilled
/// order count:
/// </summary>
public sealed class OrderCancelReplaceResponse
{
    [JsonPropertyName("cancelResult")]
    public string? CancelResult { get; set; }

    [JsonPropertyName("newOrderResult")]
    public string? NewOrderResult { get; set; }

    [JsonPropertyName("cancelResponse")]
    public OrderCancelReplaceResponseCancelResponse? CancelResponse { get; set; }

    [JsonPropertyName("newOrderResponse")]
    public OrderCancelReplaceResponseNewOrderResponse? NewOrderResponse { get; set; }
}
