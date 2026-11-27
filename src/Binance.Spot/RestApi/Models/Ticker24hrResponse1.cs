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

public sealed class Ticker24hrResponse1
{
    /// <summary>Symbol Name</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("priceChange")]
    public string? PriceChange { get; set; }

    [JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent { get; set; }

    [JsonPropertyName("weightedAvgPrice")]
    public string? WeightedAvgPrice { get; set; }

    [JsonPropertyName("prevClosePrice")]
    public string? PrevClosePrice { get; set; }

    /// <summary>Closing price of the interval</summary>
    [JsonPropertyName("lastPrice")]
    public string? LastPrice { get; set; }

    [JsonPropertyName("lastQty")]
    public string? LastQty { get; set; }

    [JsonPropertyName("bidPrice")]
    public string? BidPrice { get; set; }

    [JsonPropertyName("bidQty")]
    public string? BidQty { get; set; }

    [JsonPropertyName("askPrice")]
    public string? AskPrice { get; set; }

    [JsonPropertyName("askQty")]
    public string? AskQty { get; set; }

    /// <summary>Opening price of the Interval</summary>
    [JsonPropertyName("openPrice")]
    public string? OpenPrice { get; set; }

    /// <summary>Highest price in the interval</summary>
    [JsonPropertyName("highPrice")]
    public string? HighPrice { get; set; }

    /// <summary>Lowest price in the interval</summary>
    [JsonPropertyName("lowPrice")]
    public string? LowPrice { get; set; }

    /// <summary>Total trade volume (in base asset)</summary>
    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    /// <summary>Total trade volume (in quote asset)</summary>
    [JsonPropertyName("quoteVolume")]
    public string? QuoteVolume { get; set; }

    /// <summary>Start of the ticker interval</summary>
    [JsonPropertyName("openTime")]
    public long? OpenTime { get; set; }

    /// <summary>End of the ticker interval</summary>
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
