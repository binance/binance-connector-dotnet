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

public sealed class EquityOrderHistoryResponse
{
    /// <summary>Total number of rows matching the filter.</summary>
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    /// <summary>Current page (echoes current).</summary>
    [JsonPropertyName("page")]
    public long? Page { get; set; }

    /// <summary>Current page size (echoes size).</summary>
    [JsonPropertyName("size")]
    public long? Size { get; set; }

    /// <summary>Order rows on this page. Empty array if nothing matches.</summary>
    [JsonPropertyName("rows")]
    public List<EquityOrderHistoryResponseRowsInner>? Rows { get; set; }
}
