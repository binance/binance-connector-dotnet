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

public sealed class LongShortRatioResponseInner
{
    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Long/short ratio.</summary>
    [JsonPropertyName("longShortRatio")]
    public string? LongShortRatio { get; set; }

    /// <summary>64.42%</summary>
    [JsonPropertyName("longAccount")]
    public string? LongAccount { get; set; }

    /// <summary>35.58%</summary>
    [JsonPropertyName("shortAccount")]
    public string? ShortAccount { get; set; }

    /// <summary>End time of the period, in milliseconds.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}
