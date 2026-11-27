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

public sealed class GetMarginRestrictedAssetsResponse
{
    /// <summary>open Long Restricted Asset list.</summary>
    [JsonPropertyName("openLongRestrictedAsset")]
    public List<string>? OpenLongRestrictedAsset { get; set; }

    /// <summary>max Collateral Exceeded Asset list.</summary>
    [JsonPropertyName("maxCollateralExceededAsset")]
    public List<string>? MaxCollateralExceededAsset { get; set; }
}
