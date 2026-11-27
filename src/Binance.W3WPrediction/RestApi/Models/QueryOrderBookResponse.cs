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

public sealed class QueryOrderBookResponse
{
    [JsonPropertyName("outcome")]
    public string? Outcome { get; set; }

    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    [JsonPropertyName("bids")]
    public List<QueryOrderBookResponseBidsInner>? Bids { get; set; }

    [JsonPropertyName("asks")]
    public List<QueryOrderBookResponseAsksInner>? Asks { get; set; }
}
