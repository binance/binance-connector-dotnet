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

public sealed class EquityTradeHistoryResponse
{
    /// <summary>Total number of rows matching the filter.</summary>
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    /// <summary>Current page.</summary>
    [JsonPropertyName("page")]
    public long? Page { get; set; }

    /// <summary>Current page size.</summary>
    [JsonPropertyName("size")]
    public long? Size { get; set; }

    /// <summary>Trade rows on this page. Empty when nothing matches.</summary>
    [JsonPropertyName("rows")]
    public List<EquityTradeHistoryResponseRowsInner>? Rows { get; set; }
}
