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

namespace Binance.MarginTrading.RestApi;

public sealed class GetMarginAssetRiskBasedLiquidationRatioResponseInner
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>risk Based Liquidation Ratio.</summary>
    [JsonPropertyName("riskBasedLiquidationRatio")]
    public string? RiskBasedLiquidationRatio { get; set; }
}
