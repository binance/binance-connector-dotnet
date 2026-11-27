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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

public sealed class AccountUpdateAPInner
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Position Amount</summary>
    [JsonPropertyName("pa")]
    public string? Pa { get; set; }

    /// <summary>Entry Price</summary>
    [JsonPropertyName("ep")]
    public string? Ep { get; set; }

    /// <summary>Breakeven Price</summary>
    [JsonPropertyName("bep")]
    public string? Bep { get; set; }

    /// <summary>(Pre-fee) Accumulated Realized</summary>
    [JsonPropertyName("cr")]
    public string? Cr { get; set; }

    /// <summary>Unrealized PnL</summary>
    [JsonPropertyName("up")]
    public string? Up { get; set; }

    /// <summary>Margin Type</summary>
    [JsonPropertyName("mt")]
    public string? Mt { get; set; }

    /// <summary>Isolated Wallet (if isolated position)</summary>
    [JsonPropertyName("iw")]
    public string? Iw { get; set; }

    /// <summary>Position Side</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }
}
