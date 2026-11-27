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

public sealed class TrailingDeltaFilter
{
    [JsonPropertyName("filterType")]
    public string? FilterType { get; set; }

    [JsonPropertyName("minTrailingAboveDelta")]
    public long? MinTrailingAboveDelta { get; set; }

    [JsonPropertyName("maxTrailingAboveDelta")]
    public long? MaxTrailingAboveDelta { get; set; }

    [JsonPropertyName("minTrailingBelowDelta")]
    public long? MinTrailingBelowDelta { get; set; }

    [JsonPropertyName("maxTrailingBelowDelta")]
    public long? MaxTrailingBelowDelta { get; set; }
}
