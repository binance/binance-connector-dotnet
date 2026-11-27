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

namespace Binance.Spot.WebSocketApi;

public sealed class OrderAmendKeepPriorityResponseResult
{
    [JsonPropertyName("transactTime")]
    public long? TransactTime { get; set; }

    [JsonPropertyName("executionId")]
    public long? ExecutionId { get; set; }

    [JsonPropertyName("amendedOrder")]
    public OrderAmendKeepPriorityResponseResultAmendedOrder? AmendedOrder { get; set; }

    [JsonPropertyName("listStatus")]
    public OrderAmendKeepPriorityResponseResultListStatus? ListStatus { get; set; }
}
