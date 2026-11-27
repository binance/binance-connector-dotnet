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

namespace Binance.Stocks.RestApi;

public sealed class LatestQuoteResponse
{
    /// <summary>US-equity ticker.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Best bid price (USD).</summary>
    [JsonPropertyName("bidPrice")]
    public string? BidPrice { get; set; }

    /// <summary>Best ask price (USD).</summary>
    [JsonPropertyName("askPrice")]
    public string? AskPrice { get; set; }

    /// <summary>Best bid size (shares).</summary>
    [JsonPropertyName("bidSize")]
    public long? BidSize { get; set; }

    /// <summary>Best ask size (shares).</summary>
    [JsonPropertyName("askSize")]
    public long? AskSize { get; set; }
}
