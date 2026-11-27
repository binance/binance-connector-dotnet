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

public sealed class CancelEquityOrderResponse
{
    /// <summary>Echoes the requested order id.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Acknowledgement code: S = cancel accepted by upstream, F = cancel failed. Not an order lifecycle
    /// status — use /order/detail for lifecycle poll.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
