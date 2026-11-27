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

public sealed class QueryApplicationStatusResponseRowsInner
{
    /// <summary>Loan receiving account.</summary>
    [JsonPropertyName("loanAccountId")]
    public string? LoanAccountId { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("loanAmount")]
    public string? LoanAmount { get; set; }

    [JsonPropertyName("collateralAccountId")]
    public string? CollateralAccountId { get; set; }

    /// <summary>
    /// Includes &lt;ASSET&gt;-Earn entries when a Simple Earn Flexible position is pledged.
    /// </summary>
    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("loanTerm")]
    public string? LoanTerm { get; set; }

    /// <summary>
    /// Order status (Accruing_Interest, Overdue, Liquidating, Repaying, Repaid, Liquidated, Pending,
    /// Failed).
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("loanDate")]
    public string? LoanDate { get; set; }
}
