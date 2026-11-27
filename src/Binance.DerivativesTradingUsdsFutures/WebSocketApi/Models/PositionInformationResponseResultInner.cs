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

public sealed class PositionInformationResponseResultInner
{
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    [JsonPropertyName("breakEvenPrice")]
    public string? BreakEvenPrice { get; set; }

    [JsonPropertyName("marginType")]
    public string? MarginType { get; set; }

    [JsonPropertyName("isAutoAddMargin")]
    public string? IsAutoAddMargin { get; set; }

    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    [JsonPropertyName("liquidationPrice")]
    public string? LiquidationPrice { get; set; }

    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    [JsonPropertyName("maxNotionalValue")]
    public string? MaxNotionalValue { get; set; }

    [JsonPropertyName("positionAmt")]
    public string? PositionAmt { get; set; }

    [JsonPropertyName("notional")]
    public string? Notional { get; set; }

    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("unRealizedProfit")]
    public string? UnRealizedProfit { get; set; }

    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }
}
