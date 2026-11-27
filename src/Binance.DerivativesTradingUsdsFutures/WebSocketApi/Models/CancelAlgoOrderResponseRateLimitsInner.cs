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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class CancelAlgoOrderResponseRateLimitsInner
{
    [JsonPropertyName("rateLimitType")]
    public string? RateLimitType { get; set; }

    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("intervalNum")]
    public long? IntervalNum { get; set; }

    [JsonPropertyName("limit")]
    public long? Limit { get; set; }

    [JsonPropertyName("count")]
    public long? Count { get; set; }
}
