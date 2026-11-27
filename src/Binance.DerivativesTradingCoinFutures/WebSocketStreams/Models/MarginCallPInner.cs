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

public sealed class MarginCallPInner
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Position Side</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>Position Amount</summary>
    [JsonPropertyName("pa")]
    public string? Pa { get; set; }

    /// <summary>Margin Type</summary>
    [JsonPropertyName("mt")]
    public string? Mt { get; set; }

    /// <summary>Isolated Wallet (if isolated position)</summary>
    [JsonPropertyName("iw")]
    public string? Iw { get; set; }

    /// <summary>Mark Price</summary>
    [JsonPropertyName("mp")]
    public string? Mp { get; set; }

    /// <summary>Unrealized PnL</summary>
    [JsonPropertyName("up")]
    public string? Up { get; set; }

    /// <summary>Maintenance Margin Required</summary>
    [JsonPropertyName("mm")]
    public string? Mm { get; set; }
}
