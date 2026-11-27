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

namespace Binance.Alpha.RestApi;

public sealed class AggregatedTradesResponse
{
    /// <summary>API response code. "000000" indicates success.</summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>Response message.</summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>Detailed response message.</summary>
    [JsonPropertyName("messageDetail")]
    public string? MessageDetail { get; set; }

    /// <summary>Array of aggregated trades.</summary>
    [JsonPropertyName("data")]
    public List<AggregatedTradesResponseDataInner>? Data { get; set; }
}
