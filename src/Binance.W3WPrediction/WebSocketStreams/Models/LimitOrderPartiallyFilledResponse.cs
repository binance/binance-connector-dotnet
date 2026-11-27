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

public sealed class LimitOrderPartiallyFilledResponse
{
    /// <summary>Unique ID of this push. Use it to remove duplicates.</summary>
    [JsonPropertyName("pushId")]
    public string? PushId { get; set; }

    /// <summary>
    /// Total filled so far in USDT, not just this fill — paid for a buy, received after fees for a sell.
    /// Rounded down to 2 decimals; shown as &lt;0.01 if smaller.
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// Market title, cut to 12 characters with .. added when longer; empty if unavailable.
    /// </summary>
    [JsonPropertyName("topic")]
    public string? Topic { get; set; }
}
