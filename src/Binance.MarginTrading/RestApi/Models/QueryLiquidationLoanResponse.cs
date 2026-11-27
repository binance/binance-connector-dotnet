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

public sealed class QueryLiquidationLoanResponse
{
    /// <summary>The asset of the liquidation loan (USDC by default)</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Total liquidation loan amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>Amount that has been repaid</summary>
    [JsonPropertyName("repaidAmount")]
    public string? RepaidAmount { get; set; }

    /// <summary>Outstanding amount remaining to be repaid</summary>
    [JsonPropertyName("remainingAmount")]
    public string? RemainingAmount { get; set; }
}
