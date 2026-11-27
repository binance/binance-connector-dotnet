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

public sealed class ConditionalOrderTriggerReject
{
    /// <summary>Event Time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Message send time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }

    [JsonPropertyName("or")]
    public ConditionalOrderTriggerRejectOr? Or { get; set; }
}
