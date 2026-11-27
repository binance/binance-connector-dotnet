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

public sealed class MarginLevelStatusChange
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Margin level</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }

    /// <summary>Margin call status</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }
}
