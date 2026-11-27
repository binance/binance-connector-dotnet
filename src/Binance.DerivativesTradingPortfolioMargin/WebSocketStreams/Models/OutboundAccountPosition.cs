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

public sealed class OutboundAccountPosition
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Time of last account update</summary>
    [JsonPropertyName("u")]
    public long? U { get; set; }

    /// <summary>Time updateID</summary>
    [JsonPropertyName("U")]
    public long? UUppercase { get; set; }

    /// <summary>Balances Array</summary>
    [JsonPropertyName("B")]
    public List<OutboundAccountPositionBInner>? BUppercase { get; set; }
}
