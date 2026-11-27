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

public sealed class MaxAssetFilter
{
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    [JsonPropertyName("qtyExponent")]
    public long? QtyExponent { get; set; }

    [JsonPropertyName("limit")]
    public string? Limit { get; set; }

    [JsonPropertyName("asset")]
    public string? Asset { get; set; }
}
