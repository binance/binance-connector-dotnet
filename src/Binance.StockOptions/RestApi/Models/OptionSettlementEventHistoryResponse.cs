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

namespace Binance.StockOptions.RestApi;

public sealed class OptionSettlementEventHistoryResponse
{
    /// <summary>Event records.</summary>
    [JsonPropertyName("rows")]
    public List<OptionSettlementEventHistoryResponseRowsInner>? Rows { get; set; }

    /// <summary>Whether there is a next page.</summary>
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }

    /// <summary>Cursor for the next page.</summary>
    [JsonPropertyName("nextLastId")]
    public long? NextLastId { get; set; }
}
