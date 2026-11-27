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

namespace Binance.Convert.RestApi;

public sealed class GetConvertTradeHistoryResponse
{
    [JsonPropertyName("list")]
    public List<GetConvertTradeHistoryResponseListInner>? List { get; set; }

    [JsonPropertyName("startTime")]
    public long? StartTime { get; set; }

    [JsonPropertyName("endTime")]
    public long? EndTime { get; set; }

    [JsonPropertyName("limit")]
    public long? Limit { get; set; }

    [JsonPropertyName("moreData")]
    public bool? MoreData { get; set; }
}
