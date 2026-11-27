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

public sealed class GetFuturesPositionRiskOfSubAccountResponseInner
{
    [JsonPropertyName("entryPrice")]
    public string? EntryPrice { get; set; }

    /// <summary>current initial leverage</summary>
    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    /// <summary>notional value limit of current initial leverage</summary>
    [JsonPropertyName("maxNotional")]
    public string? MaxNotional { get; set; }

    [JsonPropertyName("liquidationPrice")]
    public string? LiquidationPrice { get; set; }

    [JsonPropertyName("markPrice")]
    public string? MarkPrice { get; set; }

    [JsonPropertyName("positionAmount")]
    public string? PositionAmount { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }
}
