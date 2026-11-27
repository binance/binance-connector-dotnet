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

public sealed class FlexibleLoanRepayResponse
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("remainingDebt")]
    public string? RemainingDebt { get; set; }

    [JsonPropertyName("remainingCollateral")]
    public string? RemainingCollateral { get; set; }

    [JsonPropertyName("fullRepayment")]
    public bool? FullRepayment { get; set; }

    [JsonPropertyName("currentLTV")]
    public string? CurrentLTV { get; set; }

    /// <summary>REPAID, REPAYING, FAILED</summary>
    [JsonPropertyName("repayStatus")]
    public string? RepayStatus { get; set; }
}
