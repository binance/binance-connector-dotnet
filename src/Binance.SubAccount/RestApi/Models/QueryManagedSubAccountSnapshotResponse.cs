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

namespace Binance.SubAccount.RestApi;

public sealed class QueryManagedSubAccountSnapshotResponse
{
    /// <summary>200 for success; others are error codes</summary>
    [JsonPropertyName("code")]
    public long? Code { get; set; }

    /// <summary>error message</summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    [JsonPropertyName("snapshotVos")]
    public List<QueryManagedSubAccountSnapshotResponseSnapshotVosInner>? SnapshotVos { get; set; }
}
