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

namespace Binance.Alpha.WebSocketStreams;

public sealed class TickerStreamResponse
{
    /// <summary>eventType</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>eventTime</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>priceChange</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>priceChangePercent</summary>
    [JsonPropertyName("P")]
    public string? PUppercase { get; set; }

    /// <summary>averagePrice</summary>
    [JsonPropertyName("w")]
    public string? W { get; set; }

    /// <summary>closePrice</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>lastTradeVolume</summary>
    [JsonPropertyName("Q")]
    public string? QUppercase { get; set; }

    /// <summary>openPrice</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>highPrice</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>lowPrice</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>volume</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>quoteVolume</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>startTime</summary>
    [JsonPropertyName("O")]
    public long? OUppercase { get; set; }

    /// <summary>endTime</summary>
    [JsonPropertyName("C")]
    public long? CUppercase { get; set; }

    /// <summary>firstTradeId</summary>
    [JsonPropertyName("F")]
    public long? FUppercase { get; set; }

    /// <summary>lastTradeId</summary>
    [JsonPropertyName("L")]
    public long? LUppercase { get; set; }

    /// <summary>tradeNum</summary>
    [JsonPropertyName("n")]
    public long? N { get; set; }
}
