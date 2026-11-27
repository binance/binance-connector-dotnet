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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

public sealed class SymbolOrderBookTickerResponseInner
{
    /// <summary>Last update ID.</summary>
    [JsonPropertyName("lastUpdateId")]
    public long? LastUpdateId { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("pair")]
    public string? Pair { get; set; }

    /// <summary>Best bid price.</summary>
    [JsonPropertyName("bidPrice")]
    public string? BidPrice { get; set; }

    /// <summary>Best bid quantity.</summary>
    [JsonPropertyName("bidQty")]
    public string? BidQty { get; set; }

    /// <summary>Best ask price.</summary>
    [JsonPropertyName("askPrice")]
    public string? AskPrice { get; set; }

    /// <summary>Best ask quantity.</summary>
    [JsonPropertyName("askQty")]
    public string? AskQty { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
