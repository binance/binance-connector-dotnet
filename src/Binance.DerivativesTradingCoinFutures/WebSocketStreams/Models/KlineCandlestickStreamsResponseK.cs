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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

/// <summary>Kline payload</summary>
public sealed class KlineCandlestickStreamsResponseK
{
    /// <summary>Kline start time</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Kline close time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Interval</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>First trade ID</summary>
    [JsonPropertyName("f")]
    public long? F { get; set; }

    /// <summary>Last trade ID</summary>
    [JsonPropertyName("L")]
    public long? LUppercase { get; set; }

    /// <summary>Open price</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Close price</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>High price</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>Low price</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>volume</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>Number of trades</summary>
    [JsonPropertyName("n")]
    public long? N { get; set; }

    /// <summary>Is this kline closed?</summary>
    [JsonPropertyName("x")]
    public bool? X { get; set; }

    /// <summary>Base asset volume</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Taker buy volume</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>Taker buy base asset volume</summary>
    [JsonPropertyName("Q")]
    public string? QUppercase { get; set; }

    /// <summary>Ignore</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }
}
