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

public sealed class QueryPositionsResponse
{
    [JsonPropertyName("summary")]
    public QueryPositionsResponseSummary? Summary { get; set; }

    [JsonPropertyName("counts")]
    public QueryPositionsResponseCounts? Counts { get; set; }

    [JsonPropertyName("positions")]
    public List<QueryPositionsResponsePositionsInner>? Positions { get; set; }
}
