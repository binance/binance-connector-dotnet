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

/// <summary>If more than one symbol is requested, response returns an array:</summary>
public sealed class TickerResponse2
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    [JsonPropertyName("result")]
    public List<TickerResponse2ResultInner>? Result { get; set; }

    [JsonPropertyName("rateLimits")]
    public List<TickerResponse2RateLimitsInner>? RateLimits { get; set; }
}
