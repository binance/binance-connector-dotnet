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

/// <summary>positions of all symbols in the market are returned</summary>
public sealed class AccountInformationV2ResponsePositionsInner
{
    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Initial margin requirement.</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>Maintenance margin requirement.</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>Unrealized profit.</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    /// <summary>Initial margin required for positions.</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>Initial margin required for open orders.</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    /// <summary>Current initial leverage.</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>Whether the position uses isolated margin mode.</summary>
    [JsonPropertyName("isolated")]
    public bool? Isolated { get; set; }

    /// <summary>Average entry price.</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>Maximum available notional under current leverage.</summary>
    [JsonPropertyName("maxNotional")]
    public string? MaxNotional { get; set; }

    /// <summary>Bid notional (ignore).</summary>
    [JsonPropertyName("bidNotional")]
    public string? BidNotional { get; set; }

    /// <summary>Ask notional (ignore).</summary>
    [JsonPropertyName("askNotional")]
    public string? AskNotional { get; set; }

    /// <summary>Position side.</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Position quantity.</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>Last update time in milliseconds.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
