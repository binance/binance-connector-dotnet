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

public sealed class HashrateResaleRequestResponse
{
    [JsonPropertyName("code")]
    public long? Code { get; set; }

    [JsonPropertyName("msg")]
    public string? Msg { get; set; }

    /// <summary>Configuration ID</summary>
    [JsonPropertyName("data")]
    public long? Data { get; set; }
}
