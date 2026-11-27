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

namespace Binance.Spot.WebSocketApi;

public sealed class AvgPriceResponseResult
{
    /// <summary>Average price interval (in minutes)</summary>
    [JsonPropertyName("mins")]
    public long? Mins { get; set; }

    /// <summary>Average price</summary>
    [JsonPropertyName("price")]
    public string? Price { get; set; }

    /// <summary>Last trade time</summary>
    [JsonPropertyName("closeTime")]
    public long? CloseTime { get; set; }
}
