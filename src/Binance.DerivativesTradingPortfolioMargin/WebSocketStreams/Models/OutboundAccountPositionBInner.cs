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

public sealed class OutboundAccountPositionBInner
{
    /// <summary>Asset</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Free</summary>
    [JsonPropertyName("f")]
    public string? F { get; set; }

    /// <summary>Locked</summary>
    [JsonPropertyName("l")]
    public string? L { get; set; }
}
