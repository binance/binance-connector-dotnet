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

namespace Binance.Stocks.WebSocketStreams;

public sealed class PriceStreamResponse
{
    /// <summary>Event type, always "price".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>One entry per symbol.</summary>
    [JsonPropertyName("rates")]
    public List<PriceStreamResponseRatesInner>? Rates { get; set; }
}
