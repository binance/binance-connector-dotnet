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

/// <summary>
/// If both cancel and placement succeed, you get the following response with "status": 200:
/// </summary>
public sealed class OrderCancelReplaceResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    [JsonPropertyName("result")]
    public OrderCancelReplaceResponseResult? Result { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<PingResponseRateLimitsInner>? RateLimits { get; set; }
}
