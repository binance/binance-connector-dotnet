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

public sealed class CalendarStreamResponse
{
    /// <summary>Event type, always "calendar".</summary>
    [JsonPropertyName("e")]
    public string? E { get; set; }

    /// <summary>Previous market phase.</summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }

    /// <summary>New market phase.</summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }

    /// <summary>Event timestamp (epoch milliseconds UTC) when the transition was detected.</summary>
    [JsonPropertyName("ts")]
    public long? Ts { get; set; }
}
