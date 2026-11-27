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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class BalancePositionUpdate
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Transaction Time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Event reason type</summary>
    [JsonPropertyName("m")]
    public string? M { get; set; }

    /// <summary>Balances</summary>
    [JsonPropertyName("B")]
    public List<BalancePositionUpdateBInner>? BUppercase { get; set; }

    /// <summary>Positions</summary>
    [JsonPropertyName("P")]
    public List<BalancePositionUpdatePInner>? PUppercase { get; set; }
}
