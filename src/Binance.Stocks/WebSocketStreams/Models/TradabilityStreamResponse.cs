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

public sealed class TradabilityStreamResponse
{
    /// <summary>Event type, always "tradability".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Symbol (UPPERCASE ticker).</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Internal asset code EQ_{symbol}; reference only. May be null for symbols not yet in the symbol
    /// dictionary.
    /// </summary>
    [JsonPropertyName("assetCode")]
    public string? AssetCode { get; set; }

    /// <summary>
    /// The new tradability value. OFFMARKET and DELISTING are protected states — trading-status events will
    /// not transition a symbol out of them.
    /// </summary>
    [JsonPropertyName("tradability")]
    public string? Tradability { get; set; }

    /// <summary>Push time (epoch milliseconds UTC).</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }
}
