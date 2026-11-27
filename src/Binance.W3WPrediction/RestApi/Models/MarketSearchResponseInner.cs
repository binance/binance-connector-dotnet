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

public sealed class MarketSearchResponseInner
{
    [JsonPropertyName("marketTopicId")]
    public long? MarketTopicId { get; set; }

    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }

    [JsonPropertyName("chainId")]
    public string? ChainId { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("question")]
    public string? Question { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("topicType")]
    public string? TopicType { get; set; }

    [JsonPropertyName("chartType")]
    public string? ChartType { get; set; }

    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    [JsonPropertyName("participantCount")]
    public long? ParticipantCount { get; set; }

    [JsonPropertyName("collateral")]
    public string? Collateral { get; set; }

    [JsonPropertyName("tradeVolume")]
    public string? TradeVolume { get; set; }

    [JsonPropertyName("liquidity")]
    public string? Liquidity { get; set; }

    [JsonPropertyName("startDate")]
    public long? StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public long? EndDate { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("markets")]
    public List<JsonElement>? Markets { get; set; }
}
