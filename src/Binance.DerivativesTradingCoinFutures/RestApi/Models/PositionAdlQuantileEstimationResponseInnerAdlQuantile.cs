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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

/// <summary>ADL quantile information.</summary>
public sealed class PositionAdlQuantileEstimationResponseInnerAdlQuantile
{
    /// <summary>adl quantile for "LONG" position in hedge mode</summary>
    [JsonPropertyName("LONG")]
    public long? LONG { get; set; }

    /// <summary>adl qauntile for "SHORT" position in hedge mode</summary>
    [JsonPropertyName("SHORT")]
    public long? SHORT { get; set; }

    /// <summary>Hedge mode ADL quantile.</summary>
    [JsonPropertyName("HEDGE")]
    public long? HEDGE { get; set; }

    /// <summary>One-way mode ADL quantile.</summary>
    [JsonPropertyName("BOTH")]
    public long? BOTH { get; set; }
}
