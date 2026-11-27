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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class QueryUserRateLimitResponseInner
{
    /// <summary>Rate Limit Type.</summary>
    [JsonPropertyName("rateLimitType")]
    public string? RateLimitType { get; set; }

    /// <summary>Interval.</summary>
    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    /// <summary>Interval Num.</summary>
    [JsonPropertyName("intervalNum")]
    public long? IntervalNum { get; set; }

    /// <summary>Limit.</summary>
    [JsonPropertyName("limit")]
    public long? Limit { get; set; }
}
