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

public sealed class BalancePositionUpdatePInner
{
    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Position quantity</summary>
    [JsonPropertyName("c")]
    public string? C { get; set; }

    /// <summary>Position value</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Average entry price</summary>
    [JsonPropertyName("a")]
    public string? A { get; set; }
}
