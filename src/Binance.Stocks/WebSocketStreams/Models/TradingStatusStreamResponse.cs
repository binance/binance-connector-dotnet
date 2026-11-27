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

public sealed class TradingStatusStreamResponse
{
    /// <summary>Event type, always "tradingStatus".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Symbol (UPPERCASE ticker), e.g. "AAPL".</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Internal asset code EQ_{symbol}; reference only.</summary>
    [JsonPropertyName("assetCode")]
    public string? AssetCode { get; set; }

    /// <summary>Trading status.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>Reason code.</summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>Status-effective time (epoch milliseconds UTC). May be in the future.</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Tape designation: C = CTA (NYSE / AMEX), N = UTP (Nasdaq).</summary>
    [JsonPropertyName("z")]
    public string? Z { get; set; }

    /// <summary>Tradability after the status change: BUY_SELL / BUY / SELL / NONE.</summary>
    [JsonPropertyName("tradability")]
    public string? Tradability { get; set; }
}
