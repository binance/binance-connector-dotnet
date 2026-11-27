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

public sealed class MarkPriceOfAllSymbolsOfAPairResponseInner
{
    /// <summary>Event type</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Event time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Symbol</summary>
    [JsonPropertyName("s")]
    public string? S { get; set; }

    /// <summary>Mark Price</summary>
    [JsonPropertyName("p")]
    public string? P { get; set; }

    /// <summary>Estimated Settle Price, only useful in the last hour before the settlement starts.</summary>
    [JsonPropertyName("P")]
    public string? PUppercase { get; set; }

    /// <summary>Index Price</summary>
    [JsonPropertyName("i")]
    public string? I { get; set; }

    /// <summary>funding rate for perpetual symbol, "" will be shown for delivery symbol</summary>
    [JsonPropertyName("r")]
    public string? R { get; set; }

    /// <summary>next funding time for perpetual symbol, 0 will be shown for delivery symbol</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    /// <summary>(After CM migration) Symbol type: 1 = UM, 2 = CM</summary>
    [JsonPropertyName("st")]
    public long? St { get; set; }
}
