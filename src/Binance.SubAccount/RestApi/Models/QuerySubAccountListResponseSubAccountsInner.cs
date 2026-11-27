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

public sealed class QuerySubAccountListResponseSubAccountsInner
{
    [JsonPropertyName("subUserId")]
    public long? SubUserId { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("remark")]
    public string? Remark { get; set; }

    [JsonPropertyName("isFreeze")]
    public bool? IsFreeze { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    [JsonPropertyName("isManagedSubAccount")]
    public bool? IsManagedSubAccount { get; set; }

    [JsonPropertyName("isAssetManagementSubAccount")]
    public bool? IsAssetManagementSubAccount { get; set; }
}
