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

namespace Binance.Stocks.RestApi;

public sealed class PlaceEquityOrderResponse
{
    /// <summary>
    /// Acknowledgement code: S = accepted, F = failed. Not an order lifecycle status — to poll lifecycle,
    /// call /order/detail or /order/history.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Order id (UUID).</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>Echoes the supplied or server-generated client order id.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }
}
