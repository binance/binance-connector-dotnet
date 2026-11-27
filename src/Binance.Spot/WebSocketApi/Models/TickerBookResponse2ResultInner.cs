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

public sealed class TickerBookResponse2ResultInner
{
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>best bid price.</summary>
    [JsonPropertyName("bidPrice")]
    public string? BidPrice { get; set; }

    /// <summary>bid/ask qty.</summary>
    [JsonPropertyName("bidQty")]
    public string? BidQty { get; set; }

    /// <summary>best ask price.</summary>
    [JsonPropertyName("askPrice")]
    public string? AskPrice { get; set; }

    /// <summary>bid/ask qty.</summary>
    [JsonPropertyName("askQty")]
    public string? AskQty { get; set; }
}
