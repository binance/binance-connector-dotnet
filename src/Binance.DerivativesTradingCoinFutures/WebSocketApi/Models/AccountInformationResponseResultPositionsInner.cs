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

namespace Binance.DerivativesTradingCoinFutures.WebSocketApi;

public sealed class AccountInformationResponseResultPositionsInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>total intial margin required with the latest mark price</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>maintenance margin</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>unrealized profit or loss</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    /// <summary>positions margin required with the latest mark price</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>open orders intial margin required with the latest mark price</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    /// <summary>Leverage value.</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>Whether isolated margin mode is enabled.</summary>
    [JsonPropertyName("isolated")]
    public bool? Isolated { get; set; }

    /// <summary>Position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Position entry price.</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>maximum quantity of base asset</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Notional value.</summary>
    [JsonPropertyName("notionalValue")]
    public string? NotionalValue { get; set; }

    /// <summary>Isolated wallet balance.</summary>
    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>position amount</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>break-even price</summary>
    [JsonPropertyName("breakEvenPrice")]
    public string? BreakEvenPrice { get; set; }
}
