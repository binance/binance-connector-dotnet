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

namespace Binance.VipLoan.RestApi;

public sealed class GetCollateralAssetDataResponseRowsInner
{
    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("_1stCollateralRatio")]
    public string? Var1stCollateralRatio { get; set; }

    [JsonPropertyName("_1stCollateralRange")]
    public string? Var1stCollateralRange { get; set; }

    [JsonPropertyName("_2ndCollateralRatio")]
    public string? Var2ndCollateralRatio { get; set; }

    [JsonPropertyName("_2ndCollateralRange")]
    public string? Var2ndCollateralRange { get; set; }

    [JsonPropertyName("_3rdCollateralRatio")]
    public string? Var3rdCollateralRatio { get; set; }

    [JsonPropertyName("_3rdCollateralRange")]
    public string? Var3rdCollateralRange { get; set; }

    [JsonPropertyName("_4thCollateralRatio")]
    public string? Var4thCollateralRatio { get; set; }

    [JsonPropertyName("_4thCollateralRange")]
    public string? Var4thCollateralRange { get; set; }
}
