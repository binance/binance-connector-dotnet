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

public sealed class QueryManagedSubAccountListResponseManagerSubUserInfoVoListInner
{
    [JsonPropertyName("rootUserId")]
    public long? RootUserId { get; set; }

    [JsonPropertyName("managersubUserId")]
    public long? ManagersubUserId { get; set; }

    [JsonPropertyName("bindParentUserId")]
    public long? BindParentUserId { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("insertTimeStamp")]
    public long? InsertTimeStamp { get; set; }

    [JsonPropertyName("bindParentEmail")]
    public string? BindParentEmail { get; set; }

    [JsonPropertyName("isSubUserEnabled")]
    public bool? IsSubUserEnabled { get; set; }

    [JsonPropertyName("isUserActive")]
    public bool? IsUserActive { get; set; }

    [JsonPropertyName("isMarginEnabled")]
    public bool? IsMarginEnabled { get; set; }

    [JsonPropertyName("isFutureEnabled")]
    public bool? IsFutureEnabled { get; set; }

    [JsonPropertyName("isSignedLVTRiskAgreement")]
    public bool? IsSignedLVTRiskAgreement { get; set; }
}
