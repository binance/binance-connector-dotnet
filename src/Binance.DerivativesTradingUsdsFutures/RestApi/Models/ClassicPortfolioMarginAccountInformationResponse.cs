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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class ClassicPortfolioMarginAccountInformationResponse
{
    /// <summary>Classic Portfolio margin maximum virtual amount for transfer out in USD</summary>
    [JsonPropertyName("maxWithdrawAmountUSD")]
    public string? MaxWithdrawAmountUSD { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>maximum amount for transfer out</summary>
    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }
}
