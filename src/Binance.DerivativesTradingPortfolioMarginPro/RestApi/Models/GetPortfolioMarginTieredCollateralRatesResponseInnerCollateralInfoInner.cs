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

public sealed class GetPortfolioMarginTieredCollateralRatesResponseInnerCollateralInfoInner
{
    /// <summary>tier Floor.</summary>
    [JsonPropertyName("tierFloor")]
    public string? TierFloor { get; set; }

    /// <summary>tier Cap.</summary>
    [JsonPropertyName("tierCap")]
    public string? TierCap { get; set; }

    /// <summary>collateral Rate.</summary>
    [JsonPropertyName("collateralRate")]
    public string? CollateralRate { get; set; }

    /// <summary>account equity quick addition number.</summary>
    [JsonPropertyName("cum")]
    public string? Cum { get; set; }
}
