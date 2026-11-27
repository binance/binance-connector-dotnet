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

public sealed class AccountListResponseDataInner
{
    /// <summary>Type of hashrate bucket</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>Mining account</summary>
    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

    [JsonPropertyName("list")]
    public List<AccountListResponseDataInnerListInner>? List { get; set; }
}
