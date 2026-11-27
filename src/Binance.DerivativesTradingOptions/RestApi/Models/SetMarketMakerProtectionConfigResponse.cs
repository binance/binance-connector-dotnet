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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class SetMarketMakerProtectionConfigResponse
{
    /// <summary>underlying Id</summary>
    [JsonPropertyName("underlyingId")]
    public long? UnderlyingId { get; set; }

    /// <summary>underlying</summary>
    [JsonPropertyName("underlying")]
    public string? Underlying { get; set; }

    /// <summary>window Time In Milliseconds</summary>
    [JsonPropertyName("windowTimeInMilliseconds")]
    public long? WindowTimeInMilliseconds { get; set; }

    /// <summary>frozen Time In Milliseconds</summary>
    [JsonPropertyName("frozenTimeInMilliseconds")]
    public long? FrozenTimeInMilliseconds { get; set; }

    /// <summary>qty Limit</summary>
    [JsonPropertyName("qtyLimit")]
    public string? QtyLimit { get; set; }

    /// <summary>delta Limit</summary>
    [JsonPropertyName("deltaLimit")]
    public string? DeltaLimit { get; set; }

    /// <summary>last Trigger Time</summary>
    [JsonPropertyName("lastTriggerTime")]
    public long? LastTriggerTime { get; set; }
}
