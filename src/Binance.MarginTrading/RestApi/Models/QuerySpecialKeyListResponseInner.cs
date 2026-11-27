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

namespace Binance.MarginTrading.RestApi;

public sealed class QuerySpecialKeyListResponseInner
{
    /// <summary>api Name.</summary>
    [JsonPropertyName("apiName")]
    public string? ApiName { get; set; }

    /// <summary>api Key.</summary>
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    /// <summary>ip.</summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>permission Mode.</summary>
    [JsonPropertyName("permissionMode")]
    public string? PermissionMode { get; set; }
}
