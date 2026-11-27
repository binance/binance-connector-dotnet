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

public sealed class MarginCall
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Account Alias</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Cross Wallet Balance. Only pushed with crossed position margin call</summary>
    [JsonPropertyName("cw")]
    public string? Cw { get; set; }

    /// <summary>Position(s) of Margin Call</summary>
    [JsonPropertyName("p")]
    public List<MarginCallPInner>? P { get; set; }
}
