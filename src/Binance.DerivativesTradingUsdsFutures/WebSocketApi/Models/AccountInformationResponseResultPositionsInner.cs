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

public sealed class AccountInformationResponseResultPositionsInner
{
    /// <summary>symbol name</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>total initial margin required with current mark price</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>maintenance margin required</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>unrealized profit</summary>
    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    /// <summary>initial margin required for positions with current mark price</summary>
    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    /// <summary>initial margin required for open orders with current mark price</summary>
    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    /// <summary>current initial leverage</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>if the position is isolated</summary>
    [JsonPropertyName("isolated")]
    public bool? Isolated { get; set; }

    /// <summary>average entry price</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>maximum available notional with current leverage</summary>
    [JsonPropertyName("maxNotional")]
    public string? MaxNotional { get; set; }

    /// <summary>bids notional, ignore</summary>
    [JsonPropertyName("bidNotional")]
    public string? BidNotional { get; set; }

    /// <summary>ask notional, ignore</summary>
    [JsonPropertyName("askNotional")]
    public string? AskNotional { get; set; }

    /// <summary>position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>position amount</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>reserved property, please ignore</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>average entry price</summary>
    [JsonPropertyName("breakEvenPrice")]
    public string? BreakEvenPrice { get; set; }
}
