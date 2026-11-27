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

public sealed class GetSubAccountsStatusOnMarginOrFuturesResponseInner
{
    /// <summary>user email</summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>true or false</summary>
    [JsonPropertyName("isSubUserEnabled")]
    public bool? IsSubUserEnabled { get; set; }

    /// <summary>true or false</summary>
    [JsonPropertyName("isUserActive")]
    public bool? IsUserActive { get; set; }

    /// <summary>sub account create time</summary>
    [JsonPropertyName("insertTime")]
    public long? InsertTime { get; set; }

    /// <summary>true or false for margin</summary>
    [JsonPropertyName("isMarginEnabled")]
    public bool? IsMarginEnabled { get; set; }

    /// <summary>true or false for futures.</summary>
    [JsonPropertyName("isFutureEnabled")]
    public bool? IsFutureEnabled { get; set; }

    /// <summary>user mobile number</summary>
    [JsonPropertyName("mobile")]
    public long? Mobile { get; set; }
}
