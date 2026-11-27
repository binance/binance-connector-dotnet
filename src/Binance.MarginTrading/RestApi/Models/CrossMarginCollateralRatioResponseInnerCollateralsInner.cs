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

public sealed class CrossMarginCollateralRatioResponseInnerCollateralsInner
{
    /// <summary>min Usd Value.</summary>
    [JsonPropertyName("minUsdValue")]
    public string? MinUsdValue { get; set; }

    /// <summary>max Usd Value.</summary>
    [JsonPropertyName("maxUsdValue")]
    public string? MaxUsdValue { get; set; }

    /// <summary>discount Rate.</summary>
    [JsonPropertyName("discountRate")]
    public string? DiscountRate { get; set; }
}
