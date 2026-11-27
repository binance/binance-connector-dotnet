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

namespace Binance.Spot.WebSocketStreams;

public sealed class PartialBookDepthResponse
{
    /// <summary>Last update ID</summary>
    [JsonPropertyName("lastUpdateId")]
    public long? LastUpdateId { get; set; }

    /// <summary>Bids to be updated</summary>
    [JsonPropertyName("bids")]
    public List<List<string>>? Bids { get; set; }

    /// <summary>Asks to be updated</summary>
    [JsonPropertyName("asks")]
    public List<List<string>>? Asks { get; set; }
}
