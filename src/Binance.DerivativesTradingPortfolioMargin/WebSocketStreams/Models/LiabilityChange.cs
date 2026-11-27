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

namespace Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

public sealed class LiabilityChange
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Asset</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Type</summary>
    [JsonPropertyName("t")]
    public string? T { get; set; }

    /// <summary>Transaction ID</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Principal</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Interest</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>Total Liability</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }
}
