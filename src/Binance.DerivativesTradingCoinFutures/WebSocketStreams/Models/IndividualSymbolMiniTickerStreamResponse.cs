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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

public sealed class IndividualSymbolMiniTickerStreamResponse
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>Close price</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>Open price</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>High price</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }

    /// <summary>Low price</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Total traded volume</summary>
    [JsonPropertyName("v")]
    public string? V { get; set; }

    /// <summary>Total traded base asset volume</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
