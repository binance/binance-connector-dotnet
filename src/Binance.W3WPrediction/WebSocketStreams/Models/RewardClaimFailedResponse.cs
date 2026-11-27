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

public sealed class RewardClaimFailedResponse
{
    /// <summary>Unique ID of this push. Use it to remove duplicates.</summary>
    [JsonPropertyName("pushId")]
    public string? PushId { get; set; }

    /// <summary>
    /// Amount of the first failed claim. Rounded down to 2 decimals; shown as &lt;0.01 if smaller.
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Outcome name of the first failed claim, such as Yes or No; empty if unavailable.</summary>
    [JsonPropertyName("outcome")]
    public string? Outcome { get; set; }
}
