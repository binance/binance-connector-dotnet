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

public sealed class Ticker24hrPriceChangeStatisticsResponse2Inner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Price Change.</summary>
    [JsonPropertyName("priceChange")]
    public string? PriceChange { get; set; }

    /// <summary>Price Change Percent.</summary>
    [JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent { get; set; }

    /// <summary>Weighted Avg Price.</summary>
    [JsonPropertyName("weightedAvgPrice")]
    public string? WeightedAvgPrice { get; set; }

    /// <summary>Last Price.</summary>
    [JsonPropertyName("lastPrice")]
    public string? LastPrice { get; set; }

    /// <summary>Last Qty.</summary>
    [JsonPropertyName("lastQty")]
    public string? LastQty { get; set; }

    /// <summary>Open Price.</summary>
    [JsonPropertyName("openPrice")]
    public string? OpenPrice { get; set; }

    /// <summary>High Price.</summary>
    [JsonPropertyName("highPrice")]
    public string? HighPrice { get; set; }

    /// <summary>Low Price.</summary>
    [JsonPropertyName("lowPrice")]
    public string? LowPrice { get; set; }

    /// <summary>Volume.</summary>
    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    /// <summary>Quote Volume.</summary>
    [JsonPropertyName("quoteVolume")]
    public string? QuoteVolume { get; set; }

    /// <summary>Open Time.</summary>
    [JsonPropertyName("openTime")]
    public long? OpenTime { get; set; }

    /// <summary>Close Time.</summary>
    [JsonPropertyName("closeTime")]
    public long? CloseTime { get; set; }

    /// <summary>First tradeId</summary>
    [JsonPropertyName("firstId")]
    public long? FirstId { get; set; }

    /// <summary>Last tradeId</summary>
    [JsonPropertyName("lastId")]
    public long? LastId { get; set; }

    /// <summary>Trade count</summary>
    [JsonPropertyName("count")]
    public long? Count { get; set; }
}
