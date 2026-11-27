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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class QueryUmPositionInformationResponseInner
{
    /// <summary>average entry price</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>current initial leverage</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>Mark Price.</summary>
    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>Max Notional Value.</summary>
    [JsonPropertyName("maxNotionalValue")]
    public string? MaxNotionalValue { get; set; }

    /// <summary>position amount</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>Notional.</summary>
    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    /// <summary>Trade symbol, if existing.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Un Realized Profit.</summary>
    [JsonPropertyName("unRealizedProfit")]
    public string? UnRealizedProfit { get; set; }

    /// <summary>Liquidation Price.</summary>
    [JsonPropertyName("liquidationPrice")]
    public string? LiquidationPrice { get; set; }

    /// <summary>BOTH means that it is the position of One-way Mode</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
