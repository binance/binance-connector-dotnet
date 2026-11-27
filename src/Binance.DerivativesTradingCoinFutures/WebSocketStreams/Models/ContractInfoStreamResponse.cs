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

public sealed class ContractInfoStreamResponse
{
    /// <summary>Event Type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>Contract type</summary>
    [JsonPropertyName("ct")]
    public string? Ct { get; set; }

    /// <summary>Delivery date time</summary>
    [JsonPropertyName("dt")]
    public long? Dt { get; set; }

    /// <summary>onboard date time</summary>
    [JsonPropertyName("ot")]
    public long? Ot { get; set; }

    /// <summary>Contract status</summary>
    [JsonPropertyName("cs")]
    public string? Cs { get; set; }

    /// <summary>Bracket list.</summary>
    [JsonPropertyName("bks")]
    public List<ContractInfoStreamResponseBksInner>? Bks { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
