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

namespace Binance.Stocks.WebSocketStreams;

/// <summary>Candlestick payload.</summary>
public sealed class KlineStreamResponseK
{
    /// <summary>Open time (epoch milliseconds).</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>
    /// Close time (epoch milliseconds). For fixed intervals: openTime + duration − 1ms. For 1M: last day of
    /// month at 23:59:59.999 UTC.
    /// </summary>
    [JsonPropertyName("ct")]
    public long? Ct { get; set; }

    /// <summary>Symbol (UPPERCASE ticker).</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Interval — "5m" / "1h" / "1d" / "1w" / "1M".</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Open price.</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Close price (latest print within the interval).</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>High price.</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>Low price.</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Volume (shares), default "0".</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>Trade count; absent when upstream did not populate.</summary>
    [JsonPropertyName("n")]
    public long? N { get; set; }

    /// <summary>Candle is closed — true once the interval has ended.</summary>
    [JsonPropertyName("x")]
    public bool? X { get; set; }

    /// <summary>VWAP (volume-weighted average price); absent when upstream did not populate.</summary>
    [JsonPropertyName("vw")]
    public string? Vw { get; set; }
}
