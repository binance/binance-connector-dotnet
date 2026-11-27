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

namespace Binance.Stocks.RestApi;

public sealed class CorporateActionRecordsResponse
{
    /// <summary>Corporate action asset change records on this page.</summary>
    [JsonPropertyName("items")]
    public List<CorporateActionRecordsResponseItemsInner>? Items { get; set; }

    /// <summary>Pass this value as lastTime on the next request. Not returned on the last page.</summary>
    [JsonPropertyName("nextTime")]
    public long? NextTime { get; set; }

    /// <summary>Pass this value as lastId on the next request. Not returned on the last page.</summary>
    [JsonPropertyName("nextId")]
    public long? NextId { get; set; }
}
