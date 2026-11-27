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

namespace Binance.W3WPrediction.RestApi;

public sealed class QueryPositionsResponsePositionsInner
{
    [JsonPropertyName("positionId")]
    public long? PositionId { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }

    [JsonPropertyName("chainId")]
    public string? ChainId { get; set; }

    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    [JsonPropertyName("collateralSymbol")]
    public string? CollateralSymbol { get; set; }

    [JsonPropertyName("topicType")]
    public string? TopicType { get; set; }

    [JsonPropertyName("marketTopicId")]
    public long? MarketTopicId { get; set; }

    [JsonPropertyName("marketId")]
    public long? MarketId { get; set; }

    [JsonPropertyName("marketTopicTitle")]
    public string? MarketTopicTitle { get; set; }

    [JsonPropertyName("marketTitle")]
    public string? MarketTitle { get; set; }

    [JsonPropertyName("outcomeName")]
    public string? OutcomeName { get; set; }

    [JsonPropertyName("outcomeIndex")]
    public long? OutcomeIndex { get; set; }

    [JsonPropertyName("shares")]
    public string? Shares { get; set; }

    [JsonPropertyName("avgPrice")]
    public string? AvgPrice { get; set; }

    [JsonPropertyName("totalCost")]
    public string? TotalCost { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("currentPrice")]
    public string? CurrentPrice { get; set; }

    [JsonPropertyName("toWin")]
    public string? ToWin { get; set; }

    [JsonPropertyName("positionStatus")]
    public string? PositionStatus { get; set; }

    [JsonPropertyName("canClaim")]
    public bool? CanClaim { get; set; }

    [JsonPropertyName("endDate")]
    public long? EndDate { get; set; }

    [JsonPropertyName("unrealizedPnl")]
    public string? UnrealizedPnl { get; set; }

    [JsonPropertyName("unrealizedPnlPercent")]
    public string? UnrealizedPnlPercent { get; set; }

    [JsonPropertyName("realizedPnl")]
    public string? RealizedPnl { get; set; }

    [JsonPropertyName("pnl")]
    public string? Pnl { get; set; }

    [JsonPropertyName("createdTime")]
    public long? CreatedTime { get; set; }

    [JsonPropertyName("updatedTime")]
    public long? UpdatedTime { get; set; }
}
