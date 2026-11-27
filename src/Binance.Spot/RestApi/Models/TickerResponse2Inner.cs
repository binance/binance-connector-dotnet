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

namespace Binance.Spot.RestApi;

public sealed class TickerResponse2Inner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Absolute price change</summary>
    [JsonPropertyName("priceChange")]
    public string? PriceChange { get; set; }

    /// <summary>Relative price change in percent</summary>
    [JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent { get; set; }

    /// <summary>QuoteVolume / Volume</summary>
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

    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    /// <summary>Sum of (price * volume) for all trades</summary>
    [JsonPropertyName("quoteVolume")]
    public string? QuoteVolume { get; set; }

    /// <summary>Open time for ticker window</summary>
    [JsonPropertyName("openTime")]
    public long? OpenTime { get; set; }

    /// <summary>Close time for ticker window</summary>
    [JsonPropertyName("closeTime")]
    public long? CloseTime { get; set; }

    /// <summary>Trade IDs</summary>
    [JsonPropertyName("firstId")]
    public long? FirstId { get; set; }

    [JsonPropertyName("lastId")]
    public long? LastId { get; set; }

    /// <summary>Number of trades in the interval</summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }
}
