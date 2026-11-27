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

namespace Binance.StockOptions.RestApi;

public sealed class CancelOptionOrderResponse
{
    /// <summary>Echoes the order ID in the request.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Always S, meaning the cancel request was accepted upstream. A failed cancellation (e.g. order not
    /// found or already filled) is returned as an error code (486xxx).
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
