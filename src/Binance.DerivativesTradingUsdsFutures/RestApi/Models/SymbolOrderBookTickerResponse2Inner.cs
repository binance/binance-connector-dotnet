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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class SymbolOrderBookTickerResponse2Inner
{
    /// <summary>Symbol.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Bid Price.</summary>
    [JsonPropertyName("bidPrice")]
    public string? BidPrice { get; set; }

    /// <summary>Bid Qty.</summary>
    [JsonPropertyName("bidQty")]
    public string? BidQty { get; set; }

    /// <summary>Ask Price.</summary>
    [JsonPropertyName("askPrice")]
    public string? AskPrice { get; set; }

    /// <summary>Ask Qty.</summary>
    [JsonPropertyName("askQty")]
    public string? AskQty { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
}
