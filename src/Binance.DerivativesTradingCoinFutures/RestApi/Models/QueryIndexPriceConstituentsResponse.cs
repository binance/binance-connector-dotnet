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

public sealed class QueryIndexPriceConstituentsResponse
{
    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Time</summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }

    /// <summary>Constituent list.</summary>
    [JsonPropertyName("constituents")]
    public List<QueryIndexPriceConstituentsResponseConstituentsInner>? Constituents { get; set; }
}
