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

public sealed class GetVIPLoanRepaymentHistoryResponseRowsInner
{
    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("repayAmount")]
    public string? RepayAmount { get; set; }

    [JsonPropertyName("repayPrincipal")]
    public string? RepayPrincipal { get; set; }

    [JsonPropertyName("repayInterest")]
    public string? RepayInterest { get; set; }

    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    /// <summary>Repayment status (Repaid, Repaying, Failed).</summary>
    [JsonPropertyName("repayStatus")]
    public string? RepayStatus { get; set; }

    [JsonPropertyName("loanDate")]
    public string? LoanDate { get; set; }

    [JsonPropertyName("repayTime")]
    public string? RepayTime { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }
}
