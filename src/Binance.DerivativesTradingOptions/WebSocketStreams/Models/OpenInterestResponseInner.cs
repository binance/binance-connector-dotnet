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

public sealed class OpenInterestResponseInner
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Option symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Open interest in contracts</summary>
    [JsonPropertyName("o")]
    public string? O { get; set; }

    /// <summary>Open interest in USDT</summary>
    [JsonPropertyName("h")]
    public string? H { get; set; }
}
