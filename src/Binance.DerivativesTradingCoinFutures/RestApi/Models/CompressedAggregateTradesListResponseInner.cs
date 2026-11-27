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

public sealed class CompressedAggregateTradesListResponseInner
{
    /// <summary>Aggregate tradeId</summary>
    [JsonPropertyName("a")]
    public long? A { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Quantity</summary>
    [JsonPropertyName("q")]
    public string? Q { get; set; }

    /// <summary>First tradeId</summary>
    [JsonPropertyName("f")]
    public long? F { get; set; }

    /// <summary>Last tradeId</summary>
    [JsonPropertyName("l")]
    public long? L { get; set; }

    /// <summary>Timestamp</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Was the buyer the maker?</summary>
    [JsonPropertyName("m")]
    public bool? M { get; set; }
}
