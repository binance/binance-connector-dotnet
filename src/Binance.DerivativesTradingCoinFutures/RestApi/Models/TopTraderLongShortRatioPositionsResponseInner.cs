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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class TopTraderLongShortRatioPositionsResponseInner
{
    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Long/short ratio.</summary>
    [JsonPropertyName("longShortRatio")]
    public string? LongShortRatio { get; set; }

    /// <summary>64.42%</summary>
    [JsonPropertyName("longPosition")]
    public string? LongPosition { get; set; }

    /// <summary>44.04%</summary>
    [JsonPropertyName("shortPosition")]
    public string? ShortPosition { get; set; }

    /// <summary>End time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
