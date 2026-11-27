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

namespace Binance.CryptoLoan.RestApi;

public sealed class GetFlexibleLoanCollateralAssetsDataResponseRowsInner
{
    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("initialLTV")]
    public string? InitialLTV { get; set; }

    [JsonPropertyName("marginCallLTV")]
    public string? MarginCallLTV { get; set; }

    [JsonPropertyName("liquidationLTV")]
    public string? LiquidationLTV { get; set; }

    [JsonPropertyName("maxLimit")]
    public string? MaxLimit { get; set; }
}
