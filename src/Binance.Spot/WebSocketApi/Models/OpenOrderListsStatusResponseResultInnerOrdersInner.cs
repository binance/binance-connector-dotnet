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

public sealed class OpenOrderListsStatusResponseResultInnerOrdersInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }
}
