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

namespace Binance.SubAccount.RestApi;

public sealed class GetFuturesPositionRiskOfSubAccountV2ResponseDeliveryPositionRiskVosInner
{
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    [JsonPropertyName("isolated")]
    public string? Isolated { get; set; }

    [JsonPropertyName("isolatedWallet")]
    public string? IsolatedWallet { get; set; }

    [JsonPropertyName("isolatedMargin")]
    public string? IsolatedMargin { get; set; }

    [JsonPropertyName("isAutoAddMargin")]
    public string? IsAutoAddMargin { get; set; }

    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    [JsonPropertyName("positionAmount")]
    public string? PositionAmount { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }
}
