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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class PositionInformationResponseInner
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>position amount</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    /// <summary>Position entry price.</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>break-even price</summary>
    [JsonPropertyName("breakEvenPrice")]
    public string? BreakEvenPrice { get; set; }

    /// <summary>mark price</summary>
    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>Unrealized profit.</summary>
    [JsonPropertyName("unRealizedProfit")]
    public string? UnRealizedProfit { get; set; }

    /// <summary>Liquidation price.</summary>
    [JsonPropertyName("liquidationPrice")]
    public string? LiquidationPrice { get; set; }

    /// <summary>Leverage value.</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>maximum quantity of base asset</summary>
    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    /// <summary>Margin type.</summary>
    [JsonPropertyName("marginType")]
    public string? MarginType { get; set; }

    /// <summary>Isolated margin amount.</summary>
    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    /// <summary>Whether auto-add margin is enabled.</summary>
    [JsonPropertyName("isAutoAddMargin")]
    public string? IsAutoAddMargin { get; set; }

    /// <summary>Position side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
