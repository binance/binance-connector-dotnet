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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class OrderBookResponseResult
{
    [JsonPropertyName("lastUpdateId")]
    public long? LastUpdateId { get; set; }

    /// <summary>Message output time</summary>
    [JsonPropertyName("E")]
    public long? EUppercase { get; set; }

    /// <summary>Transaction time</summary>
    [JsonPropertyName("T")]
    public long? TUppercase { get; set; }
}
