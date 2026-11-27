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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

public sealed class NewOrderResponse
{
    /// <summary>positionId</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("status")]
    public long? Status { get; set; }

    [JsonPropertyName("result")]
    public NewOrderResponseResult? Result { get; set; }

    /// <summary>Rate limit definitions.</summary>
    [JsonPropertyName("rateLimits")]
    public List<CancelOrderResponseRateLimitsInner>? RateLimits { get; set; }
}
