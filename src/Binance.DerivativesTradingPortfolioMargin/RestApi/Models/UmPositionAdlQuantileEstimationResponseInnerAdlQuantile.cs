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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

/// <summary>Adl Quantile.</summary>
public sealed class UmPositionAdlQuantileEstimationResponseInnerAdlQuantile
{
    /// <summary>adl quantile for "LONG" position in hedge mode</summary>
    [JsonPropertyName("LONG")]
    public long? LONG { get; set; }

    /// <summary>adl quantile for "SHORT" position in hedge mode</summary>
    [JsonPropertyName("SHORT")]
    public long? SHORT { get; set; }

    /// <summary>adl quantile for position in one-way mode</summary>
    [JsonPropertyName("BOTH")]
    public long? BOTH { get; set; }
}
