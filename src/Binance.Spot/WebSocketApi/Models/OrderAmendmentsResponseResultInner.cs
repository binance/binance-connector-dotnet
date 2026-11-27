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

public sealed class OrderAmendmentsResponseResultInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("executionId")]
    public long? ExecutionId { get; set; }

    [JsonPropertyName("origClientOrderId")]
    public string? OrigClientOrderId { get; set; }

    [JsonPropertyName("newClientOrderId")]
    public string? NewClientOrderId { get; set; }

    [JsonPropertyName("origQty")]
    public string? OrigQty { get; set; }

    [JsonPropertyName("newQty")]
    public string? NewQty { get; set; }

    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
