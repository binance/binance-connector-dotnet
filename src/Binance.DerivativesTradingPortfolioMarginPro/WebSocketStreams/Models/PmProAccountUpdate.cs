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

/// <summary>Pushed every 5 seconds with account asset status.</summary>
public sealed class PmProAccountUpdate
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>uniMMR level</summary>
    [JsonPropertyName("u")]
    public string? U { get; set; }

    /// <summary>Account equity in USD</summary>
    [JsonPropertyName("eq")]
    public string? Eq { get; set; }

    /// <summary>Actual equity without collateral rate in USD</summary>
    [JsonPropertyName("ae")]
    public string? Ae { get; set; }

    /// <summary>Total initial margin in USD</summary>
    [JsonPropertyName("im")]
    public string? Im { get; set; }

    /// <summary>Total maintenance margin in USD</summary>
    [JsonPropertyName("mm")]
    public string? Mm { get; set; }

    /// <summary>Total available balance in USD</summary>
    [JsonPropertyName("avb")]
    public string? Avb { get; set; }

    /// <summary>Virtual maxWithdraw amount in USD</summary>
    [JsonPropertyName("vmw")]
    public string? Vmw { get; set; }
}
