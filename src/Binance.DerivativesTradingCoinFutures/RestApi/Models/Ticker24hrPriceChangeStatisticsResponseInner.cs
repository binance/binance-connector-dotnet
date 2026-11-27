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

public sealed class Ticker24hrPriceChangeStatisticsResponseInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Absolute price change in the 24h window.</summary>
    [JsonPropertyName("priceChange")]
    public string? PriceChange { get; set; }

    /// <summary>Percentage price change in the 24h window.</summary>
    [JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent { get; set; }

    /// <summary>Weighted average price in the 24h window.</summary>
    [JsonPropertyName("weightedAvgPrice")]
    public string? WeightedAvgPrice { get; set; }

    /// <summary>Latest traded price.</summary>
    [JsonPropertyName("lastPrice")]
    public string? LastPrice { get; set; }

    /// <summary>Quantity of the latest trade.</summary>
    [JsonPropertyName("lastQty")]
    public string? LastQty { get; set; }

    /// <summary>Opening price of the 24h window.</summary>
    [JsonPropertyName("openPrice")]
    public string? OpenPrice { get; set; }

    /// <summary>Highest price in the 24h window.</summary>
    [JsonPropertyName("highPrice")]
    public string? HighPrice { get; set; }

    /// <summary>Lowest price in the 24h window.</summary>
    [JsonPropertyName("lowPrice")]
    public string? LowPrice { get; set; }

    /// <summary>Base asset volume in the 24h window.</summary>
    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    /// <summary>Base asset volume.</summary>
    [JsonPropertyName("baseVolume")]
    public string? BaseVolume { get; set; }

    /// <summary>Start time of the 24h window (milliseconds).</summary>
    [JsonPropertyName("openTime")]
    public long? OpenTime { get; set; }

    /// <summary>End time of the 24h window (milliseconds).</summary>
    [JsonPropertyName("closeTime")]
    public long? CloseTime { get; set; }

    /// <summary>First tradeId</summary>
    [JsonPropertyName("firstId")]
    public long? FirstId { get; set; }

    /// <summary>Last tradeId</summary>
    [JsonPropertyName("lastId")]
    public long? LastId { get; set; }

    /// <summary>Total number of trades in the 24h window.</summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }
}
