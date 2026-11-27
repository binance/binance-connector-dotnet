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

public sealed class PositionInformationV2ResponseInner
{
    /// <summary>Entry Price.</summary>
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>Break Even Price.</summary>
    [JsonPropertyName("breakEvenPrice")]
    public string? BreakEvenPrice { get; set; }

    /// <summary>Margin Type.</summary>
    [JsonPropertyName("marginType")]
    public string? MarginType { get; set; }

    [JsonPropertyName("isAutoAddMargin")]
    public string? IsAutoAddMargin { get; set; }

    /// <summary>Isolated Margin.</summary>
    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    /// <summary>Leverage.</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>Liquidation Price.</summary>
    [JsonPropertyName("liquidationPrice")]
    public string? LiquidationPrice { get; set; }

    /// <summary>Mark Price.</summary>
    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    /// <summary>Max Notional Value.</summary>
    [JsonPropertyName("maxNotionalValue")]
    public string? MaxNotionalValue { get; set; }

    /// <summary>Position Amt.</summary>
    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Un Realized Profit.</summary>
    [JsonPropertyName("unRealizedProfit")]
    public string? UnRealizedProfit { get; set; }

    /// <summary>Position Side.</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>Update Time.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
