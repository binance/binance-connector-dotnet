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

public sealed class VipLoanRepayResponse
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("repayAmount")]
    public string? RepayAmount { get; set; }

    [JsonPropertyName("remainingPrincipal")]
    public string? RemainingPrincipal { get; set; }

    [JsonPropertyName("remainingInterest")]
    public string? RemainingInterest { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("currentLTV")]
    public string? CurrentLTV { get; set; }

    /// <summary>Repayment status (Repaid, Repaying, Failed).</summary>
    [JsonPropertyName("repayStatus")]
    public string? RepayStatus { get; set; }
}
