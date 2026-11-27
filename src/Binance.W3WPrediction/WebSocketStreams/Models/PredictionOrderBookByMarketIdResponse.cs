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

namespace Binance.W3WPrediction.WebSocketStreams;

public sealed class PredictionOrderBookByMarketIdResponse
{
    /// <summary>Message type, always orderbook.</summary>
    [JsonPropertyName("msgType")]
    public string? MsgType { get; set; }

    /// <summary>Market ID of this order book, the same markets[].marketId used by the REST API.</summary>
    [JsonPropertyName("marketId")]
    public long? MarketId { get; set; }

    /// <summary>
    /// Quote update time in milliseconds (UTC). Messages for the same market may arrive out of order, so
    /// discard anything older than the snapshot you already have.
    /// </summary>
    [JsonPropertyName("updateTimestampMs")]
    public long? UpdateTimestampMs { get; set; }

    /// <summary>
    /// Ask levels sorted by price ascending, usually the top 50 or fewer; an empty array means no asks.
    /// Values may carry floating-point noise (e.g. 6865.999999999999), so round them before display.
    /// </summary>
    [JsonPropertyName("asks")]
    public List<List<decimal>>? Asks { get; set; }

    /// <summary>
    /// Bid levels sorted by price descending, usually the top 50 or fewer; an empty array means no bids.
    /// Values may carry floating-point noise (e.g. 6865.999999999999), so round them before display.
    /// </summary>
    [JsonPropertyName("bids")]
    public List<List<decimal>>? Bids { get; set; }
}
