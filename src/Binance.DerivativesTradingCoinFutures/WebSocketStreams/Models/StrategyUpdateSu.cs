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

public sealed class StrategyUpdateSu
{
    /// <summary>Strategy ID</summary>
    [JsonPropertyName("si")]
    public long? Si { get; set; }

    /// <summary>Strategy Type</summary>
    [JsonPropertyName("st")]
    public string? St { get; set; }

    /// <summary>Strategy Status</summary>
    [JsonPropertyName("ss")]
    public string? Ss { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Update Time</summary>
    [JsonPropertyName("ut")]
    public long? Ut { get; set; }

    /// <summary>opCode</summary>
    [JsonPropertyName("c")]
    public long? C { get; set; }
}
