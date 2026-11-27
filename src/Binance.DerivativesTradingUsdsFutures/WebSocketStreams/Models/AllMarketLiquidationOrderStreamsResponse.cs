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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketStreams;

public sealed class AllMarketLiquidationOrderStreamsResponse
{
    /// <summary>Event Type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    [JsonPropertyName("o")]
    public AllMarketLiquidationOrderStreamsResponseO? O { get; set; }

    /// <summary>(After CM migration) Pair symbol</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
