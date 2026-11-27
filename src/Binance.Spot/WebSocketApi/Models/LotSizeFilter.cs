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

public sealed class LotSizeFilter
{
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    [JsonPropertyName("qtyExponent")]
    public long? QtyExponent { get; set; }

    [JsonPropertyName("minQty")]
    public string? MinQty { get; set; }

    [JsonPropertyName("maxQty")]
    public string? MaxQty { get; set; }

    [JsonPropertyName("stepSize")]
    public string? StepSize { get; set; }
}
