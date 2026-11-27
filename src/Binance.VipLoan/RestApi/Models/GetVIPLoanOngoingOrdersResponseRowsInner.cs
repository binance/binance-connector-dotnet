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

public sealed class GetVIPLoanOngoingOrdersResponseRowsInner
{
    [JsonPropertyName("orderId")]
    public long? OrderId { get; set; }

    [JsonPropertyName("loanCoin")]
    public string? LoanCoin { get; set; }

    [JsonPropertyName("totalDebt")]
    public string? TotalDebt { get; set; }

    /// <summary>For flexible loans, this is the flexible rate.</summary>
    [JsonPropertyName("loanRate")]
    public string? LoanRate { get; set; }

    [JsonPropertyName("residualInterest")]
    public string? ResidualInterest { get; set; }

    [JsonPropertyName("collateralAccountId")]
    public string? CollateralAccountId { get; set; }

    /// <summary>
    /// Includes &lt;ASSET&gt;-Earn entries when a Simple Earn Flexible position is pledged.
    /// </summary>
    [JsonPropertyName("collateralCoin")]
    public string? CollateralCoin { get; set; }

    [JsonPropertyName("totalCollateralValueAfterHaircut")]
    public string? TotalCollateralValueAfterHaircut { get; set; }

    [JsonPropertyName("lockedCollateralValue")]
    public string? LockedCollateralValue { get; set; }

    [JsonPropertyName("currentLTV")]
    public string? CurrentLTV { get; set; }

    /// <summary>For flexible loans, this value is 0.</summary>
    [JsonPropertyName("expirationTime")]
    public long? ExpirationTime { get; set; }

    [JsonPropertyName("loanDate")]
    public string? LoanDate { get; set; }

    /// <summary>For flexible loans, this value is open term.</summary>
    [JsonPropertyName("loanTerm")]
    public string? LoanTerm { get; set; }
}
