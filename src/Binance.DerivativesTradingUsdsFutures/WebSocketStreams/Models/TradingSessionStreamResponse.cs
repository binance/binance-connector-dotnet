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

public sealed class TradingSessionStreamResponse
{
    /// <summary>
    /// Event type, can also be CommodityUpdate, KR_EquityUpdate, HK_EquityUpdate, CN_EquityUpdate or
    /// FXUpdate
    /// </summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Session start time</summary>
    [JsonPropertyName("t")]
    public long? T { get; set; }

    /// <summary>Session end time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>Session type</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }
}
