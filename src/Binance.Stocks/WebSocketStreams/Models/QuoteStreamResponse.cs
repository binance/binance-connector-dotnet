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

public sealed class QuoteStreamResponse
{
    /// <summary>Event type, always "quote".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time — epoch milliseconds when the server pushed the message.</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol (UPPERCASE ticker), e.g. "AAPL".</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Best bid price.</summary>
    [JsonPropertyName("bp")]
    public string? Bp { get; set; }

    /// <summary>Best ask price.</summary>
    [JsonPropertyName("ap")]
    public string? Ap { get; set; }

    /// <summary>Best bid size (shares).</summary>
    [JsonPropertyName("bs")]
    public long? Bs { get; set; }

    /// <summary>Best ask size (shares).</summary>
    [JsonPropertyName("as")]
    public long? As { get; set; }

    /// <summary>Source quote timestamp (epoch milliseconds); may be null.</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }
}
