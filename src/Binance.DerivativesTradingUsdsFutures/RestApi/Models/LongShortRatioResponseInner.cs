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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class LongShortRatioResponseInner
{
    /// <summary>long/short account num ratio of all traders</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>long account num ratio of all traders</summary>
    [JsonPropertyName("longShortRatio")]
    public string? LongShortRatio { get; set; }

    /// <summary>short account num ratio of all traders</summary>
    [JsonPropertyName("longAccount")]
    public string? LongAccount { get; set; }

    /// <summary>Short Account.</summary>
    [JsonPropertyName("shortAccount")]
    public string? ShortAccount { get; set; }

    /// <summary>End time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
