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

namespace Binance.MarginTrading.WebSocketStreams;

public sealed class ListenKeyExpired
{
    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public string? EUppercase { get; set; }

    [JsonPropertyName("listenKey")]
    public string? ListenKey { get; set; }
}
