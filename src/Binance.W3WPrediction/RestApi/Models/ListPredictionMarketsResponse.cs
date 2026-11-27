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

public sealed class ListPredictionMarketsResponse
{
    [JsonPropertyName("marketTopics")]
    public List<ListPredictionMarketsResponseMarketTopicsInner>? MarketTopics { get; set; }

    [JsonPropertyName("total")]
    public long? Total { get; set; }

    [JsonPropertyName("offset")]
    public long? Offset { get; set; }

    [JsonPropertyName("limit")]
    public long? Limit { get; set; }

    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }
}
