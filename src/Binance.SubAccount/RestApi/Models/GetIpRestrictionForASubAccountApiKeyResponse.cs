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

public sealed class GetIpRestrictionForASubAccountApiKeyResponse
{
    [JsonPropertyName("ipRestrict")]
    public string? IpRestrict { get; set; }

    [JsonPropertyName("ipList")]
    public List<string>? IpList { get; set; }

    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }
}
