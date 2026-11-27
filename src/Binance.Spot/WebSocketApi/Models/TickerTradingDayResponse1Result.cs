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

namespace Binance.Spot.WebSocketApi;

public sealed class TickerTradingDayResponse1Result
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Absolute price change</summary>
    [JsonPropertyName("priceChange")]
    public string? PriceChange { get; set; }

    /// <summary>Relative price change in percent</summary>
    [JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent { get; set; }

    /// <summary>quoteVolume / volume</summary>
    [JsonPropertyName("weightedAvgPrice")]
    public string? WeightedAvgPrice { get; set; }

    [JsonPropertyName("openPrice")]
    public string? OpenPrice { get; set; }

    [JsonPropertyName("highPrice")]
    public string? HighPrice { get; set; }

    [JsonPropertyName("lowPrice")]
    public string? LowPrice { get; set; }

    [JsonPropertyName("lastPrice")]
    public string? LastPrice { get; set; }

    /// <summary>Volume in base asset</summary>
    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    /// <summary>Volume in quote asset</summary>
    [JsonPropertyName("quoteVolume")]
    public string? QuoteVolume { get; set; }

    [JsonPropertyName("openTime")]
    public long? OpenTime { get; set; }

    [JsonPropertyName("closeTime")]
    public long? CloseTime { get; set; }

    /// <summary>Trade ID of the first trade in the interval</summary>
    [JsonPropertyName("firstId")]
    public long? FirstId { get; set; }

    /// <summary>Trade ID of the last trade in the interval</summary>
    [JsonPropertyName("lastId")]
    public long? LastId { get; set; }

    /// <summary>Number of trades in the interval</summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }
}
