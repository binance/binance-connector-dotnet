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

public sealed class IndexPriceStreamsResponseInner
{
    /// <summary>event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>underlying symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>index price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }
}
