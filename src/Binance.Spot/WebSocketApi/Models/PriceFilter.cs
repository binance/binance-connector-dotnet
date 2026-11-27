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

public sealed class PriceFilter
{
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    [JsonPropertyName("priceExponent")]
    public long? PriceExponent { get; set; }

    [JsonPropertyName("minPrice")]
    public string? MinPrice { get; set; }

    [JsonPropertyName("maxPrice")]
    public string? MaxPrice { get; set; }

    [JsonPropertyName("tickSize")]
    public string? TickSize { get; set; }
}
