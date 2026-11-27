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

public sealed class OrderTestResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    [JsonPropertyName("result")]
    public OrderTestResponseResult? Result { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<PingResponseRateLimitsInner>? RateLimits { get; set; }
}
