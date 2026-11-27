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

namespace Binance.Mining.RestApi;

public sealed class HashrateResaleListResponseData
{
    [JsonPropertyName("configDetails")]
    public List<HashrateResaleListResponseDataConfigDetailsInner>? ConfigDetails { get; set; }

    /// <summary>Total rows</summary>
    [JsonPropertyName("totalNum")]
    public long? TotalNum { get; set; }

    /// <summary>Rows per page</summary>
    [JsonPropertyName("pageSize")]
    public long? PageSize { get; set; }
}
