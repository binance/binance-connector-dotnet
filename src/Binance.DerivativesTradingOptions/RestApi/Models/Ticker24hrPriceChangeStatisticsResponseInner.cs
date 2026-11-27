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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class Ticker24hrPriceChangeStatisticsResponseInner
{
    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>24-hour price change</summary>
    [JsonPropertyName("priceChange")]
    public string? PriceChange { get; set; }

    /// <summary>24-hour percent price change</summary>
    [JsonPropertyName("priceChangePercent")]
    public string? PriceChangePercent { get; set; }

    /// <summary>Last trade price</summary>
    [JsonPropertyName("lastPrice")]
    public string? LastPrice { get; set; }

    /// <summary>Last trade amount</summary>
    [JsonPropertyName("lastQty")]
    public string? LastQty { get; set; }

    /// <summary>24-hour open price</summary>
    [JsonPropertyName("open")]
    public string? Open { get; set; }

    /// <summary>24-hour high</summary>
    [JsonPropertyName("high")]
    public string? High { get; set; }

    /// <summary>24-hour low</summary>
    [JsonPropertyName("low")]
    public string? Low { get; set; }

    /// <summary>Trading volume(contracts)</summary>
    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    /// <summary>Trade amount(in quote asset)</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>The best buy price</summary>
    [JsonPropertyName("bidPrice")]
    public string? BidPrice { get; set; }

    /// <summary>The best sell price</summary>
    [JsonPropertyName("askPrice")]
    public string? AskPrice { get; set; }

    /// <summary>Time the first trade occurred within the last 24 hours</summary>
    [JsonPropertyName("openTime")]
    public long? OpenTime { get; set; }

    /// <summary>Time the last trade occurred within the last 24 hours</summary>
    [JsonPropertyName("closeTime")]
    public long? CloseTime { get; set; }

    /// <summary>First trade ID</summary>
    [JsonPropertyName("firstTradeId")]
    public long? FirstTradeId { get; set; }

    /// <summary>Number of trades</summary>
    [JsonPropertyName("tradeCount")]
    public long? TradeCount { get; set; }

    /// <summary>Strike price</summary>
    [JsonPropertyName("strikePrice")]
    public string? StrikePrice { get; set; }

    /// <summary>
    /// return estimated settlement price one hour before exercise, return index price at other times
    /// </summary>
    [JsonPropertyName("exercisePrice")]
    public string? ExercisePrice { get; set; }
}
