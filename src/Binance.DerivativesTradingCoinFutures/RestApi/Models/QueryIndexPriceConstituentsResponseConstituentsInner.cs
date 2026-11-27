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

public sealed class QueryIndexPriceConstituentsResponseConstituentsInner
{
    /// <summary>Exchange identifier.</summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; set; }

    /// <summary>Trading symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>Price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Weight</summary>
    [JsonPropertyName("weight")]
    public string? Weight { get; set; }
}
