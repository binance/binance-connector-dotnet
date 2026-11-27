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
public sealed class ContinuousContractKlineCandlestickStreamsResponseK
{
    /// <summary>Kline start time</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>transactionTime</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>interval</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>First update ID</summary>
    [JsonPropertyName("f")]
    public long? F { get; set; }

    /// <summary>Last update ID</summary>
    [JsonPropertyName("L")]
    public long? LUppercase { get; set; }

    /// <summary>openPrice</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>closePrice</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>highPrice</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>lowPrice</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>volume</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>tradeNum</summary>
    [JsonPropertyName("n")]
    public long? N { get; set; }

    /// <summary>Is this kline closed?</summary>
    [JsonPropertyName("x")]
    public bool? X { get; set; }

    /// <summary>quoteVolume</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>Taker buy volume</summary>
    [JsonPropertyName("V")]
    public string? VUppercase { get; set; }

    /// <summary>lastTradeVolume</summary>
    [JsonPropertyName("Q")]
    public string? QUppercase { get; set; }

    /// <summary>Best bid qty</summary>
    [JsonPropertyName("B")]
    public string? BUppercase { get; set; }
}
