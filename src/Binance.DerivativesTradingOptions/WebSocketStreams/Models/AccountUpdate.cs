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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class AccountUpdate
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Transaction Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Account equity in USDT</summary>
    [JsonPropertyName("eq")]
    public string? Eq { get; set; }

    /// <summary>Account adjusted equity in USDT</summary>
    [JsonPropertyName("aeq")]
    public string? Aeq { get; set; }

    /// <summary>Account wallet balance in USDT</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Position value</summary>
    [JsonPropertyName("m")]
    public string? M { get; set; }

    /// <summary>Unrealized PnL</summary>
    [JsonPropertyName("u")]
    public string? U { get; set; }

    /// <summary>Initial margin in USDT</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Maintenance margin in USDT</summary>
    [JsonPropertyName("M")]
    public string? MUppercase { get; set; }
}
