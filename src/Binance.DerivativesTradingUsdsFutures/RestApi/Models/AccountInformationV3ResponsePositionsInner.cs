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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

/// <summary>positions of all symbols user had position/ open orders are returned</summary>
public sealed class AccountInformationV3ResponsePositionsInner
{
    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Position side.</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Position quantity.</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>Unrealized profit.</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    /// <summary>Isolated margin.</summary>
    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    /// <summary>Position notional value.</summary>
    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    /// <summary>Isolated wallet balance.</summary>
    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    /// <summary>Initial margin requirement.</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>Maintenance margin requirement.</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>Last update time in milliseconds.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
