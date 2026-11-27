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

namespace Binance.Spot.WebSocketApi;

public sealed class BalanceUpdate
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Asset</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Balance Delta</summary>
    [JsonPropertyName("d")]
    public string? D { get; set; }

    /// <summary>Clear Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }
}
