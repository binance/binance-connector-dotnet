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

public sealed class PositionInformationV3ResponseInner
{
    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>position amount, positive for long, negative for short</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>entry price</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>break-even price</summary>
    [JsonPropertyName("breakEvenPrice")]
    public string? BreakEvenPrice { get; set; }

    /// <summary>current mark price</summary>
    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>unrealized profit</summary>
    [JsonPropertyName("unRealizedProfit")]
    public string? UnRealizedProfit { get; set; }

    /// <summary>liquidation price</summary>
    [JsonPropertyName("liquidationPrice")]
    public string? LiquidationPrice { get; set; }

    /// <summary>isolated margin</summary>
    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    /// <summary>notional value of position</summary>
    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    /// <summary>margin asset</summary>
    [JsonPropertyName("marginAsset")]
    public string? MarginAsset { get; set; }

    /// <summary>isolated wallet (if isolated position)</summary>
    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    /// <summary>initial margin required with current mark price</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>maintenance margin required</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>initial margin required for positions with current mark price</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>initial margin required for open orders with current mark price</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    /// <summary>auto-deleverage ranking</summary>
    [JsonPropertyName("adl")]
    public long? Adl { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("bidNotional")]
    public string? BidNotional { get; set; }

    /// <summary>ignore</summary>
    [JsonPropertyName("askNotional")]
    public string? AskNotional { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
