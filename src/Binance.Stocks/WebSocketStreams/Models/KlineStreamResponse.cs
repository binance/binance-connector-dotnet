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

public sealed class KlineStreamResponse
{
    /// <summary>Event type, always "kline".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>
    /// Event time (epoch milliseconds); server-side system time when the message is pushed.
    /// </summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol (UPPERCASE ticker).</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    [JsonPropertyName("k")]
    public KlineStreamResponseK? K { get; set; }
}
