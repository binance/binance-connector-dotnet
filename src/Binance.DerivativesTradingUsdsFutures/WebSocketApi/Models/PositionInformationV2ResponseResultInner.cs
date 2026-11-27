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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class PositionInformationV2ResponseResultInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Position Side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    [JsonPropertyName("breakEvenPrice")]
    public string? BreakEvenPrice { get; set; }

    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>Unrealized Profit</summary>
    [JsonPropertyName("unRealizedProfit")]
    public string? UnRealizedProfit { get; set; }

    [JsonPropertyName("liquidationPrice")]
    public string? LiquidationPrice { get; set; }

    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    [JsonPropertyName("marginAsset")]
    public string? MarginAsset { get; set; }

    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    /// <summary>Initial Margin</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>Maintainance Margin</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>Position Initial Margin</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>Open Order Initial Margin</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    [JsonPropertyName("adl")]
    public long? Adl { get; set; }

    [JsonPropertyName("bidNotional")]
    public string? BidNotional { get; set; }

    [JsonPropertyName("askNotional")]
    public string? AskNotional { get; set; }

    /// <summary>Update Time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
