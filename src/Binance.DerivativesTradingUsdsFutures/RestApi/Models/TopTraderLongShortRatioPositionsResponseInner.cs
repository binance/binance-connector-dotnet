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

public sealed class TopTraderLongShortRatioPositionsResponseInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>long/short position ratio of top traders</summary>
    [JsonPropertyName("longShortRatio")]
    public string? LongShortRatio { get; set; }

    /// <summary>long positions ratio of top traders</summary>
    [JsonPropertyName("longAccount")]
    public string? LongAccount { get; set; }

    /// <summary>short positions ratio of top traders</summary>
    [JsonPropertyName("shortAccount")]
    public string? ShortAccount { get; set; }

    /// <summary>End time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
