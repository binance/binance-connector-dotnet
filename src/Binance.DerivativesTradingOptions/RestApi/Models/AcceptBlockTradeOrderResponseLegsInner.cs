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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class AcceptBlockTradeOrderResponseLegsInner
{
    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>side</summary>
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    /// <summary>quantity</summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }
}
