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

public sealed class OptionOrderHistoryResponse
{
    /// <summary>Total number of records.</summary>
    [JsonPropertyName("total")]
    public long? Total { get; set; }

    /// <summary>Current page number.</summary>
    [JsonPropertyName("page")]
    public long? Page { get; set; }

    /// <summary>Current page size.</summary>
    [JsonPropertyName("size")]
    public long? Size { get; set; }

    /// <summary>Order records.</summary>
    [JsonPropertyName("rows")]
    public List<OptionOrderHistoryResponseRowsInner>? Rows { get; set; }
}
