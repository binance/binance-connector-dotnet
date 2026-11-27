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

namespace Binance.Wallet.RestApi;

public sealed class SystemStatusResponse
{
    /// <summary>0: normal，1：system maintenance</summary>
    [JsonPropertyName("status")]
    public long? Status { get; set; }

    /// <summary>"normal", "system_maintenance"</summary>
    [JsonPropertyName("msg")]
    public string? Msg { get; set; }
}
