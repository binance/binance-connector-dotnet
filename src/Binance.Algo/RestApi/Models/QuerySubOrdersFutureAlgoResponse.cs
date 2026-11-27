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

public sealed class QuerySubOrdersFutureAlgoResponse
{
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    [JsonPropertyName("executedQty")]
    public string? ExecutedQty { get; set; }

    [JsonPropertyName("executedAmt")]
    public string? ExecutedAmt { get; set; }

    [JsonPropertyName("subOrders")]
    public List<QuerySubOrdersFutureAlgoResponseSubOrdersInner>? SubOrders { get; set; }
}
