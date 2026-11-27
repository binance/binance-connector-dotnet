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

namespace Binance.Algo.RestApi;

public sealed class QueryHistoricalAlgoOrdersSpotAlgoResponse
{
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    [JsonPropertyName("orders")]
    public List<QueryHistoricalAlgoOrdersSpotAlgoResponseOrdersInner>? Orders { get; set; }
}
