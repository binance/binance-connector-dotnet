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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

/// <summary>k</summary>
public sealed class KlineCandlestickStreamsResponseK
{
    /// <summary>kline start time</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>kline end time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Option trading symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>candle period</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>first trade ID</summary>
    [JsonPropertyName("f")]
    public long? F { get; set; }

    /// <summary>last trade ID</summary>
    [JsonPropertyName("L")]
    public long? LUppercase { get; set; }

    /// <summary>open</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>close</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>high</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>low</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>volume(in contracts)</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>number of trades</summary>
    [JsonPropertyName("n")]
    public long? N { get; set; }

    /// <summary>current candle has been completed Y/N</summary>
    [JsonPropertyName("x")]
    public bool? X { get; set; }

    /// <summary>completed trade amount (in quote asset)</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>taker completed trade volume (in contracts)</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>taker trade amount(in quote asset)</summary>
    [JsonPropertyName("Q")]
    public string? QUppercase { get; set; }
}
