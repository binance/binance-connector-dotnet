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

public sealed class CancelOrderResponseRateLimitsInner
{
    /// <summary>Rate limit type.</summary>
    [JsonPropertyName("rateLimitType")]
    public string? RateLimitType { get; set; }

    /// <summary>Rate limit interval.</summary>
    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    /// <summary>Rate limit interval multiplier.</summary>
    [JsonPropertyName("intervalNum")]
    public long? IntervalNum { get; set; }

    /// <summary>Maximum allowed orders for this rule.</summary>
    [JsonPropertyName("limit")]
    public long? Limit { get; set; }

    /// <summary>Total number of trades in the 24h window.</summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }
}
