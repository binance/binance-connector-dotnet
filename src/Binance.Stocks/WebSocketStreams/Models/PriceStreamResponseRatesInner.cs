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

public sealed class PriceStreamResponseRatesInner
{
    /// <summary>Symbol (UPPERCASE ticker), e.g. "AAPL".</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>
    /// Internal asset code, EQ_{symbol}. Reference only; do not use as a trading identifier.
    /// </summary>
    [JsonPropertyName("ac")]
    public string? Ac { get; set; }

    /// <summary>Latest price, trailing-zero stripped.</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Price time (epoch milliseconds UTC); may be null.</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Previous trading day's close price; absent when unknown.</summary>
    [JsonPropertyName("pc")]
    public string? Pc { get; set; }

    /// <summary>Today's close price; absent before After-Hours.</summary>
    [JsonPropertyName("tc")]
    public string? Tc { get; set; }

    /// <summary>
    /// Final close price of the most recent completed RTH trading day. Rolls forward only once the next
    /// trading day enters Post-Market and the 1-minute kline for the minute before that day's RTH close is
    /// available; while unavailable, the previous lrc/prc pair is retained.
    /// </summary>
    [JsonPropertyName("lrc")]
    public string? Lrc { get; set; }

    /// <summary>
    /// Final close price of the trading day before the lrc trading day. null when the symbol has only one
    /// completed RTH trading day (e.g. a new IPO).
    /// </summary>
    [JsonPropertyName("prc")]
    public string? Prc { get; set; }

    /// <summary>
    /// Per-symbol market phase: C Closed, ON Overnight, PRE Pre-Market, O Market Open, POST Post-Market.
    /// </summary>
    [JsonPropertyName("mp")]
    public string? Mp { get; set; }
}
