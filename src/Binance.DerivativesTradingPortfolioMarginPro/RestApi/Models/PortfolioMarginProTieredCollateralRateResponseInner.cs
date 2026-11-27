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

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

public sealed class PortfolioMarginProTieredCollateralRateResponseInner
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("collateralInfo")]
    public List<PortfolioMarginProTieredCollateralRateResponseInnerCollateralInfoInner>? CollateralInfo { get; set; }
}
