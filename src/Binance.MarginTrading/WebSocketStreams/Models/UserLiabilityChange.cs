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

public sealed class UserLiabilityChange
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Asset</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Liability Update Type</summary>
    [JsonPropertyName("t")]
    public string? T { get; set; }

    /// <summary>Principle Quantity</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Interest Quantity</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }
}
