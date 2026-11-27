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

public sealed class NotionalFilter
{
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    [JsonPropertyName("priceExponent")]
    public long? PriceExponent { get; set; }

    [JsonPropertyName("minNotional")]
    public string? MinNotional { get; set; }

    [JsonPropertyName("applyMinToMarket")]
    public bool? ApplyMinToMarket { get; set; }

    [JsonPropertyName("maxNotional")]
    public string? MaxNotional { get; set; }

    [JsonPropertyName("applyMaxToMarket")]
    public bool? ApplyMaxToMarket { get; set; }

    [JsonPropertyName("avgPriceMins")]
    public long? AvgPriceMins { get; set; }
}
