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

namespace Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

public sealed class Risklevelchange
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>uniMMR level</summary>
    [JsonPropertyName("u")]
    public string? U { get; set; }

    /// <summary>Risk level: NORMAL, MARGIN_CALL, REDUCE_ONLY, FORCE_LIQUIDATION</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Account equity in USD value</summary>
    [JsonPropertyName("eq")]
    public string? Eq { get; set; }

    /// <summary>Actual equity without collateral rate in USD value</summary>
    [JsonPropertyName("ae")]
    public string? Ae { get; set; }

    /// <summary>Total maintenance margin in USD value</summary>
    [JsonPropertyName("m")]
    public string? M { get; set; }
}
