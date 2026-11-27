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

public sealed class BalancePositionUpdateBInner
{
    /// <summary>Margin asset</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }

    /// <summary>Account balance</summary>
    [JsonPropertyName("b")]
    public string? B { get; set; }

    /// <summary>Balance Change except PnL and Commission</summary>
    [JsonPropertyName("bc")]
    public string? Bc { get; set; }
}
