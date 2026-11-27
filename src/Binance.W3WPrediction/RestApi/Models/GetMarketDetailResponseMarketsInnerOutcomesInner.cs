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

namespace Binance.W3WPrediction.RestApi;

public sealed class GetMarketDetailResponseMarketsInnerOutcomesInner
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("chance")]
    public string? Chance { get; set; }

    [JsonPropertyName("index")]
    public long? Index { get; set; }

    [JsonPropertyName("tokenId")]
    public string? TokenId { get; set; }

    /// <summary>
    /// Whether this outcome won. Returned only after the market is resolved. More than one outcome can be
    /// true when the payout is split
    /// </summary>
    [JsonPropertyName("winner")]
    public bool? Winner { get; set; }
}
