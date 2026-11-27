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

public sealed class GetVIPLoanAccruedInterestResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("principalAmount")]
    public string? PrincipalAmount { get; set; }

    [JsonPropertyName("interestAmount")]
    public string? InterestAmount { get; set; }

    [JsonPropertyName("annualInterestRate")]
    public string? AnnualInterestRate { get; set; }

    [JsonPropertyName("accrualTime")]
    public long? AccrualTime { get; set; }

    /// <summary>Latest order ID for the renewal order.</summary>
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }
}
