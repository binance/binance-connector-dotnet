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

namespace Binance.DerivativesTradingOptions.WebSocketStreams;

public sealed class KlineCandlestickStreamsResponse
{
    /// <summary>event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Option trading symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    [JsonPropertyName("k")]
    public KlineCandlestickStreamsResponseK? K { get; set; }
}
