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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

public sealed class IndexKlineCandlestickStreamsResponse
{
    /// <summary>eventType</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>eventTime</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Pair</summary>
    [JsonPropertyName("ps")]
    public string? Ps { get; set; }

    [JsonPropertyName("k")]
    public IndexKlineCandlestickStreamsResponseK? K { get; set; }
}
